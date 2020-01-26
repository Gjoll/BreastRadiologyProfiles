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
	public class ObservedFeatureCS                                                                                                             // CSBuilder.cs:475
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/ObservedFeatureCS";                                             // CSBuilder.cs:479
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// Axillary adenopathy
		/// Enlarged axillary lymph nodes may warrant comment, clinical correlation, and additional
		/// evaluation, especially if new or considerably larger or rounder when compared to previous examination.
		/// A review of the patient�s medical history may elucidate the cause for axillary adenopathy, averting
		/// recommendation for additional evaluation. When one or more large axillary nodes are
		/// substantially composed of fat, this is a normal variant.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG MRI.
		/// </summary>
		public static Coding Code_AxillaryAdenopathy = new Coding(System, "AxillaryAdenopathy", "Axillary adenopathy");                           // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Biopsy clip
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_BiopsyClip = new Coding(System, "BiopsyClip", "Biopsy clip");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Biopsy clips
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_BiopsyClips = new Coding(System, "BiopsyClips", "Biopsy clips");                                                // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Brachytherapy tube
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_BrachytherapyTube = new Coding(System, "BrachytherapyTube", "Brachytherapy tube");                              // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Chest wall invasion
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_ChestWallInvasion = new Coding(System, "ChestWallInvasion", "Chest wall invasion");                             // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Cooper distorted
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_CooperDistorted = new Coding(System, "CooperDistorted", "Cooper distorted");                                    // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Cooper thickened
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_CooperThickened = new Coding(System, "CooperThickened", "Cooper thickened");                                    // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Edema
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_Edema = new Coding(System, "Edema", "Edema");                                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Edema adj
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_EdemaAdj = new Coding(System, "EdemaAdj", "Edema adj");                                                         // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Gold Seed
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_GoldSeed = new Coding(System, "GoldSeed", "Gold Seed");                                                         // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Hematoma
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Hematoma = new Coding(System, "Hematoma", "Hematoma");                                                          // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// Nipple retraction
		/// The nipple is pulled in. This should not be confused with nipple inversion, which is often bilateral
		/// and which in the absence of any suspicious findings and when stable for a long period of time,
		/// is not a sign of malignancy. However, if nipple retraction is new, suspicion for underlying malignancy is increased.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG MRI.
		/// </summary>
		public static Coding Code_NippleRetraction = new Coding(System, "NippleRetraction", "Nipple retraction");                                 // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] NO Chest wall invasion
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_NOChestWallInvasion = new Coding(System, "NOChestWallInvasion", "NO Chest wall invasion");                      // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Pectoralis muscle invasion
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_PectoralisMuscleInvasion = new Coding(System, "PectoralisMuscleInvasion", "Pectoralis muscle invasion");        // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Pectoralis muscle involvement
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_PectoralisMuscleInvolvement = new Coding(System, "PectoralisMuscleInvolvement", "Pectoralis muscle involvement");// CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Pectoralis muscle tenting
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_PectoralisMuscleTenting = new Coding(System, "PectoralisMuscleTenting", "Pectoralis muscle tenting");           // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Post surgical scar
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PostSurgicalScar = new Coding(System, "PostSurgicalScar", "Post surgical scar");                                // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Seroma
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Seroma = new Coding(System, "Seroma", "Seroma");                                                                // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Skin involvement
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SkinInvolvement = new Coding(System, "SkinInvolvement", "Skin involvement");                                    // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// Skin lesion
		/// This finding may be described in the mammography report or annotated on the mammographic
		/// image when it projects over the breast (especially on 2 different projections), and may be mistaken
		/// for an intramammary lesion. A raised skin lesion sufficiently large to be seen at mammography
		/// should be marked by the technologist with a radiopaque device designated for use as a marker for
		/// a skin lesion.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SkinLesion = new Coding(System, "SkinLesion", "Skin lesion");                                                   // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Skin retraction
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SkinRetraction = new Coding(System, "SkinRetraction", "Skin retraction");                                       // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// Skin thickening
		/// Skin thickening may be focal or diffuse, and is defined as being greater than 2 mm in thickness. This
		/// finding is of particular concern if it represents a change from previous mammography examinations.
		/// However, unilateral skin thickening is an expected finding after radiation therapy.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SkinThickening = new Coding(System, "SkinThickening", "Skin thickening");                                       // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Surgical clip
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SurgicalClip = new Coding(System, "SurgicalClip", "Surgical clip");                                             // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// [PR] Surgical clips
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SurgicalClips = new Coding(System, "SurgicalClips", "Surgical clips");                                          // CSBuilder.cs:505
		                                                                                                                                          // CSBuilder.cs:491
		/// <summary>
		/// Trabecular thickening
		/// This is a thickening of the fibrous septa of the breast.
		/// -- Bi-Rads® Atlas — Mammography Fifth Ed. 2013
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_TrabecularThickening = new Coding(System, "TrabecularThickening", "Trabecular thickening");                     // CSBuilder.cs:505
		//- Fields
	}
}
