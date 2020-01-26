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
	public class MGAbnormalityDensityTypeCS                                                                                                    // CSBuilder.cs:475
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MGAbnormalityDensityTypeCS";                                    // CSBuilder.cs:479
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_FocalAsymmetrical = new Coding(System, "FocalAsymmetrical", "Focal Asymmetrical");                              // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_Nodular = new Coding(System, "Nodular", "Nodular");                                                             // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_Tubular = new Coding(System, "Tubular", "Tubular");                                                             // CSBuilder.cs:505
		//- Fields
	}
}
