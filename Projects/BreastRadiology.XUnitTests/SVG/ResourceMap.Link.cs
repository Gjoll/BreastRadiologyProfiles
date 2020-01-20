using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourceMap
    {
        [DebuggerDisplay("{LinkType}:{ResourceUrl}")]
        public class Link
        {
            public Link(string linkType,
                    String linkSource,
                    String linkTarget,
                    String cardinality,
                    bool showChildren)
            {
                this.LinkType = linkType;
                this.LinkSource = linkSource;
                this.LinkTarget = linkTarget;
                this.Cardinality = cardinality;
                this.ShowChildren = showChildren;
            }

            /// <summary>
            /// What type of link this.
            /// </summary>
            public string LinkType;

            /// <summary>
            /// Link Source.
            /// This may be a resource url, or it may just be a string name.
            /// (LinkType dependent)
            /// </summary>
            public String LinkSource;

            /// <summary>
            /// Target that this links to.
            /// This may e a resource url, or it may just be a string name.
            /// (LinkType dependent)
            /// </summary>
            public String LinkTarget;

            public String Cardinality;

            public bool ShowChildren;
        }
    }
}
