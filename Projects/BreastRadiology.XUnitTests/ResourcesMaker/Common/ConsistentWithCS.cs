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
        StringTaskVar ConsistentWith = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateEditor("ConsistentWith",
                        "Consistent With",
                        "Consistent/With",
                        ObservationUrl,
                        $"{Group_CommonResources}/ConsistentWith")
                    .Description("Breast Radiology 'Consistent With' Observation",
                        new Markdown()
                            .MissingObservation("a consistentWith")
                            .Todo(
                            "There is a CodeSystem and ValueSet created solely to identify the the component slices. Is this appropriate"
                            )
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    ;
                s = e.SDef.Url;
                e.Select("value[x]").Zero();
                e.Select("interpretation").Zero();
                e.Select("referenceRange").Zero();

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("value",
                    Self.ConsistentWithCodeValue.ToCodeableConcept(),
                    Self.ConsistentWithVS.Value().Url,
                    BindingStrength.Extensible,
                    1,
                    "1");
                e.ComponentSliceCodeableConcept("qualifier",
                    Self.ConsistentWithCodeQualifier.ToCodeableConcept(),
                    Self.ConsistentWithQualifierVS.Value().Url,
                    BindingStrength.Required,
                    0,
                    "1");

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Mammography Calcification")
                    ;
            });

        VSTaskVar ConsistentWithVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                        "ConsistentWithVS",
                        "ConsistentWith ValueSet",
                        "ConsistentWith/ValueSet",
                        "ConsistentWith value set.",
                        Group_MGCodesVS,
                        Self.ConsistentWithCS.Value()
                    )
            );

        VSTaskVar ConsistentWithQualifierVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                        "ConsistentWithQualifierVS",
                        "ConsistentWithQualifier ValueSet",
                        "ConsistentWithQualifier/ValueSet",
                        "ConsistentWithQualifier value set.",
                        Group_MGCodesVS,
                        Self.ConsistentWithQualifierCS.Value()
                    )
            );

        CSTaskVar ConsistentWithCS = new CSTaskVar(
            () =>
                Self.CreateCodeSystem(
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
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("Angiolipoma",
                                "Angiolipoma",
                                new Definition()
                                    .Line("[PR] Angiolipoma")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
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
                            new ConceptDef("AxillaryLymphNode",
                                "Axillary lymph node",
                                new Definition()
                                    .Line("[PR] Axillary lymph node")
                                    .ValidModalities(Modalities.NM)
                                ),
                            new ConceptDef("Carcinoma",
                                "Carcinoma",
                                new Definition()
                                    .Line("[PR] Carcinoma")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.NM, Modalities.US)
                                ),
                            new ConceptDef("CarcinomaKnown",
                                "Carcinoma known",
                                new Definition()
                                    .Line("[PR] Carcinoma known")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("ClusterOfCysts",
                                "Cluster of cysts",
                                new Definition()
                                    .Line("[PR] Cluster of cysts")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("Cyst",
                                "Cyst",
                                new Definition()
                                    .Line("[PR] Cyst")
                                    .ValidModalities(Modalities.MG, Modalities.MRI)
                                ),
                            new ConceptDef("CystComplex",
                                "Cyst complex",
                                new Definition()
                                    .Line("[PR] Cyst complex")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("CystComplicated",
                                "Cyst complicated",
                                new Definition()
                                    .Line("[PR] Cyst complicated")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("CystOil",
                                "Cyst oil",
                                new Definition()
                                    .Line("[PR] Cyst oil")
                                    .ValidModalities(Modalities.MG, Modalities.US)
                                ),
                            new ConceptDef("CystSebaceous",
                                "Cyst sebaceous",
                                new Definition()
                                    .Line("[PR] Cyst sebaceous")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("CystSimple",
                                "Cyst simple",
                                new Definition()
                                    .Line("[PR] Cyst simple")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("CystsComplex",
                                "Cysts complex",
                                new Definition()
                                    .Line("[PR] Cysts complex")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("CystsComplicated",
                                "Cysts complicated",
                                new Definition()
                                    .Line("[PR] Cysts complicated")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("CystsMicroClustered",
                                "Cysts micro clustered",
                                new Definition()
                                    .Line("[PR] Cysts micro clustered")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("DCIS",
                                "DCIS",
                                new Definition()
                                    .Line("[PR] DCIS")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.NM, Modalities.US)
                                ),
                            new ConceptDef("Debris",
                                "Debris",
                                new Definition()
                                    .Line("[PR] Debris")
                                    .ValidModalities(Modalities.MG, Modalities.US)
                                ),
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
                            new ConceptDef("DuctEctasia",
                                "Duct ectasia",
                                new Definition()
                                    .Line("[PR] Duct ectasia")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("Edema",
                                "Edema",
                                new Definition()
                                    .Line("[PR] Edema")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("FatLobule",
                                "Fat lobule",
                                new Definition()
                                    .Line("[PR] Fat lobule")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("FatNecrosis",
                                "Fat necrosis",
                                new Definition()
                                    .Line("[PR] Fat necrosis")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("Fibroadenolipoma",
                                "Fibroadenolipoma",
                                new Definition()
                                    .Line("[PR] Fibroadenolipoma")
                                    .ValidModalities(Modalities.MG, Modalities.US)
                                ),
                            new ConceptDef("Fibroadenoma",
                                "Fibroadenoma",
                                new Definition()
                                    .Line("[PR] Fibroadenoma")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.NM, Modalities.US)
                                ),
                            new ConceptDef("FibroadenomaDegenerating",
                                "Fibroadenoma degenerating",
                                new Definition()
                                    .Line("[PR] Fibroadenoma degenerating")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("FibrocysticChange",
                                "Fibrocystic change",
                                new Definition()
                                    .Line("[PR] Fibrocystic change")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("FibroglandularTissue",
                                "Fibroglandular tissue",
                                new Definition()
                                    .Line("[PR] Fibroglandular tissue")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("Fibrosis",
                                "Fibrosis",
                                new Definition()
                                    .Line("[PR] Fibrosis")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("FibrousRidge",
                                "Fibrous ridge",
                                new Definition()
                                    .Line("[PR] Fibrous ridge")
                                    .ValidModalities(Modalities.US)
                                ),
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
                            new ConceptDef("Hamartoma",
                                "Hamartoma",
                                new Definition()
                                    .Line("[PR] Hamartoma")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("Hematoma",
                                "Hematoma",
                                new Definition()
                                    .Line("[PR] Hematoma")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
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
                            new ConceptDef("IntramammaryNode",
                                "Intramammary node",
                                new Definition()
                                    .Line("[PR] Intramammary node")
                                    .ValidModalities(Modalities.MG, Modalities.NM)
                                ),
                            new ConceptDef("Lipoma",
                                "Lipoma",
                                new Definition()
                                    .Line("[PR] Lipoma")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("LumpectomyCavity",
                                "Lumpectomy cavity",
                                new Definition()
                                    .Line("[PR] Lumpectomy cavity")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
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
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.NM, Modalities.US)
                                ),
                            new ConceptDef("LymphNodeEnlarged",
                                "Lymph node enlarged",
                                new Definition()
                                    .Line("[PR] Lymph node enlarged")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("LymphNodeNormal",
                                "Lymph node normal",
                                new Definition()
                                    .Line("[PR] Lymph node normal")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
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
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("MassSolidW/tumorVasc",
                                "Mass solid w/tumor vasc",
                                new Definition()
                                    .Line("[PR] Mass solid w/tumor vasc")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            new ConceptDef("Mastitis",
                                "Mastitis",
                                new Definition()
                                    .Line("[PR] Mastitis")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
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
                            new ConceptDef("PapillaryLesion",
                                "Papillary lesion",
                                new Definition()
                                    .Line("[PR] Papillary lesion")
                                    .ValidModalities(Modalities.MG, Modalities.US)
                                ),
                            new ConceptDef("Papilloma",
                                "Papilloma",
                                new Definition()
                                    .Line("[PR] Papilloma")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("PhyllodesTumor",
                                "Phyllodes tumor",
                                new Definition()
                                    .Line("[PR] Phyllodes tumor")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("PostLumpectomyScar",
                                "Post lumpectomy scar",
                                new Definition()
                                    .Line("[PR] Post lumpectomy scar")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("PostSurgicalScar",
                                "Post surgical scar",
                                new Definition()
                                    .Line("[PR] Post surgical scar")
                                    .ValidModalities(Modalities.MG, Modalities.NM)
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
                            new ConceptDef("PreviousTrauma",
                                "Previous trauma",
                                new Definition()
                                    .Line("[PR] Previous trauma")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("RadialScar",
                                "Radial scar",
                                new Definition()
                                    .Line("[PR] Radial scar")
                                    .ValidModalities(Modalities.MG, Modalities.US)
                                ),
                            new ConceptDef("RadiationChanges",
                                "Radiation changes",
                                new Definition()
                                    .Line("[PR] Radiation changes")
                                    .ValidModalities(Modalities.MRI)
                                ),
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
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("ScarWithShadowing",
                                "Scar with shadowing",
                                new Definition()
                                    .Line("[PR] Scar with shadowing")
                                    .ValidModalities(Modalities.MRI, Modalities.US)
                                ),
                            new ConceptDef("SclerosingAdenosis",
                                "Sclerosing adenosis",
                                new Definition()
                                    .Line("[PR] Sclerosing adenosis")
                                    .ValidModalities(Modalities.MG)
                                ),
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
                            new ConceptDef("Seroma",
                                "Seroma",
                                new Definition()
                                    .Line("[PR] Seroma")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.US)
                                ),
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
                            new ConceptDef("Trauma",
                                "Trauma",
                                new Definition()
                                    .Line("[PR] Trauma")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            new ConceptDef("VascularCalcifications",
                                "Vascular calcifications",
                                new Definition()
                                    .Line("[PR] Vascular calcifications")
                                    .ValidModalities(Modalities.MG)
                                ),
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
             () =>
                 Self.CreateCodeSystem(
                        "ConsistentWithQualifierCS",
                        "ConsistentWith Qualifier CodeSystem",
                        "ConsistentWithQualifier/ValueSet",
                        "ConsistentWithQualifier  code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            //+ ConsistentWithQualifierCS
                            new ConceptDef("LikelyRepresents",
                                "Likely represents",
                                new Definition()
                                    .Line("[PR] Likely represents")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.NM, Modalities.US)
                                ),
                            new ConceptDef("MostLikely",
                                "Most likely",
                                new Definition()
                                    .Line("[PR] Most likely")
                                    .ValidModalities(Modalities.MG, Modalities.US)
                                ),
                            new ConceptDef("Resembles",
                                "Resembles",
                                new Definition()
                                    .Line("[PR] Resembles")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.NM, Modalities.US)
                                ),
                            new ConceptDef("w/differentialDiagnosis",
                                "w/differential diagnosis",
                                new Definition()
                                    .Line("[PR] w/differential diagnosis")
                                    .ValidModalities(Modalities.MG, Modalities.MRI, Modalities.NM, Modalities.US)
                                )
                            //- ConsistentWithQualifierCS
                        })
             );
    }
}
