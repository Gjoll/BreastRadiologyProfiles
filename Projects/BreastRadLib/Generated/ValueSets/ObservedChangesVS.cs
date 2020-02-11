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
	public class ObservedChangesVS                                                                                                             // CSBuilder.cs:369
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
		public TCoding Code_DecreaseInCalcifications = new TCoding(ObservedChangesCS.Code_DecreaseInCalcifications);                              // CSBuilder.cs:420
		public TCoding Code_DecreaseInNumber = new TCoding(ObservedChangesCS.Code_DecreaseInNumber);                                              // CSBuilder.cs:420
		public TCoding Code_DecreaseInSize = new TCoding(ObservedChangesCS.Code_DecreaseInSize);                                                  // CSBuilder.cs:420
		public TCoding Code_IncreaseInCalcifications = new TCoding(ObservedChangesCS.Code_IncreaseInCalcifications);                              // CSBuilder.cs:420
		public TCoding Code_IncreaseInNumber = new TCoding(ObservedChangesCS.Code_IncreaseInNumber);                                              // CSBuilder.cs:420
		public TCoding Code_IncreaseInSize = new TCoding(ObservedChangesCS.Code_IncreaseInSize);                                                  // CSBuilder.cs:420
		public TCoding Code_LessProminent = new TCoding(ObservedChangesCS.Code_LessProminent);                                                    // CSBuilder.cs:420
		public TCoding Code_MoreProminent = new TCoding(ObservedChangesCS.Code_MoreProminent);                                                    // CSBuilder.cs:420
		public TCoding Code_New = new TCoding(ObservedChangesCS.Code_New);                                                                        // CSBuilder.cs:420
		public TCoding Code_NoLongerSeen = new TCoding(ObservedChangesCS.Code_NoLongerSeen);                                                      // CSBuilder.cs:420
		public TCoding Code_NotSignificantChanged = new TCoding(ObservedChangesCS.Code_NotSignificantChanged);                                    // CSBuilder.cs:420
		public TCoding Code_PartiallyRemoved = new TCoding(ObservedChangesCS.Code_PartiallyRemoved);                                              // CSBuilder.cs:420
		public TCoding Code_RepresentsChange = new TCoding(ObservedChangesCS.Code_RepresentsChange);                                              // CSBuilder.cs:420
		public TCoding Code_Stable = new TCoding(ObservedChangesCS.Code_Stable);                                                                  // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:375
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:376
		                                                                                                                                          // CSBuilder.cs:377
		public ObservedChangesVS()                                                                                                                // CSBuilder.cs:378
		{                                                                                                                                         // CSBuilder.cs:379
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:380
		    this.Members.Add(this.Code_DecreaseInCalcifications);                                                                                 // CSBuilder.cs:423
		    this.Members.Add(this.Code_DecreaseInNumber);                                                                                         // CSBuilder.cs:423
		    this.Members.Add(this.Code_DecreaseInSize);                                                                                           // CSBuilder.cs:423
		    this.Members.Add(this.Code_IncreaseInCalcifications);                                                                                 // CSBuilder.cs:423
		    this.Members.Add(this.Code_IncreaseInNumber);                                                                                         // CSBuilder.cs:423
		    this.Members.Add(this.Code_IncreaseInSize);                                                                                           // CSBuilder.cs:423
		    this.Members.Add(this.Code_LessProminent);                                                                                            // CSBuilder.cs:423
		    this.Members.Add(this.Code_MoreProminent);                                                                                            // CSBuilder.cs:423
		    this.Members.Add(this.Code_New);                                                                                                      // CSBuilder.cs:423
		    this.Members.Add(this.Code_NoLongerSeen);                                                                                             // CSBuilder.cs:423
		    this.Members.Add(this.Code_NotSignificantChanged);                                                                                    // CSBuilder.cs:423
		    this.Members.Add(this.Code_PartiallyRemoved);                                                                                         // CSBuilder.cs:423
		    this.Members.Add(this.Code_RepresentsChange);                                                                                         // CSBuilder.cs:423
		    this.Members.Add(this.Code_Stable);                                                                                                   // CSBuilder.cs:423
		}                                                                                                                                         // CSBuilder.cs:382
		//- Fields
	}
}
