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
        String AbMammoSolitaryDilatedDuct()
        {
            String binding = this.CreateValueSet(
                "BreastRadAbnormalityMammoSolitaryDilatedDuctFindings",
                "Breast Radiology Abnormality Solitary Dilated Duct Findings (Mammo)",
                new Markdown()
                    .Paragraph("Breast Radiology Abnormality Solitary Dilated Duct Findings"),
                new String[]
                {
                "a. Present",
                "b. NotPresent",
                "c. NotChecked"
                });

            return this.CreateAbnormalityCodedValue(
                    "BreastRadAbnormalityMammoSolitaryDilatedDuct",
                    "Breast Radiology Abnormality Solitary Dilated Duct (Mammography)",
                    new Markdown().Paragraph("Mammography Breast Abnormality Solitary Dilated Duct Observation"),
                    binding)
                .ApplyBreastBodyLocation(this.breastBodyLocation, true)
                .SDef.Url;
        }
    }
}
