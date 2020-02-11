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
	public class MGDensityVS                                                                                                                   // CSBuilder.cs:319
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    Coding value;                                                                                                                         // CSBuilder.cs:342
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:343
		    {                                                                                                                                     // CSBuilder.cs:344
		        return tCode.value;                                                                                                               // CSBuilder.cs:345
		    }                                                                                                                                     // CSBuilder.cs:346
		                                                                                                                                          // CSBuilder.cs:347
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:348
		    {                                                                                                                                     // CSBuilder.cs:349
		        this.value= value;                                                                                                                // CSBuilder.cs:350
		    }                                                                                                                                     // CSBuilder.cs:351
		}                                                                                                                                         // CSBuilder.cs:352
		public TCoding Code_CentralLucent = new TCoding(MGDensityCS.Code_CentralLucent);                                                          // CSBuilder.cs:370
		public TCoding Code_EqualDensity = new TCoding(MGDensityCS.Code_EqualDensity);                                                            // CSBuilder.cs:370
		public TCoding Code_FatContaining = new TCoding(MGDensityCS.Code_FatContaining);                                                          // CSBuilder.cs:370
		public TCoding Code_HighDensity = new TCoding(MGDensityCS.Code_HighDensity);                                                              // CSBuilder.cs:370
		public TCoding Code_LowDensity = new TCoding(MGDensityCS.Code_LowDensity);                                                                // CSBuilder.cs:370
		                                                                                                                                          // CSBuilder.cs:325
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:326
		                                                                                                                                          // CSBuilder.cs:327
		public MGDensityVS()                                                                                                                      // CSBuilder.cs:328
		{                                                                                                                                         // CSBuilder.cs:329
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:330
		    this.Members.Add(this.Code_CentralLucent);                                                                                            // CSBuilder.cs:373
		    this.Members.Add(this.Code_EqualDensity);                                                                                             // CSBuilder.cs:373
		    this.Members.Add(this.Code_FatContaining);                                                                                            // CSBuilder.cs:373
		    this.Members.Add(this.Code_HighDensity);                                                                                              // CSBuilder.cs:373
		    this.Members.Add(this.Code_LowDensity);                                                                                               // CSBuilder.cs:373
		}                                                                                                                                         // CSBuilder.cs:332
		//- Fields
	}
}
