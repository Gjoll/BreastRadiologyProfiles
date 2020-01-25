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
	public class MGDensityCS                                                                                                                   // CSBuilder.cs:380
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MGDensityCS";                                                   // CSBuilder.cs:384
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// X-ray attenuation of the mass is greater than the expected attenuation of an equal volume of
		/// fibroglandular breast tissue.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_HighDensity = new Coding(System, "HighDensity", "High Density");                                                // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// (historically, "isodense")
		/// X-ray attenuation of the mass is the same as the expected attenuation of an equal volume of
		/// fibroglandular breast tissue.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_EqualDensity = new Coding(System, "EqualDensity", "Equal Density");                                             // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// X-ray attenuation of the mass is less than the expected attenuation of an equal volume of
		/// fibroglandular breast tissue. A low density mass may be a group of microcysts. If such a finding
		/// is identified at mammography, it may very well not be malignant but appropriately may
		/// be worked up.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_LowDensity = new Coding(System, "LowDensity", "Low Density");                                                   // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// This includes all masses containing fat, such as oil cyst, lipoma or galactocele, as well as mixed
		/// density masses such as hamartoma. A fat-containing mass will almost always represent a
		/// benign mass.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_FatContaining = new Coding(System, "FatContaining", "Fat Containing");                                          // CSBuilder.cs:410
		//- Fields
	}
}
