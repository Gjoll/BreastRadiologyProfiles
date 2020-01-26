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
	public class MGDensityVS                                                                                                                   // CSBuilder.cs:413
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
		public TCoding Code_HighDensity = new TCoding(MGDensityCS.Code_HighDensity);                                                              // CSBuilder.cs:464
		public TCoding Code_EqualDensity = new TCoding(MGDensityCS.Code_EqualDensity);                                                            // CSBuilder.cs:464
		public TCoding Code_LowDensity = new TCoding(MGDensityCS.Code_LowDensity);                                                                // CSBuilder.cs:464
		public TCoding Code_FatContaining = new TCoding(MGDensityCS.Code_FatContaining);                                                          // CSBuilder.cs:464
		                                                                                                                                          // CSBuilder.cs:419
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:421
		public MGDensityVS()                                                                                                                      // CSBuilder.cs:422
		{                                                                                                                                         // CSBuilder.cs:423
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:424
		    this.Members.Add(this.Code_HighDensity);                                                                                              // CSBuilder.cs:467
		    this.Members.Add(this.Code_EqualDensity);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_LowDensity);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_FatContaining);                                                                                            // CSBuilder.cs:467
		}                                                                                                                                         // CSBuilder.cs:426
		//- Fields
	}
}
