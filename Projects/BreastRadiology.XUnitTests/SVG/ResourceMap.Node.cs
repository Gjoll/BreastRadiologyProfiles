﻿using FhirKhit.Tools;
using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourceMap
    {
        public class Node
        {
            public String Name => this.ResourceUrl.LastUriPart();
            public String StructureName { get; }

            public String[] MapName { get; }
            public String BaseName { get; }
            public bool IsFragment { get; }

            /// <summary>
            /// Url of the resource this represents.
            /// </summary>
            public String ResourceUrl { get; }

            /// <summary>
            /// Links from this resource to an other resource.
            /// </summary>
            public IEnumerable<Link> Links => this.links.Values;

            Dictionary<String, Link> links = new Dictionary<String, Link>();

            public Node(String resourceUrl,
                String[] mapName,
                String structureName,
                String baseName,
                bool isFragment)
            {
                this.ResourceUrl = resourceUrl;
                this.MapName = mapName;
                this.StructureName = structureName;
                this.BaseName = baseName;
                this.IsFragment = isFragment;
            }

            public IEnumerable<Link> LinksByName(params String[] linkTypes)
            {
                foreach (String linkType in linkTypes)
                {
                    foreach (Link link in this.Links)
                    {
                        if (link.LinkType == linkType)
                            yield return link;
                    }
                }
            }

            public void AddLink(Link link)
            {
                if (this.links.TryGetValue(link.LinkTarget, out Link temp) == true)
                    return;
                this.links.Add(link.LinkTarget, link);
            }
        }
    }
}