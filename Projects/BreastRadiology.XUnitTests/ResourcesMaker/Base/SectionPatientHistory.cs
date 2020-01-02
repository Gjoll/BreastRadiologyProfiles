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
        StringTaskVar SectionPatientHistory = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateEditor("SectionPatientHistory",
                        "Patient History",
                        "Patient History",
                        ObservationUrl,
                        $"{Group_BaseResources}/PatientHistory")
                    .Description("Patient History Section",
                        new Markdown()
                        .Paragraph("This resource is the head of the tree of previous observations.")
                        .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                        .Todo(
                            "What resources comprise a patient history. Currently we can only reference observations - this is probably inadequate"
                            )
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationSectionFragment.Value())
                    ;
                s = e.SDef.Url;

                e.IntroDoc
                     .ObservationSection($"Patient History")
                     .ReviewedStatus(ReviewStatus.NotReviewed)
                     ;

                e.Select("value[x]").Zero();
                e.Select("bodySite").Zero();
            });
    }
}
