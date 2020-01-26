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
	public class BreastLocationClockVS                                                                                                         // CSBuilder.cs:361
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
		public TCoding Code_1200OClock = new TCoding(BreastLocationClockCS.Code_1200OClock);                                                      // CSBuilder.cs:412
		public TCoding Code_100OClock = new TCoding(BreastLocationClockCS.Code_100OClock);                                                        // CSBuilder.cs:412
		public TCoding Code_200OClock = new TCoding(BreastLocationClockCS.Code_200OClock);                                                        // CSBuilder.cs:412
		public TCoding Code_300OClock = new TCoding(BreastLocationClockCS.Code_300OClock);                                                        // CSBuilder.cs:412
		public TCoding Code_400OClock = new TCoding(BreastLocationClockCS.Code_400OClock);                                                        // CSBuilder.cs:412
		public TCoding Code_500OClock = new TCoding(BreastLocationClockCS.Code_500OClock);                                                        // CSBuilder.cs:412
		public TCoding Code_600OClock = new TCoding(BreastLocationClockCS.Code_600OClock);                                                        // CSBuilder.cs:412
		public TCoding Code_700OClock = new TCoding(BreastLocationClockCS.Code_700OClock);                                                        // CSBuilder.cs:412
		public TCoding Code_800OClock = new TCoding(BreastLocationClockCS.Code_800OClock);                                                        // CSBuilder.cs:412
		public TCoding Code_900OClock = new TCoding(BreastLocationClockCS.Code_900OClock);                                                        // CSBuilder.cs:412
		public TCoding Code_1000OClock = new TCoding(BreastLocationClockCS.Code_1000OClock);                                                      // CSBuilder.cs:412
		public TCoding Code_1100OClock = new TCoding(BreastLocationClockCS.Code_1100OClock);                                                      // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:367
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:368
		                                                                                                                                          // CSBuilder.cs:369
		public BreastLocationClockVS()                                                                                                            // CSBuilder.cs:370
		{                                                                                                                                         // CSBuilder.cs:371
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:372
		    this.Members.Add(this.Code_1200OClock);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_100OClock);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_200OClock);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_300OClock);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_400OClock);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_500OClock);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_600OClock);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_700OClock);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_800OClock);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_900OClock);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_1000OClock);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_1100OClock);                                                                                               // CSBuilder.cs:415
		}                                                                                                                                         // CSBuilder.cs:374
		//- Fields
	}
}
