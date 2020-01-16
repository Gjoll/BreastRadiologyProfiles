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
                        "AbnormalityLymphNodeCS",
                        "Lymph Node Type CodeSystem",
                         "Lymph Node Type/CodeSystem",
                        "Lymph node abnormality types code system.",
                         Group_CommonCodesCS,
                        new ConceptDef[]
                         {
                        new ConceptDef("Axillary",
                            "Axillary",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Enlarged",
                            "Enlarged",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("FocalCortex",
                            "FocalCortex",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("UniformThickness",
                            "UniformThickness",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Intramammory",
                            "Intramammory",
                            new Definition()
                            .CiteStart()
                            .Line("These are circumscribed masses that are reniform and have hilar fat. They are generally 1 cm or smaller")
                            .Line("in size. They may be larger than 1 cm and characterized as normal when fat replacement is pro-")
                            .Line("nounced. They frequently occur in the lateral and usually upper portions of the breast closer to the")
                            .Line("axilla, although they may occur anywhere in the breast. They usually are seen adjacent to a vein,")
                            .Line("because the lymphatic drainage of the breast parallels the venous drainage.")
                            .CiteEnd(BiRadCitation)
                            ),
                        new ConceptDef("InternalMargin",
                            "Internal Margin",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Normal",
                            "Normal",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("PathLymphNode",
                            "Path Lymph Node",
                            new Definition()
                                .Line("[PR]")
                            )
                         }
                     )
                 );


        VSTaskVar AbnormalityLymphNodeVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                   "AbnormalityLymphNodeVS",
                   "Lymph Node ValueSet",
                    "Lymph Node/ValueSet",
                   "lymph node abnormality types value set.",
                    Group_CommonCodesVS,
                    Self.AbnormalityLymphNodeCS.Value()
                    )
            );


        SDTaskVar AbnormalityLymphNode = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                ValueSet binding = Self.AbnormalityLymphNodeVS.Value();

                SDefEditor e = Self.CreateEditorObservationLeaf("AbnormalityLymphNode",
                    "LymphNode",
                    "Lymph Node",
                    $"{Group_CommonResources}/AbnormalityLymphNode")
                    .Description("LymphNode Observation",
                        new Markdown()
                            .MissingObservation("a lymph node abnormality")
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ShapeComponentsFragment.Value())

                    .AddFragRef(Self.TumorQualifierComponentsFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.CorrespondsWith.Value())
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                PreFhir.ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("lymphNodeType",
                    Self.CodeAbnormalityLymphNodeType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "LymphNode Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the lymph node type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
                Self.ComponentSliceObservedCountRange(e);
            });
    }
}
