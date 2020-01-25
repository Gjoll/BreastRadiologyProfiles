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
	public class MammoCalcificationTypeVS                                                                                                      // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:357
		{                                                                                                                                         // CSBuilder.cs:358
		    Coding value;                                                                                                                         // CSBuilder.cs:359
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        return tCode.value;                                                                                                               // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		                                                                                                                                          // CSBuilder.cs:364
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:365
		    {                                                                                                                                     // CSBuilder.cs:366
		        this.value= value;                                                                                                                // CSBuilder.cs:367
		    }                                                                                                                                     // CSBuilder.cs:368
		}                                                                                                                                         // CSBuilder.cs:369
		public TCoding Code_Skin = new TCoding(MammoCalcificationTypeCS.Code_Skin);                                                               // CSBuilder.cs:387
		public TCoding Code_Vascular = new TCoding(MammoCalcificationTypeCS.Code_Vascular);                                                       // CSBuilder.cs:387
		public TCoding Code_Coarse = new TCoding(MammoCalcificationTypeCS.Code_Coarse);                                                           // CSBuilder.cs:387
		public TCoding Code_LargeRodLike = new TCoding(MammoCalcificationTypeCS.Code_LargeRodLike);                                               // CSBuilder.cs:387
		public TCoding Code_Round = new TCoding(MammoCalcificationTypeCS.Code_Round);                                                             // CSBuilder.cs:387
		public TCoding Code_Rim = new TCoding(MammoCalcificationTypeCS.Code_Rim);                                                                 // CSBuilder.cs:387
		public TCoding Code_Dystrophic = new TCoding(MammoCalcificationTypeCS.Code_Dystrophic);                                                   // CSBuilder.cs:387
		public TCoding Code_MilkOfCalcium = new TCoding(MammoCalcificationTypeCS.Code_MilkOfCalcium);                                             // CSBuilder.cs:387
		public TCoding Code_Suture = new TCoding(MammoCalcificationTypeCS.Code_Suture);                                                           // CSBuilder.cs:387
		public TCoding Code_Amorphous = new TCoding(MammoCalcificationTypeCS.Code_Amorphous);                                                     // CSBuilder.cs:387
		public TCoding Code_CoarseHeterogeneous = new TCoding(MammoCalcificationTypeCS.Code_CoarseHeterogeneous);                                 // CSBuilder.cs:387
		public TCoding Code_FinePleomorphic = new TCoding(MammoCalcificationTypeCS.Code_FinePleomorphic);                                         // CSBuilder.cs:387
		public TCoding Code_FineLinear = new TCoding(MammoCalcificationTypeCS.Code_FineLinear);                                                   // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public MammoCalcificationTypeVS()                                                                                                         // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(this.Code_Skin);                                                                                                     // CSBuilder.cs:390
		    this.Members.Add(this.Code_Vascular);                                                                                                 // CSBuilder.cs:390
		    this.Members.Add(this.Code_Coarse);                                                                                                   // CSBuilder.cs:390
		    this.Members.Add(this.Code_LargeRodLike);                                                                                             // CSBuilder.cs:390
		    this.Members.Add(this.Code_Round);                                                                                                    // CSBuilder.cs:390
		    this.Members.Add(this.Code_Rim);                                                                                                      // CSBuilder.cs:390
		    this.Members.Add(this.Code_Dystrophic);                                                                                               // CSBuilder.cs:390
		    this.Members.Add(this.Code_MilkOfCalcium);                                                                                            // CSBuilder.cs:390
		    this.Members.Add(this.Code_Suture);                                                                                                   // CSBuilder.cs:390
		    this.Members.Add(this.Code_Amorphous);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_CoarseHeterogeneous);                                                                                      // CSBuilder.cs:390
		    this.Members.Add(this.Code_FinePleomorphic);                                                                                          // CSBuilder.cs:390
		    this.Members.Add(this.Code_FineLinear);                                                                                               // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
