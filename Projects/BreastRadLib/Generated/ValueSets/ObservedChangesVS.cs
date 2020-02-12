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
	public class ObservedChangesVS                                                                                                             // CSBuilder.cs:331
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:352
		{                                                                                                                                         // CSBuilder.cs:353
		    Coding value;                                                                                                                         // CSBuilder.cs:354
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:355
		    {                                                                                                                                     // CSBuilder.cs:356
		        return tCode.value;                                                                                                               // CSBuilder.cs:357
		    }                                                                                                                                     // CSBuilder.cs:358
		                                                                                                                                          // CSBuilder.cs:359
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        this.value= value;                                                                                                                // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		}                                                                                                                                         // CSBuilder.cs:364
		public TCoding Code_DecreaseInCalcifications = new TCoding(ObservedChangesCS.Code_DecreaseInCalcifications);                              // CSBuilder.cs:382
		public TCoding Code_DecreaseInNumber = new TCoding(ObservedChangesCS.Code_DecreaseInNumber);                                              // CSBuilder.cs:382
		public TCoding Code_DecreaseInSize = new TCoding(ObservedChangesCS.Code_DecreaseInSize);                                                  // CSBuilder.cs:382
		public TCoding Code_IncreaseInCalcifications = new TCoding(ObservedChangesCS.Code_IncreaseInCalcifications);                              // CSBuilder.cs:382
		public TCoding Code_IncreaseInNumber = new TCoding(ObservedChangesCS.Code_IncreaseInNumber);                                              // CSBuilder.cs:382
		public TCoding Code_IncreaseInSize = new TCoding(ObservedChangesCS.Code_IncreaseInSize);                                                  // CSBuilder.cs:382
		public TCoding Code_LessProminent = new TCoding(ObservedChangesCS.Code_LessProminent);                                                    // CSBuilder.cs:382
		public TCoding Code_MoreProminent = new TCoding(ObservedChangesCS.Code_MoreProminent);                                                    // CSBuilder.cs:382
		public TCoding Code_New = new TCoding(ObservedChangesCS.Code_New);                                                                        // CSBuilder.cs:382
		public TCoding Code_NoLongerSeen = new TCoding(ObservedChangesCS.Code_NoLongerSeen);                                                      // CSBuilder.cs:382
		public TCoding Code_NotSignificantChanged = new TCoding(ObservedChangesCS.Code_NotSignificantChanged);                                    // CSBuilder.cs:382
		public TCoding Code_PartiallyRemoved = new TCoding(ObservedChangesCS.Code_PartiallyRemoved);                                              // CSBuilder.cs:382
		public TCoding Code_RepresentsChange = new TCoding(ObservedChangesCS.Code_RepresentsChange);                                              // CSBuilder.cs:382
		public TCoding Code_Stable = new TCoding(ObservedChangesCS.Code_Stable);                                                                  // CSBuilder.cs:382
		                                                                                                                                          // CSBuilder.cs:337
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:338
		                                                                                                                                          // CSBuilder.cs:339
		public ObservedChangesVS()                                                                                                                // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:342
		    this.Members.Add(this.Code_DecreaseInCalcifications);                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_DecreaseInNumber);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_DecreaseInSize);                                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_IncreaseInCalcifications);                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_IncreaseInNumber);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_IncreaseInSize);                                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_LessProminent);                                                                                            // CSBuilder.cs:385
		    this.Members.Add(this.Code_MoreProminent);                                                                                            // CSBuilder.cs:385
		    this.Members.Add(this.Code_New);                                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_NoLongerSeen);                                                                                             // CSBuilder.cs:385
		    this.Members.Add(this.Code_NotSignificantChanged);                                                                                    // CSBuilder.cs:385
		    this.Members.Add(this.Code_PartiallyRemoved);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_RepresentsChange);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_Stable);                                                                                                   // CSBuilder.cs:385
		}                                                                                                                                         // CSBuilder.cs:344
		//- Fields
	}
}
