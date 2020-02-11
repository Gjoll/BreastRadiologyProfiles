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
		                                                                                                                                          // CSDefineComposition.cs:65
		/// <summary>
		/// Section report
		/// Composition.section:report
		/// </summary>
		public BreastRadReport Report { get; set; }                                                                                               // CSDefineComposition.cs:73
		                                                                                                                                          // CSDefineComposition.cs:65
		/// <summary>
		/// Section impressions
		/// Composition.section:impressions
		/// </summary>
		public List<ClinicalImpression> Impressions { get; } = new List<ClinicalImpression>();                                                    // CSDefineComposition.cs:77
		                                                                                                                                          // CSDefineComposition.cs:65
		/// <summary>
		/// Section relatedResources
		/// Composition.section:relatedResources
		/// </summary>
		public List<Resource> RelatedResources { get; } = new List<Resource>();                                                                   // CSDefineComposition.cs:77
		                                                                                                                                          // CSDefineComposition.cs:65
		/// <summary>
		/// Section recommendations
		/// Composition.section:recommendations
		/// </summary>
		public List<DomainResource> Recommendations { get; } = new List<DomainResource>();                                                        // CSDefineComposition.cs:77
		//- Fields

		public BreastRadComposition()
		{
			//+ Constructor
			//- Constructor
		}

		public void Write()
		{
		//+ WriteCode
		                                                                                                                                          // CSDefineComposition.cs:81
		WriteSection<BreastRadReport>("Breast Radiology Report",                                                                                  // CSDefineComposition.cs:82
		        new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionReport"),                   // CSDefineComposition.cs:83
		        1,                                                                                                                                // CSDefineComposition.cs:84
		        1,                                                                                                                                // CSDefineComposition.cs:85
		        this.Report);                                                                                                                     // CSDefineComposition.cs:86
		                                                                                                                                          // CSDefineComposition.cs:81
		WriteSection<ClinicalImpression>("Clinical Impressions",                                                                                  // CSDefineComposition.cs:82
		        new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionImpressions"),              // CSDefineComposition.cs:83
		        0,                                                                                                                                // CSDefineComposition.cs:84
		        -1,                                                                                                                               // CSDefineComposition.cs:85
		        this.Impressions);                                                                                                                // CSDefineComposition.cs:86
		                                                                                                                                          // CSDefineComposition.cs:81
		WriteSection<Resource>("Related Resources",                                                                                               // CSDefineComposition.cs:82
		        new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionRelatedResources"),         // CSDefineComposition.cs:83
		        0,                                                                                                                                // CSDefineComposition.cs:84
		        -1,                                                                                                                               // CSDefineComposition.cs:85
		        this.RelatedResources);                                                                                                           // CSDefineComposition.cs:86
		                                                                                                                                          // CSDefineComposition.cs:81
		WriteSection<DomainResource>("Recommendations",                                                                                           // CSDefineComposition.cs:82
		        new Coding("http://hl7.org/fhir/us/breast-radiology/CodeSystem/CompositionSectionSliceCodes", "sectionCodeRecommendations"),      // CSDefineComposition.cs:83
		        0,                                                                                                                                // CSDefineComposition.cs:84
		        -1,                                                                                                                               // CSDefineComposition.cs:85
		        this.Recommendations);                                                                                                            // CSDefineComposition.cs:86
		//- WriteCode
		}

		public void Read()
		{
		//+ ReadCode
		//- ReadCode
		}

		//+ Methods
		//- Methods
	}
}
