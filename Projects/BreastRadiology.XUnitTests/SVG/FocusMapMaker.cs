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
            parentsGroup.AppendChild(focusGroup);
            focusGroup.AppendChild(childrenGroup);

            {
                SENode node = this.CreateResourceNode(focusNode, Color.White, false);
                focusGroup.AppendNode(node);
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

                parentsGroup.AppendNodes(targetParents);
                parentsGroup.AppendNodes(valueSetParents);
                parentsGroup.AppendNodes(extensionParents);
            }

            {
                SENodeGroup targetChildren = new SENodeGroup("A.Targets");
                SENodeGroup componentChildren = new SENodeGroup("B.Components");
                SENodeGroup extensionChildren = new SENodeGroup("C.Extensions");
                SENodeGroup valueSetChildren = new SENodeGroup("D.ValueSets");

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

                                SENode node = new SENode(0, componentColor, componentHRef);
                                node.AddTextLine(lines[0], componentHRef);

                                if (lines.Length > 2)
                                    node.AddTextLine(lines[2], componentHRef);

                                SENodeGroup nodeGroup = new SENodeGroup(node.AllText());
                                componentChildren.AppendChild(nodeGroup);
                                nodeGroup.AppendNode(node);

                                if (lines.Length > 3)
                                {
                                    if (this.map.TryGetNode(lines[3], out ResourceMap.Node mapNode) == false)
                                        throw new Exception($"Component resource '{lines[3]}' not found!");

                                    SENodeGroup vsGroup = new SENodeGroup("vs");
                                    nodeGroup.AppendChild(vsGroup);
                                    String hRef = HRef(mapNode);
                                    SENode vsNode = new SENode(0, valueSetColor, hRef);
                                    vsGroup.AppendNode(vsNode);
                                    String s = mapNode.Name.Trim();
                                    vsNode.AddTextLine(s, hRef);
                                }
                            }
                            break;

                        case "extension":
                            {
                                if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == true)
                                {
                                    SENode node = this.CreateResourceNode(childNode, extensionColor, true);
                                    SENodeGroup nodeGroup = new SENodeGroup(node.AllText());
                                    extensionChildren.AppendChild(nodeGroup);
                                    nodeGroup.AppendNode(node);
                                }
                            }
                            break;

                        case "valueSet":
                            {
                                if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == true)
                                {
                                    SENode node = this.CreateResourceNode(childNode, valueSetColor, true);
                                    SENodeGroup nodeGroup = new SENodeGroup(node.AllText());
                                    valueSetChildren.AppendChild(nodeGroup);
                                    nodeGroup.AppendNode(node);
                                }
                            }
                            break;

                        case "target":
                            {
                                if (this.map.TryGetNode(link.LinkTarget, out ResourceMap.Node childNode) == false)
                                    throw new Exception($"Child target {link.LinkTarget} not found in map");
                                SENode node = this.CreateResourceNode(childNode, targetColor, true);
                                SENodeGroup nodeGroup = new SENodeGroup(node.AllText());
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
