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
	public class MarginVS                                                                                                                      // CSBuilder.cs:331
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
		public TCoding Code_AngularMargin = new TCoding(MarginCS.Code_AngularMargin);                                                             // CSBuilder.cs:382
		public TCoding Code_CircumscribedMargin = new TCoding(MarginCS.Code_CircumscribedMargin);                                                 // CSBuilder.cs:382
		public TCoding Code_IndistinctMargin = new TCoding(MarginCS.Code_IndistinctMargin);                                                       // CSBuilder.cs:382
		public TCoding Code_IntraductalExtension = new TCoding(MarginCS.Code_IntraductalExtension);                                               // CSBuilder.cs:382
		public TCoding Code_IrregularMargin = new TCoding(MarginCS.Code_IrregularMargin);                                                         // CSBuilder.cs:382
		public TCoding Code_LobulatedMargin = new TCoding(MarginCS.Code_LobulatedMargin);                                                         // CSBuilder.cs:382
		public TCoding Code_MacrolobulatedMargin = new TCoding(MarginCS.Code_MacrolobulatedMargin);                                               // CSBuilder.cs:382
		public TCoding Code_MicrolobulatedMargin = new TCoding(MarginCS.Code_MicrolobulatedMargin);                                               // CSBuilder.cs:382
		public TCoding Code_NonCircumscribedMargin = new TCoding(MarginCS.Code_NonCircumscribedMargin);                                           // CSBuilder.cs:382
		public TCoding Code_ObscuredMagin = new TCoding(MarginCS.Code_ObscuredMagin);                                                             // CSBuilder.cs:382
		public TCoding Code_SmoothMargin = new TCoding(MarginCS.Code_SmoothMargin);                                                               // CSBuilder.cs:382
		public TCoding Code_SpiculatedMargin = new TCoding(MarginCS.Code_SpiculatedMargin);                                                       // CSBuilder.cs:382
		                                                                                                                                          // CSBuilder.cs:337
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:338
		                                                                                                                                          // CSBuilder.cs:339
		public MarginVS()                                                                                                                         // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:342
		    this.Members.Add(this.Code_AngularMargin);                                                                                            // CSBuilder.cs:385
		    this.Members.Add(this.Code_CircumscribedMargin);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_IndistinctMargin);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_IntraductalExtension);                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_IrregularMargin);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_LobulatedMargin);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_MacrolobulatedMargin);                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_MicrolobulatedMargin);                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_NonCircumscribedMargin);                                                                                   // CSBuilder.cs:385
		    this.Members.Add(this.Code_ObscuredMagin);                                                                                            // CSBuilder.cs:385
		    this.Members.Add(this.Code_SmoothMargin);                                                                                             // CSBuilder.cs:385
		    this.Members.Add(this.Code_SpiculatedMargin);                                                                                         // CSBuilder.cs:385
		}                                                                                                                                         // CSBuilder.cs:344
		//- Fields
	}
}
