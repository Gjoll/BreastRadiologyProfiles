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
	public class MammoCalcificationTypeVS                                                                                                      // CSBuilder.cs:403
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
		public TCoding Code_Skin = new TCoding(MammoCalcificationTypeCS.Code_Skin);                                                               // CSBuilder.cs:454
		public TCoding Code_Vascular = new TCoding(MammoCalcificationTypeCS.Code_Vascular);                                                       // CSBuilder.cs:454
		public TCoding Code_Coarse = new TCoding(MammoCalcificationTypeCS.Code_Coarse);                                                           // CSBuilder.cs:454
		public TCoding Code_LargeRodLike = new TCoding(MammoCalcificationTypeCS.Code_LargeRodLike);                                               // CSBuilder.cs:454
		public TCoding Code_Round = new TCoding(MammoCalcificationTypeCS.Code_Round);                                                             // CSBuilder.cs:454
		public TCoding Code_Rim = new TCoding(MammoCalcificationTypeCS.Code_Rim);                                                                 // CSBuilder.cs:454
		public TCoding Code_Dystrophic = new TCoding(MammoCalcificationTypeCS.Code_Dystrophic);                                                   // CSBuilder.cs:454
		public TCoding Code_MilkOfCalcium = new TCoding(MammoCalcificationTypeCS.Code_MilkOfCalcium);                                             // CSBuilder.cs:454
		public TCoding Code_Suture = new TCoding(MammoCalcificationTypeCS.Code_Suture);                                                           // CSBuilder.cs:454
		public TCoding Code_Amorphous = new TCoding(MammoCalcificationTypeCS.Code_Amorphous);                                                     // CSBuilder.cs:454
		public TCoding Code_CoarseHeterogeneous = new TCoding(MammoCalcificationTypeCS.Code_CoarseHeterogeneous);                                 // CSBuilder.cs:454
		public TCoding Code_FinePleomorphic = new TCoding(MammoCalcificationTypeCS.Code_FinePleomorphic);                                         // CSBuilder.cs:454
		public TCoding Code_FineLinear = new TCoding(MammoCalcificationTypeCS.Code_FineLinear);                                                   // CSBuilder.cs:454
		                                                                                                                                          // CSBuilder.cs:409
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:411
		public MammoCalcificationTypeVS()                                                                                                         // CSBuilder.cs:412
		{                                                                                                                                         // CSBuilder.cs:413
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:414
		    this.Members.Add(this.Code_Skin);                                                                                                     // CSBuilder.cs:457
		    this.Members.Add(this.Code_Vascular);                                                                                                 // CSBuilder.cs:457
		    this.Members.Add(this.Code_Coarse);                                                                                                   // CSBuilder.cs:457
		    this.Members.Add(this.Code_LargeRodLike);                                                                                             // CSBuilder.cs:457
		    this.Members.Add(this.Code_Round);                                                                                                    // CSBuilder.cs:457
		    this.Members.Add(this.Code_Rim);                                                                                                      // CSBuilder.cs:457
		    this.Members.Add(this.Code_Dystrophic);                                                                                               // CSBuilder.cs:457
		    this.Members.Add(this.Code_MilkOfCalcium);                                                                                            // CSBuilder.cs:457
		    this.Members.Add(this.Code_Suture);                                                                                                   // CSBuilder.cs:457
		    this.Members.Add(this.Code_Amorphous);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_CoarseHeterogeneous);                                                                                      // CSBuilder.cs:457
		    this.Members.Add(this.Code_FinePleomorphic);                                                                                          // CSBuilder.cs:457
		    this.Members.Add(this.Code_FineLinear);                                                                                               // CSBuilder.cs:457
		}                                                                                                                                         // CSBuilder.cs:416
		//- Fields
	}
}
