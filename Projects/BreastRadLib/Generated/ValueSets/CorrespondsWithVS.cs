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
	public class CorrespondsWithVS                                                                                                             // CSBuilder.cs:413
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
		public TCoding Code_Aspiration = new TCoding(CorrespondsWithCodeSystemCS.Code_Aspiration);                                                // CSBuilder.cs:464
		public TCoding Code_Biopsy = new TCoding(CorrespondsWithCodeSystemCS.Code_Biopsy);                                                        // CSBuilder.cs:464
		public TCoding Code_Concern = new TCoding(CorrespondsWithCodeSystemCS.Code_Concern);                                                      // CSBuilder.cs:464
		public TCoding Code_Ductogram = new TCoding(CorrespondsWithCodeSystemCS.Code_Ductogram);                                                  // CSBuilder.cs:464
		public TCoding Code_IncidentalFinding = new TCoding(CorrespondsWithCodeSystemCS.Code_IncidentalFinding);                                  // CSBuilder.cs:464
		public TCoding Code_Mammogram = new TCoding(CorrespondsWithCodeSystemCS.Code_Mammogram);                                                  // CSBuilder.cs:464
		public TCoding Code_MRI = new TCoding(CorrespondsWithCodeSystemCS.Code_MRI);                                                              // CSBuilder.cs:464
		public TCoding Code_NippleDischarge = new TCoding(CorrespondsWithCodeSystemCS.Code_NippleDischarge);                                      // CSBuilder.cs:464
		public TCoding Code_OutsideExam = new TCoding(CorrespondsWithCodeSystemCS.Code_OutsideExam);                                              // CSBuilder.cs:464
		public TCoding Code_Pain = new TCoding(CorrespondsWithCodeSystemCS.Code_Pain);                                                            // CSBuilder.cs:464
		public TCoding Code_Palpated = new TCoding(CorrespondsWithCodeSystemCS.Code_Palpated);                                                    // CSBuilder.cs:464
		public TCoding Code_PostOperative = new TCoding(CorrespondsWithCodeSystemCS.Code_PostOperative);                                          // CSBuilder.cs:464
		public TCoding Code_PreviousBiopsy = new TCoding(CorrespondsWithCodeSystemCS.Code_PreviousBiopsy);                                        // CSBuilder.cs:464
		public TCoding Code_PriorExam = new TCoding(CorrespondsWithCodeSystemCS.Code_PriorExam);                                                  // CSBuilder.cs:464
		public TCoding Code_Redness = new TCoding(CorrespondsWithCodeSystemCS.Code_Redness);                                                      // CSBuilder.cs:464
		public TCoding Code_Scinti = new TCoding(CorrespondsWithCodeSystemCS.Code_Scinti);                                                        // CSBuilder.cs:464
		public TCoding Code_SizeLessThanMammo = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanMammo);                                  // CSBuilder.cs:464
		public TCoding Code_SizeLessThanMRI = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanMRI);                                      // CSBuilder.cs:464
		public TCoding Code_SizeLessThanPalp = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanPalp);                                    // CSBuilder.cs:464
		public TCoding Code_SizeLessThanUS = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanUS);                                        // CSBuilder.cs:464
		public TCoding Code_SizeGreaterThanMammo = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanMammo);                            // CSBuilder.cs:464
		public TCoding Code_SizeGreaterThanMRI = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanMRI);                                // CSBuilder.cs:464
		public TCoding Code_SizeGreaterThanPalp = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanPalp);                              // CSBuilder.cs:464
		public TCoding Code_SizeGreaterThanUS = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanUS);                                  // CSBuilder.cs:464
		public TCoding Code_SkinMarker = new TCoding(CorrespondsWithCodeSystemCS.Code_SkinMarker);                                                // CSBuilder.cs:464
		public TCoding Code_Surgery = new TCoding(CorrespondsWithCodeSystemCS.Code_Surgery);                                                      // CSBuilder.cs:464
		public TCoding Code_SurgicalSite = new TCoding(CorrespondsWithCodeSystemCS.Code_SurgicalSite);                                            // CSBuilder.cs:464
		public TCoding Code_Tenderness = new TCoding(CorrespondsWithCodeSystemCS.Code_Tenderness);                                                // CSBuilder.cs:464
		public TCoding Code_TriggerPoint = new TCoding(CorrespondsWithCodeSystemCS.Code_TriggerPoint);                                            // CSBuilder.cs:464
		public TCoding Code_US = new TCoding(CorrespondsWithCodeSystemCS.Code_US);                                                                // CSBuilder.cs:464
		                                                                                                                                          // CSBuilder.cs:419
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:421
		public CorrespondsWithVS()                                                                                                                // CSBuilder.cs:422
		{                                                                                                                                         // CSBuilder.cs:423
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:424
		    this.Members.Add(this.Code_Aspiration);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_Biopsy);                                                                                                   // CSBuilder.cs:467
		    this.Members.Add(this.Code_Concern);                                                                                                  // CSBuilder.cs:467
		    this.Members.Add(this.Code_Ductogram);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_IncidentalFinding);                                                                                        // CSBuilder.cs:467
		    this.Members.Add(this.Code_Mammogram);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_MRI);                                                                                                      // CSBuilder.cs:467
		    this.Members.Add(this.Code_NippleDischarge);                                                                                          // CSBuilder.cs:467
		    this.Members.Add(this.Code_OutsideExam);                                                                                              // CSBuilder.cs:467
		    this.Members.Add(this.Code_Pain);                                                                                                     // CSBuilder.cs:467
		    this.Members.Add(this.Code_Palpated);                                                                                                 // CSBuilder.cs:467
		    this.Members.Add(this.Code_PostOperative);                                                                                            // CSBuilder.cs:467
		    this.Members.Add(this.Code_PreviousBiopsy);                                                                                           // CSBuilder.cs:467
		    this.Members.Add(this.Code_PriorExam);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_Redness);                                                                                                  // CSBuilder.cs:467
		    this.Members.Add(this.Code_Scinti);                                                                                                   // CSBuilder.cs:467
		    this.Members.Add(this.Code_SizeLessThanMammo);                                                                                        // CSBuilder.cs:467
		    this.Members.Add(this.Code_SizeLessThanMRI);                                                                                          // CSBuilder.cs:467
		    this.Members.Add(this.Code_SizeLessThanPalp);                                                                                         // CSBuilder.cs:467
		    this.Members.Add(this.Code_SizeLessThanUS);                                                                                           // CSBuilder.cs:467
		    this.Members.Add(this.Code_SizeGreaterThanMammo);                                                                                     // CSBuilder.cs:467
		    this.Members.Add(this.Code_SizeGreaterThanMRI);                                                                                       // CSBuilder.cs:467
		    this.Members.Add(this.Code_SizeGreaterThanPalp);                                                                                      // CSBuilder.cs:467
		    this.Members.Add(this.Code_SizeGreaterThanUS);                                                                                        // CSBuilder.cs:467
		    this.Members.Add(this.Code_SkinMarker);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_Surgery);                                                                                                  // CSBuilder.cs:467
		    this.Members.Add(this.Code_SurgicalSite);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_Tenderness);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_TriggerPoint);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_US);                                                                                                       // CSBuilder.cs:467
		}                                                                                                                                         // CSBuilder.cs:426
		//- Fields
	}
}
