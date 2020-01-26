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
	public class ConsistentWithQualifierVS                                                                                                     // CSBuilder.cs:361
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
		public TCoding Code_LikelyRepresents = new TCoding(ConsistentWithQualifierCS.Code_LikelyRepresents);                                      // CSBuilder.cs:412
		public TCoding Code_MostLikely = new TCoding(ConsistentWithQualifierCS.Code_MostLikely);                                                  // CSBuilder.cs:412
		public TCoding Code_Resembles = new TCoding(ConsistentWithQualifierCS.Code_Resembles);                                                    // CSBuilder.cs:412
		public TCoding Code_WDifferentialDiagnosis = new TCoding(ConsistentWithQualifierCS.Code_WDifferentialDiagnosis);                          // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:367
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:368
		                                                                                                                                          // CSBuilder.cs:369
		public ConsistentWithQualifierVS()                                                                                                        // CSBuilder.cs:370
		{                                                                                                                                         // CSBuilder.cs:371
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:372
		    this.Members.Add(this.Code_LikelyRepresents);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_MostLikely);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_Resembles);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_WDifferentialDiagnosis);                                                                                   // CSBuilder.cs:415
		}                                                                                                                                         // CSBuilder.cs:374
		//- Fields
	}
}
