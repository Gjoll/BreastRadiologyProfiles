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

namespace FhirKhit.BreastRadiology.XUnitTests
{
    public partial class ResourcesMaker : ConverterBase
    {
        String SectionRoot(String patientHistoryUrl, 
            String findingsUrl,
            String patientRiskUrl)
        {
            return this.CreateObservationSection(
                "BreastRadSectionRoot",
                "Breast Radiology Root Section",
                new Markdown().Paragraph("Root Section"))
                .SliceByUrl("hasMember",
                new ObservationTarget[]
                    {
                        new ObservationTarget(patientHistoryUrl, 1, "1"),
                       new ObservationTarget(findingsUrl, 1, "1"),
                        new ObservationTarget(patientRiskUrl, 1, "1")
                    })
                .FixedCodeSlice("code", "observationCode", Loinc, "10193-1")
                .SDef.Url;
        }
    }
}
