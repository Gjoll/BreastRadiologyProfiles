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
	public class MGBreastDensityCS                                                                                                             // CSBuilder.cs:475
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MGBreastDensityCS";                                             // CSBuilder.cs:479
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// Unless an area containing cancer is not included in the image field of the mammogram,
		/// mammography is highly sensitive in this setting.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Fatty = new Coding(System, "Fatty", "The breasts are almost entirely fatty");                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// (historically, there are scattered fibroglandular densities).
		/// 
		/// It may be helpful to distinguish breasts in which there are a few scattered areas of
		/// fibroglandular-density tissue from those in which there are moderate scattered areas of
		/// fibroglandular-density tissue. Note that there has been a subtle change in the wording
		/// of this category, to conform to BI-RADS® lexicon use of the term "density" to describe
		/// the degree of x-ray attenuation of breast tissue but not to represent discrete
		/// mammographic findings.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Fibroglandular = new Coding(System, "Fibroglandular", "Scattered areas of fibroglandular density");             // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// It is not uncommon for some areas in such breasts to be relatively dense while other
		/// areas are primarily fatty. When this occurs, it may be helpful to describe the location(s)
		/// of the denser tissue in a second sentence, so that the referring clinician is aware that
		/// these are the areas in which small noncalcified lesions may be obscured. Suggested
		/// wordings for the second sentence include:
		/// 
		/// "The dense tissue is located anteriorly in both breasts, and the posterior portions
		/// are mostly fatty."
		/// 
		/// "Primarily dense tissue is located in the upper outer quadrants of both breasts;
		/// scattered areas of fibroglandular tissue are present in the remainder of the breasts."
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_HeterogeneouslyDense = new Coding(System, "HeterogeneouslyDense", "The breasts are heterogeneously dense, which may obscure detection of small masses");// CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// The sensitivity of mammography is lowest in this density category.
		/// The Fourth Edition of BI-RADS®, unlike previous editions, indicated quartile ranges
		/// of percentage dense tissue (increments of 25% density) for each of the four density
		/// categories, with the expectation that the assignment of breast density would be
		/// distributed more evenly across categories than the historical distribution of 10% fatty,
		/// 40% scattered, 40% heterogeneously and 10% extremely dense. However, it has since
		/// been demonstrated in clinical practice that there has been essentially no change
		/// in this historical distribution across density categories.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_ExtremelyDense = new Coding(System, "ExtremelyDense", "The breasts are extremely dense, which lowers the sensitivity of mammography.");// CSBuilder.cs:505
		//- Fields
	}
}
