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
        async StringTask MGAbnormalityDuct()
        {
            if (this.mgAbnormalityDuct == null)
                await this.CreateMGAbnormalityDuct();
            return this.mgAbnormalityDuct;
        }
        String mgAbnormalityDuct = null;

        CSTaskVar BreastRadMammoAbnormalityDuctCS = new CSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateCodeSystem(
                       "BreastRadMammoAbnormalityDuct",
                       "Mammography Duct Abnormality Refinement",
                        "Mg Duct Refinement/CodeSystem",
                       "Codes defining types of mammography duct abnormalities.",
                        Group_MGCodes,
                       new ConceptDef[]
                        {
                        new ConceptDef("Normal",
                            "Normal",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("Ectasia",
                            "Ectasia",
                            new Definition()
                                .Line("Penrad")
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
        async VTask CreateMGAbnormalityDuct()
        {
            await VTask.Run(async () =>
            {
                ValueSet binding = await this.CreateValueSet(
                   "BreastRadMammoAbnormalityDuct",
                   "Mammography Duct Abnormality",
                    "Mg Duct/ValueSet",
                   "Codes defining types of mammography duct node abnormalities.",
                    Group_MGCodes,
                    await BreastRadMammoAbnormalityDuctCS.Value());


                SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityDuct",
                        "Mammography Duct Abnormality",
                        "Mg Duct Abnormality",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityDuct",
                        out this.mgAbnormalityDuct)
                    .Description("Breat Radiology Mammography Duct Abnormality Observation",
                        new Markdown()
                            .MissingObservation("a duct abnormality")
                            .Todo(
                                "should this be a leaf node (how about shape, density, location, etc).",
                                "make dilated the default value."
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
                    .ObservationSection($"Duct Abnormality")
                    .Refinement(binding, "Duct")
                    ;
            });
        }
    }
}
