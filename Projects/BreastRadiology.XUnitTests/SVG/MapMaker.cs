using FhirKhit.Tools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    class MapMaker
    {
        protected ResourceMap map;
        protected bool showCardinality = true;
        protected Color focusColor = Color.White;
        protected Color extensionReferenceColor = Color.LightSkyBlue;
        protected Color extensionColor = Color.LightBlue;
        protected Color valueSetColor = Color.LightGreen;
        protected Color targetColor = Color.LightCyan;
        protected Color componentColor = Color.LightYellow;

        // these are use to determine if children of a node can be
        // grouped with the children of the last parent node, or if a new group need to be created
        // to group the current children seperately.
        dynamic[] previousChildLinks = new Object[0];

        protected bool DifferentChildren(dynamic[] links1, dynamic[] links2)
        {
            if (links1 == null)
                return true;
            if (links2 == null)
                return true;
            if (links1.Length != links2.Length)
                return true;
            for (Int32 i = 0; i < links1.Length; i++)
            {
                dynamic link1 = links1[i];
                dynamic link2 = links2[i];
                if (link1.LinkType.ToObject<String>() != link2.LinkType.ToObject<String>())
                    return true;
                if (link1.LinkTarget.ToObject<String>() != (String)link2.LinkTarget.ToObject<String>())
                    return true;
            }
            return false;
        }

        String[] linkTypes = new string[] { SVGGlobal.ExtensionType, SVGGlobal.TargetType, SVGGlobal.ComponentType};

        /*
         * Add children. If two adjacent children have same children, then dont create each in a seperate
         * group. Have the two nodes point to the same group of children.
         */
        protected void AddChildren(ResourceMap.Node mapNode,
            SENodeGroup group,
            bool showChildren)
        {
            this.AddChildren(mapNode, mapNode.LinksByLinkType(linkTypes).ToArray(), group, showChildren);
        }

        protected SENode CreateResourceNode(ResourceMap.Node mapNode,
            dynamic link,
            bool linkFlag = true)
        {
            return CreateResourceNode(mapNode, this.LinkTypeColor(link), link.Cardinality?.ToString(), linkFlag);
        }

        protected SENode CreateResourceNode(ResourceMap.Node mapNode,
        Color color,
        String annotation,
        bool linkFlag = true)
        {
            String hRef = null;
            if (linkFlag)
                hRef = HRef(mapNode);

            SENode node = new SENode(0, color, annotation, null, hRef);

            foreach (String titlePart in mapNode.MapName)
            {
                String s = titlePart.Trim();
                node.AddTextLine(s, hRef);
            }
            return node;
        }

        protected void DirectLink(SENodeGroup group,
            ResourceMap.Node mapNode,
            dynamic link,
            bool showChildren)
        {
            String linkTargetUrl = link.LinkTarget.ToObject<String>();

            void CreateDirectNode(SENodeGroup g)
            {
                if (this.map.TryGetNode(linkTargetUrl, out ResourceMap.Node linkTargetNode) == false)
                    throw new Exception("ResourceMap.Node '{link.ResourceUrl}' not found");
                SENode node = this.CreateResourceNode(linkTargetNode, link);
                g.AppendNode(node);
            }

            dynamic[] childMapLinks = new Object[0];

            ResourceMap.Node childMapNode = null;

            bool linkToLastGroup = false;
            if (showChildren)
            {
                childMapNode = this.map.GetNode(linkTargetUrl);
                childMapLinks = childMapNode.LinksByLinkType(linkTypes).ToArray();
                if (childMapLinks.Length > 0)
                    linkToLastGroup = !this.DifferentChildren(previousChildLinks, childMapLinks);
            }

            if (linkToLastGroup)
            {
                SENodeGroup groupChild = group.Children.Last();
                CreateDirectNode(groupChild);
            }
            else
            {
                SENodeGroup groupChild = group.AppendChild("", this.showCardinality);
                CreateDirectNode(groupChild);
                if (showChildren)
                    this.AddChildren(childMapNode, childMapLinks, groupChild, link.ShowChildren.ToObject<Boolean>());
                previousChildLinks = childMapLinks;
            }
        }

        protected void AddChildren(ResourceMap.Node mapNode,
            dynamic[] links,
            SENodeGroup group,
            bool showChildren)
        {
            if (links.Length == 0)
                return;
            foreach (dynamic link in links)
            {
                switch (link.LinkType.ToObject<String>())
                {
                    case SVGGlobal.ComponentType:
                        MakeComponent(link, group, showChildren);
                        break;

                    default:
                        DirectLink(group, mapNode, link, showChildren);
                        break;
                }
            }
        }


        public MapMaker(ResourceMap map)
        {
            this.map = map;
        }

        protected String HRef(ResourceMap.Node mapNode)
        {
            if (mapNode.ResourceUrl.StartsWith("http://hl7.org/fhir/StructureDefinition/"))
                return mapNode.ResourceUrl;
            return $"./{mapNode.StructureName}-{mapNode.Name}.html";
        }


        protected Color LinkTypeColor(dynamic link)
        {
            switch (link.LinkType.ToObject<String>())
            {
                case SVGGlobal.ExtensionType: return extensionColor;
                case SVGGlobal.ComponentType: return componentColor;
                case SVGGlobal.ValueSetType: return valueSetColor;
                case SVGGlobal.TargetType: return targetColor;
                default: throw new NotImplementedException();
            }
        }

        protected void MakeComponent(dynamic link,
                SENodeGroup group,
                bool showChildren)
        {
            // we never link components to previous child links, not should next item
            // link to this items children. Each component stands alone.
            previousChildLinks = new Object[0];

            String linkTargetUrl = link.LinkTarget.ToObject<String>();
            String linkSource = link.LinkSource.ToObject<String>();
            String componentHRef = link.ComponentHRef.ToObject<String>().Replace("{SDName}", linkSource.LastUriPart());

            SENode node = new SENode(0, componentColor, link.Cardinality?.ToString(), componentHRef);
            node.AddTextLine(linkTargetUrl, componentHRef);

            String types = link.Types?.ToObject<String>();
            if (String.IsNullOrEmpty(types) == false)
                node.AddTextLine(types, componentHRef);
            SENodeGroup componentGroup = new SENodeGroup(node.AllText(), this.showCardinality);
            group.AppendChild(componentGroup);
            componentGroup.AppendNode(node);

            JArray references = (JArray)link.References;
            if (references != null)
            {
                SENodeGroup refGroup = new SENodeGroup("ref", false);
                componentGroup.AppendChild(refGroup);

                Color refColor = this.LinkTypeColor(link);

                foreach (JValue item in references)
                {
                    String reference = item.ToObject<String>();
                    SENode refNode;
                    String vsUrl = reference.Trim();
                    if (vsUrl.ToLower().StartsWith(Global.BreastRadBaseUrl))
                    {
                        if (this.map.TryGetNode(vsUrl, out ResourceMap.Node vsNode) == false)
                            throw new Exception($"Component resource '{vsUrl}' not found!");
                        refNode = this.CreateResourceNode(vsNode, refColor, link.Cardinality?.ToString(), true);

                        if (showChildren)
                        {
                            var childMapNode = this.map.GetNode(reference);
                            this.AddChildren(childMapNode, refGroup, link.ShowChildren.ToObject<Boolean>());
                        }
                    }
                    else
                    {
                        refNode = new SENode(0, refColor, link.Cardinality?.ToString(), null, vsUrl);
                        refNode.AddTextLine(vsUrl.LastUriPart(), vsUrl);
                    }
                    refGroup.AppendNode(refNode);
                }
            }
        }
    }
}
