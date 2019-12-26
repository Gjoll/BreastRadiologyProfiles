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
        String BreastRadImpression()
        {
            if (this.breastRadImpression == null)
                this.CreateBreastRadImpression();
            return this.breastRadImpression;
        }
        String breastRadImpression = null;

        void CreateBreastRadImpression()
        {
            SDefEditor e = this.CreateEditor("BreastRadImpression",
                    "Impression",
                    "Impression",
                    ClinicalImpressionUrl,
                    $"{Group_CommonResources}/BreastRadImpression")
                .Description("Breast Radiology Impression (ClinicalImpression)",
                    new Markdown()
                        .Paragraph("Breast radiology exam clinical impression")
                        .Todo(
                        )
                )
                .AddFragRef(this.HeaderFragment.Value())
                ;

            this.breastRadImpression = e.SDef.Url;
            e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
        }
    }
}
