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
	public class CorrespondsWithCodeSystemCS                                                                                                   // CSBuilder.cs:475
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/CorrespondsWithCodeSystemCS";                                   // CSBuilder.cs:479
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Aspiration
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Aspiration = new Coding(System, "Aspiration", "Aspiration");                                                    // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Biopsy
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Biopsy = new Coding(System, "Biopsy", "Biopsy");                                                                // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Concern
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Concern = new Coding(System, "Concern", "Concern");                                                             // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Ductogram
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Ductogram = new Coding(System, "Ductogram", "Ductogram");                                                       // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Incidental finding
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_IncidentalFinding = new Coding(System, "IncidentalFinding", "Incidental finding");                              // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Mammogram
		/// Valid for the following modalities: US MRI NM.
		/// </summary>
		public static Coding Code_Mammogram = new Coding(System, "Mammogram", "Mammogram");                                                       // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] MRI
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_MRI = new Coding(System, "MRI", "MRI");                                                                         // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Nipple discharge
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_NippleDischarge = new Coding(System, "NippleDischarge", "Nipple discharge");                                    // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Outside exam
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_OutsideExam = new Coding(System, "OutsideExam", "Outside exam");                                                // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Pain
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Pain = new Coding(System, "Pain", "Pain");                                                                      // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Palpated
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Palpated = new Coding(System, "Palpated", "Palpated");                                                          // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Post-operative
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PostOperative = new Coding(System, "Post-operative", "Post-operative");                                         // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Previous biopsy
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_PreviousBiopsy = new Coding(System, "PreviousBiopsy", "Previous biopsy");                                       // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Prior exam
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PriorExam = new Coding(System, "PriorExam", "Prior exam");                                                      // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Redness
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Redness = new Coding(System, "Redness", "Redness");                                                             // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Scinti
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Scinti = new Coding(System, "Scinti", "Scinti");                                                                // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] size < mammo
		/// Valid for the following modalities: US MRI NM.
		/// </summary>
		public static Coding Code_SizeLessThanMammo = new Coding(System, "size<Mammo", "size < mammo");                                           // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] size < MRI
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SizeLessThanMRI = new Coding(System, "size<MRI", "size < MRI");                                                 // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] size < palp
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SizeLessThanPalp = new Coding(System, "size<Palp", "size < palp");                                              // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] size < US
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_SizeLessThanUS = new Coding(System, "size<US", "size < US");                                                    // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] size > mammo
		/// Valid for the following modalities: US MRI NM.
		/// </summary>
		public static Coding Code_SizeGreaterThanMammo = new Coding(System, "size>Mammo", "size > mammo");                                        // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] size > MRI
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SizeGreaterThanMRI = new Coding(System, "size>MRI", "size > MRI");                                              // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] size > palp
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SizeGreaterThanPalp = new Coding(System, "size>Palp", "size > palp");                                           // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] size > US
		/// Valid for the following modalities: US MRI NM.
		/// </summary>
		public static Coding Code_SizeGreaterThanUS = new Coding(System, "size>US", "size > US");                                                 // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Skin marker
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SkinMarker = new Coding(System, "SkinMarker", "Skin marker");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Surgery
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Surgery = new Coding(System, "Surgery", "Surgery");                                                             // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Surgical site
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_SurgicalSite = new Coding(System, "SurgicalSite", "Surgical site");                                             // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Tenderness
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Tenderness = new Coding(System, "Tenderness", "Tenderness");                                                    // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Trigger point
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_TriggerPoint = new Coding(System, "TriggerPoint", "Trigger point");                                             // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] US
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_US = new Coding(System, "US", "US");                                                                            // CSBuilder.cs:505
		//- Fields
	}
}
