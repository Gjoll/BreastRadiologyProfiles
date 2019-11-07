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
        String SectionPatientRisk()
        {
            return this.CreateObservationSection(
                "BreastRadSectionPatientRisk",
                "Breast Radiology Patient Risk Section",
                new Markdown().Paragraph("Patient Risk Section"))
                .SDef.Url;
        }
    }
}
