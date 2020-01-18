using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    [DebuggerDisplay("{this.Title} [{this.nodes.Count}/{this.children.Count}]")]
    public class SENodeGroup
    {
        /// <summary>
        /// For debugging only.
        /// </summary>
        public String Title {get; set; }

        public IEnumerable<SENode> Nodes => nodes;
        List<SENode> nodes = new List<SENode>();

        public IEnumerable<SENodeGroup> Children => children;
        List<SENodeGroup> children = new List<SENodeGroup>();

        public SENodeGroup(String title)
        {
            if (title == null)
                throw new Exception("Title must be non empty for sorting");
            this.Title = title;
        }

        /// <summary>
        /// Sorts the nodes and groups, and calls sort on each child node.
        /// </summary>
        public void Sort()
        {
            this.nodes.Sort((a, b) => a.AllText().CompareTo(b.AllText()));
            this.children.Sort((a, b) => a.Title.CompareTo(b.Title));
            foreach (SENodeGroup child in this.children)
                child.Sort();
        }

        public void AppendNode(SENode node)
        {
            this.nodes.Add(node);
        }

        public void AppendNodes(IEnumerable<SENode> nodes)
        {
            foreach (SENode node in nodes)
                AppendNode(node);
        }

        public void AppendChild(SENodeGroup nodeGroup)
        {
            this.children.Add(nodeGroup);
        }

        public SENodeGroup AppendChild(String title)
        {
            SENodeGroup retVal = new SENodeGroup(title);
            this.children.Add(retVal);
            return retVal;
        }
    }
}
