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
	public class MarginVS                                                                                                                      // CSBuilder.cs:336
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
		public TCoding Code_AngularMargin = new TCoding(MarginCS.Code_AngularMargin);                                                             // CSBuilder.cs:387
		public TCoding Code_CircumscribedMargin = new TCoding(MarginCS.Code_CircumscribedMargin);                                                 // CSBuilder.cs:387
		public TCoding Code_IndistinctMargin = new TCoding(MarginCS.Code_IndistinctMargin);                                                       // CSBuilder.cs:387
		public TCoding Code_IntraductalExtension = new TCoding(MarginCS.Code_IntraductalExtension);                                               // CSBuilder.cs:387
		public TCoding Code_IrregularMargin = new TCoding(MarginCS.Code_IrregularMargin);                                                         // CSBuilder.cs:387
		public TCoding Code_LobulatedMargin = new TCoding(MarginCS.Code_LobulatedMargin);                                                         // CSBuilder.cs:387
		public TCoding Code_MacrolobulatedMargin = new TCoding(MarginCS.Code_MacrolobulatedMargin);                                               // CSBuilder.cs:387
		public TCoding Code_MicrolobulatedMargin = new TCoding(MarginCS.Code_MicrolobulatedMargin);                                               // CSBuilder.cs:387
		public TCoding Code_NonCircumscribedMargin = new TCoding(MarginCS.Code_NonCircumscribedMargin);                                           // CSBuilder.cs:387
		public TCoding Code_ObscuredMargin = new TCoding(MarginCS.Code_ObscuredMargin);                                                           // CSBuilder.cs:387
		public TCoding Code_SmoothMargin = new TCoding(MarginCS.Code_SmoothMargin);                                                               // CSBuilder.cs:387
		public TCoding Code_SpiculatedMargin = new TCoding(MarginCS.Code_SpiculatedMargin);                                                       // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public MarginVS()                                                                                                                         // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(MarginCS.Code_AngularMargin);                                                                                        // CSBuilder.cs:390
		    this.Members.Add(MarginCS.Code_CircumscribedMargin);                                                                                  // CSBuilder.cs:390
		    this.Members.Add(MarginCS.Code_IndistinctMargin);                                                                                     // CSBuilder.cs:390
		    this.Members.Add(MarginCS.Code_IntraductalExtension);                                                                                 // CSBuilder.cs:390
		    this.Members.Add(MarginCS.Code_IrregularMargin);                                                                                      // CSBuilder.cs:390
		    this.Members.Add(MarginCS.Code_LobulatedMargin);                                                                                      // CSBuilder.cs:390
		    this.Members.Add(MarginCS.Code_MacrolobulatedMargin);                                                                                 // CSBuilder.cs:390
		    this.Members.Add(MarginCS.Code_MicrolobulatedMargin);                                                                                 // CSBuilder.cs:390
		    this.Members.Add(MarginCS.Code_NonCircumscribedMargin);                                                                               // CSBuilder.cs:390
		    this.Members.Add(MarginCS.Code_ObscuredMargin);                                                                                       // CSBuilder.cs:390
		    this.Members.Add(MarginCS.Code_SmoothMargin);                                                                                         // CSBuilder.cs:390
		    this.Members.Add(MarginCS.Code_SpiculatedMargin);                                                                                     // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
