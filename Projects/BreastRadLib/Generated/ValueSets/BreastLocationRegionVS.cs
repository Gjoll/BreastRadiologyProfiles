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
	public class BreastLocationRegionVS                                                                                                        // CSBuilder.cs:331
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:352
		{                                                                                                                                         // CSBuilder.cs:353
		    Coding value;                                                                                                                         // CSBuilder.cs:354
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:355
		    {                                                                                                                                     // CSBuilder.cs:356
		        return tCode.value;                                                                                                               // CSBuilder.cs:357
		    }                                                                                                                                     // CSBuilder.cs:358
		                                                                                                                                          // CSBuilder.cs:359
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        this.value= value;                                                                                                                // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		}                                                                                                                                         // CSBuilder.cs:364
		public TCoding Code_Axilla = new TCoding(BreastLocationRegionCS.Code_Axilla);                                                             // CSBuilder.cs:382
		public TCoding Code_AxillaryTail = new TCoding(BreastLocationRegionCS.Code_AxillaryTail);                                                 // CSBuilder.cs:382
		public TCoding Code_AxillaI = new TCoding(BreastLocationRegionCS.Code_AxillaI);                                                           // CSBuilder.cs:382
		public TCoding Code_AxillaII = new TCoding(BreastLocationRegionCS.Code_AxillaII);                                                         // CSBuilder.cs:382
		public TCoding Code_AxillaIII = new TCoding(BreastLocationRegionCS.Code_AxillaIII);                                                       // CSBuilder.cs:382
		public TCoding Code_InframammaryFold = new TCoding(BreastLocationRegionCS.Code_InframammaryFold);                                         // CSBuilder.cs:382
		public TCoding Code_InSkin = new TCoding(BreastLocationRegionCS.Code_InSkin);                                                             // CSBuilder.cs:382
		public TCoding Code_CentralToNipple = new TCoding(BreastLocationRegionCS.Code_CentralToNipple);                                           // CSBuilder.cs:382
		                                                                                                                                          // CSBuilder.cs:337
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:338
		                                                                                                                                          // CSBuilder.cs:339
		public BreastLocationRegionVS()                                                                                                           // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:342
		    this.Members.Add(this.Code_Axilla);                                                                                                   // CSBuilder.cs:385
		    this.Members.Add(this.Code_AxillaryTail);                                                                                             // CSBuilder.cs:385
		    this.Members.Add(this.Code_AxillaI);                                                                                                  // CSBuilder.cs:385
		    this.Members.Add(this.Code_AxillaII);                                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_AxillaIII);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_InframammaryFold);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_InSkin);                                                                                                   // CSBuilder.cs:385
		    this.Members.Add(this.Code_CentralToNipple);                                                                                          // CSBuilder.cs:385
		}                                                                                                                                         // CSBuilder.cs:344
		//- Fields
	}
}
