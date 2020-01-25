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
	public class NotPreviouslySeenVS                                                                                                           // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public NotPreviouslySeenVS()                                                                                                              // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(NotPreviouslySeenCodeSystemCS.Code_ClinicalExam);                                                                    // CSBuilder.cs:362
		    this.Members.Add(NotPreviouslySeenCodeSystemCS.Code_Ductogram);                                                                       // CSBuilder.cs:362
		    this.Members.Add(NotPreviouslySeenCodeSystemCS.Code_Mammogram);                                                                       // CSBuilder.cs:362
		    this.Members.Add(NotPreviouslySeenCodeSystemCS.Code_MRI);                                                                             // CSBuilder.cs:362
		    this.Members.Add(NotPreviouslySeenCodeSystemCS.Code_OutsideExam);                                                                     // CSBuilder.cs:362
		    this.Members.Add(NotPreviouslySeenCodeSystemCS.Code_Scintimammography);                                                               // CSBuilder.cs:362
		    this.Members.Add(NotPreviouslySeenCodeSystemCS.Code_Ultrasound);                                                                      // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
