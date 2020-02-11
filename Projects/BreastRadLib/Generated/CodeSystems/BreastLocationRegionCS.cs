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
	public class BreastLocationRegionCS                                                                                                        // CSBuilder.cs:391
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/BreastLocationRegionCS";                                        // CSBuilder.cs:395
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// The axilla (also, armpit, underarm or oxter) is the area on the human body directly under the joint where the arm connects to the shoulder.
		/// It also contains many sweat glands.
		/// -- https://en.wikipedia.org/wiki/Axilla
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_Axilla = new Coding(System, "Axilla", "Axilla");                                                                // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// The tail of Spence (Spence's tail, axillary process, axillary tail) is an extension of the tissue of the breast that extends into the axilla.
		/// It is actually an extension of the upper lateral quadrant of the breast.
		/// It passes into the axilla through an opening in the deep fascia called foramen of Langer.
		/// -- https://en.wikipedia.org/wiki/Tail_of_Spence
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_AxillaryTail = new Coding(System, "AxillaryTail", "Axillary tail");                                             // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// </summary>
		public static Coding Code_AxillaI = new Coding(System, "AxillaI", "Axilla I");                                                            // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// </summary>
		public static Coding Code_AxillaII = new Coding(System, "AxillaII", "Axilla II");                                                         // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// </summary>
		public static Coding Code_AxillaIII = new Coding(System, "AxillaIII", "Axilla III");                                                      // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_InframammaryFold = new Coding(System, "InframammaryFold", "Inframammary fold");                                 // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// Located within the skin.
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_InSkin = new Coding(System, "InSkin", "In skin");                                                               // CSBuilder.cs:421
		                                                                                                                                          // CSBuilder.cs:407
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CentralToNipple = new Coding(System, "CentralToNipple", "Central to nipple");                                   // CSBuilder.cs:421
		//- Fields
	}
}
