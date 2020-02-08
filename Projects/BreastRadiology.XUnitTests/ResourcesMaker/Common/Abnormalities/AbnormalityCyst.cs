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
                         new ConceptDef()
                             .SetCode("Cyst")
                             .SetDisplay("Cyst")
                             .MammoId("69")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                             .SetSnomedCode("399294002")
                             .SetSnomedDescription("ClinicalFinding |Cyst of breast (Disorder)")
                             .SetUMLS("A cyst is a sac-like pocket of membranous tissue " +
                                 "that contains fluid, air, or other substances. ",
                                 "Cysts can grow almost anywhere in your body or under " +
                                 "your skin.")
                         ,
                         new ConceptDef()
                             .SetCode("CystComplex")
                             .SetDisplay("Cyst complex")
                             .MammoId("610")
                             .ValidModalities(Modalities.MG | Modalities.US)
                             .SetSnomedCode("449837001")
                             .SetSnomedDescription("ClinicalFinding | Complex cyst of breast (Disorder)")
                             .SetUMLS("Complex cysts have irregular or scalloped borders, " +
                                 "thick walls, and some evidence of solid areas and/or " +
                                 "debris in the fluid. ",
                                 "These solid areas echo back the sound waves from " +
                                 "the ultrasound. ",
                                 "A complex cyst is sometimes aspirated, or drained " +
                                 "with a fine needle, so that the fluid inside can " +
                                 "be tested. ",
                                 "If blood or any unusual cells are present, further " +
                                 "testing may be needed to rule out breast cancer. ",
                                 "###URL#https://www.breastcancer.org/symptoms/benign/cysts")
                         ,
                         new ConceptDef()
                             .SetCode("CystComplicated")
                             .SetDisplay("Cyst complicated")
                             .MammoId("657")
                             .ValidModalities(Modalities.MG | Modalities.US)
                             .SetUMLS("Complicated cysts are \"in between\" simple and complex. ",
                                 "Although they share most of the features of simple " +
                                 "cysts, they tend to have some debris inside them " +
                                 "and echo back some of the ultrasound waves. ",
                                 "However, they don’t have the thick walls or obvious " +
                                 "solid components that a complex cyst has. ",
                                 "###URL#https://www.breastcancer.org/symptoms/benign/cysts")
                         ,
                         new ConceptDef()
                             .SetCode("CystMicro")
                             .SetDisplay("Cyst micro")
                             .MammoId("617")
                             .ValidModalities(Modalities.US)
                             .SetUMLS("Is a sac-like pocket of tissue that contains fluid, " +
                                 "air, or other substances. ",
                                 "A Microcyst is small and less than 2-3 mm. ",
                                 "They are often in clusters and only show up on a " +
                                 "mammogram or ultrasound.")
                         ,
                         new ConceptDef()
                             .SetCode("CystOil")
                             .SetDisplay("Cyst oil")
                             .MammoId("636")
                             .ValidModalities(Modalities.MG | Modalities.US)
                             .SetUMLS("Oil cysts are filled with fluid that may feel smooth " +
                                 "and soft/squishy. ",
                                 "They are caused by the breakdown of fatty tissue.")
                         ,
                         new ConceptDef()
                             .SetCode("CystSimple")
                             .SetDisplay("Cyst simple")
                             .MammoId("609")
                             .ValidModalities(Modalities.MG | Modalities.US)
                             .SetSnomedCode("399253005")
                             .SetSnomedDescription("ClinicalFinding | Simple cyst of breast (Disorder)")
                             .SetUMLS("A simple cyst is a sac-like pocket of membranous " +
                                 "tissue that only contains clear fluid.")
                         ,
                         new ConceptDef()
                             .SetCode("CystWithDebris")
                             .SetDisplay("Cyst with debris")
                             .MammoId("661")
                             .ValidModalities(Modalities.MG | Modalities.US)
                             .SetUMLS("A cyst that is filled with debris and fluid substance. ",
                                 "It Is either considered a complex or complicated " +
                                 "cyst. ",
                                 "The type of debris determines what kind of cyst.")
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
