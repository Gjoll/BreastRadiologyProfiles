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
	public class NotPreviouslySeenVS                                                                                                           // CSBuilder.cs:413
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
		public TCoding Code_ClinicalExam = new TCoding(NotPreviouslySeenCodeSystemCS.Code_ClinicalExam);                                          // CSBuilder.cs:464
		public TCoding Code_Ductogram = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Ductogram);                                                // CSBuilder.cs:464
		public TCoding Code_Mammogram = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Mammogram);                                                // CSBuilder.cs:464
		public TCoding Code_MRI = new TCoding(NotPreviouslySeenCodeSystemCS.Code_MRI);                                                            // CSBuilder.cs:464
		public TCoding Code_OutsideExam = new TCoding(NotPreviouslySeenCodeSystemCS.Code_OutsideExam);                                            // CSBuilder.cs:464
		public TCoding Code_Scintimammography = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Scintimammography);                                // CSBuilder.cs:464
		public TCoding Code_Ultrasound = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Ultrasound);                                              // CSBuilder.cs:464
		                                                                                                                                          // CSBuilder.cs:419
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:421
		public NotPreviouslySeenVS()                                                                                                              // CSBuilder.cs:422
		{                                                                                                                                         // CSBuilder.cs:423
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:424
		    this.Members.Add(this.Code_ClinicalExam);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_Ductogram);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_Mammogram);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_MRI);                                                                                                      // CSBuilder.cs:467
		    this.Members.Add(this.Code_OutsideExam);                                                                                              // CSBuilder.cs:467
		    this.Members.Add(this.Code_Scintimammography);                                                                                        // CSBuilder.cs:467
		    this.Members.Add(this.Code_Ultrasound);                                                                                               // CSBuilder.cs:467
		}                                                                                                                                         // CSBuilder.cs:426
		//- Fields
	}
}
