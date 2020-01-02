using FhirKhit.Tools;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourceMap
    {
        public IEnumerable<ResourceMap.Node> Nodes => this.nodes.Values;
        Dictionary<String, ResourceMap.Node> nodes = new Dictionary<string, ResourceMap.Node>();

        public IEnumerable<ResourceMap.Link> Links => this.links;
        List<ResourceMap.Link> links = new List<ResourceMap.Link>();

        public ResourceMap()
        {
        }

        public void AddDir(String path, String searchPattern)
        {
            foreach (String filePath in Directory.GetFiles(path, searchPattern))
                this.AddResource(filePath);

            foreach (String subDir in Directory.GetDirectories(path))
                this.AddDir(subDir, searchPattern);
        }

        public void AddResource(String path)
        {
            DomainResource r;
            switch (Path.GetExtension(path).ToUpper(CultureInfo.InvariantCulture))
            {
                case ".XML":
                    {
                        FhirXmlParser parser = new FhirXmlParser();
                        r = parser.Parse<DomainResource>(File.ReadAllText(path));
                        break;
                    }

                case ".JSON":
                    {
                        FhirJsonParser parser = new FhirJsonParser();
                        r = parser.Parse<DomainResource>(File.ReadAllText(path));
                        break;
                    }

                default:
                    throw new Exception($"Unknown extension for serialized fhir resource '{path}'");
            }
            ResourceMap.Node node = this.CreateMapNode(r);
            if (node == null)
                return;
            this.nodes.Add(node.ResourceUrl, node);
        }

        public bool TryGetNode(String url, out ResourceMap.Node node)
        {
            return this.nodes.TryGetValue(url, out node);
        }

        public ResourceMap.Node GetNode(String url)
        {
            if (this.nodes.TryGetValue(url, out ResourceMap.Node node) == false)
                throw new Exception($"Map node {url} not found");
            return node;
        }

        public IEnumerable<ResourceMap.Link> TargetLinks(String target)
        {
            foreach (ResourceMap.Link link in this.Links)
            {
                if (link.LinkTarget == target)
                    yield return link;
            }
        }

        public IEnumerable<ResourceMap.Link> SourceLinks(String source)
        {
            foreach (ResourceMap.Link link in this.Links)
            {
                if (link.LinkSource == source)
                    yield return link;
            }
        }

        public Link CreateLink(String linkType,
            String linkSource,
            String linkTarget,
            bool showChildren)
        {
            Link retVal = new Link
            {
                LinkType = linkType,
                LinkTarget = linkTarget,
                LinkSource = linkSource,
                ShowChildren = showChildren
            };

            this.links.Add(retVal);

            return retVal;
        }

        ResourceMap.Node CreateMapNode(DomainResource r)
        {
            String structureName = r.TypeName;
            String resourceUrl;
            String baseName = null;
            switch (r)
            {
                case ValueSet vs:
                    resourceUrl = vs.Url;
                    break;

                case StructureDefinition sd:
                    resourceUrl = sd.Url;
                    baseName = sd.BaseDefinition.LastUriPart();
                    break;

                default:
                    return null;
            }

            string mapName = r.GetStringExtension(Global.ResourceMapNameUrl);
            if (String.IsNullOrEmpty(mapName) == true)
                throw new Exception($"Mapname missing from {resourceUrl}");
            String[] mapNameArray = mapName.Split('/');

            Extension isFragmentExtension = r.GetExtension(Global.IsFragmentExtensionUrl);

            ResourceMap.Node retVal = this.CreateMapNode(resourceUrl,
                mapNameArray,
                structureName,
                baseName,
                isFragmentExtension != null);

            foreach (Extension link in r.GetExtensions(Global.ResourceMapLinkUrl))
            {
                FhirString s = (FhirString)link.Value;
                String[] parts = s.Value.Split('|');
                ResourceMap.Link mapLink = this.CreateLink(parts[0], resourceUrl, parts[2], Boolean.Parse(parts[1]));
                retVal.AddLink(mapLink);
            }
            return retVal;
        }


        public ResourceMap.Node CreateMapNode(String url, String[] mapName, String structureName, String baseName, bool fragment)
        {
            if (this.nodes.TryGetValue(url, out ResourceMap.Node retVal) == true)
                throw new Exception($"Map node {url} already exists");
            retVal = new Node(url, mapName, structureName, baseName, fragment);
            return retVal;
        }
    }
}
