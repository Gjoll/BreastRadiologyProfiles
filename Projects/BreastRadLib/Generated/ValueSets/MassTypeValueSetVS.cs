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
	public class MassTypeValueSetVS                                                                                                            // CSBuilder.cs:336
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
		public TCoding Code_Solid = new TCoding(MassTypeCS.Code_Solid);                                                                           // CSBuilder.cs:387
		public TCoding Code_Intraductal = new TCoding(MassTypeCS.Code_Intraductal);                                                               // CSBuilder.cs:387
		public TCoding Code_PartiallySolid = new TCoding(MassTypeCS.Code_PartiallySolid);                                                         // CSBuilder.cs:387
		public TCoding Code_Skin = new TCoding(MassTypeCS.Code_Skin);                                                                             // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public MassTypeValueSetVS()                                                                                                               // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(MassTypeCS.Code_Solid);                                                                                              // CSBuilder.cs:390
		    this.Members.Add(MassTypeCS.Code_Intraductal);                                                                                        // CSBuilder.cs:390
		    this.Members.Add(MassTypeCS.Code_PartiallySolid);                                                                                     // CSBuilder.cs:390
		    this.Members.Add(MassTypeCS.Code_Skin);                                                                                               // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
