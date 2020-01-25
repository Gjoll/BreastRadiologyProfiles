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
	public class BreastLocationRegionVS                                                                                                        // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that explicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:357
		{                                                                                                                                         // CSBuilder.cs:358
		    Coding value;                                                                                                                         // CSBuilder.cs:359
		    public static explicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        return tCode.value;                                                                                                               // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		                                                                                                                                          // CSBuilder.cs:364
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:365
		    {                                                                                                                                     // CSBuilder.cs:366
		        this.value= value;                                                                                                                // CSBuilder.cs:367
		    }                                                                                                                                     // CSBuilder.cs:368
		}                                                                                                                                         // CSBuilder.cs:369
		public TCoding Code_Central = new TCoding(BreastLocationRegionCS.Code_Central);                                                           // CSBuilder.cs:387
		public TCoding Code_RetroaReolar = new TCoding(BreastLocationRegionCS.Code_RetroaReolar);                                                 // CSBuilder.cs:387
		public TCoding Code_AxillaryTail = new TCoding(BreastLocationRegionCS.Code_AxillaryTail);                                                 // CSBuilder.cs:387
		public TCoding Code_Axilla = new TCoding(BreastLocationRegionCS.Code_Axilla);                                                             // CSBuilder.cs:387
		public TCoding Code_AxillaI = new TCoding(BreastLocationRegionCS.Code_AxillaI);                                                           // CSBuilder.cs:387
		public TCoding Code_AxillaII = new TCoding(BreastLocationRegionCS.Code_AxillaII);                                                         // CSBuilder.cs:387
		public TCoding Code_AxillaIII = new TCoding(BreastLocationRegionCS.Code_AxillaIII);                                                       // CSBuilder.cs:387
		public TCoding Code_InframammaryFold = new TCoding(BreastLocationRegionCS.Code_InframammaryFold);                                         // CSBuilder.cs:387
		public TCoding Code_InSkin = new TCoding(BreastLocationRegionCS.Code_InSkin);                                                             // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public BreastLocationRegionVS()                                                                                                           // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(BreastLocationRegionCS.Code_Central);                                                                                // CSBuilder.cs:390
		    this.Members.Add(BreastLocationRegionCS.Code_RetroaReolar);                                                                           // CSBuilder.cs:390
		    this.Members.Add(BreastLocationRegionCS.Code_AxillaryTail);                                                                           // CSBuilder.cs:390
		    this.Members.Add(BreastLocationRegionCS.Code_Axilla);                                                                                 // CSBuilder.cs:390
		    this.Members.Add(BreastLocationRegionCS.Code_AxillaI);                                                                                // CSBuilder.cs:390
		    this.Members.Add(BreastLocationRegionCS.Code_AxillaII);                                                                               // CSBuilder.cs:390
		    this.Members.Add(BreastLocationRegionCS.Code_AxillaIII);                                                                              // CSBuilder.cs:390
		    this.Members.Add(BreastLocationRegionCS.Code_InframammaryFold);                                                                       // CSBuilder.cs:390
		    this.Members.Add(BreastLocationRegionCS.Code_InSkin);                                                                                 // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
