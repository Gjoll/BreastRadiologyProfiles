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
                                .SetDefinition("[PR] Axillary adenopathy")
                                .MammoId("239")
                                .ValidModalities(Modalities.MG | Modalities.MRI)
                                .SetUMLS("Axillary lymphadenopathy is a condition in which " +
                                    "the lymph nodes of the axillary region — commonly " +
                                    "known as the armpit — are enlarged. The condition " +
                                    "can be diagnosed on the basis of a physical exam " +
                                    "or imaging studies.")
                            //- AutoGen
                            .BiRadsDef(
                                "Enlarged axillary lymph nodes may warrant comment, clinical correlation, and additional ",
                                "evaluation, especially if new or considerably larger or rounder when compared to previous examination.",
                                "A review of the patient's medical history may elucidate the cause for axillary adenopathy, averting",
                                "recommendation for additional evaluation. When one or more large axillary nodes are ",
                                "substantially composed of fat, this is a normal variant.")
                             ,
                            //- AxillaryAdenopathy
                            //+ BiopsyClip
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BiopsyClip")
                                .SetDisplay("Biopsy clip")
                                .SetDefinition("[PR] Biopsy clip")
                                .MammoId("471.263")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetOneToMany("one")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("The biopsy clip serves as a marker documenting where " +
                                    "the tissue was sampled in the breast. If the original " +
                                    "abnormality is no longer visible by imaging after " +
                                    "the biopsy, the marker is the only guide we have " +
                                    "to know where the diseased tissue was sampled.")
                            //- AutoGen
                            ,
                            //- BiopsyClip
                            //+ BiopsyClips
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BiopsyClips")
                                .SetDisplay("Biopsy clips")
                                .SetDefinition("[PR] Biopsy clips")
                                .MammoId("472.264")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetOneToMany("many")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("Tissue marker placement after image-guided breast " +
                                    "biopsy has become a routine component of clinical " +
                                    "practice. Marker placement distinguishes multiple " +
                                    "biopsied lesions within the same breast, prevents " +
                                    "re-biopsy of benign lesions, enables multi-modality " +
                                    "correlation, guides pre-operative localization and " +
                                    "helps confirm surgical target removal. Numerous breast " +
                                    "tissue markers are currently available, with varied " +
                                    "shapes, composition, and associated bio-absorbable " +
                                    "components. This review serves to familiarize the " +
                                    "breast interventionalist with the tissue markers " +
                                    "most widely available in the United States today " +
                                    "and to provide guidance regarding selection of appropriate " +
                                    "markers for various clinical settings.")
                            //- AutoGen
                            ,
                            //- BiopsyClips
                            //+ BrachytherapyTube
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BrachytherapyTube")
                                .SetDisplay("Brachytherapy tube")
                                .SetDefinition("[PR] Brachytherapy tube")
                                .MammoId("475")
                                .ValidModalities(Modalities.MG)
                                .SetComment("MANY Brachytherapy")
                                .SetUMLS("Brachytherapy (brak-e-THER-uh-pee) is a procedure " +
                                    "that involves placing radioactive material inside " +
                                    "your body.Brachytherapy is one type of radiation " +
                                    "therapy that's used to treat cancer. Brachytherapy " +
                                    "is sometimes called internal radiation.Brachytherapy " +
                                    "allows doctors to deliver higher doses of radiation " +
                                    "to more-specific areas of the body, compared with " +
                                    "the conventional form of radiation therapy (external " +
                                    "beam radiation) that projects radiation from a machine " +
                                    "outside of your body.")
                            //- AutoGen
                            ,
                            //- BrachytherapyTube
                            //+ ChestWallInvasion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ChestWallInvasion")
                                .SetDisplay("Chest wall invasion")
                                .SetDefinition("[PR] Chest wall invasion")
                                .MammoId("255")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("NO FIND")
                                .SetUMLS("A tumor of the lung that has invaded the chest wall.")
                            //- AutoGen
                            ,
                            //- ChestWallInvasion
                            //+ CooperDistorted
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CooperDistorted")
                                .SetDisplay("Cooper distorted")
                                .SetDefinition("[PR] Cooper distorted")
                                .MammoId("261")
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
                                .SetDefinition("[PR] Cooper thickened")
                                .MammoId("262")
                                .ValidModalities(Modalities.US)
                                .SetUMLS("The cooper's ligaments are fibrous bands extending " +
                                    "vertically from surface attach on chest wall muscles. " +
                                    "These ligaments maintain the shape and structure " +
                                    "of your breasts and help to prevent sagging. Cooper’s " +
                                    "ligaments support the breasts on the chest wall, " +
                                    "maintain their contour, and keep them in position.These " +
                                    "support breast tissue; they become contracted in " +
                                    "cancer of breast, producing dimples in overlying " +
                                    "skin. Thickening occurs when there are skin changes " +
                                    "usually associated with the presence of a mass, benign " +
                                    "or malignant, that causes shortening in the Coopers " +
                                    "ligenments due to fibrosis.")
                            //- AutoGen
                            ,
                            //- CooperThickened
                            //+ Edema
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Edema")
                                .SetDisplay("Edema")
                                .SetDefinition("[PR] Edema")
                                .MammoId("258")
                                .ValidModalities(Modalities.US)
                                .SetSnomedCode("290077003")
                                .SetSnomedDescription("ClinicalFinding | Edema of breast (Finding)")
                                .SetICD10("R60.0")
                                .SetUMLS("Edema may be due to blockage of subdermal lymphatics " +
                                    "by tumor cells or an inflammatory process within " +
                                    "the breast or axilla.")
                            //- AutoGen
                            ,
                            //- Edema
                            //+ EdemaAdj
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("EdemaAdj")
                                .SetDisplay("Edema adj")
                                .SetDefinition("[PR] Edema adj")
                                .MammoId("259")
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            ,
                            //- EdemaAdj
                            //+ GoldSeed
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("GoldSeed")
                                .SetDisplay("Gold Seed")
                                .SetDefinition("[PR] Gold Seed")
                                .MammoId("238")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetComment("no gold seed SM")
                            //- AutoGen
                            ,
                            //- GoldSeed
                            //+ Hematoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Hematoma")
                                .SetDisplay("Hematoma")
                                .SetDefinition("[PR] Hematoma")
                                .MammoId("478")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("302924003")
                                .SetSnomedDescription("ClinicalFinding | Breast hematoma (Disorder) | N64.89")
                                .SetUMLS("A hematoma (US spelling)  is a localized bleeding " +
                                    "outside of blood vessels, due to either disease or " +
                                    "trauma including injury or surgery and may involve " +
                                    "blood continuing to seep from broken capillaries.")
                            //- AutoGen
                            ,
                            //- Hematoma
                            //+ NippleRetraction
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NippleRetraction")
                                .SetDisplay("Nipple retraction")
                                .SetDefinition("[PR] Nipple retraction")
                                .MammoId("477")
                                .ValidModalities(Modalities.MG | Modalities.MRI)
                                .SetSnomedCode("31845005")
                                .SetSnomedDescription("ClinicalFinding | Retraction of nipple (Disorder) " +
                                    "| [2/9] | N64.53")
                                .SetComment("ClinicalFinding | 254239000 | Congenital retraction " +
                                    "of nipple (Disorder) | [0/0] | Q83.8")
                                .SetUMLS("Retracted nipples lie flat against the areola. The " +
                                    "condition can be the result of inflammation or scarring " +
                                    "of the tissue behind the nipple, and caused by numerous " +
                                    "conditions, not just cancer. ... In the case of breast " +
                                    "cancer, nipple retraction occurs when the tumor attacks " +
                                    "the duct behind the nipple, pulling it in.")
                            //- AutoGen
                            .BiRadsDef(
                                "The nipple is pulled in. This should not be confused with nipple inversion, which is often bilateral ",
                                "and which in the absence of any suspicious findings and when stable for a long period of time, ",
                                "is not a sign of malignancy. However, if nipple retraction is new, suspicion for underlying malignancy is increased.")
                            ,
                            //- NippleRetraction
                            //+ NOChestWallInvasion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NOChestWallInvasion")
                                .SetDisplay("NO Chest wall invasion")
                                .SetDefinition("[PR] NO Chest wall invasion")
                                .MammoId("257")
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            ,
                            //- NOChestWallInvasion
                            //+ PectoralisMuscleInvasion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PectoralisMuscleInvasion")
                                .SetDisplay("Pectoralis muscle invasion")
                                .SetDefinition("[PR] Pectoralis muscle invasion")
                                .MammoId("254")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("choices with muscle + invasion")
                                .SetUMLS("Pectoralis muscle invasion is when a tumor has become " +
                                    "large enough to invade into the pectoralis muscle.")
                            //- AutoGen
                            ,
                            //- PectoralisMuscleInvasion
                            //+ PectoralisMuscleInvolvement
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("PectoralisMuscleInvolvement")
                                .SetDisplay("Pectoralis muscle involvement")
                                .SetDefinition("[PR] Pectoralis muscle involvement")
                                .MammoId("256")
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
                                .SetDefinition("[PR] Pectoralis muscle tenting")
                                .MammoId("253")
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
                                .SetDefinition("[PR] Post surgical scar")
                                .MammoId("479")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("442523003")
                                .SetSnomedDescription("ClinicalFinding | Surgical scar finding (Finding) " +
                                    "| [2/7] | L90.5 |")
                                .SetUMLS("Post surgical scarring happens because of the incisions " +
                                    "needed to surgically remove tumor, cells, etc. The " +
                                    "amount of scarring is connected to the different " +
                                    "stages of wound healing. Surgical scar care should " +
                                    "be continued for a year.")
                            //- AutoGen
                            ,
                            //- PostSurgicalScar
                            //+ Seroma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Seroma")
                                .SetDisplay("Seroma")
                                .SetDefinition("[PR] Seroma")
                                .MammoId("469")
                                .ValidModalities(Modalities.MG)
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
                            ,
                            //- Seroma
                            //+ SkinInvolvement
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SkinInvolvement")
                                .SetDisplay("Skin involvement")
                                .SetDefinition("[PR] Skin involvement")
                                .MammoId("252")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            ,
                            //- SkinInvolvement
                            //+ SkinLesion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SkinLesion")
                                .SetDisplay("Skin lesion")
                                .SetDefinition("[PR] Skin lesion")
                                .MammoId("473")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("126510002")
                                .SetSnomedDescription("ClinicalFinding | Neoplasm of skin of breast (Disorder)")
                                .SetICD10("D49.2")
                                .SetUMLS("A skin lesion is a part of the skin that has an abnormal " +
                                    "growth or appearance compared to the skin around " +
                                    "it.In order to diagnose a skin lesion, a dermatologist " +
                                    "or doctor will conduct a full physical exam.")
                            //- AutoGen
                            .BiRadsDef(
                                "This finding may be described in the mammography report or annotated on the mammographic",
                                "image when it projects over the breast (especially on 2 different projections), and may be mistaken",
                                "for an intramammary lesion. A raised skin lesion sufficiently large to be seen at mammography",
                                "should be marked by the technologist with a radiopaque device designated for use as a marker for",
                                "a skin lesion.")
                            ,
                            //- SkinLesion
                            //+ SkinRetraction
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SkinRetraction")
                                .SetDisplay("Skin retraction")
                                .SetDefinition("[PR] Skin retraction")
                                .MammoId("251")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 129796009 | Mammographic skin retraction " +
                                    "of breast (Finding) | [0/0] | N64.5")
                                .SetUMLS("Skin retraction (or inversion) or Skin retraction. " +
                                    "Breast cancers that are located near the skin or " +
                                    "nipple may cause scarring within the breast that " +
                                    "pulls at the nipple or nearby skin. Skin and nipple " +
                                    "retraction are more obvious when a woman raises her " +
                                    "arms above her head or leans forward.")
                            //- AutoGen
                            ,
                            //- SkinRetraction
                            //+ SkinThickening
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SkinThickening")
                                .SetDisplay("Skin thickening")
                                .SetDefinition("[PR] Skin thickening")
                                .MammoId("250")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 129797000 | Mammographic skin thickening " +
                                    "of breast (Finding) | [0/0] | R92")
                                .SetComment("450848006??")
                            //- AutoGen
                            .BiRadsDef(
                                "Skin thickening may be focal or diffuse, and is defined as being greater than 2 mm in thickness. This ",
                                "finding is of particular concern if it represents a change from previous mammography examinations. ",
                                "However, unilateral skin thickening is an expected finding after radiation therapy.")
                            ,
                            //- SkinThickening
                            //+ SurgicalClip
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalClip")
                                .SetDisplay("Surgical clip")
                                .SetDefinition("[PR] Surgical clip")
                                .MammoId("485")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("470342004")
                                .SetOneToMany("one")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                                .SetUMLS("Most surgical clips are currently made of titanium, " +
                                    "and as many as 30 to 40 clips may be used during " +
                                    "a single surgical procedure. They remain inside the " +
                                    "patient's body after the wounds are healed.")
                            //- AutoGen
                            ,
                            //- SurgicalClip
                            //+ SurgicalClips
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalClips")
                                .SetDisplay("Surgical clips")
                                .SetDefinition("[PR] Surgical clips")
                                .MammoId("486")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("470342004")
                                .SetOneToMany("many")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                                .SetUMLS("A series of surgical staples or clips are used during " +
                                    "surgery. In one push of a button the blood supply " +
                                    "is cut off to the anatomical part being removed and " +
                                    "a staple line is left in the patient and on the side " +
                                    "where the pathology has been removed.")
                            //- AutoGen
                            ,
                            //- SurgicalClips
                            //+ TrabecularThickening
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("TrabecularThickening")
                                .SetDisplay("Trabecular thickening")
                                .SetDefinition("[PR] Trabecular thickening")
                                .MammoId("470")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("129795008")
                                .SetSnomedDescription("ClinicalFinding | Mammographic trabecular thickening " +
                                    "of breast (Finding)")
                                .SetICD10("N64.5")
                                .SetComment("only mammo chioce")
                                .SetUMLS("Diffusely increased density, skin edema, and trabecular " +
                                    "thickening are mammographic manifestations of the " +
                                    "edema and lymphatic obstruction in inflammatory carcinoma " +
                                    "of the breast.")
                            //- AutoGen
                                .BiRadsDef("This is a thickening of the fibrous septa of the breast.")
                            ,
                            //- TrabecularThickening
                            //+ ArchitecturalDistortion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ArchitecturalDistortion")
                                .SetDisplay("Architectural distortion")
                                .SetDefinition("[PR] Architectural distortion")
                                .MammoId("260")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("Architectural distortion is often due to a desmoplastic " +
                                    "reaction in which there is focal disruption of the " +
                                    "normal breast tissue pattern. Architectural distortion " +
                                    "is among the most common presentations for breast " +
                                    "cancer. An architectural distortion may be caused " +
                                    "by sclerosing adenosis, or a thing called radial " +
                                    "scar, both of which are benign and both quite rare. " +
                                    "Architectural distortion uncommonly indicates cancer.")
                            //- AutoGen
                            //- ArchitecturalDistortion
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
