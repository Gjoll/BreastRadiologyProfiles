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
                        Group_CommonCodesVS,
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
                            //+ Codes
                            new ConceptDef()
                                .SetCode("3DImaging")
                                .SetDisplay("3D Imaging")
                                .SetDefinition("[PR] 3D Imaging")
                                .MammoId("1828")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 450566007 | Digital breast tomosynthesis " +
                                    "(Procedure) +")
                                .SetUMLS("Advanced Technology that takes multiple images, or " +
                                    "X-rays, of breast tissue to recreate a 3-dimensional " +
                                    "picture of the breast. Also called breast tomosynthesis.")
                            ,
                            new ConceptDef()
                                .SetCode("3DSpotCC")
                                .SetDisplay("3D spot CC")
                                .SetDefinition("[PR] 3D spot CC")
                                .MammoId("1830")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 450566007 | Digital breast tomosynthesis " +
                                    "(Procedure) + QualifierValue | 399162004 | Cranio-caudal " +
                                    "projection (Qualifier) + SPOT")
                                .SetUMLS("Advanced Technology that takes multiple images, or " +
                                    "X-rays, of breast tissue to recreate a 3-dimensional " +
                                    "picture of the breast. Cranial-Caudal (CC) is a 3D " +
                                    "view from above the breast.")
                            ,
                            new ConceptDef()
                                .SetCode("3DSpotLM")
                                .SetDisplay("3D spot LM")
                                .SetDefinition("[PR] 3D spot LM")
                                .MammoId("1833")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 450566007 | Digital breast tomosynthesis " +
                                    "(Procedure) + QualifierValue | 399352003 | Lateral-medial " +
                                    "projection (Qualifier) + SPOT")
                                .SetUMLS("Advanced Technology that takes multiple images, or " +
                                    "X-rays, of breast tissue to recreate a 3-dimensional " +
                                    "picture of the breast. Lateral-medial (LM) is")
                            ,
                            new ConceptDef()
                                .SetCode("3DSpotML")
                                .SetDisplay("3D spot ML")
                                .SetDefinition("[PR] 3D spot ML")
                                .MammoId("1832")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 450566007 | Digital breast tomosynthesis " +
                                    "(Procedure) + QualifierValue | 399260004 | Medial-lateral " +
                                    "projection (Qualifier) + SPOT")
                                .SetUMLS("Advanced Technology that takes multiple images, or " +
                                    "X-rays, of breast tissue to recreate a 3-dimensional " +
                                    "picture of the breast. Mediolateral (ML) is")
                            ,
                            new ConceptDef()
                                .SetCode("3DSpotMLO")
                                .SetDisplay("3D spot MLO")
                                .SetDefinition("[PR] 3D spot MLO")
                                .MammoId("1831")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 450566007 | Digital breast tomosynthesis " +
                                    "(Procedure) + QualifierValue | 399368009 | Medio-lateral " +
                                    "oblique projection (Qualifier) + SPOT")
                                .SetUMLS("Advanced Technology that takes multiple images, or " +
                                    "X-rays, of breast tissue to recreate a 3-dimensional " +
                                    "picture of the breast. Mediolateral-oblique (MLO) " +
                                    "is")
                            ,
                            new ConceptDef()
                                .SetCode("AdditionalViews")
                                .SetDisplay("Additional views")
                                .SetDefinition("[PR] Additional views")
                                .MammoId("68")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("AddlitionalViewsWithPossibleUltrasound")
                                .SetDisplay("Addlitional views with possible ultrasound")
                                .SetDefinition("[PR] Addlitional views with possible ultrasound")
                                .MammoId("87")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 47079000 | Ultrasonography of breast " +
                                    "(Procedure)")
                            ,
                            new ConceptDef()
                                .SetCode("AxillaView")
                                .SetDisplay("Axilla view")
                                .SetDefinition("[PR] Axilla view")
                                .MammoId("1820")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("An axillary view (also known as a \"Cleopatra view\") " +
                                    "is a type of view in mammography. It is an exaggerated " +
                                    "craniocaudal view for better imaging of the lateral " +
                                    "portion of the breast to the axillary tail. This " +
                                    "projection is performed whenever we want to show " +
                                    "a lesion seen only in the axillary tail on the MLO " +
                                    "view. An optimal axillary view require to be clearly " +
                                    "displayed the most lateral portion of the breast " +
                                    "including the axillary tail, as well the pectoral " +
                                    "muscle and the nipple in profile.")
                            ,
                            new ConceptDef()
                                .SetCode("AxillaryTailView")
                                .SetDisplay("Axillary tail view")
                                .SetDefinition("[PR] Axillary tail view")
                                .MammoId("45")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 442580003 | Axillary tissue mammography " +
                                    "view (Qualifier)")
                                .SetUMLS("The tail of Spence (Spence's tail, axillary process, " +
                                    "axillary tail) is an extension of the tissue of the " +
                                    "breast that extends into the axilla. It is actually " +
                                    "an extension of the upper lateral quadrant of the " +
                                    "breast. It passes into the axilla through an opening " +
                                    "in the deep fascia called foramen of Langer.The Axilla " +
                                    "is another name for armpit.")
                            ,
                            new ConceptDef()
                                .SetCode("Biopsy")
                                .SetDisplay("Biopsy")
                                .SetDefinition("[PR] Biopsy")
                                .MammoId("100")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("BiopsyBaseOnClinical")
                                .SetDisplay("Biopsy base on clinical")
                                .SetDefinition("[PR] Biopsy base on clinical")
                                .MammoId("52")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("CaudocranialView")
                                .SetDisplay("Caudocranial view")
                                .SetDefinition("[PR] Caudocranial view")
                                .MammoId("46")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("It is useful for the study of breasts in the lower " +
                                    "quadrants. The patient will bend forward at the waist " +
                                    "to view the underside of the breast. Also called " +
                                    "a reverse CC view. The reversed CC view is an additional " +
                                    "view. It is useful for the study of breasts with " +
                                    "surgical scars in the lower quadrants. The ability " +
                                    "to see the scar through the compressor paddle offers " +
                                    "to the mammographer the possibility to flatten it " +
                                    "properly, reducing the formation of scar folds as " +
                                    "well artifacts from false parenchymal distortion.")
                            ,
                            new ConceptDef()
                                .SetCode("CCWithCompressionView")
                                .SetDisplay("CC with compression view")
                                .SetDefinition("[PR] CC with compression view")
                                .MammoId("84")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression " +
                                    "view (Procedure)+ QualifierValue | 399162004 | Cranio-caudal " +
                                    "projection (Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("CCWithMagnificationView")
                                .SetDisplay("CC with magnification view")
                                .SetDefinition("[PR] CC with magnification view")
                                .MammoId("82")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241058008 | Mammogram magnification (Procedure) " +
                                    "+ QualifierValue | 399162004 | Cranio-caudal projection " +
                                    "(Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("CleavageView")
                                .SetDisplay("Cleavage view")
                                .SetDefinition("[PR] Cleavage view")
                                .MammoId("44")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399161006 | Cleavage mammography " +
                                    "view (Qualifier)")
                                .SetUMLS("Also called \"valley view\" is a mammogram view that " +
                                    "images the most central portions of the breasts. " +
                                    "To get as much central tissue as possible, the mammogram " +
                                    "technologist will place both breasts on the plate " +
                                    "at the same time to image the medial half of both " +
                                    "breasts.")
                            ,
                            new ConceptDef()
                                .SetCode("ClinicalConsultation")
                                .SetDisplay("Clinical consultation")
                                .SetDefinition("[PR] Clinical consultation")
                                .MammoId("116")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("ClinicalCorrelation")
                                .SetDisplay("Clinical correlation")
                                .SetDefinition("[PR] Clinical correlation")
                                .MammoId("56")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("ClinicalFollow-up")
                                .SetDisplay("Clinical follow-up")
                                .SetDefinition("[PR] Clinical follow-up")
                                .MammoId("93")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("CompareToPriorExams")
                                .SetDisplay("Compare to prior exams")
                                .SetDefinition("[PR] Compare to prior exams")
                                .MammoId("103")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("CompressionViews")
                                .SetDisplay("Compression views")
                                .SetDefinition("[PR] Compression views")
                                .MammoId("43")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression " +
                                    "view (Procedure)")
                                .SetUMLS("All mammograms use compression of the breast. By " +
                                    "applying compression to only a specific area of the " +
                                    "breast, the effective pressure is increased on that " +
                                    "spot. This results in better tissue separation and " +
                                    "allows better visualization of the area of the breast " +
                                    "needing additional examination.")
                            ,
                            new ConceptDef()
                                .SetCode("ConeCompression")
                                .SetDisplay("Cone compression")
                                .SetDefinition("[PR] Cone compression")
                                .MammoId("185")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression " +
                                    "view (Procedure)")
                                .SetUMLS("A cone compression is to catch a specific spot or " +
                                    "view during the mammogram. Spot views apply the compression " +
                                    "to a smaller area of tissue using a small compression " +
                                    "plate or \"cone\".")
                            ,
                            new ConceptDef()
                                .SetCode("CoreBiopsy")
                                .SetDisplay("Core Biopsy")
                                .SetDefinition("[PR] Core Biopsy")
                                .MammoId("1829")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 44578009 | Core needle biopsy of breast " +
                                    "(Procedure)")
                                .SetUMLS("A core biopsy is a procedure where a needle is passed " +
                                    "through the skin to take a sample of tissue from " +
                                    "a mass or lump. The tissue is then examined under " +
                                    "a microscope for any abnormalities.")
                            ,
                            new ConceptDef()
                                .SetCode("CraniocaudalView")
                                .SetDisplay("Craniocaudal view")
                                .SetDefinition("[PR] Craniocaudal view")
                                .MammoId("332")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399162004 | Cranio-caudal projection " +
                                    "(Qualifier)")
                                .SetUMLS("Cranial-Caudal (CC) is a view from above the breast " +
                                    "during a mammogram or ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("Cryoablation")
                                .SetDisplay("Cryoablation")
                                .SetDefinition("[PR] Cryoablation")
                                .MammoId("168")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("Uses imaging guidance, a needle-like applicator called " +
                                    "a cryoprobe, and liquid nitrogen or argon gas to " +
                                    "create intense cold to freeze and destroy diseased " +
                                    "tissue, including cancer cells. It may be used to " +
                                    "treat a variety of skin conditions as well as tumors " +
                                    "within the liver, kidneys, bones, lungs and breasts.")
                            ,
                            new ConceptDef()
                                .SetCode("CystAspiration")
                                .SetDisplay("Cyst aspiration")
                                .SetDefinition("[PR] Cyst aspiration")
                                .MammoId("51")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 287572003 | Diagnostic aspiration of " +
                                    "breast cyst (Procedure)")
                                .SetUMLS("A medical procedure in which fluid or cells are drawn " +
                                    "out from a cyst using a needle. This is often performed " +
                                    "in order to do a biopsy. The needle is generally " +
                                    "inserted directly through the skin and may be guided " +
                                    "by a sonogram so the doctor can see what he's doing.")
                            ,
                            new ConceptDef()
                                .SetCode("CystAspirationForRelief")
                                .SetDisplay("Cyst aspiration for relief")
                                .SetDefinition("[PR] Cyst aspiration for relief")
                                .MammoId("1821")
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("Procedure | 287572003 | Diagnostic aspiration of " +
                                    "breast cyst (Procedure)")
                                .SetUMLS("One way to get relief from the pain of a cyst is " +
                                    "to remove fluid from the cyst, thereby decreasing " +
                                    "the pressure. This is called aspiration.")
                            ,
                            new ConceptDef()
                                .SetCode("DiagnosticAspiration")
                                .SetDisplay("Diagnostic aspiration")
                                .SetDefinition("[PR] Diagnostic aspiration")
                                .MammoId("108")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 287572003 | Diagnostic aspiration of " +
                                    "breast cyst (Procedure)")
                                .SetUMLS("This is a fine needle aspiration and is a type of " +
                                    "biopsy procedure. In fine needle aspiration, a thin " +
                                    "needle is inserted into an area of abnormal-appearing " +
                                    "tissue or body fluid.")
                            ,
                            new ConceptDef()
                                .SetCode("DiagnosticMammogram")
                                .SetDisplay("Diagnostic Mammogram")
                                .SetDefinition("[PR] Diagnostic Mammogram")
                                .MammoId("1834")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("While screening mammograms are used as a routine " +
                                    "check-up for breast health,  diagnostic mammograms " +
                                    "are used after suspicious results on a screening " +
                                    "mammogram or after some signs of breast cancer alert " +
                                    "the physician to check the tissue.These signs may " +
                                    "include a lump or breast pain.")
                            ,
                            new ConceptDef()
                                .SetCode("DrainageTube")
                                .SetDisplay("Drainage tube")
                                .SetDefinition("[PR] Drainage tube")
                                .MammoId("183")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("Ductography")
                                .SetDisplay("Ductography")
                                .SetDefinition("[PR] Ductography")
                                .MammoId("179")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 420131003 | Fluoroscopic mammary ductography " +
                                    "(Procedure)")
                                .SetUMLS("A ductogram (galactogram) is a type of medical imaging " +
                                    "used to view your breast ducts. It can be helpful " +
                                    "in finding the cause of nipple discharge. A ductogram involves " +
                                    "mammography and use of a contrast agent that gets " +
                                    "injected into the breast, like during a breast MRI. " +
                                    "A blunt-tipped sialogram needle (30-gauge) is used " +
                                    "for performing the ductogram. The abnormal duct is " +
                                    "identified and cannulated. Approximately 1-2 mL of " +
                                    "contrast is injected. A standard two-view mammography " +
                                    "(or craniocaudal and mediolateral projections) are " +
                                    "obtained.")
                            ,
                            new ConceptDef()
                                .SetCode("ExaggeratedCCViews")
                                .SetDisplay("Exaggerated CC views")
                                .SetDefinition("[PR] Exaggerated CC views")
                                .MammoId("41")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399265009 | Exaggerated cranio-caudal " +
                                    "projection (Qualifier)")
                                .SetUMLS("An XCCL view is a supplementary mammographic view. " +
                                    "It is a type of exaggerated cranio-caudal view. It " +
                                    "is particularly good for imaging the lateral aspect " +
                                    "of the breast. It is often done when a lesion is " +
                                    "suspected on a MLO view but cannot be seen on the CC " +
                                    "view. In this view, the lateral aspect of the breast " +
                                    "is placed forward. One rationale of performing this " +
                                    "view is that many cancers are located in the lateral " +
                                    "aspect of the breast. An XCCM view is a supplementary " +
                                    "mammographic view. It is a type of exaggerated cranio-caudal " +
                                    "view. It is particularly good for imaging the medial " +
                                    "portion of the breast. In this view, the medial portion " +
                                    "of the breast is placed forward. A negative 15° tube " +
                                    "tilt is suggested.An optimal XCCM view requires the " +
                                    "most medial portion of the breast and the nipple " +
                                    "in profile to be clearly displayed.")
                            ,
                            new ConceptDef()
                                .SetCode("FNABiopsy")
                                .SetDisplay("FNA biopsy")
                                .SetDefinition("[PR] FNA biopsy")
                                .MammoId("57")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("not matching")
                            ,
                            new ConceptDef()
                                .SetCode("Follow-up")
                                .SetDisplay("Follow-up")
                                .SetDefinition("[PR] Follow-up")
                                .MammoId("38")
                                .ValidModalities(Modalities.US)
                                .SetUMLS("It is recommended to make a follow-up appointment.")
                            ,
                            new ConceptDef()
                                .SetCode("Followup3Months")
                                .SetDisplay("Followup 3 months")
                                .SetDefinition("[PR] Followup 3 months")
                                .MammoId("123")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("It is recommended to make a follow-up appointment " +
                                    "in 3 months.")
                            ,
                            new ConceptDef()
                                .SetCode("Followup6Months")
                                .SetDisplay("Followup 6 months")
                                .SetDefinition("[PR] Followup 6 months")
                                .MammoId("119")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("It is recommended to make a follow-up appointment " +
                                    "in 6 months.")
                            ,
                            new ConceptDef()
                                .SetCode("IfPreviousShowNoChange")
                                .SetDisplay("If previous show no change")
                                .SetDefinition("[PR] If previous show no change")
                                .MammoId("89")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("LateralMagnificaionView")
                                .SetDisplay("Lateral magnificaion view")
                                .SetDefinition("[PR] Lateral magnificaion view")
                                .MammoId("161")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241058008 | Mammogram magnification (Procedure) " +
                                    "+ QualifierValue | 399067008 | Lateral projection " +
                                    "(Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("LateralMedialView")
                                .SetDisplay("Lateral medial view")
                                .SetDefinition("[PR] Lateral medial view")
                                .MammoId("90")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399352003 | Lateral-medial projection " +
                                    "(Qualifier)")
                                .SetUMLS("There are different views of the breast in mammography. " +
                                    "For the LM view, the tube is lateral and the detector " +
                                    "is placed mediallyLM view is best for evaluating " +
                                    "medial lesions.")
                            ,
                            new ConceptDef()
                                .SetCode("LateralView")
                                .SetDisplay("Lateral view")
                                .SetDefinition("[PR] Lateral view")
                                .MammoId("95")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399067008 | Lateral projection " +
                                    "(Qualifier)")
                                .SetUMLS("There are different views of the breast in mammography. " +
                                    "The lateral view is a view obtained at virtually " +
                                    "every diagnostic evaluation. A lateral view may be " +
                                    "obtained as a mediolateral view (ML) or lateromedial " +
                                    "view (LM) view depending on where the imaging tube " +
                                    "and detector are located.")
                            ,
                            new ConceptDef()
                                .SetCode("LateralWithCompressionView")
                                .SetDisplay("Lateral with compression view")
                                .SetDefinition("[PR] Lateral with compression view")
                                .MammoId("86")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression " +
                                    "view (Procedure) + QualifierValue | 399067008 | Lateral " +
                                    "projection (Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("LateromedialOblique")
                                .SetDisplay("Lateromedial oblique")
                                .SetDefinition("[PR] Lateromedial oblique")
                                .MammoId("47")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure)+ " +
                                    "QualifierValue | 399352003 | Lateral-medial projection " +
                                    "(Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("LateromedialView")
                                .SetDisplay("Lateromedial view")
                                .SetDefinition("[PR] Lateromedial view")
                                .MammoId("96")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399352003 | Lateral-medial projection " +
                                    "(Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("LymphNodeAssessment")
                                .SetDisplay("Lymph node assessment")
                                .SetDefinition("[PR] Lymph node assessment")
                                .MammoId("1835")
                                .ValidModalities(Modalities.MG)
                            ,
                            new ConceptDef()
                                .SetCode("MagnificationViews")
                                .SetDisplay("Magnification views")
                                .SetDefinition("[PR] Magnification views")
                                .MammoId("42")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 241058008 | Mammogram magnification (Procedure)")
                                .SetUMLS("A magnification view in mammography is performed " +
                                    "to evaluate and count microcalcifications and its " +
                                    "extension (as well the assessment of the borders " +
                                    "and the tissue structures of a suspicious area or " +
                                    "a mass) by using a magnification device which brings " +
                                    "the breast away from the film plate and closer to " +
                                    "the x-ray source. This allows the acquisition of " +
                                    "magnified images (1.5x to 2x magnification) of the " +
                                    "region of interest.")
                            ,
                            new ConceptDef()
                                .SetCode("Mammogram")
                                .SetDisplay("Mammogram")
                                .SetDefinition("[PR] Mammogram")
                                .MammoId("182")
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure)")
                            ,
                            new ConceptDef()
                                .SetCode("Mammogram3MonthFollow-up")
                                .SetDisplay("Mammogram 3 month follow-up")
                                .SetDefinition("[PR] Mammogram 3 month follow-up")
                                .MammoId("1822")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("A three month follow-up is recommended.")
                            ,
                            new ConceptDef()
                                .SetCode("Mammogram6MonthFollow-up")
                                .SetDisplay("Mammogram 6 month follow-up")
                                .SetDefinition("[PR] Mammogram 6 month follow-up")
                                .MammoId("1823")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("A six month follow-up is recommended.")
                            ,
                            new ConceptDef()
                                .SetCode("MammogramAndUltrasound3MonthFollow-up")
                                .SetDisplay("Mammogram and ultrasound 3 month follow-up")
                                .SetDefinition("[PR] Mammogram and ultrasound 3 month follow-up")
                                .MammoId("1826")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("A three month follow-up is recommended.")
                            ,
                            new ConceptDef()
                                .SetCode("MammogramAndUltrasound6MonthFollow-up")
                                .SetDisplay("Mammogram and ultrasound 6 month follow-up")
                                .SetDefinition("[PR] Mammogram and ultrasound 6 month follow-up")
                                .MammoId("1827")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("A six month follow-up is recommended.")
                            ,
                            new ConceptDef()
                                .SetCode("MediolateralObliqueView")
                                .SetDisplay("Mediolateral oblique view")
                                .SetDefinition("[PR] Mediolateral oblique view")
                                .MammoId("187")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399368009 | Medio-lateral oblique " +
                                    "projection (Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("MediolateralView")
                                .SetDisplay("Mediolateral view")
                                .SetDefinition("[PR] Mediolateral view")
                                .MammoId("162")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399260004 | Medial-lateral projection " +
                                    "(Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("MLOWithCompressionView")
                                .SetDisplay("MLO with compression view")
                                .SetDefinition("[PR] MLO with compression view")
                                .MammoId("85")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression " +
                                    "view (Procedure) + QualifierValue | 399368009 | Medio-lateral " +
                                    "oblique projection (Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("MLOWithMagnificationView")
                                .SetDisplay("MLO with magnification view")
                                .SetDefinition("[PR] MLO with magnification view")
                                .MammoId("83")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241058008 | Mammogram magnification (Procedure) " +
                                    "+ QualifierValue | 399368009 | Medio-lateral oblique " +
                                    "projection (Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("MRI")
                                .SetDisplay("MRI")
                                .SetDefinition("[PR] MRI")
                                .MammoId("92")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241615005 | Magnetic resonance imaging " +
                                    "of breast (Procedure)")
                            ,
                            new ConceptDef()
                                .SetCode("MRIBiopsy")
                                .SetDisplay("MRI biopsy")
                                .SetDefinition("[PR] MRI biopsy")
                                .MammoId("120")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 433008009 | Core needle biopsy of breast " +
                                    "using magnetic resonance imaging guidance (Procedure)")
                            ,
                            new ConceptDef()
                                .SetCode("MRIFollow-up")
                                .SetDisplay("MRI follow-up")
                                .SetDefinition("[PR] MRI follow-up")
                                .MammoId("180")
                                .ValidModalities(Modalities.MRI | Modalities.NM)
                            ,
                            new ConceptDef()
                                .SetCode("NeedleLocationAndSurgicalBiopsy")
                                .SetDisplay("Needle location and surgical biopsy")
                                .SetDefinition("[PR] Needle location and surgical biopsy")
                                .MammoId("53")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("NippleInProfileView")
                                .SetDisplay("Nipple in profile view")
                                .SetDefinition("[PR] Nipple in profile view")
                                .MammoId("144")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 442581004 | Nipple in profile " +
                                    "mammography view (Qualifier)")
                                .SetUMLS("A technically adequate exam has the nipple in profile, " +
                                    "allows visualization of the inframammary fold and " +
                                    "includes the pectoralis muscle extending down to " +
                                    "the posterior nipple line (an oblique line drawn " +
                                    "straight back from the nipple.)")
                            ,
                            new ConceptDef()
                                .SetCode("OffAngleCCView")
                                .SetDisplay("Off angle CC view")
                                .SetDefinition("[PR] Off angle CC view")
                                .MammoId("106")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399162004 | Cranio-caudal projection " +
                                    "(Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("OffAngleMLOView")
                                .SetDisplay("Off angle MLO view")
                                .SetDefinition("[PR] Off angle MLO view")
                                .MammoId("107")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399368009 | Medio-lateral oblique " +
                                    "projection (Qualifier) +++++")
                            ,
                            new ConceptDef()
                                .SetCode("Poss.StereotacticBx")
                                .SetDisplay("Poss. Stereotactic Bx")
                                .SetDefinition("[PR] Poss. Stereotactic Bx")
                                .MammoId("1837")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 116334007 | Stereotactically guided core " +
                                    "needle biopsy of breast (Procedure) ++ POSSILE")
                                .SetUMLS("A stereotactic breast biopsy may be performed when " +
                                    "a mammogram shows a breast abnormality such as: a " +
                                    "suspicious mass. microcalcifications, which are a " +
                                    "tiny cluster of small calcium deposits. a distortion " +
                                    "in the structure of the breast tissue.")
                            ,
                            new ConceptDef()
                                .SetCode("PossibleCoreBiopsy")
                                .SetDisplay("Possible core biopsy")
                                .SetDefinition("[PR] Possible core biopsy")
                                .MammoId("91")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 44578009 | Core needle biopsy of breast " +
                                    "(Procedure) ++ POSSIBLE")
                            ,
                            new ConceptDef()
                                .SetCode("PossibleDiagnosticMammogram")
                                .SetDisplay("Possible Diagnostic Mammogram")
                                .SetDefinition("[PR] Possible Diagnostic Mammogram")
                                .MammoId("1836")
                                .ValidModalities(Modalities.MG)
                            ,
                            new ConceptDef()
                                .SetCode("PossibleStereotacticVacuumBiopsy")
                                .SetDisplay("Possible stereotactic vacuum biopsy")
                                .SetDefinition("[PR] Possible stereotactic vacuum biopsy")
                                .MammoId("133")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("Stereotactic Vacuum Assisted Biopsy. ... During this " +
                                    "type of biopsy, small samples of tissue are removed " +
                                    "from the breast using a hollow needle, which is precisely " +
                                    "guided to the correct location using x-rays and computer " +
                                    "generated coordinates of the concerning area of breast " +
                                    "tissue.")
                            ,
                            new ConceptDef()
                                .SetCode("PossibleSurgicalConsult")
                                .SetDisplay("Possible surgical consult")
                                .SetDefinition("[PR] Possible surgical consult")
                                .MammoId("1805")
                                .ValidModalities(Modalities.NM)
                            ,
                            new ConceptDef()
                                .SetCode("PossibleSurgicalEvaluation")
                                .SetDisplay("Possible surgical evaluation")
                                .SetDefinition("[PR] Possible surgical evaluation")
                                .MammoId("1806")
                                .ValidModalities(Modalities.NM)
                            ,
                            new ConceptDef()
                                .SetCode("PossibleUltrasound")
                                .SetDisplay("Possible ultrasound")
                                .SetDefinition("[PR] Possible ultrasound")
                                .MammoId("186")
                                .ValidModalities(Modalities.MG)
                            ,
                            new ConceptDef()
                                .SetCode("PossibleUltrasoundGuidedBiopsy")
                                .SetDisplay("Possible ultrasound guided biopsy")
                                .SetDefinition("[PR] Possible ultrasound guided biopsy")
                                .MammoId("130")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 432550005 | Core needle biopsy of breast " +
                                    "using ultrasound guidance (Procedure) +++ POSSIBLE")
                            ,
                            new ConceptDef()
                                .SetCode("PossibleVacuumBiopsy")
                                .SetDisplay("Possible vacuum biopsy")
                                .SetDefinition("[PR] Possible vacuum biopsy")
                                .MammoId("132")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("A vacuum assisted biopsy is a way of removing an " +
                                    "area of abnormal cells from the breast tissue. A " +
                                    "doctor or nurse uses a special needle attached to " +
                                    "a vacuum device to remove the cells. The samples " +
                                    "can then be examined under a microscope. This can " +
                                    "show whether there is a cancer or another type of " +
                                    "breast condition.")
                            ,
                            new ConceptDef()
                                .SetCode("RepeatCCView")
                                .SetDisplay("Repeat CC view")
                                .SetDefinition("[PR] Repeat CC view")
                                .MammoId("135")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399162004 | Cranio-caudal projection " +
                                    "(Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("RepeatMLOView")
                                .SetDisplay("Repeat MLO view")
                                .SetDefinition("[PR] Repeat MLO view")
                                .MammoId("134")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241055006 | Mammogram - symptomatic (Procedure) " +
                                    "+ QualifierValue | 399368009 | Medio-lateral oblique " +
                                    "projection (Qualifier)")
                            ,
                            new ConceptDef()
                                .SetCode("RolledLateralView")
                                .SetDisplay("Rolled lateral view")
                                .SetDefinition("[PR] Rolled lateral view")
                                .MammoId("49")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 399197002 | Lateral rolling of breast " +
                                    "(Procedure)")
                                .SetUMLS("Given that the rolled projections can be performed " +
                                    "from any standard projection, the most commonly used " +
                                    "is certainly the cranio-caudal one. A rolled CC view- " +
                                    "It's performed to locate a lesion only visible in " +
                                    "the cranio-caudal view, or when overlapped tissues " +
                                    "in the standard view can simulate or partially conceal " +
                                    "a lesion: changing of  tissues distribution  allows " +
                                    "to determine whether or not its presence. The breast " +
                                    "is positioned on the image receptor as for the cranio-caudal " +
                                    "view, then is rotated medially or laterally around " +
                                    "the axis of the nipple prior to applying compression.")
                            ,
                            new ConceptDef()
                                .SetCode("RolledMedialView")
                                .SetDisplay("Rolled medial view")
                                .SetDefinition("[PR] Rolled medial view")
                                .MammoId("50")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 399226006 | Medial rolling of breast " +
                                    "(Procedure)")
                            ,
                            new ConceptDef()
                                .SetCode("ScintiBiopsy")
                                .SetDisplay("Scinti biopsy")
                                .SetDefinition("[PR] Scinti biopsy")
                                .MammoId("1807")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("This is a fine needle aspiration and is a type of " +
                                    "biopsy procedure. In fine needle aspiration, a thin " +
                                    "needle is inserted into an area of abnormal-appearing " +
                                    "tissue or body fluid. This is also can be called " +
                                    "a Scinti biopsy.")
                            ,
                            new ConceptDef()
                                .SetCode("Scintimammography")
                                .SetDisplay("Scintimammography")
                                .SetDefinition("[PR] Scintimammography")
                                .MammoId("102")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("Scintimammography is also known as nuclear medicine " +
                                    "breast imaging, Breast Specific Gamma Imaging (BSGI) " +
                                    "and Molecular Breast Imaging (MBI). Your doctor may " +
                                    "use this exam to investigate a breast abnormality " +
                                    "found with mammography.")
                            ,
                            new ConceptDef()
                                .SetCode("SpotCompression")
                                .SetDisplay("Spot compression")
                                .SetDefinition("[PR] Spot compression")
                                .MammoId("1801")
                                .ValidModalities(Modalities.MG | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 439324009 | Mammogram in compression " +
                                    "view (Procedure)")
                                .SetUMLS("A spot view (also known as a spot compression view or focal " +
                                    "compression view) is an additional mammographic view performed " +
                                    "by applying the compression to a smaller area of " +
                                    "tissue using a small compression paddle, increasing " +
                                    "the effective pressure on that spot. This results " +
                                    "in better tissue separation and allows better visualization " +
                                    "of the breast tissue in that area. It is used to " +
                                    "distinguish between the presence of a true lesion " +
                                    "and an overlap of tissues, as well to better show " +
                                    "the borders of an abnormality or questionable area " +
                                    "or a little cluster of faint microcalcifications " +
                                    "in a dense area. The improved resolution is due to " +
                                    "the increased reduction of thickness in the examined " +
                                    "area and by getting the suspicious area closer to " +
                                    "the detector surface.")
                            ,
                            new ConceptDef()
                                .SetCode("SpotMagnificationViews")
                                .SetDisplay("Spot magnification views")
                                .SetDefinition("[PR] Spot magnification views")
                                .MammoId("188")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("Procedure | 241058008 | Mammogram magnification (Procedure) " +
                                    "+++++")
                            ,
                            new ConceptDef()
                                .SetCode("StereotacticBx")
                                .SetDisplay("Stereotactic bx")
                                .SetDefinition("[PR] Stereotactic bx")
                                .MammoId("54")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 116334007 | Stereotactically guided core " +
                                    "needle biopsy of breast (Procedure)")
                                .SetUMLS("Stereotactic breast biopsy uses mammography – a specific " +
                                    "type of breast imaging that uses low-dose x-rays " +
                                    "— to help locate a breast abnormality and remove " +
                                    "a tissue sample for examination under a microscope. " +
                                    "It's less invasive than surgical biopsy, leaves little " +
                                    "to no scarring and can be an excellent way to evaluate " +
                                    "calcium deposits or tiny masses that are not visible " +
                                    "on ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("SuperolateralIOView")
                                .SetDisplay("Superolateral IO view")
                                .SetDefinition("[PR] Superolateral IO view")
                                .MammoId("48")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalBiopsy")
                                .SetDisplay("Surgical biopsy")
                                .SetDefinition("[PR] Surgical biopsy")
                                .MammoId("1803")
                                .ValidModalities(Modalities.NM)
                                .SetSnomedDescription("Procedure | 274331003 | Surgical biopsy of breast " +
                                    "(Procedure)")
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalConsult")
                                .SetDisplay("Surgical consult")
                                .SetDefinition("[PR] Surgical consult")
                                .MammoId("101")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalConsultAndBiopsy")
                                .SetDisplay("Surgical consult and biopsy")
                                .SetDefinition("[PR] Surgical consult and biopsy")
                                .MammoId("118")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("Procedure | 274331003 | Surgical biopsy of breast " +
                                    "(Procedure) ++++")
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalEvaluation")
                                .SetDisplay("Surgical evaluation")
                                .SetDefinition("[PR] Surgical evaluation")
                                .MammoId("1802")
                                .ValidModalities(Modalities.NM)
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalExcision")
                                .SetDisplay("Surgical excision")
                                .SetDefinition("[PR] Surgical excision")
                                .MammoId("1804")
                                .ValidModalities(Modalities.NM)
                                .SetSnomedDescription("Procedure | 237372000 | Excisional biopsy of breast " +
                                    "(Procedure)")
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalOncologicEvaluation")
                                .SetDisplay("Surgical oncologic evaluation")
                                .SetDefinition("[PR] Surgical oncologic evaluation")
                                .MammoId("1810")
                                .ValidModalities(Modalities.NM)
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalOncologicalConsult")
                                .SetDisplay("Surgical oncological consult")
                                .SetDefinition("[PR] Surgical oncological consult")
                                .MammoId("1809")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("TangentialView")
                                .SetDisplay("Tangential view")
                                .SetDefinition("[PR] Tangential view")
                                .MammoId("114")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("TangentialViews")
                                .SetDisplay("Tangential views")
                                .SetDefinition("[PR] Tangential views")
                                .MammoId("40")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("Ultrasound")
                                .SetDisplay("Ultrasound")
                                .SetDefinition("[PR] Ultrasound")
                                .MammoId("181")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM)
                                .SetSnomedDescription("Procedure | 47079000 | Ultrasonography of breast " +
                                    "(Procedure)")
                            ,
                            new ConceptDef()
                                .SetCode("Ultrasound2ndLook")
                                .SetDisplay("Ultrasound 2nd Look")
                                .SetDefinition("[PR] Ultrasound 2nd Look")
                                .MammoId("184")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("Ultrasound3MonthFollow-up")
                                .SetDisplay("Ultrasound 3 month follow-up")
                                .SetDefinition("[PR] Ultrasound 3 month follow-up")
                                .MammoId("1824")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("Ultrasound6MonthFollow-up")
                                .SetDisplay("Ultrasound 6 month follow-up")
                                .SetDefinition("[PR] Ultrasound 6 month follow-up")
                                .MammoId("1825")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("UltrasoundGuidedBx")
                                .SetDisplay("Ultrasound guided bx")
                                .SetDefinition("[PR] Ultrasound guided bx")
                                .MammoId("55")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("Procedure | 432550005 | Core needle biopsy of breast " +
                                    "using ultrasound guidance (Procedure)")
                            ,
                            new ConceptDef()
                                .SetCode("UltrasoundLocationAndSurgicalBiopsy")
                                .SetDisplay("Ultrasound location and surgical biopsy")
                                .SetDefinition("[PR] Ultrasound location and surgical biopsy")
                                .MammoId("171")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("Procedure | 274331003 | Surgical biopsy of breast " +
                                    "(Procedure)++++++++++++")
                            ,
                            new ConceptDef()
                                .SetCode("UltrasoundWithPossibleAddlitonalViews")
                                .SetDisplay("Ultrasound with possible addlitonal views")
                                .SetDefinition("[PR] Ultrasound with possible addlitonal views")
                                .MammoId("189")
                                .ValidModalities(Modalities.MG)
                            ,
                            new ConceptDef()
                                .SetCode("Unspecified/Other")
                                .SetDisplay("Unspecified / other")
                                .SetDefinition("[PR] Unspecified / other")
                                .MammoId("117")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("VacuumBx")
                                .SetDisplay("Vacuum Bx")
                                .SetDefinition("[PR] Vacuum Bx")
                                .MammoId("131")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("A vacuum assisted biopsy is a way of removing an " +
                                    "area of abnormal cells from the breast tissue. A " +
                                    "doctor or nurse uses a special needle attached to " +
                                    "a vacuum device to remove the cells. The samples " +
                                    "can then be examined under a microscope. This can " +
                                    "show whether there is a cancer or another type of " +
                                    "breast condition. Bx: Abbreviation for biopsy, the " +
                                    "removal of a sample of tissue for examination or " +
                                    "other study. Biopsies are most frequently studied " +
                                    "by use of a microscope to check for possible abnormalities " +
                                    "such as inflammation or cancer.")
                            //- Codes
                        })
            );
    }
}
