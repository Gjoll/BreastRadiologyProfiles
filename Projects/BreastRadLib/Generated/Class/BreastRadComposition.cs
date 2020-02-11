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
		                                                                                                                                          // CSDefineComposition.cs:78
		/// <summary>
		/// Section report
		/// Composition.section:report
		/// </summary>
		Coding ReportSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionReport");// CSDefineComposition.cs:85
		public BreastRadReport Report { get; set; }                                                                                               // CSDefineComposition.cs:91
		                                                                                                                                          // CSDefineComposition.cs:78
		/// <summary>
		/// Section impressions
		/// Composition.section:impressions
		/// </summary>
		Coding ImpressionsSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionImpressions");// CSDefineComposition.cs:85
		public List<ClinicalImpressionBase> Impressions { get; } = new List<ClinicalImpressionBase>();                                            // CSDefineComposition.cs:102
		                                                                                                                                          // CSDefineComposition.cs:78
		/// <summary>
		/// Section relatedResources
		/// Composition.section:relatedResources
		/// </summary>
		Coding RelatedResourcesSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionRelatedResources");// CSDefineComposition.cs:85
		public List<ResourceBase> RelatedResources { get; } = new List<ResourceBase>();                                                           // CSDefineComposition.cs:102
		                                                                                                                                          // CSDefineComposition.cs:78
		/// <summary>
		/// Section recommendations
		/// Composition.section:recommendations
		/// </summary>
		Coding RecommendationsSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionCodeRecommendations");// CSDefineComposition.cs:85
		public List<ResourceBase> Recommendations { get; } = new List<ResourceBase>();                                                            // CSDefineComposition.cs:102
		//- Fields

		public BreastRadComposition(Composition resource) : base(resource)
		{
			//+ Constructor
			//- Constructor
		}

		public void Write()
		{
		//+ WriteCode
		ClearSection();                                                                                                                           // CSDefineComposition.cs:38
		WriteSection<BreastRadReport>("Breast Radiology Report", ReportSectionCode, 1, 1, this.Report);                                           // CSDefineComposition.cs:111
		WriteSection<ClinicalImpressionBase>("Clinical Impressions", ImpressionsSectionCode, 0, -1, this.Impressions);                            // CSDefineComposition.cs:111
		WriteSection<ResourceBase>("Related Resources", RelatedResourcesSectionCode, 0, -1, this.RelatedResources);                               // CSDefineComposition.cs:111
		WriteSection<ResourceBase>("Recommendations", RecommendationsSectionCode, 0, -1, this.Recommendations);                                   // CSDefineComposition.cs:111
		//- WriteCode
		}

		public void Read(ResourceBag resourceBag)
		{
		//+ ReadCode
		                                                                                                                                          // CSDefineComposition.cs:95
		this.Report = ReadSection<BreastRadReport>(resourceBag, this.ReportSectionCode);                                                          // CSDefineComposition.cs:96
		ReadSection<ClinicalImpressionBase>(resourceBag, ImpressionsSectionCode, 0, -1, this.Impressions);                                        // CSDefineComposition.cs:106
		ReadSection<ResourceBase>(resourceBag, RelatedResourcesSectionCode, 0, -1, this.RelatedResources);                                        // CSDefineComposition.cs:106
		ReadSection<ResourceBase>(resourceBag, RecommendationsSectionCode, 0, -1, this.Recommendations);                                          // CSDefineComposition.cs:106
		//- ReadCode
		}

		//+ Methods
		//- Methods
	}
}
