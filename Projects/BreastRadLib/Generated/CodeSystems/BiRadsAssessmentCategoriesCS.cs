using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	//+ Header
	public class BiRadsAssessmentCategoriesCS                                                                                                  // CSBuilder.cs:391
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/BiRadsAssessmentCategoriesCS";                                  // CSBuilder.cs:395
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// Need additional Imaging Evaluation and/or prior Mammograms for comparison.
		/// Recall for additional imaging and/or comparison with prior examination(s)        ###ACRUS#
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Category0 = new Coding(System, "Category0", "Category 0 (Incomplete)");                                         // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// This is a normal assessment.
		/// Benign refers to a condition, tumor, or growth that is not cancerous.
		/// This means that it does not spread to other parts of the body.
		/// It does not invade nearby tissue.
		/// Essentially 0% likelihood of malignancy.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Category2 = new Coding(System, "Category2", "Category 2 (Benign)");                                             // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// A finding assessed using this category should have a <= 2% likelihood of malignancy, but greater than the essentially 0% likelihood of malignancy of a characteristically benign finding.
		/// A probably benign finding is not expected to change over the suggested period of imaging surveillance, but the interpreting physician prefers to establish stability of the finding before recommending management limited to routine mammography screening.
		/// Six month follow-up and/orsurveillance mammography is recommended.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Category3 = new Coding(System, "Category3", "Category 3 (Probably Benign)");                                    // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// This category is reserved for findings that do not have the classic appearance of malignancy but are sufficiently suspicious to justify a recommendation for biopsy.
		/// There is a 2% likelihood of malignancy (cancer).
		/// Almost all recommendations for breast interventional procedures will come from assessments made usingthis category.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Category4 = new Coding(System, "Category4", "Category 4 (Suspicious)");                                         // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// Low suspicion for malignancy.
		/// A malignant finding is not suspected.
		/// A biopsy or other test will likely still be performed in order to determine.
		/// Tissue diagnosis may be recommended.
		/// Six month follow-up and/or surveillance mammography is recommended.
		/// Likelihood of malignancy is > 2% to <= 10% likelihood of malignancy.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Category4A = new Coding(System, "Category4A", "Category 4A (Low suspicion)");                                   // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// Category 4B: Moderate suspicion for malignancy.
		/// It warrants radiologic and pathologic correlation after tissue diagnosis.
		/// Likelihood of malignancy is > 10% to <= 50% likelihood ofmalignancy.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Category4B = new Coding(System, "Category4B", "Category 4B (Moderate suspicion)");                              // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// Category 4C: High suspicion formalignancy.
		/// Includes findings that have a high suspicion of malignancy but that are not highlysuggestive of malignancy (category 5).
		/// Tissue Diagnosis is highly recommended.
		/// Range for likelihood of malignancy is > 50% to < 95% likelihood of malignancy.
		/// It is more likely malignant versus benign.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Category4C = new Coding(System, "Category4C", "Category 4C (High suspicion)");                                  // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// Highly Suggestive of Malignancy.
		/// Almost certainly predictive of breast cancer with a value of at least 95%.
		/// Tissue Diagnosis is highly recommended or required.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Category5 = new Coding(System, "Category5", "Category 5 (Highly Suggestive of Malignancy)");                    // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// Known Biopsy-Proven Malignancy.
		/// Surgical excision when clinicallyappropriate.
		/// This category is only used for findings on a mammogram that have already been shown to be cancer by a previous biopsy.
		/// Mammograms may be used in this way to see how well the cancer is responding to treatment.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Category6 = new Coding(System, "Category6", "Category 6 (Known Biopsy-Proven Malignancy)");                     // CSBuilder.cs:421
		//- Fields
	}
}
