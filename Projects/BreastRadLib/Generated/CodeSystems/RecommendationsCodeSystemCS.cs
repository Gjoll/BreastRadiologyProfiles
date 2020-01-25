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
	public class RecommendationsCodeSystemCS                                                                                                   // CSBuilder.cs:380
	//- Header
	{
		//+ Fields
		const string System = "http://hl7.org/fhir/us/breast-radiology/CodeSystem/RecommendationsCodeSystemCS";                                   // CSBuilder.cs:384
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] 3D Imaging
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_3DImaging = new Coding(System, "3DImaging", "3D Imaging");                                                      // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] 3D spot CC
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_3DSpotCC = new Coding(System, "3DSpotCC", "3D spot CC");                                                        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] 3D spot LM
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_3DSpotLM = new Coding(System, "3DSpotLM", "3D spot LM");                                                        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] 3D spot ML
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_3DSpotML = new Coding(System, "3DSpotML", "3D spot ML");                                                        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] 3D spot MLO
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_3DSpotMLO = new Coding(System, "3DSpotMLO", "3D spot MLO");                                                     // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Additional views
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_AdditionalViews = new Coding(System, "AdditionalViews", "Additional views");                                    // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Addlitional views with possible ultrasound
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_AddlitionalViewsWithPossibleUltrasound = new Coding(System, "AddlitionalViewsWithPossibleUltrasound", "Addlitional views with possible ultrasound");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Axilla view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_AxillaView = new Coding(System, "AxillaView", "Axilla view");                                                   // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Axillary tail view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_AxillaryTailView = new Coding(System, "AxillaryTailView", "Axillary tail view");                                // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Biopsy
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Biopsy = new Coding(System, "Biopsy", "Biopsy");                                                                // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Biopsy base on clinical
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_BiopsyBaseOnClinical = new Coding(System, "BiopsyBaseOnClinical", "Biopsy base on clinical");                   // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Caudocranial view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CaudocranialView = new Coding(System, "CaudocranialView", "Caudocranial view");                                 // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] CC with compression view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CCWithCompressionView = new Coding(System, "CCWithCompressionView", "CC with compression view");                // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] CC with magnification view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CCWithMagnificationView = new Coding(System, "CCWithMagnificationView", "CC with magnification view");          // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Cleavage view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CleavageView = new Coding(System, "CleavageView", "Cleavage view");                                             // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Clinical consultation
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_ClinicalConsultation = new Coding(System, "ClinicalConsultation", "Clinical consultation");                     // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Clinical correlation
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_ClinicalCorrelation = new Coding(System, "ClinicalCorrelation", "Clinical correlation");                        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Clinical follow-up
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_ClinicalFollowUp = new Coding(System, "ClinicalFollow-up", "Clinical follow-up");                               // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Compare to prior exams
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CompareToPriorExams = new Coding(System, "CompareToPriorExams", "Compare to prior exams");                      // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Compression views
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_CompressionViews = new Coding(System, "CompressionViews", "Compression views");                                 // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Cone compression
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_ConeCompression = new Coding(System, "ConeCompression", "Cone compression");                                    // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Core Biopsy
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_CoreBiopsy = new Coding(System, "CoreBiopsy", "Core Biopsy");                                                   // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Craniocaudal view
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_CraniocaudalView = new Coding(System, "CraniocaudalView", "Craniocaudal view");                                 // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Cryoablation
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Cryoablation = new Coding(System, "Cryoablation", "Cryoablation");                                              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Cyst aspiration
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_CystAspiration = new Coding(System, "CystAspiration", "Cyst aspiration");                                       // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Cyst aspiration for relief
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_CystAspirationForRelief = new Coding(System, "CystAspirationForRelief", "Cyst aspiration for relief");          // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Diagnostic aspiration
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_DiagnosticAspiration = new Coding(System, "DiagnosticAspiration", "Diagnostic aspiration");                     // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Diagnostic Mammogram
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_DiagnosticMammogram = new Coding(System, "DiagnosticMammogram", "Diagnostic Mammogram");                        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Drainage tube
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_DrainageTube = new Coding(System, "DrainageTube", "Drainage tube");                                             // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Ductography
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Ductography = new Coding(System, "Ductography", "Ductography");                                                 // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Exaggerated CC views
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_ExaggeratedCCViews = new Coding(System, "ExaggeratedCCViews", "Exaggerated CC views");                          // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] FNA biopsy
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_FNABiopsy = new Coding(System, "FNABiopsy", "FNA biopsy");                                                      // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Follow-up
		/// Valid for the following modalities: US.
		/// </summary>
		public static Coding Code_FollowUp = new Coding(System, "Follow-up", "Follow-up");                                                        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Followup 3 months
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Followup3Months = new Coding(System, "Followup3Months", "Followup 3 months");                                   // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Followup 6 months
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Followup6Months = new Coding(System, "Followup6Months", "Followup 6 months");                                   // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] If previous show no change
		/// Valid for the following modalities: US MRI.
		/// </summary>
		public static Coding Code_IfPreviousShowNoChange = new Coding(System, "IfPreviousShowNoChange", "If previous show no change");            // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Lateral magnificaion view
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_LateralMagnificaionView = new Coding(System, "LateralMagnificaionView", "Lateral magnificaion view");           // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Lateral medial view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateralMedialView = new Coding(System, "LateralMedialView", "Lateral medial view");                             // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Lateral view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateralView = new Coding(System, "LateralView", "Lateral view");                                                // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Lateral with compression view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateralWithCompressionView = new Coding(System, "LateralWithCompressionView", "Lateral with compression view"); // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Lateromedial oblique SPELLING
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateromedialObliqueSPELLING = new Coding(System, "LateromedialObliqueSPELLING", "Lateromedial oblique SPELLING");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Lateromedial view SPELLING
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateromedialViewSPELLING = new Coding(System, "LateromedialViewSPELLING", "Lateromedial view SPELLING");        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Lymph node assessment
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_LymphNodeAssessment = new Coding(System, "LymphNodeAssessment", "Lymph node assessment");                       // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Magnification views
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_MagnificationViews = new Coding(System, "MagnificationViews", "Magnification views");                           // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Mammogram
		/// Valid for the following modalities: MRI.
		/// </summary>
		public static Coding Code_Mammogram = new Coding(System, "Mammogram", "Mammogram");                                                       // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Mammogram 3 month follow-up
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Mammogram3MonthFollowUp = new Coding(System, "Mammogram3MonthFollow-up", "Mammogram 3 month follow-up");        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Mammogram 6 month follow-up
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Mammogram6MonthFollowUp = new Coding(System, "Mammogram6MonthFollow-up", "Mammogram 6 month follow-up");        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Mammogram and ultrasound 3 month follow-up
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MammogramAndUltrasound3MonthFollowUp = new Coding(System, "MammogramAndUltrasound3MonthFollow-up", "Mammogram and ultrasound 3 month follow-up");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Mammogram and ultrasound 6 month follow-up
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MammogramAndUltrasound6MonthFollowUp = new Coding(System, "MammogramAndUltrasound6MonthFollow-up", "Mammogram and ultrasound 6 month follow-up");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Mediolateral oblique view
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MediolateralObliqueView = new Coding(System, "MediolateralObliqueView", "Mediolateral oblique view");           // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Mediolateral view
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_MediolateralView = new Coding(System, "MediolateralView", "Mediolateral view");                                 // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] MLO with compression view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MLOWithCompressionView = new Coding(System, "MLOWithCompressionView", "MLO with compression view");             // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] MLO with magnification view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MLOWithMagnificationView = new Coding(System, "MLOWithMagnificationView", "MLO with magnification view");       // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] MRI
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_MRI = new Coding(System, "MRI", "MRI");                                                                         // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] MRI biopsy
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_MRIBiopsy = new Coding(System, "MRIBiopsy", "MRI biopsy");                                                      // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] MRI follow-up
		/// Valid for the following modalities: MRI NM.
		/// </summary>
		public static Coding Code_MRIFollowUp = new Coding(System, "MRIFollow-up", "MRI follow-up");                                              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Needle location and surgical biopsy
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_NeedleLocationAndSurgicalBiopsy = new Coding(System, "NeedleLocationAndSurgicalBiopsy", "Needle location and surgical biopsy");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Nipple in profile view
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_NippleInProfileView = new Coding(System, "NippleInProfileView", "Nipple in profile view");                      // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Off angle CC view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_OffAngleCCView = new Coding(System, "OffAngleCCView", "Off angle CC view");                                     // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Off angle MLO view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_OffAngleMLOView = new Coding(System, "OffAngleMLOView", "Off angle MLO view");                                  // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Poss. Stereotactic Bx
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossStereotacticBx = new Coding(System, "Poss.StereotacticBx", "Poss. Stereotactic Bx");                        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Possible core biopsy
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_PossibleCoreBiopsy = new Coding(System, "PossibleCoreBiopsy", "Possible core biopsy");                          // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Possible Diagnostic Mammogram
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossibleDiagnosticMammogram = new Coding(System, "PossibleDiagnosticMammogram", "Possible Diagnostic Mammogram");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Possible stereotactic vacuum biopsy
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossibleStereotacticVacuumBiopsy = new Coding(System, "PossibleStereotacticVacuumBiopsy", "Possible stereotactic vacuum biopsy");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Possible surgical consult
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_PossibleSurgicalConsult = new Coding(System, "PossibleSurgicalConsult", "Possible surgical consult");           // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Possible surgical evaluation
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_PossibleSurgicalEvaluation = new Coding(System, "PossibleSurgicalEvaluation", "Possible surgical evaluation");  // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Possible ultrasound
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossibleUltrasound = new Coding(System, "PossibleUltrasound", "Possible ultrasound");                           // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Possible ultrasound guided biopsy
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossibleUltrasoundGuidedBiopsy = new Coding(System, "PossibleUltrasoundGuidedBiopsy", "Possible ultrasound guided biopsy");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Possible vacuum biopsy
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_PossibleVacuumBiopsy = new Coding(System, "PossibleVacuumBiopsy", "Possible vacuum biopsy");                    // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Repeat CC view
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_RepeatCCView = new Coding(System, "RepeatCCView", "Repeat CC view");                                            // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Repeat MLO view
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_RepeatMLOView = new Coding(System, "RepeatMLOView", "Repeat MLO view");                                         // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Rolled lateral view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_RolledLateralView = new Coding(System, "RolledLateralView", "Rolled lateral view");                             // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Rolled medial view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_RolledMedialView = new Coding(System, "RolledMedialView", "Rolled medial view");                                // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Scinti biopsy
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_ScintiBiopsy = new Coding(System, "ScintiBiopsy", "Scinti biopsy");                                             // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Scintimammography
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_Scintimammography = new Coding(System, "Scintimammography", "Scintimammography");                               // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Spot compression
		/// Valid for the following modalities: MG US NM.
		/// </summary>
		public static Coding Code_SpotCompression = new Coding(System, "SpotCompression", "Spot compression");                                    // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Spot magnification views
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_SpotMagnificationViews = new Coding(System, "SpotMagnificationViews", "Spot magnification views");              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Stereotactic bx
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_StereotacticBx = new Coding(System, "StereotacticBx", "Stereotactic bx");                                       // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Superolateral IO view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_SuperolateralIOView = new Coding(System, "SuperolateralIOView", "Superolateral IO view");                       // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Surgical biopsy
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_SurgicalBiopsy = new Coding(System, "SurgicalBiopsy", "Surgical biopsy");                                       // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Surgical consult
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_SurgicalConsult = new Coding(System, "SurgicalConsult", "Surgical consult");                                    // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Surgical consult and biopsy
		/// Valid for the following modalities: MG US MRI.
		/// </summary>
		public static Coding Code_SurgicalConsultAndBiopsy = new Coding(System, "SurgicalConsultAndBiopsy", "Surgical consult and biopsy");       // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Surgical evaluation
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_SurgicalEvaluation = new Coding(System, "SurgicalEvaluation", "Surgical evaluation");                           // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Surgical excision
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_SurgicalExcision = new Coding(System, "SurgicalExcision", "Surgical excision");                                 // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Surgical oncologic evaluation
		/// Valid for the following modalities: NM.
		/// </summary>
		public static Coding Code_SurgicalOncologicEvaluation = new Coding(System, "SurgicalOncologicEvaluation", "Surgical oncologic evaluation");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Surgical oncological consult
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_SurgicalOncologicalConsult = new Coding(System, "SurgicalOncologicalConsult", "Surgical oncological consult");  // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Tangential view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_TangentialView = new Coding(System, "TangentialView", "Tangential view");                                       // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Tangential views
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_TangentialViews = new Coding(System, "TangentialViews", "Tangential views");                                    // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Ultrasound
		/// Valid for the following modalities: MG MRI NM.
		/// </summary>
		public static Coding Code_Ultrasound = new Coding(System, "Ultrasound", "Ultrasound");                                                    // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Ultrasound 2nd Look
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_Ultrasound2ndLook = new Coding(System, "Ultrasound2ndLook", "Ultrasound 2nd Look");                             // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Ultrasound 3 month follow-up
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Ultrasound3MonthFollowUp = new Coding(System, "Ultrasound3MonthFollow-up", "Ultrasound 3 month follow-up");     // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Ultrasound 6 month follow-up
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_Ultrasound6MonthFollowUp = new Coding(System, "Ultrasound6MonthFollow-up", "Ultrasound 6 month follow-up");     // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Ultrasound guided bx
		/// Valid for the following modalities: MG US MRI NM.
		/// </summary>
		public static Coding Code_UltrasoundGuidedBx = new Coding(System, "UltrasoundGuidedBx", "Ultrasound guided bx");                          // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Ultrasound location and surgical biopsy
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_UltrasoundLocationAndSurgicalBiopsy = new Coding(System, "UltrasoundLocationAndSurgicalBiopsy", "Ultrasound location and surgical biopsy");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Ultrasound with possible addlitonal views
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_UltrasoundWithPossibleAddlitonalViews = new Coding(System, "UltrasoundWithPossibleAddlitonalViews", "Ultrasound with possible addlitonal views");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Unless previous show no change
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_UnlessPreviousShowNoChange = new Coding(System, "UnlessPreviousShowNoChange", "Unless previous show no change");// CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Unspecified - other
		/// Valid for the following modalities: MG.
		/// </summary>
		public static Coding Code_UnspecifiedOther = new Coding(System, "Unspecified-Other", "Unspecified - other");                              // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Vacuum Bx
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_VacuumBx = new Coding(System, "VacuumBx", "Vacuum Bx");                                                         // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Lateromedial oblique
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateromedialOblique = new Coding(System, "LateromedialOblique", "Lateromedial oblique");                        // CSBuilder.cs:410
		                                                                                                                                          // CSBuilder.cs:396
		/// <summary>
		/// [PR] Lateromedial view
		/// Valid for the following modalities: MG US.
		/// </summary>
		public static Coding Code_LateromedialView = new Coding(System, "LateromedialView", "Lateromedial view");                                 // CSBuilder.cs:410
		//- Fields
	}
}
