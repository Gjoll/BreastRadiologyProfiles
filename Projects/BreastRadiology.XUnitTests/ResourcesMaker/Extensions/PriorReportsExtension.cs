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
        StringTaskVar BreastRadiologyPriorReportsExtension = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateEditor("PriorReportsExtension",
                    "Prior Reports Extension",
                    "Prior Reports/Extension",
                    ExtensionUrl,
                    $"{Group_ExtensionResources}/PriorReports")
                    .Description("Prior Diagnostic Report extension",
                        new Markdown()
                            .Paragraph("This extension defines the prior reports section of a breast radiology report, " +
                                       "linking a report to the resources that are the prior reports.")
                            //.Todo
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Extension("Prior Reports", "include references to prior reports")
                    ;

                e.AddFragRef(Self.HeaderFragment.Value());

                e.Select("extension").Zero();
                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]")
                    .TypeReference(Self.BreastRadiologyReport.Value())
                    .Single()
                    ;

                e.AddLink("target", Self.BreastRadiologyReport.Value(), false);
            });
    }
}
