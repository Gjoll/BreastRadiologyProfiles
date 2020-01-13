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
                       SDefEditor e = Self.CreateEditorObservationLeaf("ConsistentWith",
                        "Consistent With",
                        "Consistent/With",
                        $"{Group_CommonResources}/ConsistentWith")
                           .Description("'Consistent With' Observation",
                               new Markdown()
                                   .MissingObservation("a consistentWith")
                           )
                           .AddFragRef(Self.ObservationNoDeviceFragment.Value().Url)
                           ;
                       s = e.SDef;
                       e.Select("value[x]").Zero();
                       e.Select("interpretation").Zero();
                       e.Select("referenceRange").Zero();

                       e.StartComponentSliceing();
                       e.ComponentSliceCodeableConcept("value",
                           Self.CodeConsistentWithValue.ToCodeableConcept(),
                           Self.ConsistentWithVS.Value(),
                           BindingStrength.Extensible,
                           1,
                           "1",
                           "Value");
                       e.ComponentSliceCodeableConcept("qualifier",
                           Self.CodeConsistentWithQualifier.ToCodeableConcept(),
                           Self.ConsistentWithQualifierVS.Value(),
                           BindingStrength.Required,
                           0,
                           "1",
                           "Qualifier");

                       e.IntroDoc
                           .ReviewedStatus(ReviewStatus.NotReviewed)
                           ;
                   });

        VSTaskVar ConsistentWithVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "ConsistentWithVS",
                        "ConsistentWith ValueSet",
                        "ConsistentWith/ValueSet",
                        "ConsistentWith value set.",
                        Group_MGCodesVS,
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
                        Group_MGCodesVS,
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
                            //+ ConsistentWithCS
                            new ConceptDef("Abscess",
                                "Abscess",
                                new Definition()
                                    .Line("[PR] Abscess")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 404057003
                            // SNOMED Description: ClinicalFinding | Angiolipoma (Disorder)
                            // ICD10: 404057003
                            new ConceptDef("Angiolipoma",
                                "Angiolipoma",
                                new Definition()
                                    .Line("[PR] Angiolipoma")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: ClinicalFinding | 37009001 | Apocrine metaplasia of breast (Disorder) | [0/0] | N60.89
                            new ConceptDef("ApocrineMetaplasia",
                                "Apocrine metaplasia",
                                new Definition()
                                    .Line("[PR] Apocrine metaplasia")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("Artifact",
                                "Artifact",
                                new Definition()
                                    .Line("[PR] Artifact")
                                    .ValidModalities(Modalities.NM)
                                ),
                            new ConceptDef("AtypicalHyperplasia",
                                "Atypical hyperplasia",
                                new Definition()
                                    .Line("[PR] Atypical hyperplasia")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            // SNOMED Description: BodyStructure | 245269009 | Axillary lymph node group (Bodypart)
                            new ConceptDef("AxillaryLymphNode",
                                "Axillary lymph node",
                                new Definition()
                                    .Line("[PR] Axillary lymph node")
                                    .ValidModalities(Modalities.NM)
                                ),
                            // SNOMED Description: ClinicalFinding | 254838004 | Carcinoma of breast (Disorder) | [4/33] | C50.929
                            new ConceptDef("Carcinoma",
                                "Carcinoma",
                                new Definition()
                                    .Line("[PR] Carcinoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Description: ClinicalFinding | 254838004 | Carcinoma of breast (Disorder) | [4/33] | C50.929
                            new ConceptDef("CarcinomaKnown",
                                "Carcinoma known",
                                new Definition()
                                    .Line("[PR] Carcinoma known")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 399294002
                            // oneToMany: one
                            // SNOMED Description: ClinicalFinding |Cyst of breast (Disorder) ++++++
                            // ICD10: 399294002
                            // Comment: BodyStructure | 125291005 | Multiple cysts (Morphologic-Abnormality
                            new ConceptDef("ClusterOfCysts",
                                "Cluster of cysts",
                                new Definition()
                                    .Line("[PR] Cluster of cysts")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 399294002
                            // oneToMany: one
                            // SNOMED Description: ClinicalFinding |Cyst of breast (Disorder) 
                            // ICD10: 399294002
                            new ConceptDef("Cyst",
                                "Cyst",
                                new Definition()
                                    .Line("[PR] Cyst")
                                    .ValidModalities(Modalities.MG | Modalities.MRI)
                                ),
                            // SNOMED Code: 449837001
                            // oneToMany: one
                            // SNOMED Description: ClinicalFinding | Complex cyst of breast (Disorder)
                            // ICD10: 449837001
                            new ConceptDef("CystComplex",
                                "Cyst complex",
                                new Definition()
                                    .Line("[PR] Cyst complex")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            // Comment: NO CORRECT TERM
                            new ConceptDef("CystComplicated",
                                "Cyst complicated",
                                new Definition()
                                    .Line("[PR] Cyst complicated")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            // Comment: NO OIL CYST
                            new ConceptDef("CystOil",
                                "Cyst oil",
                                new Definition()
                                    .Line("[PR] Cyst oil")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Code: 76649007
                            // oneToMany: one
                            // SNOMED Description: ClinicalFinding | Sebaceous cyst of skin of breast (Disorder)
                            // ICD10: 76649007
                            new ConceptDef("CystSebaceous",
                                "Cyst sebaceous",
                                new Definition()
                                    .Line("[PR] Cyst sebaceous")
                                    .ValidModalities(Modalities.US)
                                ),
                            // SNOMED Code: 399253005
                            // oneToMany: one
                            // SNOMED Description: ClinicalFinding | Simple cyst of breast (Disorder)
                            // ICD10: 399253005
                            new ConceptDef("CystSimple",
                                "Cyst simple",
                                new Definition()
                                    .Line("[PR] Cyst simple")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 449837001
                            // oneToMany: Many
                            // SNOMED Description: ClinicalFinding | Complex cyst of breast (Disorder)
                            // ICD10: 449837001
                            new ConceptDef("CystsComplex",
                                "Cysts complex",
                                new Definition()
                                    .Line("[PR] Cysts complex")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            // Comment: NO CORRECT TERM
                            new ConceptDef("CystsComplicated",
                                "Cysts complicated",
                                new Definition()
                                    .Line("[PR] Cysts complicated")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            // Comment: NO CORRECT TERM
                            new ConceptDef("CystsMicroClustered",
                                "Cysts micro clustered",
                                new Definition()
                                    .Line("[PR] Cysts micro clustered")
                                    .ValidModalities(Modalities.US)
                                ),
                            // oneToMany: ?????
                            // SNOMED Description: BodyStructure | 399935008 | Ductal carcinoma in situ - category (Morphologic-Abnormality)
                            new ConceptDef("DCIS",
                                "DCIS",
                                new Definition()
                                    .Line("[PR] DCIS")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("Debris",
                                "Debris",
                                new Definition()
                                    .Line("[PR] Debris")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Code: 39432004
                            // SNOMED Description: PharmaceuticalBiologicProduct | Deodorant (Product)
                            // ICD10: 39432004
                            new ConceptDef("Deodorant",
                                "Deodorant",
                                new Definition()
                                    .Line("[PR] Deodorant")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("DermalCalcification",
                                "Dermal calcification",
                                new Definition()
                                    .Line("[PR] Dermal calcification")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: ClinicalFinding | 22049009 | Mammary duct ectasia (Disorder) | [0/0] | N60.49 
                            new ConceptDef("DuctEctasia",
                                "Duct ectasia",
                                new Definition()
                                    .Line("[PR] Duct ectasia")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 290077003
                            // SNOMED Description: ClinicalFinding | Edema of breast (Finding)
                            // ICD10: 290077003
                            new ConceptDef("Edema",
                                "Edema",
                                new Definition()
                                    .Line("[PR] Edema")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: no direct match possible fat necrosis?
                            new ConceptDef("FatLobule",
                                "Fat lobule",
                                new Definition()
                                    .Line("[PR] Fat lobule")
                                    .ValidModalities(Modalities.US)
                                ),
                            // SNOMED Code: 21381006
                            // SNOMED Description: ClinicalFinding | Fat necrosis of breast (Disorder) 
                            // ICD10: 21381006
                            new ConceptDef("FatNecrosis",
                                "Fat necrosis",
                                new Definition()
                                    .Line("[PR] Fat necrosis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // Comment: NO CORRECT TERM
                            new ConceptDef("Fibroadenolipoma",
                                "Fibroadenolipoma",
                                new Definition()
                                    .Line("[PR] Fibroadenolipoma")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            new ConceptDef("Fibroadenoma",
                                "Fibroadenoma",
                                new Definition()
                                    .Line("[PR] Fibroadenoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            new ConceptDef("FibroadenomaDegenerating",
                                "Fibroadenoma degenerating",
                                new Definition()
                                    .Line("[PR] Fibroadenoma degenerating")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Code: 367647000
                            // SNOMED Description: BodyStructure | Fibrocystic change 
                            // ICD10: 367647000
                            // Comment: right/left/bilateral choices
                            new ConceptDef("FibrocysticChange",
                                "Fibrocystic change",
                                new Definition()
                                    .Line("[PR] Fibrocystic change")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("FibroglandularTissue",
                                "Fibroglandular tissue",
                                new Definition()
                                    .Line("[PR] Fibroglandular tissue")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: ???????????
                            new ConceptDef("Fibrosis",
                                "Fibrosis",
                                new Definition()
                                    .Line("[PR] Fibrosis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("FibrousRidge",
                                "Fibrous ridge",
                                new Definition()
                                    .Line("[PR] Fibrous ridge")
                                    .ValidModalities(Modalities.US)
                                ),
                            // SNOMED Description: ClinicalFinding | 13600006 | Folliculitis (Disorder) | [6/113] | L73.9 
                            new ConceptDef("Folliculitis",
                                "Folliculitis",
                                new Definition()
                                    .Line("[PR] Folliculitis")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("Gynecomastia",
                                "Gynecomastia",
                                new Definition()
                                    .Line("[PR] Gynecomastia")
                                    .ValidModalities(Modalities.US)
                                ),
                            // SNOMED Code: 51398009
                            // SNOMED Description: BodyStructure | Hamartoma (Morphologic-Abnormality)
                            // ICD10: 51398009
                            new ConceptDef("Hamartoma",
                                "Hamartoma",
                                new Definition()
                                    .Line("[PR] Hamartoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 302924003
                            // SNOMED Description: ClinicalFinding | Breast hematoma (Disorder) | N64.89
                            // ICD10: 302924003
                            new ConceptDef("Hematoma",
                                "Hematoma",
                                new Definition()
                                    .Line("[PR] Hematoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("HormonalStimulation",
                                "Hormonal stimulation",
                                new Definition()
                                    .Line("[PR] Hormonal stimulation")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("IntracysticLesion",
                                "Intracystic lesion",
                                new Definition()
                                    .Line("[PR] Intracystic lesion")
                                    .ValidModalities(Modalities.US)
                                ),
                            // SNOMED Description: BodyStructure | 443159006 | Intramammary lymph node group (Bodypart)
                            new ConceptDef("IntramammaryNode",
                                "Intramammary node",
                                new Definition()
                                    .Line("[PR] Intramammary node")
                                    .ValidModalities(Modalities.MG | Modalities.NM)
                                ),
                            // SNOMED Code: 276891009
                            // SNOMED Description: ClinicalFinding | Lipoma of breast (Disorder)
                            // ICD10: 276891009
                            new ConceptDef("Lipoma",
                                "Lipoma",
                                new Definition()
                                    .Line("[PR] Lipoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: BodyStructure | 261719000 | Breast cavity (Morphologic-Abnormality) 
                            // Comment: Need to create
                            new ConceptDef("LumpectomyCavity",
                                "Lumpectomy cavity",
                                new Definition()
                                    .Line("[PR] Lumpectomy cavity")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: BodyStructure | 261719000 | Breast cavity (Morphologic-Abnormality)
                            // Comment: needs better
                            new ConceptDef("LumpectomySite",
                                "Lumpectomy site",
                                new Definition()
                                    .Line("[PR] Lumpectomy site")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            new ConceptDef("LymphNode",
                                "Lymph node",
                                new Definition()
                                    .Line("[PR] Lymph node")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // SNOMED Code: 274741002 
                            // SNOMED Description: ClinicalFinding | Generalized enlarged lymph nodes (Disorder) | [0/0] | R59.1
                            // ICD10: 274741002 
                            new ConceptDef("LymphNodeEnlarged",
                                "Lymph node enlarged",
                                new Definition()
                                    .Line("[PR] Lymph node enlarged")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("LymphNodeNormal",
                                "Lymph node normal",
                                new Definition()
                                    .Line("[PR] Lymph node normal")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("LymphNodePathological",
                                "Lymph node pathological",
                                new Definition()
                                    .Line("[PR] Lymph node pathological")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            new ConceptDef("MassSolid",
                                "Mass solid",
                                new Definition()
                                    .Line("[PR] Mass solid")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("MassSolidW/tumorVasc",
                                "Mass solid w/tumor vasc",
                                new Definition()
                                    .Line("[PR] Mass solid w/tumor vasc")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            // SNOMED Description: ClinicalFinding | 45198002 | Mastitis (Disorder) | [3/51] | P39.0 | Neonatal infective mastitis | N61 | Inflammatory disorders of breast | 
                            new ConceptDef("Mastitis",
                                "Mastitis",
                                new Definition()
                                    .Line("[PR] Mastitis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // DICOM: F-01765
                            // SNOMED Code: 129753004
                            // SNOMED Description: ClinicalFinding | 129753004 | Milk of calcium radiographic calcification (Finding)
                            // ICD10: 129753004
                            new ConceptDef("MilkOfCalcium",
                                "Milk of calcium",
                                new Definition()
                                    .Line("[PR] Milk of calcium")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Multi-focalCancer",
                                "Multi-focal cancer",
                                new Definition()
                                    .Line("[PR] Multi-focal cancer")
                                    .ValidModalities(Modalities.NM)
                                ),
                            // SNOMED Description: need help
                            new ConceptDef("PapillaryLesion",
                                "Papillary lesion",
                                new Definition()
                                    .Line("[PR] Papillary lesion")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Code: 99571000119102
                            // SNOMED Description: ClinicalFinding | Papilloma of breast (Disorder)
                            // ICD10: 99571000119102
                            // Comment: US SM NUMBER
                            new ConceptDef("Papilloma",
                                "Papilloma",
                                new Definition()
                                    .Line("[PR] Papilloma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: ClinicalFinding | 712989008 | Phyllodes tumor of breast (Disorder) | D48.6 |
                            new ConceptDef("PhyllodesTumor",
                                "Phyllodes tumor",
                                new Definition()
                                    .Line("[PR] Phyllodes tumor")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            // oneToMany: ???
                            // SNOMED Description: BodyStructure | 63130001 | Surgical scar (Morphologic-Abnormality)
                            new ConceptDef("PostLumpectomyScar",
                                "Post lumpectomy scar",
                                new Definition()
                                    .Line("[PR] Post lumpectomy scar")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: BodyStructure | 63130001 | Surgical scar (Morphologic-Abnormality)
                            new ConceptDef("PostSurgicalScar",
                                "Post surgical scar",
                                new Definition()
                                    .Line("[PR] Post surgical scar")
                                    .ValidModalities(Modalities.MG | Modalities.NM)
                                ),
                            new ConceptDef("PreviousBiopsy",
                                "Previous biopsy",
                                new Definition()
                                    .Line("[PR] Previous biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("PreviousSurgery",
                                "Previous surgery",
                                new Definition()
                                    .Line("[PR] Previous surgery")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: ClinicalFinding | 62112002 | Injury of breast (Disorder) | [4/41] | S29.9XX?
                            // Comment: NEED TO INDICATE PREVIOUS
                            new ConceptDef("PreviousTrauma",
                                "Previous trauma",
                                new Definition()
                                    .Line("[PR] Previous trauma")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Code: 390787006
                            // SNOMED Description: ClinicalFinding | Radial scar of breast (Finding)
                            // ICD10: 390787006
                            new ConceptDef("RadialScar",
                                "Radial scar",
                                new Definition()
                                    .Line("[PR] Radial scar")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // SNOMED Code: 143501000119107
                            // SNOMED Description: SituationWithExplicitContext  | History of radiation therapy to breast area (Situation)
                            // ICD10: 143501000119107
                            new ConceptDef("RadiationChanges",
                                "Radiation changes",
                                new Definition()
                                    .Line("[PR] Radiation changes")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            // SNOMED Code: 429479009
                            // SNOMED Description: SituationWithExplicitContext | History of radiation therapy (Situation)
                            // ICD10: 429479009
                            new ConceptDef("RadiationTherapy",
                                "Radiation therapy",
                                new Definition()
                                    .Line("[PR] Radiation therapy")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            new ConceptDef("Scar",
                                "Scar",
                                new Definition()
                                    .Line("[PR] Scar")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("ScarWithShadowing",
                                "Scar with shadowing",
                                new Definition()
                                    .Line("[PR] Scar with shadowing")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("SclerosingAdenosis",
                                "Sclerosing adenosis",
                                new Definition()
                                    .Line("[PR] Sclerosing adenosis")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: ??????????????
                            new ConceptDef("SecretoryCalcification",
                                "Secretory calcification",
                                new Definition()
                                    .Line("[PR] Secretory calcification")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("SentinelNode",
                                "Sentinel node",
                                new Definition()
                                    .Line("[PR] Sentinel node")
                                    .ValidModalities(Modalities.NM)
                                ),
                            // SNOMED Code: 297178008
                            // SNOMED Description: ClinicalFinding | Breast seroma (Disorder)
                            // ICD10: 297178008
                            new ConceptDef("Seroma",
                                "Seroma",
                                new Definition()
                                    .Line("[PR] Seroma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 126510002
                            // SNOMED Description: ClinicalFinding | Neoplasm of skin of breast (Disorder)
                            // ICD10: 126510002
                            new ConceptDef("SkinLesion",
                                "Skin lesion",
                                new Definition()
                                    .Line("[PR] Skin lesion")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Surgery",
                                "Surgery",
                                new Definition()
                                    .Line("[PR] Surgery")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            // SNOMED Description: ClinicalFinding | 62112002 | Injury of breast (Disorder) 
                            // Comment: Need help no direct match
                            new ConceptDef("Trauma",
                                "Trauma",
                                new Definition()
                                    .Line("[PR] Trauma")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            // SNOMED Description: ClinicalFinding | 396779001 | Breast arterial calcification (Finding) | [0/0] | R92.1 
                            new ConceptDef("VascularCalcifications",
                                "Vascular calcifications",
                                new Definition()
                                    .Line("[PR] Vascular calcifications")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Description: ClinicalFinding | 71897006 | Venous stasis (Finding) | [0/0] | I87.8
                            new ConceptDef("VenousStasis",
                                "Venous stasis",
                                new Definition()
                                    .Line("[PR] Venous stasis")
                                    .ValidModalities(Modalities.NM)
                                )
                            //- ConsistentWithCS
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
                            //+ ConsistentWithQualifierCS
                            // CODE: Qualifier
                            new ConceptDef("LikelyRepresents",
                                "Likely represents",
                                new Definition()
                                    .Line("[PR] Likely represents")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // CODE: Qualifier
                            new ConceptDef("MostLikely",
                                "Most likely",
                                new Definition()
                                    .Line("[PR] Most likely")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            // CODE: Qualifier
                            new ConceptDef("Resembles",
                                "Resembles",
                                new Definition()
                                    .Line("[PR] Resembles")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            // CODE: Qualifier
                            new ConceptDef("w/differentialDiagnosis",
                                "w/differential diagnosis",
                                new Definition()
                                    .Line("[PR] w/differential diagnosis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                            //- ConsistentWithQualifierCS
                        })
             );
    }
}
