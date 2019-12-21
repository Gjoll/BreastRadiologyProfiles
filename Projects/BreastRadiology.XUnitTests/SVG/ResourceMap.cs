using FhirKhit.Tools;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourceMap
    {
        public const String ResourceMapNameUrl = "http://www.fragment.com/mapname";
        public const String ResourceMapLinkUrl = "http://www.fragment.com/maplink";

        Dictionary<String, ResourceMap.Node> resources = new Dictionary<string, ResourceMap.Node>();

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
            switch (Path.GetExtension(path).ToUpper())
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
            this.resources.Add(node.ResourceUrl, node);
        }

        public IEnumerable<ResourceMap.Node> MapNodes => this.resources.Values;

        public bool TryGetNode(String url, out ResourceMap.Node node)
        {
            return this.resources.TryGetValue(url, out node);
        }

        public ResourceMap.Node GetNode(String url)
        {
            if (this.resources.TryGetValue(url, out ResourceMap.Node node) == false)
                throw new Exception($"Map node {url} not found");
            return node;
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

            string mapName = r.GetStringExtension(ResourceMapNameUrl);
            if (String.IsNullOrEmpty(mapName) == true)
                throw new Exception($"Mapname missing from {resourceUrl}");
            String[] mapNameArray = mapName.Split('/');
            ResourceMap.Node retVal =  this.CreateMapNode(resourceUrl, mapNameArray, structureName, baseName);
            foreach (Extension link in r.GetExtensions(ResourceMapLinkUrl))
            {
                FhirString s = (FhirString) link.Value;
                String[] parts = s.Value.Split('|');
                ResourceMap.Link mapLink = new ResourceMap.Link(parts[0], parts[2], Boolean.Parse(parts[1]));
                retVal.AddLink(mapLink);
            }
            return retVal;
        }


        public ResourceMap.Node CreateMapNode(String url, String[] mapName, String structureName, String baseName)
        {
            if (this.resources.TryGetValue(url, out ResourceMap.Node retVal) == true)
                throw new Exception($"Map node {url} already exists");
            retVal = new Node(url, mapName, structureName, baseName);
            return retVal;
        }
    }
}
