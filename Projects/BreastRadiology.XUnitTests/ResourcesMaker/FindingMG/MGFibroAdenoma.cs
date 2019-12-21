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
        async StringTask MGFibroadenoma()
        {
            if (this.mgFibroadenoma == null)
                await this.CreateMGFibroadenoma();
            return this.mgFibroadenoma;
        }
        String mgFibroadenoma = null;

        async VTask CreateMGFibroadenoma()
        {
            await VTask.Run(async () =>
            {
                ValueSet binding = await this.CreateValueSet(
                        "MammoFibroadenoma",
                        "Fibroadenoma",
                        "Fibroadenoma/Values",
                        "Codes defining Fibroadenoma values.",
                        Group_CommonCodes,
                        await this.CommonCSFibroadenoma());

                SDefEditor e = this.CreateEditor("BreastRadMammoFibroadenoma",
                        "Mammo Fibroadenoma",
                        "Mammo/Fibroadenoma",
                        ObservationUrl,
                        $"{Group_MGResources}/Fibroadenoma",
                        out this.mgFibroadenoma)
                    .Description("Breast Radiology Mammography Fibroadenoma Observation",
                        new Markdown()
                            .Paragraph("Penrad")
                            .MissingObservation("a Fibroadenoma")
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

                    new ProfileTargetSlice(await this.MGShape(), 0, "1"),
                    };

                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Mammography Fibroadenoma")
                    ;
            });
        }
    }
}
