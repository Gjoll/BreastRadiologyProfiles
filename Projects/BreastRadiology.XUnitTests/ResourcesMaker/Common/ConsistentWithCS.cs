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
        const String CodeValue = "value";
        const String CodeQualifier = "qualifier";

        StringTaskVar ConsistentWith = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditor("ConsistentWith",
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
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    ;
                s = e.SDef.Url;
                e.Select("value[x]").Zero();
                e.Select("interpretation").Zero();
                e.Select("referenceRange").Zero();

                ElementDefGroup component = e.GetOrCreate("component");
                component.ElementDefinition.Min = 1;
                component.ElementDefinition.Max = "2";
                e.Select("component.value[x]").Type("CodeableConcept");
                e.Select("component.interpretation").Zero();
                e.Select("component.referenceRange").Zero();

                component.ElementDefinition.Slicing = new ElementDefinition.SlicingComponent
                {
                    Rules = ElementDefinition.SlicingRules.Open
                };

                component.ElementDefinition.Slicing.Discriminator.Add(new ElementDefinition.DiscriminatorComponent
                {
                    Type = ElementDefinition.DiscriminatorType.Pattern,
                    Path = "code"
                });

                CodeSystem csSlice = ResourcesMaker.Self.ConsistentWithSliceCS.Value();
                ValueSet vsSlice = ResourcesMaker.Self.ConsistentWithSliceVS.Value();

                component.ElementDefinition.Binding(vsSlice.Url, BindingStrength.Required);

                void Slice(String sliceName,
                    String code,
                    String valueSetUrl,
                    BindingStrength bindingStrength)
                {
                    ElementDefinition slice = e.AppendSlice("component", sliceName, 1, "1");
                    {
                        ElementDefinition componentCode = new ElementDefinition
                        {
                            Path = $"{slice.Path}.code",
                            ElementId = $"{slice.Path}:{sliceName}.code",
                            Min = 1,
                            Max = "1"
                        };
                        componentCode
                            .Pattern(new CodeableConcept(csSlice.Url, code))
                            ;
                        e.InsertAfterAllChildren("component", componentCode);
                    }
                    {
                        ElementDefinition valueX = new ElementDefinition
                        {
                            Path = $"{slice.Path}.value[x]",
                            ElementId = $"{slice.Path}:{sliceName}.value[x]",
                            Min = 1,
                            Max = "1"
                        };
                        valueX
                            .Binding(valueSetUrl, bindingStrength)
                            ;
                        e.InsertAfterAllChildren("component", valueX);
                    }
                }

                Slice("value", CodeValue, ResourcesMaker.Self.ConsistentWithVS.Value().Url, BindingStrength.Extensible);
                Slice("qualifier", CodeQualifier, ResourcesMaker.Self.ConsistentWithQualifierVS.Value().Url, BindingStrength.Required);

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Mammography Calcification")
                    ;
            });

        CSTaskVar ConsistentWithSliceCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                        "ConsistentWithSliceCS",
                        "ConsistentWith Slice CodeSystem",
                        "ConsistentWithSlice/ValueSet",
                        "ConsistentWithSlice code system",
                        Group_CommonCodes,
                        new ConceptDef[]
                        {
                            new ConceptDef(CodeValue, "Value slice", new Definition().Line("[PR]")),
                            new ConceptDef(CodeQualifier, "qualifier", new Definition().Line("[PR]"))
                        })
             );

        VSTaskVar ConsistentWithSliceVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                        "ConsistentWithSliceVS",
                        "ConsistentWithSlice ValueSet",
                        "ConsistentWithSlice/ValueSet",
                        "ConsistentWithSlice value set.",
                        Group_MGCodes,
                        ResourcesMaker.Self.ConsistentWithSliceCS.Value()
                    )
            );

        VSTaskVar ConsistentWithVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                        "ConsistentWithVS",
                        "ConsistentWith ValueSet",
                        "ConsistentWith/ValueSet",
                        "ConsistentWith value set.",
                        Group_MGCodes,
                        ResourcesMaker.Self.ConsistentWithCS.Value()
                    )
            );

        VSTaskVar ConsistentWithQualifierVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                        "ConsistentWithQualifierVS",
                        "ConsistentWithQualifier ValueSet",
                        "ConsistentWithQualifier/ValueSet",
                        "ConsistentWithQualifier value set.",
                        Group_MGCodes,
                        ResourcesMaker.Self.ConsistentWithQualifierCS.Value()
                    )
            );

        CSTaskVar ConsistentWithCS = new CSTaskVar(
            () =>
                ResourcesMaker.Self.CreateCodeSystem(
                        "ConsistentWithCodeSystemCS",
                        "Consistent With CodeSystem",
                        "ConsistentWith/CodeSystem",
                        "ConsistentWith code system",
                        Group_CommonCodes,
                        new ConceptDef[]
                        {
                            //+ ConsistentWithCS
                            new ConceptDef("Abscess",
                                "Abscess",
                                new Definition()
                                    .Line("[PR] Abscess")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("Angiolipoma",
                                "Angiolipoma",
                                new Definition()
                                    .Line("[PR] Angiolipoma")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("ApocrineMetaplasia",
                                "Apocrine metaplasia",
                                new Definition()
                                    .Line("[PR] Apocrine metaplasia")
                                    .Line("Valid with following Modalities: US")
                                ),
                            new ConceptDef("Artifact",
                                "Artifact",
                                new Definition()
                                    .Line("[PR] Artifact")
                                    .Line("Valid with following Modalities: NM")
                                ),
                            new ConceptDef("AtypicalHyperplasia",
                                "Atypical hyperplasia",
                                new Definition()
                                    .Line("[PR] Atypical hyperplasia")
                                    .Line("Valid with following Modalities: MRI")
                                ),
                            new ConceptDef("AxillaryLymphNode",
                                "Axillary lymph node",
                                new Definition()
                                    .Line("[PR] Axillary lymph node")
                                    .Line("Valid with following Modalities: NM")
                                ),
                            new ConceptDef("Carcinoma",
                                "Carcinoma",
                                new Definition()
                                    .Line("[PR] Carcinoma")
                                    .Line("Valid with following Modalities: MG MRI NM US")
                                ),
                            new ConceptDef("CarcinomaKnown",
                                "Carcinoma known",
                                new Definition()
                                    .Line("[PR] Carcinoma known")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("ClusterOfCysts",
                                "Cluster of cysts",
                                new Definition()
                                    .Line("[PR] Cluster of cysts")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("Cyst",
                                "Cyst",
                                new Definition()
                                    .Line("[PR] Cyst")
                                    .Line("Valid with following Modalities: MG MRI")
                                ),
                            new ConceptDef("CystComplex",
                                "Cyst complex",
                                new Definition()
                                    .Line("[PR] Cyst complex")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("CystComplicated",
                                "Cyst complicated",
                                new Definition()
                                    .Line("[PR] Cyst complicated")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("CystOil",
                                "Cyst oil",
                                new Definition()
                                    .Line("[PR] Cyst oil")
                                    .Line("Valid with following Modalities: MG US")
                                ),
                            new ConceptDef("CystSebaceous",
                                "Cyst sebaceous",
                                new Definition()
                                    .Line("[PR] Cyst sebaceous")
                                    .Line("Valid with following Modalities: US")
                                ),
                            new ConceptDef("CystSimple",
                                "Cyst simple",
                                new Definition()
                                    .Line("[PR] Cyst simple")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("CystsComplex",
                                "Cysts complex",
                                new Definition()
                                    .Line("[PR] Cysts complex")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("CystsComplicated",
                                "Cysts complicated",
                                new Definition()
                                    .Line("[PR] Cysts complicated")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("CystsMicroClustered",
                                "Cysts micro clustered",
                                new Definition()
                                    .Line("[PR] Cysts micro clustered")
                                    .Line("Valid with following Modalities: US")
                                ),
                            new ConceptDef("DCIS",
                                "DCIS",
                                new Definition()
                                    .Line("[PR] DCIS")
                                    .Line("Valid with following Modalities: MG MRI NM US")
                                ),
                            new ConceptDef("Debris",
                                "Debris",
                                new Definition()
                                    .Line("[PR] Debris")
                                    .Line("Valid with following Modalities: MG US")
                                ),
                            new ConceptDef("Deodorant",
                                "Deodorant",
                                new Definition()
                                    .Line("[PR] Deodorant")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("DermalCalcification",
                                "Dermal calcification",
                                new Definition()
                                    .Line("[PR] Dermal calcification")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("DuctEctasia",
                                "Duct ectasia",
                                new Definition()
                                    .Line("[PR] Duct ectasia")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("Edema",
                                "Edema",
                                new Definition()
                                    .Line("[PR] Edema")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("FatLobule",
                                "Fat lobule",
                                new Definition()
                                    .Line("[PR] Fat lobule")
                                    .Line("Valid with following Modalities: US")
                                ),
                            new ConceptDef("FatNecrosis",
                                "Fat necrosis",
                                new Definition()
                                    .Line("[PR] Fat necrosis")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("Fibroadenolipoma",
                                "Fibroadenolipoma",
                                new Definition()
                                    .Line("[PR] Fibroadenolipoma")
                                    .Line("Valid with following Modalities: MG US")
                                ),
                            new ConceptDef("Fibroadenoma",
                                "Fibroadenoma",
                                new Definition()
                                    .Line("[PR] Fibroadenoma")
                                    .Line("Valid with following Modalities: MG MRI NM US")
                                ),
                            new ConceptDef("FibroadenomaDegenerating",
                                "Fibroadenoma degenerating",
                                new Definition()
                                    .Line("[PR] Fibroadenoma degenerating")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("FibrocysticChange",
                                "Fibrocystic change",
                                new Definition()
                                    .Line("[PR] Fibrocystic change")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("FibroglandularTissue",
                                "Fibroglandular tissue",
                                new Definition()
                                    .Line("[PR] Fibroglandular tissue")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("Fibrosis",
                                "Fibrosis",
                                new Definition()
                                    .Line("[PR] Fibrosis")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("FibrousRidge",
                                "Fibrous ridge",
                                new Definition()
                                    .Line("[PR] Fibrous ridge")
                                    .Line("Valid with following Modalities: US")
                                ),
                            new ConceptDef("Folliculitis",
                                "Folliculitis",
                                new Definition()
                                    .Line("[PR] Folliculitis")
                                    .Line("Valid with following Modalities: US")
                                ),
                            new ConceptDef("Gynecomastia",
                                "Gynecomastia",
                                new Definition()
                                    .Line("[PR] Gynecomastia")
                                    .Line("Valid with following Modalities: US")
                                ),
                            new ConceptDef("Hamartoma",
                                "Hamartoma",
                                new Definition()
                                    .Line("[PR] Hamartoma")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("Hematoma",
                                "Hematoma",
                                new Definition()
                                    .Line("[PR] Hematoma")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("HormonalStimulation",
                                "Hormonal stimulation",
                                new Definition()
                                    .Line("[PR] Hormonal stimulation")
                                    .Line("Valid with following Modalities: US")
                                ),
                            new ConceptDef("IntracysticLesion",
                                "Intracystic lesion",
                                new Definition()
                                    .Line("[PR] Intracystic lesion")
                                    .Line("Valid with following Modalities: US")
                                ),
                            new ConceptDef("IntramammaryNode",
                                "Intramammary node",
                                new Definition()
                                    .Line("[PR] Intramammary node")
                                    .Line("Valid with following Modalities: MG NM")
                                ),
                            new ConceptDef("Lipoma",
                                "Lipoma",
                                new Definition()
                                    .Line("[PR] Lipoma")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("LumpectomyCavity",
                                "Lumpectomy cavity",
                                new Definition()
                                    .Line("[PR] Lumpectomy cavity")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("LumpectomySite",
                                "Lumpectomy site",
                                new Definition()
                                    .Line("[PR] Lumpectomy site")
                                    .Line("Valid with following Modalities: MRI")
                                ),
                            new ConceptDef("LymphNode",
                                "Lymph node",
                                new Definition()
                                    .Line("[PR] Lymph node")
                                    .Line("Valid with following Modalities: MG MRI NM US")
                                ),
                            new ConceptDef("LymphNodeEnlarged",
                                "Lymph node enlarged",
                                new Definition()
                                    .Line("[PR] Lymph node enlarged")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("LymphNodeNormal",
                                "Lymph node normal",
                                new Definition()
                                    .Line("[PR] Lymph node normal")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("LymphNodePathological",
                                "Lymph node pathological",
                                new Definition()
                                    .Line("[PR] Lymph node pathological")
                                    .Line("Valid with following Modalities: MRI")
                                ),
                            new ConceptDef("MassSolid",
                                "Mass solid",
                                new Definition()
                                    .Line("[PR] Mass solid")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("MassSolidW/tumorVasc",
                                "Mass solid w/tumor vasc",
                                new Definition()
                                    .Line("[PR] Mass solid w/tumor vasc")
                                    .Line("Valid with following Modalities: MRI")
                                ),
                            new ConceptDef("Mastitis",
                                "Mastitis",
                                new Definition()
                                    .Line("[PR] Mastitis")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("MilkOfCalcium",
                                "Milk of calcium",
                                new Definition()
                                    .Line("[PR] Milk of calcium")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("Multi-focalCancer",
                                "Multi-focal cancer",
                                new Definition()
                                    .Line("[PR] Multi-focal cancer")
                                    .Line("Valid with following Modalities: NM")
                                ),
                            new ConceptDef("PapillaryLesion",
                                "Papillary lesion",
                                new Definition()
                                    .Line("[PR] Papillary lesion")
                                    .Line("Valid with following Modalities: MG US")
                                ),
                            new ConceptDef("Papilloma",
                                "Papilloma",
                                new Definition()
                                    .Line("[PR] Papilloma")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("PhyllodesTumor",
                                "Phyllodes tumor",
                                new Definition()
                                    .Line("[PR] Phyllodes tumor")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("PostLumpectomyScar",
                                "Post lumpectomy scar",
                                new Definition()
                                    .Line("[PR] Post lumpectomy scar")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("PostSurgicalScar",
                                "Post surgical scar",
                                new Definition()
                                    .Line("[PR] Post surgical scar")
                                    .Line("Valid with following Modalities: MG NM")
                                ),
                            new ConceptDef("PreviousBiopsy",
                                "Previous biopsy",
                                new Definition()
                                    .Line("[PR] Previous biopsy")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("PreviousSurgery",
                                "Previous surgery",
                                new Definition()
                                    .Line("[PR] Previous surgery")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("PreviousTrauma",
                                "Previous trauma",
                                new Definition()
                                    .Line("[PR] Previous trauma")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("RadialScar",
                                "Radial scar",
                                new Definition()
                                    .Line("[PR] Radial scar")
                                    .Line("Valid with following Modalities: MG US")
                                ),
                            new ConceptDef("RadiationChanges",
                                "Radiation changes",
                                new Definition()
                                    .Line("[PR] Radiation changes")
                                    .Line("Valid with following Modalities: MRI")
                                ),
                            new ConceptDef("RadiationTherapy",
                                "Radiation therapy",
                                new Definition()
                                    .Line("[PR] Radiation therapy")
                                    .Line("Valid with following Modalities: MRI")
                                ),
                            new ConceptDef("Scar",
                                "Scar",
                                new Definition()
                                    .Line("[PR] Scar")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("ScarWithShadowing",
                                "Scar with shadowing",
                                new Definition()
                                    .Line("[PR] Scar with shadowing")
                                    .Line("Valid with following Modalities: MRI US")
                                ),
                            new ConceptDef("SclerosingAdenosis",
                                "Sclerosing adenosis",
                                new Definition()
                                    .Line("[PR] Sclerosing adenosis")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("SecretoryCalcification",
                                "Secretory calcification",
                                new Definition()
                                    .Line("[PR] Secretory calcification")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("SentinelNode",
                                "Sentinel node",
                                new Definition()
                                    .Line("[PR] Sentinel node")
                                    .Line("Valid with following Modalities: NM")
                                ),
                            new ConceptDef("Seroma",
                                "Seroma",
                                new Definition()
                                    .Line("[PR] Seroma")
                                    .Line("Valid with following Modalities: MG MRI US")
                                ),
                            new ConceptDef("SkinLesion",
                                "Skin lesion",
                                new Definition()
                                    .Line("[PR] Skin lesion")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("Surgery",
                                "Surgery",
                                new Definition()
                                    .Line("[PR] Surgery")
                                    .Line("Valid with following Modalities: MRI")
                                ),
                            new ConceptDef("Trauma",
                                "Trauma",
                                new Definition()
                                    .Line("[PR] Trauma")
                                    .Line("Valid with following Modalities: MRI")
                                ),
                            new ConceptDef("VascularCalcifications",
                                "Vascular calcifications",
                                new Definition()
                                    .Line("[PR] Vascular calcifications")
                                    .Line("Valid with following Modalities: MG")
                                ),
                            new ConceptDef("VenousStasis",
                                "Venous stasis",
                                new Definition()
                                    .Line("[PR] Venous stasis")
                                    .Line("Valid with following Modalities: NM")
                                )
                            //- ConsistentWithCS
                        })
            );


        CSTaskVar ConsistentWithQualifierCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                        "ConsistentWithQualifierCS",
                        "ConsistentWith Qualifier CodeSystem",
                        "ConsistentWithQualifier/ValueSet",
                        "ConsistentWithQualifier  code system",
                        Group_CommonCodes,
                        new ConceptDef[]
                        {
                            //+ ConsistentWithQualifierCS
                            new ConceptDef("LikelyRepresents",
                                "Likely represents",
                                new Definition()
                                    .Line("[PR] Likely represents")
                                    .Line("Valid with following Modalities: MG MRI NM US")
                                ),
                            new ConceptDef("MostLikely",
                                "Most likely",
                                new Definition()
                                    .Line("[PR] Most likely")
                                    .Line("Valid with following Modalities: MG US")
                                ),
                            new ConceptDef("Resembles",
                                "Resembles",
                                new Definition()
                                    .Line("[PR] Resembles")
                                    .Line("Valid with following Modalities: MG MRI NM US")
                                ),
                            new ConceptDef("w/differentialDiagnosis",
                                "w/differential diagnosis",
                                new Definition()
                                    .Line("[PR] w/differential diagnosis")
                                    .Line("Valid with following Modalities: MG MRI NM US")
                                )
                            //- ConsistentWithQualifierCS
                        })
             );
    }
}
