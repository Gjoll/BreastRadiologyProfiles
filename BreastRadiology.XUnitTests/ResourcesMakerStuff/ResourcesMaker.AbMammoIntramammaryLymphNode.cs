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
        String AbMammoIntramammaryLymphNode()
        {
            String binding = this.CreateValueSet(
                "BreastRadAbnormalityMammoIntramammaryLymphNodeFindings",
                "Breast Radiology Abnormality Intramammary LymphNode Findings (Mammo)",
                new Markdown()
                    .Paragraph("Breast Radiology Abnormality Intramammary LymphNode Findings"),
                new String[]
                {
                "a. Present",
                "b. NotPresent",
                "c. NotChecked"
                });

            return this.CreateAbnormalityCodedValue(
                    "BreastRadAbnormalityMammoIntramammaryLymphNode",
                    "Breast Radiology Abnormality Intramammary LymphNode (Mammography)",
                    new Markdown().Paragraph("Mammography Breast Intramammary LymphNode Distortion Observation"),
                    binding)
                .ApplyBreastBodyLocation(this.breastBodyLocation, true)
                .SDef.Url;
        }
    }
}
