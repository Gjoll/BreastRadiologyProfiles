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
	public class AbnormalityLymphNodeTypeVS                                                                                                    // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public AbnormalityLymphNodeTypeVS()                                                                                                       // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(AbnormalityLymphNodeTypeCS.Code_Axillary);                                                                           // CSBuilder.cs:362
		    this.Members.Add(AbnormalityLymphNodeTypeCS.Code_Enlarged);                                                                           // CSBuilder.cs:362
		    this.Members.Add(AbnormalityLymphNodeTypeCS.Code_FocalCortex);                                                                        // CSBuilder.cs:362
		    this.Members.Add(AbnormalityLymphNodeTypeCS.Code_UniformThickness);                                                                   // CSBuilder.cs:362
		    this.Members.Add(AbnormalityLymphNodeTypeCS.Code_Intramammory);                                                                       // CSBuilder.cs:362
		    this.Members.Add(AbnormalityLymphNodeTypeCS.Code_InternalMargin);                                                                     // CSBuilder.cs:362
		    this.Members.Add(AbnormalityLymphNodeTypeCS.Code_Normal);                                                                             // CSBuilder.cs:362
		    this.Members.Add(AbnormalityLymphNodeTypeCS.Code_PathLymphNode);                                                                      // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
