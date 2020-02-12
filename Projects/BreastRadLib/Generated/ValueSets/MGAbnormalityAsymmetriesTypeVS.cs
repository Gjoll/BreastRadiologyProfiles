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
	public class MGAbnormalityAsymmetriesTypeVS                                                                                                // CSBuilder.cs:331
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
		public TCoding Code_Asymmetry = new TCoding(MGAbnormalityAsymmetryTypeCS.Code_Asymmetry);                                                 // CSBuilder.cs:382
		public TCoding Code_AsymmetryFocal = new TCoding(MGAbnormalityAsymmetryTypeCS.Code_AsymmetryFocal);                                       // CSBuilder.cs:382
		public TCoding Code_AsymmetryGlobal = new TCoding(MGAbnormalityAsymmetryTypeCS.Code_AsymmetryGlobal);                                     // CSBuilder.cs:382
		public TCoding Code_DevelopingAsymmetry = new TCoding(MGAbnormalityAsymmetryTypeCS.Code_DevelopingAsymmetry);                             // CSBuilder.cs:382
		                                                                                                                                          // CSBuilder.cs:337
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:338
		                                                                                                                                          // CSBuilder.cs:339
		public MGAbnormalityAsymmetriesTypeVS()                                                                                                   // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:342
		    this.Members.Add(this.Code_Asymmetry);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_AsymmetryFocal);                                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_AsymmetryGlobal);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_DevelopingAsymmetry);                                                                                      // CSBuilder.cs:385
		}                                                                                                                                         // CSBuilder.cs:344
		//- Fields
	}
}
