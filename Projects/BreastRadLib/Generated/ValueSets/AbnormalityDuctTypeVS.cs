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
	public class AbnormalityDuctTypeVS                                                                                                         // CSBuilder.cs:319
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    Coding value;                                                                                                                         // CSBuilder.cs:342
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:343
		    {                                                                                                                                     // CSBuilder.cs:344
		        return tCode.value;                                                                                                               // CSBuilder.cs:345
		    }                                                                                                                                     // CSBuilder.cs:346
		                                                                                                                                          // CSBuilder.cs:347
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:348
		    {                                                                                                                                     // CSBuilder.cs:349
		        this.value= value;                                                                                                                // CSBuilder.cs:350
		    }                                                                                                                                     // CSBuilder.cs:351
		}                                                                                                                                         // CSBuilder.cs:352
		public TCoding Code_DuctNormal = new TCoding(AbnormalityDuctTypeCS.Code_DuctNormal);                                                      // CSBuilder.cs:370
		public TCoding Code_SolitaryDilatedDuct = new TCoding(AbnormalityDuctTypeCS.Code_SolitaryDilatedDuct);                                    // CSBuilder.cs:370
		public TCoding Code_DuctEctasia = new TCoding(AbnormalityDuctTypeCS.Code_DuctEctasia);                                                    // CSBuilder.cs:370
		                                                                                                                                          // CSBuilder.cs:325
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:326
		                                                                                                                                          // CSBuilder.cs:327
		public AbnormalityDuctTypeVS()                                                                                                            // CSBuilder.cs:328
		{                                                                                                                                         // CSBuilder.cs:329
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:330
		    this.Members.Add(this.Code_DuctNormal);                                                                                               // CSBuilder.cs:373
		    this.Members.Add(this.Code_SolitaryDilatedDuct);                                                                                      // CSBuilder.cs:373
		    this.Members.Add(this.Code_DuctEctasia);                                                                                              // CSBuilder.cs:373
		}                                                                                                                                         // CSBuilder.cs:332
		//- Fields
	}
}
