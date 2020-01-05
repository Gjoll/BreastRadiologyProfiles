﻿using FhirKhit.Tools;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using PreFhir;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourceMap
    {
        Dictionary<String, DomainResource> resources = new Dictionary<string, DomainResource>();

        public IEnumerable<ResourceMap.Node> Nodes => this.nodes.Values;
        Dictionary<String, ResourceMap.Node> nodes = new Dictionary<string, ResourceMap.Node>();

        public IEnumerable<ResourceMap.Link> Links => this.links;
        List<ResourceMap.Link> links = new List<ResourceMap.Link>();

        public ResourceMap()
        {
        }

        public delegate bool VerifyDel(DomainResource r);

        public void AddDir(String path,
            String searchPattern,
            VerifyDel verifyDel = null)
        {
            foreach (String filePath in Directory.GetFiles(path, searchPattern))
                this.AddResource(filePath, verifyDel);

            foreach (String subDir in Directory.GetDirectories(path))
                this.AddDir(subDir, searchPattern, verifyDel);
        }

        public void AddResource(String path,
            VerifyDel verifyDel)
        {
            DomainResource domainResource;
            switch (Path.GetExtension(path).ToUpper(CultureInfo.InvariantCulture))
            {
                case ".XML":
                    {
                        FhirXmlParser parser = new FhirXmlParser();
                        domainResource = parser.Parse<DomainResource>(File.ReadAllText(path));
                        break;
                    }

                case ".JSON":
                    {
                        FhirJsonParser parser = new FhirJsonParser();
                        domainResource = parser.Parse<DomainResource>(File.ReadAllText(path));
                        break;
                    }

                default:
                    throw new Exception($"Unknown extension for serialized fhir resource '{path}'");
            }
            if (verifyDel != null)
            {
                if (verifyDel(domainResource) == false)
                    return;
            }
            ResourceMap.Node node = this.CreateMapNode(domainResource);
            if (node == null)
                return;
            this.nodes.Add(node.ResourceUrl, node);
            this.resources.Add(domainResource.GetUrl(), domainResource);
        }

        public bool TryGetResource(String url, out DomainResource resource)
        {
            return this.resources.TryGetValue(url, out resource);
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
            String title;

            switch (r)
            {
                case ValueSet vs:
                    resourceUrl = vs.Url;
                    title = vs.Title;
                    break;

                case StructureDefinition sd:
                    resourceUrl = sd.Url;
                    baseName = sd.BaseDefinition.LastUriPart();
                    title = sd.Title;
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
                title,
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


        public ResourceMap.Node CreateMapNode(String url,
            String title,
            String[] mapName, 
            String structureName, 
            String baseName, 
            bool fragment)
        {
            if (this.nodes.TryGetValue(url, out ResourceMap.Node retVal) == true)
                throw new Exception($"Map node {url} already exists");
            retVal = new Node(url, title, mapName, structureName, baseName, fragment);
            return retVal;
        }
    }
}
