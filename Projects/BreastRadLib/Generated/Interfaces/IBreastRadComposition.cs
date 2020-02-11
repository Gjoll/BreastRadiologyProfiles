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
		BreastRadReport Report { get; set; }                                                                                                      // CSDefineComposition.cs:91
		List<ClinicalImpression> Impressions { get; }                                                                                             // CSDefineComposition.cs:95
		List<Resource> RelatedResources { get; }                                                                                                  // CSDefineComposition.cs:95
		List<DomainResource> Recommendations { get; }                                                                                             // CSDefineComposition.cs:95
		//- Fields

		//+ Methods
		//- Methods
	}
}
