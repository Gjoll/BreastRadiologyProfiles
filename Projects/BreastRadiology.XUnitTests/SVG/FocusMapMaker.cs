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

        SENode CreateResourceNode(ResourceMap.Node mapNode, Color color, bool linkFlag)
        {
            SENode node = new SENode(0, color);

            foreach (String titlePart in mapNode.MapName)
            {
                String hRef = null;
                String title = null;
                if (linkFlag)
                {
                    hRef = $"./{mapNode.StructureName}-{mapNode.Name}.html";
                    title = $"'{mapNode.Name}'";
                }
                String s = titlePart.Trim();
                node.AddTextLine(s, hRef, title);
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
                List<SENode> extensionChildren = new List<SENode>();
                List<SENode> valueSetChildren = new List<SENode>();
                List<SENode> targetChildren = new List<SENode>();
                List<SENode> componentChildren = new List<SENode>();

                foreach (ResourceMap.Link link in this.map.SourceLinks(focusNode.ResourceUrl))
                {
                    switch (link.LinkType)
                    {
                        case "fragment":
                            break;

                        case "component":
                            {
                                SENode node = new SENode(0, componentColor);
                                String[] lines = link.LinkTarget.Split("^");
                                node.AddTextLine(lines[0]);
                                if (lines.Length > 1)
                                    node.AddTextLine(lines[1]);
                                if (lines.Length > 2)
                                {
                                    if (this.map.TryGetNode(lines[2], out ResourceMap.Node mapNode) == false)
                                        throw new Exception($"Component resource '{lines[2]}' not found!");

                                    String hRef = null;
                                    String title = null;
                                    hRef = $"./{mapNode.StructureName}-{mapNode.Name}.html";
                                    title = $"'{mapNode.Name}'";
                                    String s = mapNode.Name.Trim();
                                    node.AddTextLine(s, hRef, title);
                                }
                                extensionChildren.Add(node);
                            }
                            break;

                        case "extension":
                            {
                                if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == true)
                                {
                                    SENode node = this.CreateResourceNode(childNode, extensionColor, true);
                                    extensionChildren.Add(node);
                                }
                            }
                            break;

                        case "valueSet":
                            {
                                if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == true)
                                {
                                    SENode node = this.CreateResourceNode(childNode, valueSetColor, true);
                                    valueSetChildren.Add(node);
                                }
                            }
                            break;

                        case "target":
                            {
                                if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == false)
                                    throw new Exception($"Child target {link.LinkTarget} not found in map");
                                SENode node = this.CreateResourceNode(childNode, targetColor, true);
                                targetChildren.Add(node);
                            }
                            break;

                        default:
                            throw new NotImplementedException($"Unknown link type {link.LinkType}");
                    }
                }

                childrenGroup.Nodes.AddRange(targetChildren);
                childrenGroup.Nodes.AddRange(componentChildren);
                childrenGroup.Nodes.AddRange(valueSetChildren);
                childrenGroup.Nodes.AddRange(extensionChildren);
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
