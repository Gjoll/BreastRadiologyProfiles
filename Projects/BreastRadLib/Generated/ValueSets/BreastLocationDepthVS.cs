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
	public class BreastLocationDepthVS                                                                                                         // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that explicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:357
		{                                                                                                                                         // CSBuilder.cs:358
		    Coding value;                                                                                                                         // CSBuilder.cs:359
		    public static explicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        return tCode.value;                                                                                                               // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		                                                                                                                                          // CSBuilder.cs:364
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:365
		    {                                                                                                                                     // CSBuilder.cs:366
		        this.value= value;                                                                                                                // CSBuilder.cs:367
		    }                                                                                                                                     // CSBuilder.cs:368
		}                                                                                                                                         // CSBuilder.cs:369
		public TCoding Code_Anterior = new TCoding(BreastLocationDepthCS.Code_Anterior);                                                          // CSBuilder.cs:387
		public TCoding Code_Middle = new TCoding(BreastLocationDepthCS.Code_Middle);                                                              // CSBuilder.cs:387
		public TCoding Code_Posterior = new TCoding(BreastLocationDepthCS.Code_Posterior);                                                        // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public BreastLocationDepthVS()                                                                                                            // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(BreastLocationDepthCS.Code_Anterior);                                                                                // CSBuilder.cs:390
		    this.Members.Add(BreastLocationDepthCS.Code_Middle);                                                                                  // CSBuilder.cs:390
		    this.Members.Add(BreastLocationDepthCS.Code_Posterior);                                                                               // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
