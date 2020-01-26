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
	public class ConsistentWithCodeSystemCS                                                                                                    // CSBuilder.cs:485
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/ConsistentWithCodeSystemCS";                                    // CSBuilder.cs:489
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Abscess
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Abscess = new Coding(System, "Abscess", "Abscess");                                                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Angiolipoma
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_Angiolipoma = new Coding(System, "Angiolipoma", "Angiolipoma");                                                 // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Apocrine metaplasia
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_ApocrineMetaplasia = new Coding(System, "ApocrineMetaplasia", "Apocrine metaplasia");                           // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Artifact
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_Artifact = new Coding(System, "Artifact", "Artifact");                                                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Atypical hyperplasia
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_AtypicalHyperplasia = new Coding(System, "AtypicalHyperplasia", "Atypical hyperplasia");                        // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Axillary lymph node
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_AxillaryLymphNode = new Coding(System, "AxillaryLymphNode", "Axillary lymph node");                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Carcinoma
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Carcinoma = new Coding(System, "Carcinoma", "Carcinoma");                                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Carcinoma known
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_CarcinomaKnown = new Coding(System, "CarcinomaKnown", "Carcinoma known");                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Cluster of cysts
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_ClusterOfCysts = new Coding(System, "ClusterOfCysts", "Cluster of cysts");                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Cyst
		/// Valid for the following modalities: MG MRI.
		/// </summary>
		public static Coding Code_Cyst = new Coding(System, "Cyst", "Cyst");                                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Cyst complex
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_CystComplex = new Coding(System, "CystComplex", "Cyst complex");                                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Cyst complicated
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_CystComplicated = new Coding(System, "CystComplicated", "Cyst complicated");                                    // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Cyst oil
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CystOil = new Coding(System, "CystOil", "Cyst oil");                                                            // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Cyst sebaceous
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_CystSebaceous = new Coding(System, "CystSebaceous", "Cyst sebaceous");                                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Cyst simple
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_CystSimple = new Coding(System, "CystSimple", "Cyst simple");                                                   // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Cysts complex
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_CystsComplex = new Coding(System, "CystsComplex", "Cysts complex");                                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Cysts complicated
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_CystsComplicated = new Coding(System, "CystsComplicated", "Cysts complicated");                                 // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Cysts micro clustered
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_CystsMicroClustered = new Coding(System, "CystsMicroClustered", "Cysts micro clustered");                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] DCIS
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_DCIS = new Coding(System, "DCIS", "DCIS");                                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Debris
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Debris = new Coding(System, "Debris", "Debris");                                                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Deodorant
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Deodorant = new Coding(System, "Deodorant", "Deodorant");                                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Dermal calcification
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_DermalCalcification = new Coding(System, "DermalCalcification", "Dermal calcification");                        // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Duct ectasia
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_DuctEctasia = new Coding(System, "DuctEctasia", "Duct ectasia");                                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Edema
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_Edema = new Coding(System, "Edema", "Edema");                                                                   // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Fat lobule
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_FatLobule = new Coding(System, "FatLobule", "Fat lobule");                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Fat necrosis
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_FatNecrosis = new Coding(System, "FatNecrosis", "Fat necrosis");                                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Fibroadenolipoma
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Fibroadenolipoma = new Coding(System, "Fibroadenolipoma", "Fibroadenolipoma");                                  // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Fibroadenoma
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Fibroadenoma = new Coding(System, "Fibroadenoma", "Fibroadenoma");                                              // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Fibroadenoma degenerating
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_FibroadenomaDegenerating = new Coding(System, "FibroadenomaDegenerating", "Fibroadenoma degenerating");         // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Fibrocystic change
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_FibrocysticChange = new Coding(System, "FibrocysticChange", "Fibrocystic change");                              // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Fibroglandular tissue
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_FibroglandularTissue = new Coding(System, "FibroglandularTissue", "Fibroglandular tissue");                     // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Fibrosis
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Fibrosis = new Coding(System, "Fibrosis", "Fibrosis");                                                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Fibrous ridge
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_FibrousRidge = new Coding(System, "FibrousRidge", "Fibrous ridge");                                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Folliculitis
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_Folliculitis = new Coding(System, "Folliculitis", "Folliculitis");                                              // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Gynecomastia
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_Gynecomastia = new Coding(System, "Gynecomastia", "Gynecomastia");                                              // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Hamartoma
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Hamartoma = new Coding(System, "Hamartoma", "Hamartoma");                                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Hematoma
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Hematoma = new Coding(System, "Hematoma", "Hematoma");                                                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Hormonal stimulation
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_HormonalStimulation = new Coding(System, "HormonalStimulation", "Hormonal stimulation");                        // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Intracystic lesion
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_IntracysticLesion = new Coding(System, "IntracysticLesion", "Intracystic lesion");                              // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Intramammary node
		/// Valid for the following modalities: MG NM.
		/// </summary>
		public static Coding Code_IntramammaryNode = new Coding(System, "IntramammaryNode", "Intramammary node");                                 // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Lipoma
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Lipoma = new Coding(System, "Lipoma", "Lipoma");                                                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Lumpectomy cavity
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_LumpectomyCavity = new Coding(System, "LumpectomyCavity", "Lumpectomy cavity");                                 // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Lumpectomy site
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_LumpectomySite = new Coding(System, "LumpectomySite", "Lumpectomy site");                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Lymph node
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_LymphNode = new Coding(System, "LymphNode", "Lymph node");                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Lymph node enlarged
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_LymphNodeEnlarged = new Coding(System, "LymphNodeEnlarged", "Lymph node enlarged");                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Lymph node normal
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_LymphNodeNormal = new Coding(System, "LymphNodeNormal", "Lymph node normal");                                   // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Lymph node pathological
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_LymphNodePathological = new Coding(System, "LymphNodePathological", "Lymph node pathological");                 // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Mass solid
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_MassSolid = new Coding(System, "MassSolid", "Mass solid");                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Mass solid w/tumor vasc
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_MassSolidWTumorVasc = new Coding(System, "MassSolidW/tumorVasc", "Mass solid w/tumor vasc");                    // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Mastitis
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Mastitis = new Coding(System, "Mastitis", "Mastitis");                                                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Milk of calcium
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MilkOfCalcium = new Coding(System, "MilkOfCalcium", "Milk of calcium");                                         // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Multi-focal cancer
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_MultiFocalCancer = new Coding(System, "Multi-focalCancer", "Multi-focal cancer");                               // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Papillary lesion
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_PapillaryLesion = new Coding(System, "PapillaryLesion", "Papillary lesion");                                    // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Papilloma
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Papilloma = new Coding(System, "Papilloma", "Papilloma");                                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Phyllodes tumor
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_PhyllodesTumor = new Coding(System, "PhyllodesTumor", "Phyllodes tumor");                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Post lumpectomy scar
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PostLumpectomyScar = new Coding(System, "PostLumpectomyScar", "Post lumpectomy scar");                          // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Post surgical scar
		/// Valid for the following modalities: MG NM.
		/// </summary>
		public static Coding Code_PostSurgicalScar = new Coding(System, "PostSurgicalScar", "Post surgical scar");                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Previous biopsy
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PreviousBiopsy = new Coding(System, "PreviousBiopsy", "Previous biopsy");                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Previous surgery
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PreviousSurgery = new Coding(System, "PreviousSurgery", "Previous surgery");                                    // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Previous trauma
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PreviousTrauma = new Coding(System, "PreviousTrauma", "Previous trauma");                                       // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Radial scar
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_RadialScar = new Coding(System, "RadialScar", "Radial scar");                                                   // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Radiation changes
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_RadiationChanges = new Coding(System, "RadiationChanges", "Radiation changes");                                 // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Radiation therapy
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_RadiationTherapy = new Coding(System, "RadiationTherapy", "Radiation therapy");                                 // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Scar
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_Scar = new Coding(System, "Scar", "Scar");                                                                      // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Scar with shadowing
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_ScarWithShadowing = new Coding(System, "ScarWithShadowing", "Scar with shadowing");                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Sclerosing adenosis
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SclerosingAdenosis = new Coding(System, "SclerosingAdenosis", "Sclerosing adenosis");                           // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Secretory calcification
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SecretoryCalcification = new Coding(System, "SecretoryCalcification", "Secretory calcification");               // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Sentinel node
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_SentinelNode = new Coding(System, "SentinelNode", "Sentinel node");                                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Seroma
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Seroma = new Coding(System, "Seroma", "Seroma");                                                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Skin lesion
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SkinLesion = new Coding(System, "SkinLesion", "Skin lesion");                                                   // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Surgery
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_Surgery = new Coding(System, "Surgery", "Surgery");                                                             // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Trauma
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_Trauma = new Coding(System, "Trauma", "Trauma");                                                                // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Vascular calcifications
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_VascularCalcifications = new Coding(System, "VascularCalcifications", "Vascular calcifications");               // CSBuilder.cs:515
		                                                                                                                                          // CSBuilder.cs:501
		/// <summary>
		/// [PR] Venous stasis
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_VenousStasis = new Coding(System, "VenousStasis", "Venous stasis");                                             // CSBuilder.cs:515
		//- Fields
	}
}
