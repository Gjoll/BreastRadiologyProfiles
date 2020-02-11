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
	public class OrientationCS                                                                                                                 // CSBuilder.cs:391
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/OrientationCS";                                                 // CSBuilder.cs:395
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// (historically, "wider-than-tall" or "horizontal")The long axis of the mass parallels the skin line.
		/// Masses that are only slightly obiquely orientedmight be considered parallel.
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_ParallelToSkin = new Coding(System, "ParallelToSkin", "Parallel to skin");                                      // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// (historically, "isodense")The long axis of the mass does not lie parallel to the skin line.
		/// The anterior-posterior or verticaldimension is greater than the transverse or horizontal dimension.
		/// These masses can also beobliquely oriented to the skin line.
		/// Round masses are NOT PARALLEL in their orientation.
		/// [-- Bi-Rads® Atlas — Mammography Fifth Ed. 2013]
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_PerpendicularToSkin = new Coding(System, "PerpendicularToSkin", "Perpendicular to skin (not parallel)");        // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_TallerThanWide = new Coding(System, "TallerThanWide", "Taller than wide");                                      // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_WiderThanTall = new Coding(System, "WiderThanTall", "Wider than tall");                                         // CSBuilder.cs:421
		//- Fields
	}
}
