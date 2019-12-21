using FhirKhit.Tools;
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
                String baseName)
            {
                this.ResourceUrl = resourceUrl;
                this.MapName = mapName;
                this.StructureName = structureName;
                this.BaseName = baseName;
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

            public void AddFragmentLink(String url, bool showChildren = true)
            {
                this.AddLink("fragment", url, showChildren);
            }

            public void AddTargetLink(String url, bool showChildren = true)
            {
                this.AddLink("target", url, showChildren);
            }

            public void AddExtensionLink(String url, bool showChildren = true)
            {
                this.AddLink("extension", url, showChildren);
            }

            public void AddValueSetLink(String url, bool showChildren = true)
            {
                this.AddLink("valueSet", url, showChildren);
            }

            public void AddProfileTargets(params ProfileTargetSlice[] targets)
            {
                foreach (ProfileTargetSlice target in targets)
                    this.AddLink("target", target.Profile, target.ShowChildren);
            }

            public void AddLink(String linkType,
                String url,
                bool showChildren)
            {
                if (url.StartsWith("http://hl7.org/fhir/StructureDefinition/") == true)
                    return;
                this.AddLink(new Link(linkType, url, showChildren));
            }

            public void AddLink(Link link)
            {
                if (this.links.TryGetValue(link.ResourceUrl, out Link temp) == true)
                    return;
                this.links.Add(link.ResourceUrl, link);
            }
        }
    }
}