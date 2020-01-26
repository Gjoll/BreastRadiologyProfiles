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
	public class AbnormalityCystTypeVS                                                                                                         // CSBuilder.cs:403
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
		public TCoding Code_Complex = new TCoding(AbnormalityCystTypeCS.Code_Complex);                                                            // CSBuilder.cs:454
		public TCoding Code_Oil = new TCoding(AbnormalityCystTypeCS.Code_Oil);                                                                    // CSBuilder.cs:454
		public TCoding Code_Simple = new TCoding(AbnormalityCystTypeCS.Code_Simple);                                                              // CSBuilder.cs:454
		public TCoding Code_Complicated = new TCoding(AbnormalityCystTypeCS.Code_Complicated);                                                    // CSBuilder.cs:454
		public TCoding Code_WithDebris = new TCoding(AbnormalityCystTypeCS.Code_WithDebris);                                                      // CSBuilder.cs:454
		                                                                                                                                          // CSBuilder.cs:409
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:411
		public AbnormalityCystTypeVS()                                                                                                            // CSBuilder.cs:412
		{                                                                                                                                         // CSBuilder.cs:413
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:414
		    this.Members.Add(this.Code_Complex);                                                                                                  // CSBuilder.cs:457
		    this.Members.Add(this.Code_Oil);                                                                                                      // CSBuilder.cs:457
		    this.Members.Add(this.Code_Simple);                                                                                                   // CSBuilder.cs:457
		    this.Members.Add(this.Code_Complicated);                                                                                              // CSBuilder.cs:457
		    this.Members.Add(this.Code_WithDebris);                                                                                               // CSBuilder.cs:457
		}                                                                                                                                         // CSBuilder.cs:416
		//- Fields
	}
}
