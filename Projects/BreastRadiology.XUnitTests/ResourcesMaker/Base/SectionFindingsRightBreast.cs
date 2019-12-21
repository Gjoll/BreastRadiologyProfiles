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
        public async StringTask SectionFindingsRightBreast()
        {
            if (this.sectionFindingsRightBreast == null)
            {
                await this.CreateSectionFindingsRightBreast();
            }
            return this.sectionFindingsRightBreast;
        }
        String sectionFindingsRightBreast = null;

        async VTask CreateSectionFindingsRightBreast()
        {
            await VTask.Run(async () =>
            {
               SDefEditor e = this.CreateEditor("BreastRadSectionFindingsRightBreast",
                       "Findings Right Breast",
                       "Right Breast",
                       ObservationUrl,
                       $"{Group_BaseResources}/Findings/RightBreast",
                       out this.sectionFindingsRightBreast)
                   .Description("Findings Right Breast Section",
                       new Markdown()
                       .Paragraph("This resource is the head of the tree of observations made of the right breast during a breast radiology exam.")
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
                    .ObservationSection($"Abnormality Right Breast Finding")
                    ;
            });
       }
    }
}
