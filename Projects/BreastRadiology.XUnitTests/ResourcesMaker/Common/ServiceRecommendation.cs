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
                     Global.ServiceRequestUrl,
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
                     .ReviewedStatus("NOONE", "")
                     ;
                {
                    ValueSet binding = Self.RecommendationsVS.Value();
                    ElementDefinition codeDef = e.Select("code").Binding(binding, BindingStrength.Extensible);

                    e.AddComponentLink("Service Recommendation Code",
                        new SDefEditor.Cardinality(codeDef),
                        Global.ElementAnchor(codeDef),
                        "CodeableConcept",
                        binding.Url);
                }
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
                            //+ 3DImaging
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("3DImaging")
                                .SetDisplay("3D Imaging")
                                .SetDefinition(new Definition()
                                    .Line("[PR] 3D Imaging")
                                    .MammoId("1828")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 450566007 | Digital breast tomosynthesis (Procedure) +")
                            //- AutoGen
                            //- 3DImaging
                            ,
                            //+ 3DSpotCC
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("3DSpotCC")
                                .SetDisplay("3D spot CC")
                                .SetDefinition(new Definition()
                                    .Line("[PR] 3D spot CC")
                                    .MammoId("1830")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier) + SPOT")
                            //- AutoGen
                            //- 3DSpotCC
                            ,
                            //+ 3DSpotLM
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("3DSpotLM")
                                .SetDisplay("3D spot LM")
                                .SetDefinition(new Definition()
                                    .Line("[PR] 3D spot LM")
                                    .MammoId("1833")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399352003 | Lateral-medial projection (Qualifier) + SPOT")
                            //- AutoGen
                            //- 3DSpotLM
                            ,
                            //+ 3DSpotML
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("3DSpotML")
                                .SetDisplay("3D spot ML")
                                .SetDefinition(new Definition()
                                    .Line("[PR] 3D spot ML")
                                    .MammoId("1832")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399260004 | Medial-lateral projection (Qualifier) + SPOT")
                            //- AutoGen
                            //- 3DSpotML
                            ,
                            //+ 3DSpotMLO
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("3DSpotMLO")
                                .SetDisplay("3D spot MLO")
                                .SetDefinition(new Definition()
                                    .Line("[PR] 3D spot MLO")
                                    .MammoId("1831")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 450566007 | Digital breast tomosynthesis (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier) + SPOT")
                            //- AutoGen
                            //- 3DSpotMLO
                            ,
                            //+ AdditionalViews
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("AdditionalViews")
                                .SetDisplay("Additional views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Additional views")
                                    .MammoId("68")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- AdditionalViews
                            ,
                            //+ AddlitionalViewsWithPossibleUltrasound
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("AddlitionalViewsWithPossibleUltrasound")
                                .SetDisplay("Addlitional views with possible ultrasound")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Addlitional views with possible ultrasound")
                                    .MammoId("87")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 47079000 | Ultrasonography of breast (Procedure)")
                            //- AutoGen
                            //- AddlitionalViewsWithPossibleUltrasound
                            ,
                            //+ AxillaView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("AxillaView")
                                .SetDisplay("Axilla view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Axilla view")
                                    .MammoId("1820")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- AxillaView
                            ,
                            //+ AxillaryTailView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("AxillaryTailView")
                                .SetDisplay("Axillary tail view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Axillary tail view")
                                    .MammoId("45")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 442580003 | Axillary tissue mammography view (Qualifier)")
                            //- AutoGen
                            //- AxillaryTailView
                            ,
                            //+ Biopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Biopsy")
                                .SetDisplay("Biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Biopsy")
                                    .MammoId("100")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- Biopsy
                            ,
                            //+ BiopsyBaseOnClinical
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BiopsyBaseOnClinical")
                                .SetDisplay("Biopsy base on clinical")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Biopsy base on clinical")
                                    .MammoId("52")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- BiopsyBaseOnClinical
                            ,
                            //+ CaudocranialView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CaudocranialView")
                                .SetDisplay("Caudocranial view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Caudocranial view")
                                    .MammoId("46")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- CaudocranialView
                            ,
                            //+ CCWithCompressionView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CCWithCompressionView")
                                .SetDisplay("CC with compression view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] CC with compression view")
                                    .MammoId("84")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression view (Procedure)+ QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)")
                            //- AutoGen
                            //- CCWithCompressionView
                            ,
                            //+ CCWithMagnificationView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CCWithMagnificationView")
                                .SetDisplay("CC with magnification view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] CC with magnification view")
                                    .MammoId("82")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241058008 | Mammogram magnification (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)")
                            //- AutoGen
                            //- CCWithMagnificationView
                            ,
                            //+ CleavageView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CleavageView")
                                .SetDisplay("Cleavage view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cleavage view")
                                    .MammoId("44")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399161006 | Cleavage mammography view (Qualifier)")
                            //- AutoGen
                            //- CleavageView
                            ,
                            //+ ClinicalConsultation
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ClinicalConsultation")
                                .SetDisplay("Clinical consultation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Clinical consultation")
                                    .MammoId("116")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- ClinicalConsultation
                            ,
                            //+ ClinicalCorrelation
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ClinicalCorrelation")
                                .SetDisplay("Clinical correlation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Clinical correlation")
                                    .MammoId("56")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- ClinicalCorrelation
                            ,
                            //+ ClinicalFollow-up
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ClinicalFollow-up")
                                .SetDisplay("Clinical follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Clinical follow-up")
                                    .MammoId("93")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- ClinicalFollow-up
                            ,
                            //+ CompareToPriorExams
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CompareToPriorExams")
                                .SetDisplay("Compare to prior exams")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Compare to prior exams")
                                    .MammoId("103")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- CompareToPriorExams
                            ,
                            //+ CompressionViews
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CompressionViews")
                                .SetDisplay("Compression views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Compression views")
                                    .MammoId("43")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression view (Procedure)")
                            //- AutoGen
                            //- CompressionViews
                            ,
                            //+ ConeCompression
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ConeCompression")
                                .SetDisplay("Cone compression")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cone compression")
                                    .MammoId("185")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression view (Procedure)")
                            //- AutoGen
                            //- ConeCompression
                            ,
                            //+ CoreBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CoreBiopsy")
                                .SetDisplay("Core Biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Core Biopsy")
                                    .MammoId("1829")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 44578009 | Core needle biopsy of breast (Procedure)")
                            //- AutoGen
                            //- CoreBiopsy
                            ,
                            //+ CraniocaudalView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CraniocaudalView")
                                .SetDisplay("Craniocaudal view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Craniocaudal view")
                                    .MammoId("332")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)")
                            //- AutoGen
                            //- CraniocaudalView
                            ,
                            //+ Cryoablation
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Cryoablation")
                                .SetDisplay("Cryoablation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cryoablation")
                                    .MammoId("168")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- Cryoablation
                            ,
                            //+ CystAspiration
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystAspiration")
                                .SetDisplay("Cyst aspiration")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst aspiration")
                                    .MammoId("51")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 287572003 | Diagnostic aspiration of breast cyst (Procedure)")
                            //- AutoGen
                            //- CystAspiration
                            ,
                            //+ CystAspirationForRelief
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystAspirationForRelief")
                                .SetDisplay("Cyst aspiration for relief")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst aspiration for relief")
                                    .MammoId("1821")
                                )
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("Procedure | 287572003 | Diagnostic aspiration of breast cyst (Procedure)")
                            //- AutoGen
                            //- CystAspirationForRelief
                            ,
                            //+ DiagnosticAspiration
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DiagnosticAspiration")
                                .SetDisplay("Diagnostic aspiration")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Diagnostic aspiration")
                                    .MammoId("108")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 287572003 | Diagnostic aspiration of breast cyst (Procedure)")
                            //- AutoGen
                            //- DiagnosticAspiration
                            ,
                            //+ DiagnosticMammogram
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DiagnosticMammogram")
                                .SetDisplay("Diagnostic Mammogram")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Diagnostic Mammogram")
                                    .MammoId("1834")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- DiagnosticMammogram
                            ,
                            //+ DrainageTube
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DrainageTube")
                                .SetDisplay("Drainage tube")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Drainage tube")
                                    .MammoId("183")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- DrainageTube
                            ,
                            //+ Ductography
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Ductography")
                                .SetDisplay("Ductography")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ductography")
                                    .MammoId("179")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 420131003 | Fluoroscopic mammary ductography (Procedure)")
                            //- AutoGen
                            //- Ductography
                            ,
                            //+ ExaggeratedCCViews
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ExaggeratedCCViews")
                                .SetDisplay("Exaggerated CC views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Exaggerated CC views")
                                    .MammoId("41")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399265009 | Exaggerated cranio-caudal projection (Qualifier)")
                            //- AutoGen
                            //- ExaggeratedCCViews
                            ,
                            //+ FNABiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FNABiopsy")
                                .SetDisplay("FNA biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] FNA biopsy")
                                    .MammoId("57")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("not matching")
                            //- AutoGen
                            //- FNABiopsy
                            ,
                            //+ Follow-up
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Follow-up")
                                .SetDisplay("Follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Follow-up")
                                    .MammoId("38")
                                )
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            //- Follow-up
                            ,
                            //+ Followup3Months
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Followup3Months")
                                .SetDisplay("Followup 3 months")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Followup 3 months")
                                    .MammoId("123")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- Followup3Months
                            ,
                            //+ Followup6Months
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Followup6Months")
                                .SetDisplay("Followup 6 months")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Followup 6 months")
                                    .MammoId("119")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- Followup6Months
                            ,
                            //+ IfPreviousShowNoChange
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("IfPreviousShowNoChange")
                                .SetDisplay("If previous show no change")
                                .SetDefinition(new Definition()
                                    .Line("[PR] If previous show no change")
                                    .MammoId("89")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- IfPreviousShowNoChange
                            ,
                            //+ LateralMagnificaionView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LateralMagnificaionView")
                                .SetDisplay("Lateral magnificaion view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateral magnificaion view")
                                    .MammoId("161")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241058008 | Mammogram magnification (Procedure) + QualifierValue | 399067008 | Lateral projection (Qualifier)")
                            //- AutoGen
                            //- LateralMagnificaionView
                            ,
                            //+ LateralMedialView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LateralMedialView")
                                .SetDisplay("Lateral medial view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateral medial view")
                                    .MammoId("90")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399352003 | Lateral-medial projection (Qualifier)")
                            //- AutoGen
                            //- LateralMedialView
                            ,
                            //+ LateralView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LateralView")
                                .SetDisplay("Lateral view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateral view")
                                    .MammoId("95")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399067008 | Lateral projection (Qualifier)")
                            //- AutoGen
                            //- LateralView
                            ,
                            //+ LateralWithCompressionView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LateralWithCompressionView")
                                .SetDisplay("Lateral with compression view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateral with compression view")
                                    .MammoId("86")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression view (Procedure) + QualifierValue | 399067008 | Lateral projection (Qualifier)")
                            //- AutoGen
                            //- LateralWithCompressionView
                            ,
                            //+ LateromedialObliqueSPELLING
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LateromedialObliqueSPELLING")
                                .SetDisplay("Lateromedial oblique SPELLING")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateromedial oblique SPELLING")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure)+ QualifierValue | 399352003 | Lateral-medial projection (Qualifier)")
                            //- AutoGen
                            //- LateromedialObliqueSPELLING
                            ,
                            //+ LateromedialViewSPELLING
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LateromedialViewSPELLING")
                                .SetDisplay("Lateromedial view SPELLING")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateromedial view SPELLING")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399352003 | Lateral-medial projection (Qualifier)")
                            //- AutoGen
                            //- LateromedialViewSPELLING
                            ,
                            //+ LymphNodeAssessment
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LymphNodeAssessment")
                                .SetDisplay("Lymph node assessment")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node assessment")
                                    .MammoId("1835")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- LymphNodeAssessment
                            ,
                            //+ MagnificationViews
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MagnificationViews")
                                .SetDisplay("Magnification views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Magnification views")
                                    .MammoId("42")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 241058008 | Mammogram magnification (Procedure)")
                            //- AutoGen
                            //- MagnificationViews
                            ,
                            //+ Mammogram
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Mammogram")
                                .SetDisplay("Mammogram")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram")
                                    .MammoId("182")
                                )
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure)")
                            //- AutoGen
                            //- Mammogram
                            ,
                            //+ Mammogram3MonthFollow-up
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Mammogram3MonthFollow-up")
                                .SetDisplay("Mammogram 3 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram 3 month follow-up")
                                    .MammoId("1822")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- Mammogram3MonthFollow-up
                            ,
                            //+ Mammogram6MonthFollow-up
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Mammogram6MonthFollow-up")
                                .SetDisplay("Mammogram 6 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram 6 month follow-up")
                                    .MammoId("1823")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- Mammogram6MonthFollow-up
                            ,
                            //+ MammogramAndUltrasound3MonthFollow-up
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MammogramAndUltrasound3MonthFollow-up")
                                .SetDisplay("Mammogram and ultrasound 3 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram and ultrasound 3 month follow-up")
                                    .MammoId("1826")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- MammogramAndUltrasound3MonthFollow-up
                            ,
                            //+ MammogramAndUltrasound6MonthFollow-up
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MammogramAndUltrasound6MonthFollow-up")
                                .SetDisplay("Mammogram and ultrasound 6 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mammogram and ultrasound 6 month follow-up")
                                    .MammoId("1827")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- MammogramAndUltrasound6MonthFollow-up
                            ,
                            //+ MediolateralObliqueView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MediolateralObliqueView")
                                .SetDisplay("Mediolateral oblique view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mediolateral oblique view")
                                    .MammoId("187")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)")
                            //- AutoGen
                            //- MediolateralObliqueView
                            ,
                            //+ MediolateralView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MediolateralView")
                                .SetDisplay("Mediolateral view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mediolateral view")
                                    .MammoId("162")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399260004 | Medial-lateral projection (Qualifier)")
                            //- AutoGen
                            //- MediolateralView
                            ,
                            //+ MLOWithCompressionView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MLOWithCompressionView")
                                .SetDisplay("MLO with compression view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] MLO with compression view")
                                    .MammoId("85")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression view (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)")
                            //- AutoGen
                            //- MLOWithCompressionView
                            ,
                            //+ MLOWithMagnificationView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MLOWithMagnificationView")
                                .SetDisplay("MLO with magnification view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] MLO with magnification view")
                                    .MammoId("83")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241058008 | Mammogram magnification (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)")
                            //- AutoGen
                            //- MLOWithMagnificationView
                            ,
                            //+ MRI
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MRI")
                                .SetDisplay("MRI")
                                .SetDefinition(new Definition()
                                    .Line("[PR] MRI")
                                    .MammoId("92")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241615005 | Magnetic resonance imaging of breast (Procedure)")
                            //- AutoGen
                            //- MRI
                            ,
                            //+ MRIBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MRIBiopsy")
                                .SetDisplay("MRI biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] MRI biopsy")
                                    .MammoId("120")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 433008009 | Core needle biopsy of breast using magnetic resonance imaging guidance (Procedure)")
                            //- AutoGen
                            //- MRIBiopsy
                            ,
                            //+ MRIFollow-up
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MRIFollow-up")
                                .SetDisplay("MRI follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] MRI follow-up")
                                    .MammoId("180")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.NM)
                            //- AutoGen
                            //- MRIFollow-up
                            ,
                            //+ NeedleLocationAndSurgicalBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NeedleLocationAndSurgicalBiopsy")
                                .SetDisplay("Needle location and surgical biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Needle location and surgical biopsy")
                                    .MammoId("53")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- NeedleLocationAndSurgicalBiopsy
                            ,
                            //+ NippleInProfileView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NippleInProfileView")
                                .SetDisplay("Nipple in profile view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Nipple in profile view")
                                    .MammoId("144")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 442581004 | Nipple in profile mammography view (Qualifier)")
                            //- AutoGen
                            //- NippleInProfileView
                            ,
                            //+ OffAngleCCView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("OffAngleCCView")
                                .SetDisplay("Off angle CC view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Off angle CC view")
                                    .MammoId("106")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)")
                            //- AutoGen
                            //- OffAngleCCView
                            ,
                            //+ OffAngleMLOView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("OffAngleMLOView")
                                .SetDisplay("Off angle MLO view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Off angle MLO view")
                                    .MammoId("107")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier) +++++")
                            //- AutoGen
                            //- OffAngleMLOView
                            ,
                            //+ Poss.StereotacticBx
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Poss.StereotacticBx")
                                .SetDisplay("Poss. Stereotactic Bx")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Poss. Stereotactic Bx")
                                    .MammoId("1837")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 116334007 | Stereotactically guided core needle biopsy of breast (Procedure) ++ POSSILE")
                            //- AutoGen
                            //- Poss.StereotacticBx
                            ,
                            //+ PossibleCoreBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PossibleCoreBiopsy")
                                .SetDisplay("Possible core biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible core biopsy")
                                    .MammoId("91")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 44578009 | Core needle biopsy of breast (Procedure) ++ POSSIBLE")
                            //- AutoGen
                            //- PossibleCoreBiopsy
                            ,
                            //+ PossibleDiagnosticMammogram
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PossibleDiagnosticMammogram")
                                .SetDisplay("Possible Diagnostic Mammogram")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible Diagnostic Mammogram")
                                    .MammoId("1836")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- PossibleDiagnosticMammogram
                            ,
                            //+ PossibleStereotacticVacuumBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PossibleStereotacticVacuumBiopsy")
                                .SetDisplay("Possible stereotactic vacuum biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible stereotactic vacuum biopsy")
                                    .MammoId("133")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- PossibleStereotacticVacuumBiopsy
                            ,
                            //+ PossibleSurgicalConsult
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PossibleSurgicalConsult")
                                .SetDisplay("Possible surgical consult")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible surgical consult")
                                    .MammoId("1805")
                                )
                                .ValidModalities(Modalities.NM)
                            //- AutoGen
                            //- PossibleSurgicalConsult
                            ,
                            //+ PossibleSurgicalEvaluation
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PossibleSurgicalEvaluation")
                                .SetDisplay("Possible surgical evaluation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible surgical evaluation")
                                    .MammoId("1806")
                                )
                                .ValidModalities(Modalities.NM)
                            //- AutoGen
                            //- PossibleSurgicalEvaluation
                            ,
                            //+ PossibleUltrasound
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PossibleUltrasound")
                                .SetDisplay("Possible ultrasound")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible ultrasound")
                                    .MammoId("186")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- PossibleUltrasound
                            ,
                            //+ PossibleUltrasoundGuidedBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PossibleUltrasoundGuidedBiopsy")
                                .SetDisplay("Possible ultrasound guided biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible ultrasound guided biopsy")
                                    .MammoId("130")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 432550005 | Core needle biopsy of breast using ultrasound guidance (Procedure) +++ POSSIBLE")
                            //- AutoGen
                            //- PossibleUltrasoundGuidedBiopsy
                            ,
                            //+ PossibleVacuumBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PossibleVacuumBiopsy")
                                .SetDisplay("Possible vacuum biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Possible vacuum biopsy")
                                    .MammoId("132")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- PossibleVacuumBiopsy
                            ,
                            //+ RepeatCCView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("RepeatCCView")
                                .SetDisplay("Repeat CC view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Repeat CC view")
                                    .MammoId("135")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399162004 | Cranio-caudal projection (Qualifier)")
                            //- AutoGen
                            //- RepeatCCView
                            ,
                            //+ RepeatMLOView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("RepeatMLOView")
                                .SetDisplay("Repeat MLO view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Repeat MLO view")
                                    .MammoId("134")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399368009 | Medio-lateral oblique projection (Qualifier)")
                            //- AutoGen
                            //- RepeatMLOView
                            ,
                            //+ RolledLateralView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("RolledLateralView")
                                .SetDisplay("Rolled lateral view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Rolled lateral view")
                                    .MammoId("49")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 399197002 | Lateral rolling of breast (Procedure)")
                            //- AutoGen
                            //- RolledLateralView
                            ,
                            //+ RolledMedialView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("RolledMedialView")
                                .SetDisplay("Rolled medial view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Rolled medial view")
                                    .MammoId("50")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 399226006 | Medial rolling of breast (Procedure)")
                            //- AutoGen
                            //- RolledMedialView
                            ,
                            //+ ScintiBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ScintiBiopsy")
                                .SetDisplay("Scinti biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scinti biopsy")
                                    .MammoId("1807")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- ScintiBiopsy
                            ,
                            //+ Scintimammography
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Scintimammography")
                                .SetDisplay("Scintimammography")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scintimammography")
                                    .MammoId("102")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- Scintimammography
                            ,
                            //+ SpotCompression
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SpotCompression")
                                .SetDisplay("Spot compression")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Spot compression")
                                    .MammoId("1801")
                                )
                                .ValidModalities(Modalities.MG | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression view (Procedure)")
                            //- AutoGen
                            //- SpotCompression
                            ,
                            //+ SpotMagnificationViews
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SpotMagnificationViews")
                                .SetDisplay("Spot magnification views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Spot magnification views")
                                    .MammoId("188")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241058008 | Mammogram magnification (Procedure) +++++")
                            //- AutoGen
                            //- SpotMagnificationViews
                            ,
                            //+ StereotacticBx
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("StereotacticBx")
                                .SetDisplay("Stereotactic bx")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Stereotactic bx")
                                    .MammoId("54")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 116334007 | Stereotactically guided core needle biopsy of breast (Procedure)")
                            //- AutoGen
                            //- StereotacticBx
                            ,
                            //+ SuperolateralIOView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SuperolateralIOView")
                                .SetDisplay("Superolateral IO view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Superolateral IO view")
                                    .MammoId("48")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- SuperolateralIOView
                            ,
                            //+ SurgicalBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalBiopsy")
                                .SetDisplay("Surgical biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical biopsy")
                                    .MammoId("1803")
                                )
                                .ValidModalities(Modalities.NM)
                                .SetSnomedDescription("Procedure | 274331003 | Surgical biopsy of breast (Procedure)")
                            //- AutoGen
                            //- SurgicalBiopsy
                            ,
                            //+ SurgicalConsult
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalConsult")
                                .SetDisplay("Surgical consult")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical consult")
                                    .MammoId("101")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- SurgicalConsult
                            ,
                            //+ SurgicalConsultAndBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalConsultAndBiopsy")
                                .SetDisplay("Surgical consult and biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical consult and biopsy")
                                    .MammoId("118")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 274331003 | Surgical biopsy of breast (Procedure) ++++")
                            //- AutoGen
                            //- SurgicalConsultAndBiopsy
                            ,
                            //+ SurgicalEvaluation
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalEvaluation")
                                .SetDisplay("Surgical evaluation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical evaluation")
                                    .MammoId("1802")
                                )
                                .ValidModalities(Modalities.NM)
                            //- AutoGen
                            //- SurgicalEvaluation
                            ,
                            //+ SurgicalExcision
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalExcision")
                                .SetDisplay("Surgical excision")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical excision")
                                    .MammoId("1804")
                                )
                                .ValidModalities(Modalities.NM)
                                .SetSnomedDescription("Procedure | 237372000 | Excisional biopsy of breast (Procedure)")
                            //- AutoGen
                            //- SurgicalExcision
                            ,
                            //+ SurgicalOncologicEvaluation
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalOncologicEvaluation")
                                .SetDisplay("Surgical oncologic evaluation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical oncologic evaluation")
                                    .MammoId("1810")
                                )
                                .ValidModalities(Modalities.NM)
                            //- AutoGen
                            //- SurgicalOncologicEvaluation
                            ,
                            //+ SurgicalOncologicalConsult
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalOncologicalConsult")
                                .SetDisplay("Surgical oncological consult")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical oncological consult")
                                    .MammoId("1809")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- SurgicalOncologicalConsult
                            ,
                            //+ TangentialView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("TangentialView")
                                .SetDisplay("Tangential view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Tangential view")
                                    .MammoId("114")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- TangentialView
                            ,
                            //+ TangentialViews
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("TangentialViews")
                                .SetDisplay("Tangential views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Tangential views")
                                    .MammoId("40")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- TangentialViews
                            ,
                            //+ Ultrasound
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Ultrasound")
                                .SetDisplay("Ultrasound")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound")
                                    .MammoId("181")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM)
                                .SetSnomedDescription("Procedure | 47079000 | Ultrasonography of breast (Procedure)")
                            //- AutoGen
                            //- Ultrasound
                            ,
                            //+ Ultrasound2ndLook
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Ultrasound2ndLook")
                                .SetDisplay("Ultrasound 2nd Look")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound 2nd Look")
                                    .MammoId("184")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- Ultrasound2ndLook
                            ,
                            //+ Ultrasound3MonthFollow-up
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Ultrasound3MonthFollow-up")
                                .SetDisplay("Ultrasound 3 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound 3 month follow-up")
                                    .MammoId("1824")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- Ultrasound3MonthFollow-up
                            ,
                            //+ Ultrasound6MonthFollow-up
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Ultrasound6MonthFollow-up")
                                .SetDisplay("Ultrasound 6 month follow-up")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound 6 month follow-up")
                                    .MammoId("1825")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- Ultrasound6MonthFollow-up
                            ,
                            //+ UltrasoundGuidedBx
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("UltrasoundGuidedBx")
                                .SetDisplay("Ultrasound guided bx")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound guided bx")
                                    .MammoId("55")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 432550005 | Core needle biopsy of breast using ultrasound guidance (Procedure)")
                            //- AutoGen
                            //- UltrasoundGuidedBx
                            ,
                            //+ UltrasoundLocationAndSurgicalBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("UltrasoundLocationAndSurgicalBiopsy")
                                .SetDisplay("Ultrasound location and surgical biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound location and surgical biopsy")
                                    .MammoId("171")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 274331003 | Surgical biopsy of breast (Procedure)++++++++++++")
                            //- AutoGen
                            //- UltrasoundLocationAndSurgicalBiopsy
                            ,
                            //+ UltrasoundWithPossibleAddlitonalViews
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("UltrasoundWithPossibleAddlitonalViews")
                                .SetDisplay("Ultrasound with possible addlitonal views")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Ultrasound with possible addlitonal views")
                                    .MammoId("189")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- UltrasoundWithPossibleAddlitonalViews
                            ,
                            //+ UnlessPreviousShowNoChange
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("UnlessPreviousShowNoChange")
                                .SetDisplay("Unless previous show no change")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Unless previous show no change")
                                    .MammoId("89")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- UnlessPreviousShowNoChange
                            ,
                            //+ Unspecified-Other
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Unspecified-Other")
                                .SetDisplay("Unspecified - other")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Unspecified - other")
                                    .MammoId("351")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- Unspecified-Other
                            ,
                            //+ VacuumBx
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("VacuumBx")
                                .SetDisplay("Vacuum Bx")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Vacuum Bx")
                                    .MammoId("131")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- VacuumBx
                            ,
                            //+ LateromedialOblique
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LateromedialOblique")
                                .SetDisplay("Lateromedial oblique")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateromedial oblique")
                                    .MammoId("47")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure)+ QualifierValue | 399352003 | Lateral-medial projection (Qualifier)")
                            //- AutoGen
                            ,
                            //- LateromedialOblique
                            //+ LateromedialView
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LateromedialView")
                                .SetDisplay("Lateromedial view")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lateromedial view")
                                    .MammoId("96")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) + QualifierValue | 399352003 | Lateral-medial projection (Qualifier)")
                            //- AutoGen
                            ,
                            //- LateromedialView
                            //+ Unspecified/Other
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Unspecified/Other")
                                .SetDisplay("Unspecified / other")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Unspecified / other")
                                    .MammoId("117")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                            //- AutoGen
                            ,
                            //- Unspecified/Other
                            //- RecommendationsCS
                        })
            );
    }
}
