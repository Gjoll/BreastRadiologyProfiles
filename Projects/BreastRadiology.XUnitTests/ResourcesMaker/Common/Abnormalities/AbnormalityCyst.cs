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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        CSTaskVar AbnormalityCystTypeCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        "AbnormalityCystTypeCS",
                        "Cyst Type CodeSystem",
                         "Cyst Type/CodeSystem",
                        "Cyst abnormality type CodeSystem.",
                         Group_CommonCodesCS,
                        new ConceptDef[]
                         {
                         //+ CystTypeCS
                         //+ Cyst
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Cyst")
                             .SetDisplay("Cyst")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Cyst")
                                 .MammoId("69")
                             )
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                         //- AutoGen
                         ,
                         //- Cyst
                         //+ CystComplex
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystComplex")
                             .SetDisplay("Cyst complex")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Cyst complex")
                                 .MammoId("610")
                             )
                             .ValidModalities(Modalities.MG | Modalities.US)
                         //- AutoGen
                         ,
                         //- CystComplex
                         //+ CystComplicated
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystComplicated")
                             .SetDisplay("Cyst complicated")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Cyst complicated")
                                 .MammoId("657")
                             )
                             .ValidModalities(Modalities.MG | Modalities.US)
                         //- AutoGen
                         ,
                         //- CystComplicated
                         //+ CystMicro
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystMicro")
                             .SetDisplay("Cyst micro")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Cyst micro")
                                 .MammoId("617")
                             )
                             .ValidModalities(Modalities.US)
                         //- AutoGen
                         ,
                         //- CystMicro
                         //+ CystOil
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystOil")
                             .SetDisplay("Cyst oil")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Cyst oil")
                                 .MammoId("636")
                             )
                             .ValidModalities(Modalities.MG | Modalities.US)
                         //- AutoGen
                         ,
                         //- CystOil
                         //+ CystSimple
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystSimple")
                             .SetDisplay("Cyst simple")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Cyst simple")
                                 .MammoId("609")
                             )
                             .ValidModalities(Modalities.MG | Modalities.US)
                         //- AutoGen
                         ,
                         //- CystSimple
                         //+ CystWithDebris
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystWithDebris")
                             .SetDisplay("Cyst with debris")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Cyst with debris")
                                 .MammoId("661")
                             )
                             .ValidModalities(Modalities.MG | Modalities.US)
                         //- AutoGen
                         
                         //- CystWithDebris
                         //- CystTypeCS
                         }
                     )
             );


        VSTaskVar AbnormalityCystVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                   "AbnormalityCystTypeVS",
                   "Cyst Abnormalities ValueSet",
                    "Cyst/ValueSet",
                   "Cyst abnormality types value set.",
                    Group_CommonCodesVS,
                    Self.AbnormalityCystTypeCS.Value()
                    )
            );


        SDTaskVar AbnormalityCyst = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.AbnormalityCystVS.Value();

                {
                    IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                    valueSetIntroDoc
                        .ReviewedStatus("NOONE", "")
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("AbnormalityCyst",
                        "Cyst",
                        "Cyst",
                        Global.ObservationUrl,
                        $"{Group_CommonResources}/AbnormalityCyst",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.TumorSatelliteFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ShapeComponentsFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
                    .Description("Cyst Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                    )
                    ;
                s = e.SDef;
                e.Select("code").Pattern(Self.ObservationCodeAbnormalityCyst.ToCodeableConcept());
                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    .MammoDescription("540")
                    ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference(sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");
                e.SliceTargetReference(sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("cystType",
                    Self.ComponentSliceCodeAbnormalityCystType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "Cyst Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the cyst type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                );
            });
    }
}
