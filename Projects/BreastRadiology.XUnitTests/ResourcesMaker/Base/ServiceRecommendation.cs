using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using PreFhir;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        SDTaskVar ServiceRecommendation = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("ServiceRecommendation",
                     "Service Recommendation",
                     "Service/Recommendation",
                     ServiceRequestUrl,
                     Group_BaseResources,
                     "Resource")
                     .Description("Service Recommendation",
                         new Markdown()
                            .Paragraph("This resource is a profile of ServiceRequest. It's ServiceRequest.code is bound to a value set of common",
                                        "Breast Radiology Exam recommendations. It is not meant to be a comprehensive list, just a common list.")
                            .Paragraph("The Breast Radiology Report contains references to zero or more recommendations, which may include ServiceRecommendation instances",
                                        "but is not limited to only ServiceRecommendation instances.")
                     )
                     .AddFragRef(Self.HeaderFragment.Value())
                     ;

                s = e.SDef;
                e.IntroDoc
                     .ReviewedStatus(ReviewStatus.NotReviewed)
                     ;

                e.Select("code")
                    .Binding(Self.RecommendationsVS.Value(), BindingStrength.Extensible)
                    ;
            });

        VSTaskVar RecommendationsVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "RecommendationsVS",
                        "Recommendations ValueSet",
                        "Recommendations/ValueSet",
                        "Recommendations value set.",
                        Group_MGCodesVS,
                        Self.RecommendationsCS.Value()
                    )
            );

        CSTaskVar RecommendationsCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "RecommendationsCodeSystemCS",
                        "Recommendations CodeSystem",
                        "Recommendations/CodeSystem",
                        "Recommendations code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            //+ RecommendationsCS
                            // SNOMED Description: Procedure | 450566007 | Digital breast tomosynthesis (Procedure) +
                            new ConceptDef("3DImaging",
                                "3D Imaging",
                                new Definition()
                                    .Line("[PR] 3D Imaging")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier) + SPOT
                            new ConceptDef("3DSpotCC",
                                "3D spot CC",
                                new Definition()
                                    .Line("[PR] 3D spot CC")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399352003 | Lateral-medial projection (Qualifier) + SPOT
                            new ConceptDef("3DSpotLM",
                                "3D spot LM",
                                new Definition()
                                    .Line("[PR] 3D spot LM")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399260004 | Medial-lateral projection (Qualifier) + SPOT
                            new ConceptDef("3DSpotML",
                                "3D spot ML",
                                new Definition()
                                    .Line("[PR] 3D spot ML")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier) + SPOT
                            new ConceptDef("3DSpotMLO",
                                "3D spot MLO",
                                new Definition()
                                    .Line("[PR] 3D spot MLO")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("AdditionalViews",
                                "Additional views",
                                new Definition()
                                    .Line("[PR] Additional views")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 47079000 | Ultrasonography of breast (Procedure)
                            new ConceptDef("AddlitionalViewsWithPossibleUltrasound",
                                "Addlitional views with possible ultrasound",
                                new Definition()
                                    .Line("[PR] Addlitional views with possible ultrasound")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("AxillaView",
                                "Axilla view",
                                new Definition()
                                    .Line("[PR] Axilla view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 442580003 | Axillary tissue mammography view (Qualifier)
                            new ConceptDef("AxillaryTailView",
                                "Axillary tail view",
                                new Definition()
                                    .Line("[PR] Axillary tail view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("Biopsy",
                                "Biopsy",
                                new Definition()
                                    .Line("[PR] Biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("BiopsyBaseOnClinical",
                                "Biopsy base on clinical",
                                new Definition()
                                    .Line("[PR] Biopsy base on clinical")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("CaudocranialView",
                                "Caudocranial view",
                                new Definition()
                                    .Line("[PR] Caudocranial view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure)+ QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)
                            new ConceptDef("CCWithCompressionView",
                                "CC with compression view",
                                new Definition()
                                    .Line("[PR] CC with compression view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241058008 | Mammogram magnification (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)
                            new ConceptDef("CCWithMagnificationView",
                                "CC with magnification view",
                                new Definition()
                                    .Line("[PR] CC with magnification view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399161006 | Cleavage mammography view (Qualifier)
                            new ConceptDef("CleavageView",
                                "Cleavage view",
                                new Definition()
                                    .Line("[PR] Cleavage view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("ClinicalConsultation",
                                "Clinical consultation",
                                new Definition()
                                    .Line("[PR] Clinical consultation")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("ClinicalCorrelation",
                                "Clinical correlation",
                                new Definition()
                                    .Line("[PR] Clinical correlation")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("ClinicalFollow-up",
                                "Clinical follow-up",
                                new Definition()
                                    .Line("[PR] Clinical follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("CompareToPriorExams",
                                "Compare to prior exams",
                                new Definition()
                                    .Line("[PR] Compare to prior exams")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure) 
                            new ConceptDef("CompressionViews",
                                "Compression views",
                                new Definition()
                                    .Line("[PR] Compression views")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure) 
                            new ConceptDef("ConeCompression",
                                "Cone compression",
                                new Definition()
                                    .Line("[PR] Cone compression")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 44578009 | Core needle biopsy of breast (Procedure)
                            new ConceptDef("CoreBiopsy",
                                "Core Biopsy",
                                new Definition()
                                    .Line("[PR] Core Biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)
                            new ConceptDef("CraniocaudalView",
                                "Craniocaudal view",
                                new Definition()
                                    .Line("[PR] Craniocaudal view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Cryoablation",
                                "Cryoablation",
                                new Definition()
                                    .Line("[PR] Cryoablation")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 287572003 | Diagnostic aspiration of breast cyst (Procedure)
                            new ConceptDef("CystAspiration",
                                "Cyst aspiration",
                                new Definition()
                                    .Line("[PR] Cyst aspiration")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 287572003 | Diagnostic aspiration of breast cyst (Procedure)
                            new ConceptDef("CystAspirationForRelief",
                                "Cyst aspiration for relief",
                                new Definition()
                                    .Line("[PR] Cyst aspiration for relief")
                                    .ValidModalities(Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 287572003 | Diagnostic aspiration of breast cyst (Procedure)
                            new ConceptDef("DiagnosticAspiration",
                                "Diagnostic aspiration",
                                new Definition()
                                    .Line("[PR] Diagnostic aspiration")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("DiagnosticMammogram",
                                "Diagnostic Mammogram",
                                new Definition()
                                    .Line("[PR] Diagnostic Mammogram")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("DrainageTube",
                                "Drainage tube",
                                new Definition()
                                    .Line("[PR] Drainage tube")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 420131003 | Fluoroscopic mammary ductography (Procedure) 
                            new ConceptDef("Ductography",
                                "Ductography",
                                new Definition()
                                    .Line("[PR] Ductography")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399265009 | Exaggerated cranio-caudal projection (Qualifier)
                            new ConceptDef("ExaggeratedCCViews",
                                "Exaggerated CC views",
                                new Definition()
                                    .Line("[PR] Exaggerated CC views")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: not matching
                            new ConceptDef("FNABiopsy",
                                "FNA biopsy",
                                new Definition()
                                    .Line("[PR] FNA biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("Follow-up",
                                "Follow-up",
                                new Definition()
                                    .Line("[PR] Follow-up")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("Followup3Months",
                                "Followup 3 months",
                                new Definition()
                                    .Line("[PR] Followup 3 months")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("Followup6Months",
                                "Followup 6 months",
                                new Definition()
                                    .Line("[PR] Followup 6 months")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("IfPreviousShowNoChange",
                                "If previous show no change",
                                new Definition()
                                    .Line("[PR] If previous show no change")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241058008 | Mammogram magnification (Procedure) + QualifierValue | 399067008 | Lateral projection (Qualifier)
                            new ConceptDef("LateralMagnificaionView",
                                "Lateral magnificaion view",
                                new Definition()
                                    .Line("[PR] Lateral magnificaion view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399352003 | Lateral-medial projection (Qualifier)
                            new ConceptDef("LateralMedialView",
                                "Lateral medial view",
                                new Definition()
                                    .Line("[PR] Lateral medial view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399067008 | Lateral projection (Qualifier)
                            new ConceptDef("LateralView",
                                "Lateral view",
                                new Definition()
                                    .Line("[PR] Lateral view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure) + QualifierValue | 399067008 | Lateral projection (Qualifier)
                            new ConceptDef("LateralWithCompressionView",
                                "Lateral with compression view",
                                new Definition()
                                    .Line("[PR] Lateral with compression view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure)+ QualifierValue | 399352003 | Lateral-medial projection (Qualifier)
                            new ConceptDef("LateromedialObliqueSPELLING",
                                "Lateromedial oblique SPELLING",
                                new Definition()
                                    .Line("[PR] Lateromedial oblique SPELLING")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399352003 | Lateral-medial projection (Qualifier)
                            new ConceptDef("LateromedialViewSPELLING",
                                "Lateromedial view SPELLING",
                                new Definition()
                                    .Line("[PR] Lateromedial view SPELLING")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("LymphNodeAssessment",
                                "Lymph node assessment",
                                new Definition()
                                    .Line("[PR] Lymph node assessment")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 241058008 | Mammogram magnification (Procedure)
                            new ConceptDef("MagnificationViews",
                                "Magnification views",
                                new Definition()
                                    .Line("[PR] Magnification views")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure)
                            new ConceptDef("Mammogram",
                                "Mammogram",
                                new Definition()
                                    .Line("[PR] Mammogram")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            new ConceptDef("Mammogram3MonthFollow-up",
                                "Mammogram 3 month follow-up",
                                new Definition()
                                    .Line("[PR] Mammogram 3 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("Mammogram6MonthFollow-up",
                                "Mammogram 6 month follow-up",
                                new Definition()
                                    .Line("[PR] Mammogram 6 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("MammogramAndUltrasound3MonthFollow-up",
                                "Mammogram and ultrasound 3 month follow-up",
                                new Definition()
                                    .Line("[PR] Mammogram and ultrasound 3 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("MammogramAndUltrasound6MonthFollow-up",
                                "Mammogram and ultrasound 6 month follow-up",
                                new Definition()
                                    .Line("[PR] Mammogram and ultrasound 6 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)
                            new ConceptDef("MediolateralObliqueView",
                                "Mediolateral oblique view",
                                new Definition()
                                    .Line("[PR] Mediolateral oblique view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399260004 | Medial-lateral projection (Qualifier)
                            new ConceptDef("MediolateralView",
                                "Mediolateral view",
                                new Definition()
                                    .Line("[PR] Mediolateral view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)
                            new ConceptDef("MLOWithCompressionView",
                                "MLO with compression view",
                                new Definition()
                                    .Line("[PR] MLO with compression view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241058008 | Mammogram magnification (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)
                            new ConceptDef("MLOWithMagnificationView",
                                "MLO with magnification view",
                                new Definition()
                                    .Line("[PR] MLO with magnification view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241615005 | Magnetic resonance imaging of breast (Procedure)
                            new ConceptDef("MRI",
                                "MRI",
                                new Definition()
                                    .Line("[PR] MRI")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 433008009 | Core needle biopsy of breast using magnetic resonance imaging guidance (Procedure)
                            new ConceptDef("MRIBiopsy",
                                "MRI biopsy",
                                new Definition()
                                    .Line("[PR] MRI biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("MRIFollow-up",
                                "MRI follow-up",
                                new Definition()
                                    .Line("[PR] MRI follow-up")
                                    .ValidModalities(Modalities.MRI | Modalities.NM)
                                ),
                            new ConceptDef("NeedleLocationAndSurgicalBiopsy",
                                "Needle location and surgical biopsy",
                                new Definition()
                                    .Line("[PR] Needle location and surgical biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 442581004 | Nipple in profile mammography view (Qualifier)
                            new ConceptDef("NippleInProfileView",
                                "Nipple in profile view",
                                new Definition()
                                    .Line("[PR] Nipple in profile view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)
                            new ConceptDef("OffAngleCCView",
                                "Off angle CC view",
                                new Definition()
                                    .Line("[PR] Off angle CC view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier) +++++
                            new ConceptDef("OffAngleMLOView",
                                "Off angle MLO view",
                                new Definition()
                                    .Line("[PR] Off angle MLO view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 116334007 | Stereotactically guided core needle biopsy of breast (Procedure) ++ POSSILE
                            new ConceptDef("Poss.StereotacticBx",
                                "Poss. Stereotactic Bx",
                                new Definition()
                                    .Line("[PR] Poss. Stereotactic Bx")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 44578009 | Core needle biopsy of breast (Procedure) ++ POSSIBLE
                            new ConceptDef("PossibleCoreBiopsy",
                                "Possible core biopsy",
                                new Definition()
                                    .Line("[PR] Possible core biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("PossibleDiagnosticMammogram",
                                "Possible Diagnostic Mammogram",
                                new Definition()
                                    .Line("[PR] Possible Diagnostic Mammogram")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("PossibleStereotacticVacuumBiopsy",
                                "Possible stereotactic vacuum biopsy",
                                new Definition()
                                    .Line("[PR] Possible stereotactic vacuum biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("PossibleSurgicalConsult",
                                "Possible surgical consult",
                                new Definition()
                                    .Line("[PR] Possible surgical consult")
                                    .ValidModalities(Modalities.NM)
                                ),
                            new ConceptDef("PossibleSurgicalEvaluation",
                                "Possible surgical evaluation",
                                new Definition()
                                    .Line("[PR] Possible surgical evaluation")
                                    .ValidModalities(Modalities.NM)
                                ),
                            new ConceptDef("PossibleUltrasound",
                                "Possible ultrasound",
                                new Definition()
                                    .Line("[PR] Possible ultrasound")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 432550005 | Core needle biopsy of breast using ultrasound guidance (Procedure) +++ POSSIBLE
                            new ConceptDef("PossibleUltrasoundGuidedBiopsy",
                                "Possible ultrasound guided biopsy",
                                new Definition()
                                    .Line("[PR] Possible ultrasound guided biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("PossibleVacuumBiopsy",
                                "Possible vacuum biopsy",
                                new Definition()
                                    .Line("[PR] Possible vacuum biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)
                            new ConceptDef("RepeatCCView",
                                "Repeat CC view",
                                new Definition()
                                    .Line("[PR] Repeat CC view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)
                            new ConceptDef("RepeatMLOView",
                                "Repeat MLO view",
                                new Definition()
                                    .Line("[PR] Repeat MLO view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 399197002 | Lateral rolling of breast (Procedure)
                            new ConceptDef("RolledLateralView",
                                "Rolled lateral view",
                                new Definition()
                                    .Line("[PR] Rolled lateral view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 399226006 | Medial rolling of breast (Procedure)
                            new ConceptDef("RolledMedialView",
                                "Rolled medial view",
                                new Definition()
                                    .Line("[PR] Rolled medial view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("ScintiBiopsy",
                                "Scinti biopsy",
                                new Definition()
                                    .Line("[PR] Scinti biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Scintimammography",
                                "Scintimammography",
                                new Definition()
                                    .Line("[PR] Scintimammography")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure)
                            new ConceptDef("SpotCompression",
                                "Spot compression",
                                new Definition()
                                    .Line("[PR] Spot compression")
                                    .ValidModalities(Modalities.MG | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 241058008 | Mammogram magnification (Procedure) +++++
                            new ConceptDef("SpotMagnificationViews",
                                "Spot magnification views",
                                new Definition()
                                    .Line("[PR] Spot magnification views")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: Procedure | 116334007 | Stereotactically guided core needle biopsy of breast (Procedure)
                            new ConceptDef("StereotacticBx",
                                "Stereotactic bx",
                                new Definition()
                                    .Line("[PR] Stereotactic bx")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("SuperolateralIOView",
                                "Superolateral IO view",
                                new Definition()
                                    .Line("[PR] Superolateral IO view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 274331003 | Surgical biopsy of breast (Procedure)
                            new ConceptDef("SurgicalBiopsy",
                                "Surgical biopsy",
                                new Definition()
                                    .Line("[PR] Surgical biopsy")
                                    .ValidModalities(Modalities.NM)
                                ),
                            new ConceptDef("SurgicalConsult",
                                "Surgical consult",
                                new Definition()
                                    .Line("[PR] Surgical consult")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 274331003 | Surgical biopsy of breast (Procedure) ++++
                            new ConceptDef("SurgicalConsultAndBiopsy",
                                "Surgical consult and biopsy",
                                new Definition()
                                    .Line("[PR] Surgical consult and biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("SurgicalEvaluation",
                                "Surgical evaluation",
                                new Definition()
                                    .Line("[PR] Surgical evaluation")
                                    .ValidModalities(Modalities.NM)
                                ),
                            // SNOMED Description: Procedure | 237372000 | Excisional biopsy of breast (Procedure)
                            new ConceptDef("SurgicalExcision",
                                "Surgical excision",
                                new Definition()
                                    .Line("[PR] Surgical excision")
                                    .ValidModalities(Modalities.NM)
                                ),
                            new ConceptDef("SurgicalOncologicEvaluation",
                                "Surgical oncologic evaluation",
                                new Definition()
                                    .Line("[PR] Surgical oncologic evaluation")
                                    .ValidModalities(Modalities.NM)
                                ),
                            new ConceptDef("SurgicalOncologicalConsult",
                                "Surgical oncological consult",
                                new Definition()
                                    .Line("[PR] Surgical oncological consult")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("TangentialView",
                                "Tangential view",
                                new Definition()
                                    .Line("[PR] Tangential view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("TangentialViews",
                                "Tangential views",
                                new Definition()
                                    .Line("[PR] Tangential views")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 47079000 | Ultrasonography of breast (Procedure)
                            new ConceptDef("Ultrasound",
                                "Ultrasound",
                                new Definition()
                                    .Line("[PR] Ultrasound")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM)
                                ),
                            new ConceptDef("Ultrasound2ndLook",
                                "Ultrasound 2nd Look",
                                new Definition()
                                    .Line("[PR] Ultrasound 2nd Look")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("Ultrasound3MonthFollow-up",
                                "Ultrasound 3 month follow-up",
                                new Definition()
                                    .Line("[PR] Ultrasound 3 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("Ultrasound6MonthFollow-up",
                                "Ultrasound 6 month follow-up",
                                new Definition()
                                    .Line("[PR] Ultrasound 6 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 432550005 | Core needle biopsy of breast using ultrasound guidance (Procedure)
                            new ConceptDef("UltrasoundGuidedBx",
                                "Ultrasound guided bx",
                                new Definition()
                                    .Line("[PR] Ultrasound guided bx")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: Procedure | 274331003 | Surgical biopsy of breast (Procedure)++++++++++++
                            new ConceptDef("UltrasoundLocationAndSurgicalBiopsy",
                                "Ultrasound location and surgical biopsy",
                                new Definition()
                                    .Line("[PR] Ultrasound location and surgical biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("UltrasoundWithPossibleAddlitonalViews",
                                "Ultrasound with possible addlitonal views",
                                new Definition()
                                    .Line("[PR] Ultrasound with possible addlitonal views")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("UnlessPreviousShowNoChange",
                                "Unless previous show no change",
                                new Definition()
                                    .Line("[PR] Unless previous show no change")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Unspecified-Other",
                                "Unspecified - other",
                                new Definition()
                                    .Line("[PR] Unspecified - other")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Unspecified/Other",
                                "Unspecified / other",
                                new Definition()
                                    .Line("[PR] Unspecified / other")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("VacuumBx",
                                "Vacuum Bx",
                                new Definition()
                                    .Line("[PR] Vacuum Bx")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                )
                            //- RecommendationsCS
                        })
            );
    }
}
