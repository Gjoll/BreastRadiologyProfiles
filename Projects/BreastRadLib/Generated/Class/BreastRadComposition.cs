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
		Coding ReportSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionReport");// CSDefineComposition.cs:83
		public BreastRadReport Report { get; set; }                                                                                               // CSDefineComposition.cs:89
		                                                                                                                                          // CSDefineComposition.cs:78
		/// <summary>
		/// Section impressions
		/// Composition.section:impressions
		/// </summary>
		Coding ImpressionsSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionImpressions");// CSDefineComposition.cs:83
		public ClinicalImpressionBase Impressions { get; set; }                                                                                   // CSDefineComposition.cs:89
		                                                                                                                                          // CSDefineComposition.cs:78
		/// <summary>
		/// Section relatedResources
		/// Composition.section:relatedResources
		/// </summary>
		Coding RelatedResourcesSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionRelatedResources");// CSDefineComposition.cs:83
		public ResourceBase RelatedResources { get; set; }                                                                                        // CSDefineComposition.cs:89
		                                                                                                                                          // CSDefineComposition.cs:78
		/// <summary>
		/// Section recommendations
		/// Composition.section:recommendations
		/// </summary>
		Coding RecommendationsSectionCode = new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionCodeRecommendations");// CSDefineComposition.cs:83
		public ResourceBase Recommendations { get; set; }                                                                                         // CSDefineComposition.cs:89
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
		ClearSection();                                                                                                                           // CSDefineComposition.cs:38
		WriteSection<BreastRadReport>("Breast Radiology Report", ReportSectionCode, 1, 1, this.Report);                                           // CSDefineComposition.cs:109
		WriteSection<ClinicalImpressionBase>("Clinical Impressions", ImpressionsSectionCode, 1, 1, this.Impressions);                             // CSDefineComposition.cs:109
		WriteSection<ResourceBase>("Related Resources", RelatedResourcesSectionCode, 1, 1, this.RelatedResources);                                // CSDefineComposition.cs:109
		WriteSection<ResourceBase>("Recommendations", RecommendationsSectionCode, 1, 1, this.Recommendations);                                    // CSDefineComposition.cs:109
		//- WriteCode
		}

		public void Read(ResourceBag resourceBag)
		{
		//+ ReadCode
		                                                                                                                                          // CSDefineComposition.cs:93
		this.Report = ReadSection<BreastRadReport>(resourceBag, this.ReportSectionCode);                                                          // CSDefineComposition.cs:94
		                                                                                                                                          // CSDefineComposition.cs:93
		this.Impressions = ReadSection<ClinicalImpressionBase>(resourceBag, this.ImpressionsSectionCode);                                         // CSDefineComposition.cs:94
		                                                                                                                                          // CSDefineComposition.cs:93
		this.RelatedResources = ReadSection<ResourceBase>(resourceBag, this.RelatedResourcesSectionCode);                                         // CSDefineComposition.cs:94
		                                                                                                                                          // CSDefineComposition.cs:93
		this.Recommendations = ReadSection<ResourceBase>(resourceBag, this.RecommendationsSectionCode);                                           // CSDefineComposition.cs:94
		//- ReadCode
		}

		//+ Methods
		/// <summary>
		/// Bind fhir resource to this
		/// </summary>
		public override void SetResource(Base resource)                                                                                           // CSDefineBase.cs:113
		{                                                                                                                                         // CSDefineBase.cs:114
		    Composition r = resource as Composition;                                                                                              // CSDefineBase.cs:115
		    if (r == null)                                                                                                                        // CSDefineBase.cs:116
		        throw new Exception("resource must be of type Composition");                                                                      // CSDefineBase.cs:117
		    this.resource = r;                                                                                                                    // CSDefineBase.cs:118
		    SetProfileUrl("http://hl7.org/fhir/us/breast-radiology/StructureDefinition/BreastRadComposition");                                    // CSDefineBase.cs:119
		}                                                                                                                                         // CSDefineBase.cs:120
		//- Methods
	}
}
