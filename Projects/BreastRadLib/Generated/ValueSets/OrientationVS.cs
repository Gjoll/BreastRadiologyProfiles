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
	public class OrientationVS                                                                                                                 // CSBuilder.cs:331
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
		public TCoding Code_ParallelToSkin = new TCoding(OrientationCS.Code_ParallelToSkin);                                                      // CSBuilder.cs:382
		public TCoding Code_PerpendicularToSkin = new TCoding(OrientationCS.Code_PerpendicularToSkin);                                            // CSBuilder.cs:382
		public TCoding Code_TallerThanWide = new TCoding(OrientationCS.Code_TallerThanWide);                                                      // CSBuilder.cs:382
		public TCoding Code_WiderThanTall = new TCoding(OrientationCS.Code_WiderThanTall);                                                        // CSBuilder.cs:382
		                                                                                                                                          // CSBuilder.cs:337
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:338
		                                                                                                                                          // CSBuilder.cs:339
		public OrientationVS()                                                                                                                    // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:342
		    this.Members.Add(this.Code_ParallelToSkin);                                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_PerpendicularToSkin);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_TallerThanWide);                                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_WiderThanTall);                                                                                            // CSBuilder.cs:385
		}                                                                                                                                         // CSBuilder.cs:344
		//- Fields
	}
}
