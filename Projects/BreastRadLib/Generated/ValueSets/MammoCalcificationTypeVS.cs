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
	public class MammoCalcificationTypeVS                                                                                                      // CSBuilder.cs:413
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
		public TCoding Code_Skin = new TCoding(MammoCalcificationTypeCS.Code_Skin);                                                               // CSBuilder.cs:464
		public TCoding Code_Vascular = new TCoding(MammoCalcificationTypeCS.Code_Vascular);                                                       // CSBuilder.cs:464
		public TCoding Code_Coarse = new TCoding(MammoCalcificationTypeCS.Code_Coarse);                                                           // CSBuilder.cs:464
		public TCoding Code_LargeRodLike = new TCoding(MammoCalcificationTypeCS.Code_LargeRodLike);                                               // CSBuilder.cs:464
		public TCoding Code_Round = new TCoding(MammoCalcificationTypeCS.Code_Round);                                                             // CSBuilder.cs:464
		public TCoding Code_Rim = new TCoding(MammoCalcificationTypeCS.Code_Rim);                                                                 // CSBuilder.cs:464
		public TCoding Code_Dystrophic = new TCoding(MammoCalcificationTypeCS.Code_Dystrophic);                                                   // CSBuilder.cs:464
		public TCoding Code_MilkOfCalcium = new TCoding(MammoCalcificationTypeCS.Code_MilkOfCalcium);                                             // CSBuilder.cs:464
		public TCoding Code_Suture = new TCoding(MammoCalcificationTypeCS.Code_Suture);                                                           // CSBuilder.cs:464
		public TCoding Code_Amorphous = new TCoding(MammoCalcificationTypeCS.Code_Amorphous);                                                     // CSBuilder.cs:464
		public TCoding Code_CoarseHeterogeneous = new TCoding(MammoCalcificationTypeCS.Code_CoarseHeterogeneous);                                 // CSBuilder.cs:464
		public TCoding Code_FinePleomorphic = new TCoding(MammoCalcificationTypeCS.Code_FinePleomorphic);                                         // CSBuilder.cs:464
		public TCoding Code_FineLinear = new TCoding(MammoCalcificationTypeCS.Code_FineLinear);                                                   // CSBuilder.cs:464
		                                                                                                                                          // CSBuilder.cs:419
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:421
		public MammoCalcificationTypeVS()                                                                                                         // CSBuilder.cs:422
		{                                                                                                                                         // CSBuilder.cs:423
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:424
		    this.Members.Add(this.Code_Skin);                                                                                                     // CSBuilder.cs:467
		    this.Members.Add(this.Code_Vascular);                                                                                                 // CSBuilder.cs:467
		    this.Members.Add(this.Code_Coarse);                                                                                                   // CSBuilder.cs:467
		    this.Members.Add(this.Code_LargeRodLike);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_Round);                                                                                                    // CSBuilder.cs:467
		    this.Members.Add(this.Code_Rim);                                                                                                      // CSBuilder.cs:467
		    this.Members.Add(this.Code_Dystrophic);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_MilkOfCalcium);                                                                                            // CSBuilder.cs:467
		    this.Members.Add(this.Code_Suture);                                                                                                   // CSBuilder.cs:467
		    this.Members.Add(this.Code_Amorphous);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_CoarseHeterogeneous);                                                                                      // CSBuilder.cs:467
		    this.Members.Add(this.Code_FinePleomorphic);                                                                                          // CSBuilder.cs:467
		    this.Members.Add(this.Code_FineLinear);                                                                                               // CSBuilder.cs:467
		}                                                                                                                                         // CSBuilder.cs:426
		//- Fields
	}
}
