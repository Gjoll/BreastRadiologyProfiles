using FhirKhit.Tools;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    class MapMaker
    {
        protected ResourceMap map;

        protected Color extensionReferenceColor = Color.LightSkyBlue;
        protected Color extensionColor = Color.LightBlue;
        protected Color valueSetColor = Color.LightGreen;
        protected Color targetColor = Color.LightCyan;
        protected Color componentColor = Color.LightYellow;

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


        protected SENode CreateResourceNode(ResourceMap.Node mapNode,
            Color color,
            String annotation,
            bool linkFlag)
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

        protected void MakeComponent(dynamic link,
            SENodeGroup componentChildren)
        {
            String linkSource = link.LinkSource.ToObject<String>();
            String componentHRef = link.ComponentHRef.ToObject<String>().Replace("{SDName}", linkSource.LastUriPart());

            SENode node = new SENode(0, componentColor, link.Cardinality?.ToString(), componentHRef);
            node.AddTextLine(link.LinkTarget.ToObject<String>(), componentHRef);

            String types = link.Types?.ToObject<String>();
            if (String.IsNullOrEmpty(types) == false)
                node.AddTextLine(types, componentHRef);
            SENodeGroup nodeGroup = new SENodeGroup(node.AllText(), true);
            componentChildren.AppendChild(nodeGroup);
            nodeGroup.AppendNode(node);

            JArray references = (JArray)link.References;
            if (references != null)
            {
                SENodeGroup refGroup = new SENodeGroup("ref", false);
                nodeGroup.AppendChild(refGroup);

                Color refColor = Color.White;
                switch (link.ReferenceType.ToObject<String>())
                {
                    case "valueSet":
                        refColor = valueSetColor;
                        break;

                    case "target":
                        refColor = targetColor;
                        break;

                    default:
                        throw new NotImplementedException();
                }
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
