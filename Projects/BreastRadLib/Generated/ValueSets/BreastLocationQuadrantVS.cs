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
	public class BreastLocationQuadrantVS                                                                                                      // CSBuilder.cs:369
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
		public TCoding Code_InferiorMedialQuadrent = new TCoding(BreastLocationQuadrantCS.Code_InferiorMedialQuadrent);                           // CSBuilder.cs:420
		public TCoding Code_InferiorLateralQuadrent = new TCoding(BreastLocationQuadrantCS.Code_InferiorLateralQuadrent);                         // CSBuilder.cs:420
		public TCoding Code_SuperiorMedialQuadrent = new TCoding(BreastLocationQuadrantCS.Code_SuperiorMedialQuadrent);                           // CSBuilder.cs:420
		public TCoding Code_SuperiorLateralQuadrent = new TCoding(BreastLocationQuadrantCS.Code_SuperiorLateralQuadrent);                         // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:375
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:376
		                                                                                                                                          // CSBuilder.cs:377
		public BreastLocationQuadrantVS()                                                                                                         // CSBuilder.cs:378
		{                                                                                                                                         // CSBuilder.cs:379
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:380
		    this.Members.Add(this.Code_InferiorMedialQuadrent);                                                                                   // CSBuilder.cs:423
		    this.Members.Add(this.Code_InferiorLateralQuadrent);                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_SuperiorMedialQuadrent);                                                                                   // CSBuilder.cs:423
		    this.Members.Add(this.Code_SuperiorLateralQuadrent);                                                                                  // CSBuilder.cs:423
		}                                                                                                                                         // CSBuilder.cs:382
		//- Fields
	}
}
