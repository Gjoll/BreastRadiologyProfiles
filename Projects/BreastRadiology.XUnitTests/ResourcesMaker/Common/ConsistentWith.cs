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
                        ObservationUrl,
                        $"{Group_CommonResources}/ConsistentWith",
                        "ObservationLeaf")
                           .AddFragRef(Self.ObservationLeafFragment.Value())
                           .Description("'Consistent With' Observation",
                               new Markdown()
                           )
                           .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                           .AddFragRef(Self.ObservationNoValueFragment.Value())
                           ;
                       s = e.SDef;

                       e.StartComponentSliceing();
                       e.ComponentSliceCodeableConcept("value",
                           Self.CodeConsistentWithValue.ToCodeableConcept(),
                           Self.ConsistentWithVS.Value(),
                           BindingStrength.Extensible,
                           1,
                           "1",
                           "Value",
                            new Markdown()
                                .Paragraph($"This slice contains the required component that defines what this observation is consistent with.",
                                            $"The value of this component is a codeable concept chosen from the {Self.ConsistentWithVS.Value().Name} valueset.")
                       );
                       e.ComponentSliceCodeableConcept("qualifier",
                           Self.CodeConsistentWithQualifier.ToCodeableConcept(),
                           Self.ConsistentWithQualifierVS.Value(),
                           BindingStrength.Required,
                           0,
                           "*",
                           "Qualifier",
                            new Markdown()
                                .Paragraph($"This slice contains zero or more components that qualify the consistent with slice component value.",
                                            $"The value of this component is a codeable concept chosen from the {Self.ConsistentWithVS.Value().Name} valueset.")
                           );

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
                            //+ Abscess
                            new ConceptDef()
                                .SetCode("Abscess")
                                .SetDisplay("Abscess")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Abscess")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Abscess
                            // SNOMED Code: 404057003
                            // SNOMED Description: ClinicalFinding | Angiolipoma (Disorder)
                            // ICD10: 404057003
                            //+ Angiolipoma
                            new ConceptDef()
                                .SetCode("Angiolipoma")
                                .SetDisplay("Angiolipoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Angiolipoma")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- Angiolipoma
                            // SNOMED Description: ClinicalFinding | 37009001 | Apocrine metaplasia of breast (Disorder) | [0/0] | N60.89
                            //+ ApocrineMetaplasia
                            new ConceptDef()
                                .SetCode("ApocrineMetaplasia")
                                .SetDisplay("Apocrine metaplasia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Apocrine metaplasia")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- ApocrineMetaplasia
                            //+ Artifact
                            new ConceptDef()
                                .SetCode("Artifact")
                                .SetDisplay("Artifact")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Artifact")
                                    .ValidModalities(Modalities.NM)
                                ),
                            //- Artifact
                            //+ AtypicalHyperplasia
                            new ConceptDef()
                                .SetCode("AtypicalHyperplasia")
                                .SetDisplay("Atypical hyperplasia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Atypical hyperplasia")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- AtypicalHyperplasia
                            // SNOMED Description: BodyStructure | 245269009 | Axillary lymph node group (Bodypart)
                            //+ AxillaryLymphNode
                            new ConceptDef()
                                .SetCode("AxillaryLymphNode")
                                .SetDisplay("Axillary lymph node")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Axillary lymph node")
                                    .ValidModalities(Modalities.NM)
                                ),
                            //- AxillaryLymphNode
                            // SNOMED Description: ClinicalFinding | 254838004 | Carcinoma of breast (Disorder) | [4/33] | C50.929
                            //+ Carcinoma
                            new ConceptDef()
                                .SetCode("Carcinoma")
                                .SetDisplay("Carcinoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Carcinoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- Carcinoma
                            // SNOMED Description: ClinicalFinding | 254838004 | Carcinoma of breast (Disorder) | [4/33] | C50.929
                            //+ CarcinomaKnown
                            new ConceptDef()
                                .SetCode("CarcinomaKnown")
                                .SetDisplay("Carcinoma known")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Carcinoma known")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- CarcinomaKnown
                            // SNOMED Code: 399294002
                            // oneToMany: one
                            // SNOMED Description: ClinicalFinding |Cyst of breast (Disorder) ++++++
                            // ICD10: 399294002
                            // Comment: BodyStructure | 125291005 | Multiple cysts (Morphologic-Abnormality
                            //+ ClusterOfCysts
                            new ConceptDef()
                                .SetCode("ClusterOfCysts")
                                .SetDisplay("Cluster of cysts")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cluster of cysts")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- ClusterOfCysts
                            // SNOMED Code: 399294002
                            // oneToMany: one
                            // SNOMED Description: ClinicalFinding |Cyst of breast (Disorder) 
                            // ICD10: 399294002
                            //+ Cyst
                            new ConceptDef()
                                .SetCode("Cyst")
                                .SetDisplay("Cyst")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst")
                                    .ValidModalities(Modalities.MG | Modalities.MRI)
                                ),
                            //- Cyst
                            // SNOMED Code: 449837001
                            // oneToMany: one
                            // SNOMED Description: ClinicalFinding | Complex cyst of breast (Disorder)
                            // ICD10: 449837001
                            //+ CystComplex
                            new ConceptDef()
                                .SetCode("CystComplex")
                                .SetDisplay("Cyst complex")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst complex")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- CystComplex
                            // Comment: NO CORRECT TERM
                            //+ CystComplicated
                            new ConceptDef()
                                .SetCode("CystComplicated")
                                .SetDisplay("Cyst complicated")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst complicated")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- CystComplicated
                            // Comment: NO OIL CYST
                            //+ CystOil
                            new ConceptDef()
                                .SetCode("CystOil")
                                .SetDisplay("Cyst oil")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst oil")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- CystOil
                            // SNOMED Code: 76649007
                            // oneToMany: one
                            // SNOMED Description: ClinicalFinding | Sebaceous cyst of skin of breast (Disorder)
                            // ICD10: 76649007
                            //+ CystSebaceous
                            new ConceptDef()
                                .SetCode("CystSebaceous")
                                .SetDisplay("Cyst sebaceous")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst sebaceous")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- CystSebaceous
                            // SNOMED Code: 399253005
                            // oneToMany: one
                            // SNOMED Description: ClinicalFinding | Simple cyst of breast (Disorder)
                            // ICD10: 399253005
                            //+ CystSimple
                            new ConceptDef()
                                .SetCode("CystSimple")
                                .SetDisplay("Cyst simple")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst simple")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- CystSimple
                            // SNOMED Code: 449837001
                            // oneToMany: Many
                            // SNOMED Description: ClinicalFinding | Complex cyst of breast (Disorder)
                            // ICD10: 449837001
                            //+ CystsComplex
                            new ConceptDef()
                                .SetCode("CystsComplex")
                                .SetDisplay("Cysts complex")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cysts complex")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- CystsComplex
                            // Comment: NO CORRECT TERM
                            //+ CystsComplicated
                            new ConceptDef()
                                .SetCode("CystsComplicated")
                                .SetDisplay("Cysts complicated")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cysts complicated")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- CystsComplicated
                            // Comment: NO CORRECT TERM
                            //+ CystsMicroClustered
                            new ConceptDef()
                                .SetCode("CystsMicroClustered")
                                .SetDisplay("Cysts micro clustered")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cysts micro clustered")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- CystsMicroClustered
                            // oneToMany: ?????
                            // SNOMED Description: BodyStructure | 399935008 | Ductal carcinoma in situ - category (Morphologic-Abnormality)
                            //+ DCIS
                            new ConceptDef()
                                .SetCode("DCIS")
                                .SetDisplay("DCIS")
                                .SetDefinition(new Definition()
                                    .Line("[PR] DCIS")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- DCIS
                            //+ Debris
                            new ConceptDef()
                                .SetCode("Debris")
                                .SetDisplay("Debris")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Debris")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- Debris
                            // SNOMED Code: 39432004
                            // SNOMED Description: PharmaceuticalBiologicProduct | Deodorant (Product)
                            // ICD10: 39432004
                            //+ Deodorant
                            new ConceptDef()
                                .SetCode("Deodorant")
                                .SetDisplay("Deodorant")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Deodorant")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- Deodorant
                            //+ DermalCalcification
                            new ConceptDef()
                                .SetCode("DermalCalcification")
                                .SetDisplay("Dermal calcification")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Dermal calcification")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- DermalCalcification
                            // SNOMED Description: ClinicalFinding | 22049009 | Mammary duct ectasia (Disorder) | [0/0] | N60.49 
                            //+ DuctEctasia
                            new ConceptDef()
                                .SetCode("DuctEctasia")
                                .SetDisplay("Duct ectasia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Duct ectasia")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- DuctEctasia
                            // SNOMED Code: 290077003
                            // SNOMED Description: ClinicalFinding | Edema of breast (Finding)
                            // ICD10: 290077003
                            //+ Edema
                            new ConceptDef()
                                .SetCode("Edema")
                                .SetDisplay("Edema")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Edema")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- Edema
                            // SNOMED Description: no direct match possible fat necrosis?
                            //+ FatLobule
                            new ConceptDef()
                                .SetCode("FatLobule")
                                .SetDisplay("Fat lobule")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fat lobule")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- FatLobule
                            // SNOMED Code: 21381006
                            // SNOMED Description: ClinicalFinding | Fat necrosis of breast (Disorder) 
                            // ICD10: 21381006
                            //+ FatNecrosis
                            new ConceptDef()
                                .SetCode("FatNecrosis")
                                .SetDisplay("Fat necrosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fat necrosis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- FatNecrosis
                            // Comment: NO CORRECT TERM
                            //+ Fibroadenolipoma
                            new ConceptDef()
                                .SetCode("Fibroadenolipoma")
                                .SetDisplay("Fibroadenolipoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroadenolipoma")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- Fibroadenolipoma
                            //+ Fibroadenoma
                            new ConceptDef()
                                .SetCode("Fibroadenoma")
                                .SetDisplay("Fibroadenoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroadenoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- Fibroadenoma
                            //+ FibroadenomaDegenerating
                            new ConceptDef()
                                .SetCode("FibroadenomaDegenerating")
                                .SetDisplay("Fibroadenoma degenerating")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroadenoma degenerating")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- FibroadenomaDegenerating
                            // SNOMED Code: 367647000
                            // SNOMED Description: BodyStructure | Fibrocystic change 
                            // ICD10: 367647000
                            // Comment: right/left/bilateral choices
                            //+ FibrocysticChange
                            new ConceptDef()
                                .SetCode("FibrocysticChange")
                                .SetDisplay("Fibrocystic change")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibrocystic change")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- FibrocysticChange
                            //+ FibroglandularTissue
                            new ConceptDef()
                                .SetCode("FibroglandularTissue")
                                .SetDisplay("Fibroglandular tissue")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroglandular tissue")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- FibroglandularTissue
                            // SNOMED Description: ???????????
                            //+ Fibrosis
                            new ConceptDef()
                                .SetCode("Fibrosis")
                                .SetDisplay("Fibrosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibrosis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Fibrosis
                            //+ FibrousRidge
                            new ConceptDef()
                                .SetCode("FibrousRidge")
                                .SetDisplay("Fibrous ridge")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibrous ridge")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- FibrousRidge
                            // SNOMED Description: ClinicalFinding | 13600006 | Folliculitis (Disorder) | [6/113] | L73.9 
                            //+ Folliculitis
                            new ConceptDef()
                                .SetCode("Folliculitis")
                                .SetDisplay("Folliculitis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Folliculitis")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- Folliculitis
                            //+ Gynecomastia
                            new ConceptDef()
                                .SetCode("Gynecomastia")
                                .SetDisplay("Gynecomastia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Gynecomastia")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- Gynecomastia
                            // SNOMED Code: 51398009
                            // SNOMED Description: BodyStructure | Hamartoma (Morphologic-Abnormality)
                            // ICD10: 51398009
                            //+ Hamartoma
                            new ConceptDef()
                                .SetCode("Hamartoma")
                                .SetDisplay("Hamartoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Hamartoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Hamartoma
                            // SNOMED Code: 302924003
                            // SNOMED Description: ClinicalFinding | Breast hematoma (Disorder) | N64.89
                            // ICD10: 302924003
                            //+ Hematoma
                            new ConceptDef()
                                .SetCode("Hematoma")
                                .SetDisplay("Hematoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Hematoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Hematoma
                            //+ HormonalStimulation
                            new ConceptDef()
                                .SetCode("HormonalStimulation")
                                .SetDisplay("Hormonal stimulation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Hormonal stimulation")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- HormonalStimulation
                            //+ IntracysticLesion
                            new ConceptDef()
                                .SetCode("IntracysticLesion")
                                .SetDisplay("Intracystic lesion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Intracystic lesion")
                                    .ValidModalities(Modalities.US)
                                ),
                            //- IntracysticLesion
                            // SNOMED Description: BodyStructure | 443159006 | Intramammary lymph node group (Bodypart)
                            //+ IntramammaryNode
                            new ConceptDef()
                                .SetCode("IntramammaryNode")
                                .SetDisplay("Intramammary node")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Intramammary node")
                                    .ValidModalities(Modalities.MG | Modalities.NM)
                                ),
                            //- IntramammaryNode
                            // SNOMED Code: 276891009
                            // SNOMED Description: ClinicalFinding | Lipoma of breast (Disorder)
                            // ICD10: 276891009
                            //+ Lipoma
                            new ConceptDef()
                                .SetCode("Lipoma")
                                .SetDisplay("Lipoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lipoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Lipoma
                            // SNOMED Description: BodyStructure | 261719000 | Breast cavity (Morphologic-Abnormality) 
                            // Comment: Need to create
                            //+ LumpectomyCavity
                            new ConceptDef()
                                .SetCode("LumpectomyCavity")
                                .SetDisplay("Lumpectomy cavity")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lumpectomy cavity")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- LumpectomyCavity
                            // SNOMED Description: BodyStructure | 261719000 | Breast cavity (Morphologic-Abnormality)
                            // Comment: needs better
                            //+ LumpectomySite
                            new ConceptDef()
                                .SetCode("LumpectomySite")
                                .SetDisplay("Lumpectomy site")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lumpectomy site")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- LumpectomySite
                            //+ LymphNode
                            new ConceptDef()
                                .SetCode("LymphNode")
                                .SetDisplay("Lymph node")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- LymphNode
                            // SNOMED Code: 274741002 
                            // SNOMED Description: ClinicalFinding | Generalized enlarged lymph nodes (Disorder) | [0/0] | R59.1
                            // ICD10: 274741002 
                            //+ LymphNodeEnlarged
                            new ConceptDef()
                                .SetCode("LymphNodeEnlarged")
                                .SetDisplay("Lymph node enlarged")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node enlarged")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- LymphNodeEnlarged
                            //+ LymphNodeNormal
                            new ConceptDef()
                                .SetCode("LymphNodeNormal")
                                .SetDisplay("Lymph node normal")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node normal")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- LymphNodeNormal
                            //+ LymphNodePathological
                            new ConceptDef()
                                .SetCode("LymphNodePathological")
                                .SetDisplay("Lymph node pathological")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node pathological")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- LymphNodePathological
                            //+ MassSolid
                            new ConceptDef()
                                .SetCode("MassSolid")
                                .SetDisplay("Mass solid")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mass solid")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- MassSolid
                            //+ MassSolidW/tumorVasc
                            new ConceptDef()
                                .SetCode("MassSolidW/tumorVasc")
                                .SetDisplay("Mass solid w/tumor vasc")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mass solid w/tumor vasc")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- MassSolidW/tumorVasc
                            // SNOMED Description: ClinicalFinding | 45198002 | Mastitis (Disorder) | [3/51] | P39.0 | Neonatal infective mastitis | N61 | Inflammatory disorders of breast | 
                            //+ Mastitis
                            new ConceptDef()
                                .SetCode("Mastitis")
                                .SetDisplay("Mastitis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mastitis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Mastitis
                            // DICOM: F-01765
                            // SNOMED Code: 129753004
                            // SNOMED Description: ClinicalFinding | 129753004 | Milk of calcium radiographic calcification (Finding)
                            // ICD10: 129753004
                            //+ MilkOfCalcium
                            new ConceptDef()
                                .SetCode("MilkOfCalcium")
                                .SetDisplay("Milk of calcium")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Milk of calcium")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- MilkOfCalcium
                            //+ Multi-focalCancer
                            new ConceptDef()
                                .SetCode("Multi-focalCancer")
                                .SetDisplay("Multi-focal cancer")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Multi-focal cancer")
                                    .ValidModalities(Modalities.NM)
                                ),
                            //- Multi-focalCancer
                            // SNOMED Description: need help
                            //+ PapillaryLesion
                            new ConceptDef()
                                .SetCode("PapillaryLesion")
                                .SetDisplay("Papillary lesion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Papillary lesion")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- PapillaryLesion
                            // SNOMED Code: 99571000119102
                            // SNOMED Description: ClinicalFinding | Papilloma of breast (Disorder)
                            // ICD10: 99571000119102
                            // Comment: US SM NUMBER
                            //+ Papilloma
                            new ConceptDef()
                                .SetCode("Papilloma")
                                .SetDisplay("Papilloma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Papilloma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Papilloma
                            // SNOMED Description: ClinicalFinding | 712989008 | Phyllodes tumor of breast (Disorder) | D48.6 |
                            //+ PhyllodesTumor
                            new ConceptDef()
                                .SetCode("PhyllodesTumor")
                                .SetDisplay("Phyllodes tumor")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Phyllodes tumor")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- PhyllodesTumor
                            // oneToMany: ???
                            // SNOMED Description: BodyStructure | 63130001 | Surgical scar (Morphologic-Abnormality)
                            //+ PostLumpectomyScar
                            new ConceptDef()
                                .SetCode("PostLumpectomyScar")
                                .SetDisplay("Post lumpectomy scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Post lumpectomy scar")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- PostLumpectomyScar
                            // SNOMED Description: BodyStructure | 63130001 | Surgical scar (Morphologic-Abnormality)
                            //+ PostSurgicalScar
                            new ConceptDef()
                                .SetCode("PostSurgicalScar")
                                .SetDisplay("Post surgical scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Post surgical scar")
                                    .ValidModalities(Modalities.MG | Modalities.NM)
                                ),
                            //- PostSurgicalScar
                            //+ PreviousBiopsy
                            new ConceptDef()
                                .SetCode("PreviousBiopsy")
                                .SetDisplay("Previous biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Previous biopsy")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- PreviousBiopsy
                            //+ PreviousSurgery
                            new ConceptDef()
                                .SetCode("PreviousSurgery")
                                .SetDisplay("Previous surgery")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Previous surgery")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- PreviousSurgery
                            // SNOMED Description: ClinicalFinding | 62112002 | Injury of breast (Disorder) | [4/41] | S29.9XX?
                            // Comment: NEED TO INDICATE PREVIOUS
                            //+ PreviousTrauma
                            new ConceptDef()
                                .SetCode("PreviousTrauma")
                                .SetDisplay("Previous trauma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Previous trauma")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- PreviousTrauma
                            // SNOMED Code: 390787006
                            // SNOMED Description: ClinicalFinding | Radial scar of breast (Finding)
                            // ICD10: 390787006
                            //+ RadialScar
                            new ConceptDef()
                                .SetCode("RadialScar")
                                .SetDisplay("Radial scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Radial scar")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- RadialScar
                            // SNOMED Code: 143501000119107
                            // SNOMED Description: SituationWithExplicitContext  | History of radiation therapy to breast area (Situation)
                            // ICD10: 143501000119107
                            //+ RadiationChanges
                            new ConceptDef()
                                .SetCode("RadiationChanges")
                                .SetDisplay("Radiation changes")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Radiation changes")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- RadiationChanges
                            // SNOMED Code: 429479009
                            // SNOMED Description: SituationWithExplicitContext | History of radiation therapy (Situation)
                            // ICD10: 429479009
                            //+ RadiationTherapy
                            new ConceptDef()
                                .SetCode("RadiationTherapy")
                                .SetDisplay("Radiation therapy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Radiation therapy")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- RadiationTherapy
                            //+ Scar
                            new ConceptDef()
                                .SetCode("Scar")
                                .SetDisplay("Scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scar")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- Scar
                            //+ ScarWithShadowing
                            new ConceptDef()
                                .SetCode("ScarWithShadowing")
                                .SetDisplay("Scar with shadowing")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scar with shadowing")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            //- ScarWithShadowing
                            //+ SclerosingAdenosis
                            new ConceptDef()
                                .SetCode("SclerosingAdenosis")
                                .SetDisplay("Sclerosing adenosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Sclerosing adenosis")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- SclerosingAdenosis
                            // SNOMED Description: ??????????????
                            //+ SecretoryCalcification
                            new ConceptDef()
                                .SetCode("SecretoryCalcification")
                                .SetDisplay("Secretory calcification")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Secretory calcification")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- SecretoryCalcification
                            //+ SentinelNode
                            new ConceptDef()
                                .SetCode("SentinelNode")
                                .SetDisplay("Sentinel node")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Sentinel node")
                                    .ValidModalities(Modalities.NM)
                                ),
                            //- SentinelNode
                            // SNOMED Code: 297178008
                            // SNOMED Description: ClinicalFinding | Breast seroma (Disorder)
                            // ICD10: 297178008
                            //+ Seroma
                            new ConceptDef()
                                .SetCode("Seroma")
                                .SetDisplay("Seroma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Seroma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Seroma
                            // SNOMED Code: 126510002
                            // SNOMED Description: ClinicalFinding | Neoplasm of skin of breast (Disorder)
                            // ICD10: 126510002
                            //+ SkinLesion
                            new ConceptDef()
                                .SetCode("SkinLesion")
                                .SetDisplay("Skin lesion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Skin lesion")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- SkinLesion
                            //+ Surgery
                            new ConceptDef()
                                .SetCode("Surgery")
                                .SetDisplay("Surgery")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgery")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- Surgery
                            // SNOMED Description: ClinicalFinding | 62112002 | Injury of breast (Disorder) 
                            // Comment: Need help no direct match
                            //+ Trauma
                            new ConceptDef()
                                .SetCode("Trauma")
                                .SetDisplay("Trauma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Trauma")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- Trauma
                            // SNOMED Description: ClinicalFinding | 396779001 | Breast arterial calcification (Finding) | [0/0] | R92.1 
                            //+ VascularCalcifications
                            new ConceptDef()
                                .SetCode("VascularCalcifications")
                                .SetDisplay("Vascular calcifications")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Vascular calcifications")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- VascularCalcifications
                            // SNOMED Description: ClinicalFinding | 71897006 | Venous stasis (Finding) | [0/0] | I87.8
                            //+ VenousStasis
                            new ConceptDef()
                                .SetCode("VenousStasis")
                                .SetDisplay("Venous stasis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Venous stasis")
                                    .ValidModalities(Modalities.NM)
                                )
                            //- VenousStasis
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
                            //+ LikelyRepresents
                            new ConceptDef()
                                .SetCode("LikelyRepresents")
                                .SetDisplay("Likely represents")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Likely represents")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- LikelyRepresents
                            // CODE: Qualifier
                            //+ MostLikely
                            new ConceptDef()
                                .SetCode("MostLikely")
                                .SetDisplay("Most likely")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Most likely")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                ),
                            //- MostLikely
                            // CODE: Qualifier
                            //+ Resembles
                            new ConceptDef()
                                .SetCode("Resembles")
                                .SetDisplay("Resembles")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Resembles")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                ),
                            //- Resembles
                            // CODE: Qualifier
                            //+ w/differentialDiagnosis
                            new ConceptDef()
                                .SetCode("w/differentialDiagnosis")
                                .SetDisplay("w/differential diagnosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] w/differential diagnosis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                            //- w/differentialDiagnosis
                            //- ConsistentWithQualifierCS
                        })
             );
    }
}
