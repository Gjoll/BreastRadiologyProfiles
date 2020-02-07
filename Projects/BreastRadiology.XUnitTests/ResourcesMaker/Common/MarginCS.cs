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
                     //+ Codes
                     new ConceptDef()
                         .SetCode("AngularMargin")
                         .SetDisplay("Angular margin")
                         .SetDefinition("[PR] Angular margin")
                         .MammoId("191")
                         .ValidModalities(Modalities.US)
                         .SetUMLS("Some or all of the margin has sharp corners, often " +
                             "forming acute angles. The margin of the mass is not " +
                             "circumscribed.")
                         .SetACR("Some or all of the margin has sharp corners, often " +
                             "forming acute angles, but the significantfeature " +
                             "is that the margin of the mass is NOT CIRCUMSCRIBED.")
                     ,
                     new ConceptDef()
                         .SetCode("CircumscribedMargin")
                         .SetDisplay("Circumscribed margin")
                         .SetDefinition("[PR] Circumscribed margin")
                         .MammoId("109")
                         .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                         .SetSnomedCode("129738007")
                         .SetSnomedDescription("ClinicalFinding | Lesion with circumscribed margin " +
                             "(Finding)")
                         .SetUMLS("A circumscribed margin is one that is well defined, " +
                             "with an abrupt transition between the lesion and " +
                             "the surrounding tissue. For US, to describe a mass " +
                             "as circumscribed, its entire margin must be sharply " +
                             "defined. Most circumscribed lesions have round or " +
                             "oval shapes.")
                         .SetACR("(historically, \"well-defined\" or \"sharply-defined\")A " +
                             "circumscribed margin is one that is well defined, " +
                             "with an abrupt transition between thelesion and the " +
                             "surrounding tissue. For US, to describe a mass as " +
                             "circumscribed, its entire marginmust be sharply defined. " +
                             "Most circumscribed lesions have round or oval shapes.")
                     ,
                     new ConceptDef()
                         .SetCode("IndistinctMargin")
                         .SetDisplay("Indistinct margin")
                         .SetDefinition("[PR] Indistinct margin")
                         .MammoId("21")
                         .ValidModalities(Modalities.MG | Modalities.US)
                         .SetSnomedCode("129741003")
                         .SetSnomedDescription("ClinicalFinding | Lesion with indistinct margin (Finding)")
                         .SetUMLS("Indistinct margin There is no clear demarcation of " +
                             "the entire margin or any portion of the margin from " +
                             "the surrounding tissue. The boundary is poorly defined, " +
                             "and the significant feature is that the mass is not " +
                             "circumscribed.")
                         .SetACR("There is no clear demarcation of the entire margin " +
                             "or any portion of the margin from thesurrounding " +
                             "tissue. The boundary is poorly defined, and the significant " +
                             "feature is that themass is NOT CIRCUMSCRIBED. This " +
                             "is meant to include �echogenic rim� (historically, " +
                             "echogenichalo) because one may not be able to distinguish " +
                             "between an indistinct margin andone that displays " +
                             "an echogenic rim.")
                     ,
                     new ConceptDef()
                         .SetCode("IntraductalExtension")
                         .SetDisplay("Intraductal extension")
                         .SetDefinition("[PR] Intraductal extension")
                         .MammoId("201")
                         .ValidModalities(Modalities.US)
                         .SetUMLS("Intraductal tumor extension is a characteristic feature " +
                             "of primary breast carcinoma, and is an important " +
                             "consideration in patients undergoing breast conservative " +
                             "surgery.")
                     ,
                     new ConceptDef()
                         .SetCode("IrregularMargin")
                         .SetDisplay("Irregular margin")
                         .SetDefinition("[PR] Irregular margin")
                         .MammoId("20")
                         .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                         .SetUMLS("Edges around the soft tissue that don't look smooth. " +
                             "Indicative of some sort of growth or mass rather " +
                             "than a cyst.")
                     ,
                     new ConceptDef()
                         .SetCode("LobulatedMargin")
                         .SetDisplay("Lobulated margin")
                         .SetDefinition("[PR] Lobulated margin")
                         .MammoId("19")
                         .ValidModalities(Modalities.US)
                         .SetUMLS("The edge of the mass has broad bulges. Much like " +
                             "a 6 or 8 leaf clover. The edge of all of the leaves " +
                             "would be lobulated.")
                     ,
                     new ConceptDef()
                         .SetCode("MacrolobulatedMargin")
                         .SetDisplay("Macrolobulated margin")
                         .SetDefinition("[PR] Macrolobulated margin")
                         .MammoId("218")
                         .ValidModalities(Modalities.MG)
                         .SetUMLS("Smooth margin with distinct separation between the " +
                             "mass and the surrounding border. They are  oval-shaped " +
                             "and  have a wide rather than tall formation.")
                     ,
                     new ConceptDef()
                         .SetCode("MicrolobulatedMargin")
                         .SetDisplay("Microlobulated margin")
                         .SetDefinition("[PR] Microlobulated margin")
                         .MammoId("111")
                         .ValidModalities(Modalities.MG | Modalities.US)
                         .SetSnomedCode("129739004")
                         .SetSnomedDescription("ClinicalFinding | Lesion with microlobulated margin " +
                             "(Finding)")
                         .SetUMLS("The margin is characterized by short-cycle undulations " +
                             "or scalloped appearance,and the margin of the mass " +
                             "is not circumscribed.")
                         .SetACR("The margin is characterized by short-cycle undulations, " +
                             "but the significant feature is thatthe margin of " +
                             "the mass is NOT CIRCUMSCRIBED.")
                     ,
                     new ConceptDef()
                         .SetCode("NonCircumscribedMargin")
                         .SetDisplay("Non circumscribed margin")
                         .SetDefinition("[PR] Non circumscribed margin")
                         .MammoId("383")
                         .ValidModalities(Modalities.MRI | Modalities.US)
                         .SetSnomedDescription("ClinicalFinding | 129738007 | Lesion with circumscribed " +
                             "margin (Finding)")
                         .SetUMLS("Microbulated or Irregular masses, a margin that is " +
                             "not well defined. There is not a clear demarcation " +
                             "between the mass and the surrounding tissue.")
                     ,
                     new ConceptDef()
                         .SetCode("ObscuredMagin")
                         .SetDisplay("Obscured magin")
                         .SetDefinition("[PR] Obscured magin")
                         .MammoId("28")
                         .ValidModalities(Modalities.MG)
                         .SetSnomedCode("129740002")
                         .SetSnomedDescription("ClinicalFinding | Lesion with obscured margin (Finding)")
                         .SetUMLS("It is hidden by superimposed or adjacent fibroglandular " +
                             "tissue. This is used primarily when some of the margin " +
                             "of the mass is circumscribed, but the rest (more " +
                             "than 25%) is hidden.")
                         .SetACR("A margin that is hidden by superimposed or adjacent " +
                             "fibroglandular tissue. This is usedprimarily when " +
                             "some of the margin of the mass is circumscribed, " +
                             "but the rest (more than 25%) is hidden.")
                     ,
                     new ConceptDef()
                         .SetCode("SmoothMargin")
                         .SetDisplay("Smooth margin")
                         .SetDefinition("[PR] Smooth margin")
                         .MammoId("18")
                         .ValidModalities(Modalities.MRI | Modalities.US)
                         .SetUMLS("The edges of the mass have a smooth appearance and " +
                             "distinct separation between the mass and surrounding " +
                             "tissue.")
                     ,
                     new ConceptDef()
                         .SetCode("SpiculatedMargin")
                         .SetDisplay("Spiculated margin")
                         .SetDefinition("[PR] Spiculated margin")
                         .MammoId("29")
                         .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                         .SetSnomedCode("129742005")
                         .SetSnomedDescription("ClinicalFinding | Lesion with spiculated margin (Finding)")
                         .SetUMLS("The edges of the mass have sharp \"spikes\" coming out " +
                             "from it, and the lines radiate from the mass. The " +
                             "margin of the mass is not circumscribed.")
                         .SetACR("The margin is characterized by sharp lines radiating " +
                             "from the mass, often a sign of malignancy,but the " +
                             "significant feature is that the margin of the mass " +
                             "is NOT CIRCUMSCRIBED.")
                     //- Codes
                     })
                 );
    }
}
