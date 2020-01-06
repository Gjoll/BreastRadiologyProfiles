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
        SDTaskVar BreastRadiologyRecommendationsExtension = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("RecommendationsExtension",
                    "Recommendations Extension",
                    "Recommendations/Extension",
                    ExtensionUrl,
                     $"{Group_ExtensionResources}/Recommendations",
                     "Recommendations")
                    .Description("Diagnostic Report recommendations section extension",
                    new Markdown()
                        .Paragraph("This extension defines the recommendations section of a breast radiology report, " +
                                    "linking a report to the resources that are its recommendations.")
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.AddFragRef(Self.HeaderFragment.Value().Url);

                e.Select("extension").Zero();
                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]")
                    .TypeReference(MedicationRequestUrl, ServiceRequestUrl)
                    .Single()
                    ;

                e.AddTargetLink(MedicationRequestUrl, false);
                e.AddTargetLink(ServiceRequestUrl, false);
            });
    }
}
