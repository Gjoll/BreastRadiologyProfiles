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
        String MGAbnormalityFatNecrosis()
        {
            if (this.mgAbnormalityFatNecrosis == null)
                this.CreateMGAbnormalityFatNecrosis();
            return this.mgAbnormalityFatNecrosis;
        }
        String mgAbnormalityFatNecrosis = null;

        void CreateMGAbnormalityFatNecrosis()
        {
            SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityFatNecrosis",
                    "Mammography Fat Necrosis Abnormality",
                    "Mg Fat Necrosis Abnormality",
                    ObservationUrl,
                    $"{Group_MGResources}/AbnormalityFatNecrosis")
                .Description("Breast Radiology Mammography Fat Necrosis Abnormality Observation",
                    new Markdown()
                        .Paragraph("[PR]")
                        .MissingObservation("a fat necrosis abnormality")
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment.Value())
                .AddFragRef(this.ObservationSectionFragment.Value())
                .AddFragRef(this.ObservationNoValueFragment.Value())
                .AddFragRef(this.ImagingStudyFragment.Value())
                .AddFragRef(this.MGCommonTargetsFragment.Value())
                .AddFragRef(this.MGShapeTargetsFragment.Value())
                ;

            this.mgAbnormalityFatNecrosis = e.SDef.Url;
            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(this.CommonObservedCount(), 0, "1"),
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationSection("Mammography Fat Necrosis Abnormality")
                ;
        }
    }
}
