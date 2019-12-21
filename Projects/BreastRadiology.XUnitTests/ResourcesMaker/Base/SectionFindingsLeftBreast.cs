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
        public async StringTask SectionFindingsLeftBreast()
        {
            if (this.sectionFindingsLeftBreast == null)
            {
                await this.CreateSectionFindingsLeftBreast();
            }
            return this.sectionFindingsLeftBreast;
        }
        String sectionFindingsLeftBreast = null;

        async VTask CreateSectionFindingsLeftBreast()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadSectionFindingsLeftBreast",
                       "Findings Left Breast",
                       "Left Breast",
                       ObservationUrl,
                       $"{Group_BaseResources}/Findings/LeftBreast",
                       out this.sectionFindingsLeftBreast)
                   .Description("Findings Left Breast Section",
                       new Markdown()
                       .Paragraph("This resource is the head of the tree of observations made of the left breast during a breast radiology exam.")
                       .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                       .Todo(
                       )
                   )
                   .AddFragRef(await this.ObservationNoDeviceFragment())
                   .AddFragRef(await this.ObservationSectionFragment())
                   .AddFragRef(await this.ObservationNoValueFragment())
                   ;
                e.Select("bodySite").Zero();
                e.Find("hasMember").SliceByUrl(await this.FindingBreastTargets());
                e.AddProfileTargets(await this.FindingBreastTargets());

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Abnormality Left Breast Finding")
                    ;
            });
        }
    }
}
