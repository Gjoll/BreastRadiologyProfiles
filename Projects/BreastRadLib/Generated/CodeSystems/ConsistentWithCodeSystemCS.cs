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
	public class ConsistentWithCodeSystemCS                                                                                                    // CSBuilder.cs:403
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/ConsistentWithCodeSystemCS";                                    // CSBuilder.cs:407
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// An area within the body tissue that is swollen and contains an accumulation of pus.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Abscess = new Coding(System, "Abscess", "Abscess");                                                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Angiolipoma is a rare type of lipoma - a growth made of fat and blood vessels that develops under your skin.
		/// Unlike other types of lipomas, angiolipomas are often painful or tender.
		/// -- https://www.healthline.com/health/angiolipoma
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_Angiolipoma = new Coding(System, "Angiolipoma", "Angiolipoma");                                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A benign condition; Apocrine Metaplasia refers to a particular type of cell change.
		/// This is a type of 'umbrella term' that relates to a variety of cystic breast disorders.
		/// The epithelial cells are undergoing an unexpected change.These breast changes may show on a mammogram and biopsy as a mass or benign lesion, or possibly even develop into a palpable mass.###URL#https://breast-cancer.ca/apo-meta/
		/// 
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_ApocrineMetaplasia = new Coding(System, "ApocrineMetaplasia", "Apocrine metaplasia");                           // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// X-ray artifacts can present in a variety of ways including abnormal shadows noted on a radiograph or degraded image quality, and have been produced by artificial means from hardware failure, operator error and software (post-processing) artifacts.
		/// There are common and distinct artifacts for film, computed (CR) and digital radiography (DR).
		/// Common causes are improper handling of the filmserrors while processing the filmspatient movement while taking the image.
		/// -- https://radiopaedia.org/articles/x-ray-artifacts?lang=us
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_Artifact = new Coding(System, "Artifact", "Artifact");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Atypical hyperplasia is a precancerous condition that affects cells in the breast.
		/// Atypical hyperplasia describes an accumulation of abnormal cells in the breast.Atypical hyperplasia isn't cancer, but it can be a forerunner to the development of breast cancer.
		/// Over the course of your lifetime, if the atypical hyperplasia cells keep dividing and become more abnormal, this can transition into noninvasive breast cancer (carcinoma in situ) or invasive breast cancer.
		/// -- https://www.mayoclinic.org/diseases-conditions/atypical-hyperplasia/symptoms-causes/syc-20369773
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_AtypicalHyperplasia = new Coding(System, "AtypicalHyperplasia", "Atypical hyperplasia");                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Axillary lymph nodes are the lymph nodes located in the armpits.
		/// They can become enlarged in many conditions including infections, lymphomas, and breast cancers.
		/// Lymph nodes are small structures located all over the body around blood vessels that act as filters and can accumulate germs or cancer cells.
		/// They are a part of the lymph system of the body.
		/// -- https://www.verywellhealth.com/axillary-lymph-nodes-2252131
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_AxillaryLymphNode = new Coding(System, "AxillaryLymphNode", "Axillary lymph node");                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Carcinoma is a type of cancer that starts in cells that make up the skin or the tissue lining organs.
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Carcinoma = new Coding(System, "Carcinoma", "Carcinoma");                                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Imaging tests used in diagnosing cancer may include a computerized tomography (CT) scan, bone scan, magnetic resonance imaging (MRI), (PET) scan, ultrasound and X-ray, among others.
		/// In most cases, a biopsy is the only way to definitively diagnose cancer.
		/// Most breast cancers are carcinomas, which are tumors that start in the epithelial cells that line organs and tissues throughout the body.
		/// When carcinomas form in the breast, they are usually a more specific type called adenocarcinoma, which starts in cells in the ducts (the milk ducts) or the lobules (milk-producing glands).
		/// www.mayoclinic.org > cancer > diagnosis-treatment > drc-20370594
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_CarcinomaKnown = new Coding(System, "CarcinomaKnown", "Carcinoma known");                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A breast cyst is a non-cancerous (benign) fluid-filled sac in the breast.
		/// Some cysts are too small to feel and others may be large and uncomfortable.
		/// Sometimes there are clusters of cysts in one breast or both.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_ClusterOfCysts = new Coding(System, "ClusterOfCysts", "Cluster of cysts");                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A breast cyst is a non-cancerous (benign) fluid-filled sac in the breast.
		/// Some cysts are too small to feel and others may be large and uncomfortable.
		/// Sometimes there are clusters of cysts in one breast or both.
		/// 
		/// Valid for the following modalities: MG MRI.
		/// </summary>
		public static Coding Code_Cyst = new Coding(System, "Cyst", "Cyst");                                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Complex cysts have irregular or scalloped borders, thick walls, and some evidence of solid areas and/or debris in the fluid.
		/// These solid areas echo back the sound waves from the ultrasound.
		/// A complex cyst is sometimes aspirated, or drained with a fine needle, so that the fluid inside can be tested.
		/// If blood or any unusual cells are present, further testing may be needed to rule out breast cancer.
		/// -- https://www.breastcancer.org/symptoms/benign/cysts
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_CystComplex = new Coding(System, "CystComplex", "Cyst complex");                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Complicated cysts are "in between" simple and complex.
		/// Although they share most of the features of simple cysts, they tend to have some debris inside them and echo back some of the ultrasound waves.
		/// However, they don't have the thick walls or obvious solid components that a complex cyst has.
		/// -- https://www.breastcancer.org/symptoms/benign/cysts
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_CystComplicated = new Coding(System, "CystComplicated", "Cyst complicated");                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Oil cysts are filled with fluid that may feel smooth and squishy.
		/// They are caused by the breakdown of fatty tissue.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CystOil = new Coding(System, "CystOil", "Cyst oil");                                                            // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Sebaceous cysts are common noncancerous cysts of the skin.
		/// Cysts are abnormalities in the body that may contain liquid or semiliquid material.
		/// Sebaceous cysts are mostly found on the face, neck, or torso.
		/// They grow slowly and aren't life-threatening, but they may become uncomfortable if they go unchecked.
		/// www.healthline.com > health > sebaceous-cyst
		/// 
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_CystSebaceous = new Coding(System, "CystSebaceous", "Cyst sebaceous");                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Simple cysts have smooth, thin, regularly shaped walls and are completely filled with fluid.
		/// The sound waves sent out by the ultrasound test pass right through them, indicating there are no solid areas.
		/// Simple cysts are always benign.
		/// -- https://www.breastcancer.org/symptoms/benign/cysts
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_CystSimple = new Coding(System, "CystSimple", "Cyst simple");                                                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Complex cysts have irregular or scalloped borders, thick walls, and some evidence of solid areas and/or debris in the fluid.
		/// These solid areas echo back the sound waves from the ultrasound.
		/// A complex cyst is sometimes aspirated, or drained with a fine needle, so that the fluid inside can be tested.
		/// If blood or any unusual cells are present, further testing may be needed to rule out breast cancer.
		/// -- https://www.breastcancer.org/symptoms/benign/cysts
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_CystsComplex = new Coding(System, "CystsComplex", "Cysts complex");                                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Complicated cysts are "in between" simple and complex.
		/// Although they share most of the features of simple cysts, they tend to have some debris inside them and echo back some of the ultrasound waves.
		/// However, they don't have the thick walls or obvious solid components that a complex cyst has.
		/// -- https://www.breastcancer.org/symptoms/benign/cysts
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_CystsComplicated = new Coding(System, "CystsComplicated", "Cysts complicated");                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Microcysts are tiny, microscopic cysts.
		/// Clustered microcysts are a cluster of these tiny cysts and they only have fluid inside of them.
		/// 
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_CystsMicroClustered = new Coding(System, "CystsMicroClustered", "Cysts micro clustered");                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Ductal carcinoma in situ (DCIS) is the presence of abnormal cells inside a milk duct in the breast.
		/// DCIS is considered the earliest form of breast cancer.
		/// DCIS is noninvasive, meaning it hasn't spread out of the milk duct and has a low risk of becoming invasive.
		/// -- https://www.mayoclinic.org/diseases-conditions/dcis/symptoms-causes/syc-20371889
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_DCIS = new Coding(System, "DCIS", "DCIS");                                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Debris is a substance that is anything other than a liquid inside of the cyst.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Debris = new Coding(System, "Debris", "Debris");                                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Because estrogen can promote the growth of breast cancer cells, some scientists have suggested that the aluminum-based compounds in antiperspirants may contribute to the development of breast cancer.
		/// In addition, it has been suggested that aluminum may have direct activity in breast tissue.###URL#https://www.cancer.gov/about-cancer/causes-prevention/risk/myths/antiperspirants-fact-sheet
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_Deodorant = new Coding(System, "Deodorant", "Deodorant");                                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Skin calcifications in the breast usually form in dermal sweat glands after low grade folliculitis and inspissation of sebaceous material.
		/// Calcifications may also form in moles and other skin lesions.
		/// Often, these calcifications are in groups as they extend into small glands in the skin.
		/// -- https://radiopaedia.org/articles/skin-calcification-in-breast?lang=us
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_DermalCalcification = new Coding(System, "DermalCalcification", "Dermal calcification");                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// An abnormal dilation of a duct by lipids and cellular debris.
		/// In  mammary duct the condition, which tends mainly to affect postmenopausal women, may be accompanied by inflammation and infiltration by plasma cells.
		/// -- https://www.hoafredericksburg.com/duct-ectasia/
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_DuctEctasia = new Coding(System, "DuctEctasia", "Duct ectasia");                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Breast edema is defined as a mammographic pattern of skin thickening, increased parenchymal density, and interstitial marking.
		/// It can be caused by benign or malignant diseases, as a result of a tumor in the dermal lymphatics of the breast, lymphatic congestion caused by breast, lymphatic drainage obstruction, or by congestive heart failure.
		/// -- https://www.researchgate.net/publication/7988898_Unilateral_Breast_Edema_Spectrum_of_Etiologies_and_Imaging_Appearances
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_Edema = new Coding(System, "Edema", "Edema");                                                                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Fat Lobule.
		/// The normal breast is composed of numerous fat lobules mixed with dense fibroglandular tissue.
		/// Fat lobule in breast.
		/// Yes.
		/// Breast tissue is composed of functional elements (glands and ducts) as well as structural elements (connective tissue and vessels).
		/// The connective tissue (or stroma) in the breast is composed of various proportions of fat and fibrous tissue.
		/// 
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_FatLobule = new Coding(System, "FatLobule", "Fat lobule");                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Breasts are made up of lobules (milk-producing glands) and ducts (tubes that carry milk to the nipple).
		/// These are surrounded by glandular, fibrous and fatty tissue.
		/// Sometimes a lump can form if an area of the fatty breast tissue is damaged.
		/// This is called fat necrosis (necrosis is a medical term used to describe damaged or dead tissue).
		/// -- https://breastcancernow.org/information-support/have-i-got-breast-cancer/breast-pain-other-benign-conditions/fat-necrosis
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_FatNecrosis = new Coding(System, "FatNecrosis", "Fat necrosis");                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Another name for Hamartomas, Hamartomas represent benign proliferation of fibrous, glandular, and fatty tissue (hence fibro-adeno-lipoma) surrounded by a thin capsule of connective tissue.
		/// All components are found in normal breast tissue, which is why the lesions are considered hamartomatous.
		/// -- https://radiopaedia.org/articles/breast-hamartoma?lang=us
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Fibroadenolipoma = new Coding(System, "Fibroadenolipoma", "Fibroadenolipoma");                                  // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Fibroadenomas are common benign (non-cancerous) breast tumors made up of both glandular tissue and stromal (connective) tissue.
		/// Fibroadenomas are most common in women in their 20s and 30s, but they can be found in women of any age.
		/// They tend to shrink after a woman goes through menopause.
		/// -- https://www.cancer.org/cancer/breast-cancer/non-cancerous-breast-conditions/fibroadenomas-of-the-breast.html
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Fibroadenoma = new Coding(System, "Fibroadenoma", "Fibroadenoma");                                              // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// These are non-cancerous breast lumps.
		/// Fibroadenomas usually go away with age.
		/// By the time a woman is menopausal, they will likely experience a degeneration of the Fibroadenomas.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_FibroadenomaDegenerating = new Coding(System, "FibroadenomaDegenerating", "Fibroadenoma degenerating");         // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Fibrocystic breast changes lead to the development of fluid-filled round or oval sacs (cysts) and more prominent scar-like (fibrous) tissue, which can make breasts feel tender, lumpy or ropy.
		/// Fibrocystic breasts are composed of tissue that feels lumpy or rope-like in texture.
		/// Doctors call this nodular or glandular breast tissue.
		/// -- https://www.mayoclinic.org/diseases-conditions/fibrocystic-breasts/symptoms-causes/syc-20350438
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_FibrocysticChange = new Coding(System, "FibrocysticChange", "Fibrocystic change");                              // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Fibrocystic breast changes lead to the development of fluid-filled round or oval sacs (cysts) and more prominent scar-like (fibrous) tissue, which can make breasts feel tender, lumpy or ropy.
		/// Fibrocystic breasts are composed of tissue that feels lumpy or rope-like in texture.
		/// Doctors call this nodular or glandular breast tissue.
		/// -- https://www.mayoclinic.org/diseases-conditions/fibrocystic-breasts/symptoms-causes/syc-20350438
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_FibroglandularTissue = new Coding(System, "FibroglandularTissue", "Fibroglandular tissue");                     // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Fibrosis may refer to the connective tissue deposition that occurs as part of normal healing or to the excess tissue deposition that occurs as a pathological process.
		/// When fibrosis occurs in response to injury, the term "scarring" is used.
		/// -- https://www.news-medical.net/health/What-is-Fibrosis.aspx
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Fibrosis = new Coding(System, "Fibrosis", "Fibrosis");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Fibrous tissue, which extends under the skin, from the front of the breast to the back of the chest wall, supports the breast and gives it shape.
		/// Strands of supportive tissue surround the breast and form a prominent ridge called the inframammary ridge.
		/// -- https://www.stjoeshealth.org/find-a-service-or-specialty/womens-health/
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_FibrousRidge = new Coding(System, "FibrousRidge", "Fibrous ridge");                                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Folliculitis is the inflammation of hair follicles due to an infection, injury, or irritation.
		/// It is characterized by tender, swollen areas that form around hair follicles, often on the neck, breasts, buttocks, and face.
		/// Boils (also referred to as furuncles) are pus-filled lesions that are painful and usually firm.
		/// -- https://www.hopkinsmedicine.org/health/conditions-and-diseases/folliculitis-boils-and-carbuncles
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_Folliculitis = new Coding(System, "Folliculitis", "Folliculitis");                                              // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Gynecomastia is an enlargement or swelling of breast tissue in males.
		/// It is most commonly caused by male estrogen levels that are too high or are out of balance with testosterone levels.
		/// -- https://my.clevelandclinic.org/health/diseases/16227-enlarged-male-breast-tissue-gynecomastia
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_Gynecomastia = new Coding(System, "Gynecomastia", "Gynecomastia");                                              // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A benign (not cancer) growth made up of an abnormal mixture of cells and tissues normally found in the area of the body where the growth occurs.
		/// -- https://www.cancer.gov/publications/dictionaries/cancer-terms/def/hamartoma
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Hamartoma = new Coding(System, "Hamartoma", "Hamartoma");                                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A breast hematoma is a collection of blood that forms under the skin's surface.
		/// It's not unlike having a large bruise in your breast.
		/// The mass it forms is not cancerous, but it can sometimes lead to inflammation, fever, skin discoloration, and may leave behind scar tissue that mimics the shape of a breast tumor.
		/// -- https://www.verywellhealth.com/breast-hematomas-430281
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Hematoma = new Coding(System, "Hematoma", "Hematoma");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Hormonal effects of certain medications including antihypertensives, antidepressants, H2 blockers,illicit drugs, and endocrine active tumors stimulate development of rudimentary breast tissue.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition
		/// 
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_HormonalStimulation = new Coding(System, "HormonalStimulation", "Hormonal stimulation");                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Intracystic tumors of the breast are uncommon and, at the time of ultrasonography and aspiration cytology, it is difficult to distinguish cancer from a benign tumor.
		/// -- https://www.ncbi.nlm.nih.gov/pubmed/11911303
		/// Valid for the following modalities: US NM.
		/// </summary>
		public static Coding Code_IntracysticLesion = new Coding(System, "IntracysticLesion", "Intracystic lesion");                              // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// These are lymph  nodes within the breast tissue.
		/// They are generally 1 cm or smallerin size.
		/// They frequently occur in the lateral and usually upper portions of the breast closer to theaxilla (armpit area), although they may occur anywhere in the breast.
		/// They usually are seen adjacent to a vein, because the lymphatic drainage of the breast parallels the venous drainage.
		/// -- Breast Imaging Reporting and Data System—Mammography, Fifth Edition
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_IntramammaryNode = new Coding(System, "IntramammaryNode", "Intramammary node");                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A lipoma is a slow-growing, fatty lump that's most often situated between your skin and the underlying muscle layer.
		/// A lipoma, which feels doughy and usually isn't tender, moves readily with slight finger pressure.
		/// Lipomas are usually detected in middle age.
		/// Some people have more than one lipoma.A lipoma isn't cancer and usually is harmless.
		/// www.mayoclinic.org > lipoma > symptoms-causes > syc-20374470
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Lipoma = new Coding(System, "Lipoma", "Lipoma");                                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// With a lumpectomy, the surgeon removes only the tumor and a small amount of normal surrounding tissue.
		/// The cavity is the hollow area or hole left behind after the tumor and surrounding tissue is removed.
		/// 
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_LumpectomyCavity = new Coding(System, "LumpectomyCavity", "Lumpectomy cavity");                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// The area of the breast where the incision is made during the lumpectomy.
		/// 
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_LumpectomySite = new Coding(System, "LumpectomySite", "Lumpectomy site");                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A small bean-shaped structure that is part of the body's immune system.
		/// Lymph nodes filter substances that travel through the lymphatic fluid, and they contain lymphocytes (white blood cells) that help the body fight infection and disease.
		/// There are hundreds of lymph nodes found throughout the body.
		/// They are connected to one another by lymph vessels.
		/// Clusters of lymph nodes are found in the neck, axilla (underarm), chest, abdomen, and groin.
		/// For example, there are about 20-40 lymph nodes in the axilla.
		/// Also called lymph gland.
		/// -- https://www.cancer.gov/publications/dictionaries/cancer-terms/def/lymph-node
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_LymphNode = new Coding(System, "LymphNode", "Lymph node");                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Enlarged or swollen lymph nodes usually indicate a common infection, but they can also signal a medical condition, such as an immune disorder or, rarely, a type of cancer.
		/// Lymph nodes are small, round structures that play a vital role in the body's immune system.
		/// Swollen lymph nodes are also known as swollen glands.
		/// 
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_LymphNodeEnlarged = new Coding(System, "LymphNodeEnlarged", "Lymph node enlarged");                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Lymph nodes filter substances that travel through the lymphatic fluid, and they contain lymphocytes (white blood cells) that help the body fight infection and disease.
		/// There are hundreds of lymph nodes found throughout the body.
		/// They are connected to one another by lymph vessels.
		/// Clusters of lymph nodes are found in the neck, axilla (underarm), chest, abdomen, and groin.
		/// A normal sized lymph node is about pea-sized or bean-sized (or smaller than 1/2 inch or 12mm).
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_LymphNodeNormal = new Coding(System, "LymphNodeNormal", "Lymph node normal");                                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Lymphadenopathy (or adenopathy) is, if anything, a broader term, referring to any pathology of lymph nodes, not necessarily resulting in increased size; this includes abnormal number of nodes, or derangement of internal architecture (e.g.
		/// cystic or necrotic nodes).
		/// -- https://radiopaedia.org/articles/lymph-node-enlargement?lang=us
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_LymphNodePathological = new Coding(System, "LymphNodePathological", "Lymph node pathological");                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// An abnormal mass of tissue that usually does not contain cysts or liquid areas.
		/// Solid masses or tumors may be benign (not cancer), or malignant (cancer).
		/// Different types of solid mass/ tumors are named for the type of cells that form them.
		/// Examples of solid tumors are sarcomas, carcinomas, and lymphomas.
		/// Leukemias (cancer of the blood) generally do not form solid mass/tumors.
		/// -- https://www.cancer.gov/publications/dictionaries/cancer-terms/def/solid-tumor
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_MassSolid = new Coding(System, "MassSolid", "Mass solid");                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// An abnormal mass of tissue that usually does not contain cysts or liquid areas.
		/// Solid masses or tumors may be benign (not cancer), or malignant (cancer).
		/// Different types of solid mass/ tumors are named for the type of cells that form them.
		/// Examples of solid tumors are sarcomas, carcinomas, and lymphomas.
		/// Leukemias (cancer of the blood) generally do not form solid mass/tumors.
		/// A vascular tumor is a type of tumor that forms from cells that make blood vessels or lymph vessels.
		/// Vascular tumors may be benign (not cancer) or malignant (cancer) and can occur anywhere in the body.
		/// They may form on the skin, in the tissues below the skin, and/or in an organ.
		/// There are many types of vascular tumors.
		/// -- https://www.cancer.gov/publications/dictionaries/cancer-terms/def/solid-tumor https://www.cancer.gov/publications/dictionaries/cancer-terms/def/vascular-tumor
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_MassSolidWTumorVasc = new Coding(System, "MassSolidW/tumorVasc", "Mass solid w/tumor vasc");                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Infection of the breast tissue resulting in pain, swelling, warmth and redness.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Mastitis = new Coding(System, "Mastitis", "Mastitis");                                                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// The term milk of calcium (MOC) is given to dependent, sedimented calcification within a cystic structure or hollow organ.
		/// This sort of colloidal calcium suspension layering can occur in various regions.
		/// -- https://radiopaedia.org/articles/milk-of-calcium-disambiguation?lang=us
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MilkOfCalcium = new Coding(System, "MilkOfCalcium", "Milk of calcium");                                         // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Multifocal breast cancer occurs when there are two or more tumors in the same breast.
		/// All of the tumors begin in one original tumor.
		/// The tumors are also all in the same quadrant - or section - of the breast.
		/// -- https://www.healthline.com/health/breast-cancer/multifocal-breast-cancer
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_MultiFocalCancer = new Coding(System, "Multi-focalCancer", "Multi-focal cancer");                               // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Breast papillary lesions are characterised by growth inside the milk ducts, and they represent a heterogeneous pathology.
		/// They are rare and constitute less than 10% of benign breast lesions and less than 1% of malignant breast neoplasms.
		/// Breast papillary lesions are usually detected by imaging or clinically by the presence of a palpable breast mass or unilateral spontaneous nipple discharge.
		/// -- https://ecancer.org/es/journal/article/461-breast-papillary-lesions-an-analysis-of-70-cases
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_PapillaryLesion = new Coding(System, "PapillaryLesion", "Papillary lesion");                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Intraductal papillomas are benign (non-cancerous), wart-like tumors that grow within the milk ducts of the breast.
		/// They are made up of gland tissue along with fibrous tissue and blood vessels (called fibrovascular tissue).
		/// -- https://www.cancer.org/cancer/breast-cancer/non-cancerous-breast-conditions/intraductal-papillomas.html
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Papilloma = new Coding(System, "Papilloma", "Papilloma");                                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Phyllodes tumors of the breast are rare, accounting for less than 1% of all breast tumors.
		/// The name "phyllodes," which is taken from the Greek language and means "leaflike," refers to that fact that the tumor cells grow in a leaflike pattern.
		/// Other names for these tumors are phylloides tumor and cystosarcoma phyllodes.
		/// Phyllodes tumors tend to grow quickly, but they rarely spread outside the breast.Although most phyllodes tumors are benign (not cancerous), some are malignant (cancerous) and some are borderline (in between noncancerous and cancerous).
		/// All three kinds of phyllodes tumors tend to grow quickly, and they require surgery to reduce the risk of a phyllodes tumor coming back in the breast (local recurrence).
		/// -- https://www.breastcancer.org/symptoms/types/phyllodes
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_PhyllodesTumor = new Coding(System, "PhyllodesTumor", "Phyllodes tumor");                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// This is scarring that occurs from the lumpectomy site.
		/// It can include nerve pain or numbness if scar tissue forms around nerves.A lump of scar tissue forms in the hole left after breast tissue is removed.
		/// If scar tissue forms around a stitch from surgery it's called a suture granuloma and also feels like a lump.Changes in breast appearance.
		/// Scar tissue and fluid retention can make breast tissue appear a little firmer or rounder than before surgery and/or radiation.
		/// -- https://www.breastcancer.org/treatment/side_effects/scar_tissue
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PostLumpectomyScar = new Coding(System, "PostLumpectomyScar", "Post lumpectomy scar");                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Post surgical scarring happens because of the incisions needed to surgically remove tumor, cells, etc.
		/// The amount of scarring is connected to the different stages of wound healing.
		/// Surgical scar care should be continued for a year.
		/// 
		/// Valid for the following modalities: MG NM.
		/// </summary>
		public static Coding Code_PostSurgicalScar = new Coding(System, "PostSurgicalScar", "Post surgical scar");                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Findings on mammogram are  consistent with previous biopsy.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PreviousBiopsy = new Coding(System, "PreviousBiopsy", "Previous biopsy");                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Findings on mammogram are consistent with previous surgery.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PreviousSurgery = new Coding(System, "PreviousSurgery", "Previous surgery");                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Findings on mammogram are consistent with previous trauma to breast.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PreviousTrauma = new Coding(System, "PreviousTrauma", "Previous trauma");                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Radial scar is a growth that looks like a scar when the tissue is viewed under a microscope.
		/// It has a central core containing benign ducts.
		/// Growing out of this core are ducts and lobules that show evidence of unusual changes such as cysts and epithelial hyperplasia (overgrowth of their inner lining).
		/// Often, more than one radial scar is present.
		/// Another term for this condition is complex sclerosing lesions.
		/// -- https://www.breastcancer.org/symptoms/benign/radial-scars
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_RadialScar = new Coding(System, "RadialScar", "Radial scar");                                                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Radiation levels during radiation therapy may change as a result of side effects or to complete a more aggressive cancer treatment.
		/// 
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_RadiationChanges = new Coding(System, "RadiationChanges", "Radiation changes");                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// The use of high-energy radiation from x-rays, gamma rays, neutrons, protons, and other sources to kill cancer cells and shrink tumors.
		/// Radiation may come from a machine outside the body (external-beam radiation therapy), or it may come from radioactive material placed in the body near cancer cells (internal radiation therapy or brachytherapy).
		/// Systemic radiation therapy uses a radioactive substance, such as a radiolabeled monoclonal antibody, that travels in the blood to tissues throughout the body.
		/// Also called irradiation and radiotherapy.
		/// -- https://www.cancer.gov/publications/dictionaries/cancer-terms/def/44971
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_RadiationTherapy = new Coding(System, "RadiationTherapy", "Radiation therapy");                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Scar tissue forms as part of the healing process after a skin injury.
		/// A scar is fibrous tissue made of collagen that replaces the injured skin.
		/// -- https://www.breastcancer.org/treatment/side_effects/scar_tissue
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_Scar = new Coding(System, "Scar", "Scar");                                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// In cases when the appropriate history is not available, a postsurgical scar may mimic a malignancy.
		/// At sonographic evaluation, an area of posterior acoustic shadowing may be seen.
		/// This lack of a central mass helps differentiate a scar from a carcinoma, which has shadowing arising from a central mass.
		/// onlinelibrary.wiley.com > doi > full > jum.2004.23.1.73
		/// 
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_ScarWithShadowing = new Coding(System, "ScarWithShadowing", "Scar with shadowing");                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Sclerosing adenosis is a type of adenosis in which enlarged acini become slightly distorted by surrounded stromal fibrosis ("sclerosis").
		/// The normal lobular architecture of the breast is maintained, but becomes exaggerated and distorted.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SclerosingAdenosis = new Coding(System, "SclerosingAdenosis", "Sclerosing adenosis");                           // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Secretory calcifications are benign calcifications usually in women older than 60.
		/// They classically appear as solid or discontinuous, smooth, linear and rod-like calcifications.
		/// Usually bilateral and symmetric and may appear lucent-centered.
		/// Also known as plasma cell mastitis.
		/// -- https://radiopaedia.org/cases/secretory-calcifications?lang=us
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SecretoryCalcification = new Coding(System, "SecretoryCalcification", "Secretory calcification");               // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// The sentinel nodes are the first few lymph nodes into which a tumor drains.
		/// Sentinel node biopsy involves injecting a tracer material that helps the surgeon locate the sentinel nodes during surgery.
		/// The sentinel nodes are removed and analyzed in a laboratory.
		/// -- https://www.mayoclinic.org/tests-procedures/sentinel-node-biopsy/about/pac-20385264
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_SentinelNode = new Coding(System, "SentinelNode", "Sentinel node");                                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A breast seroma is a collection (pocket) of serous fluid that can develop after trauma to the breast or following procedures such as breast surgery or radiation therapy.
		/// Serous fluid is a pale yellow, transparent fluid that contains protein, but no blood cells or pus.
		/// -- https://www.verywellhealth.com/seroma-medical-definition-430372
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Seroma = new Coding(System, "Seroma", "Seroma");                                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A skin lesion is a part of the skin that has an abnormal growth or appearance compared to the skin around it.
		/// Primary skin lesions are abnormal skin conditions present at birth or acquired over a person's lifetime.
		/// Secondary skin lesions are the result of irritated or manipulated primary skin lesions.
		/// -- https://www.healthline.com/health/skin-lesions
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SkinLesion = new Coding(System, "SkinLesion", "Skin lesion");                                                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// The branch of medicine that employs operations in the treatment of disease or injury.
		/// Surgery can involve cutting, abrading, suturing, or otherwise physically changing body tissues and organs.
		/// -- https://www.medicinenet.com/script/main/art.asp?articlekey=5603
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_Surgery = new Coding(System, "Surgery", "Surgery");                                                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Previous injury to breast consistent with surgery, infection, etc.
		/// 
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_Trauma = new Coding(System, "Trauma", "Trauma");                                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Parallel tracks, or linear tubular calcifications that are clearly associated with blood vessels.While most vascular calcification is not difficult to identify, if only a few discontinuous calcificparticles are visible in a single location and if association with a tubular structure is questionable,then additional spot-compression magnification views may be needed to further characterizetheir nature.
		/// -- Breast Imaging Reporting and Data System—Ultrasound, Second Edition#38
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_VascularCalcifications = new Coding(System, "VascularCalcifications", "Vascular calcifications");               // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Venous stasis dermatitis happens when there's a problem with your veins, that keeps blood from moving through very well.
		/// As more fluid and pressure build, some of the blood leaks out of your veins and into your skin.
		/// -- https://www.webmd.com/skin-problems-and-treatments/eczema/venous-stasis-dermatitis#1
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_VenousStasis = new Coding(System, "VenousStasis", "Venous stasis");                                             // CSBuilder.cs:433
		//- Fields
	}
}
