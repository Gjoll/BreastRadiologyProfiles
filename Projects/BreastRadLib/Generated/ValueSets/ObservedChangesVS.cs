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
	public class ObservedChangesVS                                                                                                             // CSBuilder.cs:361
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
		public TCoding Code_DecreaseInCalcifications = new TCoding(ObservedChangesCS.Code_DecreaseInCalcifications);                              // CSBuilder.cs:412
		public TCoding Code_DecreaseInNumber = new TCoding(ObservedChangesCS.Code_DecreaseInNumber);                                              // CSBuilder.cs:412
		public TCoding Code_DecreaseInSize = new TCoding(ObservedChangesCS.Code_DecreaseInSize);                                                  // CSBuilder.cs:412
		public TCoding Code_IncreaseInCalcifications = new TCoding(ObservedChangesCS.Code_IncreaseInCalcifications);                              // CSBuilder.cs:412
		public TCoding Code_IncreaseInNumber = new TCoding(ObservedChangesCS.Code_IncreaseInNumber);                                              // CSBuilder.cs:412
		public TCoding Code_IncreaseInSize = new TCoding(ObservedChangesCS.Code_IncreaseInSize);                                                  // CSBuilder.cs:412
		public TCoding Code_LessProminent = new TCoding(ObservedChangesCS.Code_LessProminent);                                                    // CSBuilder.cs:412
		public TCoding Code_MoreProminent = new TCoding(ObservedChangesCS.Code_MoreProminent);                                                    // CSBuilder.cs:412
		public TCoding Code_New = new TCoding(ObservedChangesCS.Code_New);                                                                        // CSBuilder.cs:412
		public TCoding Code_NoLongerSeen = new TCoding(ObservedChangesCS.Code_NoLongerSeen);                                                      // CSBuilder.cs:412
		public TCoding Code_NotSignificantChanged = new TCoding(ObservedChangesCS.Code_NotSignificantChanged);                                    // CSBuilder.cs:412
		public TCoding Code_PartiallyRemoved = new TCoding(ObservedChangesCS.Code_PartiallyRemoved);                                              // CSBuilder.cs:412
		public TCoding Code_RepresentsChange = new TCoding(ObservedChangesCS.Code_RepresentsChange);                                              // CSBuilder.cs:412
		public TCoding Code_Stable = new TCoding(ObservedChangesCS.Code_Stable);                                                                  // CSBuilder.cs:412
		public TCoding Code_IncidentalFinding = new TCoding(ObservedChangesCS.Code_IncidentalFinding);                                            // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:367
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:368
		                                                                                                                                          // CSBuilder.cs:369
		public ObservedChangesVS()                                                                                                                // CSBuilder.cs:370
		{                                                                                                                                         // CSBuilder.cs:371
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:372
		    this.Members.Add(this.Code_DecreaseInCalcifications);                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_DecreaseInNumber);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_DecreaseInSize);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_IncreaseInCalcifications);                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_IncreaseInNumber);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_IncreaseInSize);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_LessProminent);                                                                                            // CSBuilder.cs:415
		    this.Members.Add(this.Code_MoreProminent);                                                                                            // CSBuilder.cs:415
		    this.Members.Add(this.Code_New);                                                                                                      // CSBuilder.cs:415
		    this.Members.Add(this.Code_NoLongerSeen);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_NotSignificantChanged);                                                                                    // CSBuilder.cs:415
		    this.Members.Add(this.Code_PartiallyRemoved);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_RepresentsChange);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_Stable);                                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_IncidentalFinding);                                                                                        // CSBuilder.cs:415
		}                                                                                                                                         // CSBuilder.cs:374
		//- Fields
	}
}
