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
	public class ObservedChangesVS                                                                                                             // CSBuilder.cs:413
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
		public TCoding Code_DecreaseInCalcifications = new TCoding(ObservedChangesCS.Code_DecreaseInCalcifications);                              // CSBuilder.cs:464
		public TCoding Code_DecreaseInNumber = new TCoding(ObservedChangesCS.Code_DecreaseInNumber);                                              // CSBuilder.cs:464
		public TCoding Code_DecreaseInSize = new TCoding(ObservedChangesCS.Code_DecreaseInSize);                                                  // CSBuilder.cs:464
		public TCoding Code_IncreaseInCalcifications = new TCoding(ObservedChangesCS.Code_IncreaseInCalcifications);                              // CSBuilder.cs:464
		public TCoding Code_IncreaseInNumber = new TCoding(ObservedChangesCS.Code_IncreaseInNumber);                                              // CSBuilder.cs:464
		public TCoding Code_IncreaseInSize = new TCoding(ObservedChangesCS.Code_IncreaseInSize);                                                  // CSBuilder.cs:464
		public TCoding Code_LessProminent = new TCoding(ObservedChangesCS.Code_LessProminent);                                                    // CSBuilder.cs:464
		public TCoding Code_MoreProminent = new TCoding(ObservedChangesCS.Code_MoreProminent);                                                    // CSBuilder.cs:464
		public TCoding Code_New = new TCoding(ObservedChangesCS.Code_New);                                                                        // CSBuilder.cs:464
		public TCoding Code_NoLongerSeen = new TCoding(ObservedChangesCS.Code_NoLongerSeen);                                                      // CSBuilder.cs:464
		public TCoding Code_NotSignificantChanged = new TCoding(ObservedChangesCS.Code_NotSignificantChanged);                                    // CSBuilder.cs:464
		public TCoding Code_PartiallyRemoved = new TCoding(ObservedChangesCS.Code_PartiallyRemoved);                                              // CSBuilder.cs:464
		public TCoding Code_RepresentsChange = new TCoding(ObservedChangesCS.Code_RepresentsChange);                                              // CSBuilder.cs:464
		public TCoding Code_Stable = new TCoding(ObservedChangesCS.Code_Stable);                                                                  // CSBuilder.cs:464
		public TCoding Code_IncidentalFinding = new TCoding(ObservedChangesCS.Code_IncidentalFinding);                                            // CSBuilder.cs:464
		                                                                                                                                          // CSBuilder.cs:419
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:421
		public ObservedChangesVS()                                                                                                                // CSBuilder.cs:422
		{                                                                                                                                         // CSBuilder.cs:423
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:424
		    this.Members.Add(this.Code_DecreaseInCalcifications);                                                                                 // CSBuilder.cs:467
		    this.Members.Add(this.Code_DecreaseInNumber);                                                                                         // CSBuilder.cs:467
		    this.Members.Add(this.Code_DecreaseInSize);                                                                                           // CSBuilder.cs:467
		    this.Members.Add(this.Code_IncreaseInCalcifications);                                                                                 // CSBuilder.cs:467
		    this.Members.Add(this.Code_IncreaseInNumber);                                                                                         // CSBuilder.cs:467
		    this.Members.Add(this.Code_IncreaseInSize);                                                                                           // CSBuilder.cs:467
		    this.Members.Add(this.Code_LessProminent);                                                                                            // CSBuilder.cs:467
		    this.Members.Add(this.Code_MoreProminent);                                                                                            // CSBuilder.cs:467
		    this.Members.Add(this.Code_New);                                                                                                      // CSBuilder.cs:467
		    this.Members.Add(this.Code_NoLongerSeen);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_NotSignificantChanged);                                                                                    // CSBuilder.cs:467
		    this.Members.Add(this.Code_PartiallyRemoved);                                                                                         // CSBuilder.cs:467
		    this.Members.Add(this.Code_RepresentsChange);                                                                                         // CSBuilder.cs:467
		    this.Members.Add(this.Code_Stable);                                                                                                   // CSBuilder.cs:467
		    this.Members.Add(this.Code_IncidentalFinding);                                                                                        // CSBuilder.cs:467
		}                                                                                                                                         // CSBuilder.cs:426
		//- Fields
	}
}
