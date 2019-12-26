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
        String MGAbnormalityDensity()
        {
            if (this.mgAbnormalityDensity == null)
                this.CreateMGAbnormalityDensity();
            return this.mgAbnormalityDensity;
        }
        String mgAbnormalityDensity = null;

        CSTaskVar BreastRadMammoAbnormalityDensityCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                        "BreastRadMammoAbnormalityDensity",
                        "Mammography Density Abnormality Refinement",
                         "Mg Density Refinement/CodeSystem",
                        "Codes defining types of mammography density abnormalities.",
                         Group_MGCodes,
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


        VSTaskVar BreastRadMammoAbnormalityDensityVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                   "BreastRadMammoAbnormalityDensity",
                   "Mammography Density Abnormality",
                    "Mg Density/ValueSet",
                   "Codes defining types of mammography density abnormalities.",
                    Group_MGCodes,
                    ResourcesMaker.Self.BreastRadMammoAbnormalityDensityCS.Value()
                    )
            );


        void CreateMGAbnormalityDensity()
        {
            ValueSet binding = this.BreastRadMammoAbnormalityDensityVS.Value();

            SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityDensity",
                    "Mammography Density Abnormality",
                    "Mg Density Abnormality",
                    ObservationUrl,
                    $"{Group_MGResources}/AbnormalityDensity")
                .Description("Breat Radiology Mammography Density Abnormality Observation",
                    new Markdown()
                        .MissingObservation("a Density abnormality")
                        .Todo(
                            "should this be a leaf node (how about shape, density, location, etc).",
                            "default value? for refinement"
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment.Value())
                .AddFragRef(this.ObservationLeafFragment.Value())
                .AddFragRef(this.MGCommonTargetsFragment.Value())
                .AddFragRef(this.MGShapeTargetsFragment.Value())
                ;

            this.mgAbnormalityDensity = e.SDef.Url;
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
                .ObservationSection($"Density Abnormality")
                .Refinement(binding, "Density")
                ;
        }
    }
}
