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
		public TCoding Code_AxillaryAdenopathy = new TCoding(ObservedFeatureCS.Code_AxillaryAdenopathy);                                          // CSBuilder.cs:387
		public TCoding Code_BiopsyClip = new TCoding(ObservedFeatureCS.Code_BiopsyClip);                                                          // CSBuilder.cs:387
		public TCoding Code_BiopsyClips = new TCoding(ObservedFeatureCS.Code_BiopsyClips);                                                        // CSBuilder.cs:387
		public TCoding Code_BrachytherapyTube = new TCoding(ObservedFeatureCS.Code_BrachytherapyTube);                                            // CSBuilder.cs:387
		public TCoding Code_ChestWallInvasion = new TCoding(ObservedFeatureCS.Code_ChestWallInvasion);                                            // CSBuilder.cs:387
		public TCoding Code_CooperDistorted = new TCoding(ObservedFeatureCS.Code_CooperDistorted);                                                // CSBuilder.cs:387
		public TCoding Code_CooperThickened = new TCoding(ObservedFeatureCS.Code_CooperThickened);                                                // CSBuilder.cs:387
		public TCoding Code_Edema = new TCoding(ObservedFeatureCS.Code_Edema);                                                                    // CSBuilder.cs:387
		public TCoding Code_EdemaAdj = new TCoding(ObservedFeatureCS.Code_EdemaAdj);                                                              // CSBuilder.cs:387
		public TCoding Code_GoldSeed = new TCoding(ObservedFeatureCS.Code_GoldSeed);                                                              // CSBuilder.cs:387
		public TCoding Code_Hematoma = new TCoding(ObservedFeatureCS.Code_Hematoma);                                                              // CSBuilder.cs:387
		public TCoding Code_NippleRetraction = new TCoding(ObservedFeatureCS.Code_NippleRetraction);                                              // CSBuilder.cs:387
		public TCoding Code_NOChestWallInvasion = new TCoding(ObservedFeatureCS.Code_NOChestWallInvasion);                                        // CSBuilder.cs:387
		public TCoding Code_PectoralisMuscleInvasion = new TCoding(ObservedFeatureCS.Code_PectoralisMuscleInvasion);                              // CSBuilder.cs:387
		public TCoding Code_PectoralisMuscleInvolvement = new TCoding(ObservedFeatureCS.Code_PectoralisMuscleInvolvement);                        // CSBuilder.cs:387
		public TCoding Code_PectoralisMuscleTenting = new TCoding(ObservedFeatureCS.Code_PectoralisMuscleTenting);                                // CSBuilder.cs:387
		public TCoding Code_PostSurgicalScar = new TCoding(ObservedFeatureCS.Code_PostSurgicalScar);                                              // CSBuilder.cs:387
		public TCoding Code_Seroma = new TCoding(ObservedFeatureCS.Code_Seroma);                                                                  // CSBuilder.cs:387
		public TCoding Code_SkinInvolvement = new TCoding(ObservedFeatureCS.Code_SkinInvolvement);                                                // CSBuilder.cs:387
		public TCoding Code_SkinLesion = new TCoding(ObservedFeatureCS.Code_SkinLesion);                                                          // CSBuilder.cs:387
		public TCoding Code_SkinRetraction = new TCoding(ObservedFeatureCS.Code_SkinRetraction);                                                  // CSBuilder.cs:387
		public TCoding Code_SkinThickening = new TCoding(ObservedFeatureCS.Code_SkinThickening);                                                  // CSBuilder.cs:387
		public TCoding Code_SurgicalClip = new TCoding(ObservedFeatureCS.Code_SurgicalClip);                                                      // CSBuilder.cs:387
		public TCoding Code_SurgicalClips = new TCoding(ObservedFeatureCS.Code_SurgicalClips);                                                    // CSBuilder.cs:387
		public TCoding Code_TrabecularThickening = new TCoding(ObservedFeatureCS.Code_TrabecularThickening);                                      // CSBuilder.cs:387
		                                                                                                                                          // CSBuilder.cs:342
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:343
		                                                                                                                                          // CSBuilder.cs:344
		public ObservedFeatureVS()                                                                                                                // CSBuilder.cs:345
		{                                                                                                                                         // CSBuilder.cs:346
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:347
		    this.Members.Add(ObservedFeatureCS.Code_AxillaryAdenopathy);                                                                          // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_BiopsyClip);                                                                                  // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_BiopsyClips);                                                                                 // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_BrachytherapyTube);                                                                           // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_ChestWallInvasion);                                                                           // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_CooperDistorted);                                                                             // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_CooperThickened);                                                                             // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_Edema);                                                                                       // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_EdemaAdj);                                                                                    // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_GoldSeed);                                                                                    // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_Hematoma);                                                                                    // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_NippleRetraction);                                                                            // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_NOChestWallInvasion);                                                                         // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_PectoralisMuscleInvasion);                                                                    // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_PectoralisMuscleInvolvement);                                                                 // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_PectoralisMuscleTenting);                                                                     // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_PostSurgicalScar);                                                                            // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_Seroma);                                                                                      // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_SkinInvolvement);                                                                             // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_SkinLesion);                                                                                  // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_SkinRetraction);                                                                              // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_SkinThickening);                                                                              // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_SurgicalClip);                                                                                // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_SurgicalClips);                                                                               // CSBuilder.cs:390
		    this.Members.Add(ObservedFeatureCS.Code_TrabecularThickening);                                                                        // CSBuilder.cs:390
		}                                                                                                                                         // CSBuilder.cs:349
		//- Fields
	}
}
