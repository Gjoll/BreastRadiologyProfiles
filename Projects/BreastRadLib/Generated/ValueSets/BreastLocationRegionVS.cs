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
	public class BreastLocationRegionVS                                                                                                        // CSBuilder.cs:369
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:390
		{                                                                                                                                         // CSBuilder.cs:391
		    Coding value;                                                                                                                         // CSBuilder.cs:392
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:393
		    {                                                                                                                                     // CSBuilder.cs:394
		        return tCode.value;                                                                                                               // CSBuilder.cs:395
		    }                                                                                                                                     // CSBuilder.cs:396
		                                                                                                                                          // CSBuilder.cs:397
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:398
		    {                                                                                                                                     // CSBuilder.cs:399
		        this.value= value;                                                                                                                // CSBuilder.cs:400
		    }                                                                                                                                     // CSBuilder.cs:401
		}                                                                                                                                         // CSBuilder.cs:402
		public TCoding Code_Axilla = new TCoding(BreastLocationRegionCS.Code_Axilla);                                                             // CSBuilder.cs:420
		public TCoding Code_AxillaryTail = new TCoding(BreastLocationRegionCS.Code_AxillaryTail);                                                 // CSBuilder.cs:420
		public TCoding Code_AxillaI = new TCoding(BreastLocationRegionCS.Code_AxillaI);                                                           // CSBuilder.cs:420
		public TCoding Code_AxillaII = new TCoding(BreastLocationRegionCS.Code_AxillaII);                                                         // CSBuilder.cs:420
		public TCoding Code_AxillaIII = new TCoding(BreastLocationRegionCS.Code_AxillaIII);                                                       // CSBuilder.cs:420
		public TCoding Code_InframammaryFold = new TCoding(BreastLocationRegionCS.Code_InframammaryFold);                                         // CSBuilder.cs:420
		public TCoding Code_InSkin = new TCoding(BreastLocationRegionCS.Code_InSkin);                                                             // CSBuilder.cs:420
		public TCoding Code_CentralToNipple = new TCoding(BreastLocationRegionCS.Code_CentralToNipple);                                           // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:375
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:376
		                                                                                                                                          // CSBuilder.cs:377
		public BreastLocationRegionVS()                                                                                                           // CSBuilder.cs:378
		{                                                                                                                                         // CSBuilder.cs:379
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:380
		    this.Members.Add(this.Code_Axilla);                                                                                                   // CSBuilder.cs:423
		    this.Members.Add(this.Code_AxillaryTail);                                                                                             // CSBuilder.cs:423
		    this.Members.Add(this.Code_AxillaI);                                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_AxillaII);                                                                                                 // CSBuilder.cs:423
		    this.Members.Add(this.Code_AxillaIII);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_InframammaryFold);                                                                                         // CSBuilder.cs:423
		    this.Members.Add(this.Code_InSkin);                                                                                                   // CSBuilder.cs:423
		    this.Members.Add(this.Code_CentralToNipple);                                                                                          // CSBuilder.cs:423
		}                                                                                                                                         // CSBuilder.cs:382
		//- Fields
	}
}
