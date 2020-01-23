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
using PreFhir;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        SDTaskVar BreastRadImpression = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("Impression",
                        "Impression",
                        "Impression",
                        ClinicalImpressionUrl,
                        $"{Group_CommonResources}/BreastRadImpression",
                        "Resource")
                    .Description("Impression (ClinicalImpression)",
                        new Markdown()
                            .Paragraph("Clinical Impression")
                    )
                    .AddFragRef(Self.HeaderFragment.Value())
                    ;

                s = e.SDef;
                e.IntroDoc
                    .ReviewedStatus("NOONE", "1.1.2020")
                    ;
            });
    }
}
