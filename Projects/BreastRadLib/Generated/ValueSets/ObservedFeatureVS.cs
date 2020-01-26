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
	public class ObservedFeatureVS                                                                                                             // CSBuilder.cs:361
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:382
		{                                                                                                                                         // CSBuilder.cs:383
		    Coding value;                                                                                                                         // CSBuilder.cs:384
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:385
		    {                                                                                                                                     // CSBuilder.cs:386
		        return tCode.value;                                                                                                               // CSBuilder.cs:387
		    }                                                                                                                                     // CSBuilder.cs:388
		                                                                                                                                          // CSBuilder.cs:389
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:390
		    {                                                                                                                                     // CSBuilder.cs:391
		        this.value= value;                                                                                                                // CSBuilder.cs:392
		    }                                                                                                                                     // CSBuilder.cs:393
		}                                                                                                                                         // CSBuilder.cs:394
		public TCoding Code_AxillaryAdenopathy = new TCoding(ObservedFeatureCS.Code_AxillaryAdenopathy);                                          // CSBuilder.cs:412
		public TCoding Code_BiopsyClip = new TCoding(ObservedFeatureCS.Code_BiopsyClip);                                                          // CSBuilder.cs:412
		public TCoding Code_BiopsyClips = new TCoding(ObservedFeatureCS.Code_BiopsyClips);                                                        // CSBuilder.cs:412
		public TCoding Code_BrachytherapyTube = new TCoding(ObservedFeatureCS.Code_BrachytherapyTube);                                            // CSBuilder.cs:412
		public TCoding Code_ChestWallInvasion = new TCoding(ObservedFeatureCS.Code_ChestWallInvasion);                                            // CSBuilder.cs:412
		public TCoding Code_CooperDistorted = new TCoding(ObservedFeatureCS.Code_CooperDistorted);                                                // CSBuilder.cs:412
		public TCoding Code_CooperThickened = new TCoding(ObservedFeatureCS.Code_CooperThickened);                                                // CSBuilder.cs:412
		public TCoding Code_Edema = new TCoding(ObservedFeatureCS.Code_Edema);                                                                    // CSBuilder.cs:412
		public TCoding Code_EdemaAdj = new TCoding(ObservedFeatureCS.Code_EdemaAdj);                                                              // CSBuilder.cs:412
		public TCoding Code_GoldSeed = new TCoding(ObservedFeatureCS.Code_GoldSeed);                                                              // CSBuilder.cs:412
		public TCoding Code_Hematoma = new TCoding(ObservedFeatureCS.Code_Hematoma);                                                              // CSBuilder.cs:412
		public TCoding Code_NippleRetraction = new TCoding(ObservedFeatureCS.Code_NippleRetraction);                                              // CSBuilder.cs:412
		public TCoding Code_NOChestWallInvasion = new TCoding(ObservedFeatureCS.Code_NOChestWallInvasion);                                        // CSBuilder.cs:412
		public TCoding Code_PectoralisMuscleInvasion = new TCoding(ObservedFeatureCS.Code_PectoralisMuscleInvasion);                              // CSBuilder.cs:412
		public TCoding Code_PectoralisMuscleInvolvement = new TCoding(ObservedFeatureCS.Code_PectoralisMuscleInvolvement);                        // CSBuilder.cs:412
		public TCoding Code_PectoralisMuscleTenting = new TCoding(ObservedFeatureCS.Code_PectoralisMuscleTenting);                                // CSBuilder.cs:412
		public TCoding Code_PostSurgicalScar = new TCoding(ObservedFeatureCS.Code_PostSurgicalScar);                                              // CSBuilder.cs:412
		public TCoding Code_Seroma = new TCoding(ObservedFeatureCS.Code_Seroma);                                                                  // CSBuilder.cs:412
		public TCoding Code_SkinInvolvement = new TCoding(ObservedFeatureCS.Code_SkinInvolvement);                                                // CSBuilder.cs:412
		public TCoding Code_SkinLesion = new TCoding(ObservedFeatureCS.Code_SkinLesion);                                                          // CSBuilder.cs:412
		public TCoding Code_SkinRetraction = new TCoding(ObservedFeatureCS.Code_SkinRetraction);                                                  // CSBuilder.cs:412
		public TCoding Code_SkinThickening = new TCoding(ObservedFeatureCS.Code_SkinThickening);                                                  // CSBuilder.cs:412
		public TCoding Code_SurgicalClip = new TCoding(ObservedFeatureCS.Code_SurgicalClip);                                                      // CSBuilder.cs:412
		public TCoding Code_SurgicalClips = new TCoding(ObservedFeatureCS.Code_SurgicalClips);                                                    // CSBuilder.cs:412
		public TCoding Code_TrabecularThickening = new TCoding(ObservedFeatureCS.Code_TrabecularThickening);                                      // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:367
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:368
		                                                                                                                                          // CSBuilder.cs:369
		public ObservedFeatureVS()                                                                                                                // CSBuilder.cs:370
		{                                                                                                                                         // CSBuilder.cs:371
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:372
		    this.Members.Add(this.Code_AxillaryAdenopathy);                                                                                       // CSBuilder.cs:415
		    this.Members.Add(this.Code_BiopsyClip);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_BiopsyClips);                                                                                              // CSBuilder.cs:415
		    this.Members.Add(this.Code_BrachytherapyTube);                                                                                        // CSBuilder.cs:415
		    this.Members.Add(this.Code_ChestWallInvasion);                                                                                        // CSBuilder.cs:415
		    this.Members.Add(this.Code_CooperDistorted);                                                                                          // CSBuilder.cs:415
		    this.Members.Add(this.Code_CooperThickened);                                                                                          // CSBuilder.cs:415
		    this.Members.Add(this.Code_Edema);                                                                                                    // CSBuilder.cs:415
		    this.Members.Add(this.Code_EdemaAdj);                                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_GoldSeed);                                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_Hematoma);                                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_NippleRetraction);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_NOChestWallInvasion);                                                                                      // CSBuilder.cs:415
		    this.Members.Add(this.Code_PectoralisMuscleInvasion);                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_PectoralisMuscleInvolvement);                                                                              // CSBuilder.cs:415
		    this.Members.Add(this.Code_PectoralisMuscleTenting);                                                                                  // CSBuilder.cs:415
		    this.Members.Add(this.Code_PostSurgicalScar);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_Seroma);                                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_SkinInvolvement);                                                                                          // CSBuilder.cs:415
		    this.Members.Add(this.Code_SkinLesion);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_SkinRetraction);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_SkinThickening);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_SurgicalClip);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_SurgicalClips);                                                                                            // CSBuilder.cs:415
		    this.Members.Add(this.Code_TrabecularThickening);                                                                                     // CSBuilder.cs:415
		}                                                                                                                                         // CSBuilder.cs:374
		//- Fields
	}
}
