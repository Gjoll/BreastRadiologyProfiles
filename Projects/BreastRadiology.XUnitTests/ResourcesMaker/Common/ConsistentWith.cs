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
                           .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                           .AddFragRef(Self.ObservationNoValueFragment.Value())
                           .AddFragRef(Self.ObservationNoComponentFragment.Value())
                           .Description("'Consistent With' Observation",
                               new Markdown()
                           )
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
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Abscess")
                                .SetDisplay("Abscess")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Abscess")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- Abscess
                            ,
                            //+ Angiolipoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Angiolipoma")
                                .SetDisplay("Angiolipoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Angiolipoma")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("404057003")
                                .SetSnomedDescription("ClinicalFinding | Angiolipoma (Disorder)")
                                .SetICD10("404057003")
                            //- AutoGen
                            //- Angiolipoma
                            ,
                            //+ ApocrineMetaplasia
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ApocrineMetaplasia")
                                .SetDisplay("Apocrine metaplasia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Apocrine metaplasia")
                                )
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 37009001 | Apocrine metaplasia of breast (Disorder) | [0/0] | N60.89")
                            //- AutoGen
                            //- ApocrineMetaplasia
                            ,
                            //+ Artifact
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Artifact")
                                .SetDisplay("Artifact")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Artifact")
                                )
                                .ValidModalities(Modalities.NM)
                            //- AutoGen
                            //- Artifact
                            ,
                            //+ AtypicalHyperplasia
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("AtypicalHyperplasia")
                                .SetDisplay("Atypical hyperplasia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Atypical hyperplasia")
                                )
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            //- AtypicalHyperplasia
                            ,
                            //+ AxillaryLymphNode
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("AxillaryLymphNode")
                                .SetDisplay("Axillary lymph node")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Axillary lymph node")
                                )
                                .ValidModalities(Modalities.NM)
                                .SetSnomedDescription("BodyStructure | 245269009 | Axillary lymph node group (Bodypart)")
                            //- AutoGen
                            //- AxillaryLymphNode
                            ,
                            //+ Carcinoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Carcinoma")
                                .SetDisplay("Carcinoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Carcinoma")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 254838004 | Carcinoma of breast (Disorder) | [4/33] | C50.929")
                            //- AutoGen
                            //- Carcinoma
                            ,
                            //+ CarcinomaKnown
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CarcinomaKnown")
                                .SetDisplay("Carcinoma known")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Carcinoma known")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 254838004 | Carcinoma of breast (Disorder) | [4/33] | C50.929")
                            //- AutoGen
                            //- CarcinomaKnown
                            ,
                            //+ ClusterOfCysts
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ClusterOfCysts")
                                .SetDisplay("Cluster of cysts")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cluster of cysts")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("399294002")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding |Cyst of breast (Disorder) ++++++")
                                .SetICD10("399294002")
                                .SetComment("BodyStructure | 125291005 | Multiple cysts (Morphologic-Abnormality")
                            //- AutoGen
                            //- ClusterOfCysts
                            ,
                            //+ Cyst
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Cyst")
                                .SetDisplay("Cyst")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI)
                                .SetSnomedCode("399294002")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding |Cyst of breast (Disorder)")
                                .SetICD10("399294002")
                            //- AutoGen
                            //- Cyst
                            ,
                            //+ CystComplex
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystComplex")
                                .SetDisplay("Cyst complex")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst complex")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("449837001")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding | Complex cyst of breast (Disorder)")
                                .SetICD10("449837001")
                            //- AutoGen
                            //- CystComplex
                            ,
                            //+ CystComplicated
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystComplicated")
                                .SetDisplay("Cyst complicated")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst complicated")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetComment("NO CORRECT TERM")
                            //- AutoGen
                            //- CystComplicated
                            ,
                            //+ CystOil
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystOil")
                                .SetDisplay("Cyst oil")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst oil")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetComment("NO OIL CYST")
                            //- AutoGen
                            //- CystOil
                            ,
                            //+ CystSebaceous
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystSebaceous")
                                .SetDisplay("Cyst sebaceous")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst sebaceous")
                                )
                                .ValidModalities(Modalities.US)
                                .SetSnomedCode("76649007")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding | Sebaceous cyst of skin of breast (Disorder)")
                                .SetICD10("76649007")
                            //- AutoGen
                            //- CystSebaceous
                            ,
                            //+ CystSimple
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystSimple")
                                .SetDisplay("Cyst simple")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cyst simple")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("399253005")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding | Simple cyst of breast (Disorder)")
                                .SetICD10("399253005")
                            //- AutoGen
                            //- CystSimple
                            ,
                            //+ CystsComplex
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystsComplex")
                                .SetDisplay("Cysts complex")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cysts complex")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("449837001")
                                .SetOneToMany("Many")
                                .SetSnomedDescription("ClinicalFinding | Complex cyst of breast (Disorder)")
                                .SetICD10("449837001")
                            //- AutoGen
                            //- CystsComplex
                            ,
                            //+ CystsComplicated
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystsComplicated")
                                .SetDisplay("Cysts complicated")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cysts complicated")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetComment("NO CORRECT TERM")
                            //- AutoGen
                            //- CystsComplicated
                            ,
                            //+ CystsMicroClustered
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CystsMicroClustered")
                                .SetDisplay("Cysts micro clustered")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cysts micro clustered")
                                )
                                .ValidModalities(Modalities.US)
                                .SetComment("NO CORRECT TERM")
                            //- AutoGen
                            //- CystsMicroClustered
                            ,
                            //+ DCIS
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DCIS")
                                .SetDisplay("DCIS")
                                .SetDefinition(new Definition()
                                    .Line("[PR] DCIS")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetOneToMany("?????")
                                .SetSnomedDescription("BodyStructure | 399935008 | Ductal carcinoma in situ - category (Morphologic-Abnormality)")
                            //- AutoGen
                            //- DCIS
                            ,
                            //+ Debris
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Debris")
                                .SetDisplay("Debris")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Debris")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            //- Debris
                            ,
                            //+ Deodorant
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Deodorant")
                                .SetDisplay("Deodorant")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Deodorant")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("39432004")
                                .SetSnomedDescription("PharmaceuticalBiologicProduct | Deodorant (Product)")
                                .SetICD10("39432004")
                            //- AutoGen
                            //- Deodorant
                            ,
                            //+ DermalCalcification
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DermalCalcification")
                                .SetDisplay("Dermal calcification")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Dermal calcification")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- DermalCalcification
                            ,
                            //+ DuctEctasia
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DuctEctasia")
                                .SetDisplay("Duct ectasia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Duct ectasia")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 22049009 | Mammary duct ectasia (Disorder) | [0/0] | N60.49")
                            //- AutoGen
                            //- DuctEctasia
                            ,
                            //+ Edema
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Edema")
                                .SetDisplay("Edema")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Edema")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("290077003")
                                .SetSnomedDescription("ClinicalFinding | Edema of breast (Finding)")
                                .SetICD10("290077003")
                            //- AutoGen
                            //- Edema
                            ,
                            //+ FatLobule
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FatLobule")
                                .SetDisplay("Fat lobule")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fat lobule")
                                )
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("no direct match possible fat necrosis?")
                            //- AutoGen
                            //- FatLobule
                            ,
                            //+ FatNecrosis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FatNecrosis")
                                .SetDisplay("Fat necrosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fat necrosis")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("21381006")
                                .SetSnomedDescription("ClinicalFinding | Fat necrosis of breast (Disorder)")
                                .SetICD10("21381006")
                            //- AutoGen
                            //- FatNecrosis
                            ,
                            //+ Fibroadenolipoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Fibroadenolipoma")
                                .SetDisplay("Fibroadenolipoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroadenolipoma")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetComment("NO CORRECT TERM")
                            //- AutoGen
                            //- Fibroadenolipoma
                            ,
                            //+ Fibroadenoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Fibroadenoma")
                                .SetDisplay("Fibroadenoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroadenoma")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- Fibroadenoma
                            ,
                            //+ FibroadenomaDegenerating
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FibroadenomaDegenerating")
                                .SetDisplay("Fibroadenoma degenerating")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroadenoma degenerating")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- FibroadenomaDegenerating
                            ,
                            //+ FibrocysticChange
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FibrocysticChange")
                                .SetDisplay("Fibrocystic change")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibrocystic change")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("367647000")
                                .SetSnomedDescription("BodyStructure | Fibrocystic change")
                                .SetICD10("367647000")
                                .SetComment("right/left/bilateral choices")
                            //- AutoGen
                            //- FibrocysticChange
                            ,
                            //+ FibroglandularTissue
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FibroglandularTissue")
                                .SetDisplay("Fibroglandular tissue")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroglandular tissue")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- FibroglandularTissue
                            ,
                            //+ Fibrosis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Fibrosis")
                                .SetDisplay("Fibrosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibrosis")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("???????????")
                            //- AutoGen
                            //- Fibrosis
                            ,
                            //+ FibrousRidge
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FibrousRidge")
                                .SetDisplay("Fibrous ridge")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibrous ridge")
                                )
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            //- FibrousRidge
                            ,
                            //+ Folliculitis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Folliculitis")
                                .SetDisplay("Folliculitis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Folliculitis")
                                )
                                .ValidModalities(Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 13600006 | Folliculitis (Disorder) | [6/113] | L73.9")
                            //- AutoGen
                            //- Folliculitis
                            ,
                            //+ Gynecomastia
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Gynecomastia")
                                .SetDisplay("Gynecomastia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Gynecomastia")
                                )
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            //- Gynecomastia
                            ,
                            //+ Hamartoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Hamartoma")
                                .SetDisplay("Hamartoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Hamartoma")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("51398009")
                                .SetSnomedDescription("BodyStructure | Hamartoma (Morphologic-Abnormality)")
                                .SetICD10("51398009")
                            //- AutoGen
                            //- Hamartoma
                            ,
                            //+ Hematoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Hematoma")
                                .SetDisplay("Hematoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Hematoma")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("302924003")
                                .SetSnomedDescription("ClinicalFinding | Breast hematoma (Disorder) | N64.89")
                                .SetICD10("302924003")
                            //- AutoGen
                            //- Hematoma
                            ,
                            //+ HormonalStimulation
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("HormonalStimulation")
                                .SetDisplay("Hormonal stimulation")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Hormonal stimulation")
                                )
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            //- HormonalStimulation
                            ,
                            //+ IntracysticLesion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("IntracysticLesion")
                                .SetDisplay("Intracystic lesion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Intracystic lesion")
                                )
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            //- IntracysticLesion
                            ,
                            //+ IntramammaryNode
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("IntramammaryNode")
                                .SetDisplay("Intramammary node")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Intramammary node")
                                )
                                .ValidModalities(Modalities.MG | Modalities.NM)
                                .SetSnomedDescription("BodyStructure | 443159006 | Intramammary lymph node group (Bodypart)")
                            //- AutoGen
                            //- IntramammaryNode
                            ,
                            //+ Lipoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Lipoma")
                                .SetDisplay("Lipoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lipoma")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("276891009")
                                .SetSnomedDescription("ClinicalFinding | Lipoma of breast (Disorder)")
                                .SetICD10("276891009")
                            //- AutoGen
                            //- Lipoma
                            ,
                            //+ LumpectomyCavity
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LumpectomyCavity")
                                .SetDisplay("Lumpectomy cavity")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lumpectomy cavity")
                                )
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
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lumpectomy site")
                                )
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
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                            //- AutoGen
                            //- LymphNode
                            ,
                            //+ LymphNodeEnlarged
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LymphNodeEnlarged")
                                .SetDisplay("Lymph node enlarged")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node enlarged")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedCode("274741002")
                                .SetSnomedDescription("ClinicalFinding | Generalized enlarged lymph nodes (Disorder) | [0/0] | R59.1")
                                .SetICD10("274741002")
                            //- AutoGen
                            //- LymphNodeEnlarged
                            ,
                            //+ LymphNodeNormal
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LymphNodeNormal")
                                .SetDisplay("Lymph node normal")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node normal")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- LymphNodeNormal
                            ,
                            //+ LymphNodePathological
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LymphNodePathological")
                                .SetDisplay("Lymph node pathological")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Lymph node pathological")
                                )
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            //- LymphNodePathological
                            ,
                            //+ MassSolid
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MassSolid")
                                .SetDisplay("Mass solid")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mass solid")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- MassSolid
                            ,
                            //+ MassSolidW/tumorVasc
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MassSolidW/tumorVasc")
                                .SetDisplay("Mass solid w/tumor vasc")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mass solid w/tumor vasc")
                                )
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            //- MassSolidW/tumorVasc
                            ,
                            //+ Mastitis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Mastitis")
                                .SetDisplay("Mastitis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mastitis")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 45198002 | Mastitis (Disorder) | [3/51] | P39.0 | Neonatal infective mastitis | N61 | Inflammatory disorders of breast |")
                            //- AutoGen
                            //- Mastitis
                            ,
                            //+ MilkOfCalcium
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MilkOfCalcium")
                                .SetDisplay("Milk of calcium")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Milk of calcium")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetDicom("F-01765")
                                .SetSnomedCode("129753004")
                                .SetSnomedDescription("ClinicalFinding | 129753004 | Milk of calcium radiographic calcification (Finding)")
                                .SetICD10("129753004")
                            //- AutoGen
                            //- MilkOfCalcium
                            ,
                            //+ Multi-focalCancer
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Multi-focalCancer")
                                .SetDisplay("Multi-focal cancer")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Multi-focal cancer")
                                )
                                .ValidModalities(Modalities.NM)
                            //- AutoGen
                            //- Multi-focalCancer
                            ,
                            //+ PapillaryLesion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PapillaryLesion")
                                .SetDisplay("Papillary lesion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Papillary lesion")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedDescription("need help")
                            //- AutoGen
                            //- PapillaryLesion
                            ,
                            //+ Papilloma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Papilloma")
                                .SetDisplay("Papilloma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Papilloma")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("99571000119102")
                                .SetSnomedDescription("ClinicalFinding | Papilloma of breast (Disorder)")
                                .SetICD10("99571000119102")
                                .SetComment("US SM NUMBER")
                            //- AutoGen
                            //- Papilloma
                            ,
                            //+ PhyllodesTumor
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PhyllodesTumor")
                                .SetDisplay("Phyllodes tumor")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Phyllodes tumor")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 712989008 | Phyllodes tumor of breast (Disorder) | D48.6 |")
                            //- AutoGen
                            //- PhyllodesTumor
                            ,
                            //+ PostLumpectomyScar
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PostLumpectomyScar")
                                .SetDisplay("Post lumpectomy scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Post lumpectomy scar")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetOneToMany("???")
                                .SetSnomedDescription("BodyStructure | 63130001 | Surgical scar (Morphologic-Abnormality)")
                            //- AutoGen
                            //- PostLumpectomyScar
                            ,
                            //+ PostSurgicalScar
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PostSurgicalScar")
                                .SetDisplay("Post surgical scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Post surgical scar")
                                )
                                .ValidModalities(Modalities.MG | Modalities.NM)
                                .SetSnomedDescription("BodyStructure | 63130001 | Surgical scar (Morphologic-Abnormality)")
                            //- AutoGen
                            //- PostSurgicalScar
                            ,
                            //+ PreviousBiopsy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PreviousBiopsy")
                                .SetDisplay("Previous biopsy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Previous biopsy")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- PreviousBiopsy
                            ,
                            //+ PreviousSurgery
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PreviousSurgery")
                                .SetDisplay("Previous surgery")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Previous surgery")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- PreviousSurgery
                            ,
                            //+ PreviousTrauma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PreviousTrauma")
                                .SetDisplay("Previous trauma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Previous trauma")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("ClinicalFinding | 62112002 | Injury of breast (Disorder) | [4/41] | S29.9XX?")
                                .SetComment("NEED TO INDICATE PREVIOUS")
                            //- AutoGen
                            //- PreviousTrauma
                            ,
                            //+ RadialScar
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("RadialScar")
                                .SetDisplay("Radial scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Radial scar")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedCode("390787006")
                                .SetSnomedDescription("ClinicalFinding | Radial scar of breast (Finding)")
                                .SetICD10("390787006")
                            //- AutoGen
                            //- RadialScar
                            ,
                            //+ RadiationChanges
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("RadiationChanges")
                                .SetDisplay("Radiation changes")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Radiation changes")
                                )
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("143501000119107")
                                .SetSnomedDescription("SituationWithExplicitContext  | History of radiation therapy to breast area (Situation)")
                                .SetICD10("143501000119107")
                            //- AutoGen
                            //- RadiationChanges
                            ,
                            //+ RadiationTherapy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("RadiationTherapy")
                                .SetDisplay("Radiation therapy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Radiation therapy")
                                )
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("429479009")
                                .SetSnomedDescription("SituationWithExplicitContext | History of radiation therapy (Situation)")
                                .SetICD10("429479009")
                            //- AutoGen
                            //- RadiationTherapy
                            ,
                            //+ Scar
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Scar")
                                .SetDisplay("Scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scar")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- Scar
                            ,
                            //+ ScarWithShadowing
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ScarWithShadowing")
                                .SetDisplay("Scar with shadowing")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Scar with shadowing")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- ScarWithShadowing
                            ,
                            //+ SclerosingAdenosis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SclerosingAdenosis")
                                .SetDisplay("Sclerosing adenosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Sclerosing adenosis")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- SclerosingAdenosis
                            ,
                            //+ SecretoryCalcification
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SecretoryCalcification")
                                .SetDisplay("Secretory calcification")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Secretory calcification")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("??????????????")
                            //- AutoGen
                            //- SecretoryCalcification
                            ,
                            //+ SentinelNode
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SentinelNode")
                                .SetDisplay("Sentinel node")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Sentinel node")
                                )
                                .ValidModalities(Modalities.NM)
                            //- AutoGen
                            //- SentinelNode
                            ,
                            //+ Seroma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Seroma")
                                .SetDisplay("Seroma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Seroma")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("297178008")
                                .SetSnomedDescription("ClinicalFinding | Breast seroma (Disorder)")
                                .SetICD10("297178008")
                            //- AutoGen
                            //- Seroma
                            ,
                            //+ SkinLesion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SkinLesion")
                                .SetDisplay("Skin lesion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Skin lesion")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("126510002")
                                .SetSnomedDescription("ClinicalFinding | Neoplasm of skin of breast (Disorder)")
                                .SetICD10("126510002")
                            //- AutoGen
                            //- SkinLesion
                            ,
                            //+ Surgery
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Surgery")
                                .SetDisplay("Surgery")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgery")
                                )
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            //- Surgery
                            ,
                            //+ Trauma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Trauma")
                                .SetDisplay("Trauma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Trauma")
                                )
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedDescription("ClinicalFinding | 62112002 | Injury of breast (Disorder)")
                                .SetComment("Need help no direct match")
                            //- AutoGen
                            //- Trauma
                            ,
                            //+ VascularCalcifications
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("VascularCalcifications")
                                .SetDisplay("Vascular calcifications")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Vascular calcifications")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("ClinicalFinding | 396779001 | Breast arterial calcification (Finding) | [0/0] | R92.1")
                            //- AutoGen
                            //- VascularCalcifications
                            ,
                            //+ VenousStasis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("VenousStasis")
                                .SetDisplay("Venous stasis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Venous stasis")
                                )
                                .ValidModalities(Modalities.NM)
                                .SetSnomedDescription("ClinicalFinding | 71897006 | Venous stasis (Finding) | [0/0] | I87.8")
                            //- AutoGen
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
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("LikelyRepresents")
                                .SetDisplay("Likely represents")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Likely represents")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetPenCode("Qualifier")
                            //- AutoGen
                            //- LikelyRepresents
                            ,
                            //+ MostLikely
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MostLikely")
                                .SetDisplay("Most likely")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Most likely")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetPenCode("Qualifier")
                            //- AutoGen
                            //- MostLikely
                            ,
                            //+ Resembles
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Resembles")
                                .SetDisplay("Resembles")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Resembles")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetPenCode("Qualifier")
                            //- AutoGen
                            //- Resembles
                            ,
                            //+ w/differentialDiagnosis
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("w/differentialDiagnosis")
                                .SetDisplay("w/differential diagnosis")
                                .SetDefinition(new Definition()
                                    .Line("[PR] w/differential diagnosis")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                                .SetPenCode("Qualifier")
                            //- AutoGen
                            //- w/differentialDiagnosis
                            
                            //- ConsistentWithQualifierCS
                        })
             );
    }
}
