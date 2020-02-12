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
	public class BiRadsAssessmentCategoriesVS                                                                                                  // CSBuilder.cs:331
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
		public TCoding Code_Category0 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category0);                                                 // CSBuilder.cs:382
		public TCoding Code_Category2 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category2);                                                 // CSBuilder.cs:382
		public TCoding Code_Category3 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category3);                                                 // CSBuilder.cs:382
		public TCoding Code_Category4 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4);                                                 // CSBuilder.cs:382
		public TCoding Code_Category4A = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4A);                                               // CSBuilder.cs:382
		public TCoding Code_Category4B = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4B);                                               // CSBuilder.cs:382
		public TCoding Code_Category4C = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4C);                                               // CSBuilder.cs:382
		public TCoding Code_Category5 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category5);                                                 // CSBuilder.cs:382
		public TCoding Code_Category6 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category6);                                                 // CSBuilder.cs:382
		                                                                                                                                          // CSBuilder.cs:337
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:338
		                                                                                                                                          // CSBuilder.cs:339
		public BiRadsAssessmentCategoriesVS()                                                                                                     // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:342
		    this.Members.Add(this.Code_Category0);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_Category2);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_Category3);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_Category4);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_Category4A);                                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_Category4B);                                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_Category4C);                                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_Category5);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_Category6);                                                                                                // CSBuilder.cs:385
		}                                                                                                                                         // CSBuilder.cs:344
		//- Fields
	}
}
