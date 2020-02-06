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
        VSTaskVar MarginVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "MarginVS",
                    "Margin ValueSet",
                    "MarginValueSet",
                    "Margin ValueSet.",
                    Group_CommonCodesVS,
                    Self.MarginCS.Value()
                    )
            );


        CSTaskVar MarginCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "MarginCS",
                     "MarginCodeSystem",
                     "Margin CodeSystem",
                     "Margin code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                     //+ MarginCS
                     //+ AngularMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("AngularMargin")
                         .SetDisplay("Angular margin")
                         .SetDefinition("[PR] Angular margin")
                         .MammoId("191")
                         .ValidModalities(Modalities.US)
                         .SetComment("NOT FOUND")
                     //- AutoGen
                         .BiRadsDef(
                             "Some or all of the margin has sharp corners, often forming acute angles, but the significant",
                             "feature is that the margin of the mass is NOT CIRCUMSCRIBED.")
                         ,
                     //- AngularMargin
                     //+ CircumscribedMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("CircumscribedMargin")
                         .SetDisplay("Circumscribed margin")
                         .SetDefinition("[PR] Circumscribed margin")
                         .MammoId("109")
                         .ValidModalities(Modalities.MG | Modalities.NM | Modalities.US)
                         .SetSnomedCode("129738007")
                         .SetSnomedDescription("ClinicalFinding | Lesion with circumscribed margin " +
                             "(Finding)")
                     //- AutoGen
                         .BiRadsDef(
                            "(historically, \"well-defined\" or \"sharply-defined\")",
                            "A circumscribed margin is one that is well defined, with an abrupt transition between the",
                            "lesion and the surrounding tissue. For US, to describe a mass as circumscribed, its entire margin",
                            "must be sharply defined. Most circumscribed lesions have round or oval shapes.")
                         ,
                     //- CircumscribedMargin
                     //+ IndistinctMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("IndistinctMargin")
                         .SetDisplay("Indistinct margin")
                         .SetDefinition("[PR] Indistinct margin")
                         .MammoId("21")
                         .ValidModalities(Modalities.MG | Modalities.US)
                         .SetSnomedCode("129741003")
                         .SetSnomedDescription("ClinicalFinding | Lesion with indistinct margin (Finding)")
                     //- AutoGen
                            .BiRadsDef(
                            "There is no clear demarcation of the entire margin or any portion of the margin from the",
                            "surrounding tissue. The boundary is poorly defined, and the significant feature is that the",
                            "mass is NOT CIRCUMSCRIBED. This is meant to include �echogenic rim� (historically, echogenic",
                            "halo) because one may not be able to distinguish between an indistinct margin and",
                            "one that displays an echogenic rim.")
                         ,
                     //- IndistinctMargin
                     //+ IntraductalExtension
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("IntraductalExtension")
                         .SetDisplay("Intraductal extension")
                         .SetDefinition("[PR] Intraductal extension")
                         .MammoId("201")
                         .ValidModalities(Modalities.US)
                     //- AutoGen
                     ,
                     //- IntraductalExtension
                     //+ IrregularMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("IrregularMargin")
                         .SetDisplay("Irregular margin")
                         .SetDefinition("[PR] Irregular margin")
                         .MammoId("20")
                         .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                         .SetComment("NOT FOUND")
                     //- AutoGen
                     ,
                     //- IrregularMargin
                     //+ LobulatedMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("LobulatedMargin")
                         .SetDisplay("Lobulated margin")
                         .SetDefinition("[PR] Lobulated margin")
                         .MammoId("19")
                         .ValidModalities(Modalities.US)
                         .SetComment("NOT FOUND")
                     //- AutoGen
                     ,
                     //- MacrolobulatedMargin
                     //+ MicrolobulatedMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("MicrolobulatedMargin")
                         .SetDisplay("Microlobulated margin")
                         .SetDefinition("[PR] Microlobulated margin")
                         .MammoId("111")
                         .ValidModalities(Modalities.MG | Modalities.US)
                         .SetSnomedCode("129739004")
                         .SetSnomedDescription("ClinicalFinding | Lesion with microlobulated margin " +
                             "(Finding)")
                     //- AutoGen
                         .BiRadsDef(
                            "The margin is characterized by short-cycle undulations, but the significant feature is that",
                            "the margin of the mass is NOT CIRCUMSCRIBED.")
                     ,
                     //- MicrolobulatedMargin
                     //+ NonCircumscribedMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("NonCircumscribedMargin")
                         .SetDisplay("Non circumscribed margin")
                         .SetDefinition("[PR] Non circumscribed margin")
                         .MammoId("383")
                         .ValidModalities(Modalities.MRI | Modalities.US)
                         .SetSnomedDescription("ClinicalFinding | 129738007 | Lesion with circumscribed " +
                             "margin (Finding)")
                         .SetComment("NEED NOT")
                     //- AutoGen
                     ,
                     //- NonCircumscribedMargin
                     //+ ObscuredMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("ObscuredMargin")
                         .SetDisplay("Obscured margin")
                         .SetDefinition("[PR] Obscured margin")
                         .MammoId("28")
                         .ValidModalities(Modalities.MG)
                         .SetSnomedCode("129740002")
                         .SetSnomedDescription("ClinicalFinding | Lesion with obscured margin (Finding)")
                     //- AutoGen
                         .BiRadsDef(
                             "A margin that is hidden by superimposed or adjacent fibroglandular tissue. This is used",
                             "primarily when some of the margin of the mass is circumscribed, but the rest (more than 25%) is hidden.")
                         ,
                     //- ObscuredMargin
                     //+ SmoothMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("SmoothMargin")
                         .SetDisplay("Smooth margin")
                         .SetDefinition("[PR] Smooth margin")
                         .MammoId("18")
                         .ValidModalities(Modalities.MRI | Modalities.US)
                         .SetComment("NOT FOUND")
                     //- AutoGen
                     ,
                     //- SmoothMargin
                     //+ SpiculatedMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("SpiculatedMargin")
                         .SetDisplay("Spiculated margin")
                         .SetDefinition("[PR] Spiculated margin")
                         .MammoId("29")
                         .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                         .SetSnomedCode("129742005")
                         .SetSnomedDescription("ClinicalFinding | Lesion with spiculated margin (Finding)")
                     //- AutoGen
                         .BiRadsDef(
                            "The margin is characterized by sharp lines radiating from the mass, often a sign of malignancy,",
                            "but the significant feature is that the margin of the mass is NOT CIRCUMSCRIBED.")
                     //- SpiculatedMargin
                     //- MarginCS
                     })
                 );
    }
}
