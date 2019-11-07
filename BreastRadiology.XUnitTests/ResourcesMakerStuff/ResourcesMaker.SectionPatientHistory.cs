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
        String SectionPatientHistory()
        {
            return this.CreateObservationSection(
                "BreastRadSectionPatientHistory",
                "Breast Radiology Patient History Section",
                new Markdown().Paragraph("Patient History Section"))
                .SDef.Url;
        }
    }
}
