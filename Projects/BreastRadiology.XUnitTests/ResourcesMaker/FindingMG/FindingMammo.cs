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
                        "Mammo Finding",
                        "Mammo/Finding",
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
                ////$ todo. Incorrect method!!!
                //e.Find("method")
                // .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                // .Card(1, "*")
                // ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.CommonForeignObject(), 0, "*"),
                    new ProfileTargetSlice(await this.MGArchitecturalDistortion(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAsymmetries(), 0, "*"),
                    new ProfileTargetSlice(await this.MGBreastDensity(), 1, "1"),
                    new ProfileTargetSlice(await this.MGCalcification(), 0, "*"),
                    new ProfileTargetSlice(await this.MGCyst(), 0, "*"),
                    new ProfileTargetSlice(await this.MGFatNecrosis(), 0, "*"),
                    new ProfileTargetSlice(await this.MGIntramammaryLymphNode(), 0, "*"),
                    new ProfileTargetSlice(await this.MGMass(), 0, "*"),
                    new ProfileTargetSlice(await this.MGSkinLesion(), 0, "*"),
                    new ProfileTargetSlice(await this.MGSolitaryDilatedDuct(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAssociatedFeatures(), 0, "*")
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