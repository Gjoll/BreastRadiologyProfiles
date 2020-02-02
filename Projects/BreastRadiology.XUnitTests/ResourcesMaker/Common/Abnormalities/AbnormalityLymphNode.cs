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
                            //+ NodeAxillary
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NodeAxillary")
                                .SetDisplay("Node axillary")
                                .SetDefinition("[PR] Node axillary")
                                .MammoId("648")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            ,
                            //- NodeAxillary
                            //+ NodeEnlarged
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NodeEnlarged")
                                .SetDisplay("Node enlarged")
                                .SetDefinition("[PR] Node enlarged")
                                .MammoId("649")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            ,
                            //- NodeEnlarged
                            //+ NodeFocalCortex
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NodeFocalCortex")
                                .SetDisplay("Node focal cortex")
                                .SetDefinition("[PR] Node focal cortex")
                                .MammoId("662")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            ,
                            //- NodeFocalCortex
                            //+ NodeInfraclavicular
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NodeInfraclavicular")
                                .SetDisplay("Node infraclavicular")
                                .SetDefinition("[PR] Node infraclavicular")
                                .MammoId("665")
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            ,
                            //- NodeInfraclavicular
                            //+ NodeIntramammary
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NodeIntramammary")
                                .SetDisplay("Node intramammary")
                                .SetDefinition("[PR] Node intramammary")
                                .MammoId("650")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                                .BiRadsDef("These are circumscribed masses that are reniform and have hilar fat. They are generally 1 cm or smaller",
                                        "in size. They may be larger than 1 cm and characterized as normal when fat replacement is pronounced. ",
                                        "They frequently occur in the lateral and usually upper portions of the breast closer to the",
                                        "axilla, although they may occur anywhere in the breast. They usually are seen adjacent to a vein,",
                                        "because the lymphatic drainage of the breast parallels the venous drainage.")
                            ,
                            //- NodeIntramammary
                            //+ NodeLymph
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NodeLymph")
                                .SetDisplay("Node lymph")
                                .SetDefinition("[PR] Node lymph")
                                .MammoId("651")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            ,
                            //- NodeLymph
                            //+ NodeLymphNormal
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NodeLymphNormal")
                                .SetDisplay("Node lymph normal")
                                .SetDefinition("[PR] Node lymph normal")
                                .MammoId("652")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            ,
                            //- NodeLymphNormal
                            //+ NodeSupraclavicular
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NodeSupraclavicular")
                                .SetDisplay("Node supraclavicular")
                                .SetDefinition("[PR] Node supraclavicular")
                                .MammoId("666")
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            ,
                            //- NodeSupraclavicular
                            //+ NodeUniformThickness
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NodeUniformThickness")
                                .SetDisplay("Node uniform thickness")
                                .SetDefinition("[PR] Node uniform thickness")
                                .MammoId("663")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            
                            //- NodeUniformThickness
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
                    .AddFragRef(Self.ShapeComponentsFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
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

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference( sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("lymphNodeType",
                    Self.ComponentSliceCodeAbnormalityLymphNodeType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "Lymph Node Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the lymph node type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
            });
    }
}
