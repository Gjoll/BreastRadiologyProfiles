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
	public class ObservedChangesVS                                                                                                             // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public ObservedChangesVS()                                                                                                                // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(ObservedChangesCS.Code_DecreaseInCalcifications);                                                                    // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_DecreaseInNumber);                                                                            // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_DecreaseInSize);                                                                              // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_IncreaseInCalcifications);                                                                    // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_IncreaseInNumber);                                                                            // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_IncreaseInSize);                                                                              // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_LessProminent);                                                                               // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_MoreProminent);                                                                               // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_New);                                                                                         // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_NoLongerSeen);                                                                                // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_NotSignificantChanged);                                                                       // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_PartiallyRemoved);                                                                            // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_RepresentsChange);                                                                            // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_Stable);                                                                                      // CSBuilder.cs:362
		    this.Members.Add(ObservedChangesCS.Code_IncidentalFinding);                                                                           // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
