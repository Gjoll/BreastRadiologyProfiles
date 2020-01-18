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
                                        "breast radiology recommendations. It is not meant to be a comprehensive list, just a common list.")
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
                            //+ 3DImaging
                            new ConceptDef()
                                .SetCode("3DImaging")
                                .SetDisplay("3D Imaging")
                                .SetDefinition(new Definition()
                                    .Line("[PR] 3D Imaging")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- 3DImaging
                            // SNOMED Description: Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier) + SPOT
                            //+ 3DSpotCC
                            new ConceptDef()
                                .SetCode("3DSpotCC")
                                .SetDisplay("3D spot CC")
                                .SetDefinition(new Definition()
                                    .Line("[PR] 3D spot CC")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- 3DSpotCC
                            // SNOMED Description: Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399352003 | Lateral-medial projection (Qualifier) + SPOT
                            //+ 3DSpotLM
                            new ConceptDef()
                                .SetCode("3DSpotLM")
                                .SetDisplay("3D spot LM")
                                .SetDefinition(new Definition()
                                    .Line("[PR] 3D spot LM")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- 3DSpotLM
                            // SNOMED Description: Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399260004 | Medial-lateral projection (Qualifier) + SPOT
                            //+ 3DSpotML
                            new ConceptDef()
                                .SetCode("3DSpotML")
                                .SetDisplay("3D spot ML")
                                .SetDefinition(new Definition()
                                    .Line("[PR] 3D spot ML")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- 3DSpotML
                            // SNOMED Description: Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier) + SPOT
                            //+ 3DSpotMLO
                            new ConceptDef()
                                .SetCode("3DSpotMLO")
                                .SetDisplay("3D spot MLO")
                                .SetDefinition(new Definition()
                                    .Line("[PR] 3D spot MLO")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- 3DSpotMLO
                            //+ AdditionalViews
                            new ConceptDef()
                                .SetCode("AdditionalViews")
                                .SetDisplay("Additional views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Additional views")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- AdditionalViews
                            // SNOMED Description: Procedure | 47079000 | Ultrasonography of breast (Procedure)
                            //+ AddlitionalViewsWithPossibleUltrasound
                            new ConceptDef()
                                .SetCode("AddlitionalViewsWithPossibleUltrasound")
                                .SetDisplay("Addlitional views with possible ultrasound")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Addlitional views with possible ultrasound")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- AddlitionalViewsWithPossibleUltrasound
                            //+ AxillaView
                            new ConceptDef()
                                .SetCode("AxillaView")
                                .SetDisplay("Axilla view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Axilla view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- AxillaView
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 442580003 | Axillary tissue mammography view (Qualifier)
                            //+ AxillaryTailView
                            new ConceptDef()
                                .SetCode("AxillaryTailView")
                                .SetDisplay("Axillary tail view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Axillary tail view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- AxillaryTailView
                            //+ Biopsy
                            new ConceptDef()
                                .SetCode("Biopsy")
                                .SetDisplay("Biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- Biopsy
                            //+ BiopsyBaseOnClinical
                            new ConceptDef()
                                .SetCode("BiopsyBaseOnClinical")
                                .SetDisplay("Biopsy base on clinical")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Biopsy base on clinical")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- BiopsyBaseOnClinical
                            //+ CaudocranialView
                            new ConceptDef()
                                .SetCode("CaudocranialView")
                                .SetDisplay("Caudocranial view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Caudocranial view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- CaudocranialView
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure)+ QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)
                            //+ CCWithCompressionView
                            new ConceptDef()
                                .SetCode("CCWithCompressionView")
                                .SetDisplay("CC with compression view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] CC with compression view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- CCWithCompressionView
                            // SNOMED Description: Procedure | 241058008 | Mammogram magnification (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)
                            //+ CCWithMagnificationView
                            new ConceptDef()
                                .SetCode("CCWithMagnificationView")
                                .SetDisplay("CC with magnification view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] CC with magnification view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- CCWithMagnificationView
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399161006 | Cleavage mammography view (Qualifier)
                            //+ CleavageView
                            new ConceptDef()
                                .SetCode("CleavageView")
                                .SetDisplay("Cleavage view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cleavage view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- CleavageView
                            //+ ClinicalConsultation
                            new ConceptDef()
                                .SetCode("ClinicalConsultation")
                                .SetDisplay("Clinical consultation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Clinical consultation")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- ClinicalConsultation
                            //+ ClinicalCorrelation
                            new ConceptDef()
                                .SetCode("ClinicalCorrelation")
                                .SetDisplay("Clinical correlation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Clinical correlation")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- ClinicalCorrelation
                            //+ ClinicalFollow-up
                            new ConceptDef()
                                .SetCode("ClinicalFollow-up")
                                .SetDisplay("Clinical follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Clinical follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- ClinicalFollow-up
                            //+ CompareToPriorExams
                            new ConceptDef()
                                .SetCode("CompareToPriorExams")
                                .SetDisplay("Compare to prior exams")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Compare to prior exams")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- CompareToPriorExams
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure) 
                            //+ CompressionViews
                            new ConceptDef()
                                .SetCode("CompressionViews")
                                .SetDisplay("Compression views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Compression views")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- CompressionViews
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure) 
                            //+ ConeCompression
                            new ConceptDef()
                                .SetCode("ConeCompression")
                                .SetDisplay("Cone compression")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cone compression")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- ConeCompression
                            // SNOMED Description: Procedure | 44578009 | Core needle biopsy of breast (Procedure)
                            //+ CoreBiopsy
                            new ConceptDef()
                                .SetCode("CoreBiopsy")
                                .SetDisplay("Core Biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Core Biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- CoreBiopsy
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)
                            //+ CraniocaudalView
                            new ConceptDef()
                                .SetCode("CraniocaudalView")
                                .SetDisplay("Craniocaudal view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Craniocaudal view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- CraniocaudalView
                            //+ Cryoablation
                            new ConceptDef()
                                .SetCode("Cryoablation")
                                .SetDisplay("Cryoablation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cryoablation")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- Cryoablation
                            // SNOMED Description: Procedure | 287572003 | Diagnostic aspiration of breast cyst (Procedure)
                            //+ CystAspiration
                            new ConceptDef()
                                .SetCode("CystAspiration")
                                .SetDisplay("Cyst aspiration")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst aspiration")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- CystAspiration
                            // SNOMED Description: Procedure | 287572003 | Diagnostic aspiration of breast cyst (Procedure)
                            //+ CystAspirationForRelief
                            new ConceptDef()
                                .SetCode("CystAspirationForRelief")
                                .SetDisplay("Cyst aspiration for relief")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst aspiration for relief")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- CystAspirationForRelief
                            // SNOMED Description: Procedure | 287572003 | Diagnostic aspiration of breast cyst (Procedure)
                            //+ DiagnosticAspiration
                            new ConceptDef()
                                .SetCode("DiagnosticAspiration")
                                .SetDisplay("Diagnostic aspiration")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Diagnostic aspiration")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- DiagnosticAspiration
                            //+ DiagnosticMammogram
                            new ConceptDef()
                                .SetCode("DiagnosticMammogram")
                                .SetDisplay("Diagnostic Mammogram")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Diagnostic Mammogram")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- DiagnosticMammogram
                            //+ DrainageTube
                            new ConceptDef()
                                .SetCode("DrainageTube")
                                .SetDisplay("Drainage tube")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Drainage tube")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- DrainageTube
                            // SNOMED Description: Procedure | 420131003 | Fluoroscopic mammary ductography (Procedure) 
                            //+ Ductography
                            new ConceptDef()
                                .SetCode("Ductography")
                                .SetDisplay("Ductography")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ductography")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Ductography
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399265009 | Exaggerated cranio-caudal projection (Qualifier)
                            //+ ExaggeratedCCViews
                            new ConceptDef()
                                .SetCode("ExaggeratedCCViews")
                                .SetDisplay("Exaggerated CC views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Exaggerated CC views")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- ExaggeratedCCViews
                            // SNOMED Description: not matching
                            //+ FNABiopsy
                            new ConceptDef()
                                .SetCode("FNABiopsy")
                                .SetDisplay("FNA biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] FNA biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- FNABiopsy
                            //+ Follow-up
                            new ConceptDef()
                                .SetCode("Follow-up")
                                .SetDisplay("Follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Follow-up")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- Follow-up
                            //+ Followup3Months
                            new ConceptDef()
                                .SetCode("Followup3Months")
                                .SetDisplay("Followup 3 months")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Followup 3 months")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- Followup3Months
                            //+ Followup6Months
                            new ConceptDef()
                                .SetCode("Followup6Months")
                                .SetDisplay("Followup 6 months")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Followup 6 months")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Followup6Months
                            //+ IfPreviousShowNoChange
                            new ConceptDef()
                                .SetCode("IfPreviousShowNoChange")
                                .SetDisplay("If previous show no change")
                                .SetDefinition(new Definition()
                                    .Line("[PR] If previous show no change")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- IfPreviousShowNoChange
                            // SNOMED Description: Procedure | 241058008 | Mammogram magnification (Procedure) + QualifierValue | 399067008 | Lateral projection (Qualifier)
                            //+ LateralMagnificaionView
                            new ConceptDef()
                                .SetCode("LateralMagnificaionView")
                                .SetDisplay("Lateral magnificaion view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateral magnificaion view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- LateralMagnificaionView
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399352003 | Lateral-medial projection (Qualifier)
                            //+ LateralMedialView
                            new ConceptDef()
                                .SetCode("LateralMedialView")
                                .SetDisplay("Lateral medial view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateral medial view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- LateralMedialView
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399067008 | Lateral projection (Qualifier)
                            //+ LateralView
                            new ConceptDef()
                                .SetCode("LateralView")
                                .SetDisplay("Lateral view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateral view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- LateralView
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure) + QualifierValue | 399067008 | Lateral projection (Qualifier)
                            //+ LateralWithCompressionView
                            new ConceptDef()
                                .SetCode("LateralWithCompressionView")
                                .SetDisplay("Lateral with compression view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateral with compression view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- LateralWithCompressionView
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure)+ QualifierValue | 399352003 | Lateral-medial projection (Qualifier)
                            //+ LateromedialObliqueSPELLING
                            new ConceptDef()
                                .SetCode("LateromedialObliqueSPELLING")
                                .SetDisplay("Lateromedial oblique SPELLING")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateromedial oblique SPELLING")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- LateromedialObliqueSPELLING
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399352003 | Lateral-medial projection (Qualifier)
                            //+ LateromedialViewSPELLING
                            new ConceptDef()
                                .SetCode("LateromedialViewSPELLING")
                                .SetDisplay("Lateromedial view SPELLING")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateromedial view SPELLING")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- LateromedialViewSPELLING
                            //+ LymphNodeAssessment
                            new ConceptDef()
                                .SetCode("LymphNodeAssessment")
                                .SetDisplay("Lymph node assessment")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node assessment")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- LymphNodeAssessment
                            // SNOMED Description: Procedure | 241058008 | Mammogram magnification (Procedure)
                            //+ MagnificationViews
                            new ConceptDef()
                                .SetCode("MagnificationViews")
                                .SetDisplay("Magnification views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Magnification views")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- MagnificationViews
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure)
                            //+ Mammogram
                            new ConceptDef()
                                .SetCode("Mammogram")
                                .SetDisplay("Mammogram")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- Mammogram
                            //+ Mammogram3MonthFollow-up
                            new ConceptDef()
                                .SetCode("Mammogram3MonthFollow-up")
                                .SetDisplay("Mammogram 3 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram 3 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- Mammogram3MonthFollow-up
                            //+ Mammogram6MonthFollow-up
                            new ConceptDef()
                                .SetCode("Mammogram6MonthFollow-up")
                                .SetDisplay("Mammogram 6 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram 6 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- Mammogram6MonthFollow-up
                            //+ MammogramAndUltrasound3MonthFollow-up
                            new ConceptDef()
                                .SetCode("MammogramAndUltrasound3MonthFollow-up")
                                .SetDisplay("Mammogram and ultrasound 3 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram and ultrasound 3 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- MammogramAndUltrasound3MonthFollow-up
                            //+ MammogramAndUltrasound6MonthFollow-up
                            new ConceptDef()
                                .SetCode("MammogramAndUltrasound6MonthFollow-up")
                                .SetDisplay("Mammogram and ultrasound 6 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram and ultrasound 6 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- MammogramAndUltrasound6MonthFollow-up
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)
                            //+ MediolateralObliqueView
                            new ConceptDef()
                                .SetCode("MediolateralObliqueView")
                                .SetDisplay("Mediolateral oblique view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mediolateral oblique view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- MediolateralObliqueView
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399260004 | Medial-lateral projection (Qualifier)
                            //+ MediolateralView
                            new ConceptDef()
                                .SetCode("MediolateralView")
                                .SetDisplay("Mediolateral view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mediolateral view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- MediolateralView
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)
                            //+ MLOWithCompressionView
                            new ConceptDef()
                                .SetCode("MLOWithCompressionView")
                                .SetDisplay("MLO with compression view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] MLO with compression view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- MLOWithCompressionView
                            // SNOMED Description: Procedure | 241058008 | Mammogram magnification (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)
                            //+ MLOWithMagnificationView
                            new ConceptDef()
                                .SetCode("MLOWithMagnificationView")
                                .SetDisplay("MLO with magnification view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] MLO with magnification view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- MLOWithMagnificationView
                            // SNOMED Description: Procedure | 241615005 | Magnetic resonance imaging of breast (Procedure)
                            //+ MRI
                            new ConceptDef()
                                .SetCode("MRI")
                                .SetDisplay("MRI")
                                .SetDefinition(new Definition()
                                    .Line("[PR] MRI")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- MRI
                            // SNOMED Description: Procedure | 433008009 | Core needle biopsy of breast using magnetic resonance imaging guidance (Procedure)
                            //+ MRIBiopsy
                            new ConceptDef()
                                .SetCode("MRIBiopsy")
                                .SetDisplay("MRI biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] MRI biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- MRIBiopsy
                            //+ MRIFollow-up
                            new ConceptDef()
                                .SetCode("MRIFollow-up")
                                .SetDisplay("MRI follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] MRI follow-up")
                                    .ValidModalities(Modalities.MRI | Modalities.NM)
                                ),
                            //- MRIFollow-up
                            //+ NeedleLocationAndSurgicalBiopsy
                            new ConceptDef()
                                .SetCode("NeedleLocationAndSurgicalBiopsy")
                                .SetDisplay("Needle location and surgical biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Needle location and surgical biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- NeedleLocationAndSurgicalBiopsy
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 442581004 | Nipple in profile mammography view (Qualifier)
                            //+ NippleInProfileView
                            new ConceptDef()
                                .SetCode("NippleInProfileView")
                                .SetDisplay("Nipple in profile view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Nipple in profile view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- NippleInProfileView
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)
                            //+ OffAngleCCView
                            new ConceptDef()
                                .SetCode("OffAngleCCView")
                                .SetDisplay("Off angle CC view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Off angle CC view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- OffAngleCCView
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier) +++++
                            //+ OffAngleMLOView
                            new ConceptDef()
                                .SetCode("OffAngleMLOView")
                                .SetDisplay("Off angle MLO view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Off angle MLO view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- OffAngleMLOView
                            // SNOMED Description: Procedure | 116334007 | Stereotactically guided core needle biopsy of breast (Procedure) ++ POSSILE
                            //+ Poss.StereotacticBx
                            new ConceptDef()
                                .SetCode("Poss.StereotacticBx")
                                .SetDisplay("Poss. Stereotactic Bx")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Poss. Stereotactic Bx")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- Poss.StereotacticBx
                            // SNOMED Description: Procedure | 44578009 | Core needle biopsy of breast (Procedure) ++ POSSIBLE
                            //+ PossibleCoreBiopsy
                            new ConceptDef()
                                .SetCode("PossibleCoreBiopsy")
                                .SetDisplay("Possible core biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible core biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- PossibleCoreBiopsy
                            //+ PossibleDiagnosticMammogram
                            new ConceptDef()
                                .SetCode("PossibleDiagnosticMammogram")
                                .SetDisplay("Possible Diagnostic Mammogram")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible Diagnostic Mammogram")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- PossibleDiagnosticMammogram
                            //+ PossibleStereotacticVacuumBiopsy
                            new ConceptDef()
                                .SetCode("PossibleStereotacticVacuumBiopsy")
                                .SetDisplay("Possible stereotactic vacuum biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible stereotactic vacuum biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- PossibleStereotacticVacuumBiopsy
                            //+ PossibleSurgicalConsult
                            new ConceptDef()
                                .SetCode("PossibleSurgicalConsult")
                                .SetDisplay("Possible surgical consult")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible surgical consult")
                                    .ValidModalities(Modalities.NM)
                                ),
                            //- PossibleSurgicalConsult
                            //+ PossibleSurgicalEvaluation
                            new ConceptDef()
                                .SetCode("PossibleSurgicalEvaluation")
                                .SetDisplay("Possible surgical evaluation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible surgical evaluation")
                                    .ValidModalities(Modalities.NM)
                                ),
                            //- PossibleSurgicalEvaluation
                            //+ PossibleUltrasound
                            new ConceptDef()
                                .SetCode("PossibleUltrasound")
                                .SetDisplay("Possible ultrasound")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible ultrasound")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- PossibleUltrasound
                            // SNOMED Description: Procedure | 432550005 | Core needle biopsy of breast using ultrasound guidance (Procedure) +++ POSSIBLE
                            //+ PossibleUltrasoundGuidedBiopsy
                            new ConceptDef()
                                .SetCode("PossibleUltrasoundGuidedBiopsy")
                                .SetDisplay("Possible ultrasound guided biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible ultrasound guided biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- PossibleUltrasoundGuidedBiopsy
                            //+ PossibleVacuumBiopsy
                            new ConceptDef()
                                .SetCode("PossibleVacuumBiopsy")
                                .SetDisplay("Possible vacuum biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible vacuum biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- PossibleVacuumBiopsy
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)
                            //+ RepeatCCView
                            new ConceptDef()
                                .SetCode("RepeatCCView")
                                .SetDisplay("Repeat CC view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Repeat CC view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- RepeatCCView
                            // SNOMED Description: Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)
                            //+ RepeatMLOView
                            new ConceptDef()
                                .SetCode("RepeatMLOView")
                                .SetDisplay("Repeat MLO view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Repeat MLO view")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- RepeatMLOView
                            // SNOMED Description: Procedure | 399197002 | Lateral rolling of breast (Procedure)
                            //+ RolledLateralView
                            new ConceptDef()
                                .SetCode("RolledLateralView")
                                .SetDisplay("Rolled lateral view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Rolled lateral view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- RolledLateralView
                            // SNOMED Description: Procedure | 399226006 | Medial rolling of breast (Procedure)
                            //+ RolledMedialView
                            new ConceptDef()
                                .SetCode("RolledMedialView")
                                .SetDisplay("Rolled medial view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Rolled medial view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- RolledMedialView
                            //+ ScintiBiopsy
                            new ConceptDef()
                                .SetCode("ScintiBiopsy")
                                .SetDisplay("Scinti biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scinti biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- ScintiBiopsy
                            //+ Scintimammography
                            new ConceptDef()
                                .SetCode("Scintimammography")
                                .SetDisplay("Scintimammography")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scintimammography")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Scintimammography
                            // SNOMED Description: Procedure | 439324009 | Mammogram in compression view (Procedure)
                            //+ SpotCompression
                            new ConceptDef()
                                .SetCode("SpotCompression")
                                .SetDisplay("Spot compression")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Spot compression")
                                    .ValidModalities(Modalities.MG | Modalities.NM | Modalities.US)
                                ),
                            //- SpotCompression
                            // SNOMED Description: Procedure | 241058008 | Mammogram magnification (Procedure) +++++
                            //+ SpotMagnificationViews
                            new ConceptDef()
                                .SetCode("SpotMagnificationViews")
                                .SetDisplay("Spot magnification views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Spot magnification views")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- SpotMagnificationViews
                            // SNOMED Description: Procedure | 116334007 | Stereotactically guided core needle biopsy of breast (Procedure)
                            //+ StereotacticBx
                            new ConceptDef()
                                .SetCode("StereotacticBx")
                                .SetDisplay("Stereotactic bx")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Stereotactic bx")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- StereotacticBx
                            //+ SuperolateralIOView
                            new ConceptDef()
                                .SetCode("SuperolateralIOView")
                                .SetDisplay("Superolateral IO view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Superolateral IO view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- SuperolateralIOView
                            // SNOMED Description: Procedure | 274331003 | Surgical biopsy of breast (Procedure)
                            //+ SurgicalBiopsy
                            new ConceptDef()
                                .SetCode("SurgicalBiopsy")
                                .SetDisplay("Surgical biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical biopsy")
                                    .ValidModalities(Modalities.NM)
                                ),
                            //- SurgicalBiopsy
                            //+ SurgicalConsult
                            new ConceptDef()
                                .SetCode("SurgicalConsult")
                                .SetDisplay("Surgical consult")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical consult")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- SurgicalConsult
                            // SNOMED Description: Procedure | 274331003 | Surgical biopsy of breast (Procedure) ++++
                            //+ SurgicalConsultAndBiopsy
                            new ConceptDef()
                                .SetCode("SurgicalConsultAndBiopsy")
                                .SetDisplay("Surgical consult and biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical consult and biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- SurgicalConsultAndBiopsy
                            //+ SurgicalEvaluation
                            new ConceptDef()
                                .SetCode("SurgicalEvaluation")
                                .SetDisplay("Surgical evaluation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical evaluation")
                                    .ValidModalities(Modalities.NM)
                                ),
                            //- SurgicalEvaluation
                            // SNOMED Description: Procedure | 237372000 | Excisional biopsy of breast (Procedure)
                            //+ SurgicalExcision
                            new ConceptDef()
                                .SetCode("SurgicalExcision")
                                .SetDisplay("Surgical excision")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical excision")
                                    .ValidModalities(Modalities.NM)
                                ),
                            //- SurgicalExcision
                            //+ SurgicalOncologicEvaluation
                            new ConceptDef()
                                .SetCode("SurgicalOncologicEvaluation")
                                .SetDisplay("Surgical oncologic evaluation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical oncologic evaluation")
                                    .ValidModalities(Modalities.NM)
                                ),
                            //- SurgicalOncologicEvaluation
                            //+ SurgicalOncologicalConsult
                            new ConceptDef()
                                .SetCode("SurgicalOncologicalConsult")
                                .SetDisplay("Surgical oncological consult")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical oncological consult")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- SurgicalOncologicalConsult
                            //+ TangentialView
                            new ConceptDef()
                                .SetCode("TangentialView")
                                .SetDisplay("Tangential view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Tangential view")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- TangentialView
                            //+ TangentialViews
                            new ConceptDef()
                                .SetCode("TangentialViews")
                                .SetDisplay("Tangential views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Tangential views")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- TangentialViews
                            // SNOMED Description: Procedure | 47079000 | Ultrasonography of breast (Procedure)
                            //+ Ultrasound
                            new ConceptDef()
                                .SetCode("Ultrasound")
                                .SetDisplay("Ultrasound")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM)
                                ),
                            //- Ultrasound
                            //+ Ultrasound2ndLook
                            new ConceptDef()
                                .SetCode("Ultrasound2ndLook")
                                .SetDisplay("Ultrasound 2nd Look")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound 2nd Look")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- Ultrasound2ndLook
                            //+ Ultrasound3MonthFollow-up
                            new ConceptDef()
                                .SetCode("Ultrasound3MonthFollow-up")
                                .SetDisplay("Ultrasound 3 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound 3 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- Ultrasound3MonthFollow-up
                            //+ Ultrasound6MonthFollow-up
                            new ConceptDef()
                                .SetCode("Ultrasound6MonthFollow-up")
                                .SetDisplay("Ultrasound 6 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound 6 month follow-up")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- Ultrasound6MonthFollow-up
                            // SNOMED Description: Procedure | 432550005 | Core needle biopsy of breast using ultrasound guidance (Procedure)
                            //+ UltrasoundGuidedBx
                            new ConceptDef()
                                .SetCode("UltrasoundGuidedBx")
                                .SetDisplay("Ultrasound guided bx")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound guided bx")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- UltrasoundGuidedBx
                            // SNOMED Description: Procedure | 274331003 | Surgical biopsy of breast (Procedure)++++++++++++
                            //+ UltrasoundLocationAndSurgicalBiopsy
                            new ConceptDef()
                                .SetCode("UltrasoundLocationAndSurgicalBiopsy")
                                .SetDisplay("Ultrasound location and surgical biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound location and surgical biopsy")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- UltrasoundLocationAndSurgicalBiopsy
                            //+ UltrasoundWithPossibleAddlitonalViews
                            new ConceptDef()
                                .SetCode("UltrasoundWithPossibleAddlitonalViews")
                                .SetDisplay("Ultrasound with possible addlitonal views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound with possible addlitonal views")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- UltrasoundWithPossibleAddlitonalViews
                            //+ UnlessPreviousShowNoChange
                            new ConceptDef()
                                .SetCode("UnlessPreviousShowNoChange")
                                .SetDisplay("Unless previous show no change")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Unless previous show no change")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- UnlessPreviousShowNoChange
                            //+ Unspecified-Other
                            new ConceptDef()
                                .SetCode("Unspecified-Other")
                                .SetDisplay("Unspecified - other")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Unspecified - other")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- Unspecified-Other
                            //+ Unspecified/Other
                            new ConceptDef()
                                .SetCode("Unspecified/Other")
                                .SetDisplay("Unspecified / other")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Unspecified / other")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- Unspecified/Other
                            //+ VacuumBx
                            new ConceptDef()
                                .SetCode("VacuumBx")
                                .SetDisplay("Vacuum Bx")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Vacuum Bx")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                )
                            //- VacuumBx
                            //- RecommendationsCS
                        })
            );
    }
}
