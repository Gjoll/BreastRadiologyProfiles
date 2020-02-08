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
        CSTaskVar AbnormalityLymphNodeCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        "AbnormalityLymphNodeTypeCS",
                        "Lymph Node Type CodeSystem",
                         "Lymph Node Type/CodeSystem",
                        "Lymph node abnormality types code system.",
                         Group_CommonCodesCS,
                        new ConceptDef[]
                         {
                            //+ Type
                            new ConceptDef()
                                .SetCode("NodeAxillary")
                                .SetDisplay("Node axillary")
                                .MammoId("648")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("BodyStructure | 68171009 | Axillary lymph node structure " +
                                    "(Bodypart)")
                                .SetUMLS("Axillary Nodes. ",
                                    "The axillary nodes are a group of lymph nodes located " +
                                    "in the axillary (or armpit) region of the body. ",
                                    "They perform the vital function of filtration and " +
                                    "conduction of lymph from the upper limbs, pectoral " +
                                    "region, and upper back.There are five axillary lymph " +
                                    "node groups, namely the lateral (humeral), anterior " +
                                    "(pectoral), posterior (subscapular), central and " +
                                    "apical nodes.")
                            ,
                            new ConceptDef()
                                .SetCode("NodeEnlarged")
                                .SetDisplay("Node enlarged")
                                .MammoId("649")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedCode("274744005")
                                .SetSnomedDescription("ClinicalFinding | Localized enlarged lymph nodes " +
                                    "(Disorder)")
                                .SetUMLS("Swollen lymph nodes usually occur as a result of " +
                                    "infection from bacteria or viruses. ",
                                    "Rarely, swollen lymph nodes are caused by cancer.Your " +
                                    "lymph nodes, also called lymph glands, play a vital " +
                                    "role in your body's ability to fight off infections. ",
                                    "They function as filters, trapping viruses, bacteria " +
                                    "and other causes of illnesses before they can infect " +
                                    "other parts of your body. ",
                                    "Common areas where you might notice swollen lymph " +
                                    "nodes include your neck, under your chin, in your " +
                                    "armpits and in your groin.")
                            ,
                            new ConceptDef()
                                .SetCode("NodeFocalCortex")
                                .SetDisplay("Node focal cortex")
                                .MammoId("662")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("NodeInfraclavicular")
                                .SetDisplay("Node infraclavicular")
                                .MammoId("665")
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("BodyStructure | 9659009 | Infraclavicular lymph node " +
                                    "(Bodypart)")
                                .SetUMLS("(Infraclavicular labeled at upper left.) One or two " +
                                    "deltopectoral lymph nodes (or infraclavicular nodes) " +
                                    "are found beside the cephalic vein, between the pectoralis " +
                                    "major and deltoideus, immediately below the clavicle " +
                                    ". ",
                                    "They are situated in the course of the external collecting " +
                                    "trunks of the arm.")
                            ,
                            new ConceptDef()
                                .SetCode("NodeIntramammary")
                                .SetDisplay("Node intramammary")
                                .MammoId("650")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("BodyStructure | 443808008 | Structure of intramammary " +
                                    "lymph node (Bodypart)")
                                .SetUMLS("Intramammary lymph nodes are defined as lymph nodes " +
                                    "surrounded by breast tissue.")
                            ,
                            new ConceptDef()
                                .SetCode("NodeLymph")
                                .SetDisplay("Node lymph")
                                .MammoId("651")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("NodeLymphNormal")
                                .SetDisplay("Node lymph normal")
                                .MammoId("652")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("NodeSupraclavicular")
                                .SetDisplay("Node supraclavicular")
                                .MammoId("666")
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("BodyStructure | 76838003 | Structure of supraclavicular " +
                                    "lymph node (Bodypart)")
                                .SetUMLS("The supraclavicular lymph nodes are a set of lymph " +
                                    "nodes found just above the clavicle or collarbone, " +
                                    "toward the hollow of the neck. ",
                                    "Lymph nodes are responsible for filtering the lymphatic " +
                                    "fluid of unwanted debris and bacteria.")
                            ,
                            new ConceptDef()
                                .SetCode("NodeUniformThickness")
                                .SetDisplay("Node uniform thickness")
                                .MammoId("663")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- Type
                         }
                     )
                 );


        VSTaskVar AbnormalityLymphNodeVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                   "AbnormalityLymphNodeTypeVS",
                   "Lymph Node ValueSet",
                    "Lymph Node/ValueSet",
                   "lymph node abnormality types value set.",
                    Group_CommonCodesVS,
                    Self.AbnormalityLymphNodeCS.Value()
                    )
            );


        SDTaskVar AbnormalityLymphNode = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.AbnormalityLymphNodeVS.Value();

                SDefEditor e = Self.CreateEditor("AbnormalityLymphNode",
                    "LymphNode",
                    "Lymph Node",
                    Global.ObservationUrl,
                    $"{Group_CommonResources}/AbnormalityLymphNode",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.TumorSatelliteFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ObservationComponentShapeFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedCountFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedDistributionFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedSizeFragment.Value())
                    .AddFragRef(Self.ObservationComponentNotPreviouslySeenFragment.Value())
                    .AddFragRef(Self.ObservationComponentCorrespondsWithFragment.Value())
                    .AddFragRef(Self.ObservationComponentPreviouslyDemonstratedByFragment.Value())

                    .AddFragRef(Self.ObservationHasMemberAssociatedFeaturesFragment.Value())

                    .Description("LymphNode Observation",
                        new Markdown()
                    )
                    ;

                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeAbnormalityLymphNode.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("lymphNodeType",
                    Self.ComponentSliceCodeAbnormalityLymphNodeType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "Lymph Node Type",
                    "refines the lymph node type");
            });
    }
}
