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
	public class RecommendationsVS                                                                                                             // CSBuilder.cs:336
	//- Header
	{
		//+ Fields
		public List<Coding> Members;                                                                                                              // CSBuilder.cs:340
		                                                                                                                                          // CSBuilder.cs:341
		public RecommendationsVS()                                                                                                                // CSBuilder.cs:342
		{                                                                                                                                         // CSBuilder.cs:343
		    this.Members = new List<Coding>();                                                                                                    // CSBuilder.cs:344
		    this.Members.Add(RecommendationsCodeSystemCS.Code_3DImaging);                                                                         // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_3DSpotCC);                                                                          // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_3DSpotLM);                                                                          // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_3DSpotML);                                                                          // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_3DSpotMLO);                                                                         // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_AdditionalViews);                                                                   // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_AddlitionalViewsWithPossibleUltrasound);                                            // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_AxillaView);                                                                        // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_AxillaryTailView);                                                                  // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Biopsy);                                                                            // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_BiopsyBaseOnClinical);                                                              // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_CaudocranialView);                                                                  // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_CCWithCompressionView);                                                             // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_CCWithMagnificationView);                                                           // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_CleavageView);                                                                      // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_ClinicalConsultation);                                                              // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_ClinicalCorrelation);                                                               // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_ClinicalFollowUp);                                                                  // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_CompareToPriorExams);                                                               // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_CompressionViews);                                                                  // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_ConeCompression);                                                                   // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_CoreBiopsy);                                                                        // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_CraniocaudalView);                                                                  // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Cryoablation);                                                                      // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_CystAspiration);                                                                    // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_CystAspirationForRelief);                                                           // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_DiagnosticAspiration);                                                              // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_DiagnosticMammogram);                                                               // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_DrainageTube);                                                                      // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Ductography);                                                                       // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_ExaggeratedCCViews);                                                                // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_FNABiopsy);                                                                         // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_FollowUp);                                                                          // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Followup3Months);                                                                   // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Followup6Months);                                                                   // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_IfPreviousShowNoChange);                                                            // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_LateralMagnificaionView);                                                           // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_LateralMedialView);                                                                 // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_LateralView);                                                                       // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_LateralWithCompressionView);                                                        // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_LateromedialObliqueSPELLING);                                                       // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_LateromedialViewSPELLING);                                                          // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_LymphNodeAssessment);                                                               // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_MagnificationViews);                                                                // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Mammogram);                                                                         // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Mammogram3MonthFollowUp);                                                           // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Mammogram6MonthFollowUp);                                                           // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_MammogramAndUltrasound3MonthFollowUp);                                              // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_MammogramAndUltrasound6MonthFollowUp);                                              // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_MediolateralObliqueView);                                                           // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_MediolateralView);                                                                  // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_MLOWithCompressionView);                                                            // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_MLOWithMagnificationView);                                                          // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_MRI);                                                                               // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_MRIBiopsy);                                                                         // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_MRIFollowUp);                                                                       // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_NeedleLocationAndSurgicalBiopsy);                                                   // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_NippleInProfileView);                                                               // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_OffAngleCCView);                                                                    // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_OffAngleMLOView);                                                                   // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_PossStereotacticBx);                                                                // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_PossibleCoreBiopsy);                                                                // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_PossibleDiagnosticMammogram);                                                       // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_PossibleStereotacticVacuumBiopsy);                                                  // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_PossibleSurgicalConsult);                                                           // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_PossibleSurgicalEvaluation);                                                        // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_PossibleUltrasound);                                                                // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_PossibleUltrasoundGuidedBiopsy);                                                    // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_PossibleVacuumBiopsy);                                                              // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_RepeatCCView);                                                                      // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_RepeatMLOView);                                                                     // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_RolledLateralView);                                                                 // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_RolledMedialView);                                                                  // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_ScintiBiopsy);                                                                      // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Scintimammography);                                                                 // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_SpotCompression);                                                                   // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_SpotMagnificationViews);                                                            // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_StereotacticBx);                                                                    // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_SuperolateralIOView);                                                               // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_SurgicalBiopsy);                                                                    // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_SurgicalConsult);                                                                   // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_SurgicalConsultAndBiopsy);                                                          // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_SurgicalEvaluation);                                                                // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_SurgicalExcision);                                                                  // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_SurgicalOncologicEvaluation);                                                       // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_SurgicalOncologicalConsult);                                                        // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_TangentialView);                                                                    // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_TangentialViews);                                                                   // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Ultrasound);                                                                        // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Ultrasound2ndLook);                                                                 // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Ultrasound3MonthFollowUp);                                                          // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_Ultrasound6MonthFollowUp);                                                          // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_UltrasoundGuidedBx);                                                                // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_UltrasoundLocationAndSurgicalBiopsy);                                               // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_UltrasoundWithPossibleAddlitonalViews);                                             // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_UnlessPreviousShowNoChange);                                                        // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_UnspecifiedOther);                                                                  // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_VacuumBx);                                                                          // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_LateromedialOblique);                                                               // CSBuilder.cs:362
		    this.Members.Add(RecommendationsCodeSystemCS.Code_LateromedialView);                                                                  // CSBuilder.cs:362
		}                                                                                                                                         // CSBuilder.cs:346
		//- Fields
	}
}
