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
	public class PreviouslyDemonstratedByCodeSystemCS                                                                                          // CSBuilder.cs:403
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/PreviouslyDemonstratedByCodeSystemCS";                          // CSBuilder.cs:407
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A medical procedure that removes something from an area of the body.
		/// These substances can be air, body fluids, or bone fragments.###URL#https://medlineplus.gov/ency/article/002216.htm
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Aspiration = new Coding(System, "Aspiration", "Aspiration");                                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// An examination of tissue removed from the body to discover the presence, cause or extent of a disease.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Biopsy = new Coding(System, "Biopsy", "Biopsy");                                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Findings on the Mammogram was previously demonstrated by the MRI.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MRI = new Coding(System, "MRI", "MRI");                                                                         // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Findings on the Mammogram was previously demonstrated by the Ultrasound.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_US = new Coding(System, "US", "US");                                                                            // CSBuilder.cs:433
		//- Fields
	}
}
