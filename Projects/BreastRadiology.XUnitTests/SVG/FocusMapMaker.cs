using FhirKhit.Tools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
        class FocusNode
        {
            public ResourceMap.Node Focus;
            public List<ResourceMap.Node> Parents = new List<ResourceMap.Node>();
            public List<ResourceMap.Node> Children = new List<ResourceMap.Node>();
        }

        ResourceMap map;
        ConcurrentDictionary<String, FocusNode> focusNodes = new ConcurrentDictionary<string, FocusNode>();
        String graphicsDir;
        String contentDir;

        public FocusMapMaker(ResourceMap map,
            String graphicsDir,
            String contentDir)
        {
            this.map = map;
            this.graphicsDir = graphicsDir;
            this.contentDir = contentDir;
        }

        public static String FocusMapName(ResourceMap.Node mapNode) => $"Focus-{mapNode.Name}.svg";
        public static String FocusMapName(String name) => $"Focus-{name}.svg";
        String IntroName(ResourceMap.Node mapNode) => $"{mapNode.StructureName}-{mapNode.Name}-intro.xml";

        void LinkNodes()
        {
            foreach (ResourceMap.Node focusMapNode in this.map.MapNodes)
            {
                if (this.focusNodes.TryGetValue(focusMapNode.Name, out FocusNode fragmentFocusNode) == false)
                    throw new Exception($"Internal error. Cant find Focus FocusNode '{focusMapNode.Name}' ");

                foreach (ResourceMap.Link link in focusMapNode.LinksByName("valueSet", "target", "extension"))
                {
                    ResourceMap.Node referencedMapNode = this.map.GetNode(link.ResourceUrl);
                    fragmentFocusNode.Parents.Add(referencedMapNode);

                    if (this.focusNodes.TryGetValue(referencedMapNode.Name, out FocusNode fragmentParentNode) == false)
                        throw new Exception($"Internal error. Cant find FocusNode '{referencedMapNode.Name}' ");
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
                    hRef = $"./{mapNode.StructureName}-{mapNode.Name}.html";
                    title = $"'{mapNode.Name}'";
                }
                String s = titlePart.Trim();
                node.AddTextLine(s, hRef, title);
            }

            return node;
        }

        void GraphNode(FocusNode fragmentNode)
        {
            SvgEditor e = new SvgEditor();
            SENodeGroup parentsGroup = new SENodeGroup("parents");
            SENodeGroup focusGroup = new SENodeGroup("focus");
            SENodeGroup childrenGroup = new SENodeGroup("children");
            parentsGroup.Children.Add(focusGroup);
            focusGroup.Children.Add(childrenGroup);

            {
                SENode node = this.CreateNode(fragmentNode.Focus, Color.LightGreen, false);
                focusGroup.Nodes.Add(node);
            }

            foreach (ResourceMap.Node childNode in fragmentNode.Children)
            {
                SENode node = this.CreateNode(childNode, Color.LightBlue, true);
                parentsGroup.Nodes.Add(node);
            }

            foreach (ResourceMap.Node parentNode in fragmentNode.Parents)
            {
                SENode node = this.CreateNode(parentNode, Color.LightSalmon, true);
                childrenGroup.Nodes.Add(node);
            }

            e.Render(parentsGroup, true);
            e.Save(Path.Combine(this.graphicsDir, FocusMapName(fragmentNode.Focus)));
        }


        void GraphNodes()
        {
            List<Task> tasks = new List<Task>();

            foreach (FocusNode fragmentNode in this.focusNodes.Values)
            {
                if (fragmentNode.Focus.Name.Contains("Fragment") == false)
                {
                    Task t = Task.Run(() => this.GraphNode(fragmentNode));
                    tasks.Add(t);
                }
            }
            Task.WaitAll(tasks.ToArray());
        }

        void CreateNodes()
        {
            foreach (ResourceMap.Node mapNode in this.map.MapNodes)
            {
                FocusNode fNode = new FocusNode
                {
                    Focus = mapNode
                };
                if (this.focusNodes.TryAdd(mapNode.Name, fNode) == false)
                    throw new Exception("Error inserting node into focus node dictionary");
            }
        }

        public void Create()
        {
            this.CreateNodes();
            this.LinkNodes();
            this.GraphNodes();
        }
    }
}
