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
	public class CorrespondsWithVS                                                                                                             // CSBuilder.cs:361
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
		public TCoding Code_Aspiration = new TCoding(CorrespondsWithCodeSystemCS.Code_Aspiration);                                                // CSBuilder.cs:412
		public TCoding Code_Biopsy = new TCoding(CorrespondsWithCodeSystemCS.Code_Biopsy);                                                        // CSBuilder.cs:412
		public TCoding Code_Concern = new TCoding(CorrespondsWithCodeSystemCS.Code_Concern);                                                      // CSBuilder.cs:412
		public TCoding Code_Ductogram = new TCoding(CorrespondsWithCodeSystemCS.Code_Ductogram);                                                  // CSBuilder.cs:412
		public TCoding Code_IncidentalFinding = new TCoding(CorrespondsWithCodeSystemCS.Code_IncidentalFinding);                                  // CSBuilder.cs:412
		public TCoding Code_Mammogram = new TCoding(CorrespondsWithCodeSystemCS.Code_Mammogram);                                                  // CSBuilder.cs:412
		public TCoding Code_MRI = new TCoding(CorrespondsWithCodeSystemCS.Code_MRI);                                                              // CSBuilder.cs:412
		public TCoding Code_NippleDischarge = new TCoding(CorrespondsWithCodeSystemCS.Code_NippleDischarge);                                      // CSBuilder.cs:412
		public TCoding Code_OutsideExam = new TCoding(CorrespondsWithCodeSystemCS.Code_OutsideExam);                                              // CSBuilder.cs:412
		public TCoding Code_Pain = new TCoding(CorrespondsWithCodeSystemCS.Code_Pain);                                                            // CSBuilder.cs:412
		public TCoding Code_Palpated = new TCoding(CorrespondsWithCodeSystemCS.Code_Palpated);                                                    // CSBuilder.cs:412
		public TCoding Code_PostOperative = new TCoding(CorrespondsWithCodeSystemCS.Code_PostOperative);                                          // CSBuilder.cs:412
		public TCoding Code_PreviousBiopsy = new TCoding(CorrespondsWithCodeSystemCS.Code_PreviousBiopsy);                                        // CSBuilder.cs:412
		public TCoding Code_PriorExam = new TCoding(CorrespondsWithCodeSystemCS.Code_PriorExam);                                                  // CSBuilder.cs:412
		public TCoding Code_Redness = new TCoding(CorrespondsWithCodeSystemCS.Code_Redness);                                                      // CSBuilder.cs:412
		public TCoding Code_Scinti = new TCoding(CorrespondsWithCodeSystemCS.Code_Scinti);                                                        // CSBuilder.cs:412
		public TCoding Code_SizeLessThanMammo = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanMammo);                                  // CSBuilder.cs:412
		public TCoding Code_SizeLessThanMRI = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanMRI);                                      // CSBuilder.cs:412
		public TCoding Code_SizeLessThanPalp = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanPalp);                                    // CSBuilder.cs:412
		public TCoding Code_SizeLessThanUS = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeLessThanUS);                                        // CSBuilder.cs:412
		public TCoding Code_SizeGreaterThanMammo = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanMammo);                            // CSBuilder.cs:412
		public TCoding Code_SizeGreaterThanMRI = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanMRI);                                // CSBuilder.cs:412
		public TCoding Code_SizeGreaterThanPalp = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanPalp);                              // CSBuilder.cs:412
		public TCoding Code_SizeGreaterThanUS = new TCoding(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanUS);                                  // CSBuilder.cs:412
		public TCoding Code_SkinMarker = new TCoding(CorrespondsWithCodeSystemCS.Code_SkinMarker);                                                // CSBuilder.cs:412
		public TCoding Code_Surgery = new TCoding(CorrespondsWithCodeSystemCS.Code_Surgery);                                                      // CSBuilder.cs:412
		public TCoding Code_SurgicalSite = new TCoding(CorrespondsWithCodeSystemCS.Code_SurgicalSite);                                            // CSBuilder.cs:412
		public TCoding Code_Tenderness = new TCoding(CorrespondsWithCodeSystemCS.Code_Tenderness);                                                // CSBuilder.cs:412
		public TCoding Code_TriggerPoint = new TCoding(CorrespondsWithCodeSystemCS.Code_TriggerPoint);                                            // CSBuilder.cs:412
		public TCoding Code_US = new TCoding(CorrespondsWithCodeSystemCS.Code_US);                                                                // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:367
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:368
		                                                                                                                                          // CSBuilder.cs:369
		public CorrespondsWithVS()                                                                                                                // CSBuilder.cs:370
		{                                                                                                                                         // CSBuilder.cs:371
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:372
		    this.Members.Add(this.Code_Aspiration);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_Biopsy);                                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_Concern);                                                                                                  // CSBuilder.cs:415
		    this.Members.Add(this.Code_Ductogram);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_IncidentalFinding);                                                                                        // CSBuilder.cs:415
		    this.Members.Add(this.Code_Mammogram);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_MRI);                                                                                                      // CSBuilder.cs:415
		    this.Members.Add(this.Code_NippleDischarge);                                                                                          // CSBuilder.cs:415
		    this.Members.Add(this.Code_OutsideExam);                                                                                              // CSBuilder.cs:415
		    this.Members.Add(this.Code_Pain);                                                                                                     // CSBuilder.cs:415
		    this.Members.Add(this.Code_Palpated);                                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_PostOperative);                                                                                            // CSBuilder.cs:415
		    this.Members.Add(this.Code_PreviousBiopsy);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_PriorExam);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_Redness);                                                                                                  // CSBuilder.cs:415
		    this.Members.Add(this.Code_Scinti);                                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_SizeLessThanMammo);                                                                                        // CSBuilder.cs:415
		    this.Members.Add(this.Code_SizeLessThanMRI);                                                                                          // CSBuilder.cs:415
		    this.Members.Add(this.Code_SizeLessThanPalp);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_SizeLessThanUS);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_SizeGreaterThanMammo);                                                                                     // CSBuilder.cs:415
		    this.Members.Add(this.Code_SizeGreaterThanMRI);                                                                                       // CSBuilder.cs:415
		    this.Members.Add(this.Code_SizeGreaterThanPalp);                                                                                      // CSBuilder.cs:415
		    this.Members.Add(this.Code_SizeGreaterThanUS);                                                                                        // CSBuilder.cs:415
		    this.Members.Add(this.Code_SkinMarker);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_Surgery);                                                                                                  // CSBuilder.cs:415
		    this.Members.Add(this.Code_SurgicalSite);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_Tenderness);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_TriggerPoint);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_US);                                                                                                       // CSBuilder.cs:415
		}                                                                                                                                         // CSBuilder.cs:374
		//- Fields
	}
}
