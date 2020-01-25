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
	public class ConsistentWithVS                                                                                                              // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public ConsistentWithVS()                                                                                                                 // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Abscess);                                                                            // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Angiolipoma);                                                                        // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_ApocrineMetaplasia);                                                                 // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Artifact);                                                                           // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_AtypicalHyperplasia);                                                                // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_AxillaryLymphNode);                                                                  // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Carcinoma);                                                                          // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_CarcinomaKnown);                                                                     // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_ClusterOfCysts);                                                                     // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Cyst);                                                                               // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_CystComplex);                                                                        // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_CystComplicated);                                                                    // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_CystOil);                                                                            // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_CystSebaceous);                                                                      // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_CystSimple);                                                                         // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_CystsComplex);                                                                       // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_CystsComplicated);                                                                   // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_CystsMicroClustered);                                                                // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_DCIS);                                                                               // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Debris);                                                                             // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Deodorant);                                                                          // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_DermalCalcification);                                                                // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_DuctEctasia);                                                                        // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Edema);                                                                              // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_FatLobule);                                                                          // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_FatNecrosis);                                                                        // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Fibroadenolipoma);                                                                   // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Fibroadenoma);                                                                       // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_FibroadenomaDegenerating);                                                           // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_FibrocysticChange);                                                                  // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_FibroglandularTissue);                                                               // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Fibrosis);                                                                           // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_FibrousRidge);                                                                       // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Folliculitis);                                                                       // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Gynecomastia);                                                                       // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Hamartoma);                                                                          // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Hematoma);                                                                           // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_HormonalStimulation);                                                                // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_IntracysticLesion);                                                                  // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_IntramammaryNode);                                                                   // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Lipoma);                                                                             // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_LumpectomyCavity);                                                                   // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_LumpectomySite);                                                                     // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_LymphNode);                                                                          // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_LymphNodeEnlarged);                                                                  // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_LymphNodeNormal);                                                                    // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_LymphNodePathological);                                                              // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_MassSolid);                                                                          // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_MassSolidWTumorVasc);                                                                // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Mastitis);                                                                           // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_MilkOfCalcium);                                                                      // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_MultiFocalCancer);                                                                   // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_PapillaryLesion);                                                                    // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Papilloma);                                                                          // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_PhyllodesTumor);                                                                     // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_PostLumpectomyScar);                                                                 // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_PostSurgicalScar);                                                                   // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_PreviousBiopsy);                                                                     // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_PreviousSurgery);                                                                    // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_PreviousTrauma);                                                                     // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_RadialScar);                                                                         // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_RadiationChanges);                                                                   // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_RadiationTherapy);                                                                   // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Scar);                                                                               // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_ScarWithShadowing);                                                                  // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_SclerosingAdenosis);                                                                 // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_SecretoryCalcification);                                                             // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_SentinelNode);                                                                       // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Seroma);                                                                             // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_SkinLesion);                                                                         // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Surgery);                                                                            // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_Trauma);                                                                             // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_VascularCalcifications);                                                             // CSBuilder.cs:362
		    this.Members.Add(ConsistentWithCodeSystemCS.Code_VenousStasis);                                                                       // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
