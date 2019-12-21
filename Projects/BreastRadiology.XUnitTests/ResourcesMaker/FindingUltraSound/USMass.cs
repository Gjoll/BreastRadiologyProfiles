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
        async StringTask USMass()
        {
            if (this.usMass == null)
                await this.CreateUSMass();
            return this.usMass;
        }
        String usMass = null;

        async VTask CreateUSMass()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadUSMass",
                        "US Mass",
                        "US Mass",
                        ObservationUrl,
                        $"{Group_USResources}/Finding/Mass",
                        out this.usMass)
                    .Description("Breast Radiology Mammography Ultra-Sound Mass Observation",
                        new Markdown()
                            .MissingObservation("a mass", "and no Shape, Orientation, Margin, Echo Pattern, or Posterior Acoustic Feature observations should be referenced by this observation")
                            .BiradHeader()
                            .BlockQuote("A mass is three dimensional and occupies space. With 2-D ultrasound, it should be seen in two")
                            .BlockQuote("different planes, and in three planes with volumetric acquisitions. Masses can be distinguished")
                            .BlockQuote("from normal anatomic structures, such as ribs or fat lobules, using two or more projections and")
                            .BlockQuote("real-time scanning.")
                            .BiradFooter()
                            .Todo(
                                "add mass size measurements (3 dimensional) like US?",
                                "same for asymmetry, lesion, calcification?"
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
                    new ProfileTargetSlice(await this.CommonHilum(), 0, "1"),

                    new ProfileTargetSlice(await this.USBoundary(), 0, "1"),
                    new ProfileTargetSlice(await this.USEchoPattern(), 0, "1"),
                    new ProfileTargetSlice(await this.USElasticity(), 0, "1"),
                    new ProfileTargetSlice(await this.USMargin(), 0, "*"),
                    new ProfileTargetSlice(await this.USPosteriorAcousticFeatures(), 0, "1"),
                    new ProfileTargetSlice(await this.USShape(), 0, "1"),
                    new ProfileTargetSlice(await this.USVascularity(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Ultra-Sound Mass")
                    ;
            });
        }
    }
}
