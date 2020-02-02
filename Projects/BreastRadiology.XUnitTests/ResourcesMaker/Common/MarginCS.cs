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
                         .SetDefinition(new Definition()
                             .Line("[PR] Angular margin")
                             .MammoId("191")
                         )
                         .ValidModalities(Modalities.US)
                         .SetComment("NOT FOUND")
                     //- AutoGen
                         .SetDefinition(new Definition()
                            .Line("[PR] Angular margin")
                            .CiteStart(BiRadCitation)
                                .Text("Some or all of the margin has sharp corners, often forming acute angles, but the significant")
                                .Text("feature is that the margin of the mass is NOT CIRCUMSCRIBED.")
                            .CiteEnd()
                         )
                     ,
                     //- AngularMargin
                     //+ CircumscribedMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("CircumscribedMargin")
                         .SetDisplay("Circumscribed margin")
                         .SetDefinition(new Definition()
                             .Line("[PR] Circumscribed margin")
                             .MammoId("109")
                         )
                         .ValidModalities(Modalities.MG | Modalities.NM | Modalities.US)
                         .SetSnomedCode("129738007")
                         .SetSnomedDescription("ClinicalFinding | Lesion with circumscribed margin (Finding)")
                     //- AutoGen
                        .SetDefinition(new Definition()
                            .CiteStart(BiRadCitation)
                            .Text("(historically, \"well-defined\" or \"sharply-defined\")")
                            .Text("A circumscribed margin is one that is well defined, with an abrupt transition between the")
                            .Text("lesion and the surrounding tissue. For US, to describe a mass as circumscribed, its entire margin")
                            .Text("must be sharply defined. Most circumscribed lesions have round or oval shapes.")
                            .CiteEnd()
                        )
                     ,
                     //- CircumscribedMargin
                     //+ IndistinctMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("IndistinctMargin")
                         .SetDisplay("Indistinct margin")
                         .SetDefinition(new Definition()
                             .Line("[PR] Indistinct margin")
                             .MammoId("21")
                         )
                         .ValidModalities(Modalities.MG | Modalities.US)
                         .SetSnomedCode("129741003")
                         .SetSnomedDescription("ClinicalFinding | Lesion with indistinct margin (Finding)")
                     //- AutoGen
                        .SetDefinition(new Definition()
                             .Line("Indistinct margin")
                            .CiteStart(BiRadCitation)
                                .Text("There is no clear demarcation of the entire margin or any portion of the margin from the")
                                .Text("surrounding tissue. The boundary is poorly defined, and the significant feature is that the")
                                .Text("mass is NOT CIRCUMSCRIBED. This is meant to include �echogenic rim� (historically, echogenic")
                                .Text("halo) because one may not be able to distinguish between an indistinct margin and")
                                .Text("one that displays an echogenic rim.")
                            .CiteEnd()
                         )
                     ,
                     //- IndistinctMargin
                     //+ IntraductalExtension
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("IntraductalExtension")
                         .SetDisplay("Intraductal extension")
                         .SetDefinition(new Definition()
                             .Line("[PR] Intraductal extension")
                             .MammoId("201")
                         )
                         .ValidModalities(Modalities.US)
                     //- AutoGen
                     ,
                     //- IntraductalExtension
                     //+ IrregularMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("IrregularMargin")
                         .SetDisplay("Irregular margin")
                         .SetDefinition(new Definition()
                             .Line("[PR] Irregular margin")
                             .MammoId("20")
                         )
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
                         .SetDefinition(new Definition()
                             .Line("[PR] Lobulated margin")
                             .MammoId("19")
                         )
                         .ValidModalities(Modalities.US)
                         .SetComment("NOT FOUND")
                     //- AutoGen
                     ,
                     //- LobulatedMargin
                     //+ MacrolobulatedMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("MacrolobulatedMargin")
                         .SetDisplay("Macrolobulated margin")
                         .SetDefinition(new Definition()
                             .Line("[PR] Macrolobulated margin")
                         )
                         .ValidModalities(Modalities.MG)
                     //- AutoGen
                     ,
                     //- MacrolobulatedMargin
                     //+ MicrolobulatedMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("MicrolobulatedMargin")
                         .SetDisplay("Microlobulated margin")
                         .SetDefinition(new Definition()
                             .Line("[PR] Microlobulated margin")
                             .MammoId("111")
                         )
                         .ValidModalities(Modalities.MG | Modalities.US)
                         .SetSnomedCode("129739004")
                         .SetSnomedDescription("ClinicalFinding | Lesion with microlobulated margin (Finding)")
                     //- AutoGen
                        .SetDefinition(new Definition()
                            .Line("Microlobulated margin")
                            .CiteStart(BiRadCitation)
                            .Text("The margin is characterized by short-cycle undulations, but the significant feature is that")
                            .Text("the margin of the mass is NOT CIRCUMSCRIBED.")
                            .CiteEnd()
                        )
                     ,
                     //- MicrolobulatedMargin
                     //+ NonCircumscribedMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("NonCircumscribedMargin")
                         .SetDisplay("Non circumscribed margin")
                         .SetDefinition(new Definition()
                             .Line("[PR] Non circumscribed margin")
                             .MammoId("383")
                         )
                         .ValidModalities(Modalities.MRI | Modalities.US)
                         .SetSnomedDescription("ClinicalFinding | 129738007 | Lesion with circumscribed margin (Finding)")
                         .SetComment("NEED NOT")
                     //- AutoGen
                     ,
                     //- NonCircumscribedMargin
                     //+ ObscuredMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("ObscuredMargin")
                         .SetDisplay("Obscured margin")
                         .SetDefinition(new Definition()
                             .Line("[PR] Obscured margin")
                             .MammoId("28")
                         )
                         .ValidModalities(Modalities.MG)
                         .SetSnomedCode("129740002")
                         .SetSnomedDescription("ClinicalFinding | Lesion with obscured margin (Finding)")
                     //- AutoGen
                         .SetDefinition(new Definition()
                             .Line("Obscured margin")
                            .CiteStart(BiRadCitation)
                                .Text("A margin that is hidden by superimposed or adjacent fibroglandular tissue. This is used")
                                .Text("primarily when some of the margin of the mass is circumscribed, but the rest (more than 25%) is hidden.")
                            .CiteEnd()
                         )
                     ,
                     //- ObscuredMargin
                     //+ SmoothMargin
                     //+ AutoGen
                     new ConceptDef()
                         .SetCode("SmoothMargin")
                         .SetDisplay("Smooth margin")
                         .SetDefinition(new Definition()
                             .Line("[PR] Smooth margin")
                             .MammoId("18")
                         )
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
                         .SetDefinition(new Definition()
                             .Line("[PR] Spiculated margin")
                             .MammoId("29")
                         )
                         .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                         .SetSnomedCode("129742005")
                         .SetSnomedDescription("ClinicalFinding | Lesion with spiculated margin (Finding)")
                     //- AutoGen
                        .SetDefinition(new Definition()
                            .Line("Spiculated margin")
                            .CiteStart(BiRadCitation)
                                .Text("The margin is characterized by sharp lines radiating from the mass, often a sign of malignancy,")
                                .Text("but the significant feature is that the margin of the mass is NOT CIRCUMSCRIBED.")
                            .CiteEnd()
                        )
                     //- SpiculatedMargin
                     //- MarginCS
                     })
                 );
    }
}
