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
	public class MassTypeValueSetVS                                                                                                            // CSBuilder.cs:403
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
		public TCoding Code_Solid = new TCoding(MassTypeCS.Code_Solid);                                                                           // CSBuilder.cs:454
		public TCoding Code_Intraductal = new TCoding(MassTypeCS.Code_Intraductal);                                                               // CSBuilder.cs:454
		public TCoding Code_PartiallySolid = new TCoding(MassTypeCS.Code_PartiallySolid);                                                         // CSBuilder.cs:454
		public TCoding Code_Skin = new TCoding(MassTypeCS.Code_Skin);                                                                             // CSBuilder.cs:454
		                                                                                                                                          // CSBuilder.cs:409
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:411
		public MassTypeValueSetVS()                                                                                                               // CSBuilder.cs:412
		{                                                                                                                                         // CSBuilder.cs:413
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:414
		    this.Members.Add(this.Code_Solid);                                                                                                    // CSBuilder.cs:457
		    this.Members.Add(this.Code_Intraductal);                                                                                              // CSBuilder.cs:457
		    this.Members.Add(this.Code_PartiallySolid);                                                                                           // CSBuilder.cs:457
		    this.Members.Add(this.Code_Skin);                                                                                                     // CSBuilder.cs:457
		}                                                                                                                                         // CSBuilder.cs:416
		//- Fields
	}
}
