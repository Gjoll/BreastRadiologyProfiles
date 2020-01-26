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
	public class AbnormalityLymphNodeTypeCS                                                                                                    // CSBuilder.cs:475
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/AbnormalityLymphNodeTypeCS";                                    // CSBuilder.cs:479
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_Axillary = new Coding(System, "Axillary", "Axillary");                                                          // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_Enlarged = new Coding(System, "Enlarged", "Enlarged");                                                          // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_FocalCortex = new Coding(System, "FocalCortex", "FocalCortex");                                                 // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_UniformThickness = new Coding(System, "UniformThickness", "UniformThickness");                                  // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// These are circumscribed masses that are reniform and have hilar fat. They are generally 1 cm or smaller
		/// in size. They may be larger than 1 cm and characterized as normal when fat replacement is pro-
		/// nounced. They frequently occur in the lateral and usually upper portions of the breast closer to the
		/// axilla, although they may occur anywhere in the breast. They usually are seen adjacent to a vein,
		/// because the lymphatic drainage of the breast parallels the venous drainage.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Intramammory = new Coding(System, "Intramammory", "Intramammory");                                              // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_InternalMargin = new Coding(System, "InternalMargin", "Internal Margin");                                       // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_Normal = new Coding(System, "Normal", "Normal");                                                                // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_PathLymphNode = new Coding(System, "PathLymphNode", "Path Lymph Node");                                         // CSBuilder.cs:505
		//- Fields
	}
}
