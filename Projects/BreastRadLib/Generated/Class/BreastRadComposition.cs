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
		                                                                                                                                          // CSDefineComposition.cs:76
		/// <summary>
		/// Section report
		/// Composition.section:report
		/// </summary>
		Coding ReportSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionReport");// CSDefineComposition.cs:83
		public BreastRadReport Report { get; set; }                                                                                               // CSDefineComposition.cs:89
		                                                                                                                                          // CSDefineComposition.cs:76
		/// <summary>
		/// Section impressions
		/// Composition.section:impressions
		/// </summary>
		Coding ImpressionsSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionImpressions");// CSDefineComposition.cs:83
		public List<ClinicalImpressionBase> Impressions { get; } = new List<ClinicalImpressionBase>();                                            // CSDefineComposition.cs:100
		                                                                                                                                          // CSDefineComposition.cs:76
		/// <summary>
		/// Section relatedResources
		/// Composition.section:relatedResources
		/// </summary>
		Coding RelatedResourcesSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionRelatedResources");// CSDefineComposition.cs:83
		public List<ResourceBase> RelatedResources { get; } = new List<ResourceBase>();                                                           // CSDefineComposition.cs:100
		                                                                                                                                          // CSDefineComposition.cs:76
		/// <summary>
		/// Section recommendations
		/// Composition.section:recommendations
		/// </summary>
		Coding RecommendationsSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionCodeRecommendations");// CSDefineComposition.cs:83
		public List<ResourceBase> Recommendations { get; } = new List<ResourceBase>();                                                            // CSDefineComposition.cs:100
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
		WriteSection<BreastRadReport>("Breast Radiology Report",                                                                                  // CSDefineComposition.cs:112
		        ReportSectionCode,                                                                                                                // CSDefineComposition.cs:113
		        1,                                                                                                                                // CSDefineComposition.cs:114
		        1,                                                                                                                                // CSDefineComposition.cs:115
		        this.Report);                                                                                                                     // CSDefineComposition.cs:116
		WriteSection<ClinicalImpressionBase>("Clinical Impressions",                                                                              // CSDefineComposition.cs:112
		        ImpressionsSectionCode,                                                                                                           // CSDefineComposition.cs:113
		        0,                                                                                                                                // CSDefineComposition.cs:114
		        -1,                                                                                                                               // CSDefineComposition.cs:115
		        this.Impressions);                                                                                                                // CSDefineComposition.cs:116
		WriteSection<ResourceBase>("Related Resources",                                                                                           // CSDefineComposition.cs:112
		        RelatedResourcesSectionCode,                                                                                                      // CSDefineComposition.cs:113
		        0,                                                                                                                                // CSDefineComposition.cs:114
		        -1,                                                                                                                               // CSDefineComposition.cs:115
		        this.RelatedResources);                                                                                                           // CSDefineComposition.cs:116
		WriteSection<ResourceBase>("Recommendations",                                                                                             // CSDefineComposition.cs:112
		        RecommendationsSectionCode,                                                                                                       // CSDefineComposition.cs:113
		        0,                                                                                                                                // CSDefineComposition.cs:114
		        -1,                                                                                                                               // CSDefineComposition.cs:115
		        this.Recommendations);                                                                                                            // CSDefineComposition.cs:116
		//- WriteCode
		}

		public void Read()
		{
		//+ ReadCode
		                                                                                                                                          // CSDefineComposition.cs:93
		this.Report = ReadSection<BreastRadReport>(this.ReportSectionCode);                                                                       // CSDefineComposition.cs:94
		ReadSection<ClinicalImpressionBase>(ImpressionsSectionCode,                                                                               // CSDefineComposition.cs:104
		        0,                                                                                                                                // CSDefineComposition.cs:105
		        -1,                                                                                                                               // CSDefineComposition.cs:106
		        this.Impressions);                                                                                                                // CSDefineComposition.cs:107
		ReadSection<ResourceBase>(RelatedResourcesSectionCode,                                                                                    // CSDefineComposition.cs:104
		        0,                                                                                                                                // CSDefineComposition.cs:105
		        -1,                                                                                                                               // CSDefineComposition.cs:106
		        this.RelatedResources);                                                                                                           // CSDefineComposition.cs:107
		ReadSection<ResourceBase>(RecommendationsSectionCode,                                                                                     // CSDefineComposition.cs:104
		        0,                                                                                                                                // CSDefineComposition.cs:105
		        -1,                                                                                                                               // CSDefineComposition.cs:106
		        this.Recommendations);                                                                                                            // CSDefineComposition.cs:107
		//- ReadCode
		}

		//+ Methods
		//- Methods
	}
}
