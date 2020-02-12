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
	public class BreastLocationClockVS                                                                                                         // CSBuilder.cs:338
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
		public TCoding Code_1OClock = new TCoding(BreastLocationClockCS.Code_1OClock);                                                            // CSBuilder.cs:389
		public TCoding Code_2OClock = new TCoding(BreastLocationClockCS.Code_2OClock);                                                            // CSBuilder.cs:389
		public TCoding Code_3OClock = new TCoding(BreastLocationClockCS.Code_3OClock);                                                            // CSBuilder.cs:389
		public TCoding Code_4OClock = new TCoding(BreastLocationClockCS.Code_4OClock);                                                            // CSBuilder.cs:389
		public TCoding Code_5OClock = new TCoding(BreastLocationClockCS.Code_5OClock);                                                            // CSBuilder.cs:389
		public TCoding Code_6OClock = new TCoding(BreastLocationClockCS.Code_6OClock);                                                            // CSBuilder.cs:389
		public TCoding Code_7OClock = new TCoding(BreastLocationClockCS.Code_7OClock);                                                            // CSBuilder.cs:389
		public TCoding Code_8OClock = new TCoding(BreastLocationClockCS.Code_8OClock);                                                            // CSBuilder.cs:389
		public TCoding Code_9OClock = new TCoding(BreastLocationClockCS.Code_9OClock);                                                            // CSBuilder.cs:389
		public TCoding Code_10OClock = new TCoding(BreastLocationClockCS.Code_10OClock);                                                          // CSBuilder.cs:389
		public TCoding Code_11OClock = new TCoding(BreastLocationClockCS.Code_11OClock);                                                          // CSBuilder.cs:389
		public TCoding Code_12OClock = new TCoding(BreastLocationClockCS.Code_12OClock);                                                          // CSBuilder.cs:389
		                                                                                                                                          // CSBuilder.cs:344
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:345
		                                                                                                                                          // CSBuilder.cs:346
		public BreastLocationClockVS()                                                                                                            // CSBuilder.cs:347
		{                                                                                                                                         // CSBuilder.cs:348
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:349
		    this.Members.Add(this.Code_1OClock);                                                                                                  // CSBuilder.cs:392
		    this.Members.Add(this.Code_2OClock);                                                                                                  // CSBuilder.cs:392
		    this.Members.Add(this.Code_3OClock);                                                                                                  // CSBuilder.cs:392
		    this.Members.Add(this.Code_4OClock);                                                                                                  // CSBuilder.cs:392
		    this.Members.Add(this.Code_5OClock);                                                                                                  // CSBuilder.cs:392
		    this.Members.Add(this.Code_6OClock);                                                                                                  // CSBuilder.cs:392
		    this.Members.Add(this.Code_7OClock);                                                                                                  // CSBuilder.cs:392
		    this.Members.Add(this.Code_8OClock);                                                                                                  // CSBuilder.cs:392
		    this.Members.Add(this.Code_9OClock);                                                                                                  // CSBuilder.cs:392
		    this.Members.Add(this.Code_10OClock);                                                                                                 // CSBuilder.cs:392
		    this.Members.Add(this.Code_11OClock);                                                                                                 // CSBuilder.cs:392
		    this.Members.Add(this.Code_12OClock);                                                                                                 // CSBuilder.cs:392
		}                                                                                                                                         // CSBuilder.cs:351
		//- Fields
	}
}
