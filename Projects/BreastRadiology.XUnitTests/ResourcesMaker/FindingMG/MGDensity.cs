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
        //# TODO: get from gg
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
                         //+ CentralLucent
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CentralLucent")
                             .SetDisplay("Central lucent")
                             .SetDefinition("[PR] Central lucent")
                             .MammoId("215")
                             .ValidModalities(Modalities.MG)
                         //- AutoGen
                         ,
                         //- CentralLucent
                         //+ EqualDensity
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("EqualDensity")
                             .SetDisplay("Equal density")
                             .SetDefinition("[PR] Equal density")
                             .MammoId("213")
                             .ValidModalities(Modalities.MG)
                         //- AutoGen
                             .BiRadsDef("(historically, \"isodense\")",
                                 "X-ray attenuation of the mass is the same as the expected attenuation of an equal volume of",
                                 "fibroglandular breast tissue.")
                         ,
                         //- EqualDensity
                         //+ FatContaining
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("FatContaining")
                             .SetDisplay("Fat containing")
                             .SetDefinition("[PR] Fat containing")
                             .MammoId("214")
                             .ValidModalities(Modalities.MG)
                         //- AutoGen
                             .BiRadsDef("This includes all masses containing fat, such as oil cyst, lipoma or galactocele, as well as mixed",
                                 "density masses such as hamartoma. A fat-containing mass will almost always represent a",
                                 "benign mass.")
                         ,
                         //- FatContaining
                         //+ HighDensity
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("HighDensity")
                             .SetDisplay("High density")
                             .SetDefinition("[PR] High density")
                             .MammoId("211")
                             .ValidModalities(Modalities.MG)
                         //- AutoGen
                             .BiRadsDef("X-ray attenuation of the mass is greater than the expected attenuation of an equal volume of",
                                 "fibroglandular breast tissue.")
                         ,
                         //- HighDensity
                         //+ LowDensity
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("LowDensity")
                             .SetDisplay("Low density")
                             .SetDefinition("[PR] Low density")
                             .MammoId("212")
                             .ValidModalities(Modalities.MG)
                         //- AutoGen
                             .BiRadsDef("X-ray attenuation of the mass is less than the expected attenuation of an equal volume of",
                                 "fibroglandular breast tissue. A low density mass may be a group of microcysts. If such a finding",
                                 "is identified at mammography, it may very well not be malignant but appropriately may",
                                 "be worked up."),
                         //- LowDensity
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
