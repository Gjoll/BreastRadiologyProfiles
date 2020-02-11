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
	public class MarginVS                                                                                                                      // CSBuilder.cs:369
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
		public TCoding Code_AngularMargin = new TCoding(MarginCS.Code_AngularMargin);                                                             // CSBuilder.cs:420
		public TCoding Code_CircumscribedMargin = new TCoding(MarginCS.Code_CircumscribedMargin);                                                 // CSBuilder.cs:420
		public TCoding Code_IndistinctMargin = new TCoding(MarginCS.Code_IndistinctMargin);                                                       // CSBuilder.cs:420
		public TCoding Code_IntraductalExtension = new TCoding(MarginCS.Code_IntraductalExtension);                                               // CSBuilder.cs:420
		public TCoding Code_IrregularMargin = new TCoding(MarginCS.Code_IrregularMargin);                                                         // CSBuilder.cs:420
		public TCoding Code_LobulatedMargin = new TCoding(MarginCS.Code_LobulatedMargin);                                                         // CSBuilder.cs:420
		public TCoding Code_MacrolobulatedMargin = new TCoding(MarginCS.Code_MacrolobulatedMargin);                                               // CSBuilder.cs:420
		public TCoding Code_MicrolobulatedMargin = new TCoding(MarginCS.Code_MicrolobulatedMargin);                                               // CSBuilder.cs:420
		public TCoding Code_NonCircumscribedMargin = new TCoding(MarginCS.Code_NonCircumscribedMargin);                                           // CSBuilder.cs:420
		public TCoding Code_ObscuredMagin = new TCoding(MarginCS.Code_ObscuredMagin);                                                             // CSBuilder.cs:420
		public TCoding Code_SmoothMargin = new TCoding(MarginCS.Code_SmoothMargin);                                                               // CSBuilder.cs:420
		public TCoding Code_SpiculatedMargin = new TCoding(MarginCS.Code_SpiculatedMargin);                                                       // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:375
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:376
		                                                                                                                                          // CSBuilder.cs:377
		public MarginVS()                                                                                                                         // CSBuilder.cs:378
		{                                                                                                                                         // CSBuilder.cs:379
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:380
		    this.Members.Add(this.Code_AngularMargin);                                                                                            // CSBuilder.cs:423
		    this.Members.Add(this.Code_CircumscribedMargin);                                                                                      // CSBuilder.cs:423
		    this.Members.Add(this.Code_IndistinctMargin);                                                                                         // CSBuilder.cs:423
		    this.Members.Add(this.Code_IntraductalExtension);                                                                                     // CSBuilder.cs:423
		    this.Members.Add(this.Code_IrregularMargin);                                                                                          // CSBuilder.cs:423
		    this.Members.Add(this.Code_LobulatedMargin);                                                                                          // CSBuilder.cs:423
		    this.Members.Add(this.Code_MacrolobulatedMargin);                                                                                     // CSBuilder.cs:423
		    this.Members.Add(this.Code_MicrolobulatedMargin);                                                                                     // CSBuilder.cs:423
		    this.Members.Add(this.Code_NonCircumscribedMargin);                                                                                   // CSBuilder.cs:423
		    this.Members.Add(this.Code_ObscuredMagin);                                                                                            // CSBuilder.cs:423
		    this.Members.Add(this.Code_SmoothMargin);                                                                                             // CSBuilder.cs:423
		    this.Members.Add(this.Code_SpiculatedMargin);                                                                                         // CSBuilder.cs:423
		}                                                                                                                                         // CSBuilder.cs:382
		//- Fields
	}
}
