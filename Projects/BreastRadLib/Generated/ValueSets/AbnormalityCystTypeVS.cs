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
	public class AbnormalityCystTypeVS                                                                                                         // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public AbnormalityCystTypeVS()                                                                                                            // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(AbnormalityCystTypeCS.Code_Complex);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(AbnormalityCystTypeCS.Code_Oil);                                                                                     // CSBuilder.cs:362
		    this.Members.Add(AbnormalityCystTypeCS.Code_Simple);                                                                                  // CSBuilder.cs:362
		    this.Members.Add(AbnormalityCystTypeCS.Code_Complicated);                                                                             // CSBuilder.cs:362
		    this.Members.Add(AbnormalityCystTypeCS.Code_WithDebris);                                                                              // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
