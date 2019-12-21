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
        async StringTask FindingMri()
        {
            if (this.findingMri == null)
                await this.CreateFindingMri();
            return this.findingMri;
        }
        String findingMri = null;

        async VTask CreateFindingMri()
        {
            await VTask.Run(async () =>
            {
                //$ Fix me. Incorrect method!!!
                SDefEditor e = this.CreateEditor("BreastRadMRIFinding",
                        "MRI Finding",
                        "MRI/Finding",
                        ObservationUrl,
                        $"{Group_MRIResources}",
                        out this.findingMri)
                    .Description("Breast Radiology MRI Finding",
                        new Markdown()
                            .Todo(
                                "Device Metrics detailing the observation devices parameters.",
                                "Add information about contrast enhancement/other observation specific parameters."
                            )
                    )
                    .AddFragRef(await this.ObservationSectionFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    //new ProfileTargetSlice(await this.MGArchitecturalDistortion(), 0, "1"),
                    //new ProfileTargetSlice(await this.MGAsymmetries(), 0, "*"),
                    //new ProfileTargetSlice(await this.MGBreastDensity(), 1, "1"),
                    //new ProfileTargetSlice(await this.MGCalcification(), 0, "*"),
                    new ProfileTargetSlice(await this.CommonForeignObject(), 0, "*"),
                    //new ProfileTargetSlice(await this.MGIntramammaryLymphNode(), 0, "1"),
                    new ProfileTargetSlice(await this.MRIMass(), 0, "*"),
                    //new ProfileTargetSlice(await this.MGSkinLesion(), 0, "*"),
                    //new ProfileTargetSlice(await this.MGSolitaryDilatedDuct(), 0, "1"),
                    //new ProfileTargetSlice(await this.MGAssociatedFeatures(), 0, "1")
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("MRI Abnormality")
                    ;
                //$e.Find("method")
                //$     .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                //$     .Card(1, "*")
                //$     ;
            });
        }
    }
}
