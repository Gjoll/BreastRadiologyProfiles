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
	public class BiRadsAssessmentCategoriesVS                                                                                                  // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that explicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:357
		{                                                                                                                                         // CSBuilder.cs:358
		    Coding value;                                                                                                                         // CSBuilder.cs:359
		    public static explicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        return tCode.value;                                                                                                               // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		                                                                                                                                          // CSBuilder.cs:364
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:365
		    {                                                                                                                                     // CSBuilder.cs:366
		        this.value= value;                                                                                                                // CSBuilder.cs:367
		    }                                                                                                                                     // CSBuilder.cs:368
		}                                                                                                                                         // CSBuilder.cs:369
		public TCoding Code_Category0 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category0);                                                 // CSBuilder.cs:387
		public TCoding Code_Category1 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category1);                                                 // CSBuilder.cs:387
		public TCoding Code_Category2 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category2);                                                 // CSBuilder.cs:387
		public TCoding Code_Category3 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category3);                                                 // CSBuilder.cs:387
		public TCoding Code_Category4 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4);                                                 // CSBuilder.cs:387
		public TCoding Code_Category4A = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4A);                                               // CSBuilder.cs:387
		public TCoding Code_Category4B = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4B);                                               // CSBuilder.cs:387
		public TCoding Code_Category4C = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4C);                                               // CSBuilder.cs:387
		public TCoding Code_Category5 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category5);                                                 // CSBuilder.cs:387
		public TCoding Code_Category6 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category6);                                                 // CSBuilder.cs:387
		public TCoding Code_PostBiopsyMarker = new TCoding(BiRadsAssessmentCategoriesCS.Code_PostBiopsyMarker);                                   // CSBuilder.cs:387
		public TCoding Code_MarkerClipPlacement = new TCoding(BiRadsAssessmentCategoriesCS.Code_MarkerClipPlacement);                             // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public BiRadsAssessmentCategoriesVS()                                                                                                     // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category0);                                                                        // CSBuilder.cs:390
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category1);                                                                        // CSBuilder.cs:390
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category2);                                                                        // CSBuilder.cs:390
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category3);                                                                        // CSBuilder.cs:390
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category4);                                                                        // CSBuilder.cs:390
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category4A);                                                                       // CSBuilder.cs:390
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category4B);                                                                       // CSBuilder.cs:390
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category4C);                                                                       // CSBuilder.cs:390
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category5);                                                                        // CSBuilder.cs:390
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category6);                                                                        // CSBuilder.cs:390
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_PostBiopsyMarker);                                                                 // CSBuilder.cs:390
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_MarkerClipPlacement);                                                              // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
