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

        public FragmentMapMaker(FileCleaner fc,
            ResourceMap map,
            String graphicsDir,
            String pageDir)
        {
            this.fc = fc;
            this.map = map;
            this.graphicsDir = graphicsDir;
            this.pageDir = pageDir;
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
            SENode node = new SENode(0, color);
            foreach (String titlePart in mapNode.MapName)
            {
                String hRef = null;
                String title = null;
                if (linkFlag)
                {
                    String fragMapName = this.FragmentMapName(mapNode);
                    hRef = $"./{fragMapName}";
                    title = $"'{fragMapName}'";
                }
                String s = titlePart.Trim();
                node.AddTextLine(s, hRef, title);
            }

            {
                String hRef = $"../Guide/Output/{mapNode.StructureName}-{mapNode.Name}.html";
                String title = $"'{mapNode.Name}'";
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
            String outputPath = Path.Combine(this.graphicsDir, this.FragmentMapName(fragmentNode.Focus));
            this.fc?.Mark(outputPath);
            e.Save(outputPath);

            {
                IntroDoc doc = new IntroDoc(Path.Combine(pageDir, $"StructureDefinition-Fragment{fragmentNode.Focus.Name}-intro.xml"));
                doc
                    .AddSvgImage("FragmentMap_{structureDefinition.Name}.svg")
                    ;
                outputPath = doc.Save();
                this.fc?.Mark(outputPath);
            }

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

        public void Create()
        {
            this.SelectNodes();
            this.CreateNodes();
            this.LinkNodes();
            this.GraphNodes();
        }
    }
}
