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
	public class MarginVS                                                                                                                      // CSBuilder.cs:413
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:434
		{                                                                                                                                         // CSBuilder.cs:435
		    Coding value;                                                                                                                         // CSBuilder.cs:436
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:437
		    {                                                                                                                                     // CSBuilder.cs:438
		        return tCode.value;                                                                                                               // CSBuilder.cs:439
		    }                                                                                                                                     // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:441
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:442
		    {                                                                                                                                     // CSBuilder.cs:443
		        this.value= value;                                                                                                                // CSBuilder.cs:444
		    }                                                                                                                                     // CSBuilder.cs:445
		}                                                                                                                                         // CSBuilder.cs:446
		public TCoding Code_AngularMargin = new TCoding(MarginCS.Code_AngularMargin);                                                             // CSBuilder.cs:464
		public TCoding Code_CircumscribedMargin = new TCoding(MarginCS.Code_CircumscribedMargin);                                                 // CSBuilder.cs:464
		public TCoding Code_IndistinctMargin = new TCoding(MarginCS.Code_IndistinctMargin);                                                       // CSBuilder.cs:464
		public TCoding Code_IntraductalExtension = new TCoding(MarginCS.Code_IntraductalExtension);                                               // CSBuilder.cs:464
		public TCoding Code_IrregularMargin = new TCoding(MarginCS.Code_IrregularMargin);                                                         // CSBuilder.cs:464
		public TCoding Code_LobulatedMargin = new TCoding(MarginCS.Code_LobulatedMargin);                                                         // CSBuilder.cs:464
		public TCoding Code_MacrolobulatedMargin = new TCoding(MarginCS.Code_MacrolobulatedMargin);                                               // CSBuilder.cs:464
		public TCoding Code_MicrolobulatedMargin = new TCoding(MarginCS.Code_MicrolobulatedMargin);                                               // CSBuilder.cs:464
		public TCoding Code_NonCircumscribedMargin = new TCoding(MarginCS.Code_NonCircumscribedMargin);                                           // CSBuilder.cs:464
		public TCoding Code_ObscuredMargin = new TCoding(MarginCS.Code_ObscuredMargin);                                                           // CSBuilder.cs:464
		public TCoding Code_SmoothMargin = new TCoding(MarginCS.Code_SmoothMargin);                                                               // CSBuilder.cs:464
		public TCoding Code_SpiculatedMargin = new TCoding(MarginCS.Code_SpiculatedMargin);                                                       // CSBuilder.cs:464
		                                                                                                                                          // CSBuilder.cs:419
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:421
		public MarginVS()                                                                                                                         // CSBuilder.cs:422
		{                                                                                                                                         // CSBuilder.cs:423
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:424
		    this.Members.Add(this.Code_AngularMargin);                                                                                            // CSBuilder.cs:467
		    this.Members.Add(this.Code_CircumscribedMargin);                                                                                      // CSBuilder.cs:467
		    this.Members.Add(this.Code_IndistinctMargin);                                                                                         // CSBuilder.cs:467
		    this.Members.Add(this.Code_IntraductalExtension);                                                                                     // CSBuilder.cs:467
		    this.Members.Add(this.Code_IrregularMargin);                                                                                          // CSBuilder.cs:467
		    this.Members.Add(this.Code_LobulatedMargin);                                                                                          // CSBuilder.cs:467
		    this.Members.Add(this.Code_MacrolobulatedMargin);                                                                                     // CSBuilder.cs:467
		    this.Members.Add(this.Code_MicrolobulatedMargin);                                                                                     // CSBuilder.cs:467
		    this.Members.Add(this.Code_NonCircumscribedMargin);                                                                                   // CSBuilder.cs:467
		    this.Members.Add(this.Code_ObscuredMargin);                                                                                           // CSBuilder.cs:467
		    this.Members.Add(this.Code_SmoothMargin);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_SpiculatedMargin);                                                                                         // CSBuilder.cs:467
		}                                                                                                                                         // CSBuilder.cs:426
		//- Fields
	}
}
