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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        String USCyst()
        {
            if (this.usCyst == null)
                this.CreateUSCyst();
            return this.usCyst;
        }
        String usCyst = null;

        void CreateUSCyst()
        {
            SDefEditor e = this.CreateEditor("BreastRadUltraSoundCyst",
                    "UltraSound Cyst",
                    "US Cyst",
                    ObservationUrl,
                    $"{Group_USResources}/Cyst")
                .Description("Breast Radiology UltraSound Cyst Observation",
                    new Markdown()
                        .Paragraph("[PR]")
                        .MissingObservation("a cyst")
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.BreastBodyLocationRequiredFragment())
                .AddFragRef(this.ObservationSectionFragment())
                .AddFragRef(this.ObservationNoValueFragment())
                .AddFragRef(this.ImagingStudyFragment())
                ;
            this.usCyst = e.SDef.Url;

            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(this.BiRadsAssessmentCategory(), 0, "1"),

                    new ProfileTargetSlice(this.CommonObservedCount(), 0, "1"),
                    new ProfileTargetSlice(this.CommonObservedChangeInState(), 0, "*"),
                    new ProfileTargetSlice(this.CommonObservedSize(), 0, "1"),
                    new ProfileTargetSlice(this.CommonOrientation(), 0, "1"),

                    //new ProfileTargetSlice(this.MGMassMargin(), 0, "*"),
                    //new ProfileTargetSlice(this.MGMassDensity(), 0, "1"),
                    //new ProfileTargetSlice(this.MGAssociatedFeatures(), 0, "1", false),
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationSection("UltraSound Cyst")
                ;
        }
    }
}
