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
        StringTaskVar BreastRadImpression = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateEditor("Impression",
                        "Impression",
                        "Impression",
                        ClinicalImpressionUrl,
                        $"{Group_CommonResources}/BreastRadImpression")
                    .Description("Breast Radiology Impression (ClinicalImpression)",
                        new Markdown()
                            .Paragraph("Breast radiology exam clinical impression")
                            //.Todo
                    )
                    .AddFragRef(Self.HeaderFragment.Value())
                    ;

                s = e.SDef.Url;
                e.IntroDoc
                    .IntroGeneral($"Breast Radiology Impressions Resource")
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
            });
    }
}
