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
		BreastRadReport Report { get; set; }                                                                                                      // CSDefineComposition.cs:114
		ClinicalImpressionBase Impressions { get; set; }                                                                                          // CSDefineComposition.cs:114
		ResourceBase RelatedResources { get; set; }                                                                                               // CSDefineComposition.cs:114
		ResourceBase Recommendations { get; set; }                                                                                                // CSDefineComposition.cs:114
		//- Fields

		//+ Methods
		//- Methods
	}
}
