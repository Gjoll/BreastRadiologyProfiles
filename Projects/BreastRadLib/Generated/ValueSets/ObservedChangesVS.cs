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
	public class ObservedChangesVS                                                                                                             // CSBuilder.cs:338
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
		public TCoding Code_DecreaseInCalcifications = new TCoding(ObservedChangesCS.Code_DecreaseInCalcifications);                              // CSBuilder.cs:389
		public TCoding Code_DecreaseInNumber = new TCoding(ObservedChangesCS.Code_DecreaseInNumber);                                              // CSBuilder.cs:389
		public TCoding Code_DecreaseInSize = new TCoding(ObservedChangesCS.Code_DecreaseInSize);                                                  // CSBuilder.cs:389
		public TCoding Code_IncreaseInCalcifications = new TCoding(ObservedChangesCS.Code_IncreaseInCalcifications);                              // CSBuilder.cs:389
		public TCoding Code_IncreaseInNumber = new TCoding(ObservedChangesCS.Code_IncreaseInNumber);                                              // CSBuilder.cs:389
		public TCoding Code_IncreaseInSize = new TCoding(ObservedChangesCS.Code_IncreaseInSize);                                                  // CSBuilder.cs:389
		public TCoding Code_LessProminent = new TCoding(ObservedChangesCS.Code_LessProminent);                                                    // CSBuilder.cs:389
		public TCoding Code_MoreProminent = new TCoding(ObservedChangesCS.Code_MoreProminent);                                                    // CSBuilder.cs:389
		public TCoding Code_New = new TCoding(ObservedChangesCS.Code_New);                                                                        // CSBuilder.cs:389
		public TCoding Code_NoLongerSeen = new TCoding(ObservedChangesCS.Code_NoLongerSeen);                                                      // CSBuilder.cs:389
		public TCoding Code_NotSignificantChanged = new TCoding(ObservedChangesCS.Code_NotSignificantChanged);                                    // CSBuilder.cs:389
		public TCoding Code_PartiallyRemoved = new TCoding(ObservedChangesCS.Code_PartiallyRemoved);                                              // CSBuilder.cs:389
		public TCoding Code_RepresentsChange = new TCoding(ObservedChangesCS.Code_RepresentsChange);                                              // CSBuilder.cs:389
		public TCoding Code_Stable = new TCoding(ObservedChangesCS.Code_Stable);                                                                  // CSBuilder.cs:389
		                                                                                                                                          // CSBuilder.cs:344
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:345
		                                                                                                                                          // CSBuilder.cs:346
		public ObservedChangesVS()                                                                                                                // CSBuilder.cs:347
		{                                                                                                                                         // CSBuilder.cs:348
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:349
		    this.Members.Add(this.Code_DecreaseInCalcifications);                                                                                 // CSBuilder.cs:392
		    this.Members.Add(this.Code_DecreaseInNumber);                                                                                         // CSBuilder.cs:392
		    this.Members.Add(this.Code_DecreaseInSize);                                                                                           // CSBuilder.cs:392
		    this.Members.Add(this.Code_IncreaseInCalcifications);                                                                                 // CSBuilder.cs:392
		    this.Members.Add(this.Code_IncreaseInNumber);                                                                                         // CSBuilder.cs:392
		    this.Members.Add(this.Code_IncreaseInSize);                                                                                           // CSBuilder.cs:392
		    this.Members.Add(this.Code_LessProminent);                                                                                            // CSBuilder.cs:392
		    this.Members.Add(this.Code_MoreProminent);                                                                                            // CSBuilder.cs:392
		    this.Members.Add(this.Code_New);                                                                                                      // CSBuilder.cs:392
		    this.Members.Add(this.Code_NoLongerSeen);                                                                                             // CSBuilder.cs:392
		    this.Members.Add(this.Code_NotSignificantChanged);                                                                                    // CSBuilder.cs:392
		    this.Members.Add(this.Code_PartiallyRemoved);                                                                                         // CSBuilder.cs:392
		    this.Members.Add(this.Code_RepresentsChange);                                                                                         // CSBuilder.cs:392
		    this.Members.Add(this.Code_Stable);                                                                                                   // CSBuilder.cs:392
		}                                                                                                                                         // CSBuilder.cs:351
		//- Fields
	}
}
