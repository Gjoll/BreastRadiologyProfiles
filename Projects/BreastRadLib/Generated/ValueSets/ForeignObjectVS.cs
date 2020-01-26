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
	public class ForeignObjectVS                                                                                                               // CSBuilder.cs:403
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:424
		{                                                                                                                                         // CSBuilder.cs:425
		    Coding value;                                                                                                                         // CSBuilder.cs:426
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:427
		    {                                                                                                                                     // CSBuilder.cs:428
		        return tCode.value;                                                                                                               // CSBuilder.cs:429
		    }                                                                                                                                     // CSBuilder.cs:430
		                                                                                                                                          // CSBuilder.cs:431
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:432
		    {                                                                                                                                     // CSBuilder.cs:433
		        this.value= value;                                                                                                                // CSBuilder.cs:434
		    }                                                                                                                                     // CSBuilder.cs:435
		}                                                                                                                                         // CSBuilder.cs:436
		public TCoding Code_BBPellet = new TCoding(ForeignObjectCS.Code_BBPellet);                                                                // CSBuilder.cs:454
		public TCoding Code_BiopsyClip = new TCoding(ForeignObjectCS.Code_BiopsyClip);                                                            // CSBuilder.cs:454
		public TCoding Code_BreastMarker = new TCoding(ForeignObjectCS.Code_BreastMarker);                                                        // CSBuilder.cs:454
		public TCoding Code_Calcification = new TCoding(ForeignObjectCS.Code_Calcification);                                                      // CSBuilder.cs:454
		public TCoding Code_CatheterSleeves = new TCoding(ForeignObjectCS.Code_CatheterSleeves);                                                  // CSBuilder.cs:454
		public TCoding Code_ChemotherapyPort = new TCoding(ForeignObjectCS.Code_ChemotherapyPort);                                                // CSBuilder.cs:454
		public TCoding Code_Clip = new TCoding(ForeignObjectCS.Code_Clip);                                                                        // CSBuilder.cs:454
		public TCoding Code_Coil = new TCoding(ForeignObjectCS.Code_Coil);                                                                        // CSBuilder.cs:454
		public TCoding Code_Glass = new TCoding(ForeignObjectCS.Code_Glass);                                                                      // CSBuilder.cs:454
		public TCoding Code_GoldSeed = new TCoding(ForeignObjectCS.Code_GoldSeed);                                                                // CSBuilder.cs:454
		public TCoding Code_GunshotWound = new TCoding(ForeignObjectCS.Code_GunshotWound);                                                        // CSBuilder.cs:454
		public TCoding Code_MarkerClip = new TCoding(ForeignObjectCS.Code_MarkerClip);                                                            // CSBuilder.cs:454
		public TCoding Code_Metal = new TCoding(ForeignObjectCS.Code_Metal);                                                                      // CSBuilder.cs:454
		public TCoding Code_MetallicMarker = new TCoding(ForeignObjectCS.Code_MetallicMarker);                                                    // CSBuilder.cs:454
		public TCoding Code_Needle = new TCoding(ForeignObjectCS.Code_Needle);                                                                    // CSBuilder.cs:454
		public TCoding Code_NippleJewelry = new TCoding(ForeignObjectCS.Code_NippleJewelry);                                                      // CSBuilder.cs:454
		public TCoding Code_NonMetallicBody = new TCoding(ForeignObjectCS.Code_NonMetallicBody);                                                  // CSBuilder.cs:454
		public TCoding Code_Pacemaker = new TCoding(ForeignObjectCS.Code_Pacemaker);                                                              // CSBuilder.cs:454
		public TCoding Code_SiliconeGranuloma = new TCoding(ForeignObjectCS.Code_SiliconeGranuloma);                                              // CSBuilder.cs:454
		public TCoding Code_Sponge = new TCoding(ForeignObjectCS.Code_Sponge);                                                                    // CSBuilder.cs:454
		public TCoding Code_SurgicalClip = new TCoding(ForeignObjectCS.Code_SurgicalClip);                                                        // CSBuilder.cs:454
		public TCoding Code_Swab = new TCoding(ForeignObjectCS.Code_Swab);                                                                        // CSBuilder.cs:454
		public TCoding Code_TitaniumClip = new TCoding(ForeignObjectCS.Code_TitaniumClip);                                                        // CSBuilder.cs:454
		public TCoding Code_TitaniumMarkerClip = new TCoding(ForeignObjectCS.Code_TitaniumMarkerClip);                                            // CSBuilder.cs:454
		public TCoding Code_Wire = new TCoding(ForeignObjectCS.Code_Wire);                                                                        // CSBuilder.cs:454
		public TCoding Code_WireFragment = new TCoding(ForeignObjectCS.Code_WireFragment);                                                        // CSBuilder.cs:454
		public TCoding Code_BBPellets = new TCoding(ForeignObjectCS.Code_BBPellets);                                                              // CSBuilder.cs:454
		public TCoding Code_BiopsyClips = new TCoding(ForeignObjectCS.Code_BiopsyClips);                                                          // CSBuilder.cs:454
		public TCoding Code_BreastMarkers = new TCoding(ForeignObjectCS.Code_BreastMarkers);                                                      // CSBuilder.cs:454
		public TCoding Code_Calcifications = new TCoding(ForeignObjectCS.Code_Calcifications);                                                    // CSBuilder.cs:454
		public TCoding Code_Clips = new TCoding(ForeignObjectCS.Code_Clips);                                                                      // CSBuilder.cs:454
		public TCoding Code_MetallicMarkers = new TCoding(ForeignObjectCS.Code_MetallicMarkers);                                                  // CSBuilder.cs:454
		public TCoding Code_MetallicObjects = new TCoding(ForeignObjectCS.Code_MetallicObjects);                                                  // CSBuilder.cs:454
		public TCoding Code_SurgicalClips = new TCoding(ForeignObjectCS.Code_SurgicalClips);                                                      // CSBuilder.cs:454
		public TCoding Code_TitaniumClips = new TCoding(ForeignObjectCS.Code_TitaniumClips);                                                      // CSBuilder.cs:454
		                                                                                                                                          // CSBuilder.cs:409
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:411
		public ForeignObjectVS()                                                                                                                  // CSBuilder.cs:412
		{                                                                                                                                         // CSBuilder.cs:413
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:414
		    this.Members.Add(this.Code_BBPellet);                                                                                                 // CSBuilder.cs:457
		    this.Members.Add(this.Code_BiopsyClip);                                                                                               // CSBuilder.cs:457
		    this.Members.Add(this.Code_BreastMarker);                                                                                             // CSBuilder.cs:457
		    this.Members.Add(this.Code_Calcification);                                                                                            // CSBuilder.cs:457
		    this.Members.Add(this.Code_CatheterSleeves);                                                                                          // CSBuilder.cs:457
		    this.Members.Add(this.Code_ChemotherapyPort);                                                                                         // CSBuilder.cs:457
		    this.Members.Add(this.Code_Clip);                                                                                                     // CSBuilder.cs:457
		    this.Members.Add(this.Code_Coil);                                                                                                     // CSBuilder.cs:457
		    this.Members.Add(this.Code_Glass);                                                                                                    // CSBuilder.cs:457
		    this.Members.Add(this.Code_GoldSeed);                                                                                                 // CSBuilder.cs:457
		    this.Members.Add(this.Code_GunshotWound);                                                                                             // CSBuilder.cs:457
		    this.Members.Add(this.Code_MarkerClip);                                                                                               // CSBuilder.cs:457
		    this.Members.Add(this.Code_Metal);                                                                                                    // CSBuilder.cs:457
		    this.Members.Add(this.Code_MetallicMarker);                                                                                           // CSBuilder.cs:457
		    this.Members.Add(this.Code_Needle);                                                                                                   // CSBuilder.cs:457
		    this.Members.Add(this.Code_NippleJewelry);                                                                                            // CSBuilder.cs:457
		    this.Members.Add(this.Code_NonMetallicBody);                                                                                          // CSBuilder.cs:457
		    this.Members.Add(this.Code_Pacemaker);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_SiliconeGranuloma);                                                                                        // CSBuilder.cs:457
		    this.Members.Add(this.Code_Sponge);                                                                                                   // CSBuilder.cs:457
		    this.Members.Add(this.Code_SurgicalClip);                                                                                             // CSBuilder.cs:457
		    this.Members.Add(this.Code_Swab);                                                                                                     // CSBuilder.cs:457
		    this.Members.Add(this.Code_TitaniumClip);                                                                                             // CSBuilder.cs:457
		    this.Members.Add(this.Code_TitaniumMarkerClip);                                                                                       // CSBuilder.cs:457
		    this.Members.Add(this.Code_Wire);                                                                                                     // CSBuilder.cs:457
		    this.Members.Add(this.Code_WireFragment);                                                                                             // CSBuilder.cs:457
		    this.Members.Add(this.Code_BBPellets);                                                                                                // CSBuilder.cs:457
		    this.Members.Add(this.Code_BiopsyClips);                                                                                              // CSBuilder.cs:457
		    this.Members.Add(this.Code_BreastMarkers);                                                                                            // CSBuilder.cs:457
		    this.Members.Add(this.Code_Calcifications);                                                                                           // CSBuilder.cs:457
		    this.Members.Add(this.Code_Clips);                                                                                                    // CSBuilder.cs:457
		    this.Members.Add(this.Code_MetallicMarkers);                                                                                          // CSBuilder.cs:457
		    this.Members.Add(this.Code_MetallicObjects);                                                                                          // CSBuilder.cs:457
		    this.Members.Add(this.Code_SurgicalClips);                                                                                            // CSBuilder.cs:457
		    this.Members.Add(this.Code_TitaniumClips);                                                                                            // CSBuilder.cs:457
		}                                                                                                                                         // CSBuilder.cs:416
		//- Fields
	}
}
