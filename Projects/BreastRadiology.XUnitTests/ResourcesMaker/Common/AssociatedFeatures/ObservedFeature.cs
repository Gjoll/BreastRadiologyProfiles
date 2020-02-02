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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        CSTaskVar ObservedFeatureCS = new CSTaskVar(
             (out CodeSystem vs) =>
                 vs = Self.CreateCodeSystem(
                         "ObservedFeatureCS",
                         "Observed Feature CodeSystem",
                         "ObservedFeature/CodeSystem",
                         "Observed Feature seen during a breast examination.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                            //+ ObservedFeatureCS
                            //+ AxillaryAdenopathy
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("AxillaryAdenopathy")
                                .SetDisplay("Axillary adenopathy")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Axillary adenopathy")
                                    .MammoId("239")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI)
                            //- AutoGen
                                .SetDefinition(new Definition()
                                    .Line("Axillary adenopathy")
                                    .CiteStart(BiRadCitation)
                                    .Text("Enlarged axillary lymph nodes may warrant comment, clinical correlation, and additional ")
                                    .Text("evaluation, especially if new or considerably larger or rounder when compared to previous examination.")
                                    .Text("A review of the patient's medical history may elucidate the cause for axillary adenopathy, averting")
                                    .Text("recommendation for additional evaluation. When one or more large axillary nodes are ")
                                    .Text("substantially composed of fat, this is a normal variant.")
                                    .CiteEnd()
                                ),
                            //- AxillaryAdenopathy
                            //+ BiopsyClip
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BiopsyClip")
                                .SetDisplay("Biopsy clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Biopsy clip")
                                    .MammoId("263")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetOneToMany("one")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                            //- AutoGen
                            ,
                            //- BiopsyClip
                            //+ BiopsyClips
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BiopsyClips")
                                .SetDisplay("Biopsy clips")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Biopsy clips")
                                    .MammoId("264")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetOneToMany("many")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                            //- AutoGen
                            ,
                            //- BiopsyClips
                            //+ BrachytherapyTube
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BrachytherapyTube")
                                .SetDisplay("Brachytherapy tube")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Brachytherapy tube")
                                    .MammoId("475")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetComment("MANY Brachytherapy")
                            //- AutoGen
                            ,
                            //- BrachytherapyTube
                            //+ ChestWallInvasion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ChestWallInvasion")
                                .SetDisplay("Chest wall invasion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Chest wall invasion")
                                    .MammoId("255")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("NO FIND")
                            //- AutoGen
                            ,
                            //- ChestWallInvasion
                            //+ CooperDistorted
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CooperDistorted")
                                .SetDisplay("Cooper distorted")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cooper distorted")
                                    .MammoId("261")
                                )
                                .ValidModalities(Modalities.US)
                                .SetUMLS("C1268682")
                            //- AutoGen
                            ,
                            //- CooperDistorted
                            //+ CooperThickened
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CooperThickened")
                                .SetDisplay("Cooper thickened")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Cooper thickened")
                                    .MammoId("262")
                                )
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            ,
                            //- CooperThickened
                            //+ Edema
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Edema")
                                .SetDisplay("Edema")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Edema")
                                    .MammoId("258")
                                )
                                .ValidModalities(Modalities.US)
                                .SetSnomedCode("290077003")
                                .SetSnomedDescription("ClinicalFinding | Edema of breast (Finding)")
                                .SetICD10("R60.0")
                            //- AutoGen
                            ,
                            //- Edema
                            //+ EdemaAdj
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("EdemaAdj")
                                .SetDisplay("Edema adj")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Edema adj")
                                    .MammoId("259")
                                )
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            ,
                            //- EdemaAdj
                            //+ GoldSeed
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("GoldSeed")
                                .SetDisplay("Gold Seed")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Gold Seed")
                                    .MammoId("238")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                                .SetComment("no gold seed SM")
                            //- AutoGen
                            ,
                            //- GoldSeed
                            //+ Hematoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Hematoma")
                                .SetDisplay("Hematoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Hematoma")
                                    .MammoId("478")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("302924003")
                                .SetSnomedDescription("ClinicalFinding | Breast hematoma (Disorder) | N64.89")
                            //- AutoGen
                            ,
                            //- Hematoma
                            //+ NippleRetraction
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NippleRetraction")
                                .SetDisplay("Nipple retraction")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Nipple retraction")
                                    .MammoId("477")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI)
                                .SetSnomedCode("31845005")
                                .SetSnomedDescription("ClinicalFinding | Retraction of nipple (Disorder) | [2/9] | N64.53")
                                .SetComment("ClinicalFinding | 254239000 | Congenital retraction of nipple (Disorder) | [0/0] | Q83.8")
                            //- AutoGen
                                .SetDefinition(new Definition()
                                    .Line("Nipple retraction")
                                    .CiteStart(BiRadCitation)
                                    .Text("The nipple is pulled in. This should not be confused with nipple inversion, which is often bilateral ")
                                    .Text("and which in the absence of any suspicious findings and when stable for a long period of time, ")
                                    .Text("is not a sign of malignancy. However, if nipple retraction is new, suspicion for underlying malignancy is increased.")
                                    .CiteEnd()
                                )
                            ,
                            //- NippleRetraction
                            //+ NOChestWallInvasion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NOChestWallInvasion")
                                .SetDisplay("NO Chest wall invasion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] NO Chest wall invasion")
                                    .MammoId("257")
                                )
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            ,
                            //- NOChestWallInvasion
                            //+ PectoralisMuscleInvasion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PectoralisMuscleInvasion")
                                .SetDisplay("Pectoralis muscle invasion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Pectoralis muscle invasion")
                                    .MammoId("254")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("choices with muscle + invasion")
                            //- AutoGen
                            ,
                            //- PectoralisMuscleInvasion
                            //+ PectoralisMuscleInvolvement
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PectoralisMuscleInvolvement")
                                .SetDisplay("Pectoralis muscle involvement")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Pectoralis muscle involvement")
                                    .MammoId("256")
                                )
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedDescription("choices with muscle + invasion")
                            //- AutoGen
                            ,
                            //- PectoralisMuscleInvolvement
                            //+ PectoralisMuscleTenting
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PectoralisMuscleTenting")
                                .SetDisplay("Pectoralis muscle tenting")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Pectoralis muscle tenting")
                                    .MammoId("253")
                                )
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("NO FIND")
                            //- AutoGen
                            ,
                            //- PectoralisMuscleTenting
                            //+ PostSurgicalScar
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PostSurgicalScar")
                                .SetDisplay("Post surgical scar")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Post surgical scar")
                                    .MammoId("479")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("442523003")
                                .SetSnomedDescription("ClinicalFinding | Surgical scar finding (Finding) | [2/7] | L90.5 |")
                            //- AutoGen
                            ,
                            //- PostSurgicalScar
                            //+ Seroma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Seroma")
                                .SetDisplay("Seroma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Seroma")
                                    .MammoId("469")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("297178008")
                                .SetSnomedDescription("ClinicalFinding | Breast seroma (Disorder)")
                                .SetICD10("N64.89")
                            //- AutoGen
                            ,
                            //- Seroma
                            //+ SkinInvolvement
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SkinInvolvement")
                                .SetDisplay("Skin involvement")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Skin involvement")
                                    .MammoId("252")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            ,
                            //- SkinInvolvement
                            //+ SkinLesion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SkinLesion")
                                .SetDisplay("Skin lesion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Skin lesion")
                                    .MammoId("473")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("126510002")
                                .SetSnomedDescription("ClinicalFinding | Neoplasm of skin of breast (Disorder)")
                                .SetICD10("D49.2")
                            //- AutoGen
                                .SetDefinition(new Definition()
                                    .Line("Skin lesion")
                                    .CiteStart(BiRadCitation)
                                    .Text("This finding may be described in the mammography report or annotated on the mammographic")
                                    .Text("image when it projects over the breast (especially on 2 different projections), and may be mistaken")
                                    .Text("for an intramammary lesion. A raised skin lesion sufficiently large to be seen at mammography")
                                    .Text("should be marked by the technologist with a radiopaque device designated for use as a marker for")
                                    .Text("a skin lesion.")
                                    .CiteEnd()
                                )
                            ,
                            //- SkinLesion
                            //+ SkinRetraction
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SkinRetraction")
                                .SetDisplay("Skin retraction")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Skin retraction")
                                    .MammoId("251")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 129796009 | Mammographic skin retraction of breast (Finding) | [0/0] | N64.5")
                            //- AutoGen
                            ,
                            //- SkinRetraction
                            //+ SkinThickening
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SkinThickening")
                                .SetDisplay("Skin thickening")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Skin thickening")
                                    .MammoId("250")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 129797000 | Mammographic skin thickening of breast (Finding) | [0/0] | R92")
                                .SetComment("450848006??")
                            //- AutoGen
                                .SetDefinition(new Definition()
                                    .Line("Skin thickening")
                                    .CiteStart(BiRadCitation)
                                    .Text("Skin thickening may be focal or diffuse, and is defined as being greater than 2 mm in thickness. This ")
                                    .Text("finding is of particular concern if it represents a change from previous mammography examinations. ")
                                    .Text("However, unilateral skin thickening is an expected finding after radiation therapy.")
                                    .CiteEnd()
                                )
                            ,
                            //- SkinThickening
                            //+ SurgicalClip
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalClip")
                                .SetDisplay("Surgical clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical clip")
                                    .MammoId("485")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("470342004")
                                .SetOneToMany("one")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                            //- AutoGen
                            ,
                            //- SurgicalClip
                            //+ SurgicalClips
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalClips")
                                .SetDisplay("Surgical clips")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical clips")
                                    .MammoId("486")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("470342004")
                                .SetOneToMany("many")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                            //- AutoGen
                            ,
                            //- SurgicalClips
                            //+ TrabecularThickening
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("TrabecularThickening")
                                .SetDisplay("Trabecular thickening")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Trabecular thickening")
                                    .MammoId("470")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("129795008")
                                .SetSnomedDescription("ClinicalFinding | Mammographic trabecular thickening of breast (Finding)")
                                .SetICD10("N64.5")
                                .SetComment("only mammo chioce")
                            //- AutoGen
                                .SetDefinition(new Definition()
                                    .Line("Trabecular thickening")
                                    .CiteStart(BiRadCitation)
                                    .Text("This is a thickening of the fibrous septa of the breast.")
                                    .CiteEnd()
                                )
                            //- TrabecularThickening
                            //- ObservedFeatureCS
                         })
             );


        VSTaskVar ObservedFeatureVS = new VSTaskVar(
            (out ValueSet vs) =>
            {
                vs = Self.CreateValueSet(
                        "ObservedFeatureVS",
                        "Observed Feature ValueSet",
                        "Observed Feature/ValueSet",
                        "Observed feature observed during a Breast Radiology exam value set",
                        Group_CommonCodesVS,
                        Self.ObservedFeatureCS.Value());

                IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(vs);
                valueSetIntroDoc
                    .ReviewedStatus("NOONE", "")
                ;
                String outputPath = valueSetIntroDoc.Save();
                Self.fc?.Mark(outputPath);
            }
            );

        SDTaskVar ObservedFeature = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.ObservedFeatureVS.Value();

                SDefEditor e = Self.CreateEditor("ObservedFeature",
                    "Observed Feature",
                    "Observed Feature",
                    Global.ObservationUrl,
                    $"{Group_CommonResources}/AssociatedFeature/ObservedFeature",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
                    .Description("Observed Feature Observation",
                        new Markdown()
                            .Paragraph("The feature observed is defined by the codeable concept in the value[x] field.")
                    )
                    ;
                s = e.SDef;
                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeObservedFeature.ToCodeableConcept());

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("featureType",
                    Self.ComponentSliceCodeObservedFeatureType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "Observed Feature Type",
                    new Markdown()
                        .Paragraph($"This slice contains the required component that defines the observed feature.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
            });
    }
}
