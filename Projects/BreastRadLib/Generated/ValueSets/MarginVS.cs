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
	public class MarginVS                                                                                                                      // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public MarginVS()                                                                                                                         // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(MarginCS.Code_AngularMargin);                                                                                        // CSBuilder.cs:362
		    this.Members.Add(MarginCS.Code_CircumscribedMargin);                                                                                  // CSBuilder.cs:362
		    this.Members.Add(MarginCS.Code_IndistinctMargin);                                                                                     // CSBuilder.cs:362
		    this.Members.Add(MarginCS.Code_IntraductalExtension);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(MarginCS.Code_IrregularMargin);                                                                                      // CSBuilder.cs:362
		    this.Members.Add(MarginCS.Code_LobulatedMargin);                                                                                      // CSBuilder.cs:362
		    this.Members.Add(MarginCS.Code_MacrolobulatedMargin);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(MarginCS.Code_MicrolobulatedMargin);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(MarginCS.Code_NonCircumscribedMargin);                                                                               // CSBuilder.cs:362
		    this.Members.Add(MarginCS.Code_ObscuredMargin);                                                                                       // CSBuilder.cs:362
		    this.Members.Add(MarginCS.Code_SmoothMargin);                                                                                         // CSBuilder.cs:362
		    this.Members.Add(MarginCS.Code_SpiculatedMargin);                                                                                     // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
