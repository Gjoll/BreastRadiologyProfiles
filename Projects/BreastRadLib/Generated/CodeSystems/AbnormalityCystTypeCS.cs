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
	public class AbnormalityCystTypeCS                                                                                                         // CSBuilder.cs:408
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/AbnormalityCystTypeCS";                                         // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_Complex = new Coding(System, "Complex", "Complex cyst");                                                        // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_Oil = new Coding(System, "Oil", "Oil cyst");                                                                    // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_Simple = new Coding(System, "Simple", "Simple cyst");                                                           // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_Complicated = new Coding(System, "Complicated", "Complicated cyst");                                            // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_WithDebris = new Coding(System, "WithDebris", "Cyst With Debris");                                              // CSBuilder.cs:438
		//- Fields
	}
}
