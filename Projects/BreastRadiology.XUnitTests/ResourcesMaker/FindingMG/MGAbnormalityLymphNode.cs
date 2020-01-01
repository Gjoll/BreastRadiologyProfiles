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
                 Self.CreateCodeSystem(
                        "MGAbnormalityLymphNodeCS",
                        "Mammography Lymph Node Refinement CodeSystem",
                         "MG Lymph Node Refinement/CodeSystem",
                        "Mammography lymph node abnormality types code system.",
                         Group_MGCodesCS,
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
                Self.CreateValueSet(
                   "MGAbnormalityLymphNodeVS",
                   "Mammography Lymph Node ValueSet",
                    "MG Lymph Node/ValueSet",
                   "Mammography lymph node abnormality types value set.",
                    Group_MGCodesVS,
                    Self.MGAbnormalityLymphNodeCS.Value()
                    )
            );


        StringTaskVar MGAbnormalityLymphNode = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.MGAbnormalityLymphNodeVS.Value();

                SDefEditor e = Self.CreateEditor("MGAbnormalityLymphNode",
                    "Mammography LymphNode",
                    "MG Lymph Node",
                    ObservationUrl,
                    $"{Group_MGResources}/AbnormalityLymphNode")
                    .Description("Breast Radiology Mammography LymphNode Observation",
                        new Markdown()
                            .MissingObservation("a lymph node abnormality")
                            //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(Self.MGShapeTargetsFragment.Value())
                    ;

                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Lymph Node")
                    .Refinement(binding, "LymphNode")
                    ;

                e.Select("value[x]")
                        .ZeroToOne()
                        .Type("CodeableConcept")
                        .Binding(binding.Url, BindingStrength.Required)
                        ;
                e.AddValueSetLink(binding);

                if (Self.Component_HasMember)
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(Self.ObservedCount.Value(), 0, "1"),
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);
                }
                else
                {
                    e.StartComponentSliceing();
                    Self.ComponentSliceObservedCount(e);
                }
            });
    }
}