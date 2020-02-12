using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadLib
{
	//+ Header
	public class ObservationCodes                                                                                                              // CSBuilder.cs:405
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/ObservationCodes";                                              // CSBuilder.cs:409
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an MGFinding observation
		/// </summary>
		public static Coding Code_MgFindingObservationObservation = new Coding(System, "mgFindingObservationObservation", "MG Finding observation");// CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an AbnormalityCyst observation
		/// </summary>
		public static Coding Code_AbnormalityCyst = new Coding(System, "abnormalityCyst", "Abnormality Cyst observation");                        // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an AssociatedFeatures observation
		/// </summary>
		public static Coding Code_AssociatedFeaturesObservation = new Coding(System, "associatedFeaturesObservation", "Associated Features observation");// CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an MGAbnormalityArchitecturalDistortion observation
		/// </summary>
		public static Coding Code_MgAbnormalityArchitecturalDistortionObservation = new Coding(System, "mgAbnormalityArchitecturalDistortionObservation", "Abnormality Architectural Distortion observation");// CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify a ConsistentWith observation
		/// </summary>
		public static Coding Code_ConsistentWithObservation = new Coding(System, "consistentWithObservation", "Consistent With observation");     // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify a TumorSatellite observation
		/// </summary>
		public static Coding Code_TumorSatelliteObservation = new Coding(System, "tumorSatelliteObservation", "Tumor Satellite observation");     // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an MGAbnormalityCalcification observation
		/// </summary>
		public static Coding Code_MgAbnormalityCalcificationObservation = new Coding(System, "mgAbnormalityCalcificationObservation", "Abnormality Calcification observation");// CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an ObservedFeature observation
		/// </summary>
		public static Coding Code_FeatureObservation = new Coding(System, "featureObservation", "Observed Feature observation");                  // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an ObservationCodeAbnormalityDuct observation
		/// </summary>
		public static Coding Code_AbnormalityDuctObservation = new Coding(System, "abnormalityDuctObservation", "Abnormality Duct observation");  // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an AbnormalityForeignObject observation
		/// </summary>
		public static Coding Code_AbnormalityForeignObjectObservation = new Coding(System, "abnormalityForeignObjectObservation", "Abnormality Foreign Object observation");// CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an AbnormalityLymphNode observation
		/// </summary>
		public static Coding Code_AbnormalityLymphNodeObservation = new Coding(System, "abnormalityLymphNodeObservation", "Abnormality Lymph Node observation");// CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an AbnormalityMass observation
		/// </summary>
		public static Coding Code_AbnormalityMassObservation = new Coding(System, "abnormalityMassObservation", "Abnormality Mass observation");  // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an AbnormalityFibroadenoma observation
		/// </summary>
		public static Coding Code_AbnormalityFibroadenomaObservation = new Coding(System, "abnormalityFibroadenomaObservation", "Abnormality Fibroadenoma observation");// CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an MGAbnormalityAsymmetry observation
		/// </summary>
		public static Coding Code_MgAbnormalityAsymmetryObservation = new Coding(System, "mgAbnormalityAsymmetryObservation", "MG Abnormality Asymmetry observation");// CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an MGAbnormalityDensity observation
		/// </summary>
		public static Coding Code_MgAbnormalityDensityObservation = new Coding(System, "mgAbnormalityDensityObservation", "MG Abnormality Density observation");// CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an MGAbnormalityFatNecrosis observation
		/// </summary>
		public static Coding Code_MgAbnormalityFatNecrosisObservation = new Coding(System, "mgAbnormalityFatNecrosisObservation", "MG Abnormality FatNecrosis observation");// CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an MGBreastDensity observation
		/// </summary>
		public static Coding Code_MgBreastDensityObservation = new Coding(System, "mgBreastDensityObservation", "MG Breast Density observation"); // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an MRIFinding observation
		/// </summary>
		public static Coding Code_MriFindingObservation = new Coding(System, "mriFindingObservation", "MRI Finding observation");                 // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify an NMFinding observation
		/// </summary>
		public static Coding Code_NmFindingObservation = new Coding(System, "nmFindingObservation", "NM Findingobservation");                     // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify a USFinding observation
		/// </summary>
		public static Coding Code_UsFindingObservation = new Coding(System, "usFindingObservation", "US Finding observation");                    // CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify a SectionFindingsLeftBreast observation
		/// </summary>
		public static Coding Code_FindingsLeftBreastObservation = new Coding(System, "findingsLeftBreastObservation", "Findings Left Breast observation");// CSBuilder.cs:435
		                                                                                                                                          // CSBuilder.cs:421
		/// <summary>
		/// Observation.code to identify a SectionFindingsRightBreast observation
		/// </summary>
		public static Coding Code_FindingsRightBreastObservation = new Coding(System, "findingsRightBreastObservation", "Findings Right Breast observation");// CSBuilder.cs:435
		//- Fields
	}
}
