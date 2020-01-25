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
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public BiRadsAssessmentCategoriesVS()                                                                                                     // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category0);                                                                        // CSBuilder.cs:362
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category1);                                                                        // CSBuilder.cs:362
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category2);                                                                        // CSBuilder.cs:362
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category3);                                                                        // CSBuilder.cs:362
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category4);                                                                        // CSBuilder.cs:362
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category4A);                                                                       // CSBuilder.cs:362
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category4B);                                                                       // CSBuilder.cs:362
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category4C);                                                                       // CSBuilder.cs:362
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category5);                                                                        // CSBuilder.cs:362
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_Category6);                                                                        // CSBuilder.cs:362
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_PostBiopsyMarker);                                                                 // CSBuilder.cs:362
		    this.Members.Add(BiRadsAssessmentCategoriesCS.Code_MarkerClipPlacement);                                                              // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
