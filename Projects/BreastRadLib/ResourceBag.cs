using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public class ResourceBag
    {
        Dictionary<String, Bundle.EntryComponent> resources = new Dictionary<string, Bundle.EntryComponent>(StringComparer.OrdinalIgnoreCase);

        public bool TryGetEntry(String url, out Bundle.EntryComponent entry) => this.resources.TryGetValue(url, out entry);

        public ResourceBag(Bundle bundle)
        {
            foreach (Bundle.EntryComponent entry in bundle.Entry)
                resources.Add(entry.FullUrl, entry);
        }
    }
}
