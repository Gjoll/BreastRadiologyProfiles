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
    partial class ResourcesMaker : ConverterBase
    {
        String BreastRadiologyImpressionsExtension()
        {
            if (this.breastRadiologyImpressionsExtension == null)
                this.CreateBreastRadiologyImpressionsExtension();
            return this.breastRadiologyImpressionsExtension;
        }
        String breastRadiologyImpressionsExtension = null;

        void CreateBreastRadiologyImpressionsExtension()
        {
            SDefEditor e = this.CreateEditor("BreastRadImpressionsExtension",
                "Impressions Extension",
                "Impressions/Extension",
                ExtensionUrl,
                $"{Group_ExtensionResources}/Impressions")
                .Description("Impressions extension",
                    new Markdown()
                        .Paragraph("This extension defines the impressions section of a breast radiology report, " +
                                   "linking a report to the resources that the exam impressions.")
                        .Todo(
                        )
                )
                .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                .Context()
                ;
            e.AddFragRef(this.HeaderFragment.Value());
            this.breastRadiologyImpressionsExtension = e.SDef.Url;

            e.Select("extension").Zero();
            e.Select("url")
                .Type("uri")
                .Fixed(new FhirUri(e.SDef.Url));

            e.Select("value[x]")
                .TypeReference(this.BreastRadImpression())
                .ZeroToMany()
                ;

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Extension("Prior Reports", "include references to prior reports")
                ;

            e.AddLink("target", ClinicalImpressionUrl, false);
        }
    }
}
