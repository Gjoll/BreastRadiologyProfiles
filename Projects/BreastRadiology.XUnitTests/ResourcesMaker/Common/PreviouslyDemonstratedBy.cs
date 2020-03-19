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
    partial class ResourcesMaker
    {
        VSTaskVar PreviouslyDemonstratedByVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "PreviouslyDemonstratedByVS",
                    "PreviouslyDemonstratedBy ValueSet",
                    "PreviouslyDemonstratedBy/ValueSet",
                    "PreviouslyDemonstratedBy value set.",
                    Group_CommonCodesVS,
                    Self.PreviouslyDemonstratedByCS.Value()
                )
        );

        CSTaskVar PreviouslyDemonstratedByCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                    "PreviouslyDemonstratedByCodeSystemCS",
                    "Not Previously Seen CodeSystem",
                    "PreviouslyDemonstratedBy/CodeSystem",
                    "PreviouslyDemonstratedBy code system",
                    Group_CommonCodesCS,
                    new ConceptDef[]
                    {
                        //+ Codes

                        #region Codes

                        new ConceptDef()
                            .SetCode("Aspiration")
                            .SetDisplay("Aspiration")
                            .MammoId("805")
                            .ValidModalities(Modalities.MG)
                            .SetSnomedDescription("Procedure | 287572003 | Diagnostic aspiration of " +
                                                  "breast cyst (Procedure) | [0/0] |")
                            .SetUMLS("A medical procedure that removes something from an " +
                                     "area of the body. ",
                                "These substances can be air, body fluids, or bone " +
                                "fragments.",
                                "###URL#https://medlineplus.gov/ency/article/002216.htm"),
                        new ConceptDef()
                            .SetCode("Biopsy")
                            .SetDisplay("Biopsy")
                            .MammoId("807")
                            .ValidModalities(Modalities.MG)
                            .SetSnomedDescription("Procedure | 122548005 | Biopsy of breast (Procedure)")
                            .SetUMLS("An examination under a microscope  of the specific " +
                                     "tissue removed from the body. ",
                                "The examination is used to check for abnormalities " +
                                "or cancer cells."),
                        new ConceptDef()
                            .SetCode("MRI")
                            .SetDisplay("MRI")
                            .MammoId("808")
                            .ValidModalities(Modalities.MG)
                            .SetSnomedDescription("Procedure | 241615005 | Magnetic resonance imaging " +
                                                  "of breast (Procedure)")
                            .SetUMLS("Findings on the Mammogram was previously demonstrated " +
                                     "by the MRI."),
                        new ConceptDef()
                            .SetCode("US")
                            .SetDisplay("US")
                            .MammoId("806")
                            .ValidModalities(Modalities.MG)
                            .SetUMLS("Findings on the Mammogram was previously demonstrated " +
                                     "by the Ultrasound.")

                        #endregion // Codes

                        //- Codes
                    })
        );
    }
}