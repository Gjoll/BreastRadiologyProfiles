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
                     "Resource")
                     .Description("Breast Radiology Diagnostic Report",
                         new Markdown()
                             .Paragraph("This resource is the base resource of the Breast Diagnostic Report.",
                             "All components of this report are stored in or referenced by this fhir instance.")
                             .Paragraph("This resource is a profile of the Fhir DiagnosticReport base resource.")
                             .Paragraph("Items referenced by this resource include:")
                             .List("references to prior breast radiology reports for this patient",
                                   "references to the observations of this report",
                                   "references to the recommendations of this report",
                                   "a summary of the report findings in a human readable format")
                     )
                     .AddFragRef(Self.HeaderFragment.Value())
                     .AddFragRef(Self.CategoryFragment.Value())
                     ;

                s = e.SDef;
                e.IntroDoc
                     .ReviewedStatus(ReviewStatus.NotReviewed)
                     ;

                e.Select("code").Pattern = new CodeableConcept(Loinc, "10193-1");
                e.Select("specimen").Zero();
                e.Select("conclusion").Single();
                e.Select("conclusionCode").Single();
                e.ApplyExtension("Recommendations", Self.RecommendationsExtension.Value())
                     .Short("Recommendations for future care")
                     .Definition("Recommendations for future care")
                     .ZeroToMany();
                e.ApplyExtension("Impressions", Self.ImpressionsExtension.Value())
                     .Short("Exam impressions")
                     .Definition("Exam impressions.")
                     .ZeroToMany();
                e.ApplyExtension("Related", Self.RelatedClinicalResourcesExtension.Value())
                     .Short("Related Clinical Resources")
                     .Definition("References to FHIR clinical resoruces used during the exam or referenced by this report.")
                     .ZeroToMany();

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("result", false);
                {
                    ElementTreeSlice slice = Self.SliceTargetReference(e, sliceElementDef, Self.SectionFindings.Value(), 1, "1");
                    slice.ElementDefinition.MustSupport = true;
                }
            });
    }
}
