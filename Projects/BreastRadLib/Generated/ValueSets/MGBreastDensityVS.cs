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
	public class MGBreastDensityVS                                                                                                             // CSBuilder.cs:361
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
		public TCoding Code_Fatty = new TCoding(MGBreastDensityCS.Code_Fatty);                                                                    // CSBuilder.cs:412
		public TCoding Code_Fibroglandular = new TCoding(MGBreastDensityCS.Code_Fibroglandular);                                                  // CSBuilder.cs:412
		public TCoding Code_HeterogeneouslyDense = new TCoding(MGBreastDensityCS.Code_HeterogeneouslyDense);                                      // CSBuilder.cs:412
		public TCoding Code_ExtremelyDense = new TCoding(MGBreastDensityCS.Code_ExtremelyDense);                                                  // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:367
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:368
		                                                                                                                                          // CSBuilder.cs:369
		public MGBreastDensityVS()                                                                                                                // CSBuilder.cs:370
		{                                                                                                                                         // CSBuilder.cs:371
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:372
		    this.Members.Add(this.Code_Fatty);                                                                                                    // CSBuilder.cs:415
		    this.Members.Add(this.Code_Fibroglandular);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_HeterogeneouslyDense);                                                                                     // CSBuilder.cs:415
		    this.Members.Add(this.Code_ExtremelyDense);                                                                                           // CSBuilder.cs:415
		}                                                                                                                                         // CSBuilder.cs:374
		//- Fields
	}
}
