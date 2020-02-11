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
        public void AddEntry(String fullUrl, DomainResource resource)
        {
            bundle.AddResourceEntry(resource, fullUrl);
        }
    }
}
