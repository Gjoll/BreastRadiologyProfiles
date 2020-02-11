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
	public class NotPreviouslySeenVS                                                                                                           // CSBuilder.cs:369
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
		public TCoding Code_ClinicalExam = new TCoding(NotPreviouslySeenCodeSystemCS.Code_ClinicalExam);                                          // CSBuilder.cs:420
		public TCoding Code_Ductogram = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Ductogram);                                                // CSBuilder.cs:420
		public TCoding Code_Mammogram = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Mammogram);                                                // CSBuilder.cs:420
		public TCoding Code_MRI = new TCoding(NotPreviouslySeenCodeSystemCS.Code_MRI);                                                            // CSBuilder.cs:420
		public TCoding Code_OutsideExam = new TCoding(NotPreviouslySeenCodeSystemCS.Code_OutsideExam);                                            // CSBuilder.cs:420
		public TCoding Code_Scintimammography = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Scintimammography);                                // CSBuilder.cs:420
		public TCoding Code_Ultrasound = new TCoding(NotPreviouslySeenCodeSystemCS.Code_Ultrasound);                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:375
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:376
		                                                                                                                                          // CSBuilder.cs:377
		public NotPreviouslySeenVS()                                                                                                              // CSBuilder.cs:378
		{                                                                                                                                         // CSBuilder.cs:379
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:380
		    this.Members.Add(this.Code_ClinicalExam);                                                                                             // CSBuilder.cs:423
		    this.Members.Add(this.Code_Ductogram);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_Mammogram);                                                                                                // CSBuilder.cs:423
		    this.Members.Add(this.Code_MRI);                                                                                                      // CSBuilder.cs:423
		    this.Members.Add(this.Code_OutsideExam);                                                                                              // CSBuilder.cs:423
		    this.Members.Add(this.Code_Scintimammography);                                                                                        // CSBuilder.cs:423
		    this.Members.Add(this.Code_Ultrasound);                                                                                               // CSBuilder.cs:423
		}                                                                                                                                         // CSBuilder.cs:382
		//- Fields
	}
}
