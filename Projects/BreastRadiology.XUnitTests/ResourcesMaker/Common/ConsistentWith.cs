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
    partial class ResourcesMaker
    {
        SDTaskVar ConsistentWith = new SDTaskVar(
               (out StructureDefinition  s) =>
                   {
                       SDefEditor e = Self.CreateEditor("ConsistentWith",
                        "Consistent With",
                        "Consistent/With",
                        Global.ObservationUrl,
                        $"{Group_CommonResources}/ConsistentWith",
                        "ObservationLeaf")
                           .AddFragRef(Self.ObservationLeafFragment.Value())
                           .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                           .AddFragRef(Self.ObservationNoValueFragment.Value())
                           .AddFragRef(Self.ObservationNoComponentFragment.Value())
                           .Description("'Consistent With' Observation",
                               new Markdown()
                           )
                           ;
                       s = e.SDef;

                       // Set Observation.code to unique value for this profile.
                       e.Select("code").Pattern(Self.ObservationCodeConsistentWith.ToCodeableConcept());


                       e.StartComponentSliceing();
                       e.ComponentSliceCodeableConcept("value",
                           Self.ComponentSliceCodeConsistentWithValue.ToCodeableConcept(),
                           Self.ConsistentWithVS.Value(),
                           BindingStrength.Extensible,
                           1,
                           "1",
                           "Consistent With Value",
                            new Markdown()
                                .Paragraph($"This slice contains the required component that defines what this observation is consistent with.",
                                            $"The value of this component is a codeable concept chosen from the {Self.ConsistentWithVS.Value().Name} valueset.")
                       );
                       e.ComponentSliceCodeableConcept("qualifier",
                           Self.ComponentSliceCodeConsistentWithQualifier.ToCodeableConcept(),
                           Self.ConsistentWithQualifierVS.Value(),
                           BindingStrength.Required,
                           0,
                           "*",
                           "Consistent With Qualifier",
                            new Markdown()
                                .Paragraph($"This slice contains zero or more components that qualify the consistent with slice component value.",
                                            $"The value of this component is a codeable concept chosen from the {Self.ConsistentWithVS.Value().Name} valueset.")
                           );

                       e.IntroDoc
                           .ReviewedStatus("NOONE", "")
                           ;
                   });

        VSTaskVar ConsistentWithVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "ConsistentWithVS",
                        "ConsistentWith ValueSet",
                        "ConsistentWith/ValueSet",
                        "ConsistentWith value set.",
                        Group_CommonCodesVS,
                        Self.ConsistentWithCS.Value()
                    )
            );

        VSTaskVar ConsistentWithQualifierVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "ConsistentWithQualifierVS",
                        "ConsistentWithQualifier ValueSet",
                        "ConsistentWithQualifier/ValueSet",
                        "ConsistentWithQualifier value set.",
                        Group_CommonCodesVS,
                        Self.ConsistentWithQualifierCS.Value()
                    )
            );

        CSTaskVar ConsistentWithCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "ConsistentWithCodeSystemCS",
                        "Consistent With CodeSystem",
                        "ConsistentWith/CodeSystem",
                        "ConsistentWith code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            //+ Codes
                            //+ Abscess
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Abscess")
                                .SetDisplay("Abscess")
                                .SetDefinition("[PR] Abscess")
                                .MammoId("104")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("An area within the body tissue that is swollen and " +
                                    "contains an accumulation of pus.")
                            //- AutoGen
                            //- Abscess
                            ,
                            //+ Angiolipoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Angiolipoma")
                                .SetDisplay("Angiolipoma")
                                .SetDefinition("[PR] Angiolipoma")
                                .MammoId("503")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("404057003")
                                .SetSnomedDescription("ClinicalFinding | Angiolipoma (Disorder)")
                                .SetICD10("D17.9")
                                .SetUMLS("Angiolipoma is a rare type of lipoma — a growth made " +
                                    "of fat and blood vessels that develops under your " +
                                    "skin.  Unlike other types of lipomas, angiolipomas " +
                                    "are often painful or tender.")
                            //- AutoGen
                            //- Angiolipoma
                            ,
                            //+ ApocrineMetaplasia
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ApocrineMetaplasia")
                                .SetDisplay("Apocrine metaplasia")
                                .SetDefinition("[PR] Apocrine metaplasia")
                                .MammoId("948")
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 37009001 | Apocrine metaplasia " +
                                    "of breast (Disorder) | [0/0] | N60.89")
                                .SetUMLS("Apocrine Metaplasia refers to a particular type of " +
                                    "cell change. ... This means that the epithelial cells " +
                                    "are undergoing an unexpected change. These breast " +
                                    "changes may show on a mammogram and biopsy as a mass " +
                                    "or benign lesion, or possibly even develop into a " +
                                    "palpable mass.")
                            //- AutoGen
                            //- ApocrineMetaplasia
                            ,
                            //+ Artifact
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Artifact")
                                .SetDisplay("Artifact")
                                .SetDefinition("[PR] Artifact")
                                .MammoId("946")
                                .ValidModalities(Modalities.NM)
                                .SetUMLS("In medical imaging, artifacts are misrepresentations " +
                                    "of tissue structures produced by imaging techniques " +
                                    "such as ultrasound, X-ray, CT scan, and magnetic " +
                                    "resonance imaging (MRI).")
                            //- AutoGen
                            //- Artifact
                            ,
                            //+ AtypicalHyperplasia
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("AtypicalHyperplasia")
                                .SetDisplay("Atypical hyperplasia")
                                .SetDefinition("[PR] Atypical hyperplasia")
                                .MammoId("545")
                                .ValidModalities(Modalities.MRI)
                                .SetUMLS("Atypical hyperplasia is a precancerous condition " +
                                    "that affects cells in the breast. Atypical hyperplasia " +
                                    "describes an accumulation of abnormal cells in the " +
                                    "breast. Atypical hyperplasia isn't cancer, but it " +
                                    "can be a forerunner to the development of breast " +
                                    "cancer.")
                            //- AutoGen
                            //- AtypicalHyperplasia
                            ,
                            //+ AxillaryLymphNode
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("AxillaryLymphNode")
                                .SetDisplay("Axillary lymph node")
                                .SetDefinition("[PR] Axillary lymph node")
                                .MammoId("942")
                                .ValidModalities(Modalities.NM)
                                .SetSnomedDescription("BodyStructure | 245269009 | Axillary lymph node group " +
                                    "(Bodypart)")
                                .SetUMLS("Axillary lymph nodes are the lymph nodes located " +
                                    "in the armpits. They can become enlarged in many " +
                                    "conditions including infections, lymphomas, and breast " +
                                    "cancers. Lymph nodes are small structures located " +
                                    "all over the body around blood vessels that act as " +
                                    "filters and can accumulate germs or cancer cells. " +
                                    "They are a part of the lymph system of the body.")
                            //- AutoGen
                            //- AxillaryLymphNode
                            ,
                            //+ Carcinoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Carcinoma")
                                .SetDisplay("Carcinoma")
                                .SetDefinition("[PR] Carcinoma")
                                .MammoId("542")
                                .ValidModalities(Modalities.MRI)
                                .SetUMLS("Carcinoma is a type of cancer that starts in cells " +
                                    "that make up the skin or the tissue lining organs")
                            //- AutoGen
                            //- Carcinoma
                            ,
                            //+ CarcinomaKnown
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CarcinomaKnown")
                                .SetDisplay("Carcinoma known")
                                .SetDefinition("[PR] Carcinoma known")
                                .MammoId("543")
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            //- CarcinomaKnown
                            ,
                            //+ ClusterOfCysts
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ClusterOfCysts")
                                .SetDisplay("Cluster of cysts")
                                .SetDefinition("[PR] Cluster of cysts")
                                .MammoId("577")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("399294002")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding |Cyst of breast (Disorder) ++++++")
                                .SetICD10("N60.09")
                                .SetComment("BodyStructure | 125291005 | Multiple cysts (Morphologic-Abnormality")
                                .SetUMLS("A breast cyst is a benign (non-cancerous) fluid-filled " +
                                    "sac in the breast. They are most common in pre-menopausal " +
                                    "women and in post-menopausal women taking hormone " +
                                    "therapy. Some cysts are too small to feel and others " +
                                    "may be quite large and uncomfortable. Sometimes there " +
                                    "are clusters of cysts in one breast or both.")
                            //- AutoGen
                            //- ClusterOfCysts
                            ,
                            //+ Cyst
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Cyst")
                                .SetDisplay("Cyst")
                                .SetDefinition("[PR] Cyst")
                                .MammoId("565")
                                .ValidModalities(Modalities.MG | Modalities.MRI)
                                .SetSnomedCode("399294002")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding |Cyst of breast (Disorder)")
                                .SetICD10("N60.09")
                            //- AutoGen
                            //- Cyst
                            ,
                            //+ CystComplex
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystComplex")
                                .SetDisplay("Cyst complex")
                                .SetDefinition("[PR] Cyst complex")
                                .MammoId("61")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("449837001")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding | Complex cyst of breast (Disorder)")
                                .SetICD10("N60.09")
                                .SetUMLS("Refers to cysts that contain something more than " +
                                    "clear fluid. A complex breast cyst contains solid " +
                                    "elements suspended within the fluid, and may also " +
                                    "feature segmentation (septation) and some regions " +
                                    "of the cyst wall that are ‘thicker‘ than others.")
                            //- AutoGen
                            //- CystComplex
                            ,
                            //+ CystComplicated
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystComplicated")
                                .SetDisplay("Cyst complicated")
                                .SetDefinition("[PR] Cyst complicated")
                                .MammoId("115")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetComment("NO CORRECT TERM")
                                .SetUMLS("Complicated cysts are \"in between\" a simple cyst and " +
                                    "a complex cyst. A complicated breast cyst contains " +
                                    "solid elements suspended within the fluid, and may " +
                                    "also feature segmentation (septation) and some regions " +
                                    "of the cyst wall that are ‘thicker‘ than others. " +
                                    "Complicated breast cysts are one of the cystic breast " +
                                    "lesions that show intracystic debris which may imitate " +
                                    "a solid mass appearance.")
                            //- AutoGen
                            //- CystComplicated
                            ,
                            //+ CystOil
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystOil")
                                .SetDisplay("Cyst oil")
                                .SetDefinition("[PR] Cyst oil")
                                .MammoId("582")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetComment("NO OIL CYST")
                                .SetUMLS("Oil cysts are filled with fluid that may feel smooth " +
                                    "and soft/squishy. They are caused by the breakdown " +
                                    "of fatty tissue.")
                            //- AutoGen
                            //- CystOil
                            ,
                            //+ CystSebaceous
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystSebaceous")
                                .SetDisplay("Cyst sebaceous")
                                .SetDefinition("[PR] Cyst sebaceous")
                                .MammoId("501")
                                .ValidModalities(Modalities.US)
                                .SetSnomedCode("76649007")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding | Sebaceous cyst of skin of breast " +
                                    "(Disorder)")
                                .SetICD10("N60.89")
                                .SetUMLS("Sebaceous cysts form out of your sebaceous gland. " +
                                    "The sebaceous gland produces the oil (called sebum) " +
                                    "that coats your hair and skin.Cysts can develop if " +
                                    "the gland or its duct (the passage from which the " +
                                    "oil is able to leave) becomes damaged or blocked. " +
                                    "This usually occurs due to a trauma to the area.")
                            //- AutoGen
                            //- CystSebaceous
                            ,
                            //+ CystSimple
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystSimple")
                                .SetDisplay("Cyst simple")
                                .SetDefinition("[PR] Cyst simple")
                                .MammoId("60")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("399253005")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding | Simple cyst of breast (Disorder)")
                                .SetICD10("N60.09")
                            //- AutoGen
                            //- CystSimple
                            ,
                            //+ CystsComplex
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystsComplex")
                                .SetDisplay("Cysts complex")
                                .SetDefinition("[PR] Cysts complex")
                                .MammoId("537")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("449837001")
                                .SetOneToMany("Many")
                                .SetSnomedDescription("ClinicalFinding | Complex cyst of breast (Disorder)")
                                .SetICD10("N60.09")
                                .SetUMLS("Refers to cysts that contain something more than " +
                                    "clear fluid. A complex breast cyst contains solid " +
                                    "elements suspended within the fluid, and may also " +
                                    "feature segmentation (septation) and some regions " +
                                    "of the cyst wall that are ‘thicker‘ than others.")
                            //- AutoGen
                            //- CystsComplex
                            ,
                            //+ CystsComplicated
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystsComplicated")
                                .SetDisplay("Cysts complicated")
                                .SetDefinition("[PR] Cysts complicated")
                                .MammoId("506")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetComment("NO CORRECT TERM")
                                .SetUMLS("Complicated cysts are \"in between\" a simple cyst and " +
                                    "a complex cyst. A complicated breast cyst contains " +
                                    "solid elements suspended within the fluid, and may " +
                                    "also feature segmentation (septation) and some regions " +
                                    "of the cyst wall that are ‘thicker‘ than others. " +
                                    "Complicated breast cysts are one of the cystic breast " +
                                    "lesions that show intracystic debris which may imitate " +
                                    "a solid mass appearance.")
                            //- AutoGen
                            //- CystsComplicated
                            ,
                            //+ CystsMicroClustered
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystsMicroClustered")
                                .SetDisplay("Cysts micro clustered")
                                .SetDefinition("[PR] Cysts micro clustered")
                                .MammoId("505")
                                .ValidModalities(Modalities.US)
                                .SetComment("NO CORRECT TERM")
                                .SetUMLS("A cyst is a  pocket of tissue that contains fluid, " +
                                    "air, or other substances. A Microcyst is small and " +
                                    "less than 2-3 mm. They are often in clusters and " +
                                    "only show up on a mammogram or ultrasound.")
                            //- AutoGen
                            //- CystsMicroClustered
                            ,
                            //+ DCIS
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DCIS")
                                .SetDisplay("DCIS")
                                .SetDefinition("[PR] DCIS")
                                .MammoId("514")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetOneToMany("?????")
                                .SetSnomedDescription("BodyStructure | 399935008 | Ductal carcinoma in situ " +
                                    "- category (Morphologic-Abnormality)")
                                .SetUMLS("Ductal carcinoma in situ (DCIS) is the presence of " +
                                    "abnormal cells inside a milk duct in the breast. " +
                                    "DCIS is considered the earliest form of breast cancer. " +
                                    "DCIS is noninvasive, meaning it hasn't spread out " +
                                    "of the milk duct and has a low risk of becoming invasive.")
                            //- AutoGen
                            //- DCIS
                            ,
                            //+ Debris
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Debris")
                                .SetDisplay("Debris")
                                .SetDefinition("[PR] Debris")
                                .MammoId("515")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- Debris
                            ,
                            //+ Deodorant
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Deodorant")
                                .SetDisplay("Deodorant")
                                .SetDefinition("[PR] Deodorant")
                                .MammoId("589")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("39432004")
                                .SetSnomedDescription("PharmaceuticalBiologicProduct | Deodorant (Product)")
                            //- AutoGen
                            //- Deodorant
                            ,
                            //+ DermalCalcification
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DermalCalcification")
                                .SetDisplay("Dermal calcification")
                                .SetDefinition("[PR] Dermal calcification")
                                .MammoId("572")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("Skin calcifications in the breast usually form in " +
                                    "dermal sweat glands after low grade folliculitis " +
                                    "and inspissation of sebaceous material. Calcifications " +
                                    "may also form in moles and other skin lesions. Often, " +
                                    "these calcifications are in groups as they extend " +
                                    "into small glands in the skin.")
                            //- AutoGen
                            //- DermalCalcification
                            ,
                            //+ DuctEctasia
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DuctEctasia")
                                .SetDisplay("Duct ectasia")
                                .SetDefinition("[PR] Duct ectasia")
                                .MammoId("64")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 22049009 | Mammary duct ectasia " +
                                    "(Disorder) | [0/0] | N60.49")
                                .SetUMLS("An abnormal dilation of a duct by lipids and cellular " +
                                    "debris. In a mammary duct the condition, which tends " +
                                    "mainly to affect postmenopausal women, may be accompanied " +
                                    "by inflammation and infiltration by plasma cells.")
                            //- AutoGen
                            //- DuctEctasia
                            ,
                            //+ Edema
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Edema")
                                .SetDisplay("Edema")
                                .SetDefinition("[PR] Edema")
                                .MammoId("513")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("290077003")
                                .SetSnomedDescription("ClinicalFinding | Edema of breast (Finding)")
                                .SetICD10("R60.0")
                                .SetUMLS("Breast edema is defined as a mammographic pattern " +
                                    "of skin thickening, increased parenchymal density, " +
                                    "and interstitial marking. It can be caused by benign " +
                                    "or malignant diseases, as a result of a tumor in " +
                                    "the dermal lymphatics of the breast, lymphatic congestion " +
                                    "caused by breast, lymphatic drainage obstruction, " +
                                    "or by congestive heart failure.")
                            //- AutoGen
                            //- Edema
                            ,
                            //+ FatLobule
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FatLobule")
                                .SetDisplay("Fat lobule")
                                .SetDefinition("[PR] Fat lobule")
                                .MammoId("523")
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("no direct match possible fat necrosis?")
                                .SetUMLS("Fat Lobule. The normal breast is composed of numerous " +
                                    "fat lobules mixed with dense fibroglandular tissue. " +
                                    "Fat lobule in breast. Yes. Breast tissue is composed " +
                                    "of functional elements (glands and ducts) as well " +
                                    "as structural elements (connective tissue and vessels). " +
                                    "The connective tissue (or stroma) in the breast is " +
                                    "composed of various proportions of fat and fibrous " +
                                    "tissue.")
                            //- AutoGen
                            //- FatLobule
                            ,
                            //+ FatNecrosis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FatNecrosis")
                                .SetDisplay("Fat necrosis")
                                .SetDefinition("[PR] Fat necrosis")
                                .MammoId("509")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("21381006")
                                .SetSnomedDescription("ClinicalFinding | Fat necrosis of breast (Disorder)")
                                .SetICD10("N64.1")
                                .SetUMLS("Fat necrosis within the breast is a pathological " +
                                    "process that occurs when there is saponification " +
                                    "of local fat. It is a benign inflammatory process " +
                                    "and is becoming increasingly common with the greater " +
                                    "use of breast conserving surgery and mammoplasty " +
                                    "procedures.")
                            //- AutoGen
                            //- FatNecrosis
                            ,
                            //+ Fibroadenolipoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Fibroadenolipoma")
                                .SetDisplay("Fibroadenolipoma")
                                .SetDefinition("[PR] Fibroadenolipoma")
                                .MammoId("500")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetComment("NO CORRECT TERM")
                                .SetUMLS("Another name for Hamartomas, Hamartomas represent " +
                                    "benign proliferation of fibrous, glandular, and fatty " +
                                    "tissue (hence fibro-adeno-lipoma) surrounded by a " +
                                    "thin capsule of connective tissue. All components " +
                                    "are found in normal breast tissue, which is why the " +
                                    "lesions are considered hamartomatous.")
                            //- AutoGen
                            //- Fibroadenolipoma
                            ,
                            //+ Fibroadenoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Fibroadenoma")
                                .SetDisplay("Fibroadenoma")
                                .SetDefinition("[PR] Fibroadenoma")
                                .MammoId("81")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetUMLS("Fibroadenomas are noncancerous breast lumps that " +
                                    "most commonly occur in women ages 15 to 35.")
                            //- AutoGen
                            //- Fibroadenoma
                            ,
                            //+ FibroadenomaDegenerating
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FibroadenomaDegenerating")
                                .SetDisplay("Fibroadenoma degenerating")
                                .SetDefinition("[PR] Fibroadenoma degenerating")
                                .MammoId("587")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("Fibroadenomas usually go away with age. By the time " +
                                    "a woman is menopausal, they will experience a degeneration " +
                                    "of the Fibroadenomas. These are non-cancerous breast " +
                                    "lumps.")
                            //- AutoGen
                            //- FibroadenomaDegenerating
                            ,
                            //+ FibrocysticChange
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FibrocysticChange")
                                .SetDisplay("Fibrocystic change")
                                .SetDefinition("[PR] Fibrocystic change")
                                .MammoId("538")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("367647000")
                                .SetSnomedDescription("BodyStructure | Fibrocystic change")
                                .SetComment("right/left/bilateral choices")
                                .SetUMLS("Fibrocystic breast changes lead to the development " +
                                    "of fluid-filled round or oval sacs (cysts) and more " +
                                    "prominent scar-like (fibrous) tissue, which can make " +
                                    "breasts feel tender, lumpy or ropy. Fibrocystic breasts " +
                                    "are composed of tissue that feels lumpy or rope-like " +
                                    "in texture. Doctors call this nodular or glandular " +
                                    "breast tissue.")
                            //- AutoGen
                            //- FibrocysticChange
                            ,
                            //+ FibroglandularTissue
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FibroglandularTissue")
                                .SetDisplay("Fibroglandular tissue")
                                .SetDefinition("[PR] Fibroglandular tissue")
                                .MammoId("94")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("Fibrocystic breast changes lead to the development " +
                                    "of fluid-filled round or oval sacs (cysts) and more " +
                                    "prominent scar-like (fibrous) tissue, which can make " +
                                    "breasts feel tender, lumpy or ropy. Fibrocystic breasts " +
                                    "are composed of tissue that feels lumpy or rope-like " +
                                    "in texture. Doctors call this nodular or glandular " +
                                    "breast tissue.")
                            //- AutoGen
                            //- FibroglandularTissue
                            ,
                            //+ Fibrosis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Fibrosis")
                                .SetDisplay("Fibrosis")
                                .SetDefinition("[PR] Fibrosis")
                                .MammoId("578")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("???????????")
                                .SetUMLS("Fibrosis may refer to the connective tissue deposition " +
                                    "that occurs as part of normal healing or to the excess " +
                                    "tissue deposition that occurs as a pathological process. " +
                                    "When fibrosis occurs in response to injury, the term " +
                                    "\"scarring\" is used. Some of the main types of fibrosis " +
                                    "that occur in the body are described below.")
                            //- AutoGen
                            //- Fibrosis
                            ,
                            //+ FibrousRidge
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FibrousRidge")
                                .SetDisplay("Fibrous ridge")
                                .SetDefinition("[PR] Fibrous ridge")
                                .MammoId("914")
                                .ValidModalities(Modalities.US)
                                .SetUMLS("Fibrous tissue, which extends under the skin, from " +
                                    "the front of the breast to the back of the chest " +
                                    "wall, supports the breast and gives it shape. Strands " +
                                    "of supportive tissue surround the breast and form " +
                                    "a prominent ridge called the inframammary ridge.")
                            //- AutoGen
                            //- FibrousRidge
                            ,
                            //+ Folliculitis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Folliculitis")
                                .SetDisplay("Folliculitis")
                                .SetDefinition("[PR] Folliculitis")
                                .MammoId("562")
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 13600006 | Folliculitis (Disorder) " +
                                    "| [6/113] | L73.9")
                                .SetUMLS("Folliculitis is the inflammation of hair follicles " +
                                    "due to an infection, injury, or irritation. It is " +
                                    "characterized by tender, swollen areas that form " +
                                    "around hair follicles, often on the neck, breasts, " +
                                    "buttocks, and face.")
                            //- AutoGen
                            //- Folliculitis
                            ,
                            //+ Gynecomastia
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Gynecomastia")
                                .SetDisplay("Gynecomastia")
                                .SetDefinition("[PR] Gynecomastia")
                                .MammoId("759")
                                .ValidModalities(Modalities.US)
                                .SetUMLS("An increase in the amount of breast gland tissue " +
                                    "in boys or men, caused by an imbalance of the hormones " +
                                    "estrogen and testosterone. Gynecomastia can affect " +
                                    "one or both breasts, sometimes unevenly.")
                            //- AutoGen
                            //- Gynecomastia
                            ,
                            //+ Hamartoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Hamartoma")
                                .SetDisplay("Hamartoma")
                                .SetDefinition("[PR] Hamartoma")
                                .MammoId("552.544")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("51398009")
                                .SetSnomedDescription("BodyStructure | Hamartoma (Morphologic-Abnormality)")
                                .SetUMLS("A hamartoma is a noncancerous tumor made of an abnormal " +
                                    "mixture of normal tissues and cells from the area " +
                                    "in which it grows.")
                            //- AutoGen
                            //- Hamartoma
                            ,
                            //+ Hematoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Hematoma")
                                .SetDisplay("Hematoma")
                                .SetDefinition("[PR] Hematoma")
                                .MammoId("112")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("302924003")
                                .SetSnomedDescription("ClinicalFinding | Breast hematoma (Disorder) | N64.89")
                                .SetUMLS("A breast hematoma is a collection of blood that forms " +
                                    "under the skin's surface. It's not unlike having " +
                                    "a large bruise in your breast. The mass it forms " +
                                    "is not cancerous, but it can sometimes lead to inflammation, " +
                                    "fever, skin discoloration, and may leave behind scar " +
                                    "tissue that mimics the shape of a breast tumor.")
                            //- AutoGen
                            //- Hematoma
                            ,
                            //+ HormonalStimulation
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("HormonalStimulation")
                                .SetDisplay("Hormonal stimulation")
                                .SetDefinition("[PR] Hormonal stimulation")
                                .MammoId("539")
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            //- HormonalStimulation
                            ,
                            //+ IntracysticLesion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("IntracysticLesion")
                                .SetDisplay("Intracystic lesion")
                                .SetDefinition("[PR] Intracystic lesion")
                                .MammoId("62")
                                .ValidModalities(Modalities.NM | Modalities.US)
                                .SetUMLS("Intracystic tumors of the breast are uncommon and, " +
                                    "at the time of ultrasonography and aspiration cytology, " +
                                    "it is difficult to distinguish cancer from a benign " +
                                    "tumor.")
                            //- AutoGen
                            //- IntracysticLesion
                            ,
                            //+ IntramammaryNode
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("IntramammaryNode")
                                .SetDisplay("Intramammary node")
                                .SetDefinition("[PR] Intramammary node")
                                .MammoId("566,941")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("BodyStructure | 443159006 | Intramammary lymph node " +
                                    "group (Bodypart)")
                                .SetUMLS("Intramammary lymph nodes are defined as lymph nodes " +
                                    "surrounded by breast tissue.")
                            //- AutoGen
                            //- IntramammaryNode
                            ,
                            //+ Lipoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Lipoma")
                                .SetDisplay("Lipoma")
                                .SetDefinition("[PR] Lipoma")
                                .MammoId("508")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("276891009")
                                .SetSnomedDescription("ClinicalFinding | Lipoma of breast (Disorder)")
                                .SetICD10("D17.39")
                                .SetUMLS("A lipoma is a slow-growing, fatty lump that's most " +
                                    "often situated between your skin and the underlying " +
                                    "muscle layer. A lipoma, which feels doughy and usually " +
                                    "isn't tender, moves readily with slight finger pressure. " +
                                    "Lipomas are usually detected in middle age. Some " +
                                    "people have more than one lipoma.A lipoma isn't cancer " +
                                    "and usually is harmless.")
                            //- AutoGen
                            //- Lipoma
                            ,
                            //+ LumpectomyCavity
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LumpectomyCavity")
                                .SetDisplay("Lumpectomy cavity")
                                .SetDefinition("[PR] Lumpectomy cavity")
                                .MammoId("512")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("BodyStructure | 261719000 | Breast cavity (Morphologic-Abnormality)")
                                .SetComment("Need to create")
                            //- AutoGen
                            //- LumpectomyCavity
                            ,
                            //+ LumpectomySite
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LumpectomySite")
                                .SetDisplay("Lumpectomy site")
                                .SetDefinition("[PR] Lumpectomy site")
                                .MammoId("564")
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedDescription("BodyStructure | 261719000 | Breast cavity (Morphologic-Abnormality)")
                                .SetComment("needs better")
                            //- AutoGen
                            //- LumpectomySite
                            ,
                            //+ LymphNode
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LymphNode")
                                .SetDisplay("Lymph node")
                                .SetDefinition("[PR] Lymph node")
                                .MammoId("74")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- LymphNode
                            ,
                            //+ LymphNodeEnlarged
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LymphNodeEnlarged")
                                .SetDisplay("Lymph node enlarged")
                                .SetDefinition("[PR] Lymph node enlarged")
                                .MammoId("541.588")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("274741002")
                                .SetSnomedDescription("ClinicalFinding | Generalized enlarged lymph nodes " +
                                    "(Disorder) | [0/0] | R59.1")
                            //- AutoGen
                            //- LymphNodeEnlarged
                            ,
                            //+ LymphNodeNormal
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LymphNodeNormal")
                                .SetDisplay("Lymph node normal")
                                .SetDefinition("[PR] Lymph node normal")
                                .MammoId("907")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- LymphNodeNormal
                            ,
                            //+ LymphNodePathological
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LymphNodePathological")
                                .SetDisplay("Lymph node pathological")
                                .SetDefinition("[PR] Lymph node pathological")
                                .MammoId("540")
                                .ValidModalities(Modalities.MRI)
                                .SetUMLS("Lymphadenopathy (or adenopathy) is, if anything, " +
                                    "a broader term, referring to any pathology of lymph " +
                                    "nodes, not necessarily resulting in increased size; " +
                                    "this includes abnormal number of nodes, or derangement " +
                                    "of internal architecture (e.g. cystic or necrotic " +
                                    "nodes).")
                            //- AutoGen
                            //- LymphNodePathological
                            ,
                            //+ MassSolid
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MassSolid")
                                .SetDisplay("Mass solid")
                                .SetDefinition("[PR] Mass solid")
                                .MammoId("63")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- MassSolid
                            ,
                            //+ MassSolidW/tumorVasc
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MassSolidW/tumorVasc")
                                .SetDisplay("Mass solid w/tumor vasc")
                                .SetDefinition("[PR] Mass solid w/tumor vasc")
                                .MammoId("550")
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            //- MassSolidW/tumorVasc
                            ,
                            //+ Mastitis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Mastitis")
                                .SetDisplay("Mastitis")
                                .SetDefinition("[PR] Mastitis")
                                .MammoId("524")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 45198002 | Mastitis (Disorder) " +
                                    "| [3/51] | P39.0 | Neonatal infective mastitis | " +
                                    "N61 | Inflammatory disorders of breast |")
                                .SetUMLS("Infection of the breast tissue resulting in pain, " +
                                    "swelling, warmth and redness.")
                            //- AutoGen
                            //- Mastitis
                            ,
                            //+ MilkOfCalcium
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MilkOfCalcium")
                                .SetDisplay("Milk of calcium")
                                .SetDefinition("[PR] Milk of calcium")
                                .MammoId("571")
                                .ValidModalities(Modalities.MG)
                                .SetDicom("F-01765")
                                .SetSnomedCode("129753004")
                                .SetSnomedDescription("ClinicalFinding | 129753004 | Milk of calcium radiographic " +
                                    "calcification (Finding)")
                                .SetUMLS("The term milk of calcium (MOC) is given to dependent, " +
                                    "sedimented calcification within a cystic structure " +
                                    "or hollow organ. This sort of colloidal calcium suspension " +
                                    "layering can occur in various regions: renal: milk " +
                                    "of calcium in renal cyst (most common) breast: mil+A:Rk " +
                                    "of calcium in breast cyst.")
                            //- AutoGen
                            //- MilkOfCalcium
                            ,
                            //+ Multi-focalCancer
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Multi-focalCancer")
                                .SetDisplay("Multi-focal cancer")
                                .SetDefinition("[PR] Multi-focal cancer")
                                .MammoId("944")
                                .ValidModalities(Modalities.NM)
                                .SetUMLS("Multifocal breast cancer occurs when there are two " +
                                    "or more tumors in the same breast. All of the tumors " +
                                    "begin in one original tumor. The tumors are also " +
                                    "all in the same quadrant — or section — of the breast.")
                            //- AutoGen
                            //- Multi-focalCancer
                            ,
                            //+ PapillaryLesion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PapillaryLesion")
                                .SetDisplay("Papillary lesion")
                                .SetDefinition("[PR] Papillary lesion")
                                .MammoId("563")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("need help")
                                .SetUMLS("Papillary lesions are benign growths in the duct " +
                                    "of the breast. They comprise approximately 1 to 3 " +
                                    "percent of all lesions sampled by core needle biopsies. " +
                                    "Currently, the treatment of these lesions alternates " +
                                    "between radiographic follow-up and surgical excision, " +
                                    "and is often dependent upon physician recommendation.")
                            //- AutoGen
                            //- PapillaryLesion
                            ,
                            //+ Papilloma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Papilloma")
                                .SetDisplay("Papilloma")
                                .SetDefinition("[PR] Papilloma")
                                .MammoId("507")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("99571000119102")
                                .SetSnomedDescription("ClinicalFinding | Papilloma of breast (Disorder)")
                                .SetICD10("D24")
                                .SetComment("US SM NUMBER")
                                .SetUMLS("A benign epithelial tumor that forms on the skin " +
                                    "or mucous membrane.")
                            //- AutoGen
                            //- Papilloma
                            ,
                            //+ PhyllodesTumor
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PhyllodesTumor")
                                .SetDisplay("Phyllodes tumor")
                                .SetDefinition("[PR] Phyllodes tumor")
                                .MammoId("560")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 712989008 | Phyllodes tumor of " +
                                    "breast (Disorder) | D48.6 |")
                            //- AutoGen
                            //- PhyllodesTumor
                            ,
                            //+ PostLumpectomyScar
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PostLumpectomyScar")
                                .SetDisplay("Post lumpectomy scar")
                                .SetDefinition("[PR] Post lumpectomy scar")
                                .MammoId("590")
                                .ValidModalities(Modalities.MG)
                                .SetOneToMany("???")
                                .SetSnomedDescription("BodyStructure | 63130001 | Surgical scar (Morphologic-Abnormality)")
                                .SetUMLS("A lump of scar tissue forms in the hole left after " +
                                    "breast tissue is removed. If scar tissue forms around " +
                                    "a stitch from surgery it's called a suture granuloma " +
                                    "and also feels like a lump. ... Scar tissue and fluid " +
                                    "retention can make breast tissue appear a little " +
                                    "firmer or rounder than before surgery and/or radiation.")
                            //- AutoGen
                            //- PostLumpectomyScar
                            ,
                            //+ PostSurgicalScar
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PostSurgicalScar")
                                .SetDisplay("Post surgical scar")
                                .SetDefinition("[PR] Post surgical scar")
                                .MammoId("567.943")
                                .ValidModalities(Modalities.MG | Modalities.NM)
                                .SetSnomedDescription("BodyStructure | 63130001 | Surgical scar (Morphologic-Abnormality)")
                                .SetUMLS("Post surgical scarring happens because of the incisions " +
                                    "needed to surgically remove tumor, cells, etc. The " +
                                    "amount of scarring is connected to the different " +
                                    "stages of wound healing. Surgical scar care should " +
                                    "be continued for a year.")
                            //- AutoGen
                            //- PostSurgicalScar
                            ,
                            //+ PreviousBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PreviousBiopsy")
                                .SetDisplay("Previous biopsy")
                                .SetDefinition("[PR] Previous biopsy")
                                .MammoId("584")
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- PreviousBiopsy
                            ,
                            //+ PreviousSurgery
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PreviousSurgery")
                                .SetDisplay("Previous surgery")
                                .SetDefinition("[PR] Previous surgery")
                                .MammoId("585")
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- PreviousSurgery
                            ,
                            //+ PreviousTrauma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PreviousTrauma")
                                .SetDisplay("Previous trauma")
                                .SetDefinition("[PR] Previous trauma")
                                .MammoId("586")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("ClinicalFinding | 62112002 | Injury of breast (Disorder) " +
                                    "| [4/41] | S29.9XX?")
                                .SetComment("NEED TO INDICATE PREVIOUS")
                            //- AutoGen
                            //- PreviousTrauma
                            ,
                            //+ RadialScar
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("RadialScar")
                                .SetDisplay("Radial scar")
                                .SetDefinition("[PR] Radial scar")
                                .MammoId("568")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedCode("390787006")
                                .SetSnomedDescription("ClinicalFinding | Radial scar of breast (Finding)")
                                .SetICD10("N64.89")
                                .SetUMLS("Radial scar is a growth that looks like a scar when " +
                                    "the tissue is viewed under a microscope. It has a " +
                                    "central core containing benign ducts. Growing out " +
                                    "of this core are ducts and lobules that show evidence " +
                                    "of unusual changes such as cysts and epithelial hyperplasia " +
                                    "(overgrowth of their inner lining). Often, more than " +
                                    "one radial scar is present. Another term for this " +
                                    "condition is complex sclerosing lesions.")
                            //- AutoGen
                            //- RadialScar
                            ,
                            //+ RadiationChanges
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("RadiationChanges")
                                .SetDisplay("Radiation changes")
                                .SetDefinition("[PR] Radiation changes")
                                .MammoId("548")
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("143501000119107")
                                .SetSnomedDescription("SituationWithExplicitContext  | History of radiation " +
                                    "therapy to breast area (Situation)")
                            //- AutoGen
                            //- RadiationChanges
                            ,
                            //+ RadiationTherapy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("RadiationTherapy")
                                .SetDisplay("Radiation therapy")
                                .SetDefinition("[PR] Radiation therapy")
                                .MammoId("549")
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("429479009")
                                .SetSnomedDescription("SituationWithExplicitContext | History of radiation " +
                                    "therapy (Situation)")
                            //- AutoGen
                            //- RadiationTherapy
                            ,
                            //+ Scar
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Scar")
                                .SetDisplay("Scar")
                                .SetDefinition("[PR] Scar")
                                .MammoId("502")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetUMLS("A mark left on the skin or within body tissue where " +
                                    "a wound, burn, or sore has not healed completely " +
                                    "and fibrous connective tissue has developed.")
                            //- AutoGen
                            //- Scar
                            ,
                            //+ ScarWithShadowing
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ScarWithShadowing")
                                .SetDisplay("Scar with shadowing")
                                .SetDefinition("[PR] Scar with shadowing")
                                .MammoId("113")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- ScarWithShadowing
                            ,
                            //+ SclerosingAdenosis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SclerosingAdenosis")
                                .SetDisplay("Sclerosing adenosis")
                                .SetDefinition("[PR] Sclerosing adenosis")
                                .MammoId("599")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("Sclerosing adenosis is a type of adenosis in which " +
                                    "enlarged acini become slightly distorted by surrounded " +
                                    "stromal fibrosis (\"sclerosis\"). The normal lobular " +
                                    "architecture of the breast is maintained, but becomes " +
                                    "exaggerated and distorted.")
                            //- AutoGen
                            //- SclerosingAdenosis
                            ,
                            //+ SecretoryCalcification
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SecretoryCalcification")
                                .SetDisplay("Secretory calcification")
                                .SetDefinition("[PR] Secretory calcification")
                                .MammoId("570")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("??????????????")
                                .SetUMLS("Large rodlike or secretory calcifications. Large " +
                                    "rodlike or secretory calcifications (see below) are " +
                                    "oriented along the axes of the ductal system. These " +
                                    "calcifications result from calcification of ductal " +
                                    "secretions. Large rodlike or secretory calcifications " +
                                    "are oriented along the axis of the breast ductal " +
                                    "system.")
                            //- AutoGen
                            //- SecretoryCalcification
                            ,
                            //+ SentinelNode
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SentinelNode")
                                .SetDisplay("Sentinel node")
                                .SetDefinition("[PR] Sentinel node")
                                .MammoId("945")
                                .ValidModalities(Modalities.NM)
                                .SetUMLS("The sentinel nodes are the first few lymph nodes " +
                                    "into which a tumor drains. Sentinel node biopsy involves " +
                                    "injecting a tracer material that helps the surgeon " +
                                    "locate the sentinel nodes during surgery. The sentinel " +
                                    "nodes are removed and analyzed in a laboratory.")
                            //- AutoGen
                            //- SentinelNode
                            ,
                            //+ Seroma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Seroma")
                                .SetDisplay("Seroma")
                                .SetDefinition("[PR] Seroma")
                                .MammoId("511.576")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("297178008")
                                .SetSnomedDescription("ClinicalFinding | Breast seroma (Disorder)")
                                .SetICD10("N64.89")
                                .SetUMLS("A breast seroma is a collection (pocket) of serous " +
                                    "fluid that can develop after trauma to the breast " +
                                    "or following procedures such as breast surgery or " +
                                    "radiation therapy. Serous fluid is a pale yellow, " +
                                    "transparent fluid that contains protein, but no blood " +
                                    "cells or pus.")
                            //- AutoGen
                            //- Seroma
                            ,
                            //+ SkinLesion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SkinLesion")
                                .SetDisplay("Skin lesion")
                                .SetDefinition("[PR] Skin lesion")
                                .MammoId("583")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("126510002")
                                .SetSnomedDescription("ClinicalFinding | Neoplasm of skin of breast (Disorder)")
                                .SetICD10("D49.2")
                            //- AutoGen
                            //- SkinLesion
                            ,
                            //+ Surgery
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Surgery")
                                .SetDisplay("Surgery")
                                .SetDefinition("[PR] Surgery")
                                .MammoId("546")
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            //- Surgery
                            ,
                            //+ Trauma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Trauma")
                                .SetDisplay("Trauma")
                                .SetDefinition("[PR] Trauma")
                                .MammoId("547")
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedDescription("ClinicalFinding | 62112002 | Injury of breast (Disorder)")
                                .SetICD10("S29.9XX?")
                                .SetComment("Need help no direct match")
                            //- AutoGen
                            //- Trauma
                            ,
                            //+ VascularCalcifications
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("VascularCalcifications")
                                .SetDisplay("Vascular calcifications")
                                .SetDefinition("[PR] Vascular calcifications")
                                .MammoId("569")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("ClinicalFinding | 396779001 | Breast arterial calcification " +
                                    "(Finding) | [0/0] | R92.1")
                                .SetUMLS("Vascular calcifications are mineral deposits on the " +
                                    "walls of your arteries and veins. These mineral deposits " +
                                    "sometimes stick to fatty deposits, or plaques, that " +
                                    "are already built up on the walls of a blood vessel.")
                            //- AutoGen
                            //- VascularCalcifications
                            ,
                            //+ VenousStasis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("VenousStasis")
                                .SetDisplay("Venous stasis")
                                .SetDefinition("[PR] Venous stasis")
                                .MammoId("947")
                                .ValidModalities(Modalities.NM)
                                .SetSnomedDescription("ClinicalFinding | 71897006 | Venous stasis (Finding) " +
                                    "| [0/0] | I87.8")
                                .SetUMLS("Venous stasis, is a condition of slow blood flow " +
                                    "in the veins, usually of the legs. Venous stasis " +
                                    "is a risk factor for forming blood clots in veins")
                            //- AutoGen
                            ,
                            //- VenousStasis
                            //+ PhyllodesTumor(SPELLINGREMOVEI)
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PhyllodesTumor(SPELLINGREMOVEI)")
                                .SetDisplay("Phyllodes tumor (SPELLING REMOVE i)")
                                .SetDefinition("[PR] Phyllodes tumor (SPELLING REMOVE i)")
                                .MammoId("560")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 712989008 | Phyllodes tumor of " +
                                    "breast (Disorder) | D48.6 |")
                                .SetUMLS("Phyllodes tumor. Phyllodes tumors (from Greek: phullon " +
                                    "leaf), also cystosarcoma phyllodes, cystosarcoma " +
                                    "phylloides and phylloides tumor, are typically large, " +
                                    "fast-growing masses that form from the periductal " +
                                    "stromal cells of the breast.")
                            //- AutoGen
                            ,
                            //- PhyllodesTumor(SPELLINGREMOVEI)
                            //- Codes
                        })
            );


        CSTaskVar ConsistentWithQualifierCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        "ConsistentWithQualifierCS",
                        "ConsistentWith Qualifier CodeSystem",
                        "ConsistentWithQualifier/ValueSet",
                        "ConsistentWithQualifier  code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            //+ Qualifiers
                            //+ LikelyRepresents
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LikelyRepresents")
                                .SetDisplay("Likely represents")
                                .SetDefinition("[PR] Likely represents")
                                .MammoId("536")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- LikelyRepresents
                            ,
                            //+ MostLikely
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MostLikely")
                                .SetDisplay("Most likely")
                                .SetDefinition("[PR] Most likely")
                                .MammoId("581")
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- MostLikely
                            ,
                            //+ Resembles
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Resembles")
                                .SetDisplay("Resembles")
                                .SetDefinition("[PR] Resembles")
                                .MammoId("580")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- Resembles
                            ,
                            //+ w/differentialDiagnosis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("w/differentialDiagnosis")
                                .SetDisplay("w/differential diagnosis")
                                .SetDefinition("[PR] w/differential diagnosis")
                                .MammoId("561")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- w/differentialDiagnosis
                            ,
                            //+ DifferentialDiagnosis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DifferentialDiagnosis")
                                .SetDisplay("Differential diagnosis")
                                .SetDefinition("[PR] Differential diagnosis")
                                .MammoId("561")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetUMLS("More than one possibility for your diagnosis. The " +
                                    "process of weighing the probability of one disease " +
                                    "versus that of other diseases possibly accounting " +
                                    "for a patient's illness.")
                            //- AutoGen
                            ,
                            //- DifferentialDiagnosis
                            //- Qualifiers
                        })
             );
    }
}
