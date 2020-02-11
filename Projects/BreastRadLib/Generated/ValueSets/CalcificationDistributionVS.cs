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
	public class CalcificationDistributionVS                                                                                                   // CSBuilder.cs:369
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:390
		{                                                                                                                                         // CSBuilder.cs:391
		    Coding value;                                                                                                                         // CSBuilder.cs:392
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:393
		    {                                                                                                                                     // CSBuilder.cs:394
		        return tCode.value;                                                                                                               // CSBuilder.cs:395
		    }                                                                                                                                     // CSBuilder.cs:396
		                                                                                                                                          // CSBuilder.cs:397
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:398
		    {                                                                                                                                     // CSBuilder.cs:399
		        this.value= value;                                                                                                                // CSBuilder.cs:400
		    }                                                                                                                                     // CSBuilder.cs:401
		}                                                                                                                                         // CSBuilder.cs:402
		public TCoding Code_ClusteredDistribution = new TCoding(CalcificationDistributionCS.Code_ClusteredDistribution);                          // CSBuilder.cs:420
		public TCoding Code_DiffuseDistribution = new TCoding(CalcificationDistributionCS.Code_DiffuseDistribution);                              // CSBuilder.cs:420
		public TCoding Code_GroupedDistribution = new TCoding(CalcificationDistributionCS.Code_GroupedDistribution);                              // CSBuilder.cs:420
		public TCoding Code_LinearDistribution = new TCoding(CalcificationDistributionCS.Code_LinearDistribution);                                // CSBuilder.cs:420
		public TCoding Code_RegionalDistribution = new TCoding(CalcificationDistributionCS.Code_RegionalDistribution);                            // CSBuilder.cs:420
		public TCoding Code_ScatteredDistribution = new TCoding(CalcificationDistributionCS.Code_ScatteredDistribution);                          // CSBuilder.cs:420
		public TCoding Code_SegmentalDistribution = new TCoding(CalcificationDistributionCS.Code_SegmentalDistribution);                          // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:375
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:376
		                                                                                                                                          // CSBuilder.cs:377
		public CalcificationDistributionVS()                                                                                                      // CSBuilder.cs:378
		{                                                                                                                                         // CSBuilder.cs:379
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:380
		    this.Members.Add(this.Code_ClusteredDistribution);                                                                                    // CSBuilder.cs:423
		    this.Members.Add(this.Code_DiffuseDistribution);                                                                                      // CSBuilder.cs:423
		    this.Members.Add(this.Code_GroupedDistribution);                                                                                      // CSBuilder.cs:423
		    this.Members.Add(this.Code_LinearDistribution);                                                                                       // CSBuilder.cs:423
		    this.Members.Add(this.Code_RegionalDistribution);                                                                                     // CSBuilder.cs:423
		    this.Members.Add(this.Code_ScatteredDistribution);                                                                                    // CSBuilder.cs:423
		    this.Members.Add(this.Code_SegmentalDistribution);                                                                                    // CSBuilder.cs:423
		}                                                                                                                                         // CSBuilder.cs:382
		//- Fields
	}
}
