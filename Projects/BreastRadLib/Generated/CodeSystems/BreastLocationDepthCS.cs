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
	public class BreastLocationDepthCS                                                                                                         // CSBuilder.cs:380
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/BreastLocationDepthCS";                                         // CSBuilder.cs:384
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Anterior depth
		/// </summary>
		public static Coding Code_Anterior = new Coding(System, "Anterior", "Anterior depth");                                                    // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Middle depth
		/// </summary>
		public static Coding Code_Middle = new Coding(System, "Middle", "Middle depth");                                                          // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Posterior depth
		/// </summary>
		public static Coding Code_Posterior = new Coding(System, "Posterior", "Posterior depth");                                                 // CSBuilder.cs:410
		//- Fields
	}
}
