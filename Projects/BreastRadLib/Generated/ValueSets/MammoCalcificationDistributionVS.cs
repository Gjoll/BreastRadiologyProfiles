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
	public class MammoCalcificationDistributionVS                                                                                              // CSBuilder.cs:403
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:424
		{                                                                                                                                         // CSBuilder.cs:425
		    Coding value;                                                                                                                         // CSBuilder.cs:426
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:427
		    {                                                                                                                                     // CSBuilder.cs:428
		        return tCode.value;                                                                                                               // CSBuilder.cs:429
		    }                                                                                                                                     // CSBuilder.cs:430
		                                                                                                                                          // CSBuilder.cs:431
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:432
		    {                                                                                                                                     // CSBuilder.cs:433
		        this.value= value;                                                                                                                // CSBuilder.cs:434
		    }                                                                                                                                     // CSBuilder.cs:435
		}                                                                                                                                         // CSBuilder.cs:436
		public TCoding Code_Diffuse = new TCoding(MammoCalcificationDistributionCS.Code_Diffuse);                                                 // CSBuilder.cs:454
		public TCoding Code_Regional = new TCoding(MammoCalcificationDistributionCS.Code_Regional);                                               // CSBuilder.cs:454
		public TCoding Code_Grouped = new TCoding(MammoCalcificationDistributionCS.Code_Grouped);                                                 // CSBuilder.cs:454
		public TCoding Code_Linear = new TCoding(MammoCalcificationDistributionCS.Code_Linear);                                                   // CSBuilder.cs:454
		public TCoding Code_Segmental = new TCoding(MammoCalcificationDistributionCS.Code_Segmental);                                             // CSBuilder.cs:454
		                                                                                                                                          // CSBuilder.cs:409
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:411
		public MammoCalcificationDistributionVS()                                                                                                 // CSBuilder.cs:412
		{                                                                                                                                         // CSBuilder.cs:413
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:414
		    this.Members.Add(this.Code_Diffuse);                                                                                                  // CSBuilder.cs:457
		    this.Members.Add(this.Code_Regional);                                                                                                 // CSBuilder.cs:457
		    this.Members.Add(this.Code_Grouped);                                                                                                  // CSBuilder.cs:457
		    this.Members.Add(this.Code_Linear);                                                                                                   // CSBuilder.cs:457
		    this.Members.Add(this.Code_Segmental);                                                                                                // CSBuilder.cs:457
		}                                                                                                                                         // CSBuilder.cs:416
		//- Fields
	}
}
