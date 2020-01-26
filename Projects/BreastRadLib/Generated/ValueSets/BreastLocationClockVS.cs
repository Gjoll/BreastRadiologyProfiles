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
	public class BreastLocationClockVS                                                                                                         // CSBuilder.cs:413
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
		public TCoding Code_1200OClock = new TCoding(BreastLocationClockCS.Code_1200OClock);                                                      // CSBuilder.cs:464
		public TCoding Code_100OClock = new TCoding(BreastLocationClockCS.Code_100OClock);                                                        // CSBuilder.cs:464
		public TCoding Code_200OClock = new TCoding(BreastLocationClockCS.Code_200OClock);                                                        // CSBuilder.cs:464
		public TCoding Code_300OClock = new TCoding(BreastLocationClockCS.Code_300OClock);                                                        // CSBuilder.cs:464
		public TCoding Code_400OClock = new TCoding(BreastLocationClockCS.Code_400OClock);                                                        // CSBuilder.cs:464
		public TCoding Code_500OClock = new TCoding(BreastLocationClockCS.Code_500OClock);                                                        // CSBuilder.cs:464
		public TCoding Code_600OClock = new TCoding(BreastLocationClockCS.Code_600OClock);                                                        // CSBuilder.cs:464
		public TCoding Code_700OClock = new TCoding(BreastLocationClockCS.Code_700OClock);                                                        // CSBuilder.cs:464
		public TCoding Code_800OClock = new TCoding(BreastLocationClockCS.Code_800OClock);                                                        // CSBuilder.cs:464
		public TCoding Code_900OClock = new TCoding(BreastLocationClockCS.Code_900OClock);                                                        // CSBuilder.cs:464
		public TCoding Code_1000OClock = new TCoding(BreastLocationClockCS.Code_1000OClock);                                                      // CSBuilder.cs:464
		public TCoding Code_1100OClock = new TCoding(BreastLocationClockCS.Code_1100OClock);                                                      // CSBuilder.cs:464
		                                                                                                                                          // CSBuilder.cs:419
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:421
		public BreastLocationClockVS()                                                                                                            // CSBuilder.cs:422
		{                                                                                                                                         // CSBuilder.cs:423
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:424
		    this.Members.Add(this.Code_1200OClock);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_100OClock);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_200OClock);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_300OClock);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_400OClock);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_500OClock);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_600OClock);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_700OClock);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_800OClock);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_900OClock);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_1000OClock);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_1100OClock);                                                                                               // CSBuilder.cs:467
		}                                                                                                                                         // CSBuilder.cs:426
		//- Fields
	}
}
