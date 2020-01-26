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
	public class ConsistentWithVS                                                                                                              // CSBuilder.cs:361
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
		public TCoding Code_Abscess = new TCoding(ConsistentWithCodeSystemCS.Code_Abscess);                                                       // CSBuilder.cs:412
		public TCoding Code_Angiolipoma = new TCoding(ConsistentWithCodeSystemCS.Code_Angiolipoma);                                               // CSBuilder.cs:412
		public TCoding Code_ApocrineMetaplasia = new TCoding(ConsistentWithCodeSystemCS.Code_ApocrineMetaplasia);                                 // CSBuilder.cs:412
		public TCoding Code_Artifact = new TCoding(ConsistentWithCodeSystemCS.Code_Artifact);                                                     // CSBuilder.cs:412
		public TCoding Code_AtypicalHyperplasia = new TCoding(ConsistentWithCodeSystemCS.Code_AtypicalHyperplasia);                               // CSBuilder.cs:412
		public TCoding Code_AxillaryLymphNode = new TCoding(ConsistentWithCodeSystemCS.Code_AxillaryLymphNode);                                   // CSBuilder.cs:412
		public TCoding Code_Carcinoma = new TCoding(ConsistentWithCodeSystemCS.Code_Carcinoma);                                                   // CSBuilder.cs:412
		public TCoding Code_CarcinomaKnown = new TCoding(ConsistentWithCodeSystemCS.Code_CarcinomaKnown);                                         // CSBuilder.cs:412
		public TCoding Code_ClusterOfCysts = new TCoding(ConsistentWithCodeSystemCS.Code_ClusterOfCysts);                                         // CSBuilder.cs:412
		public TCoding Code_Cyst = new TCoding(ConsistentWithCodeSystemCS.Code_Cyst);                                                             // CSBuilder.cs:412
		public TCoding Code_CystComplex = new TCoding(ConsistentWithCodeSystemCS.Code_CystComplex);                                               // CSBuilder.cs:412
		public TCoding Code_CystComplicated = new TCoding(ConsistentWithCodeSystemCS.Code_CystComplicated);                                       // CSBuilder.cs:412
		public TCoding Code_CystOil = new TCoding(ConsistentWithCodeSystemCS.Code_CystOil);                                                       // CSBuilder.cs:412
		public TCoding Code_CystSebaceous = new TCoding(ConsistentWithCodeSystemCS.Code_CystSebaceous);                                           // CSBuilder.cs:412
		public TCoding Code_CystSimple = new TCoding(ConsistentWithCodeSystemCS.Code_CystSimple);                                                 // CSBuilder.cs:412
		public TCoding Code_CystsComplex = new TCoding(ConsistentWithCodeSystemCS.Code_CystsComplex);                                             // CSBuilder.cs:412
		public TCoding Code_CystsComplicated = new TCoding(ConsistentWithCodeSystemCS.Code_CystsComplicated);                                     // CSBuilder.cs:412
		public TCoding Code_CystsMicroClustered = new TCoding(ConsistentWithCodeSystemCS.Code_CystsMicroClustered);                               // CSBuilder.cs:412
		public TCoding Code_DCIS = new TCoding(ConsistentWithCodeSystemCS.Code_DCIS);                                                             // CSBuilder.cs:412
		public TCoding Code_Debris = new TCoding(ConsistentWithCodeSystemCS.Code_Debris);                                                         // CSBuilder.cs:412
		public TCoding Code_Deodorant = new TCoding(ConsistentWithCodeSystemCS.Code_Deodorant);                                                   // CSBuilder.cs:412
		public TCoding Code_DermalCalcification = new TCoding(ConsistentWithCodeSystemCS.Code_DermalCalcification);                               // CSBuilder.cs:412
		public TCoding Code_DuctEctasia = new TCoding(ConsistentWithCodeSystemCS.Code_DuctEctasia);                                               // CSBuilder.cs:412
		public TCoding Code_Edema = new TCoding(ConsistentWithCodeSystemCS.Code_Edema);                                                           // CSBuilder.cs:412
		public TCoding Code_FatLobule = new TCoding(ConsistentWithCodeSystemCS.Code_FatLobule);                                                   // CSBuilder.cs:412
		public TCoding Code_FatNecrosis = new TCoding(ConsistentWithCodeSystemCS.Code_FatNecrosis);                                               // CSBuilder.cs:412
		public TCoding Code_Fibroadenolipoma = new TCoding(ConsistentWithCodeSystemCS.Code_Fibroadenolipoma);                                     // CSBuilder.cs:412
		public TCoding Code_Fibroadenoma = new TCoding(ConsistentWithCodeSystemCS.Code_Fibroadenoma);                                             // CSBuilder.cs:412
		public TCoding Code_FibroadenomaDegenerating = new TCoding(ConsistentWithCodeSystemCS.Code_FibroadenomaDegenerating);                     // CSBuilder.cs:412
		public TCoding Code_FibrocysticChange = new TCoding(ConsistentWithCodeSystemCS.Code_FibrocysticChange);                                   // CSBuilder.cs:412
		public TCoding Code_FibroglandularTissue = new TCoding(ConsistentWithCodeSystemCS.Code_FibroglandularTissue);                             // CSBuilder.cs:412
		public TCoding Code_Fibrosis = new TCoding(ConsistentWithCodeSystemCS.Code_Fibrosis);                                                     // CSBuilder.cs:412
		public TCoding Code_FibrousRidge = new TCoding(ConsistentWithCodeSystemCS.Code_FibrousRidge);                                             // CSBuilder.cs:412
		public TCoding Code_Folliculitis = new TCoding(ConsistentWithCodeSystemCS.Code_Folliculitis);                                             // CSBuilder.cs:412
		public TCoding Code_Gynecomastia = new TCoding(ConsistentWithCodeSystemCS.Code_Gynecomastia);                                             // CSBuilder.cs:412
		public TCoding Code_Hamartoma = new TCoding(ConsistentWithCodeSystemCS.Code_Hamartoma);                                                   // CSBuilder.cs:412
		public TCoding Code_Hematoma = new TCoding(ConsistentWithCodeSystemCS.Code_Hematoma);                                                     // CSBuilder.cs:412
		public TCoding Code_HormonalStimulation = new TCoding(ConsistentWithCodeSystemCS.Code_HormonalStimulation);                               // CSBuilder.cs:412
		public TCoding Code_IntracysticLesion = new TCoding(ConsistentWithCodeSystemCS.Code_IntracysticLesion);                                   // CSBuilder.cs:412
		public TCoding Code_IntramammaryNode = new TCoding(ConsistentWithCodeSystemCS.Code_IntramammaryNode);                                     // CSBuilder.cs:412
		public TCoding Code_Lipoma = new TCoding(ConsistentWithCodeSystemCS.Code_Lipoma);                                                         // CSBuilder.cs:412
		public TCoding Code_LumpectomyCavity = new TCoding(ConsistentWithCodeSystemCS.Code_LumpectomyCavity);                                     // CSBuilder.cs:412
		public TCoding Code_LumpectomySite = new TCoding(ConsistentWithCodeSystemCS.Code_LumpectomySite);                                         // CSBuilder.cs:412
		public TCoding Code_LymphNode = new TCoding(ConsistentWithCodeSystemCS.Code_LymphNode);                                                   // CSBuilder.cs:412
		public TCoding Code_LymphNodeEnlarged = new TCoding(ConsistentWithCodeSystemCS.Code_LymphNodeEnlarged);                                   // CSBuilder.cs:412
		public TCoding Code_LymphNodeNormal = new TCoding(ConsistentWithCodeSystemCS.Code_LymphNodeNormal);                                       // CSBuilder.cs:412
		public TCoding Code_LymphNodePathological = new TCoding(ConsistentWithCodeSystemCS.Code_LymphNodePathological);                           // CSBuilder.cs:412
		public TCoding Code_MassSolid = new TCoding(ConsistentWithCodeSystemCS.Code_MassSolid);                                                   // CSBuilder.cs:412
		public TCoding Code_MassSolidWTumorVasc = new TCoding(ConsistentWithCodeSystemCS.Code_MassSolidWTumorVasc);                               // CSBuilder.cs:412
		public TCoding Code_Mastitis = new TCoding(ConsistentWithCodeSystemCS.Code_Mastitis);                                                     // CSBuilder.cs:412
		public TCoding Code_MilkOfCalcium = new TCoding(ConsistentWithCodeSystemCS.Code_MilkOfCalcium);                                           // CSBuilder.cs:412
		public TCoding Code_MultiFocalCancer = new TCoding(ConsistentWithCodeSystemCS.Code_MultiFocalCancer);                                     // CSBuilder.cs:412
		public TCoding Code_PapillaryLesion = new TCoding(ConsistentWithCodeSystemCS.Code_PapillaryLesion);                                       // CSBuilder.cs:412
		public TCoding Code_Papilloma = new TCoding(ConsistentWithCodeSystemCS.Code_Papilloma);                                                   // CSBuilder.cs:412
		public TCoding Code_PhyllodesTumor = new TCoding(ConsistentWithCodeSystemCS.Code_PhyllodesTumor);                                         // CSBuilder.cs:412
		public TCoding Code_PostLumpectomyScar = new TCoding(ConsistentWithCodeSystemCS.Code_PostLumpectomyScar);                                 // CSBuilder.cs:412
		public TCoding Code_PostSurgicalScar = new TCoding(ConsistentWithCodeSystemCS.Code_PostSurgicalScar);                                     // CSBuilder.cs:412
		public TCoding Code_PreviousBiopsy = new TCoding(ConsistentWithCodeSystemCS.Code_PreviousBiopsy);                                         // CSBuilder.cs:412
		public TCoding Code_PreviousSurgery = new TCoding(ConsistentWithCodeSystemCS.Code_PreviousSurgery);                                       // CSBuilder.cs:412
		public TCoding Code_PreviousTrauma = new TCoding(ConsistentWithCodeSystemCS.Code_PreviousTrauma);                                         // CSBuilder.cs:412
		public TCoding Code_RadialScar = new TCoding(ConsistentWithCodeSystemCS.Code_RadialScar);                                                 // CSBuilder.cs:412
		public TCoding Code_RadiationChanges = new TCoding(ConsistentWithCodeSystemCS.Code_RadiationChanges);                                     // CSBuilder.cs:412
		public TCoding Code_RadiationTherapy = new TCoding(ConsistentWithCodeSystemCS.Code_RadiationTherapy);                                     // CSBuilder.cs:412
		public TCoding Code_Scar = new TCoding(ConsistentWithCodeSystemCS.Code_Scar);                                                             // CSBuilder.cs:412
		public TCoding Code_ScarWithShadowing = new TCoding(ConsistentWithCodeSystemCS.Code_ScarWithShadowing);                                   // CSBuilder.cs:412
		public TCoding Code_SclerosingAdenosis = new TCoding(ConsistentWithCodeSystemCS.Code_SclerosingAdenosis);                                 // CSBuilder.cs:412
		public TCoding Code_SecretoryCalcification = new TCoding(ConsistentWithCodeSystemCS.Code_SecretoryCalcification);                         // CSBuilder.cs:412
		public TCoding Code_SentinelNode = new TCoding(ConsistentWithCodeSystemCS.Code_SentinelNode);                                             // CSBuilder.cs:412
		public TCoding Code_Seroma = new TCoding(ConsistentWithCodeSystemCS.Code_Seroma);                                                         // CSBuilder.cs:412
		public TCoding Code_SkinLesion = new TCoding(ConsistentWithCodeSystemCS.Code_SkinLesion);                                                 // CSBuilder.cs:412
		public TCoding Code_Surgery = new TCoding(ConsistentWithCodeSystemCS.Code_Surgery);                                                       // CSBuilder.cs:412
		public TCoding Code_Trauma = new TCoding(ConsistentWithCodeSystemCS.Code_Trauma);                                                         // CSBuilder.cs:412
		public TCoding Code_VascularCalcifications = new TCoding(ConsistentWithCodeSystemCS.Code_VascularCalcifications);                         // CSBuilder.cs:412
		public TCoding Code_VenousStasis = new TCoding(ConsistentWithCodeSystemCS.Code_VenousStasis);                                             // CSBuilder.cs:412
		                                                                                                                                          // CSBuilder.cs:367
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:368
		                                                                                                                                          // CSBuilder.cs:369
		public ConsistentWithVS()                                                                                                                 // CSBuilder.cs:370
		{                                                                                                                                         // CSBuilder.cs:371
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:372
		    this.Members.Add(this.Code_Abscess);                                                                                                  // CSBuilder.cs:415
		    this.Members.Add(this.Code_Angiolipoma);                                                                                              // CSBuilder.cs:415
		    this.Members.Add(this.Code_ApocrineMetaplasia);                                                                                       // CSBuilder.cs:415
		    this.Members.Add(this.Code_Artifact);                                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_AtypicalHyperplasia);                                                                                      // CSBuilder.cs:415
		    this.Members.Add(this.Code_AxillaryLymphNode);                                                                                        // CSBuilder.cs:415
		    this.Members.Add(this.Code_Carcinoma);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_CarcinomaKnown);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_ClusterOfCysts);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_Cyst);                                                                                                     // CSBuilder.cs:415
		    this.Members.Add(this.Code_CystComplex);                                                                                              // CSBuilder.cs:415
		    this.Members.Add(this.Code_CystComplicated);                                                                                          // CSBuilder.cs:415
		    this.Members.Add(this.Code_CystOil);                                                                                                  // CSBuilder.cs:415
		    this.Members.Add(this.Code_CystSebaceous);                                                                                            // CSBuilder.cs:415
		    this.Members.Add(this.Code_CystSimple);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_CystsComplex);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_CystsComplicated);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_CystsMicroClustered);                                                                                      // CSBuilder.cs:415
		    this.Members.Add(this.Code_DCIS);                                                                                                     // CSBuilder.cs:415
		    this.Members.Add(this.Code_Debris);                                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_Deodorant);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_DermalCalcification);                                                                                      // CSBuilder.cs:415
		    this.Members.Add(this.Code_DuctEctasia);                                                                                              // CSBuilder.cs:415
		    this.Members.Add(this.Code_Edema);                                                                                                    // CSBuilder.cs:415
		    this.Members.Add(this.Code_FatLobule);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_FatNecrosis);                                                                                              // CSBuilder.cs:415
		    this.Members.Add(this.Code_Fibroadenolipoma);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_Fibroadenoma);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_FibroadenomaDegenerating);                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_FibrocysticChange);                                                                                        // CSBuilder.cs:415
		    this.Members.Add(this.Code_FibroglandularTissue);                                                                                     // CSBuilder.cs:415
		    this.Members.Add(this.Code_Fibrosis);                                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_FibrousRidge);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_Folliculitis);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_Gynecomastia);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_Hamartoma);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_Hematoma);                                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_HormonalStimulation);                                                                                      // CSBuilder.cs:415
		    this.Members.Add(this.Code_IntracysticLesion);                                                                                        // CSBuilder.cs:415
		    this.Members.Add(this.Code_IntramammaryNode);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_Lipoma);                                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_LumpectomyCavity);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_LumpectomySite);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_LymphNode);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_LymphNodeEnlarged);                                                                                        // CSBuilder.cs:415
		    this.Members.Add(this.Code_LymphNodeNormal);                                                                                          // CSBuilder.cs:415
		    this.Members.Add(this.Code_LymphNodePathological);                                                                                    // CSBuilder.cs:415
		    this.Members.Add(this.Code_MassSolid);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_MassSolidWTumorVasc);                                                                                      // CSBuilder.cs:415
		    this.Members.Add(this.Code_Mastitis);                                                                                                 // CSBuilder.cs:415
		    this.Members.Add(this.Code_MilkOfCalcium);                                                                                            // CSBuilder.cs:415
		    this.Members.Add(this.Code_MultiFocalCancer);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_PapillaryLesion);                                                                                          // CSBuilder.cs:415
		    this.Members.Add(this.Code_Papilloma);                                                                                                // CSBuilder.cs:415
		    this.Members.Add(this.Code_PhyllodesTumor);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_PostLumpectomyScar);                                                                                       // CSBuilder.cs:415
		    this.Members.Add(this.Code_PostSurgicalScar);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_PreviousBiopsy);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_PreviousSurgery);                                                                                          // CSBuilder.cs:415
		    this.Members.Add(this.Code_PreviousTrauma);                                                                                           // CSBuilder.cs:415
		    this.Members.Add(this.Code_RadialScar);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_RadiationChanges);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_RadiationTherapy);                                                                                         // CSBuilder.cs:415
		    this.Members.Add(this.Code_Scar);                                                                                                     // CSBuilder.cs:415
		    this.Members.Add(this.Code_ScarWithShadowing);                                                                                        // CSBuilder.cs:415
		    this.Members.Add(this.Code_SclerosingAdenosis);                                                                                       // CSBuilder.cs:415
		    this.Members.Add(this.Code_SecretoryCalcification);                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_SentinelNode);                                                                                             // CSBuilder.cs:415
		    this.Members.Add(this.Code_Seroma);                                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_SkinLesion);                                                                                               // CSBuilder.cs:415
		    this.Members.Add(this.Code_Surgery);                                                                                                  // CSBuilder.cs:415
		    this.Members.Add(this.Code_Trauma);                                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_VascularCalcifications);                                                                                   // CSBuilder.cs:415
		    this.Members.Add(this.Code_VenousStasis);                                                                                             // CSBuilder.cs:415
		}                                                                                                                                         // CSBuilder.cs:374
		//- Fields
	}
}
