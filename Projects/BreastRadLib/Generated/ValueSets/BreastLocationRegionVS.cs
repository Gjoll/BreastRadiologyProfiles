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
	public class BreastLocationRegionVS                                                                                                        // CSBuilder.cs:333
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:354
		{                                                                                                                                         // CSBuilder.cs:355
		    Coding value;                                                                                                                         // CSBuilder.cs:356
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:357
		    {                                                                                                                                     // CSBuilder.cs:358
		        return tCode.value;                                                                                                               // CSBuilder.cs:359
		    }                                                                                                                                     // CSBuilder.cs:360
		                                                                                                                                          // CSBuilder.cs:361
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:362
		    {                                                                                                                                     // CSBuilder.cs:363
		        this.value= value;                                                                                                                // CSBuilder.cs:364
		    }                                                                                                                                     // CSBuilder.cs:365
		}                                                                                                                                         // CSBuilder.cs:366
		public TCoding Code_Axilla = new TCoding(BreastLocationRegionCS.Code_Axilla);                                                             // CSBuilder.cs:384
		public TCoding Code_AxillaryTail = new TCoding(BreastLocationRegionCS.Code_AxillaryTail);                                                 // CSBuilder.cs:384
		public TCoding Code_AxillaI = new TCoding(BreastLocationRegionCS.Code_AxillaI);                                                           // CSBuilder.cs:384
		public TCoding Code_AxillaII = new TCoding(BreastLocationRegionCS.Code_AxillaII);                                                         // CSBuilder.cs:384
		public TCoding Code_AxillaIII = new TCoding(BreastLocationRegionCS.Code_AxillaIII);                                                       // CSBuilder.cs:384
		public TCoding Code_InframammaryFold = new TCoding(BreastLocationRegionCS.Code_InframammaryFold);                                         // CSBuilder.cs:384
		public TCoding Code_InSkin = new TCoding(BreastLocationRegionCS.Code_InSkin);                                                             // CSBuilder.cs:384
		public TCoding Code_CentralToNipple = new TCoding(BreastLocationRegionCS.Code_CentralToNipple);                                           // CSBuilder.cs:384
		                                                                                                                                          // CSBuilder.cs:339
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public BreastLocationRegionVS()                                                                                                           // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(this.Code_Axilla);                                                                                                   // CSBuilder.cs:387
		    this.Members.Add(this.Code_AxillaryTail);                                                                                             // CSBuilder.cs:387
		    this.Members.Add(this.Code_AxillaI);                                                                                                  // CSBuilder.cs:387
		    this.Members.Add(this.Code_AxillaII);                                                                                                 // CSBuilder.cs:387
		    this.Members.Add(this.Code_AxillaIII);                                                                                                // CSBuilder.cs:387
		    this.Members.Add(this.Code_InframammaryFold);                                                                                         // CSBuilder.cs:387
		    this.Members.Add(this.Code_InSkin);                                                                                                   // CSBuilder.cs:387
		    this.Members.Add(this.Code_CentralToNipple);                                                                                          // CSBuilder.cs:387
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
