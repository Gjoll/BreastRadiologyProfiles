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
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        async StringTask BiRadsAssessmentCategory()
        {
            if (this.biRadsAssessmentCategory == null)
                await this.CreateBiRadsAssessmentCategory();
            return this.biRadsAssessmentCategory;
        }
        String biRadsAssessmentCategory = null;

        async VTask CreateBiRadsAssessmentCategory()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs = await this.CreateCodeSystem(
                        "BiRadsAssessmentCategories",
                        "BiRads(r) Assessment Category Codes",
                        "BiRads/Assessment/Category/Values",
                        "BiRads(r) Assessment Category codes.",
                        Group_CommonCodes,
                        new ConceptDef[]
                        {
                        new ConceptDef("Category-0",
                            "Category 0 - Incomplete ",
                            new Definition()
                                .Line("Incomplete – Need Additional Imaging Evaluation and/or Prior Mammograms for Comparison")
                            ),
                        new ConceptDef("Category-1",
                            "Category 1 - Negative ",
                            new Definition()
                                .Line("Negative Routine mammography screening Essentially 0% likelihood of malignancy")
                            ),
                        new ConceptDef("Category-2",
                            "Category 2 - Benign ",
                            new Definition()
                                .Line("Benign Routine mammography screening Essentially 0% likelihood of malignancy")
                            ),
                        new ConceptDef("Category-3",
                            "Category 0 - Probably Benign ",
                            new Definition()
                                .Line("Probably Benign Short-interval (6-month) follow-up or surveillance mammography ")
                            ),
                        new ConceptDef("Category-4",
                            "Category 4 - Suspicious",
                            new Definition()
                                .Line("Suspicious")
                            ),
                        new ConceptDef("Category-4A",
                            "Category 4A - Low suspicion for malignancy",
                            new Definition()
                                .Line("Low suspicion for malignancy")
                            ),
                        new ConceptDef("Category-4B",
                            "Category 4B - Moderate suspicion for malignancy",
                            new Definition()
                                .Line("Moderate suspicion for malignancy")
                            ),
                        new ConceptDef("Category-4C",
                            "Category 4C - High suspicion for malignancy",
                            new Definition()
                                .Line("High suspicion for malignancy")
                            ),
                        new ConceptDef("Category-5",
                            "Category 5 - Highly Suggestive of Malignancy",
                            new Definition()
                                .Line("Highly Suggestive of Malignancy")
                            ),
                        new ConceptDef("Category-6",
                            "Category 6 - Known Biopsy-Proven Malignancy",
                            new Definition()
                                .Line("Known Biopsy-Proven Malignancy")
                            )
                        })
                    ;
                ValueSet binding = await this.CreateValueSet(
                        "BiRadsAssessmentCategories",
                        "BiRads(r) Assessment Category Codes",
                        "BiRads/Assessment/Category/Values",
                        "BiRads(r) Assessment Category codes.",
                        Group_CommonCodes,
                        cs);

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("BiRadsAssessmentCategory",
                        "BiRads Assessment Category",
                        "BiRads/Assessment/Category",
                        ObservationUrl,
                        $"{Group_CommonResources}/BiRads",
                        out this.biRadsAssessmentCategory)
                    .Description("BiRads Assessment Category Observation",
                        new Markdown()
                            .BiradHeader()
                            .BlockQuote("BI-RADS® assessments are divided into incomplete (category 0) and final assessment categories")
                            .BlockQuote("(categories 1, 2, 3, 4, 5 and 6). An incomplete mammography assessment, usually rendered at batch-")
                            .BlockQuote("read screening mammography, requires further evaluation with additional mammographic views,")
                            .BlockQuote("ultrasound, and/or comparison mammography examination(s). If the additional evaluation involves")
                            .BlockQuote("only comparison with previous mammography examination(s) that then leads to a final assessment,")
                            .BlockQuote("the incomplete screening assessment is replaced by this final assessment. If the additional evalu-")
                            .BlockQuote("ation includes a diagnostic imaging examination, a final assessment is rendered for the diagnostic")
                            .BlockQuote("examination, but the screening mammography examination remains assessed as category 0.")
                            .BiradFooter()
                            .Todo(
                                "Should each mass/calcification observation have its own optional/required BiRad observation or just the Left/Right/Combined sections?",
                                "How is this different from CommonObservedState"
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationCodedValueFragment())
                    .AddFragRef(await this.ObservationLeafFragment())
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode(e, "a BiRad Assessment Category", binding);
            });
        }
    }
}
