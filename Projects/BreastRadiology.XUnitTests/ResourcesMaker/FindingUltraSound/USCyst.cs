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
        async StringTask USCyst()
        {
            if (this.usCyst == null)
                await this.CreateUSCyst();
            return this.usCyst;
        }
        String usCyst = null;

        async VTask CreateUSCyst()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadUltraSoundCyst",
                        "UltraSound Cyst",
                        "UltraSound/Cyst",
                        ObservationUrl,
                        $"{Group_USResources}/Cyst",
                        out this.usCyst)
                    .Description("Breast Radiology UltraSound Cyst Observation",
                        new Markdown()
                            .Paragraph("Penrad")
                            .MissingObservation("a cyst")
                            .Todo(
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    .AddFragRef(await this.ObservationSectionFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    .AddFragRef(await this.ImagingStudyFragment())
                    ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.BiRadsAssessmentCategory(), 0, "1"),

                    new ProfileTargetSlice(await this.CommonObservedCount(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonObservedChanges(), 0, "*"),
                    new ProfileTargetSlice(await this.CommonObservedSize(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonOrientation(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonObservedState(), 0, "*"),

                    //new ProfileTargetSlice(await this.MGMassMargin(), 0, "*"),
                    //new ProfileTargetSlice(await this.MGMassDensity(), 0, "1"),
                    //new ProfileTargetSlice(await this.MGAssociatedFeatures(), 0, "1", false),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("UltraSound Cyst")
                    ;
            });
        }
    }
}
