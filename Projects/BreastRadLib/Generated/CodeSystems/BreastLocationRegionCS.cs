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
	public class BreastLocationRegionCS                                                                                                        // CSBuilder.cs:485
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/BreastLocationRegionCS";                                        // CSBuilder.cs:489
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Central region of the breast (behind nipple)
		/// </summary>
		public static Coding Code_Central = new Coding(System, "Central", "Central Region");                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Central location in the anterior third of the breast close to the nipple
		/// </summary>
		public static Coding Code_RetroaReolar = new Coding(System, "RetroaReolar", "RetroaReolar Region");                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Upper outer region location adjacent to the axilla but within the breast mound
		/// </summary>
		public static Coding Code_AxillaryTail = new Coding(System, "AxillaryTail", "AxillaryTail Region");                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Upper outer region location in the axilla
		/// </summary>
		public static Coding Code_Axilla = new Coding(System, "Axilla", "Axilla Region");                                                         // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Axilla Region I
		/// </summary>
		public static Coding Code_AxillaI = new Coding(System, "AxillaI", "Axilla Region I");                                                     // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Axilla Region II
		/// </summary>
		public static Coding Code_AxillaII = new Coding(System, "AxillaII", "Axilla Region II");                                                  // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Axilla Region III
		/// </summary>
		public static Coding Code_AxillaIII = new Coding(System, "AxillaIII", "Axilla Region III");                                               // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// Inframammary Fold
		/// </summary>
		public static Coding Code_InframammaryFold = new Coding(System, "InframammaryFold", "Inframammary Fold Region");                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// In Skin
		/// </summary>
		public static Coding Code_InSkin = new Coding(System, "InSkin", "In Skin");                                                               // CSBuilder.cs:515
		//- Fields
	}
}
