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
	public class RecommendationsVS                                                                                                             // CSBuilder.cs:331
	//- Header
	{
		//+ Fields
		/// <summary>
		/// This class creates a type for codings of this class, that implicitly converts to Coding
		/// Allows type checking for these codes.
		/// </summary>
		public class TCoding                                                                                                                      // CSBuilder.cs:352
		{                                                                                                                                         // CSBuilder.cs:353
		    Coding value;                                                                                                                         // CSBuilder.cs:354
		    public static implicit operator Coding(TCoding tCode)                                                                                 // CSBuilder.cs:355
		    {                                                                                                                                     // CSBuilder.cs:356
		        return tCode.value;                                                                                                               // CSBuilder.cs:357
		    }                                                                                                                                     // CSBuilder.cs:358
		                                                                                                                                          // CSBuilder.cs:359
		    public TCoding(Coding value)                                                                                                          // CSBuilder.cs:360
		    {                                                                                                                                     // CSBuilder.cs:361
		        this.value= value;                                                                                                                // CSBuilder.cs:362
		    }                                                                                                                                     // CSBuilder.cs:363
		}                                                                                                                                         // CSBuilder.cs:364
		public TCoding Code_3DImaging = new TCoding(RecommendationsCodeSystemCS.Code_3DImaging);                                                  // CSBuilder.cs:382
		public TCoding Code_3DSpotCC = new TCoding(RecommendationsCodeSystemCS.Code_3DSpotCC);                                                    // CSBuilder.cs:382
		public TCoding Code_3DSpotLM = new TCoding(RecommendationsCodeSystemCS.Code_3DSpotLM);                                                    // CSBuilder.cs:382
		public TCoding Code_3DSpotML = new TCoding(RecommendationsCodeSystemCS.Code_3DSpotML);                                                    // CSBuilder.cs:382
		public TCoding Code_3DSpotMLO = new TCoding(RecommendationsCodeSystemCS.Code_3DSpotMLO);                                                  // CSBuilder.cs:382
		public TCoding Code_AdditionalViews = new TCoding(RecommendationsCodeSystemCS.Code_AdditionalViews);                                      // CSBuilder.cs:382
		public TCoding Code_AddlitionalViewsWithPossibleUltrasound = new TCoding(RecommendationsCodeSystemCS.Code_AddlitionalViewsWithPossibleUltrasound);// CSBuilder.cs:382
		public TCoding Code_AxillaView = new TCoding(RecommendationsCodeSystemCS.Code_AxillaView);                                                // CSBuilder.cs:382
		public TCoding Code_AxillaryTailView = new TCoding(RecommendationsCodeSystemCS.Code_AxillaryTailView);                                    // CSBuilder.cs:382
		public TCoding Code_Biopsy = new TCoding(RecommendationsCodeSystemCS.Code_Biopsy);                                                        // CSBuilder.cs:382
		public TCoding Code_BiopsyBaseOnClinical = new TCoding(RecommendationsCodeSystemCS.Code_BiopsyBaseOnClinical);                            // CSBuilder.cs:382
		public TCoding Code_CaudocranialView = new TCoding(RecommendationsCodeSystemCS.Code_CaudocranialView);                                    // CSBuilder.cs:382
		public TCoding Code_CCWithCompressionView = new TCoding(RecommendationsCodeSystemCS.Code_CCWithCompressionView);                          // CSBuilder.cs:382
		public TCoding Code_CCWithMagnificationView = new TCoding(RecommendationsCodeSystemCS.Code_CCWithMagnificationView);                      // CSBuilder.cs:382
		public TCoding Code_CleavageView = new TCoding(RecommendationsCodeSystemCS.Code_CleavageView);                                            // CSBuilder.cs:382
		public TCoding Code_ClinicalConsultation = new TCoding(RecommendationsCodeSystemCS.Code_ClinicalConsultation);                            // CSBuilder.cs:382
		public TCoding Code_ClinicalCorrelation = new TCoding(RecommendationsCodeSystemCS.Code_ClinicalCorrelation);                              // CSBuilder.cs:382
		public TCoding Code_ClinicalFollowUp = new TCoding(RecommendationsCodeSystemCS.Code_ClinicalFollowUp);                                    // CSBuilder.cs:382
		public TCoding Code_CompareToPriorExams = new TCoding(RecommendationsCodeSystemCS.Code_CompareToPriorExams);                              // CSBuilder.cs:382
		public TCoding Code_CompressionViews = new TCoding(RecommendationsCodeSystemCS.Code_CompressionViews);                                    // CSBuilder.cs:382
		public TCoding Code_ConeCompression = new TCoding(RecommendationsCodeSystemCS.Code_ConeCompression);                                      // CSBuilder.cs:382
		public TCoding Code_CoreBiopsy = new TCoding(RecommendationsCodeSystemCS.Code_CoreBiopsy);                                                // CSBuilder.cs:382
		public TCoding Code_CraniocaudalView = new TCoding(RecommendationsCodeSystemCS.Code_CraniocaudalView);                                    // CSBuilder.cs:382
		public TCoding Code_Cryoablation = new TCoding(RecommendationsCodeSystemCS.Code_Cryoablation);                                            // CSBuilder.cs:382
		public TCoding Code_CystAspiration = new TCoding(RecommendationsCodeSystemCS.Code_CystAspiration);                                        // CSBuilder.cs:382
		public TCoding Code_CystAspirationForRelief = new TCoding(RecommendationsCodeSystemCS.Code_CystAspirationForRelief);                      // CSBuilder.cs:382
		public TCoding Code_DiagnosticAspiration = new TCoding(RecommendationsCodeSystemCS.Code_DiagnosticAspiration);                            // CSBuilder.cs:382
		public TCoding Code_DiagnosticMammogram = new TCoding(RecommendationsCodeSystemCS.Code_DiagnosticMammogram);                              // CSBuilder.cs:382
		public TCoding Code_DrainageTube = new TCoding(RecommendationsCodeSystemCS.Code_DrainageTube);                                            // CSBuilder.cs:382
		public TCoding Code_Ductography = new TCoding(RecommendationsCodeSystemCS.Code_Ductography);                                              // CSBuilder.cs:382
		public TCoding Code_ExaggeratedCCViews = new TCoding(RecommendationsCodeSystemCS.Code_ExaggeratedCCViews);                                // CSBuilder.cs:382
		public TCoding Code_FNABiopsy = new TCoding(RecommendationsCodeSystemCS.Code_FNABiopsy);                                                  // CSBuilder.cs:382
		public TCoding Code_FollowUp = new TCoding(RecommendationsCodeSystemCS.Code_FollowUp);                                                    // CSBuilder.cs:382
		public TCoding Code_Followup3Months = new TCoding(RecommendationsCodeSystemCS.Code_Followup3Months);                                      // CSBuilder.cs:382
		public TCoding Code_Followup6Months = new TCoding(RecommendationsCodeSystemCS.Code_Followup6Months);                                      // CSBuilder.cs:382
		public TCoding Code_IfPreviousShowNoChange = new TCoding(RecommendationsCodeSystemCS.Code_IfPreviousShowNoChange);                        // CSBuilder.cs:382
		public TCoding Code_LateralMagnificaionView = new TCoding(RecommendationsCodeSystemCS.Code_LateralMagnificaionView);                      // CSBuilder.cs:382
		public TCoding Code_LateralMedialView = new TCoding(RecommendationsCodeSystemCS.Code_LateralMedialView);                                  // CSBuilder.cs:382
		public TCoding Code_LateralView = new TCoding(RecommendationsCodeSystemCS.Code_LateralView);                                              // CSBuilder.cs:382
		public TCoding Code_LateralWithCompressionView = new TCoding(RecommendationsCodeSystemCS.Code_LateralWithCompressionView);                // CSBuilder.cs:382
		public TCoding Code_LateromedialOblique = new TCoding(RecommendationsCodeSystemCS.Code_LateromedialOblique);                              // CSBuilder.cs:382
		public TCoding Code_LateromedialView = new TCoding(RecommendationsCodeSystemCS.Code_LateromedialView);                                    // CSBuilder.cs:382
		public TCoding Code_LymphNodeAssessment = new TCoding(RecommendationsCodeSystemCS.Code_LymphNodeAssessment);                              // CSBuilder.cs:382
		public TCoding Code_MagnificationViews = new TCoding(RecommendationsCodeSystemCS.Code_MagnificationViews);                                // CSBuilder.cs:382
		public TCoding Code_Mammogram = new TCoding(RecommendationsCodeSystemCS.Code_Mammogram);                                                  // CSBuilder.cs:382
		public TCoding Code_Mammogram3MonthFollowUp = new TCoding(RecommendationsCodeSystemCS.Code_Mammogram3MonthFollowUp);                      // CSBuilder.cs:382
		public TCoding Code_Mammogram6MonthFollowUp = new TCoding(RecommendationsCodeSystemCS.Code_Mammogram6MonthFollowUp);                      // CSBuilder.cs:382
		public TCoding Code_MammogramAndUltrasound3MonthFollowUp = new TCoding(RecommendationsCodeSystemCS.Code_MammogramAndUltrasound3MonthFollowUp);// CSBuilder.cs:382
		public TCoding Code_MammogramAndUltrasound6MonthFollowUp = new TCoding(RecommendationsCodeSystemCS.Code_MammogramAndUltrasound6MonthFollowUp);// CSBuilder.cs:382
		public TCoding Code_MediolateralObliqueView = new TCoding(RecommendationsCodeSystemCS.Code_MediolateralObliqueView);                      // CSBuilder.cs:382
		public TCoding Code_MediolateralView = new TCoding(RecommendationsCodeSystemCS.Code_MediolateralView);                                    // CSBuilder.cs:382
		public TCoding Code_MLOWithCompressionView = new TCoding(RecommendationsCodeSystemCS.Code_MLOWithCompressionView);                        // CSBuilder.cs:382
		public TCoding Code_MLOWithMagnificationView = new TCoding(RecommendationsCodeSystemCS.Code_MLOWithMagnificationView);                    // CSBuilder.cs:382
		public TCoding Code_MRI = new TCoding(RecommendationsCodeSystemCS.Code_MRI);                                                              // CSBuilder.cs:382
		public TCoding Code_MRIBiopsy = new TCoding(RecommendationsCodeSystemCS.Code_MRIBiopsy);                                                  // CSBuilder.cs:382
		public TCoding Code_MRIFollowUp = new TCoding(RecommendationsCodeSystemCS.Code_MRIFollowUp);                                              // CSBuilder.cs:382
		public TCoding Code_NeedleLocationAndSurgicalBiopsy = new TCoding(RecommendationsCodeSystemCS.Code_NeedleLocationAndSurgicalBiopsy);      // CSBuilder.cs:382
		public TCoding Code_NippleInProfileView = new TCoding(RecommendationsCodeSystemCS.Code_NippleInProfileView);                              // CSBuilder.cs:382
		public TCoding Code_OffAngleCCView = new TCoding(RecommendationsCodeSystemCS.Code_OffAngleCCView);                                        // CSBuilder.cs:382
		public TCoding Code_OffAngleMLOView = new TCoding(RecommendationsCodeSystemCS.Code_OffAngleMLOView);                                      // CSBuilder.cs:382
		public TCoding Code_PossStereotacticBx = new TCoding(RecommendationsCodeSystemCS.Code_PossStereotacticBx);                                // CSBuilder.cs:382
		public TCoding Code_PossibleCoreBiopsy = new TCoding(RecommendationsCodeSystemCS.Code_PossibleCoreBiopsy);                                // CSBuilder.cs:382
		public TCoding Code_PossibleDiagnosticMammogram = new TCoding(RecommendationsCodeSystemCS.Code_PossibleDiagnosticMammogram);              // CSBuilder.cs:382
		public TCoding Code_PossibleStereotacticVacuumBiopsy = new TCoding(RecommendationsCodeSystemCS.Code_PossibleStereotacticVacuumBiopsy);    // CSBuilder.cs:382
		public TCoding Code_PossibleSurgicalConsult = new TCoding(RecommendationsCodeSystemCS.Code_PossibleSurgicalConsult);                      // CSBuilder.cs:382
		public TCoding Code_PossibleSurgicalEvaluation = new TCoding(RecommendationsCodeSystemCS.Code_PossibleSurgicalEvaluation);                // CSBuilder.cs:382
		public TCoding Code_PossibleUltrasound = new TCoding(RecommendationsCodeSystemCS.Code_PossibleUltrasound);                                // CSBuilder.cs:382
		public TCoding Code_PossibleUltrasoundGuidedBiopsy = new TCoding(RecommendationsCodeSystemCS.Code_PossibleUltrasoundGuidedBiopsy);        // CSBuilder.cs:382
		public TCoding Code_PossibleVacuumBiopsy = new TCoding(RecommendationsCodeSystemCS.Code_PossibleVacuumBiopsy);                            // CSBuilder.cs:382
		public TCoding Code_RepeatCCView = new TCoding(RecommendationsCodeSystemCS.Code_RepeatCCView);                                            // CSBuilder.cs:382
		public TCoding Code_RepeatMLOView = new TCoding(RecommendationsCodeSystemCS.Code_RepeatMLOView);                                          // CSBuilder.cs:382
		public TCoding Code_RolledLateralView = new TCoding(RecommendationsCodeSystemCS.Code_RolledLateralView);                                  // CSBuilder.cs:382
		public TCoding Code_RolledMedialView = new TCoding(RecommendationsCodeSystemCS.Code_RolledMedialView);                                    // CSBuilder.cs:382
		public TCoding Code_ScintiBiopsy = new TCoding(RecommendationsCodeSystemCS.Code_ScintiBiopsy);                                            // CSBuilder.cs:382
		public TCoding Code_Scintimammography = new TCoding(RecommendationsCodeSystemCS.Code_Scintimammography);                                  // CSBuilder.cs:382
		public TCoding Code_SpotCompression = new TCoding(RecommendationsCodeSystemCS.Code_SpotCompression);                                      // CSBuilder.cs:382
		public TCoding Code_SpotMagnificationViews = new TCoding(RecommendationsCodeSystemCS.Code_SpotMagnificationViews);                        // CSBuilder.cs:382
		public TCoding Code_StereotacticBx = new TCoding(RecommendationsCodeSystemCS.Code_StereotacticBx);                                        // CSBuilder.cs:382
		public TCoding Code_SuperolateralIOView = new TCoding(RecommendationsCodeSystemCS.Code_SuperolateralIOView);                              // CSBuilder.cs:382
		public TCoding Code_SurgicalBiopsy = new TCoding(RecommendationsCodeSystemCS.Code_SurgicalBiopsy);                                        // CSBuilder.cs:382
		public TCoding Code_SurgicalConsult = new TCoding(RecommendationsCodeSystemCS.Code_SurgicalConsult);                                      // CSBuilder.cs:382
		public TCoding Code_SurgicalConsultAndBiopsy = new TCoding(RecommendationsCodeSystemCS.Code_SurgicalConsultAndBiopsy);                    // CSBuilder.cs:382
		public TCoding Code_SurgicalEvaluation = new TCoding(RecommendationsCodeSystemCS.Code_SurgicalEvaluation);                                // CSBuilder.cs:382
		public TCoding Code_SurgicalExcision = new TCoding(RecommendationsCodeSystemCS.Code_SurgicalExcision);                                    // CSBuilder.cs:382
		public TCoding Code_SurgicalOncologicEvaluation = new TCoding(RecommendationsCodeSystemCS.Code_SurgicalOncologicEvaluation);              // CSBuilder.cs:382
		public TCoding Code_SurgicalOncologicalConsult = new TCoding(RecommendationsCodeSystemCS.Code_SurgicalOncologicalConsult);                // CSBuilder.cs:382
		public TCoding Code_TangentialView = new TCoding(RecommendationsCodeSystemCS.Code_TangentialView);                                        // CSBuilder.cs:382
		public TCoding Code_TangentialViews = new TCoding(RecommendationsCodeSystemCS.Code_TangentialViews);                                      // CSBuilder.cs:382
		public TCoding Code_Ultrasound = new TCoding(RecommendationsCodeSystemCS.Code_Ultrasound);                                                // CSBuilder.cs:382
		public TCoding Code_Ultrasound2ndLook = new TCoding(RecommendationsCodeSystemCS.Code_Ultrasound2ndLook);                                  // CSBuilder.cs:382
		public TCoding Code_Ultrasound3MonthFollowUp = new TCoding(RecommendationsCodeSystemCS.Code_Ultrasound3MonthFollowUp);                    // CSBuilder.cs:382
		public TCoding Code_Ultrasound6MonthFollowUp = new TCoding(RecommendationsCodeSystemCS.Code_Ultrasound6MonthFollowUp);                    // CSBuilder.cs:382
		public TCoding Code_UltrasoundGuidedBx = new TCoding(RecommendationsCodeSystemCS.Code_UltrasoundGuidedBx);                                // CSBuilder.cs:382
		public TCoding Code_UltrasoundLocationAndSurgicalBiopsy = new TCoding(RecommendationsCodeSystemCS.Code_UltrasoundLocationAndSurgicalBiopsy);// CSBuilder.cs:382
		public TCoding Code_UltrasoundWithPossibleAddlitonalViews = new TCoding(RecommendationsCodeSystemCS.Code_UltrasoundWithPossibleAddlitonalViews);// CSBuilder.cs:382
		public TCoding Code_UnspecifiedOther = new TCoding(RecommendationsCodeSystemCS.Code_UnspecifiedOther);                                    // CSBuilder.cs:382
		public TCoding Code_VacuumBx = new TCoding(RecommendationsCodeSystemCS.Code_VacuumBx);                                                    // CSBuilder.cs:382
		                                                                                                                                          // CSBuilder.cs:337
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:338
		                                                                                                                                          // CSBuilder.cs:339
		public RecommendationsVS()                                                                                                                // CSBuilder.cs:340
		{                                                                                                                                         // CSBuilder.cs:341
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:342
		    this.Members.Add(this.Code_3DImaging);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_3DSpotCC);                                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_3DSpotLM);                                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_3DSpotML);                                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_3DSpotMLO);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_AdditionalViews);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_AddlitionalViewsWithPossibleUltrasound);                                                                   // CSBuilder.cs:385
		    this.Members.Add(this.Code_AxillaView);                                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_AxillaryTailView);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_Biopsy);                                                                                                   // CSBuilder.cs:385
		    this.Members.Add(this.Code_BiopsyBaseOnClinical);                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_CaudocranialView);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_CCWithCompressionView);                                                                                    // CSBuilder.cs:385
		    this.Members.Add(this.Code_CCWithMagnificationView);                                                                                  // CSBuilder.cs:385
		    this.Members.Add(this.Code_CleavageView);                                                                                             // CSBuilder.cs:385
		    this.Members.Add(this.Code_ClinicalConsultation);                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_ClinicalCorrelation);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_ClinicalFollowUp);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_CompareToPriorExams);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_CompressionViews);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_ConeCompression);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_CoreBiopsy);                                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_CraniocaudalView);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_Cryoablation);                                                                                             // CSBuilder.cs:385
		    this.Members.Add(this.Code_CystAspiration);                                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_CystAspirationForRelief);                                                                                  // CSBuilder.cs:385
		    this.Members.Add(this.Code_DiagnosticAspiration);                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_DiagnosticMammogram);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_DrainageTube);                                                                                             // CSBuilder.cs:385
		    this.Members.Add(this.Code_Ductography);                                                                                              // CSBuilder.cs:385
		    this.Members.Add(this.Code_ExaggeratedCCViews);                                                                                       // CSBuilder.cs:385
		    this.Members.Add(this.Code_FNABiopsy);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_FollowUp);                                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_Followup3Months);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_Followup6Months);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_IfPreviousShowNoChange);                                                                                   // CSBuilder.cs:385
		    this.Members.Add(this.Code_LateralMagnificaionView);                                                                                  // CSBuilder.cs:385
		    this.Members.Add(this.Code_LateralMedialView);                                                                                        // CSBuilder.cs:385
		    this.Members.Add(this.Code_LateralView);                                                                                              // CSBuilder.cs:385
		    this.Members.Add(this.Code_LateralWithCompressionView);                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_LateromedialOblique);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_LateromedialView);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_LymphNodeAssessment);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_MagnificationViews);                                                                                       // CSBuilder.cs:385
		    this.Members.Add(this.Code_Mammogram);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_Mammogram3MonthFollowUp);                                                                                  // CSBuilder.cs:385
		    this.Members.Add(this.Code_Mammogram6MonthFollowUp);                                                                                  // CSBuilder.cs:385
		    this.Members.Add(this.Code_MammogramAndUltrasound3MonthFollowUp);                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_MammogramAndUltrasound6MonthFollowUp);                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_MediolateralObliqueView);                                                                                  // CSBuilder.cs:385
		    this.Members.Add(this.Code_MediolateralView);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_MLOWithCompressionView);                                                                                   // CSBuilder.cs:385
		    this.Members.Add(this.Code_MLOWithMagnificationView);                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_MRI);                                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_MRIBiopsy);                                                                                                // CSBuilder.cs:385
		    this.Members.Add(this.Code_MRIFollowUp);                                                                                              // CSBuilder.cs:385
		    this.Members.Add(this.Code_NeedleLocationAndSurgicalBiopsy);                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_NippleInProfileView);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_OffAngleCCView);                                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_OffAngleMLOView);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_PossStereotacticBx);                                                                                       // CSBuilder.cs:385
		    this.Members.Add(this.Code_PossibleCoreBiopsy);                                                                                       // CSBuilder.cs:385
		    this.Members.Add(this.Code_PossibleDiagnosticMammogram);                                                                              // CSBuilder.cs:385
		    this.Members.Add(this.Code_PossibleStereotacticVacuumBiopsy);                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_PossibleSurgicalConsult);                                                                                  // CSBuilder.cs:385
		    this.Members.Add(this.Code_PossibleSurgicalEvaluation);                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_PossibleUltrasound);                                                                                       // CSBuilder.cs:385
		    this.Members.Add(this.Code_PossibleUltrasoundGuidedBiopsy);                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_PossibleVacuumBiopsy);                                                                                     // CSBuilder.cs:385
		    this.Members.Add(this.Code_RepeatCCView);                                                                                             // CSBuilder.cs:385
		    this.Members.Add(this.Code_RepeatMLOView);                                                                                            // CSBuilder.cs:385
		    this.Members.Add(this.Code_RolledLateralView);                                                                                        // CSBuilder.cs:385
		    this.Members.Add(this.Code_RolledMedialView);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_ScintiBiopsy);                                                                                             // CSBuilder.cs:385
		    this.Members.Add(this.Code_Scintimammography);                                                                                        // CSBuilder.cs:385
		    this.Members.Add(this.Code_SpotCompression);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_SpotMagnificationViews);                                                                                   // CSBuilder.cs:385
		    this.Members.Add(this.Code_StereotacticBx);                                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_SuperolateralIOView);                                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_SurgicalBiopsy);                                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_SurgicalConsult);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_SurgicalConsultAndBiopsy);                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_SurgicalEvaluation);                                                                                       // CSBuilder.cs:385
		    this.Members.Add(this.Code_SurgicalExcision);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_SurgicalOncologicEvaluation);                                                                              // CSBuilder.cs:385
		    this.Members.Add(this.Code_SurgicalOncologicalConsult);                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_TangentialView);                                                                                           // CSBuilder.cs:385
		    this.Members.Add(this.Code_TangentialViews);                                                                                          // CSBuilder.cs:385
		    this.Members.Add(this.Code_Ultrasound);                                                                                               // CSBuilder.cs:385
		    this.Members.Add(this.Code_Ultrasound2ndLook);                                                                                        // CSBuilder.cs:385
		    this.Members.Add(this.Code_Ultrasound3MonthFollowUp);                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_Ultrasound6MonthFollowUp);                                                                                 // CSBuilder.cs:385
		    this.Members.Add(this.Code_UltrasoundGuidedBx);                                                                                       // CSBuilder.cs:385
		    this.Members.Add(this.Code_UltrasoundLocationAndSurgicalBiopsy);                                                                      // CSBuilder.cs:385
		    this.Members.Add(this.Code_UltrasoundWithPossibleAddlitonalViews);                                                                    // CSBuilder.cs:385
		    this.Members.Add(this.Code_UnspecifiedOther);                                                                                         // CSBuilder.cs:385
		    this.Members.Add(this.Code_VacuumBx);                                                                                                 // CSBuilder.cs:385
		}                                                                                                                                         // CSBuilder.cs:344
		//- Fields
	}
}