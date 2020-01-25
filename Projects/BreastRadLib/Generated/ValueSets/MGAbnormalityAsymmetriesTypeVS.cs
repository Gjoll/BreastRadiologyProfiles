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
	public class MGAbnormalityAsymmetriesTypeVS                                                                                                // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public MGAbnormalityAsymmetriesTypeVS()                                                                                                   // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(MGAbnormalityAsymmetryTypeCS.Code_Asymmetry);                                                                        // CSBuilder.cs:362
		    this.Members.Add(MGAbnormalityAsymmetryTypeCS.Code_GlobalAsymmetry);                                                                  // CSBuilder.cs:362
		    this.Members.Add(MGAbnormalityAsymmetryTypeCS.Code_FocalAsymmetry);                                                                   // CSBuilder.cs:362
		    this.Members.Add(MGAbnormalityAsymmetryTypeCS.Code_DevelopingAsymmetry);                                                              // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
