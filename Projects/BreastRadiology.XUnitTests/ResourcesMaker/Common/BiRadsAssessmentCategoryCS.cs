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
                            //+ Codes
                            #region Codes
                            new ConceptDef()
                                .SetCode("Category0")
                                .SetDisplay("Category 0")
                                .MammoId("36")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 397138000 | Mammography assessment " +
                                    "(Category 0)")
                                .SetUMLS("Category 0: Incomplete - NeedAdditional Imaging Evaluation " +
                                    "and/or prior Mammograms for comparison. ",
                                    "Recall for additional imaging and/or comparison with " +
                                    "prior examination(s)        ###ACRUS#")
                            ,
                            new ConceptDef()
                                .SetCode("Category2")
                                .SetDisplay("Category 2")
                                .MammoId("32")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 397141009 | Mammography assessment " +
                                    "(Category 2)")
                                .SetUMLS("This is a normal assessment. ",
                                    "Benign refers to a condition, tumor, or growth that " +
                                    "is not cancerous. ",
                                    "This means that it does not spread to other parts " +
                                    "of the body. ",
                                    "It does not invade nearby tissue. ",
                                    " Essentially 0% likelihood of malignancy. ",
                                    "###ACRUS#")
                            ,
                            new ConceptDef()
                                .SetCode("Category3")
                                .SetDisplay("Category 3")
                                .MammoId("33")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 397143007 | Mammography assessment " +
                                    "(Category 3)")
                                .SetUMLS("A finding assessed using this category should have " +
                                    "a <= 2% likelihood of malignancy, but greater than " +
                                    "the essentially 0% likelihood of malignancy of a " +
                                    "characteristically benign finding. ",
                                    "A probably benign finding is not expected to change " +
                                    "over the suggested period of imaging surveillance, " +
                                    "but the interpreting physician prefers to establish " +
                                    "stability of the finding before recommending management " +
                                    "limited to routine mammography screening. ",
                                    " Six month follow-up and/orsurveillance mammography " +
                                    "is recommended. ",
                                    "###ACRUS#")
                            ,
                            new ConceptDef()
                                .SetCode("Category4")
                                .SetDisplay("Category 4")
                                .MammoId("34")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 397144001 | Mammography assessment " +
                                    "(Category 4)")
                                .SetUMLS("This category is reserved for findings that do not " +
                                    "have the classic appearance of malignancy but are " +
                                    "sufficiently suspicious to justify a recommendation " +
                                    "for biopsy. ",
                                    "There is a 2% likelihood of malignancy (cancer). ",
                                    "Almost all recommendations for breast interventional " +
                                    "procedures will come from assessments made usingthis " +
                                    "category. ",
                                    "###ACRUS#")
                            ,
                            new ConceptDef()
                                .SetCode("Category4a")
                                .SetDisplay("Category 4a")
                                .MammoId("176")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Not found")
                                .SetUMLS("Category 4A: Low suspicion formalignancy. ",
                                    "A malignant finding is not suspected. ",
                                    "A biopsy or other test will likely still be performed " +
                                    "in order to determine. ",
                                    "Tissue diagnosis may be recommended. ",
                                    "Six month follow-up and/or surveillance mammography " +
                                    "is recommended. ",
                                    "Likelihood of malignancy is > 2% to <= 10% likelihood " +
                                    "of malignancy. ",
                                    "###ACRUS#")
                            ,
                            new ConceptDef()
                                .SetCode("Category4b")
                                .SetDisplay("Category 4b")
                                .MammoId("177")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Not found")
                                .SetUMLS("Category 4B: Moderate suspicion for malignancy. ",
                                    "It warrants radiologic and pathologic correlation " +
                                    "after tissue diagnosis. ",
                                    "Likelihood of malignancy is > 10% to <= 50% likelihood " +
                                    "ofmalignancy. ",
                                    "###ACRUS#")
                            ,
                            new ConceptDef()
                                .SetCode("Category4c")
                                .SetDisplay("Category 4c")
                                .MammoId("178")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Not found")
                                .SetUMLS("Category 4C: High suspicion formalignancy. ",
                                    "Includes findings that have a high suspicion of malignancy " +
                                    "but that are not highlysuggestive of malignancy (category " +
                                    "5). ",
                                    "Tissue Diagnosis is highly recommended. ",
                                    " Range for likelihood of malignancy is > 50% to < " +
                                    "95% likelihood of malignancy. ",
                                    "It is more likely malignant versus benign. ",
                                    "###ACRUS#")
                            ,
                            new ConceptDef()
                                .SetCode("Category5")
                                .SetDisplay("Category 5")
                                .MammoId("35")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 397145000 | Mammography assessment " +
                                    "(Category 5)")
                                .SetUMLS("Category 5: HighlySuggestive of Malignancy      Almost " +
                                    "certainly predictive of breast cancer with a value " +
                                    "of at least 95%. ",
                                    "Tissue Diagnosis is highly recommended or required.")
                            ,
                            new ConceptDef()
                                .SetCode("Category6")
                                .SetDisplay("Category 6")
                                .MammoId("172")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetUMLS("Category 6: Known Biopsy-Proven Malignancy       " +
                                    "              Surgical excision when clinicallyappropriate. ",
                                    "                                This category is " +
                                    "only used for findings on a mammogram that have already " +
                                    "been shown to be cancer by a previous biopsy. ",
                                    " Mammograms may be used in this way to see how well " +
                                    "the cancer is responding to treatment. ",
                                    "###ACRUS#")
                            ,
                            new ConceptDef()
                                .SetCode("N/A")
                                .SetDisplay("N/A")
                                .MammoId("174")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Not found")
                            ,
                            new ConceptDef()
                                .SetCode("PostBiopsy/Marker")
                                .SetDisplay("Post biopsy / marker")
                                .MammoId("173")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("After removing the tissue samples, the doctor may " +
                                    "leave a tiny clip or marker, made of surgical-grade " +
                                    "material, to identify the biopsy site. ",
                                    "This will be visible on a mammogram. ",
                                    "The marker points out the exact site of the biopsy " +
                                    "so that a doctor can find it again easily if they " +
                                    "need to. ",
                                    "###URL#https://www.medicalnewstoday.com/articles/265444.php")
                            #endregion // Codes
                            //- Codes
                        //new ConceptDef()
                        //    .SetCode("Category-0", "Category 0 - Incomplete")
                        //    .SetACR("Incomplete � Need Additional Imaging Evaluation and/or Prior Mammograms for Comparison")
                        //    ,
                        //new ConceptDef()
                        //    .SetCode("Category-1", "Category 1 - Negative")
                        //    .SetACR("Negative Routine mammography screening Essentially 0% likelihood of malignancy")
                        //    ,
                        //new ConceptDef()
                        //    .SetCode("Category-2", "Category 2 - Benign ")
                        //    .SetACR("Benign Routine mammography screening Essentially 0% likelihood of malignancy")
                        //    ,
                        //new ConceptDef()
                        //    .SetCode("Category-3", "Category 3 - Probably Benign ")
                        //    .SetACR("Probably Benign Short-interval (6-month) follow-up or surveillance mammography ")
                        //    ,
                        //new ConceptDef()
                        //    .SetCode("Category-4", "Category 4 - Suspicious")
                        //    .SetACR("Suspicious")
                        //    ,
                        //new ConceptDef()
                        //    .SetCode("Category-4A", "Category 4A - Low suspicion for malignancy")
                        //    .SetACR("Low suspicion for malignancy")
                        //    ,
                        //new ConceptDef()
                        //    .SetCode("Category-4B", "Category 4B - Moderate suspicion for malignancy")
                        //    .SetACR("Moderate suspicion for malignancy")
                        //    ,
                        //new ConceptDef()
                        //    .SetCode("Category-4C", "Category 4C - High suspicion for malignancy")
                        //    .SetACR("High suspicion for malignancy")
                        //    ,
                        //new ConceptDef()
                        //    .SetCode("Category-5", "Category 5 - Highly Suggestive of Malignancy")
                        //    .SetACR("Highly Suggestive of Malignancy")
                        //    ,
                        //new ConceptDef()
                        //    .SetCode("Category-6", "Category 6 - Known Biopsy-Proven Malignancy")
                        //    .SetACR("Known Biopsy-Proven Malignancy")
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
