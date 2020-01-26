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
	public class ForeignObjectCS                                                                                                               // CSBuilder.cs:485
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/ForeignObjectCS";                                               // CSBuilder.cs:489
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] BB pellet
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_BBPellet = new Coding(System, "BBPellet", "BB pellet");                                                         // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Biopsy clip
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_BiopsyClip = new Coding(System, "BiopsyClip", "Biopsy clip");                                                   // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Breast marker
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_BreastMarker = new Coding(System, "BreastMarker", "Breast marker");                                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Calcification
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_Calcification = new Coding(System, "Calcification", "Calcification");                                           // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Catheter sleeves
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_CatheterSleeves = new Coding(System, "CatheterSleeves", "Catheter sleeves");                                    // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Chemotherapy port
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_ChemotherapyPort = new Coding(System, "ChemotherapyPort", "Chemotherapy port");                                 // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Clip
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Clip = new Coding(System, "Clip", "Clip");                                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Coil
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Coil = new Coding(System, "Coil", "Coil");                                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Glass
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Glass = new Coding(System, "Glass", "Glass");                                                                   // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Gold seed
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_GoldSeed = new Coding(System, "GoldSeed", "Gold seed");                                                         // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Gunshot wound
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_GunshotWound = new Coding(System, "GunshotWound", "Gunshot wound");                                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Marker clip
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MarkerClip = new Coding(System, "MarkerClip", "Marker clip");                                                   // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Metal
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Metal = new Coding(System, "Metal", "Metal");                                                                   // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Metallic marker
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_MetallicMarker = new Coding(System, "MetallicMarker", "Metallic marker");                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Needle
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Needle = new Coding(System, "Needle", "Needle");                                                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Nipple jewelry
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_NippleJewelry = new Coding(System, "NippleJewelry", "Nipple jewelry");                                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Non-metallic body
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_NonMetallicBody = new Coding(System, "Non-metallicBody", "Non-metallic body");                                  // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Pacemaker
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Pacemaker = new Coding(System, "Pacemaker", "Pacemaker");                                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Silicone granuloma
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SiliconeGranuloma = new Coding(System, "SiliconeGranuloma", "Silicone granuloma");                              // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Sponge
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Sponge = new Coding(System, "Sponge", "Sponge");                                                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Surgical clip
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SurgicalClip = new Coding(System, "SurgicalClip", "Surgical clip");                                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Swab
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Swab = new Coding(System, "Swab", "Swab");                                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Titanium clip
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_TitaniumClip = new Coding(System, "TitaniumClip", "Titanium clip");                                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Titanium marker clip
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_TitaniumMarkerClip = new Coding(System, "TitaniumMarkerClip", "Titanium marker clip");                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Wire
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Wire = new Coding(System, "Wire", "Wire");                                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Wire fragment
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_WireFragment = new Coding(System, "WireFragment", "Wire fragment");                                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] BB pellets
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_BBPellets = new Coding(System, "BBPellets", "BB pellets");                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Biopsy clips
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_BiopsyClips = new Coding(System, "BiopsyClips", "Biopsy clips");                                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Breast markers
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_BreastMarkers = new Coding(System, "BreastMarkers", "Breast markers");                                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Calcifications
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_Calcifications = new Coding(System, "Calcifications", "Calcifications");                                        // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Clips
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Clips = new Coding(System, "Clips", "Clips");                                                                   // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Metallic markers
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_MetallicMarkers = new Coding(System, "MetallicMarkers", "Metallic markers");                                    // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Metallic objects
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MetallicObjects = new Coding(System, "MetallicObjects", "Metallic objects");                                    // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Surgical clips
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SurgicalClips = new Coding(System, "SurgicalClips", "Surgical clips");                                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Titanium clips
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_TitaniumClips = new Coding(System, "TitaniumClips", "Titanium clips");                                          // CSBuilder.cs:515
		//- Fields
	}
}
