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
        String AbMammoCalcificationDistribution()
        {
            String binding = this.CreateValueSet(
                "CalcificationDistribution",
                "Calcification Distribution",
                new Markdown()
                    .Paragraph("Mammography Calcification Distribution"),
                new String[]
                {
                        "a. Skin (Typically benign)",
                        "b. Vascular (Typically benign)",
                        "c. Coarse or 'popcorn-like' (Typically benign)",
                        "d. Large rod-like (Typically benign)",
                        "e. Round (Typically benign)",
                        "f. Rim (Typically benign)",
                        "g. Dystrophic (Typically benign)",
                        "h. Milk of calcium (Typically benign)",
                        "i. Suture (Typically benign)",

                        "a. Amorphous (Suspicious morphology)",
                        "b. Course heterogeneous (Suspicious morphology)",
                        "c. Fine pleomorphic (Suspicious morphology)",
                        "d. Fine linear or fine-linear branching (Suspicious morphology)"
                });

            return this.CreateAbnormalityCodedValue(
                "BreastRadAbnormalityMammoCalcificationDistribution",
                "Breast Radiology Abnormality Calcification Distribution (Mammography)",
                new Markdown().Paragraph("Mammography Breast Abnormality Calcification Distribution Observation"),
                binding)
                .SDef.Url;
        }
    }
}
