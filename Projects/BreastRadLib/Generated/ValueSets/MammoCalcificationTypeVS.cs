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
	public class MammoCalcificationTypeVS                                                                                                      // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public MammoCalcificationTypeVS()                                                                                                         // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(MammoCalcificationTypeCS.Code_Skin);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_Vascular);                                                                             // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_Coarse);                                                                               // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_LargeRodLike);                                                                         // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_Round);                                                                                // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_Rim);                                                                                  // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_Dystrophic);                                                                           // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_MilkOfCalcium);                                                                        // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_Suture);                                                                               // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_Amorphous);                                                                            // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_CoarseHeterogeneous);                                                                  // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_FinePleomorphic);                                                                      // CSBuilder.cs:362
		    this.Members.Add(MammoCalcificationTypeCS.Code_FineLinear);                                                                           // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
