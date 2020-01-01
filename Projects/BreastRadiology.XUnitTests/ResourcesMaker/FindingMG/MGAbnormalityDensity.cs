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

        CSTaskVar MGAbnormalityDensityCS = new CSTaskVar(
             () =>
                 Self.CreateCodeSystem(
                        "MGAbnormalityDensityCS",
                        "Mammography Density Refinement CodeSystem",
                         "MG Density Refinement/CodeSystem",
                        "Mammography density abnormality types code system.",
                         Group_MGCodesCS,
                        new ConceptDef[]
                         {
                        new ConceptDef("FocalAsymmetrical",
                            "Focal Asymmetrical",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Nodular",
                            "Nodular",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Tubular",
                            "Tubular",
                            new Definition()
                                .Line("[PR]")
                            )
                         }
                     )
                 );


        VSTaskVar MGAbnormalityDensityVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                   "MGAbnormalityDensityVS",
                   "Mammography Density ValueSet",
                    "MG Density/ValueSet",
                   "Mammography density abnormality types value set.",
                    Group_MGCodesVS,
                    Self.MGAbnormalityDensityCS.Value()
                    )
            );


        StringTaskVar MGAbnormalityDensity = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.MGAbnormalityDensityVS.Value();

                SDefEditor e = Self.CreateEditor("MGAbnormalityDensity",
                        "Mammography Density",
                        "MG Density",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityDensity")
                    .Description("Breat Radiology Mammography Density Observation",
                        new Markdown()
                            .MissingObservation("a Density abnormality")
                            .Todo(
                                "default value? for refinement"
                            )
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(Self.MGShapeTargetsFragment.Value())
                    ;

                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Density")
                    .Refinement(binding, "Density")
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
                    new ProfileTargetSlice(Self.ConsistentWith.Value(), 0, "*"),
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);
                }
                else
                {
                    e.StartComponentSliceing();
                    Self.ComponentSliceObservedCount(e);
                    Self.ComponentSliceConsistentWith(e);
                }
            });
    }
}