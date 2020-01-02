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
        StringTaskVar BreastRadiologyImpressionsExtension = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateEditor("ImpressionsExtension",
                    "Impressions Extension",
                    "Impressions/Extension",
                    ExtensionUrl,
                    $"{Group_ExtensionResources}/Impressions")
                    .Description("Impressions extension",
                        new Markdown()
                            .Paragraph("This extension defines the impressions section of a breast radiology report, " +
                                       "linking a report to the resources that the exam impressions.")
                            //.Todo
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;
                e.AddFragRef(Self.HeaderFragment.Value());
                s = e.SDef.Url;

                e.IntroDoc
                    .IntroExtension("Prior Reports", "include references to prior reports")
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("extension").Zero();
                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]")
                    .TypeReference(Self.BreastRadImpression.Value())
                    .ZeroToMany()
                    ;

                e.AddTargetLink(ClinicalImpressionUrl, false);
            });
    }
}
