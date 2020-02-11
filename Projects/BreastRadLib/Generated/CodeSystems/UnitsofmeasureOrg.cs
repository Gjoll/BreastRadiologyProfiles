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
	public class UnitsofmeasureOrg                                                                                                             // CSBuilder.cs:441
	//- Header
	{
		//+ Fields
		const string System = "http://unitsofmeasure.org";                                                                                        // CSBuilder.cs:445
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// </summary>
		public static Coding Code_M = new Coding(System, "m", "meter");                                                                           // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// </summary>
		public static Coding Code_Cm = new Coding(System, "cm", "centimeter");                                                                    // CSBuilder.cs:471
		                                                                                                                                          // CSBuilder.cs:457
		/// <summary>
		/// </summary>
		public static Coding Code_Mm = new Coding(System, "mm", "millimeter");                                                                    // CSBuilder.cs:471
		//- Fields
	}
}
