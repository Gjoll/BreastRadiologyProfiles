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
	public class MGAbnormalityAsymmetryTypeCS                                                                                                  // CSBuilder.cs:485
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MGAbnormalityAsymmetryTypeCS";                                  // CSBuilder.cs:489
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// This is an area of fibroglandular-density tissue that is visible on only one mammographic projection.
		/// Most such findings represent summation artifact, a superimposition of normal breast structures,
		/// whereas those confirmed to be real lesions (by subsequent demonstration on at least one
		/// more projection) may represent one of the other types of asymmetry or a mass.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Asymmetry = new Coding(System, "Asymmetry", "Asymmetry");                                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Global asymmetry is judged relative to the corresponding area in the contralateral breast and
		/// represents a large amount of fibroglandular-density tissue over a substantial portion of the
		/// breast (at least one quadrant). There is no mass, distorted architecture or associated suspicious
		/// calcifications. Global asymmetry usually represents a normal variant.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_GlobalAsymmetry = new Coding(System, "GlobalAsymmetry", "Global Asymmetry");                                    // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// A focal asymmetry is judged relative to the corresponding location in the contralateral breast,
		/// and represents a relatively small amount of fibroglandular-density tissue over a confined portion
		/// of the breast (less than one quadrant). It is visible on and has similar shape on different mammographic
		/// projections (hence a real finding rather than superimposition of normal breast structures),
		/// but it lacks the convex-outward borders and the conspicuity of a mass. Rather, the borders
		/// of a focal asymmetry are concave-outward, and it usually is seen to be interspersed with fat.
		/// Note that occasionally what is properly described as a focal asymmetry at screening (a finding visible
		/// on standard MLO and CC views) is determined at diagnostic mammography to be 2 different
		/// findings, each visible on only 1 standard view (hence, 2 asymmetries), each of which ultimately
		/// is judged to represent superimposition of normal breast structures. Also, not infrequently, what
		/// is properly described as a focal asymmetry at screening is determined at diagnostic evaluation
		/// (mammography and/or ultrasound) to represent a mass.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_FocalAsymmetry = new Coding(System, "FocalAsymmetry", "Focal Asymmetry");                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// This is a focal asymmetry that is new, larger, or more conspicuous than on a previous examination.
		/// Approximately 15% of cases of developing asymmetry are found to be malignant (either
		/// invasive carcinoma, DCIS, or both), so these cases warrant further imaging evaluation and biopsy
		/// unless found to be characteristically benign (e.g., simple cyst at directed ultrasound). Absence
		/// of a sonographic correlate, especially for a small (< 1 cm) developing asymmetry, should not avert biopsy.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_DevelopingAsymmetry = new Coding(System, "DevelopingAsymmetry", "Developing Asymmetry");                        // CSBuilder.cs:515
		//- Fields
	}
}
