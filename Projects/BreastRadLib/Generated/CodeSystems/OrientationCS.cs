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
	public class OrientationCS                                                                                                                 // CSBuilder.cs:380
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/OrientationCS";                                                 // CSBuilder.cs:384
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// (historically, “wider-than-tall” or “horizontal”)
		/// The long axis of the mass parallels the skin line. Masses that are only slightly obiquely oriented
		/// might be considered parallel.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_ParallelToSkin = new Coding(System, "ParallelToSkin", "Parallel to skin");                                      // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// (historically, "isodense")
		/// The long axis of the mass does not lie parallel to the skin line. The anterior–posterior or vertical
		/// dimension is greater than the transverse or horizontal dimension. These masses can also be
		/// obliquely oriented to the skin line. Round masses are NOT PARALLEL in their orientation.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_PerpendicularToSkin = new Coding(System, "PerpendicularToSkin", "Perpendicular To Skin");                       // CSBuilder.cs:410
		//- Fields
	}
}
