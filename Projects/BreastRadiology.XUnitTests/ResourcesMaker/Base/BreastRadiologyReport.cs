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
                             .List("Prior breast radiology reports for this patient",
                                   "Left breast findings",
                                   "Right breast findings",
                                   "Recommendations of this report",
                                   "Report findings in a human readable format")
                     )
                     .AddFragRef(Self.HeaderFragment.Value())
                     .AddFragRef(Self.CategoryFragment.Value())
                     ;

                s = e.SDef;
                e.IntroDoc
                     .ReviewedStatus(ReviewStatus.Alpha)
                     ;

                e.Select("code").Pattern = new CodeableConcept(Loinc, "10193-1");
                e.Select("specimen").Zero();
                e.Select("conclusion").Single();
                e.Select("conclusionCode").Single();
                {
                    ElementDefinition extensionDef = e.ApplyExtension("Impressions", Self.ImpressionsExtension.Value())
                         .Short("Exam impressions")
                         .Definition("Exam impressions.")
                         .ZeroToMany()
                         .MustSupport();
                    e.AddExtensionLink(extensionDef);
                }
                {
                    ElementDefinition extensionDef =  e.ApplyExtension("Related", Self.RelatedClinicalResourcesExtension.Value())
                         .Short("Related Clinical Resources")
                         .Definition("References to FHIR clinical resoruces used during the exam or referenced by this report.")
                         .ZeroToMany();
                    e.AddExtensionLink(extensionDef);
                }
                {
                    ValueSet binding = Self.BiRadsAssessmentCategoriesVS.Value();
                    e.Select("conclusionCode")
                        .Single()
                        .Binding(binding, BindingStrength.Required)
                        .MustSupport()
                        ;
                    e.AddComponentLink("Conclusion Code",
                        new SDefEditor.Cardinality(e.Select("conclusionCode")),
                        Global.ElementAnchor("conclusionCode"), 
                        "CodeableConcept", 
                        binding.Url);
                }
                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("result", false);
                {
                    ElementTreeSlice slice = Self.SliceTargetReference(e, sliceElementDef, Self.SectionFindingsLeftBreast.Value(), 0, "1");
                    slice.ElementDefinition.MustSupport();
                }
                {
                    ElementTreeSlice slice = Self.SliceTargetReference(e, sliceElementDef, Self.SectionFindingsRightBreast.Value(), 0, "1");
                    slice.ElementDefinition.MustSupport();
                }
            });
    }
}
