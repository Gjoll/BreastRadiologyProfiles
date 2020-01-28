using FhirKhit.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    /// <summary>
    /// Create graphic of all resources.
    /// </summary>
    class ResourceMapMaker : MapMaker
    {
        FileCleaner fc;

        public ResourceMapMaker(FileCleaner fc,
            ResourceMap map) : base(map)
        {
            this.fc = fc;
        }

        SENode CreateNode(ResourceMap.Node mapNode, Color color, String annotation)
        {
            String hRef = HRef(mapNode);
            SENode node = new SENode(0, color, annotation, hRef, mapNode.Name);
            foreach (String titlePart in mapNode.MapName)
            {
                String s = titlePart.Trim();
                node.AddTextLine(s, hRef);
            }
            return node;
        }

        bool DifferentChildren(dynamic[] links1, dynamic[] links2)
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

        String[] linkNames = new string[] { "extension", "target", "component" };
        /*
         * Add children. If two adjacent children have same children, then dont create each in a seperate
         * group. Have the two nodes point to the same group of children.
         */
        void AddChildren(ResourceMap.Node mapNode,
            SENodeGroup group)
        {
            this.AddChildren(mapNode, mapNode.LinksByName(linkNames).ToArray(), group);
        }

        dynamic[] previousChildLinks = null;
        dynamic[] childMapLinks = null;

        void DirectLink(SENodeGroup group,
            ResourceMap.Node mapNode,
            dynamic link)
        {
            SENodeGroup groupChild = null;

            String linkTargetUrl = link.LinkTarget.ToObject<String>();
            ResourceMap.Node childMapNode = this.map.GetNode(linkTargetUrl);
            if (link.ShowChildren.ToObject<Boolean>())
            {
                childMapLinks = childMapNode.LinksByName(linkNames).ToArray();
                if (this.DifferentChildren(previousChildLinks, childMapLinks))
                    previousChildLinks = null;
            }
            else
                previousChildLinks = null;

            if (previousChildLinks == null)
            {
                groupChild = group.AppendChild("", false);
                if (link.ShowChildren.ToObject<Boolean>())
                {
                    this.AddChildren(childMapNode, childMapLinks, groupChild);
                    previousChildLinks = childMapLinks;
                }
            }

            {
                if (this.map.TryGetNode(linkTargetUrl, out ResourceMap.Node linkTargetNode) == false)
                    throw new Exception("ResourceMap.Node '{link.ResourceUrl}' not found");
                SENode node = this.CreateNode(linkTargetNode, targetColor, link.Cardinality?.ToString());
                groupChild.AppendNode(node);
            }
        }

        void AddChildren(ResourceMap.Node mapNode,
            dynamic[] links,
            SENodeGroup group)
        {

            if (links.Length == 0)
                return;
            foreach (dynamic link in links)
            {
                switch (link.LinkType.ToObject<String>())
                {
                    case "component":
                        MakeComponent(link, group);
                        if (link.ShowChildren.ToObject<Boolean>())
                        {
                            //$this.AddChildren(childMapNode, childMapLinks, groupChild);
                            //$previousChildLinks = childMapLinks;
                        }
                        break;

                    default:
                        DirectLink(group, mapNode, link);
                        break;
                }
            }
        }

        public void Create(String baseUrl, String outputPath)
        {
            SvgEditor svgEditor = new SvgEditor();
            SENodeGroup rootGroup = this.CreateNodes(baseUrl);
            svgEditor.Render(rootGroup, true);
            svgEditor.Save(outputPath);
            fc?.Mark(outputPath);
        }


        SENodeGroup CreateNodes(String reportUrl)
        {
            ResourceMap.Node mapNode = this.map.GetNode(reportUrl);
            SENodeGroup rootGroup = new SENodeGroup("root", false);
            SENode rootNode = this.CreateNode(mapNode, focusColor , null);
            rootGroup.AppendNode(rootNode);
            this.AddChildren(mapNode, rootGroup);
            return rootGroup;
        }
    }
}
