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
	public class BiRadsAssessmentCategoriesVS                                                                                                  // CSBuilder.cs:403
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
		public TCoding Code_Category0 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category0);                                                 // CSBuilder.cs:454
		public TCoding Code_Category1 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category1);                                                 // CSBuilder.cs:454
		public TCoding Code_Category2 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category2);                                                 // CSBuilder.cs:454
		public TCoding Code_Category3 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category3);                                                 // CSBuilder.cs:454
		public TCoding Code_Category4 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4);                                                 // CSBuilder.cs:454
		public TCoding Code_Category4A = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4A);                                               // CSBuilder.cs:454
		public TCoding Code_Category4B = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4B);                                               // CSBuilder.cs:454
		public TCoding Code_Category4C = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4C);                                               // CSBuilder.cs:454
		public TCoding Code_Category5 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category5);                                                 // CSBuilder.cs:454
		public TCoding Code_Category6 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category6);                                                 // CSBuilder.cs:454
		public TCoding Code_PostBiopsyMarker = new TCoding(BiRadsAssessmentCategoriesCS.Code_PostBiopsyMarker);                                   // CSBuilder.cs:454
		public TCoding Code_MarkerClipPlacement = new TCoding(BiRadsAssessmentCategoriesCS.Code_MarkerClipPlacement);                             // CSBuilder.cs:454
		                                                                                                                                          // CSBuilder.cs:409
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:411
		public BiRadsAssessmentCategoriesVS()                                                                                                     // CSBuilder.cs:412
		{                                                                                                                                         // CSBuilder.cs:413
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:414
		    this.Members.Add(this.Code_Category0);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_Category1);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_Category2);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_Category3);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_Category4);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_Category4A);                                                                                               // CSBuilder.cs:457
		    this.Members.Add(this.Code_Category4B);                                                                                               // CSBuilder.cs:457
		    this.Members.Add(this.Code_Category4C);                                                                                               // CSBuilder.cs:457
		    this.Members.Add(this.Code_Category5);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_Category6);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_PostBiopsyMarker);                                                                                         // CSBuilder.cs:457
		    this.Members.Add(this.Code_MarkerClipPlacement);                                                                                      // CSBuilder.cs:457
		}                                                                                                                                         // CSBuilder.cs:416
		//- Fields
	}
}
