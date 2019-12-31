using FhirKhit.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    /// <summary>
    /// Create graphic for each resourece showing fragment parents and children..
    /// </summary>
    class FragmentMapMaker
    {
        class FragmentNode
        {
            public ResourceMap.Node Focus;
            public List<ResourceMap.Node> Parents = new List<ResourceMap.Node>();
            public List<ResourceMap.Node> Children = new List<ResourceMap.Node>();
        }

        List<ResourceMap.Node> selectedNodes = new List<ResourceMap.Node>();
        Dictionary<String, FragmentNode> fragmentNodes = new Dictionary<string, FragmentNode>();
        String graphicsDir;

        ResourceMap map;
        FileCleaner fc;
        String pageDir;
        String pageTemplateDir;

        public FragmentMapMaker(FileCleaner fc,
            ResourceMap map,
            String graphicsDir,
            String pageDir,
            String pageTemplateDir)
        {
            this.fc = fc;
            this.map = map;
            this.graphicsDir = graphicsDir;
            this.pageDir = pageDir;
            this.pageTemplateDir = pageTemplateDir;
        }

        String FragmentMapName(ResourceMap.Node mapNode) => $"FragmentMap_{mapNode.Name}.svg";

        IEnumerable<ResourceMap.Link> FragmentLinks(ResourceMap.Node n)
        {
            foreach (ResourceMap.Link link in n.Links)
            {
                switch (link.LinkType)
                {
                    case "fragment":
                        yield return link;
                        break;
                }
            }
        }

        void LinkNodes()
        {
            foreach (ResourceMap.Node focusMapNode in this.selectedNodes)
            {
                if (this.fragmentNodes.TryGetValue(focusMapNode.Name, out FragmentNode fragmentFocusNode) == false)
                    throw new Exception($"Internal error. Cant find Focus FragmentNode '{focusMapNode.Name}' ");

                foreach (ResourceMap.Link link in this.FragmentLinks(focusMapNode))
                {
                    ResourceMap.Node referencedMapNode = this.map.GetNode(link.ResourceUrl);
                    fragmentFocusNode.Parents.Add(referencedMapNode);

                    if (this.fragmentNodes.TryGetValue(referencedMapNode.Name, out FragmentNode fragmentParentNode) == false)
                        throw new Exception($"Internal error. Cant find FragmentNode '{referencedMapNode.Name}' ");
                    fragmentParentNode.Children.Add(focusMapNode);
                }
            }
        }

        SENode CreateNode(ResourceMap.Node mapNode, Color color, bool linkFlag)
        {
            if (this.map.TryGetNode(mapNode.ResourceUrl, out var dummy) == false)
                throw new Exception($"Referenced node {mapNode.ResourceUrl} not found in map");

            SENode node = new SENode(0, color);
            foreach (String titlePart in mapNode.MapName)
            {
                String hRef = null;
                String title = null;
                if (linkFlag)
                {
                    String fragMapName = $"{mapNode.StructureName}-Fragment{mapNode.Name}.html";
                    hRef = $"./{fragMapName}";
                    title = $"'Fragment {mapNode.Name}'";
                }
                String s = titlePart.Trim();
                node.AddTextLine(s, hRef, title);
            }

            if (mapNode.IsFragment == false)
            {
                String hRef = $"{mapNode.StructureName}-{mapNode.Name}.html";
                String title = $"Resource '{mapNode.Name}'";
                node.AddTextLine("[Resource]", hRef, title);
            }
            return node;
        }

        void GraphNode(FragmentNode fragmentNode)
        {
            SvgEditor e = new SvgEditor();
            SENodeGroup parentsGroup = new SENodeGroup("parents");
            SENodeGroup focusGroup = new SENodeGroup("focus");
            SENodeGroup childrenGroup = new SENodeGroup("children");
            parentsGroup.Children.Add(focusGroup);
            focusGroup.Children.Add(childrenGroup);

            {
                SENode node = this.CreateNode(fragmentNode.Focus, Color.Green, false);
                focusGroup.Nodes.Add(node);
            }

            foreach (ResourceMap.Node childNode in fragmentNode.Children)
            {
                SENode node = this.CreateNode(childNode, Color.LightBlue, true);
                childrenGroup.Nodes.Add(node);
            }

            foreach (ResourceMap.Node parentNode in fragmentNode.Parents)
            {
                SENode node = this.CreateNode(parentNode, Color.LightCyan, true);
                parentsGroup.Nodes.Add(node);
            }

            e.Render(parentsGroup, true);
            String svgName = this.FragmentMapName(fragmentNode.Focus);
            String outputSvgPath = Path.Combine(this.graphicsDir, svgName);
            this.fc?.Mark(outputSvgPath);
            e.Save(outputSvgPath);

            {
                IntroDoc doc = new IntroDoc(Path.Combine(pageDir, $"StructureDefinition-Fragment{fragmentNode.Focus.Name}-intro.xml"));
                doc
                    .AddSvgImage($"FragmentMap_{fragmentNode.Focus.Name}.svg")
                    ;
                String outputDocPath = doc.Save();
                this.fc?.Mark(outputDocPath);
            }

            this.fragmentsBlock
                .AppendLine($"<p>")
                .AppendLine($"Fragment Diagram {fragmentNode.Focus.Name}")
                .AppendLine($"</p>")
                .AppendLine($"<object data=\"{svgName}\" type=\"image/svg+xml\">")
                .AppendLine($"    <img src=\"{svgName}\" alt=\"{fragmentNode.Focus.Name}\"/>")
                .AppendLine($"</object>");
            ;
        }

        void GraphNodes()
        {
            foreach (FragmentNode fragmentNode in this.fragmentNodes.Values)
                this.GraphNode(fragmentNode);
        }

        /// <summary>
        /// Select nodes we are going to process.
        /// </summary>
        void SelectNodes()
        {
            foreach (ResourceMap.Node mapNode in this.map.MapNodes)
            {
                switch (mapNode.StructureName)
                {
                    case "StructureDefinition":
                        this.selectedNodes.Add(mapNode);
                        break;
                }
            }
        }

        void CreateNodes()
        {
            foreach (ResourceMap.Node mapNode in this.selectedNodes)
            {
                FragmentNode fNode = new FragmentNode
                {
                    Focus = mapNode
                };
                this.fragmentNodes.Add(mapNode.Name, fNode);
            }
        }

        CodeEditor fragmentsEditor;
        CodeBlockNested fragmentsBlock;

        public void Create()
        {
            this.fragmentsEditor = new CodeEditor();
            this.fragmentsEditor.BlockStart = "<!-- +";
            this.fragmentsEditor.BlockStartTerm = "-->";
            this.fragmentsEditor.BlockEnd = "<!-- -";
            this.fragmentsEditor.BlockEndTerm = "-->";
            this.fragmentsEditor.Load(Path.Combine(this.pageTemplateDir, "fragments.xml"));
            this.fragmentsBlock = this.fragmentsEditor.Blocks.Find("Block");
            this.fragmentsBlock.Clear();

            this.SelectNodes();
            this.CreateNodes();
            this.LinkNodes();
            this.GraphNodes();

            this.fragmentsEditor.Save();
        }
    }
}
