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
	public class MammoCalcificationDistributionVS                                                                                              // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that explicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:357
		{                                                                                                                                         // CSBuilder.cs:358
		    Coding value;                                                                                                                         // CSBuilder.cs:359
		    public static explicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        return tCode.value;                                                                                                               // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		                                                                                                                                          // CSBuilder.cs:364
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:365
		    {                                                                                                                                     // CSBuilder.cs:366
		        this.value= value;                                                                                                                // CSBuilder.cs:367
		    }                                                                                                                                     // CSBuilder.cs:368
		}                                                                                                                                         // CSBuilder.cs:369
		public TCoding Code_Diffuse = new TCoding(MammoCalcificationDistributionCS.Code_Diffuse);                                                 // CSBuilder.cs:387
		public TCoding Code_Regional = new TCoding(MammoCalcificationDistributionCS.Code_Regional);                                               // CSBuilder.cs:387
		public TCoding Code_Grouped = new TCoding(MammoCalcificationDistributionCS.Code_Grouped);                                                 // CSBuilder.cs:387
		public TCoding Code_Linear = new TCoding(MammoCalcificationDistributionCS.Code_Linear);                                                   // CSBuilder.cs:387
		public TCoding Code_Segmental = new TCoding(MammoCalcificationDistributionCS.Code_Segmental);                                             // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public MammoCalcificationDistributionVS()                                                                                                 // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(MammoCalcificationDistributionCS.Code_Diffuse);                                                                      // CSBuilder.cs:390
		    this.Members.Add(MammoCalcificationDistributionCS.Code_Regional);                                                                     // CSBuilder.cs:390
		    this.Members.Add(MammoCalcificationDistributionCS.Code_Grouped);                                                                      // CSBuilder.cs:390
		    this.Members.Add(MammoCalcificationDistributionCS.Code_Linear);                                                                       // CSBuilder.cs:390
		    this.Members.Add(MammoCalcificationDistributionCS.Code_Segmental);                                                                    // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
