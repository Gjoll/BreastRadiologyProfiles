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
        CSTaskVar MGAbnormalityLymphNodeCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                        "BreastRadMammoAbnormalityLymphNode",
                        "Mammography Lymph Node Refinement",
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


        VSTaskVar MGAbnormalityLymphNodeVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                   "BreastRadMammoAbnormalityLymphNode",
                   "Mammography Lymph Node",
                    "Mg Lymph Node/ValueSet",
                   "Codes defining types of mammography lymph node abnormalities.",
                    Group_MGCodes,
                    ResourcesMaker.Self.MGAbnormalityLymphNodeCS.Value()
                    )
            );


        StringTaskVar MGAbnormalityLymphNode = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.MGAbnormalityLymphNodeVS.Value();

                SDefEditor e = ResourcesMaker.Self.CreateEditorXX("BreastRadMammoAbnormalityLymphNode",
                    "Mammography LymphNode",
                    "Mg Lymph Node",
                    ObservationUrl,
                    $"{Group_MGResources}/AbnormalityLymphNode")
                    .Description("Breast Radiology Mammography LymphNode Observation",
                        new Markdown()
                            .MissingObservation("a lymph node abnormality")
                            .Todo(
                                "should this be a leaf node (how about shape, density, location, etc)."
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationSectionFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.MGShapeTargetsFragment.Value())
                    ;

                s = e.SDef.Url;
                e.Select("value[x]")
                        .ZeroToOne()
                        .Type("CodeableConcept")
                        .Binding(binding.Url, BindingStrength.Required)
                        ;
                e.AddValueSetLink(binding);

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedCount.Value(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Lymph Node")
                    .Refinement(binding, "LymphNode")
                    ;
            });
    }
}
