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
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        async StringTask MGAbnormalityDensity()
        {
            if (this.mgAbnormalityDensity == null)
                await this.CreateMGAbnormalityDensity();
            return this.mgAbnormalityDensity;
        }
        String mgAbnormalityDensity = null;

        async VTask CreateMGAbnormalityDensity()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs = await this.CreateCodeSystem(
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
                                .Line("Penrad")
                            ),
                        new ConceptDef("Nodular",
                            "Nodular",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("Tubular",
                            "Tubular",
                            new Definition()
                                .Line("Penrad")
                            )
                        }
                    );

                ValueSet binding = await this.CreateValueSet(
                   "BreastRadMammoAbnormalityDensity",
                   "Mammography Density Abnormality",
                    "Mg Density/ValueSet",
                   "Codes defining types of mammography density abnormalities.",
                    Group_MGCodes,
                    cs);


                SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityDensity",
                        "Mammography Density Abnormality",
                        "Mg Density Abnormality",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityDensity",
                        out this.mgAbnormalityDensity)
                    .Description("Breat Radiology Mammography Density Abnormality Observation",
                        new Markdown()
                            .MissingObservation("a Density abnormality")
                            .Todo(
                                "should this be a leaf node (how about shape, density, location, etc).",
                                "default value? for refinement"
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationLeafFragment())
                    .AddFragRef(await this.MGCommonTargetsFragment())
                    .AddFragRef(await this.MGShapeTargetsFragment())
                    ;

                e.Select("value[x]")
                    .ZeroToOne()
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.CommonObservedCount(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Density Abnormality")
                    .Refinement(binding, "Density")
                    ;
            });
        }
    }
}
