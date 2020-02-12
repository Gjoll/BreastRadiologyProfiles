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
	public class UnitsofmeasureOrg                                                                                                             // CSBuilder.cs:403
	//- Header
	{
		//+ Fields
		const string System = "http://unitsofmeasure.org";                                                                                        // CSBuilder.cs:407
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// </summary>
		public static Coding Code_M = new Coding(System, "m", "meter");                                                                           // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// </summary>
		public static Coding Code_Cm = new Coding(System, "cm", "centimeter");                                                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// </summary>
		public static Coding Code_Mm = new Coding(System, "mm", "millimeter");                                                                    // CSBuilder.cs:433
		//- Fields
	}
}
