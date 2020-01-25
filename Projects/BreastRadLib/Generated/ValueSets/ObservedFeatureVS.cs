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
	public class ObservedFeatureVS                                                                                                             // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public ObservedFeatureVS()                                                                                                                // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(ObservedFeatureCS.Code_AxillaryAdenopathy);                                                                          // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_BiopsyClip);                                                                                  // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_BiopsyClips);                                                                                 // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_BrachytherapyTube);                                                                           // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_ChestWallInvasion);                                                                           // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_CooperDistorted);                                                                             // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_CooperThickened);                                                                             // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_Edema);                                                                                       // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_EdemaAdj);                                                                                    // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_GoldSeed);                                                                                    // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_Hematoma);                                                                                    // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_NippleRetraction);                                                                            // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_NOChestWallInvasion);                                                                         // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_PectoralisMuscleInvasion);                                                                    // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_PectoralisMuscleInvolvement);                                                                 // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_PectoralisMuscleTenting);                                                                     // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_PostSurgicalScar);                                                                            // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_Seroma);                                                                                      // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_SkinInvolvement);                                                                             // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_SkinLesion);                                                                                  // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_SkinRetraction);                                                                              // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_SkinThickening);                                                                              // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_SurgicalClip);                                                                                // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_SurgicalClips);                                                                               // CSBuilder.cs:362
		    this.Members.Add(ObservedFeatureCS.Code_TrabecularThickening);                                                                        // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
