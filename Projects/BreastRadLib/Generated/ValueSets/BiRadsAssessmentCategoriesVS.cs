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
	public class BiRadsAssessmentCategoriesVS                                                                                                  // CSBuilder.cs:413
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
		public TCoding Code_Category0 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category0);                                                 // CSBuilder.cs:464
		public TCoding Code_Category1 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category1);                                                 // CSBuilder.cs:464
		public TCoding Code_Category2 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category2);                                                 // CSBuilder.cs:464
		public TCoding Code_Category3 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category3);                                                 // CSBuilder.cs:464
		public TCoding Code_Category4 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4);                                                 // CSBuilder.cs:464
		public TCoding Code_Category4A = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4A);                                               // CSBuilder.cs:464
		public TCoding Code_Category4B = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4B);                                               // CSBuilder.cs:464
		public TCoding Code_Category4C = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4C);                                               // CSBuilder.cs:464
		public TCoding Code_Category5 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category5);                                                 // CSBuilder.cs:464
		public TCoding Code_Category6 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category6);                                                 // CSBuilder.cs:464
		public TCoding Code_PostBiopsyMarker = new TCoding(BiRadsAssessmentCategoriesCS.Code_PostBiopsyMarker);                                   // CSBuilder.cs:464
		public TCoding Code_MarkerClipPlacement = new TCoding(BiRadsAssessmentCategoriesCS.Code_MarkerClipPlacement);                             // CSBuilder.cs:464
		                                                                                                                                          // CSBuilder.cs:419
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:421
		public BiRadsAssessmentCategoriesVS()                                                                                                     // CSBuilder.cs:422
		{                                                                                                                                         // CSBuilder.cs:423
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:424
		    this.Members.Add(this.Code_Category0);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_Category1);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_Category2);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_Category3);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_Category4);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_Category4A);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_Category4B);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_Category4C);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_Category5);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_Category6);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_PostBiopsyMarker);                                                                                         // CSBuilder.cs:467
		    this.Members.Add(this.Code_MarkerClipPlacement);                                                                                      // CSBuilder.cs:467
		}                                                                                                                                         // CSBuilder.cs:426
		//- Fields
	}
}
