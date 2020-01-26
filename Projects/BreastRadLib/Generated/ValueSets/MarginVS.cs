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
	public class MarginVS                                                                                                                      // CSBuilder.cs:361
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:382
		{                                                                                                                                         // CSBuilder.cs:383
		    Coding value;                                                                                                                         // CSBuilder.cs:384
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:385
		    {                                                                                                                                     // CSBuilder.cs:386
		        return tCode.value;                                                                                                               // CSBuilder.cs:387
		    }                                                                                                                                     // CSBuilder.cs:388
		                                                                                                                                          // CSBuilder.cs:389
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:390
		    {                                                                                                                                     // CSBuilder.cs:391
		        this.value= value;                                                                                                                // CSBuilder.cs:392
		    }                                                                                                                                     // CSBuilder.cs:393
		}                                                                                                                                         // CSBuilder.cs:394
		public TCoding Code_AngularMargin = new TCoding(MarginCS.Code_AngularMargin);                                                             // CSBuilder.cs:412
		public TCoding Code_CircumscribedMargin = new TCoding(MarginCS.Code_CircumscribedMargin);                                                 // CSBuilder.cs:412
		public TCoding Code_IndistinctMargin = new TCoding(MarginCS.Code_IndistinctMargin);                                                       // CSBuilder.cs:412
		public TCoding Code_IntraductalExtension = new TCoding(MarginCS.Code_IntraductalExtension);                                               // CSBuilder.cs:412
		public TCoding Code_IrregularMargin = new TCoding(MarginCS.Code_IrregularMargin);                                                         // CSBuilder.cs:412
		public TCoding Code_LobulatedMargin = new TCoding(MarginCS.Code_LobulatedMargin);                                                         // CSBuilder.cs:412
		public TCoding Code_MacrolobulatedMargin = new TCoding(MarginCS.Code_MacrolobulatedMargin);                                               // CSBuilder.cs:412
		public TCoding Code_MicrolobulatedMargin = new TCoding(MarginCS.Code_MicrolobulatedMargin);                                               // CSBuilder.cs:412
		public TCoding Code_NonCircumscribedMargin = new TCoding(MarginCS.Code_NonCircumscribedMargin);                                           // CSBuilder.cs:412
		public TCoding Code_ObscuredMargin = new TCoding(MarginCS.Code_ObscuredMargin);                                                           // CSBuilder.cs:412
		public TCoding Code_SmoothMargin = new TCoding(MarginCS.Code_SmoothMargin);                                                               // CSBuilder.cs:412
		public TCoding Code_SpiculatedMargin = new TCoding(MarginCS.Code_SpiculatedMargin);                                                       // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:367
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:368
		                                                                                                                                          // CSBuilder.cs:369
		public MarginVS()                                                                                                                         // CSBuilder.cs:370
		{                                                                                                                                         // CSBuilder.cs:371
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:372
		    this.Members.Add(this.Code_AngularMargin);                                                                                            // CSBuilder.cs:415
		    this.Members.Add(this.Code_CircumscribedMargin);                                                                                      // CSBuilder.cs:415
		    this.Members.Add(this.Code_IndistinctMargin);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_IntraductalExtension);                                                                                     // CSBuilder.cs:415
		    this.Members.Add(this.Code_IrregularMargin);                                                                                          // CSBuilder.cs:415
		    this.Members.Add(this.Code_LobulatedMargin);                                                                                          // CSBuilder.cs:415
		    this.Members.Add(this.Code_MacrolobulatedMargin);                                                                                     // CSBuilder.cs:415
		    this.Members.Add(this.Code_MicrolobulatedMargin);                                                                                     // CSBuilder.cs:415
		    this.Members.Add(this.Code_NonCircumscribedMargin);                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_ObscuredMargin);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_SmoothMargin);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_SpiculatedMargin);                                                                                         // CSBuilder.cs:415
		}                                                                                                                                         // CSBuilder.cs:374
		//- Fields
	}
}
