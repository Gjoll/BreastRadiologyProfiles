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
        async StringTask FindingNM()
        {
            if (this.findingNM == null)
                await this.CreateFindingNM();
            return this.findingNM;
        }
        String findingNM = null;

        async VTask CreateFindingNM()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadNMFinding",
                        "NM Finding",
                        "NM/Finding",
                        ObservationUrl,
                        $"{Group_NMResources}",
                        out this.findingNM)
                    .Description("Breast Radiology NMgraphy Finding",
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
                    //new ProfileTargetSlice(await this.NMBreastDensity(), 1, "1"),
                    new ProfileTargetSlice(await this.NMMass(), 0, "*"),
                    //new ProfileTargetSlice(await this.NMCalcification(), 0, "*"),
                    //new ProfileTargetSlice(await this.NMArchitecturalDistortion(), 0, "1"),
                    //new ProfileTargetSlice(await this.NMAsymmetries(), 0, "*"),
                    //new ProfileTargetSlice(await this.NMIntramammaryLymphNode(), 0, "1"),
                    //new ProfileTargetSlice(await this.NMSkinLesion(), 0, "*"),
                    //new ProfileTargetSlice(await this.NMSolitaryDilatedDuct(), 0, "1"),
                    //new ProfileTargetSlice(await this.NMAssociatedFeatures(), 0, "1")
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