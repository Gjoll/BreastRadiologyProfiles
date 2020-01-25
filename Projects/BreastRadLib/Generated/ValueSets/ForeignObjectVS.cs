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
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public ForeignObjectVS()                                                                                                                  // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(ForeignObjectCS.Code_BBPellet);                                                                                      // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_BiopsyClip);                                                                                    // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_BreastMarker);                                                                                  // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Calcification);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_CatheterSleeves);                                                                               // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_ChemotherapyPort);                                                                              // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Clip);                                                                                          // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Coil);                                                                                          // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Glass);                                                                                         // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_GoldSeed);                                                                                      // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_GunshotWound);                                                                                  // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_MarkerClip);                                                                                    // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Metal);                                                                                         // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_MetallicMarker);                                                                                // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Needle);                                                                                        // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_NippleJewelry);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_NonMetallicBody);                                                                               // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Pacemaker);                                                                                     // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_SiliconeGranuloma);                                                                             // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Sponge);                                                                                        // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_SurgicalClip);                                                                                  // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Swab);                                                                                          // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_TitaniumClip);                                                                                  // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_TitaniumMarkerClip);                                                                            // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Wire);                                                                                          // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_WireFragment);                                                                                  // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_BBPellets);                                                                                     // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_BiopsyClips);                                                                                   // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_BreastMarkers);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Calcifications);                                                                                // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_Clips);                                                                                         // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_MetallicMarkers);                                                                               // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_MetallicObjects);                                                                               // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_SurgicalClips);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(ForeignObjectCS.Code_TitaniumClips);                                                                                 // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
