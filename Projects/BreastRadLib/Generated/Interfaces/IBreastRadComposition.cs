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
		SectionList<BreastRadReport> Report { get; }                                                                                              // CSDefineComposition.cs:79
		SectionList<ClinicalImpression> Impressions { get; }                                                                                      // CSDefineComposition.cs:79
		SectionList<Resource> RelatedResources { get; }                                                                                           // CSDefineComposition.cs:79
		SectionList<DomainResource> Recommendations { get; }                                                                                      // CSDefineComposition.cs:79
		//- Fields

		//+ Methods
		//- Methods
	}
}
