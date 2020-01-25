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
	public class BreastLocationClockVS                                                                                                         // CSBuilder.cs:336
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
		public TCoding Code_1200OClock = new TCoding(BreastLocationClockCS.Code_1200OClock);                                                      // CSBuilder.cs:387
		public TCoding Code_100OClock = new TCoding(BreastLocationClockCS.Code_100OClock);                                                        // CSBuilder.cs:387
		public TCoding Code_200OClock = new TCoding(BreastLocationClockCS.Code_200OClock);                                                        // CSBuilder.cs:387
		public TCoding Code_300OClock = new TCoding(BreastLocationClockCS.Code_300OClock);                                                        // CSBuilder.cs:387
		public TCoding Code_400OClock = new TCoding(BreastLocationClockCS.Code_400OClock);                                                        // CSBuilder.cs:387
		public TCoding Code_500OClock = new TCoding(BreastLocationClockCS.Code_500OClock);                                                        // CSBuilder.cs:387
		public TCoding Code_600OClock = new TCoding(BreastLocationClockCS.Code_600OClock);                                                        // CSBuilder.cs:387
		public TCoding Code_700OClock = new TCoding(BreastLocationClockCS.Code_700OClock);                                                        // CSBuilder.cs:387
		public TCoding Code_800OClock = new TCoding(BreastLocationClockCS.Code_800OClock);                                                        // CSBuilder.cs:387
		public TCoding Code_900OClock = new TCoding(BreastLocationClockCS.Code_900OClock);                                                        // CSBuilder.cs:387
		public TCoding Code_1000OClock = new TCoding(BreastLocationClockCS.Code_1000OClock);                                                      // CSBuilder.cs:387
		public TCoding Code_1100OClock = new TCoding(BreastLocationClockCS.Code_1100OClock);                                                      // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public BreastLocationClockVS()                                                                                                            // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(this.Code_1200OClock);                                                                                               // CSBuilder.cs:390
		    this.Members.Add(this.Code_100OClock);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_200OClock);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_300OClock);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_400OClock);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_500OClock);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_600OClock);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_700OClock);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_800OClock);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_900OClock);                                                                                                // CSBuilder.cs:390
		    this.Members.Add(this.Code_1000OClock);                                                                                               // CSBuilder.cs:390
		    this.Members.Add(this.Code_1100OClock);                                                                                               // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
