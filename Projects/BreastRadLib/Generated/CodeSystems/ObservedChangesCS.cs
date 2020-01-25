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
	public class ObservedChangesCS                                                                                                             // CSBuilder.cs:380
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/ObservedChangesCS";                                             // CSBuilder.cs:384
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Decrease in calcifications
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_DecreaseInCalcifications = new Coding(System, "DecreaseInCalcifications", "Decrease in calcifications");        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Decrease in number
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_DecreaseInNumber = new Coding(System, "DecreaseInNumber", "Decrease in number");                                // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Decrease in size
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_DecreaseInSize = new Coding(System, "DecreaseInSize", "Decrease in size");                                      // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Increase in calcifications
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_IncreaseInCalcifications = new Coding(System, "IncreaseInCalcifications", "Increase in calcifications");        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Increase in number
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_IncreaseInNumber = new Coding(System, "IncreaseInNumber", "Increase in number");                                // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Increase in size
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_IncreaseInSize = new Coding(System, "IncreaseInSize", "Increase in size");                                      // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Less prominent
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_LessProminent = new Coding(System, "LessProminent", "Less prominent");                                          // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] More prominent
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_MoreProminent = new Coding(System, "MoreProminent", "More prominent");                                          // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] New
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_New = new Coding(System, "New", "New");                                                                         // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] No longer seen
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_NoLongerSeen = new Coding(System, "NoLongerSeen", "No longer seen");                                            // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Not significant changed
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_NotSignificantChanged = new Coding(System, "NotSignificantChanged", "Not significant changed");                 // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Partially removed
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PartiallyRemoved = new Coding(System, "PartiallyRemoved", "Partially removed");                                 // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Unspecified change has occured in item
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_RepresentsChange = new Coding(System, "RepresentsChange", "Represents change");                                 // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Stable
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Stable = new Coding(System, "Stable", "Stable");                                                                // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// Item observation is an incidental Finding
		/// </summary>
		public static Coding Code_IncidentalFinding = new Coding(System, "IncidentalFinding", "Incidental Finding");                              // CSBuilder.cs:410
		//- Fields
	}
}
