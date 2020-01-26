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
	public class MarginCS                                                                                                                      // CSBuilder.cs:485
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/MarginCS";                                                      // CSBuilder.cs:489
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Angular margin
		/// Some or all of the margin has sharp corners, often forming acute angles, but the significant
		/// feature is that the margin of the mass is NOT CIRCUMSCRIBED.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_AngularMargin = new Coding(System, "AngularMargin", "Angular margin");                                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// (historically, "well-defined" or "sharply-defined")
		/// A circumscribed margin is one that is well defined, with an abrupt transition between the
		/// lesion and the surrounding tissue. For US, to describe a mass as circumscribed, its entire margin
		/// must be sharply defined. Most circumscribed lesions have round or oval shapes.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG US NM.
		/// </summary>
		public static Coding Code_CircumscribedMargin = new Coding(System, "CircumscribedMargin", "Circumscribed margin");                        // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Indistinct margin
		/// There is no clear demarcation of the entire margin or any portion of the margin from the
		/// surrounding tissue. The boundary is poorly defined, and the significant feature is that the
		/// mass is NOT CIRCUMSCRIBED. This is meant to include �echogenic rim� (historically, echogenic
		/// halo) because one may not be able to distinguish between an indistinct margin and
		/// one that displays an echogenic rim.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_IndistinctMargin = new Coding(System, "IndistinctMargin", "Indistinct margin");                                 // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Intraductal extension
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_IntraductalExtension = new Coding(System, "IntraductalExtension", "Intraductal extension");                     // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Irregular margin
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_IrregularMargin = new Coding(System, "IrregularMargin", "Irregular margin");                                    // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Lobulated margin
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_LobulatedMargin = new Coding(System, "LobulatedMargin", "Lobulated margin");                                    // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Macrolobulated margin
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MacrolobulatedMargin = new Coding(System, "MacrolobulatedMargin", "Macrolobulated margin");                     // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Microlobulated margin
		/// The margin is characterized by short-cycle undulations, but the significant feature is that
		/// the margin of the mass is NOT CIRCUMSCRIBED.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MicrolobulatedMargin = new Coding(System, "MicrolobulatedMargin", "Microlobulated margin");                     // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Non circumscribed margin
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_NonCircumscribedMargin = new Coding(System, "NonCircumscribedMargin", "Non circumscribed margin");              // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Obscured margin
		/// A margin that is hidden by superimposed or adjacent fibroglandular tissue. This is used
		/// primarily when some of the margin of the mass is circumscribed, but the rest (more than 25%) is hidden.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_ObscuredMargin = new Coding(System, "ObscuredMargin", "Obscured margin");                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Smooth margin
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_SmoothMargin = new Coding(System, "SmoothMargin", "Smooth margin");                                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Spiculated margin
		/// The margin is characterized by sharp lines radiating from the mass, often a sign of malignancy,
		/// but the significant feature is that the margin of the mass is NOT CIRCUMSCRIBED.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SpiculatedMargin = new Coding(System, "SpiculatedMargin", "Spiculated margin");                                 // CSBuilder.cs:515
		//- Fields
	}
}
