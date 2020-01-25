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
	public class MammoCalcificationDistributionCS                                                                                              // CSBuilder.cs:408
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MammoCalcificationDistributionCS";                              // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// (historically, "scattered")
		/// These are calcifications that are distributed randomly throughout the breast. Punctate and
		/// amorphous calcifications in this distribution are almost always benign, especially if bilateral.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Diffuse = new Coding(System, "Diffuse", "Diffuse Calcification Distribution");                                  // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// This descriptor is used for numerous calcifications that occupy a large portion of breast tissue
		/// (more than 2 cm in greatest dimension), not conforming to a duct distribution. Since this
		/// distribution may involve most of a quadrant or even more than a single quadrant, malignancy
		/// is less likely. However, overall evaluation of regional calcifications must include particle shape
		/// (morphology) as well as distribution.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Regional = new Coding(System, "Regional", "Regional  Calcification Distribution");                              // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// (historically, "clustered")
		/// This term should be used when relatively few calcifications occupy a small portion of breast
		/// tissue. The lower limit for use of this descriptor is usually when 5 calcifications are grouped
		/// within 1 cm of each other or when a definable pattern is identified. The upper limit for use
		/// of this descriptor is when larger numbers of calcifications are grouped within 2 cm of each other.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Grouped = new Coding(System, "Grouped", "Grouped  Calcification Distribution");                                 // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// These are calcifications arrayed in a line. This distribution may elevate suspicion for malignancy,
		/// as it suggests deposits in a duct. Note that both vascular and large rod-like calcifications
		/// also are usually linear in distribution, but that these typically benign calcifications have
		/// a characteristically benign morphology.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Linear = new Coding(System, "Linear", "Linear  Calcification Distribution");                                    // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Calcifications in a segmental distribution are of concern because they suggest deposits in a
		/// duct or ducts and their branches, raising the possibility of extensive or multifocal breast cancer
		/// in a lobe or segment of the breast. Although benign causes of segmental calcifications exist
		/// (e.g. large rod-like), the smooth, rod-like morphology and large size of benign calcifications
		/// distinguish them from finer, more pleomorphic or heterogeneous malignant calcifications.
		/// A segmental distribution may elevate the degree of suspicion for calcifications such as punctate or amorphous forms.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// </summary>
		public static Coding Code_Segmental = new Coding(System, "Segmental", "Segmental Calcification Distribution");                            // CSBuilder.cs:438
		//- Fields
	}
}
