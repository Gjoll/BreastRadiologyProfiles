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
	public class MGAbnormalityAsymmetriesTypeVS                                                                                                // CSBuilder.cs:338
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
		public TCoding Code_Asymmetry = new TCoding(MGAbnormalityAsymmetryTypeCS.Code_Asymmetry);                                                 // CSBuilder.cs:389
		public TCoding Code_AsymmetryFocal = new TCoding(MGAbnormalityAsymmetryTypeCS.Code_AsymmetryFocal);                                       // CSBuilder.cs:389
		public TCoding Code_AsymmetryGlobal = new TCoding(MGAbnormalityAsymmetryTypeCS.Code_AsymmetryGlobal);                                     // CSBuilder.cs:389
		public TCoding Code_DevelopingAsymmetry = new TCoding(MGAbnormalityAsymmetryTypeCS.Code_DevelopingAsymmetry);                             // CSBuilder.cs:389
		                                                                                                                                          // CSBuilder.cs:344
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:345
		                                                                                                                                          // CSBuilder.cs:346
		public MGAbnormalityAsymmetriesTypeVS()                                                                                                   // CSBuilder.cs:347
		{                                                                                                                                         // CSBuilder.cs:348
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:349
		    this.Members.Add(this.Code_Asymmetry);                                                                                                // CSBuilder.cs:392
		    this.Members.Add(this.Code_AsymmetryFocal);                                                                                           // CSBuilder.cs:392
		    this.Members.Add(this.Code_AsymmetryGlobal);                                                                                          // CSBuilder.cs:392
		    this.Members.Add(this.Code_DevelopingAsymmetry);                                                                                      // CSBuilder.cs:392
		}                                                                                                                                         // CSBuilder.cs:351
		//- Fields
	}
}
