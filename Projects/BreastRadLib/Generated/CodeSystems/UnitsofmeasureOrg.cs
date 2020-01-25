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
	public class UnitsofmeasureOrg                                                                                                             // CSBuilder.cs:380
	//- Header
	{
		//+ Fields
		const string System = "http://unitsofmeasure.org";                                                                                        // CSBuilder.cs:384
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// </summary>
		public static Coding Code_M = new Coding(System, "m", "meter");                                                                           // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// </summary>
		public static Coding Code_Cm = new Coding(System, "cm", "centimeter");                                                                    // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// </summary>
		public static Coding Code_Mm = new Coding(System, "mm", "millimeter");                                                                    // CSBuilder.cs:410
		//- Fields
	}
}
