using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using PreFhir;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        CSTaskVar MGDensityCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "MGDensityCS",
                     "Mammography Density CodeSystem",
                     "MG Density/CodeSystem",
                     "Mammography density code system.",
                     Group_MGCodesCS,
                     new ConceptDef[]
                     {
                         //+ Codes
                         new ConceptDef()
                             .SetCode("CentralLucent")
                             .SetDisplay("Central lucent")
                             .SetDefinition("[PR] Central lucent")
                             .MammoId("215")
                             .ValidModalities(Modalities.MG)
                         ,
                         new ConceptDef()
                             .SetCode("EqualDensity")
                             .SetDisplay("Equal density")
                             .SetDefinition("[PR] Equal density")
                             .MammoId("213")
                             .ValidModalities(Modalities.MG)
                             .SetACR("(historically, \"isodense\")X-ray attenuation of the " +
                                 "mass is the same as the expected attenuation of an " +
                                 "equal volume offibroglandular breast tissue.")
                         ,
                         new ConceptDef()
                             .SetCode("FatContaining")
                             .SetDisplay("Fat containing")
                             .SetDefinition("[PR] Fat containing")
                             .MammoId("214")
                             .ValidModalities(Modalities.MG)
                             .SetACR("This includes all masses containing fat, such as " +
                                 "oil cyst, lipoma or galactocele, as well as mixeddensity " +
                                 "masses such as hamartoma. A fat-containing mass will " +
                                 "almost always represent abenign mass.")
                         ,
                         new ConceptDef()
                             .SetCode("HighDensity")
                             .SetDisplay("High density")
                             .SetDefinition("[PR] High density")
                             .MammoId("211")
                             .ValidModalities(Modalities.MG)
                             .SetACR("X-ray attenuation of the mass is greater than the " +
                                 "expected attenuation of an equal volume offibroglandular " +
                                 "breast tissue.")
                         ,
                         new ConceptDef()
                             .SetCode("LowDensity")
                             .SetDisplay("Low density")
                             .SetDefinition("[PR] Low density")
                             .MammoId("212")
                             .ValidModalities(Modalities.MG)
                             .SetACR("X-ray attenuation of the mass is less than the expected " +
                                 "attenuation of an equal volume offibroglandular breast " +
                                 "tissue. A low density mass may be a group of microcysts. " +
                                 "If such a findingis identified at mammography, it " +
                                 "may very well not be malignant but appropriately " +
                                 "maybe worked up.")
                         //- Codes
                     })
             );


        VSTaskVar MGDensityVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "MGDensityVS",
                    "Mammography Density ValueSet",
                    "MG Density ValueSet",
                    "Mammography density codes value set.",
                    Group_MGCodesVS,
                    Self.MGDensityCS.Value())
                    );
    }
}
