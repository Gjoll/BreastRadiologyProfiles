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
        public String SectionFindings()
        {
            if (this.sectionFindings == null)
            {
                this.CreateSectionFindings();
            }
            return this.sectionFindings;
        }
        String sectionFindings = null;

        void CreateSectionFindings()
        {
            SDefEditor e = this.CreateEditor("BreastRadSectionFindings",
                    "Findings",
                    "Findings",
                    ObservationUrl,
                    $"{Group_BaseResources}/Findings")
                .Description("Findings Section",
                    new Markdown()
                    .Paragraph("This resource is the head of the tree of observations made during a breast radiology exam.")
                    .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                    .Todo(
                    )
                )
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationSectionFragment())
                .AddFragRef(this.ObservationNoValueFragment())
                ;

            this.sectionFindings = e.SDef.Url;
            e.Select("value[x]").Zero();
            e.Select("bodySite").Zero();
            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(this.BiRadsAssessmentCategory(), 1, "1"),
                    new ProfileTargetSlice(this.SectionFindingsLeftBreast(), 1, "1"),
                    new ProfileTargetSlice(this.SectionFindingsRightBreast(), 1, "1")
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }

            e.IntroDoc
             .ReviewedStatus(ReviewStatus.NotReviewed)
             .ObservationSection($"Abnormality Finding")
             ;
        }
    }
}
