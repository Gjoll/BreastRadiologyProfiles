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
        CSTaskVar MGAbnormalityDuctCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                        "MGAbnormalityDuctCS",
                        "Mammography Duct Refinement CodeSystem",
                         "MG Duct Refinement/CodeSystem",
                        "Mammography duct abnormality types code system.",
                         Group_MGCodes,
                        new ConceptDef[]
                         {
                        new ConceptDef("Normal",
                            "Normal",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Ectasia",
                            "Ectasia",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Dilated",
                            "Dilated",
                            new Definition()
                                .CiteStart()
                                .Line("This is a unilateral tubular or branching structure that likely represents a dilated or otherwise en-")
                                .Line("larged duct. It is a rare finding. Even if unassociated with other suspicious clinical or mammographic")
                                .Line("findings, it has been reported to be associated with noncalcified DCIS.")
                                .CiteEnd(BiRadCitation)
                            )
                         }
                     )
                 );


        VSTaskVar MGAbnormalityDuctVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                   "MGAbnormalityDuctVS",
                   "Mammography Duct ValueSet",
                    "MG Duct/ValueSet",
                   "Mammography duct node abnormality types value set.",
                    Group_MGCodes,
                    ResourcesMaker.Self.MGAbnormalityDuctCS.Value()
                    )
            );


        StringTaskVar MGAbnormalityDuct = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.MGAbnormalityDuctVS.Value();
                SDefEditor e = ResourcesMaker.Self.CreateEditor("MGAbnormalityDuct",
                        "Mammography Duct",
                        "MG Duct",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityDuct")
                    .Description("Breat Radiology Mammography Duct Observation",
                        new Markdown()
                            .MissingObservation("a duct abnormality")
                            .Todo(
                                "should this be a leaf node (how about shape, density, location, etc).",
                                "make dilated the default value."
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
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
                    new ProfileTargetSlice(ResourcesMaker.Self.ObservedCount.Value(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Duct")
                    .Refinement(binding, "Duct")
                    ;
            });
    }
}
