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
	public class MarginCS                                                                                                                      // CSBuilder.cs:410
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MarginCS";                                                      // CSBuilder.cs:414
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Some or all of the margin has sharp corners, often forming acute angles.
		/// The margin of the mass is not circumscribed.
		/// 
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_AngularMargin = new Coding(System, "AngularMargin", "Angular margin");                                          // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// A circumscribed margin is one that is well defined, with an abrupt transition between the lesion and the surrounding tissue.
		/// For US, to describe a mass as circumscribed, its entire margin must be sharply defined.
		/// Most circumscribed lesions have round or oval shapes.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition#49
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_CircumscribedMargin = new Coding(System, "CircumscribedMargin", "Circumscribed margin");                        // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// There is no clear demarcation of the entire margin, or of any portion of the margin, from the surroundingtissue.
		/// For mammography, this descriptor should not be used when the interpretingphysician believes it is likely due to immediately adjacent breast tissue.
		/// Use of this descriptorusually implies a suspicious finding.
		/// -- Breast Imaging Reporting and Data System—Ultrasound, Second Edition#23
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_IndistinctMargin = new Coding(System, "IndistinctMargin", "Indistinct margin");                                 // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Intraductal tumor extension is a characteristic feature of primary breast carcinoma, and is an important consideration in patients undergoing breast conservative surgery.
		/// -- https://www.ncbi.nlm.nih.gov/pubmed/8630874
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_IntraductalExtension = new Coding(System, "IntraductalExtension", "Intraductal extension");                     // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Edges around the soft tissue that don't look smooth.
		/// Indicative of some sort of growth or mass rather than a cyst.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_IrregularMargin = new Coding(System, "IrregularMargin", "Irregular margin");                                    // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// The edge of the mass has broad bulges.
		/// Much like a 6 or 8 leaf clover.
		/// The edge of all of the leaves would be considered lobulated.
		/// 
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_LobulatedMargin = new Coding(System, "LobulatedMargin", "Lobulated margin");                                    // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// Smooth margin with distinct separation between the mass and the surrounding border.
		/// They are  oval-shaped and  have a wide rather than tall formation.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MacrolobulatedMargin = new Coding(System, "MacrolobulatedMargin", "Macrolobulated margin");                     // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// The margin is characterized by short-cycle undulations or scalloped appearance,and the margin of the mass is not circumscribed.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition#54
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MicrolobulatedMargin = new Coding(System, "MicrolobulatedMargin", "Microlobulated margin");                     // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// The mass has one or more of the following features: indistinct,angular, microlobulated, or spiculated in any portionof the margin There is not a clear demarcation between the mass and the surrounding tissue.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition#153
		/// 
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_NonCircumscribedMargin = new Coding(System, "NonCircumscribedMargin", "Non circumscribed margin");              // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// It is hidden by superimposed or adjacent fibroglandular tissue.
		/// This is used primarily when some of the margin of the mass is circumscribed, but the rest (more than 25%) is hidden.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_ObscuredMagin = new Coding(System, "ObscuredMagin", "Obscured magin");                                          // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// The edges of the mass have a smooth appearance and distinct separation between the mass and surrounding tissue.
		/// 
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_SmoothMargin = new Coding(System, "SmoothMargin", "Smooth margin");                                             // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:426
		/// <summary>
		/// The margin is characterized by sharp lines radiating from the mass, often a sign of malignancy,but the significant feature is that the margin of the mass is not circumscribed.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition#55
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SpiculatedMargin = new Coding(System, "SpiculatedMargin", "Spiculated margin");                                 // CSBuilder.cs:440
		//- Fields
	}
}
