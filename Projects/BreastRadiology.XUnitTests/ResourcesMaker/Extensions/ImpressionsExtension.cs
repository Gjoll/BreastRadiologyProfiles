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
        SDTaskVar ImpressionsExtension = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("ImpressionsExtension",
                    "Impressions Extension",
                    "Impressions/Extension",
                    ExtensionUrl,
                    $"{Group_ExtensionResources}/Impressions",
                    "Extension")
                    .Description("Impressions extension",
                        new Markdown()
                            .Paragraph("This extension defines the impressions section of a breast radiology report.")
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;
                e.AddFragRef(Self.HeaderFragment.Value().Url);
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Intro(
                        "This extension adds fields to link a Breast Radiology Document to a series of clinical impressions."
                        )
                    ;

                e.Select("extension").Zero();
                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]")
                    .TypeReference(Self.BreastRadImpression.Value().Url)
                    .ZeroToMany()
                    ;

                e.AddTargetLink(ClinicalImpressionUrl, false);
            });
    }
}
