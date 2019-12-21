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
        public async StringTask SectionPatientHistory()
        {
            if (this.sectionPatientHistory == null)
            {
                await this.CreateSectionPatientHistory();
            }
            return this.sectionPatientHistory;
        }
        String sectionPatientHistory = null;

        async VTask CreateSectionPatientHistory()
        {
            await VTask.Run(async () =>
            {
               SDefEditor e = this.CreateEditor("BreastRadSectionPatientHistory",
                       "Patient History",
                       "Patient History",
                       ObservationUrl,
                       $"{Group_BaseResources}/PatientHistory",
                       out this.sectionPatientHistory)
                   .Description("Patient History Section",
                       new Markdown()
                       .Paragraph("This resource is the head of the tree of previous observations.")
                       .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                       .Todo(
                           "What resources comprise a patient history. Currently we can only reference observations - this is probably inadequate"
                           )
                   )
                   .AddFragRef(await this.ObservationNoDeviceFragment())
                   .AddFragRef(await this.ObservationSectionFragment())
                   .AddFragRef(await this.ObservationNoValueFragment())
                   ;
               e.Select("bodySite").Zero();

               e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Patient History")
                    ;
            });
        }
    }
}
