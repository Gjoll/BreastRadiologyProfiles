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
	public class NotPreviouslySeenVS                                                                                                           // CSBuilder.cs:338
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
		public TCoding Code_ClinicalExam = new TCoding(NotPreviouslySeenCodeSystemCS.Code_ClinicalExam);                                          // CSBuilder.cs:389
		public TCoding Code_Ductogram = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Ductogram);                                                // CSBuilder.cs:389
		public TCoding Code_Mammogram = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Mammogram);                                                // CSBuilder.cs:389
		public TCoding Code_MRI = new TCoding(NotPreviouslySeenCodeSystemCS.Code_MRI);                                                            // CSBuilder.cs:389
		public TCoding Code_OutsideExam = new TCoding(NotPreviouslySeenCodeSystemCS.Code_OutsideExam);                                            // CSBuilder.cs:389
		public TCoding Code_Scintimammography = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Scintimammography);                                // CSBuilder.cs:389
		public TCoding Code_Ultrasound = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Ultrasound);                                              // CSBuilder.cs:389
		                                                                                                                                          // CSBuilder.cs:344
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:345
		                                                                                                                                          // CSBuilder.cs:346
		public NotPreviouslySeenVS()                                                                                                              // CSBuilder.cs:347
		{                                                                                                                                         // CSBuilder.cs:348
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:349
		    this.Members.Add(this.Code_ClinicalExam);                                                                                             // CSBuilder.cs:392
		    this.Members.Add(this.Code_Ductogram);                                                                                                // CSBuilder.cs:392
		    this.Members.Add(this.Code_Mammogram);                                                                                                // CSBuilder.cs:392
		    this.Members.Add(this.Code_MRI);                                                                                                      // CSBuilder.cs:392
		    this.Members.Add(this.Code_OutsideExam);                                                                                              // CSBuilder.cs:392
		    this.Members.Add(this.Code_Scintimammography);                                                                                        // CSBuilder.cs:392
		    this.Members.Add(this.Code_Ultrasound);                                                                                               // CSBuilder.cs:392
		}                                                                                                                                         // CSBuilder.cs:351
		//- Fields
	}
}
