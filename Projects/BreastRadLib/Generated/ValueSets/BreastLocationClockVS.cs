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
	public class BreastLocationClockVS                                                                                                         // CSBuilder.cs:369
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
		public TCoding Code_1OClock = new TCoding(BreastLocationClockCS.Code_1OClock);                                                            // CSBuilder.cs:420
		public TCoding Code_2OClock = new TCoding(BreastLocationClockCS.Code_2OClock);                                                            // CSBuilder.cs:420
		public TCoding Code_3OClock = new TCoding(BreastLocationClockCS.Code_3OClock);                                                            // CSBuilder.cs:420
		public TCoding Code_4OClock = new TCoding(BreastLocationClockCS.Code_4OClock);                                                            // CSBuilder.cs:420
		public TCoding Code_5OClock = new TCoding(BreastLocationClockCS.Code_5OClock);                                                            // CSBuilder.cs:420
		public TCoding Code_6OClock = new TCoding(BreastLocationClockCS.Code_6OClock);                                                            // CSBuilder.cs:420
		public TCoding Code_7OClock = new TCoding(BreastLocationClockCS.Code_7OClock);                                                            // CSBuilder.cs:420
		public TCoding Code_8OClock = new TCoding(BreastLocationClockCS.Code_8OClock);                                                            // CSBuilder.cs:420
		public TCoding Code_9OClock = new TCoding(BreastLocationClockCS.Code_9OClock);                                                            // CSBuilder.cs:420
		public TCoding Code_10OClock = new TCoding(BreastLocationClockCS.Code_10OClock);                                                          // CSBuilder.cs:420
		public TCoding Code_11OClock = new TCoding(BreastLocationClockCS.Code_11OClock);                                                          // CSBuilder.cs:420
		public TCoding Code_12OClock = new TCoding(BreastLocationClockCS.Code_12OClock);                                                          // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:375
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:376
		                                                                                                                                          // CSBuilder.cs:377
		public BreastLocationClockVS()                                                                                                            // CSBuilder.cs:378
		{                                                                                                                                         // CSBuilder.cs:379
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:380
		    this.Members.Add(this.Code_1OClock);                                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_2OClock);                                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_3OClock);                                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_4OClock);                                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_5OClock);                                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_6OClock);                                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_7OClock);                                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_8OClock);                                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_9OClock);                                                                                                  // CSBuilder.cs:423
		    this.Members.Add(this.Code_10OClock);                                                                                                 // CSBuilder.cs:423
		    this.Members.Add(this.Code_11OClock);                                                                                                 // CSBuilder.cs:423
		    this.Members.Add(this.Code_12OClock);                                                                                                 // CSBuilder.cs:423
		}                                                                                                                                         // CSBuilder.cs:382
		//- Fields
	}
}
