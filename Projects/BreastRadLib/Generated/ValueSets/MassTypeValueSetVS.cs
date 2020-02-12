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
	public class MassTypeValueSetVS                                                                                                            // CSBuilder.cs:331
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:352
		{                                                                                                                                         // CSBuilder.cs:353
		    Coding value;                                                                                                                         // CSBuilder.cs:354
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:355
		    {                                                                                                                                     // CSBuilder.cs:356
		        return tCode.value;                                                                                                               // CSBuilder.cs:357
		    }                                                                                                                                     // CSBuilder.cs:358
		                                                                                                                                          // CSBuilder.cs:359
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        this.value= value;                                                                                                                // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		}                                                                                                                                         // CSBuilder.cs:364
		public TCoding Code_Mass = new TCoding(MassTypeCS.Code_Mass);                                                                             // CSBuilder.cs:382
		public TCoding Code_MassIntraductal = new TCoding(MassTypeCS.Code_MassIntraductal);                                                       // CSBuilder.cs:382
		public TCoding Code_MassPartiallySolid = new TCoding(MassTypeCS.Code_MassPartiallySolid);                                                 // CSBuilder.cs:382
		public TCoding Code_MassSkinATLASIsSkinLesion = new TCoding(MassTypeCS.Code_MassSkinATLASIsSkinLesion);                                   // CSBuilder.cs:382
		public TCoding Code_MassSolid = new TCoding(MassTypeCS.Code_MassSolid);                                                                   // CSBuilder.cs:382
		                                                                                                                                          // CSBuilder.cs:337
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:338
		                                                                                                                                          // CSBuilder.cs:339
		public MassTypeValueSetVS()                                                                                                               // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:342
		    this.Members.Add(this.Code_Mass);                                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_MassIntraductal);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_MassPartiallySolid);                                                                                       // CSBuilder.cs:385
		    this.Members.Add(this.Code_MassSkinATLASIsSkinLesion);                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_MassSolid);                                                                                                // CSBuilder.cs:385
		}                                                                                                                                         // CSBuilder.cs:344
		//- Fields
	}
}
