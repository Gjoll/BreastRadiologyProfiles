using FhirKhit.Tools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreastRadiology.XUnitTests
{
    /// <summary>
    /// Create graphic for each resourece showing fragment parents and children..
    /// </summary>
    class FocusMapMaker
    {
        ResourceMap map;
        String graphicsDir;
        String contentDir;
        FileCleaner fc;


        public FocusMapMaker(FileCleaner fc,
            ResourceMap map,
            String graphicsDir,
            String contentDir)
        {
            this.fc = fc;
            this.map = map;
            this.graphicsDir = graphicsDir;
            this.contentDir = contentDir;
        }

        public static String FocusMapName(ResourceMap.Node mapNode) => $"Focus-{mapNode.Name}.svg";
        public static String FocusMapName(String name) => $"Focus-{name}.svg";
        String IntroName(ResourceMap.Node mapNode) => $"{mapNode.StructureName}-{mapNode.Name}-intro.xml";

        String HRef(ResourceMap.Node mapNode)
        {
            if (mapNode.ResourceUrl.StartsWith("http://hl7.org/fhir/StructureDefinition/"))
                return mapNode.ResourceUrl;
            return $"./{mapNode.StructureName}-{mapNode.Name}.html";
        }

        SENode CreateResourceNode(ResourceMap.Node mapNode,
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

        void GraphNode(ResourceMap.Node focusNode)
        {
            if (focusNode.Name.Contains("Fragment", new StringComparison()) == true)
                return;

            Trace.WriteLine($"Creating focus graph {focusNode.Name}");
            SvgEditor e = new SvgEditor();
            SENodeGroup parentsGroup = new SENodeGroup("parents", false);
            SENodeGroup focusGroup = new SENodeGroup("focus", false);
            SENodeGroup childrenGroup = new SENodeGroup("children", true);
            parentsGroup.AppendChild(focusGroup);
            focusGroup.AppendChild(childrenGroup);
            {
                SENode node = this.CreateResourceNode(focusNode, Color.White, null, false);
                focusGroup.AppendNode(node);
            }
            Color extensionReferenceColor = Color.LightSkyBlue;
            Color extensionColor = Color.LightBlue;
            Color valueSetColor = Color.LightGreen;
            Color targetColor = Color.LightCyan;
            Color componentColor = Color.LightYellow;
            {
                List<SENode> extensionParents = new List<SENode>();
                List<SENode> valueSetParents = new List<SENode>();
                List<SENode> targetParents = new List<SENode>();

                foreach (ResourceMap.Link link in this.map.TargetLinks(focusNode.ResourceUrl))
                {
                    switch (link.LinkType)
                    {
                        case "fragment":
                        case "component":
                            break;

                        case "extension":
                            {
                                if (this.map.TryGetNode(link.LinkSource, out ResourceMap.Node parentNode) == false)
                                    throw new Exception($"Parent extension {link.LinkSource} not found in map");
                                SENode node = this.CreateResourceNode(parentNode, extensionColor, link.Cardinality?.ToString(), true);
                                extensionParents.Add(node);
                            }
                            break;

                        case "valueSet":
                            {
                                if (this.map.TryGetNode(link.LinkSource, out ResourceMap.Node parentNode) == false)
                                    throw new Exception($"Parent valueSet {link.LinkSource} not found in map");
                                SENode node = this.CreateResourceNode(parentNode, valueSetColor, link.Cardinality?.ToString(), true);
                                valueSetParents.Add(node);
                            }
                            break;

                        case "target":
                            {
                                if (this.map.TryGetNode(link.LinkSource, out ResourceMap.Node parentNode) == false)
                                    throw new Exception($"Parent resource {link.LinkSource} not found in map");
                                SENode node = this.CreateResourceNode(parentNode, targetColor, link.Cardinality?.ToString(), true);
                                targetParents.Add(node);
                            }
                            break;

                        default:
                            throw new NotImplementedException($"Unknown link type {link.LinkType}");
                    }
                }
                parentsGroup.AppendNodes(targetParents);
                parentsGroup.AppendNodes(valueSetParents);
                parentsGroup.AppendNodes(extensionParents);
            }
            {
                SENodeGroup targetChildren = new SENodeGroup("A.Targets", true);
                SENodeGroup componentChildren = new SENodeGroup("B.Components", true);
                SENodeGroup extensionChildren = new SENodeGroup("C.Extensions", true);
                SENodeGroup valueSetChildren = new SENodeGroup("D.ValueSets", true);

                childrenGroup.AppendChild(targetChildren);
                childrenGroup.AppendChild(componentChildren);
                childrenGroup.AppendChild(valueSetChildren);
                childrenGroup.AppendChild(extensionChildren);

                foreach (ResourceMap.Link link in this.map.SourceLinks(focusNode.ResourceUrl))
                {
                    switch (link.LinkType)
                    {
                        case "fragment":
                            break;

                        case "component":
                            {
                                String[] lines = link.LinkTarget.Split("^");
                                String componentHRef = lines[1];
                                componentHRef = componentHRef.Replace("{SDName}", link.LinkSource.LastUriPart());

                                SENode node = new SENode(0, componentColor, link.Cardinality?.ToString(), componentHRef);
                                node.AddTextLine(lines[0], componentHRef);

                                if (lines.Length > 2)
                                    node.AddTextLine(lines[2], componentHRef);
                                SENodeGroup nodeGroup = new SENodeGroup(node.AllText(), true);
                                componentChildren.AppendChild(nodeGroup);
                                nodeGroup.AppendNode(node);

                                if (lines.Length > 3)
                                {
                                    SENodeGroup vsGroup = new SENodeGroup("vs", false);
                                    nodeGroup.AppendChild(vsGroup);
                                    SENode vs2Node;
                                    String vsUrl = lines[3].Trim();
                                    if (vsUrl.ToLower().StartsWith(Global.BreastRadBaseUrl))
                                    {
                                        if (this.map.TryGetNode(vsUrl, out ResourceMap.Node vsNode) == false)
                                            throw new Exception($"Component resource '{vsUrl}' not found!");
                                        vs2Node = this.CreateResourceNode(vsNode, valueSetColor, link.Cardinality?.ToString(), true);
                                    }
                                    else
                                    {
                                        vs2Node = new SENode(0, valueSetColor, link.Cardinality?.ToString(), null, vsUrl);
                                        vs2Node.AddTextLine(vsUrl.LastUriPart(), vsUrl);
                                    }
                                    vsGroup.AppendNode(vs2Node);
                                }
                            }
                            break;

                        case "extension":
                            {
                                String[] lines = link.LinkTarget.Split("^");
                                String componentHRef = lines[1];
                                componentHRef = componentHRef.Replace("{SDName}", link.LinkSource.LastUriPart());

                                SENode node = new SENode(0, extensionReferenceColor, link.Cardinality?.ToString(), componentHRef);
                                node.AddTextLine(lines[2], componentHRef);

                                SENodeGroup nodeGroup = new SENodeGroup(node.AllText(), true);
                                componentChildren.AppendChild(nodeGroup);
                                nodeGroup.AppendNode(node);

                                {
                                    SENodeGroup extGroup = new SENodeGroup("extension", false);
                                    nodeGroup.AppendChild(extGroup);
                                    SENode extNode;
                                    String extUrl = lines[0].Trim();
                                    if (extUrl.ToLower().StartsWith(Global.BreastRadBaseUrl))
                                    {
                                        if (this.map.TryGetNode(extUrl, out ResourceMap.Node vsNode) == false)
                                            throw new Exception($"Component resource '{extUrl}' not found!");
                                        extNode = this.CreateResourceNode(vsNode, extensionColor, link.Cardinality?.ToString(), true);
                                    }
                                    else
                                    {
                                        extNode = new SENode(0, valueSetColor, link.Cardinality?.ToString(), null, extUrl);
                                        extNode.AddTextLine(extUrl.LastUriPart(), extUrl);
                                    }
                                    extGroup.AppendNode(extNode);
                                }

                                //if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == true)
                                //{
                                //    SENode node = this.CreateResourceNode(childNode, extensionColor, link.Cardinality?.ToString(), true);
                                //    SENodeGroup nodeGroup = new SENodeGroup(node.AllText(), false);
                                //    extensionChildren.AppendChild(nodeGroup);
                                //    nodeGroup.AppendNode(node);
                                //}
                            }
                            break;

                        case "valueSet":
                            {
                                if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == true)
                                {
                                    SENode node = this.CreateResourceNode(childNode, valueSetColor, link.Cardinality?.ToString(), true);
                                    SENodeGroup nodeGroup = new SENodeGroup(node.AllText(), false);
                                    valueSetChildren.AppendChild(nodeGroup);
                                    nodeGroup.AppendNode(node);
                                }
                            }
                            break;

                        case "target":
                            {
                                if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == false)
                                    throw new Exception($"Child target {link.LinkTarget} not found in map");
                                SENode node = this.CreateResourceNode(childNode, targetColor, link.Cardinality?.ToString(), true);
                                SENodeGroup nodeGroup = new SENodeGroup(node.AllText(), true);
                                targetChildren.AppendChild(nodeGroup);
                                nodeGroup.AppendNode(node);
                            }
                            break;

                        default:
                            throw new NotImplementedException($"Unknown link type {link.LinkType}");
                    }
                }
            }

            parentsGroup.Sort();
            e.Render(parentsGroup, true);
            String outputPath = Path.Combine(this.graphicsDir, FocusMapName(focusNode));
            fc?.Mark(outputPath);
            e.Save(outputPath);
        }


        public void Create()
        {
            foreach (ResourceMap.Node focusNode in this.map.Nodes)
                this.GraphNode(focusNode);
        }
    }
}
