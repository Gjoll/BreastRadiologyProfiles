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
	public class ForeignObjectVS                                                                                                               // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that explicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:357
		{                                                                                                                                         // CSBuilder.cs:358
		    Coding value;                                                                                                                         // CSBuilder.cs:359
		    public static explicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        return tCode.value;                                                                                                               // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		                                                                                                                                          // CSBuilder.cs:364
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:365
		    {                                                                                                                                     // CSBuilder.cs:366
		        this.value= value;                                                                                                                // CSBuilder.cs:367
		    }                                                                                                                                     // CSBuilder.cs:368
		}                                                                                                                                         // CSBuilder.cs:369
		public TCoding Code_BBPellet = new TCoding(ForeignObjectCS.Code_BBPellet);                                                                // CSBuilder.cs:387
		public TCoding Code_BiopsyClip = new TCoding(ForeignObjectCS.Code_BiopsyClip);                                                            // CSBuilder.cs:387
		public TCoding Code_BreastMarker = new TCoding(ForeignObjectCS.Code_BreastMarker);                                                        // CSBuilder.cs:387
		public TCoding Code_Calcification = new TCoding(ForeignObjectCS.Code_Calcification);                                                      // CSBuilder.cs:387
		public TCoding Code_CatheterSleeves = new TCoding(ForeignObjectCS.Code_CatheterSleeves);                                                  // CSBuilder.cs:387
		public TCoding Code_ChemotherapyPort = new TCoding(ForeignObjectCS.Code_ChemotherapyPort);                                                // CSBuilder.cs:387
		public TCoding Code_Clip = new TCoding(ForeignObjectCS.Code_Clip);                                                                        // CSBuilder.cs:387
		public TCoding Code_Coil = new TCoding(ForeignObjectCS.Code_Coil);                                                                        // CSBuilder.cs:387
		public TCoding Code_Glass = new TCoding(ForeignObjectCS.Code_Glass);                                                                      // CSBuilder.cs:387
		public TCoding Code_GoldSeed = new TCoding(ForeignObjectCS.Code_GoldSeed);                                                                // CSBuilder.cs:387
		public TCoding Code_GunshotWound = new TCoding(ForeignObjectCS.Code_GunshotWound);                                                        // CSBuilder.cs:387
		public TCoding Code_MarkerClip = new TCoding(ForeignObjectCS.Code_MarkerClip);                                                            // CSBuilder.cs:387
		public TCoding Code_Metal = new TCoding(ForeignObjectCS.Code_Metal);                                                                      // CSBuilder.cs:387
		public TCoding Code_MetallicMarker = new TCoding(ForeignObjectCS.Code_MetallicMarker);                                                    // CSBuilder.cs:387
		public TCoding Code_Needle = new TCoding(ForeignObjectCS.Code_Needle);                                                                    // CSBuilder.cs:387
		public TCoding Code_NippleJewelry = new TCoding(ForeignObjectCS.Code_NippleJewelry);                                                      // CSBuilder.cs:387
		public TCoding Code_NonMetallicBody = new TCoding(ForeignObjectCS.Code_NonMetallicBody);                                                  // CSBuilder.cs:387
		public TCoding Code_Pacemaker = new TCoding(ForeignObjectCS.Code_Pacemaker);                                                              // CSBuilder.cs:387
		public TCoding Code_SiliconeGranuloma = new TCoding(ForeignObjectCS.Code_SiliconeGranuloma);                                              // CSBuilder.cs:387
		public TCoding Code_Sponge = new TCoding(ForeignObjectCS.Code_Sponge);                                                                    // CSBuilder.cs:387
		public TCoding Code_SurgicalClip = new TCoding(ForeignObjectCS.Code_SurgicalClip);                                                        // CSBuilder.cs:387
		public TCoding Code_Swab = new TCoding(ForeignObjectCS.Code_Swab);                                                                        // CSBuilder.cs:387
		public TCoding Code_TitaniumClip = new TCoding(ForeignObjectCS.Code_TitaniumClip);                                                        // CSBuilder.cs:387
		public TCoding Code_TitaniumMarkerClip = new TCoding(ForeignObjectCS.Code_TitaniumMarkerClip);                                            // CSBuilder.cs:387
		public TCoding Code_Wire = new TCoding(ForeignObjectCS.Code_Wire);                                                                        // CSBuilder.cs:387
		public TCoding Code_WireFragment = new TCoding(ForeignObjectCS.Code_WireFragment);                                                        // CSBuilder.cs:387
		public TCoding Code_BBPellets = new TCoding(ForeignObjectCS.Code_BBPellets);                                                              // CSBuilder.cs:387
		public TCoding Code_BiopsyClips = new TCoding(ForeignObjectCS.Code_BiopsyClips);                                                          // CSBuilder.cs:387
		public TCoding Code_BreastMarkers = new TCoding(ForeignObjectCS.Code_BreastMarkers);                                                      // CSBuilder.cs:387
		public TCoding Code_Calcifications = new TCoding(ForeignObjectCS.Code_Calcifications);                                                    // CSBuilder.cs:387
		public TCoding Code_Clips = new TCoding(ForeignObjectCS.Code_Clips);                                                                      // CSBuilder.cs:387
		public TCoding Code_MetallicMarkers = new TCoding(ForeignObjectCS.Code_MetallicMarkers);                                                  // CSBuilder.cs:387
		public TCoding Code_MetallicObjects = new TCoding(ForeignObjectCS.Code_MetallicObjects);                                                  // CSBuilder.cs:387
		public TCoding Code_SurgicalClips = new TCoding(ForeignObjectCS.Code_SurgicalClips);                                                      // CSBuilder.cs:387
		public TCoding Code_TitaniumClips = new TCoding(ForeignObjectCS.Code_TitaniumClips);                                                      // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public ForeignObjectVS()                                                                                                                  // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(ForeignObjectCS.Code_BBPellet);                                                                                      // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_BiopsyClip);                                                                                    // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_BreastMarker);                                                                                  // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Calcification);                                                                                 // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_CatheterSleeves);                                                                               // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_ChemotherapyPort);                                                                              // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Clip);                                                                                          // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Coil);                                                                                          // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Glass);                                                                                         // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_GoldSeed);                                                                                      // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_GunshotWound);                                                                                  // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_MarkerClip);                                                                                    // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Metal);                                                                                         // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_MetallicMarker);                                                                                // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Needle);                                                                                        // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_NippleJewelry);                                                                                 // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_NonMetallicBody);                                                                               // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Pacemaker);                                                                                     // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_SiliconeGranuloma);                                                                             // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Sponge);                                                                                        // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_SurgicalClip);                                                                                  // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Swab);                                                                                          // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_TitaniumClip);                                                                                  // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_TitaniumMarkerClip);                                                                            // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Wire);                                                                                          // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_WireFragment);                                                                                  // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_BBPellets);                                                                                     // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_BiopsyClips);                                                                                   // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_BreastMarkers);                                                                                 // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Calcifications);                                                                                // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_Clips);                                                                                         // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_MetallicMarkers);                                                                               // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_MetallicObjects);                                                                               // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_SurgicalClips);                                                                                 // CSBuilder.cs:390
		    this.Members.Add(ForeignObjectCS.Code_TitaniumClips);                                                                                 // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
