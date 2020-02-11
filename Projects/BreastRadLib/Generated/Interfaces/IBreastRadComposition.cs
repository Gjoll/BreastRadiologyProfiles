using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public interface IBreastRadComposition : ICompositionBase, IHeaderFragment
	{
		//+ Fields
		BreastRadReport Report { get; set; }                                                                                                      // CSDefineComposition.cs:121
		List<ClinicalImpressionBase> Impressions { get; }                                                                                         // CSDefineComposition.cs:125
		List<ResourceBase> RelatedResources { get; }                                                                                              // CSDefineComposition.cs:125
		List<ResourceBase> Recommendations { get; }                                                                                               // CSDefineComposition.cs:125
		//- Fields

		//+ Methods
		//- Methods
	}
}
