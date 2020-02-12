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
	public class MammoCalcificationTypeVS                                                                                                      // CSBuilder.cs:338
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
		public TCoding Code_Amorphous = new TCoding(MammoCalcificationTypeCS.Code_Amorphous);                                                     // CSBuilder.cs:389
		public TCoding Code_Coarse = new TCoding(MammoCalcificationTypeCS.Code_Coarse);                                                           // CSBuilder.cs:389
		public TCoding Code_Dystrophic = new TCoding(MammoCalcificationTypeCS.Code_Dystrophic);                                                   // CSBuilder.cs:389
		public TCoding Code_Eggshell = new TCoding(MammoCalcificationTypeCS.Code_Eggshell);                                                       // CSBuilder.cs:389
		public TCoding Code_Fine = new TCoding(MammoCalcificationTypeCS.Code_Fine);                                                               // CSBuilder.cs:389
		public TCoding Code_GenericCalcification = new TCoding(MammoCalcificationTypeCS.Code_GenericCalcification);                               // CSBuilder.cs:389
		public TCoding Code_CourseHeterogeneous = new TCoding(MammoCalcificationTypeCS.Code_CourseHeterogeneous);                                 // CSBuilder.cs:389
		public TCoding Code_Indistinct = new TCoding(MammoCalcificationTypeCS.Code_Indistinct);                                                   // CSBuilder.cs:389
		public TCoding Code_LargeRodlike = new TCoding(MammoCalcificationTypeCS.Code_LargeRodlike);                                               // CSBuilder.cs:389
		public TCoding Code_Layering = new TCoding(MammoCalcificationTypeCS.Code_Layering);                                                       // CSBuilder.cs:389
		public TCoding Code_FineLinear = new TCoding(MammoCalcificationTypeCS.Code_FineLinear);                                                   // CSBuilder.cs:389
		public TCoding Code_LucentCentered = new TCoding(MammoCalcificationTypeCS.Code_LucentCentered);                                           // CSBuilder.cs:389
		public TCoding Code_MilkOfCalcium = new TCoding(MammoCalcificationTypeCS.Code_MilkOfCalcium);                                             // CSBuilder.cs:389
		public TCoding Code_FinePleomorphic = new TCoding(MammoCalcificationTypeCS.Code_FinePleomorphic);                                         // CSBuilder.cs:389
		public TCoding Code_Punctate = new TCoding(MammoCalcificationTypeCS.Code_Punctate);                                                       // CSBuilder.cs:389
		public TCoding Code_Rim = new TCoding(MammoCalcificationTypeCS.Code_Rim);                                                                 // CSBuilder.cs:389
		public TCoding Code_Round = new TCoding(MammoCalcificationTypeCS.Code_Round);                                                             // CSBuilder.cs:389
		public TCoding Code_Skin = new TCoding(MammoCalcificationTypeCS.Code_Skin);                                                               // CSBuilder.cs:389
		public TCoding Code_Spherical = new TCoding(MammoCalcificationTypeCS.Code_Spherical);                                                     // CSBuilder.cs:389
		public TCoding Code_Suture = new TCoding(MammoCalcificationTypeCS.Code_Suture);                                                           // CSBuilder.cs:389
		public TCoding Code_Vascular = new TCoding(MammoCalcificationTypeCS.Code_Vascular);                                                       // CSBuilder.cs:389
		                                                                                                                                          // CSBuilder.cs:344
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:345
		                                                                                                                                          // CSBuilder.cs:346
		public MammoCalcificationTypeVS()                                                                                                         // CSBuilder.cs:347
		{                                                                                                                                         // CSBuilder.cs:348
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:349
		    this.Members.Add(this.Code_Amorphous);                                                                                                // CSBuilder.cs:392
		    this.Members.Add(this.Code_Coarse);                                                                                                   // CSBuilder.cs:392
		    this.Members.Add(this.Code_Dystrophic);                                                                                               // CSBuilder.cs:392
		    this.Members.Add(this.Code_Eggshell);                                                                                                 // CSBuilder.cs:392
		    this.Members.Add(this.Code_Fine);                                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_GenericCalcification);                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_CourseHeterogeneous);                                                                                      // CSBuilder.cs:392
		    this.Members.Add(this.Code_Indistinct);                                                                                               // CSBuilder.cs:392
		    this.Members.Add(this.Code_LargeRodlike);                                                                                             // CSBuilder.cs:392
		    this.Members.Add(this.Code_Layering);                                                                                                 // CSBuilder.cs:392
		    this.Members.Add(this.Code_FineLinear);                                                                                               // CSBuilder.cs:392
		    this.Members.Add(this.Code_LucentCentered);                                                                                           // CSBuilder.cs:392
		    this.Members.Add(this.Code_MilkOfCalcium);                                                                                            // CSBuilder.cs:392
		    this.Members.Add(this.Code_FinePleomorphic);                                                                                          // CSBuilder.cs:392
		    this.Members.Add(this.Code_Punctate);                                                                                                 // CSBuilder.cs:392
		    this.Members.Add(this.Code_Rim);                                                                                                      // CSBuilder.cs:392
		    this.Members.Add(this.Code_Round);                                                                                                    // CSBuilder.cs:392
		    this.Members.Add(this.Code_Skin);                                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_Spherical);                                                                                                // CSBuilder.cs:392
		    this.Members.Add(this.Code_Suture);                                                                                                   // CSBuilder.cs:392
		    this.Members.Add(this.Code_Vascular);                                                                                                 // CSBuilder.cs:392
		}                                                                                                                                         // CSBuilder.cs:351
		//- Fields
	}
}
