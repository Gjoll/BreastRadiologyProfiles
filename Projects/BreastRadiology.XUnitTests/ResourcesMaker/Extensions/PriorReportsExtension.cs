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
        String BreastRadiologyPriorReportsExtension()
        {
            if (this.breastRadiologyPriorReportsExtension == null)
                this.CreateBreastRadiologyPriorReportsExtension();
            return this.breastRadiologyPriorReportsExtension;
        }
        String breastRadiologyPriorReportsExtension = null;

        void CreateBreastRadiologyPriorReportsExtension()
        {
            SDefEditor e = this.CreateEditor("BreastRadPriorReportsExtension",
                "Prior Reports Extension",
                "Prior Reports/Extension",
                ExtensionUrl,
                $"{Group_ExtensionResources}/PriorReports",
                out this.breastRadiologyPriorReportsExtension)
                .Description("Prior Diagnostic Report extension",
                    new Markdown()
                        .Paragraph("This extension defines the prior reports section of a breast radiology report, " +
                                   "linking a report to the resources that are the prior reports.")
                        .Todo(
                        )
                )
                .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                .Context()
                ;
            e.AddFragRef(this.HeaderFragment());

            e.Select("extension").Zero();
            e.Select("url")
                .Type("uri")
                .Fixed(new FhirUri(e.SDef.Url));

            e.Select("value[x]")
                .TypeReference(this.BreastRadiologyReport())
                .Single()
                ;

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Extension("Prior Reports", "include references to prior reports")
                ;
            e.AddLink("target", this.BreastRadiologyReport(), false);
        }
    }
}
