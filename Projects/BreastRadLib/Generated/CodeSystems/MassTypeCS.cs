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
	public class MassTypeCS                                                                                                                    // CSBuilder.cs:408
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MassTypeCS";                                                    // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// [PR]
		/// Solid Mass
		/// </summary>
		public static Coding Code_Solid = new Coding(System, "Solid", "Solid Mass");                                                              // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// [PR]
		/// Intraductal Mass
		/// </summary>
		public static Coding Code_Intraductal = new Coding(System, "Intraductal", "Intraductal Mass");                                            // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// [PR]
		/// Partially Solid Mass
		/// </summary>
		public static Coding Code_PartiallySolid = new Coding(System, "PartiallySolid", "Partially Solid Mass");                                  // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// [PR]
		/// Skin Mass
		/// </summary>
		public static Coding Code_Skin = new Coding(System, "Skin", "Skin Mass");                                                                 // CSBuilder.cs:438
		//- Fields
	}
}
