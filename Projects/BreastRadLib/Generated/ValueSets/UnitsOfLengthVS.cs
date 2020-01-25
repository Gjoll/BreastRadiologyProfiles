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
	public class UnitsOfLengthVS                                                                                                               // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public UnitsOfLengthVS()                                                                                                                  // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(UnitsofmeasureOrg.Code_M);                                                                                           // CSBuilder.cs:362
		    this.Members.Add(UnitsofmeasureOrg.Code_Cm);                                                                                          // CSBuilder.cs:362
		    this.Members.Add(UnitsofmeasureOrg.Code_Mm);                                                                                          // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
