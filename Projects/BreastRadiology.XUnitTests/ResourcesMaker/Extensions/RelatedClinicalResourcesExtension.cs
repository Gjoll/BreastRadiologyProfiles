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
        SDTaskVar RelatedClinicalResourcesExtension = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("RelatedClinicalResourcesExtension",
                    "Related Clinical Resources Extension",
                    "RelatedClinicalResources/Extension",
                    ExtensionUrl,
                     $"{Group_ExtensionResources}/PatientRisk",
                     "Extension")
                    .Description("Related Clinical Resources section extension",
                    new Markdown()
                        .Paragraph("This extension defines the RelatedClinicalResources section of a breast radiology report, " +
                                    "linking a report to external resources that are referenced as part of the exam.")
                        .Paragraph("This resources include, but are not limited to:")
                        .List(
                            "Patient Risk Resources",
                            "Prir Breast Radiology Reports",
                            "Various Patient History Resources"
                            )
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("NOONE", "1.1.2020")
                    ;

                e.AddFragRef(Self.HeaderFragment.Value());

                e.Select("extension").Zero();
                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]")
                    .Type("Reference")
                    ;

                e.AddTargetLink(Self.BreastRadiologyReport.Value().Url,
                    new SDefEditor.Cardinality(0, "*"), 
                    false);
                e.AddTargetLink(RiskAssessmentUrl, 
                    new SDefEditor.Cardinality(0, "*"), 
                    false);
                e.AddTargetLink(DomainResourceUrl, 
                    new SDefEditor.Cardinality(0, "*"),
                    false);
            });
    }
}
