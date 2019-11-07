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
        String SectionFindingsLeftBreast(ObservationTarget[] abnormalityTargets)
        {
            return this.CreateObservationSection(
                "BreastRadSectionFindingsLeftBreast",
                "Breast Radiology Findings Left Breast",
                new Markdown().Paragraph("Findings Left Breast Section"))
                .SliceByUrl("hasMember", abnormalityTargets)
                .SDef.Url;
        }
    }
}
