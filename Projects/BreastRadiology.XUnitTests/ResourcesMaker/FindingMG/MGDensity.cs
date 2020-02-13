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
                         #region Codes
                         new ConceptDef()
                             .SetCode("CentralLucent")
                             .SetDisplay("Central lucent")
                             .MammoId("215")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("These are round or oval calcifications that range " +
                                 "from under 1 mm to over a centimeter.",
                                 "They are the result of fat necrosis, calcified debris " +
                                 "in ducts, and occasional fibroadenomas. ",
                                 "###URL#https://radiologyassistant.nl/breast/breast-calcifications-differential-diagnosis#benign-calcifications-lucent-centered")
                         ,
                         new ConceptDef()
                             .SetCode("EqualDensity")
                             .SetDisplay("Equal density")
                             .MammoId("213")
                             .ValidModalities(Modalities.MG)
                             .SetACR("(historically, \"isodense\")",
                                 "X-ray attenuation of the mass is the same as the " +
                                 "expected attenuation of an equal volume of",
                                 "fibroglandular breast tissue.")
                         ,
                         new ConceptDef()
                             .SetCode("FatContaining")
                             .SetDisplay("Fat containing")
                             .MammoId("214")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("The mammogram shows a lot of fatty tissue  meaning " +
                                 "the density of the breast is likely low density.")
                         ,
                         new ConceptDef()
                             .SetCode("HighDensity")
                             .SetDisplay("High density")
                             .MammoId("211")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("Your breast tissue may be called dense if you have " +
                                 "a lot of fibrous or glandular ",
                                 "tissue and not much fat in the breasts. ",
                                 "Having dense breast tissue is common. ",
                                 "Some women have more dense breast tissue than others. ",
                                 "###URL#https://www.cancer.org/cancer/breast-cancer/screening-tests-and-early-detection/mammograms/breast-density-and-your-mammogram-report.html")
                         ,
                         new ConceptDef()
                             .SetCode("LowDensity")
                             .SetDisplay("Low density")
                             .MammoId("212")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("The mammogram shows the breast is low density, containg " +
                                 "a lot of fatty tissue.")
                         #endregion // Codes
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
