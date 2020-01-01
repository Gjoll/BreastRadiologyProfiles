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

            public bool ShowChildren;
        }
    }
}
