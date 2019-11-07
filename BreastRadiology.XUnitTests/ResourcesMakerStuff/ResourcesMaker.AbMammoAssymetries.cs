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
        String AbMammoAssymetries()
        {
            String binding = this.CreateValueSet(
                "Assymetries",
                "Assymetries",
                new Markdown()
                    .Paragraph("Breast Radiology Mammography Assymetries"),
                new String[]
                {
                    "a. Diffuse",
                    "b. Regional",
                    "c. Grouped",
                    "d. Linear",
                    "e. Segmental"
                });

            return this.CreateAbnormalityCodedValue(
                    "BreastRadAbnormalityMammoAssymetries",
                    "Breast Radiology Abnormality Assymetries (Mammography)",
                    new Markdown().Paragraph("Mammography Breast Abnormality Assymetries Observation"),
                    binding)
                .ApplyBreastBodyLocation(this.breastBodyLocation, false)
                .SDef.Url;
        }
    }
}
