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
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public BreastLocationClockVS()                                                                                                            // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(BreastLocationClockCS.Code_1200OClock);                                                                              // CSBuilder.cs:362
		    this.Members.Add(BreastLocationClockCS.Code_100OClock);                                                                               // CSBuilder.cs:362
		    this.Members.Add(BreastLocationClockCS.Code_200OClock);                                                                               // CSBuilder.cs:362
		    this.Members.Add(BreastLocationClockCS.Code_300OClock);                                                                               // CSBuilder.cs:362
		    this.Members.Add(BreastLocationClockCS.Code_400OClock);                                                                               // CSBuilder.cs:362
		    this.Members.Add(BreastLocationClockCS.Code_500OClock);                                                                               // CSBuilder.cs:362
		    this.Members.Add(BreastLocationClockCS.Code_600OClock);                                                                               // CSBuilder.cs:362
		    this.Members.Add(BreastLocationClockCS.Code_700OClock);                                                                               // CSBuilder.cs:362
		    this.Members.Add(BreastLocationClockCS.Code_800OClock);                                                                               // CSBuilder.cs:362
		    this.Members.Add(BreastLocationClockCS.Code_900OClock);                                                                               // CSBuilder.cs:362
		    this.Members.Add(BreastLocationClockCS.Code_1000OClock);                                                                              // CSBuilder.cs:362
		    this.Members.Add(BreastLocationClockCS.Code_1100OClock);                                                                              // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
