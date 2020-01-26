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
	public class FibroadenomaCodeSystemCS                                                                                                      // CSBuilder.cs:485
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/FibroadenomaCodeSystemCS";                                      // CSBuilder.cs:489
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR]
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Normal = new Coding(System, "Normal", "Normal");                                                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR]
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Degenerated = new Coding(System, "Degenerated", "Degenerated");                                                 // CSBuilder.cs:515
		//- Fields
	}
}
