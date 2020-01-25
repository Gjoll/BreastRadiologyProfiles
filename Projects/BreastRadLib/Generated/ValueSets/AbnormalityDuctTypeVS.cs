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
	public class AbnormalityDuctTypeVS                                                                                                         // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public AbnormalityDuctTypeVS()                                                                                                            // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(AbnormalityDuctTypeCS.Code_Normal);                                                                                  // CSBuilder.cs:362
		    this.Members.Add(AbnormalityDuctTypeCS.Code_Ectasia);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(AbnormalityDuctTypeCS.Code_Dilated);                                                                                 // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
