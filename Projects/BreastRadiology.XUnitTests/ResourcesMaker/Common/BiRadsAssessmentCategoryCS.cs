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
        //# TODO: get from gg
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
                        new ConceptDef()
                            .SetCode("Category-0", "Category 0 - Incomplete")
                            .SetACR("Incomplete – Need Additional Imaging Evaluation and/or Prior Mammograms for Comparison")
                            ,
                        new ConceptDef()
                            .SetCode("Category-1", "Category 1 - Negative")
                            .SetACR("Negative Routine mammography screening Essentially 0% likelihood of malignancy")
                            ,
                        new ConceptDef()
                            .SetCode("Category-2", "Category 2 - Benign ")
                            .SetACR("Benign Routine mammography screening Essentially 0% likelihood of malignancy")
                            ,
                        new ConceptDef()
                            .SetCode("Category-3", "Category 0 - Probably Benign ")
                            .SetACR("Probably Benign Short-interval (6-month) follow-up or surveillance mammography ")
                            ,
                        new ConceptDef()
                            .SetCode("Category-4", "Category 4 - Suspicious")
                            .SetACR("Suspicious")
                            ,
                        new ConceptDef()
                            .SetCode("Category-4A", "Category 4A - Low suspicion for malignancy")
                            .SetACR("Low suspicion for malignancy")
                            ,
                        new ConceptDef()
                            .SetCode("Category-4B", "Category 4B - Moderate suspicion for malignancy")
                            .SetACR("Moderate suspicion for malignancy")
                            ,
                        new ConceptDef()
                            .SetCode("Category-4C", "Category 4C - High suspicion for malignancy")
                            .SetACR("High suspicion for malignancy")
                            ,
                        new ConceptDef()
                            .SetCode("Category-5", "Category 5 - Highly Suggestive of Malignancy")
                            .SetACR("Highly Suggestive of Malignancy")
                            ,
                        new ConceptDef()
                            .SetCode("Category-6", "Category 6 - Known Biopsy-Proven Malignancy")
                            .SetACR("Known Biopsy-Proven Malignancy")
                        //    ,
                        //new ConceptDef()
                        //    .SetCode("Post Biopsy Marker", "Post Biopsy Marker")
                        //    .SetDefinition("Post Biopsy Marker")
                        //    ,
                        //new ConceptDef()
                        //    .SetCode("Marker Clip Placement", "Marker Clip Placement")
                        //    .SetDefinition("Marker Clip Placement")
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
