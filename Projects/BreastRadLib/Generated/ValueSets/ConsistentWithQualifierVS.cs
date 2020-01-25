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
	public class ConsistentWithQualifierVS                                                                                                     // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public ConsistentWithQualifierVS()                                                                                                        // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(ConsistentWithQualifierCS.Code_LikelyRepresents);                                                                    // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithQualifierCS.Code_MostLikely);                                                                          // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithQualifierCS.Code_Resembles);                                                                           // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithQualifierCS.Code_WDifferentialDiagnosis);                                                              // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
