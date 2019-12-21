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
        public async StringTask SectionFindings()
        {
            if (this.sectionFindings == null)
            {
                await this.CreateSectionFindings();
            }
            return this.sectionFindings;
        }
        String sectionFindings = null;

        async VTask CreateSectionFindings()
        {
            await VTask.Run( async () =>
           {
               SDefEditor e = this.CreateEditor("BreastRadSectionFindings",
                       "Findings",
                       "Findings",
                       ObservationUrl,
                       $"{Group_BaseResources}/Findings",
                       out this.sectionFindings)
                   .Description("Findings Section",
                       new Markdown()
                       .Paragraph("This resource is the head of the tree of observations made during a breast radiology exam.")
                       .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                       .Todo(
                       )
                   )
                   .AddFragRef(await this.ObservationNoDeviceFragment())
                   .AddFragRef(await this.ObservationSectionFragment())
                   .AddFragRef(await this.ObservationNoValueFragment())
                   ;

               e.Select("bodySite").Zero();
               {
                   ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                   {
                    new ProfileTargetSlice(await this.BiRadsAssessmentCategory(), 1, "1"),
                    new ProfileTargetSlice(await this.SectionFindingsLeftBreast(), 1, "1"),
                    new ProfileTargetSlice(await this.SectionFindingsRightBreast(), 1, "1")
                   };
                   e.Find("hasMember").SliceByUrl(targets);
                   e.AddProfileTargets(targets);
               }

               e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationSection($"Abnormality Finding")
                ;
           });
        }
    }
}
