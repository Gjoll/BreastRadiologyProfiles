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
	public class CorrespondsWithVS                                                                                                             // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:357
		{                                                                                                                                         // CSBuilder.cs:358
		    Coding value;                                                                                                                         // CSBuilder.cs:359
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        return tCode.value;                                                                                                               // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		                                                                                                                                          // CSBuilder.cs:364
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:365
		    {                                                                                                                                     // CSBuilder.cs:366
		        this.value= value;                                                                                                                // CSBuilder.cs:367
		    }                                                                                                                                     // CSBuilder.cs:368
		}                                                                                                                                         // CSBuilder.cs:369
		public TCoding Code_Aspiration = new TCoding(CorrespondsWithCodeSystemCS.Code_Aspiration);                                                // CSBuilder.cs:387
		public TCoding Code_Biopsy = new TCoding(CorrespondsWithCodeSystemCS.Code_Biopsy);                                                        // CSBuilder.cs:387
		public TCoding Code_Concern = new TCoding(CorrespondsWithCodeSystemCS.Code_Concern);                                                      // CSBuilder.cs:387
		public TCoding Code_Ductogram = new TCoding(CorrespondsWithCodeSystemCS.Code_Ductogram);                                                  // CSBuilder.cs:387
		public TCoding Code_IncidentalFinding = new TCoding(CorrespondsWithCodeSystemCS.Code_IncidentalFinding);                                  // CSBuilder.cs:387
		public TCoding Code_Mammogram = new TCoding(CorrespondsWithCodeSystemCS.Code_Mammogram);                                                  // CSBuilder.cs:387
		public TCoding Code_MRI = new TCoding(CorrespondsWithCodeSystemCS.Code_MRI);                                                              // CSBuilder.cs:387
		public TCoding Code_NippleDischarge = new TCoding(CorrespondsWithCodeSystemCS.Code_NippleDischarge);                                      // CSBuilder.cs:387
		public TCoding Code_OutsideExam = new TCoding(CorrespondsWithCodeSystemCS.Code_OutsideExam);                                              // CSBuilder.cs:387
		public TCoding Code_Pain = new TCoding(CorrespondsWithCodeSystemCS.Code_Pain);                                                            // CSBuilder.cs:387
		public TCoding Code_Palpated = new TCoding(CorrespondsWithCodeSystemCS.Code_Palpated);                                                    // CSBuilder.cs:387
		public TCoding Code_PostOperative = new TCoding(CorrespondsWithCodeSystemCS.Code_PostOperative);                                          // CSBuilder.cs:387
		public TCoding Code_PreviousBiopsy = new TCoding(CorrespondsWithCodeSystemCS.Code_PreviousBiopsy);                                        // CSBuilder.cs:387
		public TCoding Code_PriorExam = new TCoding(CorrespondsWithCodeSystemCS.Code_PriorExam);                                                  // CSBuilder.cs:387
		public TCoding Code_Redness = new TCoding(CorrespondsWithCodeSystemCS.Code_Redness);                                                      // CSBuilder.cs:387
		public TCoding Code_Scinti = new TCoding(CorrespondsWithCodeSystemCS.Code_Scinti);                                                        // CSBuilder.cs:387
		public TCoding Code_SizeLessThanMammo = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanMammo);                                  // CSBuilder.cs:387
		public TCoding Code_SizeLessThanMRI = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanMRI);                                      // CSBuilder.cs:387
		public TCoding Code_SizeLessThanPalp = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanPalp);                                    // CSBuilder.cs:387
		public TCoding Code_SizeLessThanUS = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanUS);                                        // CSBuilder.cs:387
		public TCoding Code_SizeGreaterThanMammo = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanMammo);                            // CSBuilder.cs:387
		public TCoding Code_SizeGreaterThanMRI = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanMRI);                                // CSBuilder.cs:387
		public TCoding Code_SizeGreaterThanPalp = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanPalp);                              // CSBuilder.cs:387
		public TCoding Code_SizeGreaterThanUS = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanUS);                                  // CSBuilder.cs:387
		public TCoding Code_SkinMarker = new TCoding(CorrespondsWithCodeSystemCS.Code_SkinMarker);                                                // CSBuilder.cs:387
		public TCoding Code_Surgery = new TCoding(CorrespondsWithCodeSystemCS.Code_Surgery);                                                      // CSBuilder.cs:387
		public TCoding Code_SurgicalSite = new TCoding(CorrespondsWithCodeSystemCS.Code_SurgicalSite);                                            // CSBuilder.cs:387
		public TCoding Code_Tenderness = new TCoding(CorrespondsWithCodeSystemCS.Code_Tenderness);                                                // CSBuilder.cs:387
		public TCoding Code_TriggerPoint = new TCoding(CorrespondsWithCodeSystemCS.Code_TriggerPoint);                                            // CSBuilder.cs:387
		public TCoding Code_US = new TCoding(CorrespondsWithCodeSystemCS.Code_US);                                                                // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public CorrespondsWithVS()                                                                                                                // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(this.Code_Aspiration);                                                                                               // CSBuilder.cs:390
		    this.Members.Add(this.Code_Biopsy);                                                                                                   // CSBuilder.cs:390
		    this.Members.Add(this.Code_Concern);                                                                                                  // CSBuilder.cs:390
		    this.Members.Add(this.Code_Ductogram);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_IncidentalFinding);                                                                                        // CSBuilder.cs:390
		    this.Members.Add(this.Code_Mammogram);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_MRI);                                                                                                      // CSBuilder.cs:390
		    this.Members.Add(this.Code_NippleDischarge);                                                                                          // CSBuilder.cs:390
		    this.Members.Add(this.Code_OutsideExam);                                                                                              // CSBuilder.cs:390
		    this.Members.Add(this.Code_Pain);                                                                                                     // CSBuilder.cs:390
		    this.Members.Add(this.Code_Palpated);                                                                                                 // CSBuilder.cs:390
		    this.Members.Add(this.Code_PostOperative);                                                                                            // CSBuilder.cs:390
		    this.Members.Add(this.Code_PreviousBiopsy);                                                                                           // CSBuilder.cs:390
		    this.Members.Add(this.Code_PriorExam);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_Redness);                                                                                                  // CSBuilder.cs:390
		    this.Members.Add(this.Code_Scinti);                                                                                                   // CSBuilder.cs:390
		    this.Members.Add(this.Code_SizeLessThanMammo);                                                                                        // CSBuilder.cs:390
		    this.Members.Add(this.Code_SizeLessThanMRI);                                                                                          // CSBuilder.cs:390
		    this.Members.Add(this.Code_SizeLessThanPalp);                                                                                         // CSBuilder.cs:390
		    this.Members.Add(this.Code_SizeLessThanUS);                                                                                           // CSBuilder.cs:390
		    this.Members.Add(this.Code_SizeGreaterThanMammo);                                                                                     // CSBuilder.cs:390
		    this.Members.Add(this.Code_SizeGreaterThanMRI);                                                                                       // CSBuilder.cs:390
		    this.Members.Add(this.Code_SizeGreaterThanPalp);                                                                                      // CSBuilder.cs:390
		    this.Members.Add(this.Code_SizeGreaterThanUS);                                                                                        // CSBuilder.cs:390
		    this.Members.Add(this.Code_SkinMarker);                                                                                               // CSBuilder.cs:390
		    this.Members.Add(this.Code_Surgery);                                                                                                  // CSBuilder.cs:390
		    this.Members.Add(this.Code_SurgicalSite);                                                                                             // CSBuilder.cs:390
		    this.Members.Add(this.Code_Tenderness);                                                                                               // CSBuilder.cs:390
		    this.Members.Add(this.Code_TriggerPoint);                                                                                             // CSBuilder.cs:390
		    this.Members.Add(this.Code_US);                                                                                                       // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
