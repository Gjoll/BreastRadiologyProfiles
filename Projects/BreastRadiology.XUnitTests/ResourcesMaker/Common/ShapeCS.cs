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

        VSTaskVar ShapeVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "ShapeVS",
                        "Shape ValueSet",
                        "Shape/ValueSet",
                        "Shape value set.",
                        Group_CommonCodesVS,
                        Self.ShapeCS.Value()
                    )
            );


        CSTaskVar ShapeCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "ShapeCS",
                     "Shape CodeSystem",
                     "Shape/CodeSystem",
                     "Shape values code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                        //+ Codes
                        //+ IrregularInShape
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("IrregularInShape")
                            .SetDisplay("Irregular in shape")
                            .SetDefinition("[PR] Irregular in shape")
                            .MammoId("16")
                            .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            .SetSnomedCode("129736006")
                            .SetSnomedDescription("ClinicalFinding | Irregular shaped lesion")
                            .SetUMLS("A mass that can't be characterized by any specific " +
                                "shape.")
                        //- AutoGen
                            .BiRadsDef(
                                "The shape is neither round nor oval.",
                                "For mammography, use of this descriptor usually implies a suspicious finding.")
                        ,
                        //- IrregularInShape
                        //+ OvalInShape
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("OvalInShape")
                            .SetDisplay("Oval in shape")
                            .SetDefinition("[PR] Oval in shape")
                            .MammoId("15")
                            .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            .SetSnomedCode("129734009")
                            .SetSnomedDescription("ClinicalFinding | Oval shaped lesion (Finding)")
                            .SetUMLS("A mass that is elliptical or egg-shaped.")
                        //- AutoGen
                            .BiRadsDef("Shape is elliptical or egg-shaped (may include 2 or 3 undulations, , i.e., \"gently lobulated\" or \"macrolobulated\").")
                        ,
                        //- OvalInShape
                        //+ RoundInShape
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("RoundInShape")
                            .SetDisplay("Round in shape")
                            .SetDefinition("[PR] Round in shape")
                            .MammoId("14")
                            .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            .SetSnomedCode("129733003")
                            .SetSnomedDescription("ClinicalFinding | Round shaped lesion (Finding)")
                            .SetUMLS("A mass that is spherical, ball-shaped, circular or " +
                                "global.")
                        //- AutoGen
                            .BiRadsDef(
                                "A mass that is spherical, ball-shaped, circular, or globular in shape.",
                                "A round mass has an anteroposterior diameter equal to its transverse diameter",
                                "and to qualify as a ROUND mass, it must be circular in perpendicular projections.",
                                "Breast masses with a ROUND shape are not commonly seen with breast ultrasound.")
                                ,
                        //- RoundInShape
                        //+ LobulatedInShape
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("LobulatedInShape")
                            .SetDisplay("Lobulated in shape")
                            .SetDefinition("[PR] Lobulated in shape")
                            .MammoId("190")
                            .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            .SetSnomedCode("129735005")
                            .SetSnomedDescription("ClinicalFinding | Lobular shaped lesion (Finding)")
                            .SetUMLS("A mass that has an undulating  (having a smoothly " +
                                "rising and falling form or outline) contour.")
                        //- AutoGen
                        ,
                        //- LobulatedInShape
                        //+ Reniform
                        //+ AutoGen
                        new ConceptDef()
                            .SetCode("Reniform")
                            .SetDisplay("Reniform")
                            .SetDefinition("[PR] Reniform")
                            .MammoId("27")
                            .ValidModalities(Modalities.MG)
                        //- AutoGen
                        //- Reniform
                        //- Codes
                     })
                 );
    }
}



















































