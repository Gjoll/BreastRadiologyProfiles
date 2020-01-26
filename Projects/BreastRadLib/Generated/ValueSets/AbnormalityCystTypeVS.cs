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
	public class AbnormalityCystTypeVS                                                                                                         // CSBuilder.cs:413
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:434
		{                                                                                                                                         // CSBuilder.cs:435
		    Coding value;                                                                                                                         // CSBuilder.cs:436
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:437
		    {                                                                                                                                     // CSBuilder.cs:438
		        return tCode.value;                                                                                                               // CSBuilder.cs:439
		    }                                                                                                                                     // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:441
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:442
		    {                                                                                                                                     // CSBuilder.cs:443
		        this.value= value;                                                                                                                // CSBuilder.cs:444
		    }                                                                                                                                     // CSBuilder.cs:445
		}                                                                                                                                         // CSBuilder.cs:446
		public TCoding Code_Complex = new TCoding(AbnormalityCystTypeCS.Code_Complex);                                                            // CSBuilder.cs:464
		public TCoding Code_Oil = new TCoding(AbnormalityCystTypeCS.Code_Oil);                                                                    // CSBuilder.cs:464
		public TCoding Code_Simple = new TCoding(AbnormalityCystTypeCS.Code_Simple);                                                              // CSBuilder.cs:464
		public TCoding Code_Complicated = new TCoding(AbnormalityCystTypeCS.Code_Complicated);                                                    // CSBuilder.cs:464
		public TCoding Code_WithDebris = new TCoding(AbnormalityCystTypeCS.Code_WithDebris);                                                      // CSBuilder.cs:464
		                                                                                                                                          // CSBuilder.cs:419
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:421
		public AbnormalityCystTypeVS()                                                                                                            // CSBuilder.cs:422
		{                                                                                                                                         // CSBuilder.cs:423
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:424
		    this.Members.Add(this.Code_Complex);                                                                                                  // CSBuilder.cs:467
		    this.Members.Add(this.Code_Oil);                                                                                                      // CSBuilder.cs:467
		    this.Members.Add(this.Code_Simple);                                                                                                   // CSBuilder.cs:467
		    this.Members.Add(this.Code_Complicated);                                                                                              // CSBuilder.cs:467
		    this.Members.Add(this.Code_WithDebris);                                                                                               // CSBuilder.cs:467
		}                                                                                                                                         // CSBuilder.cs:426
		//- Fields
	}
}
