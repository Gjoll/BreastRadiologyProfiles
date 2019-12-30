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
        StringTaskVar BreastRadiologyPatientRiskExtension = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateEditor("PatientRiskExtension",
                    "PatientRisk Extension",
                    "PatientRisk/Extension",
                    ExtensionUrl,
                     $"{Group_ExtensionResources}/PatientRisk")
                    .Description("Patient Risk section extension",
                    new Markdown()
                        .Paragraph("This extension defines the PatientRisk section of a breast radiology report, " +
                                    "linking a report to the resources that are its PatientRisk.")
                        .Todo(
                            "Do we need a BreastRadiologyPatientRisk (Tyrer Cuzack, etc) Profile"
                        )
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Extension("PatientRisk", "include references to PatientRisk")
                    ;

                e.AddFragRef(Self.HeaderFragment.Value());

                e.Select("extension").Zero();
                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]")
                    .TypeReference(MedicationRequestUrl, ServiceRequestUrl)
                    .Single()
                    ;

                e.AddLink("target", RiskAssessmentUrl, false);
            });
    }
}
