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
	public class BiRadsAssessmentCategoriesCS                                                                                                  // CSBuilder.cs:380
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/BiRadsAssessmentCategoriesCS";                                  // CSBuilder.cs:384
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Incomplete – Need Additional Imaging Evaluation and/or Prior Mammograms for Comparison
		/// </summary>
		public static Coding Code_Category0 = new Coding(System, "Category-0", "Category 0 - Incomplete");                                        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Negative Routine mammography screening Essentially 0% likelihood of malignancy
		/// </summary>
		public static Coding Code_Category1 = new Coding(System, "Category-1", "Category 1 - Negative");                                          // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Benign Routine mammography screening Essentially 0% likelihood of malignancy
		/// </summary>
		public static Coding Code_Category2 = new Coding(System, "Category-2", "Category 2 - Benign");                                            // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Probably Benign Short-interval (6-month) follow-up or surveillance mammography
		/// </summary>
		public static Coding Code_Category3 = new Coding(System, "Category-3", "Category 0 - Probably Benign");                                   // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Suspicious
		/// </summary>
		public static Coding Code_Category4 = new Coding(System, "Category-4", "Category 4 - Suspicious");                                        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Low suspicion for malignancy
		/// </summary>
		public static Coding Code_Category4A = new Coding(System, "Category-4A", "Category 4A - Low suspicion for malignancy");                   // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Moderate suspicion for malignancy
		/// </summary>
		public static Coding Code_Category4B = new Coding(System, "Category-4B", "Category 4B - Moderate suspicion for malignancy");              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// High suspicion for malignancy
		/// </summary>
		public static Coding Code_Category4C = new Coding(System, "Category-4C", "Category 4C - High suspicion for malignancy");                  // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Highly Suggestive of Malignancy
		/// </summary>
		public static Coding Code_Category5 = new Coding(System, "Category-5", "Category 5 - Highly Suggestive of Malignancy");                   // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Known Biopsy-Proven Malignancy
		/// </summary>
		public static Coding Code_Category6 = new Coding(System, "Category-6", "Category 6 - Known Biopsy-Proven Malignancy");                    // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Post Biopsy Marker
		/// </summary>
		public static Coding Code_PostBiopsyMarker = new Coding(System, "Post Biopsy Marker", "Post Biopsy Marker");                              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Marker Clip Placement
		/// </summary>
		public static Coding Code_MarkerClipPlacement = new Coding(System, "Marker Clip Placement", "Marker Clip Placement");                     // CSBuilder.cs:410
		//- Fields
	}
}
