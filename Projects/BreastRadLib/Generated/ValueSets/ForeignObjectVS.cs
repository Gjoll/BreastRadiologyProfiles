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
	public class ForeignObjectVS                                                                                                               // CSBuilder.cs:413
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:434
		{                                                                                                                                         // CSBuilder.cs:435
		    Coding value;                                                                                                                         // CSBuilder.cs:436
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:437
		    {                                                                                                                                     // CSBuilder.cs:438
		        return tCode.value;                                                                                                               // CSBuilder.cs:439
		    }                                                                                                                                     // CSBuilder.cs:440
		                                                                                                                                          // CSBuilder.cs:441
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:442
		    {                                                                                                                                     // CSBuilder.cs:443
		        this.value= value;                                                                                                                // CSBuilder.cs:444
		    }                                                                                                                                     // CSBuilder.cs:445
		}                                                                                                                                         // CSBuilder.cs:446
		public TCoding Code_BBPellet = new TCoding(ForeignObjectCS.Code_BBPellet);                                                                // CSBuilder.cs:464
		public TCoding Code_BiopsyClip = new TCoding(ForeignObjectCS.Code_BiopsyClip);                                                            // CSBuilder.cs:464
		public TCoding Code_BreastMarker = new TCoding(ForeignObjectCS.Code_BreastMarker);                                                        // CSBuilder.cs:464
		public TCoding Code_Calcification = new TCoding(ForeignObjectCS.Code_Calcification);                                                      // CSBuilder.cs:464
		public TCoding Code_CatheterSleeves = new TCoding(ForeignObjectCS.Code_CatheterSleeves);                                                  // CSBuilder.cs:464
		public TCoding Code_ChemotherapyPort = new TCoding(ForeignObjectCS.Code_ChemotherapyPort);                                                // CSBuilder.cs:464
		public TCoding Code_Clip = new TCoding(ForeignObjectCS.Code_Clip);                                                                        // CSBuilder.cs:464
		public TCoding Code_Coil = new TCoding(ForeignObjectCS.Code_Coil);                                                                        // CSBuilder.cs:464
		public TCoding Code_Glass = new TCoding(ForeignObjectCS.Code_Glass);                                                                      // CSBuilder.cs:464
		public TCoding Code_GoldSeed = new TCoding(ForeignObjectCS.Code_GoldSeed);                                                                // CSBuilder.cs:464
		public TCoding Code_GunshotWound = new TCoding(ForeignObjectCS.Code_GunshotWound);                                                        // CSBuilder.cs:464
		public TCoding Code_MarkerClip = new TCoding(ForeignObjectCS.Code_MarkerClip);                                                            // CSBuilder.cs:464
		public TCoding Code_Metal = new TCoding(ForeignObjectCS.Code_Metal);                                                                      // CSBuilder.cs:464
		public TCoding Code_MetallicMarker = new TCoding(ForeignObjectCS.Code_MetallicMarker);                                                    // CSBuilder.cs:464
		public TCoding Code_Needle = new TCoding(ForeignObjectCS.Code_Needle);                                                                    // CSBuilder.cs:464
		public TCoding Code_NippleJewelry = new TCoding(ForeignObjectCS.Code_NippleJewelry);                                                      // CSBuilder.cs:464
		public TCoding Code_NonMetallicBody = new TCoding(ForeignObjectCS.Code_NonMetallicBody);                                                  // CSBuilder.cs:464
		public TCoding Code_Pacemaker = new TCoding(ForeignObjectCS.Code_Pacemaker);                                                              // CSBuilder.cs:464
		public TCoding Code_SiliconeGranuloma = new TCoding(ForeignObjectCS.Code_SiliconeGranuloma);                                              // CSBuilder.cs:464
		public TCoding Code_Sponge = new TCoding(ForeignObjectCS.Code_Sponge);                                                                    // CSBuilder.cs:464
		public TCoding Code_SurgicalClip = new TCoding(ForeignObjectCS.Code_SurgicalClip);                                                        // CSBuilder.cs:464
		public TCoding Code_Swab = new TCoding(ForeignObjectCS.Code_Swab);                                                                        // CSBuilder.cs:464
		public TCoding Code_TitaniumClip = new TCoding(ForeignObjectCS.Code_TitaniumClip);                                                        // CSBuilder.cs:464
		public TCoding Code_TitaniumMarkerClip = new TCoding(ForeignObjectCS.Code_TitaniumMarkerClip);                                            // CSBuilder.cs:464
		public TCoding Code_Wire = new TCoding(ForeignObjectCS.Code_Wire);                                                                        // CSBuilder.cs:464
		public TCoding Code_WireFragment = new TCoding(ForeignObjectCS.Code_WireFragment);                                                        // CSBuilder.cs:464
		public TCoding Code_BBPellets = new TCoding(ForeignObjectCS.Code_BBPellets);                                                              // CSBuilder.cs:464
		public TCoding Code_BiopsyClips = new TCoding(ForeignObjectCS.Code_BiopsyClips);                                                          // CSBuilder.cs:464
		public TCoding Code_BreastMarkers = new TCoding(ForeignObjectCS.Code_BreastMarkers);                                                      // CSBuilder.cs:464
		public TCoding Code_Calcifications = new TCoding(ForeignObjectCS.Code_Calcifications);                                                    // CSBuilder.cs:464
		public TCoding Code_Clips = new TCoding(ForeignObjectCS.Code_Clips);                                                                      // CSBuilder.cs:464
		public TCoding Code_MetallicMarkers = new TCoding(ForeignObjectCS.Code_MetallicMarkers);                                                  // CSBuilder.cs:464
		public TCoding Code_MetallicObjects = new TCoding(ForeignObjectCS.Code_MetallicObjects);                                                  // CSBuilder.cs:464
		public TCoding Code_SurgicalClips = new TCoding(ForeignObjectCS.Code_SurgicalClips);                                                      // CSBuilder.cs:464
		public TCoding Code_TitaniumClips = new TCoding(ForeignObjectCS.Code_TitaniumClips);                                                      // CSBuilder.cs:464
		                                                                                                                                          // CSBuilder.cs:419
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:420
		                                                                                                                                          // CSBuilder.cs:421
		public ForeignObjectVS()                                                                                                                  // CSBuilder.cs:422
		{                                                                                                                                         // CSBuilder.cs:423
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:424
		    this.Members.Add(this.Code_BBPellet);                                                                                                 // CSBuilder.cs:467
		    this.Members.Add(this.Code_BiopsyClip);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_BreastMarker);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_Calcification);                                                                                            // CSBuilder.cs:467
		    this.Members.Add(this.Code_CatheterSleeves);                                                                                          // CSBuilder.cs:467
		    this.Members.Add(this.Code_ChemotherapyPort);                                                                                         // CSBuilder.cs:467
		    this.Members.Add(this.Code_Clip);                                                                                                     // CSBuilder.cs:467
		    this.Members.Add(this.Code_Coil);                                                                                                     // CSBuilder.cs:467
		    this.Members.Add(this.Code_Glass);                                                                                                    // CSBuilder.cs:467
		    this.Members.Add(this.Code_GoldSeed);                                                                                                 // CSBuilder.cs:467
		    this.Members.Add(this.Code_GunshotWound);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_MarkerClip);                                                                                               // CSBuilder.cs:467
		    this.Members.Add(this.Code_Metal);                                                                                                    // CSBuilder.cs:467
		    this.Members.Add(this.Code_MetallicMarker);                                                                                           // CSBuilder.cs:467
		    this.Members.Add(this.Code_Needle);                                                                                                   // CSBuilder.cs:467
		    this.Members.Add(this.Code_NippleJewelry);                                                                                            // CSBuilder.cs:467
		    this.Members.Add(this.Code_NonMetallicBody);                                                                                          // CSBuilder.cs:467
		    this.Members.Add(this.Code_Pacemaker);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_SiliconeGranuloma);                                                                                        // CSBuilder.cs:467
		    this.Members.Add(this.Code_Sponge);                                                                                                   // CSBuilder.cs:467
		    this.Members.Add(this.Code_SurgicalClip);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_Swab);                                                                                                     // CSBuilder.cs:467
		    this.Members.Add(this.Code_TitaniumClip);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_TitaniumMarkerClip);                                                                                       // CSBuilder.cs:467
		    this.Members.Add(this.Code_Wire);                                                                                                     // CSBuilder.cs:467
		    this.Members.Add(this.Code_WireFragment);                                                                                             // CSBuilder.cs:467
		    this.Members.Add(this.Code_BBPellets);                                                                                                // CSBuilder.cs:467
		    this.Members.Add(this.Code_BiopsyClips);                                                                                              // CSBuilder.cs:467
		    this.Members.Add(this.Code_BreastMarkers);                                                                                            // CSBuilder.cs:467
		    this.Members.Add(this.Code_Calcifications);                                                                                           // CSBuilder.cs:467
		    this.Members.Add(this.Code_Clips);                                                                                                    // CSBuilder.cs:467
		    this.Members.Add(this.Code_MetallicMarkers);                                                                                          // CSBuilder.cs:467
		    this.Members.Add(this.Code_MetallicObjects);                                                                                          // CSBuilder.cs:467
		    this.Members.Add(this.Code_SurgicalClips);                                                                                            // CSBuilder.cs:467
		    this.Members.Add(this.Code_TitaniumClips);                                                                                            // CSBuilder.cs:467
		}                                                                                                                                         // CSBuilder.cs:426
		//- Fields
	}
}
