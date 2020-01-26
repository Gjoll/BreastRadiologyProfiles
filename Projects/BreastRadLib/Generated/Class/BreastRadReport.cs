using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class BreastRadReport : BreastRadBase, IHeaderFragment, ICategoryFragment, IServiceRecommendationFragment
	{
		//+ Fields
		//- Fields

		//+ Constructor
		public BreastRadReport()                                                                                                                  // CSBuilder.cs:308
		{                                                                                                                                         // CSBuilder.cs:309
		}                                                                                                                                         // CSBuilder.cs:311
		//- Constructor

		//+ Methods
		public void Load(ResourceBag resourceBag, DiagnosticReport resource)                                                                      // CSBuilder.cs:318
		{                                                                                                                                         // CSBuilder.cs:319
		}                                                                                                                                         // CSBuilder.cs:321
		                                                                                                                                          // CSBuilder.cs:322
		public void Unload(ResourceBag resourceBag, DiagnosticReport resource)                                                                    // CSBuilder.cs:323
		{                                                                                                                                         // CSBuilder.cs:324
		}                                                                                                                                         // CSBuilder.cs:326
		//- Methods
	}
}
