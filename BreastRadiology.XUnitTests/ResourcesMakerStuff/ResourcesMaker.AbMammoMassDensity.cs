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
        String AbMammoMassDensity()
        {
            String binding = this.CreateValueSet(
                "BreastRadAbnormalityMammoMassDensity",
                "Breast Radiology Abnormality Mammography Mass Density",
                new Markdown()
                    .Paragraph("Breast Radiology Mass Density (Mammography)"),
                new String[]
                {
                        "a. High density",
                        "b. Equal density",
                        "c. Low density",
                        "d. Fat-containing"
                });

            return this.CreateAbnormalityCodedValue(
                "BreastRadAbnormalityMammoMassDensity",
                "Breast Radiology Abnormality Mass Density (Mammography)",
                new Markdown().Paragraph("Breast Radiology Abnormality Mass Density Observation (Mammography)"),
                binding)
                .SDef.Url;
        }
    }
}
