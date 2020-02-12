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
		BreastRadReport Report { get; set; }                                                                                                      // CSDefineComposition.cs:116
		ClinicalImpressionBase Impressions { get; set; }                                                                                          // CSDefineComposition.cs:116
		ResourceBase RelatedResources { get; set; }                                                                                               // CSDefineComposition.cs:116
		ResourceBase Recommendations { get; set; }                                                                                                // CSDefineComposition.cs:116
		//- Fields

		//+ Methods
		//- Methods
	}
}
