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
	public class MammoCalcificationTypeVS                                                                                                      // CSBuilder.cs:331
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:352
		{                                                                                                                                         // CSBuilder.cs:353
		    Coding value;                                                                                                                         // CSBuilder.cs:354
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:355
		    {                                                                                                                                     // CSBuilder.cs:356
		        return tCode.value;                                                                                                               // CSBuilder.cs:357
		    }                                                                                                                                     // CSBuilder.cs:358
		                                                                                                                                          // CSBuilder.cs:359
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        this.value= value;                                                                                                                // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		}                                                                                                                                         // CSBuilder.cs:364
		public TCoding Code_Amorphous = new TCoding(MammoCalcificationTypeCS.Code_Amorphous);                                                     // CSBuilder.cs:382
		public TCoding Code_Coarse = new TCoding(MammoCalcificationTypeCS.Code_Coarse);                                                           // CSBuilder.cs:382
		public TCoding Code_Dystrophic = new TCoding(MammoCalcificationTypeCS.Code_Dystrophic);                                                   // CSBuilder.cs:382
		public TCoding Code_Eggshell = new TCoding(MammoCalcificationTypeCS.Code_Eggshell);                                                       // CSBuilder.cs:382
		public TCoding Code_Fine = new TCoding(MammoCalcificationTypeCS.Code_Fine);                                                               // CSBuilder.cs:382
		public TCoding Code_GenericCalcification = new TCoding(MammoCalcificationTypeCS.Code_GenericCalcification);                               // CSBuilder.cs:382
		public TCoding Code_CourseHeterogeneous = new TCoding(MammoCalcificationTypeCS.Code_CourseHeterogeneous);                                 // CSBuilder.cs:382
		public TCoding Code_Indistinct = new TCoding(MammoCalcificationTypeCS.Code_Indistinct);                                                   // CSBuilder.cs:382
		public TCoding Code_LargeRodlike = new TCoding(MammoCalcificationTypeCS.Code_LargeRodlike);                                               // CSBuilder.cs:382
		public TCoding Code_Layering = new TCoding(MammoCalcificationTypeCS.Code_Layering);                                                       // CSBuilder.cs:382
		public TCoding Code_FineLinear = new TCoding(MammoCalcificationTypeCS.Code_FineLinear);                                                   // CSBuilder.cs:382
		public TCoding Code_LucentCentered = new TCoding(MammoCalcificationTypeCS.Code_LucentCentered);                                           // CSBuilder.cs:382
		public TCoding Code_MilkOfCalcium = new TCoding(MammoCalcificationTypeCS.Code_MilkOfCalcium);                                             // CSBuilder.cs:382
		public TCoding Code_FinePleomorphic = new TCoding(MammoCalcificationTypeCS.Code_FinePleomorphic);                                         // CSBuilder.cs:382
		public TCoding Code_Punctate = new TCoding(MammoCalcificationTypeCS.Code_Punctate);                                                       // CSBuilder.cs:382
		public TCoding Code_Rim = new TCoding(MammoCalcificationTypeCS.Code_Rim);                                                                 // CSBuilder.cs:382
		public TCoding Code_Round = new TCoding(MammoCalcificationTypeCS.Code_Round);                                                             // CSBuilder.cs:382
		public TCoding Code_Skin = new TCoding(MammoCalcificationTypeCS.Code_Skin);                                                               // CSBuilder.cs:382
		public TCoding Code_Spherical = new TCoding(MammoCalcificationTypeCS.Code_Spherical);                                                     // CSBuilder.cs:382
		public TCoding Code_Suture = new TCoding(MammoCalcificationTypeCS.Code_Suture);                                                           // CSBuilder.cs:382
		public TCoding Code_Vascular = new TCoding(MammoCalcificationTypeCS.Code_Vascular);                                                       // CSBuilder.cs:382
		                                                                                                                                          // CSBuilder.cs:337
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:338
		                                                                                                                                          // CSBuilder.cs:339
		public MammoCalcificationTypeVS()                                                                                                         // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:342
		    this.Members.Add(this.Code_Amorphous);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_Coarse);                                                                                                   // CSBuilder.cs:385
		    this.Members.Add(this.Code_Dystrophic);                                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_Eggshell);                                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_Fine);                                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_GenericCalcification);                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_CourseHeterogeneous);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_Indistinct);                                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_LargeRodlike);                                                                                             // CSBuilder.cs:385
		    this.Members.Add(this.Code_Layering);                                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_FineLinear);                                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_LucentCentered);                                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_MilkOfCalcium);                                                                                            // CSBuilder.cs:385
		    this.Members.Add(this.Code_FinePleomorphic);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_Punctate);                                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_Rim);                                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_Round);                                                                                                    // CSBuilder.cs:385
		    this.Members.Add(this.Code_Skin);                                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_Spherical);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_Suture);                                                                                                   // CSBuilder.cs:385
		    this.Members.Add(this.Code_Vascular);                                                                                                 // CSBuilder.cs:385
		}                                                                                                                                         // CSBuilder.cs:344
		//- Fields
	}
}
