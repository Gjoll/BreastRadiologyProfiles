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
	public class BreastLocationQuadrantVS                                                                                                      // CSBuilder.cs:338
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
		public TCoding Code_InferiorMedialQuadrent = new TCoding(BreastLocationQuadrantCS.Code_InferiorMedialQuadrent);                           // CSBuilder.cs:389
		public TCoding Code_InferiorLateralQuadrent = new TCoding(BreastLocationQuadrantCS.Code_InferiorLateralQuadrent);                         // CSBuilder.cs:389
		public TCoding Code_SuperiorMedialQuadrent = new TCoding(BreastLocationQuadrantCS.Code_SuperiorMedialQuadrent);                           // CSBuilder.cs:389
		public TCoding Code_SuperiorLateralQuadrent = new TCoding(BreastLocationQuadrantCS.Code_SuperiorLateralQuadrent);                         // CSBuilder.cs:389
		                                                                                                                                          // CSBuilder.cs:344
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:345
		                                                                                                                                          // CSBuilder.cs:346
		public BreastLocationQuadrantVS()                                                                                                         // CSBuilder.cs:347
		{                                                                                                                                         // CSBuilder.cs:348
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:349
		    this.Members.Add(this.Code_InferiorMedialQuadrent);                                                                                   // CSBuilder.cs:392
		    this.Members.Add(this.Code_InferiorLateralQuadrent);                                                                                  // CSBuilder.cs:392
		    this.Members.Add(this.Code_SuperiorMedialQuadrent);                                                                                   // CSBuilder.cs:392
		    this.Members.Add(this.Code_SuperiorLateralQuadrent);                                                                                  // CSBuilder.cs:392
		}                                                                                                                                         // CSBuilder.cs:351
		//- Fields
	}
}
