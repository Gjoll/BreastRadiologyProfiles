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
        public String SectionFindingsRightBreast()
        {
            if (this.sectionFindingsRightBreast == null)
            {
                this.CreateSectionFindingsRightBreast();
            }
            return this.sectionFindingsRightBreast;
        }
        String sectionFindingsRightBreast = null;

        void CreateSectionFindingsRightBreast()
        {
            SDefEditor e = this.CreateEditor("BreastRadSectionFindingsRightBreast",
                    "Findings Right Breast",
                    "Right Breast",
                    ObservationUrl,
                    $"{Group_BaseResources}/Findings/RightBreast")
                .Description("Findings Right Breast Section",
                    new Markdown()
                    .Paragraph("This resource is the head of the tree of observations made of the right breast during a breast radiology exam.")
                    .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                    .Todo(
                    )
                )
                .AddFragRef(this.ObservationNoDeviceFragment.Value())
                .AddFragRef(this.ObservationSectionFragment.Value())
                .AddFragRef(this.ObservationNoValueFragment.Value())
                ;
            this.sectionFindingsRightBreast = e.SDef.Url;
            e.Select("value[x]").Zero();
            e.Select("bodySite").Zero();
            e.Find("hasMember").SliceByUrl(this.FindingBreastTargets());
            e.AddProfileTargets(this.FindingBreastTargets());

            e.IntroDoc
                 .ReviewedStatus(ReviewStatus.NotReviewed)
                 .ObservationSection($"Abnormality Right Breast Finding")
                 ;
        }
    }
}
