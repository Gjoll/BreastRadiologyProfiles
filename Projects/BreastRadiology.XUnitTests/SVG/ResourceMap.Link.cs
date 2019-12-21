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
            /// Url of ResourceMap.Node that this links to.
            /// </summary>
            public String ResourceUrl;

            public bool ShowChildren;

            public Link(String linkType,
                String resourceUrl,
                bool showChildren)
            {
                if (String.IsNullOrEmpty(resourceUrl))
                    throw new Exception("Url can not be empty");

                this.LinkType = linkType;
                this.ResourceUrl = resourceUrl;
                this.ShowChildren = showChildren;
            }
        }
    }
}
