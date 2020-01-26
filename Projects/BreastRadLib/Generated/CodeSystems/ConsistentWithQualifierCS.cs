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
	public class ConsistentWithQualifierCS                                                                                                     // CSBuilder.cs:475
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/ConsistentWithQualifierCS";                                     // CSBuilder.cs:479
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Likely represents
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_LikelyRepresents = new Coding(System, "LikelyRepresents", "Likely represents");                                 // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Most likely
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MostLikely = new Coding(System, "MostLikely", "Most likely");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Resembles
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Resembles = new Coding(System, "Resembles", "Resembles");                                                       // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] w/differential diagnosis
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_WDifferentialDiagnosis = new Coding(System, "w/differentialDiagnosis", "w/differential diagnosis");             // CSBuilder.cs:505
		//- Fields
	}
}
