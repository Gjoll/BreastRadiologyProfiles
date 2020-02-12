using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public class ResourceBag
    {
        Bundle bundle;
        Dictionary<String, Bundle.EntryComponent> resources = new Dictionary<string, Bundle.EntryComponent>(StringComparer.OrdinalIgnoreCase);

        public ResourceBag()
        {
            this.bundle = new Bundle();
            this.bundle.Type = Bundle.BundleType.Document;
        }

        public ResourceBag(Bundle bundle)
        {
            if (this.bundle.Type != Bundle.BundleType.Document)
                throw new Exception($"Expected bundle type 'Document', got '{this.bundle.Type}'");
            this.bundle = bundle;
            foreach (Bundle.EntryComponent entry in bundle.Entry)
                resources.Add(entry.FullUrl, entry);
        }

        public bool TryGetEntry(String url, out Bundle.EntryComponent entry) => this.resources.TryGetValue(url, out entry);

        /// <summary>
        /// Add resource to the bundle and to the resource dictionary.
        /// </summary>
        /// <param name="fullUrl"></param>
        /// <param name="resource"></param>
        public void AddResource(DomainResource resource)
        {
            if (String.IsNullOrEmpty(resource.Id) == false)
                throw new Exception($"Id is already set");

            resource.Id = $"{Guid.NewGuid().ToString()}";
            Bundle.EntryComponent entry = bundle.AddResourceEntry(resource, resource.Id);
            resources.Add(resource.Id, entry);
        }
    }
}
