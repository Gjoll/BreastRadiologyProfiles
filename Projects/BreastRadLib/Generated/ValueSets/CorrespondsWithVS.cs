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
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public CorrespondsWithVS()                                                                                                                // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_Aspiration);                                                                        // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_Biopsy);                                                                            // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_Concern);                                                                           // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_Ductogram);                                                                         // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_IncidentalFinding);                                                                 // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_Mammogram);                                                                         // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_MRI);                                                                               // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_NippleDischarge);                                                                   // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_OutsideExam);                                                                       // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_Pain);                                                                              // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_Palpated);                                                                          // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_PostOperative);                                                                     // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_PreviousBiopsy);                                                                    // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_PriorExam);                                                                         // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_Redness);                                                                           // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_Scinti);                                                                            // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_SizeLessThanMammo);                                                                 // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_SizeLessThanMRI);                                                                   // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_SizeLessThanPalp);                                                                  // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_SizeLessThanUS);                                                                    // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanMammo);                                                              // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanMRI);                                                                // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanPalp);                                                               // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_SizeGreaterThanUS);                                                                 // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_SkinMarker);                                                                        // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_Surgery);                                                                           // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_SurgicalSite);                                                                      // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_Tenderness);                                                                        // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_TriggerPoint);                                                                      // CSBuilder.cs:362
		    this.Members.Add(CorrespondsWithCodeSystemCS.Code_US);                                                                                // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
