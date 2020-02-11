using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	public class BreastRadComposition : CompositionBase, IHeaderFragment
	{
		//+ Fields
		                                                                                                                                          // CSDefineComposition.cs:62
		/// <summary>
		/// Section report
		/// Composition.section:report
		/// </summary>
		public SectionList<BreastRadReport> Report { get; }                                                                                       // CSDefineComposition.cs:67
		                                                                                                                                          // CSDefineComposition.cs:62
		/// <summary>
		/// Section impressions
		/// Composition.section:impressions
		/// </summary>
		public SectionList<ClinicalImpression> Impressions { get; }                                                                               // CSDefineComposition.cs:67
		                                                                                                                                          // CSDefineComposition.cs:62
		/// <summary>
		/// Section relatedResources
		/// Composition.section:relatedResources
		/// </summary>
		public SectionList<Resource> RelatedResources { get; }                                                                                    // CSDefineComposition.cs:67
		                                                                                                                                          // CSDefineComposition.cs:62
		/// <summary>
		/// Section recommendations
		/// Composition.section:recommendations
		/// </summary>
		public SectionList<DomainResource> Recommendations { get; }                                                                               // CSDefineComposition.cs:67
		//- Fields

		public BreastRadComposition()
		{
			//+ Constructor
			                                                                                                                                         // CSDefineComposition.cs:71
			Report = new SectionList<BreastRadReport>("Breast Radiology Report",                                                                     // CSDefineComposition.cs:72
			        new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionReport"),                  // CSDefineComposition.cs:73
			        1,                                                                                                                               // CSDefineComposition.cs:74
			        1);                                                                                                                              // CSDefineComposition.cs:75
			                                                                                                                                         // CSDefineComposition.cs:71
			Impressions = new SectionList<ClinicalImpression>("Clinical Impressions",                                                                // CSDefineComposition.cs:72
			        new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionImpressions"),             // CSDefineComposition.cs:73
			        0,                                                                                                                               // CSDefineComposition.cs:74
			        -1);                                                                                                                             // CSDefineComposition.cs:75
			                                                                                                                                         // CSDefineComposition.cs:71
			RelatedResources = new SectionList<Resource>("Related Resources",                                                                        // CSDefineComposition.cs:72
			        new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionRelatedResources"),        // CSDefineComposition.cs:73
			        0,                                                                                                                               // CSDefineComposition.cs:74
			        -1);                                                                                                                             // CSDefineComposition.cs:75
			                                                                                                                                         // CSDefineComposition.cs:71
			Recommendations = new SectionList<DomainResource>("Recommendations",                                                                     // CSDefineComposition.cs:72
			        new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionCodeRecommendations"),     // CSDefineComposition.cs:73
			        0,                                                                                                                               // CSDefineComposition.cs:74
			        -1);                                                                                                                             // CSDefineComposition.cs:75
			//- Constructor
		}

		//+ Methods
		//- Methods
	}
}
