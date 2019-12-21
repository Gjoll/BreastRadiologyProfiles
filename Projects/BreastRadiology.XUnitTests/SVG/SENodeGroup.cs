using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    [DebuggerDisplay("{this.Title} [{this.Nodes.Count}/{this.Children.Count}]")]
    public class SENodeGroup
    {
        /// <summary>
        /// For debugging only.
        /// </summary>
        public String Title {get; set; }

        public List<SENode> Nodes = new List<SENode>();

        public List<SENodeGroup> Children = new List<SENodeGroup>();

        public SENodeGroup(String title)
        {
            this.Title = title;
        }

        public SENodeGroup AppendChild(String title)
        {
            SENodeGroup retVal = new SENodeGroup(title);
            this.Children.Add(retVal);
            return retVal;
        }
    }
}
