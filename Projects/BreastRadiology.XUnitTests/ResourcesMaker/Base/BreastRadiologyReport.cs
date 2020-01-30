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
                             .Paragraph("This resource is one of the components of a Breast Radiology Document.",
                                         "It is referenced in the document's 'Report' section ",
                                         "and contains the report conclusions and findings.")
                             .Paragraph("This resource is a profile of the Fhir DiagnosticReport base resource.")
                     )
                     .AddFragRef(Self.HeaderFragment.Value())
                     .AddFragRef(Self.CategoryFragment.Value())
                     ;

                s = e.SDef;
                e.IntroDoc
                     .ReviewedStatus("KWA-PEN", "1.1.2020")
                     .ReviewedStatus("CIC", "22.1.2020")
                     ;

                e.Select("code").Pattern = new CodeableConcept(Loinc, "10193-1");
                e.Select("specimen").Zero();
                {
                    e.Select("conclusion")
                        .Single()
                        .Definition(new Markdown()
                            .Paragraph("This will contain a text version of the complete report.")
                            .Paragraph("The report should be readable without specialized formatting software.")
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
