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
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        async StringTask BreastRadImpression()
        {
            if (this.breastRadImpression == null)
                await this.CreateBreastRadImpression();
            return this.breastRadImpression;
        }
        String breastRadImpression = null;

        async VTask CreateBreastRadImpression()
        {
            SDefEditor e = this.CreateEditor("BreastRadImpression",
                    "Impression",
                    "Impression",
                    ClinicalImpressionUrl,
                    $"{Group_CommonResources}/BreastRadImpression",
                    out this.breastRadImpression)
                .Description("Breast Radiology Impression (ClinicalImpression)",
                    new Markdown()
                        .Paragraph("Breast radiology exam clinical impression")
                        .Todo(
                        )
                )
                .AddFragRef(await this.HeaderFragment())
                ;

            e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
        }
    }
}
