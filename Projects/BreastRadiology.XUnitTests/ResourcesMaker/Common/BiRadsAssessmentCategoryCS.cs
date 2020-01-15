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
    partial class ResourcesMaker
    {
        CSTaskVar BiRadsAssessmentCategoriesCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "BiRadsAssessmentCategoriesCS",
                        "BiRads(r) Assessment Category Codes CodeSystem",
                        "BiRads/CodeSystem",
                        "BiRads(r) Assessment Category code system.",
                        Group_CommonCodesCS,
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
                    );

        VSTaskVar BiRadsAssessmentCategoriesVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "BiRadsAssessmentCategoriesVS",
                        "BiRads(r) Assessment Category ValueSet",
                        "BiRads/ValueSet",
                        "BiRads(r) Assessment Category value set.",
                        Group_CommonCodesVS,
                        Self.BiRadsAssessmentCategoriesCS.Value())
            );
    }
}
