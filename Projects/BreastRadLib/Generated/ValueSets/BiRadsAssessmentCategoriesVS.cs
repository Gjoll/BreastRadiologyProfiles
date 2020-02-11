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
	public class BiRadsAssessmentCategoriesVS                                                                                                  // CSBuilder.cs:369
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
		public TCoding Code_Category0 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category0);                                                 // CSBuilder.cs:420
		public TCoding Code_Category2 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category2);                                                 // CSBuilder.cs:420
		public TCoding Code_Category3 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category3);                                                 // CSBuilder.cs:420
		public TCoding Code_Category4 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4);                                                 // CSBuilder.cs:420
		public TCoding Code_Category4A = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4A);                                               // CSBuilder.cs:420
		public TCoding Code_Category4B = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4B);                                               // CSBuilder.cs:420
		public TCoding Code_Category4C = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category4C);                                               // CSBuilder.cs:420
		public TCoding Code_Category5 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category5);                                                 // CSBuilder.cs:420
		public TCoding Code_Category6 = new TCoding(BiRadsAssessmentCategoriesCS.Code_Category6);                                                 // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:375
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:376
		                                                                                                                                          // CSBuilder.cs:377
		public BiRadsAssessmentCategoriesVS()                                                                                                     // CSBuilder.cs:378
		{                                                                                                                                         // CSBuilder.cs:379
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:380
		    this.Members.Add(this.Code_Category0);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_Category2);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_Category3);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_Category4);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_Category4A);                                                                                               // CSBuilder.cs:423
		    this.Members.Add(this.Code_Category4B);                                                                                               // CSBuilder.cs:423
		    this.Members.Add(this.Code_Category4C);                                                                                               // CSBuilder.cs:423
		    this.Members.Add(this.Code_Category5);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_Category6);                                                                                                // CSBuilder.cs:423
		}                                                                                                                                         // CSBuilder.cs:382
		//- Fields
	}
}
