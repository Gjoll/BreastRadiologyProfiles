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
                           "Consistent With Value",
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
                           "Consistent With Qualifier",
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
                                )
                            //- Abscess
                            ,
                            //+ Angiolipoma
                            new ConceptDef()
                                .SetCode("Angiolipoma")
                                .SetDisplay("Angiolipoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Angiolipoma")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("404057003")
                                .SetSnomedDescription("ClinicalFinding | Angiolipoma (Disorder)")
                                .SetICD10("404057003")
                            //- Angiolipoma
                            ,
                            //+ ApocrineMetaplasia
                            new ConceptDef()
                                .SetCode("ApocrineMetaplasia")
                                .SetDisplay("Apocrine metaplasia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Apocrine metaplasia")
                                    .ValidModalities(Modalities.US)
                                )
                                .SetSnomedDescription("ClinicalFinding | 37009001 | Apocrine metaplasia of breast (Disorder) | [0/0] | N60.89")
                            //- ApocrineMetaplasia
                            ,
                            //+ Artifact
                            new ConceptDef()
                                .SetCode("Artifact")
                                .SetDisplay("Artifact")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Artifact")
                                    .ValidModalities(Modalities.NM)
                                )
                            //- Artifact
                            ,
                            //+ AtypicalHyperplasia
                            new ConceptDef()
                                .SetCode("AtypicalHyperplasia")
                                .SetDisplay("Atypical hyperplasia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Atypical hyperplasia")
                                    .ValidModalities(Modalities.MRI)
                                )
                            //- AtypicalHyperplasia
                            ,
                            //+ AxillaryLymphNode
                            new ConceptDef()
                                .SetCode("AxillaryLymphNode")
                                .SetDisplay("Axillary lymph node")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Axillary lymph node")
                                    .ValidModalities(Modalities.NM)
                                )
                                .SetSnomedDescription("BodyStructure | 245269009 | Axillary lymph node group (Bodypart)")
                            //- AxillaryLymphNode
                            ,
                            //+ Carcinoma
                            new ConceptDef()
                                .SetCode("Carcinoma")
                                .SetDisplay("Carcinoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Carcinoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                                .SetSnomedDescription("ClinicalFinding | 254838004 | Carcinoma of breast (Disorder) | [4/33] | C50.929")
                            //- Carcinoma
                            ,
                            //+ CarcinomaKnown
                            new ConceptDef()
                                .SetCode("CarcinomaKnown")
                                .SetDisplay("Carcinoma known")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Carcinoma known")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedDescription("ClinicalFinding | 254838004 | Carcinoma of breast (Disorder) | [4/33] | C50.929")
                            //- CarcinomaKnown
                            ,
                            //+ ClusterOfCysts
                            new ConceptDef()
                                .SetCode("ClusterOfCysts")
                                .SetDisplay("Cluster of cysts")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cluster of cysts")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("399294002")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding |Cyst of breast (Disorder) ++++++")
                                .SetICD10("399294002")
                                .SetComment("BodyStructure | 125291005 | Multiple cysts (Morphologic-Abnormality")
                            //- ClusterOfCysts
                            ,
                            //+ Cyst
                            new ConceptDef()
                                .SetCode("Cyst")
                                .SetDisplay("Cyst")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst")
                                    .ValidModalities(Modalities.MG | Modalities.MRI)
                                )
                                .SetSnomedCode("399294002")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding |Cyst of breast (Disorder) ")
                                .SetICD10("399294002")
                            //- Cyst
                            ,
                            //+ CystComplex
                            new ConceptDef()
                                .SetCode("CystComplex")
                                .SetDisplay("Cyst complex")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst complex")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("449837001")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding | Complex cyst of breast (Disorder)")
                                .SetICD10("449837001")
                            //- CystComplex
                            ,
                            //+ CystComplicated
                            new ConceptDef()
                                .SetCode("CystComplicated")
                                .SetDisplay("Cyst complicated")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst complicated")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                                .SetComment("NO CORRECT TERM")
                            //- CystComplicated
                            ,
                            //+ CystOil
                            new ConceptDef()
                                .SetCode("CystOil")
                                .SetDisplay("Cyst oil")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst oil")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                )
                                .SetComment("NO OIL CYST")
                            //- CystOil
                            ,
                            //+ CystSebaceous
                            new ConceptDef()
                                .SetCode("CystSebaceous")
                                .SetDisplay("Cyst sebaceous")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst sebaceous")
                                    .ValidModalities(Modalities.US)
                                )
                                .SetSnomedCode("76649007")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding | Sebaceous cyst of skin of breast (Disorder)")
                                .SetICD10("76649007")
                            //- CystSebaceous
                            ,
                            //+ CystSimple
                            new ConceptDef()
                                .SetCode("CystSimple")
                                .SetDisplay("Cyst simple")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst simple")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("399253005")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding | Simple cyst of breast (Disorder)")
                                .SetICD10("399253005")
                            //- CystSimple
                            ,
                            //+ CystsComplex
                            new ConceptDef()
                                .SetCode("CystsComplex")
                                .SetDisplay("Cysts complex")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cysts complex")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("449837001")
                                .SetOneToMany("Many")
                                .SetSnomedDescription("ClinicalFinding | Complex cyst of breast (Disorder)")
                                .SetICD10("449837001")
                            //- CystsComplex
                            ,
                            //+ CystsComplicated
                            new ConceptDef()
                                .SetCode("CystsComplicated")
                                .SetDisplay("Cysts complicated")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cysts complicated")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                                .SetComment("NO CORRECT TERM")
                            //- CystsComplicated
                            ,
                            //+ CystsMicroClustered
                            new ConceptDef()
                                .SetCode("CystsMicroClustered")
                                .SetDisplay("Cysts micro clustered")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cysts micro clustered")
                                    .ValidModalities(Modalities.US)
                                )
                                .SetComment("NO CORRECT TERM")
                            //- CystsMicroClustered
                            ,
                            //+ DCIS
                            new ConceptDef()
                                .SetCode("DCIS")
                                .SetDisplay("DCIS")
                                .SetDefinition(new Definition()
                                    .Line("[PR] DCIS")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                                .SetOneToMany("?????")
                                .SetSnomedDescription("BodyStructure | 399935008 | Ductal carcinoma in situ - category (Morphologic-Abnormality)")
                            //- DCIS
                            ,
                            //+ Debris
                            new ConceptDef()
                                .SetCode("Debris")
                                .SetDisplay("Debris")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Debris")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                )
                            //- Debris
                            ,
                            //+ Deodorant
                            new ConceptDef()
                                .SetCode("Deodorant")
                                .SetDisplay("Deodorant")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Deodorant")
                                    .ValidModalities(Modalities.MG)
                                )
                                .SetSnomedCode("39432004")
                                .SetSnomedDescription("PharmaceuticalBiologicProduct | Deodorant (Product)")
                                .SetICD10("39432004")
                            //- Deodorant
                            ,
                            //+ DermalCalcification
                            new ConceptDef()
                                .SetCode("DermalCalcification")
                                .SetDisplay("Dermal calcification")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Dermal calcification")
                                    .ValidModalities(Modalities.MG)
                                )
                            //- DermalCalcification
                            ,
                            //+ DuctEctasia
                            new ConceptDef()
                                .SetCode("DuctEctasia")
                                .SetDisplay("Duct ectasia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Duct ectasia")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedDescription("ClinicalFinding | 22049009 | Mammary duct ectasia (Disorder) | [0/0] | N60.49 ")
                            //- DuctEctasia
                            ,
                            //+ Edema
                            new ConceptDef()
                                .SetCode("Edema")
                                .SetDisplay("Edema")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Edema")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("290077003")
                                .SetSnomedDescription("ClinicalFinding | Edema of breast (Finding)")
                                .SetICD10("290077003")
                            //- Edema
                            ,
                            //+ FatLobule
                            new ConceptDef()
                                .SetCode("FatLobule")
                                .SetDisplay("Fat lobule")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fat lobule")
                                    .ValidModalities(Modalities.US)
                                )
                                .SetSnomedDescription("no direct match possible fat necrosis?")
                            //- FatLobule
                            ,
                            //+ FatNecrosis
                            new ConceptDef()
                                .SetCode("FatNecrosis")
                                .SetDisplay("Fat necrosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fat necrosis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("21381006")
                                .SetSnomedDescription("ClinicalFinding | Fat necrosis of breast (Disorder) ")
                                .SetICD10("21381006")
                            //- FatNecrosis
                            ,
                            //+ Fibroadenolipoma
                            new ConceptDef()
                                .SetCode("Fibroadenolipoma")
                                .SetDisplay("Fibroadenolipoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroadenolipoma")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                )
                                .SetComment("NO CORRECT TERM")
                            //- Fibroadenolipoma
                            ,
                            //+ Fibroadenoma
                            new ConceptDef()
                                .SetCode("Fibroadenoma")
                                .SetDisplay("Fibroadenoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroadenoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                            //- Fibroadenoma
                            ,
                            //+ FibroadenomaDegenerating
                            new ConceptDef()
                                .SetCode("FibroadenomaDegenerating")
                                .SetDisplay("Fibroadenoma degenerating")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroadenoma degenerating")
                                    .ValidModalities(Modalities.MG)
                                )
                            //- FibroadenomaDegenerating
                            ,
                            //+ FibrocysticChange
                            new ConceptDef()
                                .SetCode("FibrocysticChange")
                                .SetDisplay("Fibrocystic change")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibrocystic change")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("367647000")
                                .SetSnomedDescription("BodyStructure | Fibrocystic change ")
                                .SetICD10("367647000")
                                .SetComment("right/left/bilateral choices")
                            //- FibrocysticChange
                            ,
                            //+ FibroglandularTissue
                            new ConceptDef()
                                .SetCode("FibroglandularTissue")
                                .SetDisplay("Fibroglandular tissue")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroglandular tissue")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                            //- FibroglandularTissue
                            ,
                            //+ Fibrosis
                            new ConceptDef()
                                .SetCode("Fibrosis")
                                .SetDisplay("Fibrosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibrosis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedDescription("???????????")
                            //- Fibrosis
                            ,
                            //+ FibrousRidge
                            new ConceptDef()
                                .SetCode("FibrousRidge")
                                .SetDisplay("Fibrous ridge")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibrous ridge")
                                    .ValidModalities(Modalities.US)
                                )
                            //- FibrousRidge
                            ,
                            //+ Folliculitis
                            new ConceptDef()
                                .SetCode("Folliculitis")
                                .SetDisplay("Folliculitis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Folliculitis")
                                    .ValidModalities(Modalities.US)
                                )
                                .SetSnomedDescription("ClinicalFinding | 13600006 | Folliculitis (Disorder) | [6/113] | L73.9 ")
                            //- Folliculitis
                            ,
                            //+ Gynecomastia
                            new ConceptDef()
                                .SetCode("Gynecomastia")
                                .SetDisplay("Gynecomastia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Gynecomastia")
                                    .ValidModalities(Modalities.US)
                                )
                            //- Gynecomastia
                            ,
                            //+ Hamartoma
                            new ConceptDef()
                                .SetCode("Hamartoma")
                                .SetDisplay("Hamartoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Hamartoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("51398009")
                                .SetSnomedDescription("BodyStructure | Hamartoma (Morphologic-Abnormality)")
                                .SetICD10("51398009")
                            //- Hamartoma
                            ,
                            //+ Hematoma
                            new ConceptDef()
                                .SetCode("Hematoma")
                                .SetDisplay("Hematoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Hematoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("302924003")
                                .SetSnomedDescription("ClinicalFinding | Breast hematoma (Disorder) | N64.89")
                                .SetICD10("302924003")
                            //- Hematoma
                            ,
                            //+ HormonalStimulation
                            new ConceptDef()
                                .SetCode("HormonalStimulation")
                                .SetDisplay("Hormonal stimulation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Hormonal stimulation")
                                    .ValidModalities(Modalities.US)
                                )
                            //- HormonalStimulation
                            ,
                            //+ IntracysticLesion
                            new ConceptDef()
                                .SetCode("IntracysticLesion")
                                .SetDisplay("Intracystic lesion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Intracystic lesion")
                                    .ValidModalities(Modalities.US)
                                )
                            //- IntracysticLesion
                            ,
                            //+ IntramammaryNode
                            new ConceptDef()
                                .SetCode("IntramammaryNode")
                                .SetDisplay("Intramammary node")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Intramammary node")
                                    .ValidModalities(Modalities.MG | Modalities.NM)
                                )
                                .SetSnomedDescription("BodyStructure | 443159006 | Intramammary lymph node group (Bodypart)")
                            //- IntramammaryNode
                            ,
                            //+ Lipoma
                            new ConceptDef()
                                .SetCode("Lipoma")
                                .SetDisplay("Lipoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lipoma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("276891009")
                                .SetSnomedDescription("ClinicalFinding | Lipoma of breast (Disorder)")
                                .SetICD10("276891009")
                            //- Lipoma
                            ,
                            //+ LumpectomyCavity
                            new ConceptDef()
                                .SetCode("LumpectomyCavity")
                                .SetDisplay("Lumpectomy cavity")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lumpectomy cavity")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedDescription("BodyStructure | 261719000 | Breast cavity (Morphologic-Abnormality) ")
                                .SetComment("Need to create")
                            //- LumpectomyCavity
                            ,
                            //+ LumpectomySite
                            new ConceptDef()
                                .SetCode("LumpectomySite")
                                .SetDisplay("Lumpectomy site")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lumpectomy site")
                                    .ValidModalities(Modalities.MRI)
                                )
                                .SetSnomedDescription("BodyStructure | 261719000 | Breast cavity (Morphologic-Abnormality)")
                                .SetComment("needs better")
                            //- LumpectomySite
                            ,
                            //+ LymphNode
                            new ConceptDef()
                                .SetCode("LymphNode")
                                .SetDisplay("Lymph node")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                            //- LymphNode
                            ,
                            //+ LymphNodeEnlarged
                            new ConceptDef()
                                .SetCode("LymphNodeEnlarged")
                                .SetDisplay("Lymph node enlarged")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node enlarged")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("274741002 ")
                                .SetSnomedDescription("ClinicalFinding | Generalized enlarged lymph nodes (Disorder) | [0/0] | R59.1")
                                .SetICD10("274741002 ")
                            //- LymphNodeEnlarged
                            ,
                            //+ LymphNodeNormal
                            new ConceptDef()
                                .SetCode("LymphNodeNormal")
                                .SetDisplay("Lymph node normal")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node normal")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                            //- LymphNodeNormal
                            ,
                            //+ LymphNodePathological
                            new ConceptDef()
                                .SetCode("LymphNodePathological")
                                .SetDisplay("Lymph node pathological")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node pathological")
                                    .ValidModalities(Modalities.MRI)
                                )
                            //- LymphNodePathological
                            ,
                            //+ MassSolid
                            new ConceptDef()
                                .SetCode("MassSolid")
                                .SetDisplay("Mass solid")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mass solid")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                            //- MassSolid
                            ,
                            //+ MassSolidW/tumorVasc
                            new ConceptDef()
                                .SetCode("MassSolidW/tumorVasc")
                                .SetDisplay("Mass solid w/tumor vasc")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mass solid w/tumor vasc")
                                    .ValidModalities(Modalities.MRI)
                                )
                            //- MassSolidW/tumorVasc
                            ,
                            //+ Mastitis
                            new ConceptDef()
                                .SetCode("Mastitis")
                                .SetDisplay("Mastitis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mastitis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedDescription("ClinicalFinding | 45198002 | Mastitis (Disorder) | [3/51] | P39.0 | Neonatal infective mastitis | N61 | Inflammatory disorders of breast | ")
                            //- Mastitis
                            ,
                            //+ MilkOfCalcium
                            new ConceptDef()
                                .SetCode("MilkOfCalcium")
                                .SetDisplay("Milk of calcium")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Milk of calcium")
                                    .ValidModalities(Modalities.MG)
                                )
                                .SetDicom("F-01765")
                                .SetSnomedCode("129753004")
                                .SetSnomedDescription("ClinicalFinding | 129753004 | Milk of calcium radiographic calcification (Finding)")
                                .SetICD10("129753004")
                            //- MilkOfCalcium
                            ,
                            //+ Multi-focalCancer
                            new ConceptDef()
                                .SetCode("Multi-focalCancer")
                                .SetDisplay("Multi-focal cancer")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Multi-focal cancer")
                                    .ValidModalities(Modalities.NM)
                                )
                            //- Multi-focalCancer
                            ,
                            //+ PapillaryLesion
                            new ConceptDef()
                                .SetCode("PapillaryLesion")
                                .SetDisplay("Papillary lesion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Papillary lesion")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                )
                                .SetSnomedDescription("need help")
                            //- PapillaryLesion
                            ,
                            //+ Papilloma
                            new ConceptDef()
                                .SetCode("Papilloma")
                                .SetDisplay("Papilloma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Papilloma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("99571000119102")
                                .SetSnomedDescription("ClinicalFinding | Papilloma of breast (Disorder)")
                                .SetICD10("99571000119102")
                                .SetComment("US SM NUMBER")
                            //- Papilloma
                            ,
                            //+ PhyllodesTumor
                            new ConceptDef()
                                .SetCode("PhyllodesTumor")
                                .SetDisplay("Phyllodes tumor")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Phyllodes tumor")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedDescription("ClinicalFinding | 712989008 | Phyllodes tumor of breast (Disorder) | D48.6 |")
                            //- PhyllodesTumor
                            ,
                            //+ PostLumpectomyScar
                            new ConceptDef()
                                .SetCode("PostLumpectomyScar")
                                .SetDisplay("Post lumpectomy scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Post lumpectomy scar")
                                    .ValidModalities(Modalities.MG)
                                )
                                .SetOneToMany("???")
                                .SetSnomedDescription("BodyStructure | 63130001 | Surgical scar (Morphologic-Abnormality)")
                            //- PostLumpectomyScar
                            ,
                            //+ PostSurgicalScar
                            new ConceptDef()
                                .SetCode("PostSurgicalScar")
                                .SetDisplay("Post surgical scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Post surgical scar")
                                    .ValidModalities(Modalities.MG | Modalities.NM)
                                )
                                .SetSnomedDescription("BodyStructure | 63130001 | Surgical scar (Morphologic-Abnormality)")
                            //- PostSurgicalScar
                            ,
                            //+ PreviousBiopsy
                            new ConceptDef()
                                .SetCode("PreviousBiopsy")
                                .SetDisplay("Previous biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Previous biopsy")
                                    .ValidModalities(Modalities.MG)
                                )
                            //- PreviousBiopsy
                            ,
                            //+ PreviousSurgery
                            new ConceptDef()
                                .SetCode("PreviousSurgery")
                                .SetDisplay("Previous surgery")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Previous surgery")
                                    .ValidModalities(Modalities.MG)
                                )
                            //- PreviousSurgery
                            ,
                            //+ PreviousTrauma
                            new ConceptDef()
                                .SetCode("PreviousTrauma")
                                .SetDisplay("Previous trauma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Previous trauma")
                                    .ValidModalities(Modalities.MG)
                                )
                                .SetSnomedDescription("ClinicalFinding | 62112002 | Injury of breast (Disorder) | [4/41] | S29.9XX?")
                                .SetComment("NEED TO INDICATE PREVIOUS")
                            //- PreviousTrauma
                            ,
                            //+ RadialScar
                            new ConceptDef()
                                .SetCode("RadialScar")
                                .SetDisplay("Radial scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Radial scar")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                )
                                .SetSnomedCode("390787006")
                                .SetSnomedDescription("ClinicalFinding | Radial scar of breast (Finding)")
                                .SetICD10("390787006")
                            //- RadialScar
                            ,
                            //+ RadiationChanges
                            new ConceptDef()
                                .SetCode("RadiationChanges")
                                .SetDisplay("Radiation changes")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Radiation changes")
                                    .ValidModalities(Modalities.MRI)
                                )
                                .SetSnomedCode("143501000119107")
                                .SetSnomedDescription("SituationWithExplicitContext  | History of radiation therapy to breast area (Situation)")
                                .SetICD10("143501000119107")
                            //- RadiationChanges
                            ,
                            //+ RadiationTherapy
                            new ConceptDef()
                                .SetCode("RadiationTherapy")
                                .SetDisplay("Radiation therapy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Radiation therapy")
                                    .ValidModalities(Modalities.MRI)
                                )
                                .SetSnomedCode("429479009")
                                .SetSnomedDescription("SituationWithExplicitContext | History of radiation therapy (Situation)")
                                .SetICD10("429479009")
                            //- RadiationTherapy
                            ,
                            //+ Scar
                            new ConceptDef()
                                .SetCode("Scar")
                                .SetDisplay("Scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scar")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                            //- Scar
                            ,
                            //+ ScarWithShadowing
                            new ConceptDef()
                                .SetCode("ScarWithShadowing")
                                .SetDisplay("Scar with shadowing")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scar with shadowing")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                )
                            //- ScarWithShadowing
                            ,
                            //+ SclerosingAdenosis
                            new ConceptDef()
                                .SetCode("SclerosingAdenosis")
                                .SetDisplay("Sclerosing adenosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Sclerosing adenosis")
                                    .ValidModalities(Modalities.MG)
                                )
                            //- SclerosingAdenosis
                            ,
                            //+ SecretoryCalcification
                            new ConceptDef()
                                .SetCode("SecretoryCalcification")
                                .SetDisplay("Secretory calcification")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Secretory calcification")
                                    .ValidModalities(Modalities.MG)
                                )
                                .SetSnomedDescription("??????????????")
                            //- SecretoryCalcification
                            ,
                            //+ SentinelNode
                            new ConceptDef()
                                .SetCode("SentinelNode")
                                .SetDisplay("Sentinel node")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Sentinel node")
                                    .ValidModalities(Modalities.NM)
                                )
                            //- SentinelNode
                            ,
                            //+ Seroma
                            new ConceptDef()
                                .SetCode("Seroma")
                                .SetDisplay("Seroma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Seroma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                                .SetSnomedCode("297178008")
                                .SetSnomedDescription("ClinicalFinding | Breast seroma (Disorder)")
                                .SetICD10("297178008")
                            //- Seroma
                            ,
                            //+ SkinLesion
                            new ConceptDef()
                                .SetCode("SkinLesion")
                                .SetDisplay("Skin lesion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Skin lesion")
                                    .ValidModalities(Modalities.MG)
                                )
                                .SetSnomedCode("126510002")
                                .SetSnomedDescription("ClinicalFinding | Neoplasm of skin of breast (Disorder)")
                                .SetICD10("126510002")
                            //- SkinLesion
                            ,
                            //+ Surgery
                            new ConceptDef()
                                .SetCode("Surgery")
                                .SetDisplay("Surgery")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgery")
                                    .ValidModalities(Modalities.MRI)
                                )
                            //- Surgery
                            ,
                            //+ Trauma
                            new ConceptDef()
                                .SetCode("Trauma")
                                .SetDisplay("Trauma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Trauma")
                                    .ValidModalities(Modalities.MRI)
                                )
                                .SetSnomedDescription("ClinicalFinding | 62112002 | Injury of breast (Disorder) ")
                                .SetComment("Need help no direct match")
                            //- Trauma
                            ,
                            //+ VascularCalcifications
                            new ConceptDef()
                                .SetCode("VascularCalcifications")
                                .SetDisplay("Vascular calcifications")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Vascular calcifications")
                                    .ValidModalities(Modalities.MG)
                                )
                                .SetSnomedDescription("ClinicalFinding | 396779001 | Breast arterial calcification (Finding) | [0/0] | R92.1 ")
                            //- VascularCalcifications
                            ,
                            //+ VenousStasis
                            new ConceptDef()
                                .SetCode("VenousStasis")
                                .SetDisplay("Venous stasis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Venous stasis")
                                    .ValidModalities(Modalities.NM)
                                )
                                .SetSnomedDescription("ClinicalFinding | 71897006 | Venous stasis (Finding) | [0/0] | I87.8")
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
                            //+ LikelyRepresents
                            new ConceptDef()
                                .SetCode("LikelyRepresents")
                                .SetDisplay("Likely represents")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Likely represents")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                                .SetPenCode("Qualifier")
                            //- LikelyRepresents
                            ,
                            //+ MostLikely
                            new ConceptDef()
                                .SetCode("MostLikely")
                                .SetDisplay("Most likely")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Most likely")
                                    .ValidModalities(Modalities.MG | Modalities.US)
                                )
                                .SetPenCode("Qualifier")
                            //- MostLikely
                            ,
                            //+ Resembles
                            new ConceptDef()
                                .SetCode("Resembles")
                                .SetDisplay("Resembles")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Resembles")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                                .SetPenCode("Qualifier")
                            //- Resembles
                            ,
                            //+ w/differentialDiagnosis
                            new ConceptDef()
                                .SetCode("w/differentialDiagnosis")
                                .SetDisplay("w/differential diagnosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] w/differential diagnosis")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                )
                                .SetPenCode("Qualifier")
                            //- w/differentialDiagnosis
                            
                            //- ConsistentWithQualifierCS
                        })
             );
    }
}
