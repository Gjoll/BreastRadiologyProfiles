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
        SDTaskVar PriorReportsExtension = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("PriorReportsExtension",
                    "Prior Reports Extension",
                    "Prior Reports/Extension",
                    ExtensionUrl,
                    $"{Group_ExtensionResources}/PriorReports",
                    "PriorReports")
                    .Description("Prior Diagnostic Report extension",
                        new Markdown()
                            .Paragraph("This extension defines the prior reports section of a breast radiology report, " +
                                       "linking a report to the resources that are the prior reports.")
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
                    .TypeReference(Self.BreastRadiologyReport.Value().Url)
                    .Single()
                    ;

                e.AddTargetLink(Self.BreastRadiologyReport.Value().Url, false);
            });
    }
}
