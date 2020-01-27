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
                     .AddFragRef(Self.ServiceRecommendationFragment.Value())
                     ;

                s = e.SDef;
                e.IntroDoc
                     .ReviewedStatus("KWA-PEN", "1.1.2020")
                     .ReviewedStatus("CIC", "22.1.2020")
                     ;

                e.Select("code").Pattern = new CodeableConcept(Loinc, "10193-1");
                e.Select("specimen").Zero();
                {
                    StructureDefinition extensionStructureDef = Self.ImpressionsExtension.Value();
                    ElementDefinition extensionDef = e.ApplyExtension("Impressions", extensionStructureDef).ElementDefinition
                         .Short("Exam impressions")
                         .Definition("Exam impressions.")
                         .ZeroToMany()
                         .MustSupport();
                    e.AddExtensionLink(extensionStructureDef.Url,
                        new SDefEditor.Cardinality(extensionDef),
                        "Impressions", 
                        Global.ElementAnchor(extensionDef));
                }
                {
                    StructureDefinition extensionStructureDef = Self.RelatedClinicalResourcesExtension.Value();
                    ElementDefinition extensionDef =  e.ApplyExtension("Related", extensionStructureDef).ElementDefinition
                         .Short("Related Clinical Resources")
                         .Definition("References to FHIR clinical resoruces used during the exam or referenced by this report.")
                         .ZeroToMany();
                    e.AddExtensionLink(extensionStructureDef.Url,
                        new SDefEditor.Cardinality(extensionDef),
                        "Related Clinical Resources", 
                        Global.ElementAnchor(extensionDef));
                }
                {
                    ValueSet binding = Self.BiRadsAssessmentCategoriesVS.Value();
                    e.Select("conclusion")
                        .Single()
                        .Definition(new Markdown()
                            .Paragraph("This will contain a text version of the complete report.")
                            .Paragraph("The report should be readable without specialized formatting software..")
                            );
                }
                {
                    ValueSet binding = Self.BiRadsAssessmentCategoriesVS.Value();
                    ElementDefinition conclusionCodeDef =  e.Select("conclusionCode")
                        .Single()
                        .Binding(binding, BindingStrength.Required)
                        .MustSupport()
                        ;
                    e.AddComponentLinkVS("Conclusion Code",
                        new SDefEditor.Cardinality(conclusionCodeDef),
                        Global.ElementAnchor(conclusionCodeDef), 
                        "CodeableConcept", 
                        binding.Url);
                }
                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("result", false);
                {
                    ElementTreeSlice slice = e.SliceTargetReference( sliceElementDef, Self.SectionFindingsLeftBreast.Value(), 0, "1");
                    slice.ElementDefinition.MustSupport();
                }
                {
                    ElementTreeSlice slice = e.SliceTargetReference( sliceElementDef, Self.SectionFindingsRightBreast.Value(), 0, "1");
                    slice.ElementDefinition.MustSupport();
                }
            });
    }
}
