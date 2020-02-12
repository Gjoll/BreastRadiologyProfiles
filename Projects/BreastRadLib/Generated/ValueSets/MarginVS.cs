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
	public class MarginVS                                                                                                                      // CSBuilder.cs:338
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:359
		{                                                                                                                                         // CSBuilder.cs:360
		    Coding value;                                                                                                                         // CSBuilder.cs:361
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:362
		    {                                                                                                                                     // CSBuilder.cs:363
		        return tCode.value;                                                                                                               // CSBuilder.cs:364
		    }                                                                                                                                     // CSBuilder.cs:365
		                                                                                                                                          // CSBuilder.cs:366
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:367
		    {                                                                                                                                     // CSBuilder.cs:368
		        this.value= value;                                                                                                                // CSBuilder.cs:369
		    }                                                                                                                                     // CSBuilder.cs:370
		}                                                                                                                                         // CSBuilder.cs:371
		public TCoding Code_AngularMargin = new TCoding(MarginCS.Code_AngularMargin);                                                             // CSBuilder.cs:389
		public TCoding Code_CircumscribedMargin = new TCoding(MarginCS.Code_CircumscribedMargin);                                                 // CSBuilder.cs:389
		public TCoding Code_IndistinctMargin = new TCoding(MarginCS.Code_IndistinctMargin);                                                       // CSBuilder.cs:389
		public TCoding Code_IntraductalExtension = new TCoding(MarginCS.Code_IntraductalExtension);                                               // CSBuilder.cs:389
		public TCoding Code_IrregularMargin = new TCoding(MarginCS.Code_IrregularMargin);                                                         // CSBuilder.cs:389
		public TCoding Code_LobulatedMargin = new TCoding(MarginCS.Code_LobulatedMargin);                                                         // CSBuilder.cs:389
		public TCoding Code_MacrolobulatedMargin = new TCoding(MarginCS.Code_MacrolobulatedMargin);                                               // CSBuilder.cs:389
		public TCoding Code_MicrolobulatedMargin = new TCoding(MarginCS.Code_MicrolobulatedMargin);                                               // CSBuilder.cs:389
		public TCoding Code_NonCircumscribedMargin = new TCoding(MarginCS.Code_NonCircumscribedMargin);                                           // CSBuilder.cs:389
		public TCoding Code_ObscuredMagin = new TCoding(MarginCS.Code_ObscuredMagin);                                                             // CSBuilder.cs:389
		public TCoding Code_SmoothMargin = new TCoding(MarginCS.Code_SmoothMargin);                                                               // CSBuilder.cs:389
		public TCoding Code_SpiculatedMargin = new TCoding(MarginCS.Code_SpiculatedMargin);                                                       // CSBuilder.cs:389
		                                                                                                                                          // CSBuilder.cs:344
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:345
		                                                                                                                                          // CSBuilder.cs:346
		public MarginVS()                                                                                                                         // CSBuilder.cs:347
		{                                                                                                                                         // CSBuilder.cs:348
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:349
		    this.Members.Add(this.Code_AngularMargin);                                                                                            // CSBuilder.cs:392
		    this.Members.Add(this.Code_CircumscribedMargin);                                                                                      // CSBuilder.cs:392
		    this.Members.Add(this.Code_IndistinctMargin);                                                                                         // CSBuilder.cs:392
		    this.Members.Add(this.Code_IntraductalExtension);                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_IrregularMargin);                                                                                          // CSBuilder.cs:392
		    this.Members.Add(this.Code_LobulatedMargin);                                                                                          // CSBuilder.cs:392
		    this.Members.Add(this.Code_MacrolobulatedMargin);                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_MicrolobulatedMargin);                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_NonCircumscribedMargin);                                                                                   // CSBuilder.cs:392
		    this.Members.Add(this.Code_ObscuredMagin);                                                                                            // CSBuilder.cs:392
		    this.Members.Add(this.Code_SmoothMargin);                                                                                             // CSBuilder.cs:392
		    this.Members.Add(this.Code_SpiculatedMargin);                                                                                         // CSBuilder.cs:392
		}                                                                                                                                         // CSBuilder.cs:351
		//- Fields
	}
}
