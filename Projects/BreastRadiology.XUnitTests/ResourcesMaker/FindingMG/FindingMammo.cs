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
        async StringTask FindingMammo()
        {
            if (this.findingMammo == null)
                await this.CreateFindingMammo();
            return this.findingMammo;
        }
        String findingMammo = null;

        async VTask CreateFindingMammo()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoFinding",
                        "Mammographi Finding",
                        "Mg Finding",
                        ObservationUrl,
                        $"{Group_MGResources}",
                        out this.findingMammo)
                    .Description("Breast Radiology Mammography Finding",
                        new Markdown()
                            .Todo(
                                "Device Metrics detailing the observation devices parameters (transducer freq, etc)."
                                )
                        )
                    .AddFragRef(await this.ObservationSectionFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    ;
                e.Select("value[x]").Zero();
                ////$ todo. Incorrect method!!!
                //e.Find("method")
                // .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                // .Card(1, "*")
                // ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.CommonAbnormalityForeignObject(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAbnormalityArchitecturalDistortion(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAbnormalityAsymmetry(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAbnormalityCalcification(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAbnormalityCyst(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAbnormalityDensity(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAbnormalityDuct(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAbnormalityFatNecrosis(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAbnormalityFibroadenoma(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAbnormalityLymphNode(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAbnormalityMass(), 0, "*"),
                    new ProfileTargetSlice(await this.MGSkinLesion(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAssociatedFeatures(), 0, "*"),
                    new ProfileTargetSlice(await this.MGBreastDensity(), 1, "1")
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("MRI Abnormality")
                    ;
            });
        }
    }
}