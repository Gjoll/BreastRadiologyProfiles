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
	public class RecommendationsCodeSystemCS                                                                                                   // CSBuilder.cs:403
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/RecommendationsCodeSystemCS";                                   // CSBuilder.cs:407
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Advanced Technology that takes multiple images, or X-rays, of breast tissue to recreate a 3-dimensional picture of the breast.
		/// Also called breast tomosynthesis.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_3DImaging = new Coding(System, "3DImaging", "3D Imaging");                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Advanced Technology that takes multiple images, or X-rays, of breast tissue to recreate a 3-dimensional picture of the breast.
		/// Cranial-Caudal (CC) is a 3D view from above the breast.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_3DSpotCC = new Coding(System, "3DSpotCC", "3D spot CC");                                                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Advanced Technology that takes multiple images, or X-rays, of breast tissue to recreate a 3-dimensional picture of the breast.
		/// Lateral-medial (LM) is
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_3DSpotLM = new Coding(System, "3DSpotLM", "3D spot LM");                                                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Advanced Technology that takes multiple images, or X-rays, of breast tissue to recreate a 3-dimensional picture of the breast.
		/// Mediolateral (ML) is
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_3DSpotML = new Coding(System, "3DSpotML", "3D spot ML");                                                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Advanced Technology that takes multiple images, or X-rays, of breast tissue to recreate a 3-dimensional picture of the breast.
		/// Mediolateral-oblique (MLO) is
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_3DSpotMLO = new Coding(System, "3DSpotMLO", "3D spot MLO");                                                     // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Additional views in Mammography, MRI and US, help increase the chances of finding any possible tumors in the breast.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_AdditionalViews = new Coding(System, "AdditionalViews", "Additional views");                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Additional views in a Mammogram, MRI or Ultrasound are recommended.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_AddlitionalViewsWithPossibleUltrasound = new Coding(System, "AddlitionalViewsWithPossibleUltrasound", "Addlitional views with possible ultrasound");// CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// An axillary view (also known as a "Cleopatra view") is a type of view in mammography. It is an exaggerated craniocaudal view for better imaging of the lateral portion of the breast to the axillary tail.
		/// This projection is performed whenever we want to show a lesion seen only in the axillary tail on the MLO view.
		/// An optimal axillary view require to be clearly displayed the most lateral portion of the breast including the axillary tail, as well the pectoral muscle and the nipple in profile.
		/// -- https://radiopaedia.org/articles/axillary-view?lang=us
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_AxillaView = new Coding(System, "AxillaView", "Axilla view");                                                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// The tail of Spence (Spence's tail, axillary process, axillary tail) is an extension of the tissue of the breast that extends into the axilla.
		/// It is actually an extension of the upper lateral quadrant of the breast.
		/// It passes into the axilla through an opening in the deep fascia called foramen of Langer.
		/// -- https://en.wikipedia.org/wiki/Tail_of_Spence
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_AxillaryTailView = new Coding(System, "AxillaryTailView", "Axillary tail view");                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Biopsy = new Coding(System, "Biopsy", "Biopsy");                                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_BiopsyBaseOnClinical = new Coding(System, "BiopsyBaseOnClinical", "Biopsy base on clinical");                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// It is recommended that a Caudocranial view is captured by Ultrasound and/or Mammogram.
		/// It is useful for the study of breasts in the lower quadrants.
		/// The patient will bend forward at the waist to view the underside of the breast.
		/// Also called a reverse CC view.
		/// The reversed CC view is an additional view.
		/// It is useful for the study of breasts with surgical scars in the lower quadrants.
		/// The ability to see the scar through the compressor paddle offers to the mammographer the possibility to flatten it properly, reducing the formation of scar folds as well artifacts from false parenchymal distortion.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CaudocranialView = new Coding(System, "CaudocranialView", "Caudocranial view");                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CCWithCompressionView = new Coding(System, "CCWithCompressionView", "CC with compression view");                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CCWithMagnificationView = new Coding(System, "CCWithMagnificationView", "CC with magnification view");          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// It is recommended that a cleavage view is captured via Mammogram and/or Ultrasound.
		/// Also called "valley view" is a mammogram view that images the most central portions of the breasts.
		/// To get as much central tissue as possible, the mammogram technologist will place both breasts on the plate at the same time to image the medial half of both breasts.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CleavageView = new Coding(System, "CleavageView", "Cleavage view");                                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A clinical consultation is recommended.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_ClinicalConsultation = new Coding(System, "ClinicalConsultation", "Clinical consultation");                     // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_ClinicalCorrelation = new Coding(System, "ClinicalCorrelation", "Clinical correlation");                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_ClinicalFollowUp = new Coding(System, "ClinicalFollow-up", "Clinical follow-up");                               // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CompareToPriorExams = new Coding(System, "CompareToPriorExams", "Compare to prior exams");                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// It is recommended that a compression view is admininstered via Mammogram or Ultrasound.
		/// All mammograms use compression of the breast.
		/// By applying compression to only a specific area of the breast, the effective pressure is increased on that spot.
		/// This results in better tissue separation and allows better visualization of the area of the breast needing additional examination.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CompressionViews = new Coding(System, "CompressionViews", "Compression views");                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A cone compression is recommended to catch a specific spot or view during the mammogram and/or ultrasound.
		/// Spot views apply the compression to a smaller area of tissue using a small compression plate or "cone".
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_ConeCompression = new Coding(System, "ConeCompression", "Cone compression");                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// It is recommended that a core biopsy procedure is administered.
		/// It is a procedure where a needle is passed through the skin to take a sample of tissue from a mass or lump.
		/// The tissue is then examined under a microscope for any abnormalities.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_CoreBiopsy = new Coding(System, "CoreBiopsy", "Core Biopsy");                                                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Cranial-Caudal (CC) is a view from above the breast during a mammogram or ultrasound.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_CraniocaudalView = new Coding(System, "CraniocaudalView", "Craniocaudal view");                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Uses imaging guidance, a needle-like applicator called a cryoprobe, and liquid nitrogen or argon gas to create intense cold to freeze and destroy diseased tissue, including cancer cells.
		/// It may be used to treat a variety of skin conditions as well as tumors within the liver, kidneys, bones, lungs and breasts.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Cryoablation = new Coding(System, "Cryoablation", "Cryoablation");                                              // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A cyst aspiration is a procedure used to drain fluid from a breast cyst.
		/// The vast majority of cysts are benign (non-cancerous), though some are quite tender.
		/// Aspirating the fluid from a cyst may alleviate symptoms or discomfort.
		/// In some cases, specimens are sent to pathology.
		/// www.carolmilgardbreastcenter.org > Cyst_Aspiration
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_CystAspiration = new Coding(System, "CystAspiration", "Cyst aspiration");                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// One way to get relief from the pain of a cyst is to have a doctor remove fluid from the cyst, thereby decreasing the pressure.
		/// This is called aspiration.
		/// 
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_CystAspirationForRelief = new Coding(System, "CystAspirationForRelief", "Cyst aspiration for relief");          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// This is a fine needle aspiration and is a type of biopsy procedure.
		/// In fine needle aspiration, a thin needle is inserted into an area of abnormal-appearing tissue or body fluid.
		/// www.webmd.com > a-to-z-guides > fine-needle-aspiration
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_DiagnosticAspiration = new Coding(System, "DiagnosticAspiration", "Diagnostic aspiration");                     // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// While screening mammograms are used as a routine check-up for breast health,  diagnostic mammograms are used after suspicious results on a screening mammogram or after some signs of breast cancer alert the physician to check the tissue.These signs may include a lump or breast pain.
		/// -- https://www.nationalbreastcancer.org/diagnostic-mammogram
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_DiagnosticMammogram = new Coding(System, "DiagnosticMammogram", "Diagnostic Mammogram");                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_DrainageTube = new Coding(System, "DrainageTube", "Drainage tube");                                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A ductogram, also called a galactogram, is a special type of mammogram used for imaging the breast ducts.
		/// It can aid in diagnosing the cause of abnormal nipple discharges.Ductography (also called galactography or ductogalactography) is a special type of contrast enhanced mammography used for imaging the breast ducts.
		/// Ductography can aid in diagnosing the cause of an abnormal nipple discharge and is valuable in diagnosing intraductal papillomas and other conditions.###URL#https://www.imaginis.com/mammography/ductogram-galactogram-imaging-the-breast-ducts
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Ductography = new Coding(System, "Ductography", "Ductography");                                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// An XCCL view is a supplementary mammographic view.
		/// It is a type of exaggerated cranio-caudal view.
		/// It is particularly good for imaging the lateral aspect of the breast. It is often done when a lesion is suspected on a MLO view but cannot be seen on the CC view. In this view, the lateral aspect of the breast is placed forward.
		/// One rationale of performing this view is that many cancers are located in the lateral aspect of the breast.
		/// An XCCM view is a supplementary mammographic view.
		/// It is a type of exaggerated cranio-caudal view.
		/// It is particularly good for imaging the medial portion of the breast.
		/// In this view, the medial portion of the breast is placed forward.
		/// A negative 15degrees tube tilt is suggested.An optimal XCCM view requires the most medial portion of the breast and the nipple in profile to be clearly displayed.
		/// -- https://radiopaedia.org/articles/xccl-view?lang=us
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_ExaggeratedCCViews = new Coding(System, "ExaggeratedCCViews", "Exaggerated CC views");                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// FNA stands for Fine needle aspiration and this is a type of biopsy procedure.
		/// In fine needle aspiration, a thin needle is inserted into an area of abnormal-appearing tissue or body fluid.As with other types of biopsies, the sample collected during fine needle aspiration can help make a diagnosis or rule out conditions such as cancer.
		/// -- https://www.webmd.com/a-to-z-guides/fine-needle-aspiration#1
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_FNABiopsy = new Coding(System, "FNABiopsy", "FNA biopsy");                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// It is recommended to make a follow-up appointment.
		/// 
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_FollowUp = new Coding(System, "Follow-up", "Follow-up");                                                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// It is recommended to make a follow-up appointment in 3 months.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Followup3Months = new Coding(System, "Followup3Months", "Followup 3 months");                                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// It is recommended to make a follow-up appointment in 6 months.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Followup6Months = new Coding(System, "Followup6Months", "Followup 6 months");                                   // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_IfPreviousShowNoChange = new Coding(System, "IfPreviousShowNoChange", "If previous show no change");            // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_LateralMagnificaionView = new Coding(System, "LateralMagnificaionView", "Lateral magnificaion view");           // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// There are different views of the breast in mammography.
		/// For the LM view, the tube is lateral and the detector is placed mediallyLM view is best for evaluating medial lesions.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateralMedialView = new Coding(System, "LateralMedialView", "Lateral medial view");                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// There are different views of the breast in mammography.
		/// The lateral view is a view obtained at virtually every diagnostic evaluation.
		/// A lateral view may be obtained as a mediolateral view (ML) or lateromedial view (LM) view depending on where the imaging tube and detector are located.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateralView = new Coding(System, "LateralView", "Lateral view");                                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateralWithCompressionView = new Coding(System, "LateralWithCompressionView", "Lateral with compression view"); // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateromedialOblique = new Coding(System, "LateromedialOblique", "Lateromedial oblique");                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateromedialView = new Coding(System, "LateromedialView", "Lateromedial view");                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Lymph Node Exam.
		/// Palpation of the lymph nodes provides information about the possible presence of a malignant or inflammatory process and the localization or generalization of that process.
		/// -- https://stanfordmedicine25.stanford.edu/the25/lymph.html
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_LymphNodeAssessment = new Coding(System, "LymphNodeAssessment", "Lymph node assessment");                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A magnification view in mammography is performed to evaluate and count microcalcifications and its extension (as well the assessment of the borders and the tissue structures of a suspicious area or a mass) by using a magnification device which brings the breast away from the film plate and closer to the x-ray source.
		/// This allows the acquisition of magnified images (1.5x to 2x magnification) of the region of interest. radiopaedia.org > articles > magnification-view-mammography
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_MagnificationViews = new Coding(System, "MagnificationViews", "Magnification views");                           // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// An X-Ray picture of the breast.
		/// It's used to look for early signs of breast cancer.
		/// 
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_Mammogram = new Coding(System, "Mammogram", "Mammogram");                                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A three month follow-up is recommended.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Mammogram3MonthFollowUp = new Coding(System, "Mammogram3MonthFollow-up", "Mammogram 3 month follow-up");        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A six month follow-up is recommended.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Mammogram6MonthFollowUp = new Coding(System, "Mammogram6MonthFollow-up", "Mammogram 6 month follow-up");        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A three month follow-up is recommended.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MammogramAndUltrasound3MonthFollowUp = new Coding(System, "MammogramAndUltrasound3MonthFollow-up", "Mammogram and ultrasound 3 month follow-up");// CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A six month follow-up is recommended.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MammogramAndUltrasound6MonthFollowUp = new Coding(System, "MammogramAndUltrasound6MonthFollow-up", "Mammogram and ultrasound 6 month follow-up");// CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MediolateralObliqueView = new Coding(System, "MediolateralObliqueView", "Mediolateral oblique view");           // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MediolateralView = new Coding(System, "MediolateralView", "Mediolateral view");                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MLOWithCompressionView = new Coding(System, "MLOWithCompressionView", "MLO with compression view");             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MLOWithMagnificationView = new Coding(System, "MLOWithMagnificationView", "MLO with magnification view");       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MRI = new Coding(System, "MRI", "MRI");                                                                         // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_MRIBiopsy = new Coding(System, "MRIBiopsy", "MRI biopsy");                                                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MRI NM.
		/// </summary>
		public static Coding Code_MRIFollowUp = new Coding(System, "MRIFollow-up", "MRI follow-up");                                              // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_NeedleLocationAndSurgicalBiopsy = new Coding(System, "NeedleLocationAndSurgicalBiopsy", "Needle location and surgical biopsy");// CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A technically adequate exam has the nipple in profile, allows visualization of the inframammary fold and includes the pectoralis muscle extending down to the posterior nipple line (an oblique line drawn straight back from the nipple.) ###URL#https://www.mammoguide.com/mammo-techniques.html
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_NippleInProfileView = new Coding(System, "NippleInProfileView", "Nipple in profile view");                      // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_OffAngleCCView = new Coding(System, "OffAngleCCView", "Off angle CC view");                                     // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_OffAngleMLOView = new Coding(System, "OffAngleMLOView", "Off angle MLO view");                                  // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Stereotactic breast biopsy uses mammography - a specific type of breast imaging that uses low-dose x-rays - to help locate a breast abnormality and remove a tissue sample for examination under a microscope.
		/// It's less invasive than surgical biopsy, leaves little to no scarring and can be an excellent way to evaluate calcium deposits or tiny masses that are not visible on ultrasound.
		/// -- https://www.radiologyinfo.org/en/info.cfm?pg=breastbixr
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossStereotacticBx = new Coding(System, "Poss.StereotacticBx", "Poss. Stereotactic Bx");                        // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// If other tests show you might have breast cancer, your doctor might refer you for a core needle biopsy (CNB).
		/// For a CNB, the doctor uses a hollow needle to take out pieces of breast tissue from a suspicious area the doctor has felt or has pinpointed on an imaging test.
		/// The needle may be attached to a spring-loaded tool that moves the needle in and out of the tissue quickly, or it may be attached to a suction device that helps pull breast tissue into the needle.
		/// A small cylinder (core) of tissue is taken out in the needle.
		/// Several cores are often removed.
		/// -- https://www.cancer.org/cancer/breast-cancer/screening-tests-and-early-detection/breast-biopsy/core-needle-biopsy-of-the-breast.html
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_PossibleCoreBiopsy = new Coding(System, "PossibleCoreBiopsy", "Possible core biopsy");                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A diagnostic mammogram is an X-ray examination of the breasts.
		/// This is carried out when a person, their doctor or another health professional discovers unusual signs or symptoms in one or both breasts; that is, a lump, tenderness, nipple discharge or skin changes.
		/// The mammogram confirms whether the changes are benign (non-cancerous) and no treatment is needed, or whether the changes indicate possible breast cancer and further tests and treatment may be required.
		/// -- https://www.insideradiology.com.au/diagnostic-mammography/
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossibleDiagnosticMammogram = new Coding(System, "PossibleDiagnosticMammogram", "Possible Diagnostic Mammogram");// CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Based on the results of your last mammogram, it may be  recommended that an area of your breast be biopsied in order to obtain further information.
		/// This is accomplished through a technique known as a stereotatic vacuum assisted core biopsy.During this type of biopsy, small samples of tissue are removed from the breast using a hollow needle, which is precisely guided to the correct location using x-rays and computer generated coordinates of the concerning area of breast tissue.
		/// -- https://www.genesishealth.com/care-treatment/cancer/treat/breast/diagnosis/sterotactic_vacuum/
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossibleStereotacticVacuumBiopsy = new Coding(System, "PossibleStereotacticVacuumBiopsy", "Possible stereotactic vacuum biopsy");// CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_PossibleSurgicalConsult = new Coding(System, "PossibleSurgicalConsult", "Possible surgical consult");           // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_PossibleSurgicalEvaluation = new Coding(System, "PossibleSurgicalEvaluation", "Possible surgical evaluation");  // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossibleUltrasound = new Coding(System, "PossibleUltrasound", "Possible ultrasound");                           // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossibleUltrasoundGuidedBiopsy = new Coding(System, "PossibleUltrasoundGuidedBiopsy", "Possible ultrasound guided biopsy");// CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Recommendation is a vacuum assisted biopsy.
		/// This is a way of  removing an area of abnormal cells from the breast tissue.
		/// A doctor or nurse uses a special needle attached to a vacuum device to remove the cells.
		/// The samples can then be examined under a microscope.
		/// This can show whether there is a cancer or another type of breast condition.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossibleVacuumBiopsy = new Coding(System, "PossibleVacuumBiopsy", "Possible vacuum biopsy");                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_RepeatCCView = new Coding(System, "RepeatCCView", "Repeat CC view");                                            // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_RepeatMLOView = new Coding(System, "RepeatMLOView", "Repeat MLO view");                                         // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Given that the rolled projections can be performed from any standard projection, the most commonly used is certainly the cranio-caudal one.
		/// A rolled CC view It's performed to locate a lesion only visible in the cranio-caudal view, or when overlapped tissues in the standard view can simulate or partially conceal a lesion: changing of  tissues distribution  allows to determine whether or not its presence.
		/// When the lesion identified moves medially or laterally respect to the standard projection, it is possible to determine in which quadrant it is localized.The breast is positioned on the image receptor as for the cranio-caudal view, then is rotated medially or laterally around the axis of the nipple prior to applying compression.
		/// -- https://radiopaedia.org/articles/rolled-cc-view-1?lang=us
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_RolledLateralView = new Coding(System, "RolledLateralView", "Rolled lateral view");                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_RolledMedialView = new Coding(System, "RolledMedialView", "Rolled medial view");                                // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A Scinti Biopsy is recommended.
		/// This is a fine needle aspiration and is a type of biopsy procedure.
		/// In fine needle aspiration, a thin needle is inserted into an area of abnormal-appearing tissue or body fluid.
		/// This is also can be called a Scinti biopsy.
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_ScintiBiopsy = new Coding(System, "ScintiBiopsy", "Scinti biopsy");                                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Scintimammography is also known as nuclear medicine breast imaging, Breast Specific Gamma Imaging (BSGI) and Molecular Breast Imaging (MBI).
		/// Your doctor may use this exam to investigate a breast abnormality found with mammography.
		/// Scintimammography uses small amounts of radioactive material, a special camera and a computer to help investigate a breast abnormality.
		/// Scintimammography can detect cancer even when dense breast tissue and breast implants are present.
		/// It can reduce unnecessary procedures by helping determine whether a biopsy is needed.
		/// -- https://www.radiologyinfo.org/en/info.cfm?pg=scintimammo
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Scintimammography = new Coding(System, "Scintimammography", "Scintimammography");                               // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A spot view (also known as a spot compression view or focal compression view) is an additional mammographic view performed by applying the compression to a smaller area of tissue using a small compression paddle, increasing the effective pressure on that spot.
		/// This results in better tissue separation and allows better visualization of the breast tissue in that area.
		/// It is used to distinguish between the presence of a true lesion and an overlap of tissues, as well to better show the borders of an abnormality or questionable area or a little cluster of faint microcalcifications in a dense area.
		/// -- https://radiopaedia.org/articles/spot-view-mammography?lang=us
		/// Valid for the following modalities: MG US NM.
		/// </summary>
		public static Coding Code_SpotCompression = new Coding(System, "SpotCompression", "Spot compression");                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// In a mammogram
		/// 
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SpotMagnificationViews = new Coding(System, "SpotMagnificationViews", "Spot magnification views");              // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Stereotactic breast biopsy uses mammography - a specific type of breast imaging that uses low-dose x-rays - to help locate a breast abnormality and remove a tissue sample for examination under a microscope.
		/// It's less invasive than surgical biopsy, leaves little to no scarring and can be an excellent way to evaluate calcium deposits or tiny masses that are not visible on ultrasound.
		/// -- https://www.radiologyinfo.org/en/info.cfm?pg=breastbixr
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_StereotacticBx = new Coding(System, "StereotacticBx", "Stereotactic bx");                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// The view of the upper outer quadrant of the breast.
		/// This is the quadrant of the breast that is closest to the armpit.
		/// There are 4 quadrants in the anatomy of a breast.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_SuperolateralIOView = new Coding(System, "SuperolateralIOView", "Superolateral IO view");                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A surgical biopsy is a procedure that involves the surgical removal of tissue from a lump or mass for examination under a microscope.
		/// This test may also be called an open biopsy.Surgical biopsies can be excisional (removal of an entire lump or abnormal area) or incisional (removal of a piece of a lump or abnormal area).
		/// -- https://www.cancer.ca/en/cancer-information/diagnosis-and-treatment/tests-and-procedures/surgical-biopsy/?region=on
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_SurgicalBiopsy = new Coding(System, "SurgicalBiopsy", "Surgical biopsy");                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Recommend consultation with your doctor to determine if surgery is the best plan of action for your diagnosis.
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_SurgicalConsult = new Coding(System, "SurgicalConsult", "Surgical consult");                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Recommend a biopsy as well as consultation with your doctor to determine if surgery is the best plan of action for your diagnosis.
		/// 
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SurgicalConsultAndBiopsy = new Coding(System, "SurgicalConsultAndBiopsy", "Surgical consult and biopsy");       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// The recommendation is for a surgical evaluation.
		/// 
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_SurgicalEvaluation = new Coding(System, "SurgicalEvaluation", "Surgical evaluation");                           // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// The recommendation is for a surgical excision.
		/// 
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_SurgicalExcision = new Coding(System, "SurgicalExcision", "Surgical excision");                                 // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// The recommendation is for a surgical oncologic evaluation.
		/// 
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_SurgicalOncologicEvaluation = new Coding(System, "SurgicalOncologicEvaluation", "Surgical oncologic evaluation");// CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// The recommendation is for a surgical oncologic consult.
		/// 
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_SurgicalOncologicalConsult = new Coding(System, "SurgicalOncologicalConsult", "Surgical oncological consult");  // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A tangential view is recommended via Ultrasound.
		/// Tangential views are useful to differentiate intracutaneous radiopaque particles in a tattoo from intraparenchymal microcalcifications.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_TangentialView = new Coding(System, "TangentialView", "Tangential view");                                       // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Tangential views are recommended via Ultrasound.
		/// Tangential views are useful to differentiate intracutaneous radiopaque particles in a tattoo from intraparenchymal microcalcifications.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_TangentialViews = new Coding(System, "TangentialViews", "Tangential views");                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG MRI NM.
		/// </summary>
		public static Coding Code_Ultrasound = new Coding(System, "Ultrasound", "Ultrasound");                                                    // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Ultrasound2ndLook = new Coding(System, "Ultrasound2ndLook", "Ultrasound 2nd Look");                             // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Ultrasound3MonthFollowUp = new Coding(System, "Ultrasound3MonthFollow-up", "Ultrasound 3 month follow-up");     // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Ultrasound6MonthFollowUp = new Coding(System, "Ultrasound6MonthFollow-up", "Ultrasound 6 month follow-up");     // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_UltrasoundGuidedBx = new Coding(System, "UltrasoundGuidedBx", "Ultrasound guided bx");                          // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_UltrasoundLocationAndSurgicalBiopsy = new Coding(System, "UltrasoundLocationAndSurgicalBiopsy", "Ultrasound location and surgical biopsy");// CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_UltrasoundWithPossibleAddlitonalViews = new Coding(System, "UltrasoundWithPossibleAddlitonalViews", "Ultrasound with possible addlitonal views");// CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_UnspecifiedOther = new Coding(System, "Unspecified/Other", "Unspecified / other");                              // CSBuilder.cs:433
		                                                                                                                                          // CSBuilder.cs:419
		/// <summary>
		/// A vacuum biopsy is recommended.
		/// A vacuum assisted biopsy is a way of removing an area of abnormal cells from the breast tissue.
		/// A doctor or nurse uses a special needle attached to a vacuum device to remove the cells.
		/// 
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_VacuumBx = new Coding(System, "VacuumBx", "Vacuum Bx");                                                         // CSBuilder.cs:433
		//- Fields
	}
}
