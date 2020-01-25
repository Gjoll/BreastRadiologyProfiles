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
	public class ComponentSliceCodes                                                                                                           // CSBuilder.cs:408
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/ComponentSliceCodes";                                           // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - AbnormalityCystType
		/// </summary>
		public static Coding Code_AbnormalityCystType = new Coding(System, "abnormalityCystType", "");                                            // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - CodeAbnormalityDuctType
		/// </summary>
		public static Coding Code_AbnormalityDuctType = new Coding(System, "abnormalityDuctType", "");                                            // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - CodeAbnormalityFibroAdenomaType
		/// </summary>
		public static Coding Code_MgAbnormalityFibroAdenomaType = new Coding(System, "mgAbnormalityFibroAdenomaType", "");                        // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - CodeAbnormalityForeignObjectType
		/// </summary>
		public static Coding Code_AbnormalityForeignObjectType = new Coding(System, "abnormalityForeignObjectType", "");                          // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - CodeAbnormalityLymphNodeType
		/// </summary>
		public static Coding Code_AbnormalityLymphNodeType = new Coding(System, "abnormalityLymphNodeType", "");                                  // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - CodeAbnormalityMassType
		/// </summary>
		public static Coding Code_AbnormalityMassType = new Coding(System, "abnormalityMassType", "");                                            // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - BiRads
		/// </summary>
		public static Coding Code_TargetBiRads = new Coding(System, "targetBiRads", "");                                                          // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - ConsistentWithValue
		/// </summary>
		public static Coding Code_ConsistentWithValue = new Coding(System, "consistentWithValue", "");                                            // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - ConsistentWithQualifier
		/// </summary>
		public static Coding Code_ConsistentWithQualifier = new Coding(System, "consistentWithQualifier", "");                                    // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - CorrespondsWith
		/// </summary>
		public static Coding Code_CorrespondsWith = new Coding(System, "correspondsWith", "");                                                    // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - Margin
		/// </summary>
		public static Coding Code_Margin = new Coding(System, "margin", "");                                                                      // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - MGDensity
		/// </summary>
		public static Coding Code_MgDensity = new Coding(System, "mgDensity", "");                                                                // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - Not Previously Seen
		/// </summary>
		public static Coding Code_NotPreviouslySeen = new Coding(System, "notPreviouslySeen", "");                                                // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - Observed Changes
		/// </summary>
		public static Coding Code_ObservedChanges = new Coding(System, "observedChanges", "");                                                    // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - ObservedSize
		/// </summary>
		public static Coding Code_ObservedSize = new Coding(System, "observedSize", "");                                                          // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - ObservedArea
		/// </summary>
		public static Coding Code_ObservedRegion = new Coding(System, "observedRegion", "");                                                      // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - ObservedCount
		/// </summary>
		public static Coding Code_ObservedCount = new Coding(System, "observedCount", "");                                                        // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - ObservedFeatureType
		/// </summary>
		public static Coding Code_FeatureType = new Coding(System, "featureType", "");                                                            // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - Orientation
		/// </summary>
		public static Coding Code_Orientation = new Coding(System, "orientation", "");                                                            // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - Shape
		/// </summary>
		public static Coding Code_Shape = new Coding(System, "shape", "");                                                                        // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - TumorQualifier
		/// </summary>
		public static Coding Code_TumorQualifier = new Coding(System, "tumorQualifier", "");                                                      // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - MGCodeAbnormalityAsymmetryType
		/// </summary>
		public static Coding Code_MgAbnormalityAsymmetryType = new Coding(System, "mgAbnormalityAsymmetryType", "");                              // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - MGCodeAbnormalityDensityType
		/// </summary>
		public static Coding Code_MgAbnormalityDensityType = new Coding(System, "mgAbnormalityDensityType", "");                                  // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - MGCalcificationType
		/// </summary>
		public static Coding Code_MgCalcificationType = new Coding(System, "mgCalcificationType", "");                                            // CSBuilder.cs:438
		                                                                                                                                          // CSBuilder.cs:424
		/// <summary>
		/// Slicing Component Code - MGCalcificationDistribution
		/// </summary>
		public static Coding Code_MgCalcificationDistribution = new Coding(System, "mgCalcificationDistribution", "");                            // CSBuilder.cs:438
		//- Fields
	}
}
