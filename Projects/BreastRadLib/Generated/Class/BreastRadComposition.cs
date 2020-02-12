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
		                                                                                                                                          // CSDefineComposition.cs:79
		/// <summary>
		/// Section report
		/// Composition.section:report
		/// </summary>
		Coding ReportSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionReport");// CSDefineComposition.cs:84
		public BreastRadReport Report { get; set; }                                                                                               // CSDefineComposition.cs:90
		                                                                                                                                          // CSDefineComposition.cs:79
		/// <summary>
		/// Section impressions
		/// Composition.section:impressions
		/// </summary>
		Coding ImpressionsSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionImpressions");// CSDefineComposition.cs:84
		public List<ClinicalImpressionBase> Impressions { get; } = new List<ClinicalImpressionBase>();                                            // CSDefineComposition.cs:101
		                                                                                                                                          // CSDefineComposition.cs:79
		/// <summary>
		/// Section relatedResources
		/// Composition.section:relatedResources
		/// </summary>
		Coding RelatedResourcesSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionRelatedResources");// CSDefineComposition.cs:84
		public List<ResourceBase> RelatedResources { get; } = new List<ResourceBase>();                                                           // CSDefineComposition.cs:101
		                                                                                                                                          // CSDefineComposition.cs:79
		/// <summary>
		/// Section recommendations
		/// Composition.section:recommendations
		/// </summary>
		Coding RecommendationsSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionCodeRecommendations");// CSDefineComposition.cs:84
		public List<ResourceBase> Recommendations { get; } = new List<ResourceBase>();                                                            // CSDefineComposition.cs:101
		//- Fields

		public BreastRadComposition(Composition resource) : this()
		{
			this.SetResource(resource);
		}

		public BreastRadComposition() : base()
		{
			//+ Constructor
			//- Constructor
		}

		public void Write()
		{
		//+ WriteCode
		SetProfileUrl("http://hl7.org/fhir/us/breast-radiology/StructureDefinition/BreastRadComposition");                                        // CSDefineBase.cs:109
		ClearSection();                                                                                                                           // CSDefineComposition.cs:38
		WriteSection<BreastRadReport>("Breast Radiology Report", ReportSectionCode, 1, 1, this.Report);                                           // CSDefineComposition.cs:110
		WriteSection<ClinicalImpressionBase>("Clinical Impressions", ImpressionsSectionCode, 0, -1, this.Impressions);                            // CSDefineComposition.cs:110
		WriteSection<ResourceBase>("Related Resources", RelatedResourcesSectionCode, 0, -1, this.RelatedResources);                               // CSDefineComposition.cs:110
		WriteSection<ResourceBase>("Recommendations", RecommendationsSectionCode, 0, -1, this.Recommendations);                                   // CSDefineComposition.cs:110
		//- WriteCode
		}

		public void Read(ResourceBag resourceBag)
		{
		//+ ReadCode
		                                                                                                                                          // CSDefineComposition.cs:94
		this.Report = ReadSection<BreastRadReport>(resourceBag, this.ReportSectionCode);                                                          // CSDefineComposition.cs:95
		ReadSection<ClinicalImpressionBase>(resourceBag, ImpressionsSectionCode, 0, -1, this.Impressions);                                        // CSDefineComposition.cs:105
		ReadSection<ResourceBase>(resourceBag, RelatedResourcesSectionCode, 0, -1, this.RelatedResources);                                        // CSDefineComposition.cs:105
		ReadSection<ResourceBase>(resourceBag, RecommendationsSectionCode, 0, -1, this.Recommendations);                                          // CSDefineComposition.cs:105
		//- ReadCode
		}

		//+ Methods
		//- Methods
	}
}
