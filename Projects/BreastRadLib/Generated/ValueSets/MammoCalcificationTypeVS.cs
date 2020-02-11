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
	public class MammoCalcificationTypeVS                                                                                                      // CSBuilder.cs:369
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
		public TCoding Code_Amorphous = new TCoding(MammoCalcificationTypeCS.Code_Amorphous);                                                     // CSBuilder.cs:420
		public TCoding Code_Coarse = new TCoding(MammoCalcificationTypeCS.Code_Coarse);                                                           // CSBuilder.cs:420
		public TCoding Code_Dystrophic = new TCoding(MammoCalcificationTypeCS.Code_Dystrophic);                                                   // CSBuilder.cs:420
		public TCoding Code_Eggshell = new TCoding(MammoCalcificationTypeCS.Code_Eggshell);                                                       // CSBuilder.cs:420
		public TCoding Code_Fine = new TCoding(MammoCalcificationTypeCS.Code_Fine);                                                               // CSBuilder.cs:420
		public TCoding Code_GenericCalcification = new TCoding(MammoCalcificationTypeCS.Code_GenericCalcification);                               // CSBuilder.cs:420
		public TCoding Code_CourseHeterogeneous = new TCoding(MammoCalcificationTypeCS.Code_CourseHeterogeneous);                                 // CSBuilder.cs:420
		public TCoding Code_Indistinct = new TCoding(MammoCalcificationTypeCS.Code_Indistinct);                                                   // CSBuilder.cs:420
		public TCoding Code_LargeRodlike = new TCoding(MammoCalcificationTypeCS.Code_LargeRodlike);                                               // CSBuilder.cs:420
		public TCoding Code_Layering = new TCoding(MammoCalcificationTypeCS.Code_Layering);                                                       // CSBuilder.cs:420
		public TCoding Code_FineLinear = new TCoding(MammoCalcificationTypeCS.Code_FineLinear);                                                   // CSBuilder.cs:420
		public TCoding Code_LucentCentered = new TCoding(MammoCalcificationTypeCS.Code_LucentCentered);                                           // CSBuilder.cs:420
		public TCoding Code_MilkOfCalcium = new TCoding(MammoCalcificationTypeCS.Code_MilkOfCalcium);                                             // CSBuilder.cs:420
		public TCoding Code_FinePleomorphic = new TCoding(MammoCalcificationTypeCS.Code_FinePleomorphic);                                         // CSBuilder.cs:420
		public TCoding Code_Punctate = new TCoding(MammoCalcificationTypeCS.Code_Punctate);                                                       // CSBuilder.cs:420
		public TCoding Code_Rim = new TCoding(MammoCalcificationTypeCS.Code_Rim);                                                                 // CSBuilder.cs:420
		public TCoding Code_Round = new TCoding(MammoCalcificationTypeCS.Code_Round);                                                             // CSBuilder.cs:420
		public TCoding Code_Skin = new TCoding(MammoCalcificationTypeCS.Code_Skin);                                                               // CSBuilder.cs:420
		public TCoding Code_Spherical = new TCoding(MammoCalcificationTypeCS.Code_Spherical);                                                     // CSBuilder.cs:420
		public TCoding Code_Suture = new TCoding(MammoCalcificationTypeCS.Code_Suture);                                                           // CSBuilder.cs:420
		public TCoding Code_Vascular = new TCoding(MammoCalcificationTypeCS.Code_Vascular);                                                       // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:375
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:376
		                                                                                                                                          // CSBuilder.cs:377
		public MammoCalcificationTypeVS()                                                                                                         // CSBuilder.cs:378
		{                                                                                                                                         // CSBuilder.cs:379
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:380
		    this.Members.Add(this.Code_Amorphous);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_Coarse);                                                                                                   // CSBuilder.cs:423
		    this.Members.Add(this.Code_Dystrophic);                                                                                               // CSBuilder.cs:423
		    this.Members.Add(this.Code_Eggshell);                                                                                                 // CSBuilder.cs:423
		    this.Members.Add(this.Code_Fine);                                                                                                     // CSBuilder.cs:423
		    this.Members.Add(this.Code_GenericCalcification);                                                                                     // CSBuilder.cs:423
		    this.Members.Add(this.Code_CourseHeterogeneous);                                                                                      // CSBuilder.cs:423
		    this.Members.Add(this.Code_Indistinct);                                                                                               // CSBuilder.cs:423
		    this.Members.Add(this.Code_LargeRodlike);                                                                                             // CSBuilder.cs:423
		    this.Members.Add(this.Code_Layering);                                                                                                 // CSBuilder.cs:423
		    this.Members.Add(this.Code_FineLinear);                                                                                               // CSBuilder.cs:423
		    this.Members.Add(this.Code_LucentCentered);                                                                                           // CSBuilder.cs:423
		    this.Members.Add(this.Code_MilkOfCalcium);                                                                                            // CSBuilder.cs:423
		    this.Members.Add(this.Code_FinePleomorphic);                                                                                          // CSBuilder.cs:423
		    this.Members.Add(this.Code_Punctate);                                                                                                 // CSBuilder.cs:423
		    this.Members.Add(this.Code_Rim);                                                                                                      // CSBuilder.cs:423
		    this.Members.Add(this.Code_Round);                                                                                                    // CSBuilder.cs:423
		    this.Members.Add(this.Code_Skin);                                                                                                     // CSBuilder.cs:423
		    this.Members.Add(this.Code_Spherical);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_Suture);                                                                                                   // CSBuilder.cs:423
		    this.Members.Add(this.Code_Vascular);                                                                                                 // CSBuilder.cs:423
		}                                                                                                                                         // CSBuilder.cs:382
		//- Fields
	}
}
