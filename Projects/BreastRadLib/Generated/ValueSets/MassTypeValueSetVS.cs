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
	public class MassTypeValueSetVS                                                                                                            // CSBuilder.cs:338
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
		public TCoding Code_Mass = new TCoding(MassTypeCS.Code_Mass);                                                                             // CSBuilder.cs:389
		public TCoding Code_MassIntraductal = new TCoding(MassTypeCS.Code_MassIntraductal);                                                       // CSBuilder.cs:389
		public TCoding Code_MassPartiallySolid = new TCoding(MassTypeCS.Code_MassPartiallySolid);                                                 // CSBuilder.cs:389
		public TCoding Code_MassSkinATLASIsSkinLesion = new TCoding(MassTypeCS.Code_MassSkinATLASIsSkinLesion);                                   // CSBuilder.cs:389
		public TCoding Code_MassSolid = new TCoding(MassTypeCS.Code_MassSolid);                                                                   // CSBuilder.cs:389
		                                                                                                                                          // CSBuilder.cs:344
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:345
		                                                                                                                                          // CSBuilder.cs:346
		public MassTypeValueSetVS()                                                                                                               // CSBuilder.cs:347
		{                                                                                                                                         // CSBuilder.cs:348
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:349
		    this.Members.Add(this.Code_Mass);                                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_MassIntraductal);                                                                                          // CSBuilder.cs:392
		    this.Members.Add(this.Code_MassPartiallySolid);                                                                                       // CSBuilder.cs:392
		    this.Members.Add(this.Code_MassSkinATLASIsSkinLesion);                                                                                // CSBuilder.cs:392
		    this.Members.Add(this.Code_MassSolid);                                                                                                // CSBuilder.cs:392
		}                                                                                                                                         // CSBuilder.cs:351
		//- Fields
	}
}
