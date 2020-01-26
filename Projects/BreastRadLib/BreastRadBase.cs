using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadLib
{
    public class BreastRadBase
    {
        /// <summary>
        /// Unload HasMember observation
        /// </summary>
        void UnloadHasMember(ResourceBag resourceBag,
            Observation parent,
            Observation child)
        {
            //resourceBag.AddEntry(child, child.Url);
        }
    }
}
