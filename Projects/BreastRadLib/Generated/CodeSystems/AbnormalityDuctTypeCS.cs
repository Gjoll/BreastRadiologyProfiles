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
	public class AbnormalityDuctTypeCS                                                                                                         // CSBuilder.cs:433
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/AbnormalityDuctTypeCS";                                         // CSBuilder.cs:437
		                                                                                                                                          // CSBuilder.cs:449
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_Normal = new Coding(System, "Normal", "Normal");                                                                // CSBuilder.cs:463
		                                                                                                                                          // CSBuilder.cs:449
		/// <summary>
		/// [PR]
		/// </summary>
		public static Coding Code_Ectasia = new Coding(System, "Ectasia", "Ectasia");                                                             // CSBuilder.cs:463
		                                                                                                                                          // CSBuilder.cs:449
		/// <summary>
		/// This is a unilateral tubular or branching structure that likely represents a dilated or otherwise en-
		/// larged duct. It is a rare finding. Even if unassociated with other suspicious clinical or mammographic
		/// findings, it has been reported to be associated with noncalcified DCIS.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Dilated = new Coding(System, "Dilated", "Dilated");                                                             // CSBuilder.cs:463
		//- Fields
	}
}
