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
        SDTaskVar BreastRadiologyReport = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("BreastRadReport",
                     "Breast Radiology Report",
                     "Breast/Radiology/Report",
                     DiagnosticReportUrl,
                     Group_BaseResources,
                     "BreastRadiologyReport")
                     .Description("Breast Radiology Diagnostic Report",
                         new Markdown()
                             .Paragraph("This diagnostic report has links to the data that comprise a Breast Radiology Report, including:")
                             .List("references to prior breast radiology reports for this patient",
                                   "references to the observations of this report",
                                   "references to the recommendations of this report",
                                   "a summary of the report findings in a human readable format")
                     )
                     .AddFragRef(Self.HeaderFragment.Value().Url)
                     .AddFragRef(Self.CategoryFragment.Value().Url)
                     ;

                s = e.SDef;
                e.IntroDoc
                     .ReviewedStatus(ReviewStatus.NotReviewed)
                     ;

                e.Select("code").Pattern = new CodeableConcept(Loinc, "10193-1");
                e.Select("specimen").Zero();
                e.Select("conclusion").Single();
                e.Select("conclusionCode").Single();
                e.ApplyExtension("Recommendations", Self.RecommendationsExtension.Value().Url)
                     .Short("Recommendations for future care")
                     .Definition("Recommendations for future care")
                     .ZeroToMany();
                e.ApplyExtension("PriorReports", Self.PriorReportsExtension.Value().Url)
                     .Short("Prior breast radiology reports")
                     .Definition("Prior breast radiology reports")
                     .ZeroToMany();
                e.ApplyExtension("Impressions", Self.ImpressionsExtension.Value().Url)
                     .Short("Exam impressions")
                     .Definition("Exam impressions.")
                     .ZeroToMany();
                e.ApplyExtension("PatientRisk", Self.PatientRiskExtension.Value().Url)
                     .Short("Patient Risk")
                     .Definition("Patient Risk.")
                     .ZeroToMany();

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("result", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.SectionFindings.Value(), 1, "1");
                Self.SliceTargetReference(e, sliceElementDef, Self.SectionPatientHistory.Value(), 1, "1");
            });
    }
}
