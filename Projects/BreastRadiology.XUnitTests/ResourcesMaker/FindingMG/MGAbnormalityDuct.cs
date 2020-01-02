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
                 Self.CreateCodeSystem(
                        "MGAbnormalityDuctCS",
                        "Mammography Duct Type CodeSystem",
                         "MG Duct Type/CodeSystem",
                        "Mammography duct abnormality types code system.",
                         Group_MGCodesCS,
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
                Self.CreateValueSet(
                   "MGAbnormalityDuctVS",
                   "Mammography Duct ValueSet",
                    "MG Duct/ValueSet",
                   "Mammography duct node abnormality types value set.",
                    Group_MGCodesVS,
                    Self.MGAbnormalityDuctCS.Value()
                    )
            );


        StringTaskVar MGAbnormalityDuct = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.MGAbnormalityDuctVS.Value();
                SDefEditor e = Self.CreateEditor("MGAbnormalityDuct",
                        "Mammography Duct",
                        "MG Duct",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityDuct")
                    .Description("Breat Radiology Mammography Duct Observation",
                        new Markdown()
                            .MissingObservation("a duct abnormality")
                            .Todo(
                                "make dilated the default value."
                            )
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(Self.MGShapeTargetsFragment.Value())
                    ;

                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Duct")
                    .Refinement(binding, "Duct")
                    ;

                if (Self.Component_HasMember)
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(Self.ObservedCount.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.ConsistentWith.Value(), 0, "*"),
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);

                    e.Select("value[x]")
                        .ZeroToOne()
                        .Type("CodeableConcept")
                        .Binding(binding.Url, BindingStrength.Required)
                        ;
                    e.AddValueSetLink(binding);
                }
                else
                {
                    e.Select("value[x]").Zero();

                    e.StartComponentSliceing();
                    e.ComponentSliceCodeableConcept("mgAbnormalityDuctType",
                        Self.MGCodeAbnormalityDuctType.ToCodeableConcept(),
                        binding,
                        BindingStrength.Required,
                        1,
                        "1",
                        "MG AbnormalityDuct Type");
                    Self.ComponentSliceConsistentWith(e);
                    Self.ComponentSliceObservedCount(e);
                }
            });
    }
}
