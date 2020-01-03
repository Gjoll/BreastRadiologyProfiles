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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        StringTaskVar BreastRadiologyReport = new StringTaskVar(
            (out String s) =>
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
                     //.Todo
                     )
                     .AddFragRef(Self.HeaderFragment.Value())
                     .AddFragRef(Self.CategoryFragment.Value())
                     ;

                s = e.SDef.Url;
                //$e.IntroDoc
                //     .Paragraph(
                //         $"This resource is the base of the Breast Radiology Report.",
                //         $"Detailed information about the report is contained in sub sections referenced by this resource."
                //         );

                e.Select("code").Pattern = new CodeableConcept(Loinc, "10193-1");
                e.Select("specimen").Zero();
                e.Select("conclusion").Single();
                e.Select("conclusionCode").Single();
                e.ApplyExtension("Recommendations", Self.BreastRadiologyRecommendationsExtension.Value())
                     .Short("Recommendations for future care")
                     .Definition("Recommendations for future care")
                     .ZeroToMany();
                e.ApplyExtension("PriorReports", Self.BreastRadiologyPriorReportsExtension.Value())
                     .Short("Prior breast radiology reports")
                     .Definition("Prior breast radiology reports")
                     .ZeroToMany();
                e.ApplyExtension("Impressions", Self.BreastRadiologyImpressionsExtension.Value())
                     .Short("Exam impressions")
                     .Definition("Exam impressions.")
                     .ZeroToMany();
                e.ApplyExtension("PatientRisk", Self.BreastRadiologyPatientRiskExtension.Value())
                     .Short("Patient Risk")
                     .Definition("Patient Risk.")
                     .ZeroToMany();

                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                        new ProfileTargetSlice(Self.SectionPatientHistory.Value(), 1, "1"),
                        new ProfileTargetSlice(Self.SectionFindings.Value(), 1, "1"),
                };
                e.SliceByUrl("result", targets);
                e.AddProfileTargets(targets);
            });
    }
}
