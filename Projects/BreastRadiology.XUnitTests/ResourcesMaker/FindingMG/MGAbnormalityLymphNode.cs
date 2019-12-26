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
        String MGAbnormalityLymphNode()
        {
            if (this.mgAbnormalityLymphNode == null)
                this.CreateMGAbnormalityLymphNode();
            return this.mgAbnormalityLymphNode;
        }
        String mgAbnormalityLymphNode = null;

       CSTaskVar BreastRadMammoAbnormalityLymphNodeCS = new CSTaskVar(
            () =>
                ResourcesMaker.Self.CreateCodeSystem(
                       "BreastRadMammoAbnormalityLymphNode",
                       "Mammography Lymph Node Abnormality Refinement",
                        "Mg Lymph Node Refinement/CodeSystem",
                       "Codes defining types of mammography lymph node abnormalities.",
                        Group_MGCodes,
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


        VSTaskVar BreastRadMammoAbnormalityLymphNodeVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSetXX(
                   "BreastRadMammoAbnormalityLymphNode",
                   "Mammography Lymph Node Abnormality",
                    "Mg Lymph Node/ValueSet",
                   "Codes defining types of mammography lymph node abnormalities.",
                    Group_MGCodes,
                    ResourcesMaker.Self.BreastRadMammoAbnormalityLymphNodeCS.Value()
                    )
            );


        void CreateMGAbnormalityLymphNode()
        {
                ValueSet binding = this.BreastRadMammoAbnormalityLymphNodeVS.Value();

                SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityLymphNode",
                    "Mammography LymphNode Abnormality",
                    "Mg Lymph Node Abnormality",
                    ObservationUrl,
                    $"{Group_MGResources}/AbnormalityLymphNode")
                    .Description("Breast Radiology Mammography LymphNode Abnormality Observation",
                        new Markdown()
                            .MissingObservation("a lymph node abnormality")
                            .Todo(
                                "should this be a leaf node (how about shape, density, location, etc)."
                            )
                    )
                    .AddFragRef(this.ObservationNoDeviceFragment())
                    .AddFragRef(this.ObservationCodedValueFragment())
                    .AddFragRef(this.ObservationSectionFragment())
                    .AddFragRef(this.MGCommonTargetsFragment())
                    .AddFragRef(this.MGShapeTargetsFragment())
                    ;

            this.mgAbnormalityLymphNode = e.SDef.Url;
            e.Select("value[x]")
                    .ZeroToOne()
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(this.CommonObservedCount(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Lymph Node Abnormality")
                    .Refinement(binding, "LymphNode")
                    ;
        }
    }
}
