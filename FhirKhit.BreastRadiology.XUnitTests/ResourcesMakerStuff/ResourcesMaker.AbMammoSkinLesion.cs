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
        String AbMammoSkinLesion()
        {
            String binding = this.CreateValueSet(
                "BreastRadAbnormalityMammoSkinLesionFindings",
                "Breast Radiology Abnormality Skin Lesion Findings (Mammo)",
                new Markdown()
                    .Paragraph("Breast Radiology Abnormality Skin Lesion Findings"),
                new String[]
                {
                "a. Present",
                "b. NotPresent",
                "c. NotChecked"
                });

            return this.CreateAbnormalityCodedValue(
                    "BreastRadAbnormalityMammoSkinLesion",
                    "Breast Radiology Abnormality Skin Lesion (Mammography)",
                    new Markdown().Paragraph("Mammography Breast Abnormality Skin Lesion Observation"),
                    binding)
                .ApplyBreastBodyLocation(this.breastBodyLocation, true)
                .SDef.Url;
        }
    }
}
