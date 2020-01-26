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
	public class BreastLocationQuadrantCS                                                                                                      // CSBuilder.cs:433
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/BreastLocationQuadrantCS";                                      // CSBuilder.cs:437
		                                                                                                                                          // CSBuilder.cs:449
		/// <summary>
		/// Upper outer quadrant of the breast
		/// </summary>
		public static Coding Code_UpperOuter = new Coding(System, "UpperOuter", "Upper Outer Quadrant");                                          // CSBuilder.cs:463
		                                                                                                                                          // CSBuilder.cs:449
		/// <summary>
		/// Upper inner quadrant of the breast
		/// </summary>
		public static Coding Code_UpperInner = new Coding(System, "UpperInner", "Upper Inner Quadrant");                                          // CSBuilder.cs:463
		                                                                                                                                          // CSBuilder.cs:449
		/// <summary>
		/// Lower outer quadrant of the breast
		/// </summary>
		public static Coding Code_LowerOuter = new Coding(System, "LowerOuter", "Lower Outer Quadrant");                                          // CSBuilder.cs:463
		                                                                                                                                          // CSBuilder.cs:449
		/// <summary>
		/// Lower inner quadrant of the breast
		/// </summary>
		public static Coding Code_LowerInner = new Coding(System, "LowerInner", "Lower Inner Quadrant");                                          // CSBuilder.cs:463
		//- Fields
	}
}
