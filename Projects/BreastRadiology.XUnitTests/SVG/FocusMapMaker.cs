using FhirKhit.Tools;
using Newtonsoft.Json.Linq;
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

                HashSet<String> alreadyLinkedResources = new HashSet<string>();

                foreach (dynamic link in this.map.TargetLinks(focusNode.ResourceUrl))
                {
                    switch (link.LinkType.ToObject<String>())
                    {
                        case "fragment":
                        case "component":
                            break;

                        case "extension":
                            {
                                String linkSource = link.LinkSource.ToObject<String>();
                                if (this.map.TryGetNode(linkSource, out ResourceMap.Node parentNode) == false)
                                    throw new Exception($"Parent extension {linkSource} not found in map");
                                if (alreadyLinkedResources.Contains(parentNode.ResourceUrl) == false)
                                {
                                    alreadyLinkedResources.Add(parentNode.ResourceUrl);
                                    SENode node = this.CreateResourceNode(parentNode, extensionColor, link.Cardinality?.ToString(), true);
                                    extensionParents.Add(node);
                                }
                            }
                            break;

                        case "valueSet":
                            {
                                String linkSource = link.LinkSource.ToObject<String>();
                                if (this.map.TryGetNode(linkSource, out ResourceMap.Node parentNode) == false)
                                    throw new Exception($"Parent valueSet {linkSource} not found in map");
                                if (alreadyLinkedResources.Contains(parentNode.ResourceUrl) == false)
                                {
                                    alreadyLinkedResources.Add(parentNode.ResourceUrl);
                                    SENode node = this.CreateResourceNode(parentNode, valueSetColor, link.Cardinality?.ToString(), true);
                                    valueSetParents.Add(node);
                                }
                            }
                            break;

                        case "target":
                            {
                                String linkSource = link.LinkSource.ToObject<String>();
                                if (this.map.TryGetNode(linkSource, out ResourceMap.Node parentNode) == false)
                                    throw new Exception($"Parent resource {linkSource} not found in map");
                                if (alreadyLinkedResources.Contains(parentNode.ResourceUrl) == false)
                                {
                                    alreadyLinkedResources.Add(parentNode.ResourceUrl);
                                    SENode node = this.CreateResourceNode(parentNode, targetColor, link.Cardinality?.ToString(), true);
                                    targetParents.Add(node);
                                }
                            }
                            break;

                        default:
                            throw new NotImplementedException($"Unknown link type {link.LinkType.ToObject<String>()}");
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

                foreach (dynamic link in this.map.SourceLinks(focusNode.ResourceUrl))
                {
                    switch (link.LinkType.ToObject<String>())
                    {
                        case "fragment":
                            break;

                        case "component":
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

                                JArray references = (JArray) link.References;
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
                            break;

                        case "extension":
                            {
                                String linkSource = link.LinkSource.ToObject<String>();
                                String componentHRef = link.ComponentHRef.ToObject<String>().Replace("{SDName}", linkSource.LastUriPart());

                                SENode node = new SENode(0, extensionReferenceColor, link.Cardinality?.ToString(), componentHRef);
                                node.AddTextLine(link.LocalName.ToObject<String>(), componentHRef);

                                SENodeGroup nodeGroup = new SENodeGroup(node.AllText(), true);
                                extensionChildren.AppendChild(nodeGroup);
                                nodeGroup.AppendNode(node);

                                {
                                    SENodeGroup extGroup = new SENodeGroup("extension", false);
                                    nodeGroup.AppendChild(extGroup);
                                    SENode extNode;
                                    String extUrl = link.LinkTarget.ToObject<String>().Trim();
                                    if (extUrl.ToLower().StartsWith(Global.BreastRadBaseUrl))
                                    {
                                        if (this.map.TryGetNode(extUrl, out ResourceMap.Node vsNode) == false)
                                            throw new Exception($"Component resource '{extUrl}' not found!");
                                        extNode = this.CreateResourceNode(vsNode, extensionColor, link.Cardinality?.ToString(), true);
                                    }
                                    else
                                    {
                                        String name = extUrl.LastUriPart()
                                            .TrimStart("StructureDefinition-")
                                            .TrimStart("ValueSet-")
                                            .TrimEnd(".html")
                                            ;
                                        extNode = new SENode(0, valueSetColor, link.Cardinality?.ToString(), null, extUrl);
                                        extNode.AddTextLine(name, extUrl);
                                    }
                                    extGroup.AppendNode(extNode);
                                }
                            }
                            break;

                        case "valueSet":
                            {
                                if (this.map.TryGetNode(link.LinkTarget.ToObject<String>().ToObject<String>(), out ResourceMap.Node childNode) == true)
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
                                if (this.map.TryGetNode(link.LinkTarget.ToObject<String>(), out ResourceMap.Node childNode) == false)
                                    throw new Exception($"Child target {link.LinkTarget.ToObject<String>()} not found in map");
                                SENode node = this.CreateResourceNode(childNode, targetColor, link.Cardinality?.ToString(), true);
                                SENodeGroup nodeGroup = new SENodeGroup(node.AllText(), true);
                                targetChildren.AppendChild(nodeGroup);
                                nodeGroup.AppendNode(node);
                            }
                            break;

                        default:
                            throw new NotImplementedException($"Unknown link type {link.LinkType.ToObject<String>()}");
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
