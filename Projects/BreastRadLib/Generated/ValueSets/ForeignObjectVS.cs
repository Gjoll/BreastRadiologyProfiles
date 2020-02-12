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
	public class ForeignObjectVS                                                                                                               // CSBuilder.cs:338
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:359
		{                                                                                                                                         // CSBuilder.cs:360
		    Coding value;                                                                                                                         // CSBuilder.cs:361
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:362
		    {                                                                                                                                     // CSBuilder.cs:363
		        return tCode.value;                                                                                                               // CSBuilder.cs:364
		    }                                                                                                                                     // CSBuilder.cs:365
		                                                                                                                                          // CSBuilder.cs:366
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:367
		    {                                                                                                                                     // CSBuilder.cs:368
		        this.value= value;                                                                                                                // CSBuilder.cs:369
		    }                                                                                                                                     // CSBuilder.cs:370
		}                                                                                                                                         // CSBuilder.cs:371
		public TCoding Code_BBPellet = new TCoding(ForeignObjectCS.Code_BBPellet);                                                                // CSBuilder.cs:389
		public TCoding Code_BBPellets = new TCoding(ForeignObjectCS.Code_BBPellets);                                                              // CSBuilder.cs:389
		public TCoding Code_BiopsyClip = new TCoding(ForeignObjectCS.Code_BiopsyClip);                                                            // CSBuilder.cs:389
		public TCoding Code_BiopsyClips = new TCoding(ForeignObjectCS.Code_BiopsyClips);                                                          // CSBuilder.cs:389
		public TCoding Code_BreastMarker = new TCoding(ForeignObjectCS.Code_BreastMarker);                                                        // CSBuilder.cs:389
		public TCoding Code_BreastMarkers = new TCoding(ForeignObjectCS.Code_BreastMarkers);                                                      // CSBuilder.cs:389
		public TCoding Code_CatheterSleeves = new TCoding(ForeignObjectCS.Code_CatheterSleeves);                                                  // CSBuilder.cs:389
		public TCoding Code_ChemotherapyPort = new TCoding(ForeignObjectCS.Code_ChemotherapyPort);                                                // CSBuilder.cs:389
		public TCoding Code_Clip = new TCoding(ForeignObjectCS.Code_Clip);                                                                        // CSBuilder.cs:389
		public TCoding Code_Clips = new TCoding(ForeignObjectCS.Code_Clips);                                                                      // CSBuilder.cs:389
		public TCoding Code_Coil = new TCoding(ForeignObjectCS.Code_Coil);                                                                        // CSBuilder.cs:389
		public TCoding Code_Glass = new TCoding(ForeignObjectCS.Code_Glass);                                                                      // CSBuilder.cs:389
		public TCoding Code_GoldSeed = new TCoding(ForeignObjectCS.Code_GoldSeed);                                                                // CSBuilder.cs:389
		public TCoding Code_GunshotWound = new TCoding(ForeignObjectCS.Code_GunshotWound);                                                        // CSBuilder.cs:389
		public TCoding Code_MarkerClip = new TCoding(ForeignObjectCS.Code_MarkerClip);                                                            // CSBuilder.cs:389
		public TCoding Code_Metal = new TCoding(ForeignObjectCS.Code_Metal);                                                                      // CSBuilder.cs:389
		public TCoding Code_MetallicMarker = new TCoding(ForeignObjectCS.Code_MetallicMarker);                                                    // CSBuilder.cs:389
		public TCoding Code_MetallicMarkers = new TCoding(ForeignObjectCS.Code_MetallicMarkers);                                                  // CSBuilder.cs:389
		public TCoding Code_MetallicObjects = new TCoding(ForeignObjectCS.Code_MetallicObjects);                                                  // CSBuilder.cs:389
		public TCoding Code_Needle = new TCoding(ForeignObjectCS.Code_Needle);                                                                    // CSBuilder.cs:389
		public TCoding Code_NippleJewelry = new TCoding(ForeignObjectCS.Code_NippleJewelry);                                                      // CSBuilder.cs:389
		public TCoding Code_NonMetallicBody = new TCoding(ForeignObjectCS.Code_NonMetallicBody);                                                  // CSBuilder.cs:389
		public TCoding Code_Pacemaker = new TCoding(ForeignObjectCS.Code_Pacemaker);                                                              // CSBuilder.cs:389
		public TCoding Code_SiliconeGranuloma = new TCoding(ForeignObjectCS.Code_SiliconeGranuloma);                                              // CSBuilder.cs:389
		public TCoding Code_Sponge = new TCoding(ForeignObjectCS.Code_Sponge);                                                                    // CSBuilder.cs:389
		public TCoding Code_SurgicalClip = new TCoding(ForeignObjectCS.Code_SurgicalClip);                                                        // CSBuilder.cs:389
		public TCoding Code_SurgicalClips = new TCoding(ForeignObjectCS.Code_SurgicalClips);                                                      // CSBuilder.cs:389
		public TCoding Code_Swab = new TCoding(ForeignObjectCS.Code_Swab);                                                                        // CSBuilder.cs:389
		public TCoding Code_TitaniumClip = new TCoding(ForeignObjectCS.Code_TitaniumClip);                                                        // CSBuilder.cs:389
		public TCoding Code_TitaniumClips = new TCoding(ForeignObjectCS.Code_TitaniumClips);                                                      // CSBuilder.cs:389
		public TCoding Code_Wire = new TCoding(ForeignObjectCS.Code_Wire);                                                                        // CSBuilder.cs:389
		public TCoding Code_WireFragment = new TCoding(ForeignObjectCS.Code_WireFragment);                                                        // CSBuilder.cs:389
		                                                                                                                                          // CSBuilder.cs:344
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:345
		                                                                                                                                          // CSBuilder.cs:346
		public ForeignObjectVS()                                                                                                                  // CSBuilder.cs:347
		{                                                                                                                                         // CSBuilder.cs:348
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:349
		    this.Members.Add(this.Code_BBPellet);                                                                                                 // CSBuilder.cs:392
		    this.Members.Add(this.Code_BBPellets);                                                                                                // CSBuilder.cs:392
		    this.Members.Add(this.Code_BiopsyClip);                                                                                               // CSBuilder.cs:392
		    this.Members.Add(this.Code_BiopsyClips);                                                                                              // CSBuilder.cs:392
		    this.Members.Add(this.Code_BreastMarker);                                                                                             // CSBuilder.cs:392
		    this.Members.Add(this.Code_BreastMarkers);                                                                                            // CSBuilder.cs:392
		    this.Members.Add(this.Code_CatheterSleeves);                                                                                          // CSBuilder.cs:392
		    this.Members.Add(this.Code_ChemotherapyPort);                                                                                         // CSBuilder.cs:392
		    this.Members.Add(this.Code_Clip);                                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_Clips);                                                                                                    // CSBuilder.cs:392
		    this.Members.Add(this.Code_Coil);                                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_Glass);                                                                                                    // CSBuilder.cs:392
		    this.Members.Add(this.Code_GoldSeed);                                                                                                 // CSBuilder.cs:392
		    this.Members.Add(this.Code_GunshotWound);                                                                                             // CSBuilder.cs:392
		    this.Members.Add(this.Code_MarkerClip);                                                                                               // CSBuilder.cs:392
		    this.Members.Add(this.Code_Metal);                                                                                                    // CSBuilder.cs:392
		    this.Members.Add(this.Code_MetallicMarker);                                                                                           // CSBuilder.cs:392
		    this.Members.Add(this.Code_MetallicMarkers);                                                                                          // CSBuilder.cs:392
		    this.Members.Add(this.Code_MetallicObjects);                                                                                          // CSBuilder.cs:392
		    this.Members.Add(this.Code_Needle);                                                                                                   // CSBuilder.cs:392
		    this.Members.Add(this.Code_NippleJewelry);                                                                                            // CSBuilder.cs:392
		    this.Members.Add(this.Code_NonMetallicBody);                                                                                          // CSBuilder.cs:392
		    this.Members.Add(this.Code_Pacemaker);                                                                                                // CSBuilder.cs:392
		    this.Members.Add(this.Code_SiliconeGranuloma);                                                                                        // CSBuilder.cs:392
		    this.Members.Add(this.Code_Sponge);                                                                                                   // CSBuilder.cs:392
		    this.Members.Add(this.Code_SurgicalClip);                                                                                             // CSBuilder.cs:392
		    this.Members.Add(this.Code_SurgicalClips);                                                                                            // CSBuilder.cs:392
		    this.Members.Add(this.Code_Swab);                                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_TitaniumClip);                                                                                             // CSBuilder.cs:392
		    this.Members.Add(this.Code_TitaniumClips);                                                                                            // CSBuilder.cs:392
		    this.Members.Add(this.Code_Wire);                                                                                                     // CSBuilder.cs:392
		    this.Members.Add(this.Code_WireFragment);                                                                                             // CSBuilder.cs:392
		}                                                                                                                                         // CSBuilder.cs:351
		//- Fields
	}
}
