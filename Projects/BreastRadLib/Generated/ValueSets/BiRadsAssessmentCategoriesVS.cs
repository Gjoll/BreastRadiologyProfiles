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
	public class BiRadsAssessmentCategoriesVS                                                                                                  // CSBuilder.cs:361
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:382
		{                                                                                                                                         // CSBuilder.cs:383
		    Coding value;                                                                                                                         // CSBuilder.cs:384
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:385
		    {                                                                                                                                     // CSBuilder.cs:386
		        return tCode.value;                                                                                                               // CSBuilder.cs:387
		    }                                                                                                                                     // CSBuilder.cs:388
		                                                                                                                                          // CSBuilder.cs:389
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:390
		    {                                                                                                                                     // CSBuilder.cs:391
		        this.value= value;                                                                                                                // CSBuilder.cs:392
		    }                                                                                                                                     // CSBuilder.cs:393
		}                                                                                                                                         // CSBuilder.cs:394
		public TCoding Code_Category0 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category0);                                                 // CSBuilder.cs:412
		public TCoding Code_Category1 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category1);                                                 // CSBuilder.cs:412
		public TCoding Code_Category2 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category2);                                                 // CSBuilder.cs:412
		public TCoding Code_Category3 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category3);                                                 // CSBuilder.cs:412
		public TCoding Code_Category4 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4);                                                 // CSBuilder.cs:412
		public TCoding Code_Category4A = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4A);                                               // CSBuilder.cs:412
		public TCoding Code_Category4B = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4B);                                               // CSBuilder.cs:412
		public TCoding Code_Category4C = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4C);                                               // CSBuilder.cs:412
		public TCoding Code_Category5 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category5);                                                 // CSBuilder.cs:412
		public TCoding Code_Category6 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category6);                                                 // CSBuilder.cs:412
		public TCoding Code_PostBiopsyMarker = new TCoding(BiRadsAssessmentCategoriesCS.Code_PostBiopsyMarker);                                   // CSBuilder.cs:412
		public TCoding Code_MarkerClipPlacement = new TCoding(BiRadsAssessmentCategoriesCS.Code_MarkerClipPlacement);                             // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:367
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:368
		                                                                                                                                          // CSBuilder.cs:369
		public BiRadsAssessmentCategoriesVS()                                                                                                     // CSBuilder.cs:370
		{                                                                                                                                         // CSBuilder.cs:371
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:372
		    this.Members.Add(this.Code_Category0);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_Category1);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_Category2);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_Category3);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_Category4);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_Category4A);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_Category4B);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_Category4C);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_Category5);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_Category6);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_PostBiopsyMarker);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_MarkerClipPlacement);                                                                                      // CSBuilder.cs:415
		}                                                                                                                                         // CSBuilder.cs:374
		//- Fields
	}
}
