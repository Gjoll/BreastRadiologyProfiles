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

        SENode CreateResourceNode(ResourceMap.Node mapNode, Color color, bool linkFlag)
        {
            String hRef = null;
            if (linkFlag)
                hRef = HRef(mapNode);

            SENode node = new SENode(0, color, hRef);

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
            SENodeGroup parentsGroup = new SENodeGroup("parents");
            SENodeGroup focusGroup = new SENodeGroup("focus");
            SENodeGroup childrenGroup = new SENodeGroup("children");
            parentsGroup.Children.Add(focusGroup);
            focusGroup.Children.Add(childrenGroup);

            {
                SENode node = this.CreateResourceNode(focusNode, Color.White, false);
                focusGroup.Nodes.Add(node);
            }

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
                                SENode node = this.CreateResourceNode(parentNode, extensionColor, true);
                                extensionParents.Add(node);
                            }
                            break;

                        case "valueSet":
                            {
                                if (this.map.TryGetNode(link.LinkSource, out ResourceMap.Node parentNode) == false)
                                    throw new Exception($"Parent valueSet {link.LinkSource} not found in map");
                                SENode node = this.CreateResourceNode(parentNode, valueSetColor, true);
                                valueSetParents.Add(node);
                            }
                            break;

                        case "target":
                            {
                                if (this.map.TryGetNode(link.LinkSource, out ResourceMap.Node parentNode) == false)
                                    throw new Exception($"Parent resource {link.LinkSource} not found in map");
                                SENode node = this.CreateResourceNode(parentNode, targetColor, true);
                                targetParents.Add(node);
                            }
                            break;

                        default:
                            throw new NotImplementedException($"Unknown link type {link.LinkType}");
                    }
                }

                parentsGroup.Nodes.AddRange(targetParents);
                parentsGroup.Nodes.AddRange(valueSetParents);
                parentsGroup.Nodes.AddRange(extensionParents);
            }

            {
                SENodeGroup extensionChildren = new SENodeGroup("");
                SENodeGroup valueSetChildren = new SENodeGroup("");
                SENodeGroup targetChildren = new SENodeGroup("");
                SENodeGroup componentChildren = new SENodeGroup("");

                childrenGroup.Children.Add(targetChildren);
                childrenGroup.Children.Add(componentChildren);
                childrenGroup.Children.Add(valueSetChildren);
                childrenGroup.Children.Add(extensionChildren);

                foreach (ResourceMap.Link link in this.map.SourceLinks(focusNode.ResourceUrl))
                {
                    SENodeGroup nodeGroup = new SENodeGroup("");

                    switch (link.LinkType)
                    {
                        case "fragment":
                            break;

                        case "component":
                            {
                                componentChildren.Children.Add(nodeGroup);
                                SENode node = new SENode(0, componentColor);
                                String[] lines = link.LinkTarget.Split("^");
                                nodeGroup.Nodes.Add(node);

                                node.AddTextLine(lines[0]);
                                if (lines.Length > 1)
                                    node.AddTextLine(lines[1]);
                                if (lines.Length > 2)
                                {
                                    if (this.map.TryGetNode(lines[2], out ResourceMap.Node mapNode) == false)
                                        throw new Exception($"Component resource '{lines[2]}' not found!");

                                    SENodeGroup vsGroup = new SENodeGroup("vs");
                                    nodeGroup.Children.Add(vsGroup);
                                    String hRef = HRef(mapNode);
                                    SENode vsNode = new SENode(0, valueSetColor, hRef);
                                    vsGroup.Nodes.Add(vsNode);
                                    String s = mapNode.Name.Trim();
                                    vsNode.AddTextLine(s, hRef);
                                }
                            }
                            break;

                        case "extension":
                            {
                                if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == true)
                                {
                                    extensionChildren.Children.Add(nodeGroup);

                                    SENode node = this.CreateResourceNode(childNode, extensionColor, true);
                                    nodeGroup.Nodes.Add(node);
                                }
                            }
                            break;

                        case "valueSet":
                            {
                                if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == true)
                                {
                                    valueSetChildren.Children.Add(nodeGroup);
                                    SENode node = this.CreateResourceNode(childNode, valueSetColor, true);
                                    nodeGroup.Nodes.Add(node);
                                }
                            }
                            break;

                        case "target":
                            {
                                if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == false)
                                    throw new Exception($"Child target {link.LinkTarget} not found in map");
                                targetChildren.Children.Add(nodeGroup);
                                SENode node = this.CreateResourceNode(childNode, targetColor, true);
                                nodeGroup.Nodes.Add(node);
                            }
                            break;

                        default:
                            throw new NotImplementedException($"Unknown link type {link.LinkType}");
                    }
                }
            }

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
