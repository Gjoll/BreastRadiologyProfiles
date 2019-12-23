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
        async StringTask MGAbnormalityFatNecrosis()
        {
            if (this.mgAbnormalityFatNecrosis == null)
                await this.CreateMGAbnormalityFatNecrosis();
            return this.mgAbnormalityFatNecrosis;
        }
        String mgAbnormalityFatNecrosis = null;

        async VTask CreateMGAbnormalityFatNecrosis()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityFatNecrosis",
                        "Mammography Fat Necrosis Abnormality",
                        "Mg Fat Necrosis Abnormality",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityFatNecrosis",
                        out this.mgAbnormalityFatNecrosis)
                    .Description("Breast Radiology Mammography Fat Necrosis Abnormality Observation",
                        new Markdown()
                            .Paragraph("Penrad")
                            .MissingObservation("a fat necrosis abnormality")
                            .Todo(
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationSectionFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    .AddFragRef(await this.ImagingStudyFragment())
                    .AddFragRef(await this.MGCommonTargetsFragment())
                    .AddFragRef(await this.MGShapeTargetsFragment())
                    ;

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
                    .ObservationSection("Mammography Fat Necrosis Abnormality")
                    ;
            });
        }
    }
}
