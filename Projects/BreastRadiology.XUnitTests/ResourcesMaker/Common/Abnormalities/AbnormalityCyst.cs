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
                         //+ Type
                         //+ Cyst
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Cyst")
                             .SetDisplay("Cyst")
                             .SetDefinition("[PR] Cyst")
                             .MammoId("69")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                             .SetSnomedCode("399294002")
                             .SetOneToMany("one")
                             .SetSnomedDescription("ClinicalFinding |Cyst of breast (Disorder)")
                             .SetICD10("N60.09")
                             .SetUMLS("A cyst is a sac-like pocket of membranous tissue " +
                                 "that contains fluid, air, or other substances. Cysts " +
                                 "can grow almost anywhere in your body or under your " +
                                 "skin.")
                         //- AutoGen
                         ,
                         //- Cyst
                         //+ CystComplex
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystComplex")
                             .SetDisplay("Cyst complex")
                             .SetDefinition("[PR] Cyst complex")
                             .MammoId("610")
                             .ValidModalities(Modalities.MG | Modalities.US)
                             .SetSnomedCode("449837001")
                             .SetOneToMany("one")
                             .SetSnomedDescription("ClinicalFinding | Complex cyst of breast (Disorder)")
                             .SetICD10("N60.09")
                             .SetUMLS("Refers to cysts that contain something more than " +
                                 "clear fluid. A complex breast cyst contains solid " +
                                 "elements suspended within the fluid, and may also " +
                                 "feature segmentation (septation) and some regions " +
                                 "of the cyst wall that are ‘thicker‘ than others.")
                         //- AutoGen
                         ,
                         //- CystComplex
                         //+ CystComplicated
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystComplicated")
                             .SetDisplay("Cyst complicated")
                             .SetDefinition("[PR] Cyst complicated")
                             .MammoId("657")
                             .ValidModalities(Modalities.MG | Modalities.US)
                             .SetComment("NOT COMPLICATED")
                             .SetUMLS("Complicated cysts are \"in between\" a simple cyst and " +
                                 "a complex cyst. A complicated breast cyst contains " +
                                 "solid elements suspended within the fluid, and may " +
                                 "also feature segmentation (septation) and some regions " +
                                 "of the cyst wall that are ‘thicker‘ than others. " +
                                 "Complicated breast cysts are one of the cystic breast " +
                                 "lesions that show intracystic debris which may imitate " +
                                 "a solid mass appearance.")
                         //- AutoGen
                         ,
                         //- CystComplicated
                         //+ CystMicro
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystMicro")
                             .SetDisplay("Cyst micro")
                             .SetDefinition("[PR] Cyst micro")
                             .MammoId("617")
                             .ValidModalities(Modalities.US)
                             .SetUMLS("Is a sac-like pocket of tissue that contains fluid, " +
                                 "air, or other substances. A Microcyst is small and " +
                                 "less than 2-3 mm. They are often in clusters and " +
                                 "only show up on a mammogram or ultrasound.")
                         //- AutoGen
                         ,
                         //- CystMicro
                         //+ CystOil
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystOil")
                             .SetDisplay("Cyst oil")
                             .SetDefinition("[PR] Cyst oil")
                             .MammoId("636")
                             .ValidModalities(Modalities.MG | Modalities.US)
                             .SetUMLS("Oil cysts are filled with fluid that may feel smooth " +
                                 "and soft/squishy. They are caused by the breakdown " +
                                 "of fatty tissue.")
                         //- AutoGen
                         ,
                         //- CystOil
                         //+ CystSimple
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystSimple")
                             .SetDisplay("Cyst simple")
                             .SetDefinition("[PR] Cyst simple")
                             .MammoId("609")
                             .ValidModalities(Modalities.MG | Modalities.US)
                             .SetSnomedCode("399253005")
                             .SetOneToMany("one")
                             .SetSnomedDescription("ClinicalFinding | Simple cyst of breast (Disorder)")
                             .SetICD10("N60.09")
                             .SetUMLS("A simple cyst is a sac-like pocket of membranous " +
                                 "tissue that only contains clear fluid.")
                         //- AutoGen
                         ,
                         //- CystSimple
                         //+ CystWithDebris
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("CystWithDebris")
                             .SetDisplay("Cyst with debris")
                             .SetDefinition("[PR] Cyst with debris")
                             .MammoId("661")
                             .ValidModalities(Modalities.MG | Modalities.US)
                             .SetUMLS("A cyst that is filled with debris and fluid substance. " +
                                 "It Is either considered a complex or complicated " +
                                 "cyst. The type of debris determines what kind of " +
                                 "cyst.")
                         //- AutoGen
                         
                         //- CystWithDebris
                         //- Type
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
                    .AddFragRef(Self.ObservedDistributionComponentFragment.Value())
                    .AddFragRef(Self.ObservedSizeComponentFragment.Value())
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
