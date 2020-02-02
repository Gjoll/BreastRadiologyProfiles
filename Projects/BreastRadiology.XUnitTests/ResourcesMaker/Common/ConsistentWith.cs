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
                                .SetDefinition("[PR] Abscess")
                                .MammoId("104")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
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
                                .SetSnomedDescription("ClinicalFinding | 37009001 | Apocrine metaplasia of breast (Disorder) | [0/0] | N60.89")
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
                                .SetSnomedDescription("BodyStructure | 245269009 | Axillary lymph node group (Bodypart)")
                            //- AutoGen
                            //- AxillaryLymphNode
                            ,
                            //+ Carcinoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Carcinoma")
                                .SetDisplay("Carcinoma")
                                .SetDefinition("[PR] Carcinoma")
                                .MammoId("504")
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
                                .SetDefinition("[PR] Carcinoma known")
                                .MammoId("510")
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
                                .SetDefinition("[PR] Cluster of cysts")
                                .MammoId("577")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("399294002")
                                .SetOneToMany("one")
                                .SetSnomedDescription("ClinicalFinding |Cyst of breast (Disorder) ++++++")
                                .SetICD10("N60.09")
                                .SetComment("BodyStructure | 125291005 | Multiple cysts (Morphologic-Abnormality")
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
                                .SetSnomedDescription("ClinicalFinding | Sebaceous cyst of skin of breast (Disorder)")
                                .SetICD10("N60.89")
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
                                .SetSnomedDescription("BodyStructure | 399935008 | Ductal carcinoma in situ - category (Morphologic-Abnormality)")
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
                                .SetSnomedDescription("ClinicalFinding | 22049009 | Mammary duct ectasia (Disorder) | [0/0] | N60.49")
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
                                .SetSnomedDescription("ClinicalFinding | 13600006 | Folliculitis (Disorder) | [6/113] | L73.9")
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
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            //- IntracysticLesion
                            ,
                            //+ IntramammaryNode
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("IntramammaryNode")
                                .SetDisplay("Intramammary node")
                                .SetDefinition("[PR] Intramammary node")
                                .MammoId("566.941")
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
                                .SetDefinition("[PR] Lipoma")
                                .MammoId("508")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("276891009")
                                .SetSnomedDescription("ClinicalFinding | Lipoma of breast (Disorder)")
                                .SetICD10("D17.39")
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
                                .SetSnomedDescription("ClinicalFinding | Generalized enlarged lymph nodes (Disorder) | [0/0] | R59.1")
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
                                .SetSnomedDescription("ClinicalFinding | 45198002 | Mastitis (Disorder) | [3/51] | P39.0 | Neonatal infective mastitis | N61 | Inflammatory disorders of breast |")
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
                                .SetSnomedDescription("ClinicalFinding | 129753004 | Milk of calcium radiographic calcification (Finding)")
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
                                .SetSnomedDescription("ClinicalFinding | 712989008 | Phyllodes tumor of breast (Disorder) | D48.6 |")
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
                                .SetDefinition("[PR] Radial scar")
                                .MammoId("568")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetSnomedCode("390787006")
                                .SetSnomedDescription("ClinicalFinding | Radial scar of breast (Finding)")
                                .SetICD10("N64.89")
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
                                .SetSnomedDescription("SituationWithExplicitContext  | History of radiation therapy to breast area (Situation)")
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
                                .SetSnomedDescription("SituationWithExplicitContext | History of radiation therapy (Situation)")
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
                                .SetSnomedDescription("ClinicalFinding | 396779001 | Breast arterial calcification (Finding) | [0/0] | R92.1")
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
                            
                            //- ConsistentWithQualifierCS
                        })
             );
    }
}
