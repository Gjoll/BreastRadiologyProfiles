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
	public class BreastLocationClockVS                                                                                                         // CSBuilder.cs:403
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:424
		{                                                                                                                                         // CSBuilder.cs:425
		    Coding value;                                                                                                                         // CSBuilder.cs:426
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:427
		    {                                                                                                                                     // CSBuilder.cs:428
		        return tCode.value;                                                                                                               // CSBuilder.cs:429
		    }                                                                                                                                     // CSBuilder.cs:430
		                                                                                                                                          // CSBuilder.cs:431
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:432
		    {                                                                                                                                     // CSBuilder.cs:433
		        this.value= value;                                                                                                                // CSBuilder.cs:434
		    }                                                                                                                                     // CSBuilder.cs:435
		}                                                                                                                                         // CSBuilder.cs:436
		public TCoding Code_1200OClock = new TCoding(BreastLocationClockCS.Code_1200OClock);                                                      // CSBuilder.cs:454
		public TCoding Code_100OClock = new TCoding(BreastLocationClockCS.Code_100OClock);                                                        // CSBuilder.cs:454
		public TCoding Code_200OClock = new TCoding(BreastLocationClockCS.Code_200OClock);                                                        // CSBuilder.cs:454
		public TCoding Code_300OClock = new TCoding(BreastLocationClockCS.Code_300OClock);                                                        // CSBuilder.cs:454
		public TCoding Code_400OClock = new TCoding(BreastLocationClockCS.Code_400OClock);                                                        // CSBuilder.cs:454
		public TCoding Code_500OClock = new TCoding(BreastLocationClockCS.Code_500OClock);                                                        // CSBuilder.cs:454
		public TCoding Code_600OClock = new TCoding(BreastLocationClockCS.Code_600OClock);                                                        // CSBuilder.cs:454
		public TCoding Code_700OClock = new TCoding(BreastLocationClockCS.Code_700OClock);                                                        // CSBuilder.cs:454
		public TCoding Code_800OClock = new TCoding(BreastLocationClockCS.Code_800OClock);                                                        // CSBuilder.cs:454
		public TCoding Code_900OClock = new TCoding(BreastLocationClockCS.Code_900OClock);                                                        // CSBuilder.cs:454
		public TCoding Code_1000OClock = new TCoding(BreastLocationClockCS.Code_1000OClock);                                                      // CSBuilder.cs:454
		public TCoding Code_1100OClock = new TCoding(BreastLocationClockCS.Code_1100OClock);                                                      // CSBuilder.cs:454
		                                                                                                                                          // CSBuilder.cs:409
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:411
		public BreastLocationClockVS()                                                                                                            // CSBuilder.cs:412
		{                                                                                                                                         // CSBuilder.cs:413
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:414
		    this.Members.Add(this.Code_1200OClock);                                                                                               // CSBuilder.cs:457
		    this.Members.Add(this.Code_100OClock);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_200OClock);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_300OClock);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_400OClock);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_500OClock);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_600OClock);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_700OClock);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_800OClock);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_900OClock);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_1000OClock);                                                                                               // CSBuilder.cs:457
		    this.Members.Add(this.Code_1100OClock);                                                                                               // CSBuilder.cs:457
		}                                                                                                                                         // CSBuilder.cs:416
		//- Fields
	}
}
