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
        async StringTask MGAbnormalityCyst()
        {
            if (this.mgAbnormalityCyst == null)
                await this.CreateMGAbnormalityCyst();
            return this.mgAbnormalityCyst;
        }
        String mgAbnormalityCyst = null;

        async VTask CreateMGAbnormalityCyst()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityCyst",
                        "Mammography Cyst Abnormality",
                        "Mg Cyst Abnormality",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityCyst",
                        out this.mgAbnormalityCyst)
                    .Description("Breast Radiology Mammography Cyst Abnormality Observation",
                        new Markdown()
                            .Paragraph("Penrad")
                            .MissingObservation("a cyst")
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
                    //new ProfileTargetSlice(await this.MGAssociatedFeatures(), 0, "1", false),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Mammography Cyst Abnormality")
                    ;
            });
        }
    }
}
