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
	public class BreastLocationRegionVS                                                                                                        // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public BreastLocationRegionVS()                                                                                                           // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(BreastLocationRegionCS.Code_Central);                                                                                // CSBuilder.cs:362
		    this.Members.Add(BreastLocationRegionCS.Code_RetroaReolar);                                                                           // CSBuilder.cs:362
		    this.Members.Add(BreastLocationRegionCS.Code_AxillaryTail);                                                                           // CSBuilder.cs:362
		    this.Members.Add(BreastLocationRegionCS.Code_Axilla);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(BreastLocationRegionCS.Code_AxillaI);                                                                                // CSBuilder.cs:362
		    this.Members.Add(BreastLocationRegionCS.Code_AxillaII);                                                                               // CSBuilder.cs:362
		    this.Members.Add(BreastLocationRegionCS.Code_AxillaIII);                                                                              // CSBuilder.cs:362
		    this.Members.Add(BreastLocationRegionCS.Code_InframammaryFold);                                                                       // CSBuilder.cs:362
		    this.Members.Add(BreastLocationRegionCS.Code_InSkin);                                                                                 // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
