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
                            #region Codes
                            new ConceptDef()
                                .SetCode("ArchitecturalDistortion")
                                .SetDisplay("Architectural distortion")
                                .MammoId("260")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("Many breast masses are found within the zone of fibroglandular " +
                                    "tissue or at a fat-fibroglandular",
                                    "junction. ",
                                    "If the mass blurs a tissue plane between fat and " +
                                    "fibroglandular tissue or if the ",
                                    "mass produces",
                                    "distortion of the ducts, these findings may be termed " +
                                    "architectural distortion. ",
                                    "###ACRUS#139")
                            ,
                            new ConceptDef()
                                .SetCode("AxillaryAdenopathy")
                                .SetDisplay("Axillary adenopathy")
                                .MammoId("239")
                                .ValidModalities(Modalities.MG | Modalities.MRI)
                                .SetUMLS("Enlarged axillary (under the armpit) lymph nodes. ",
                                    "Additional evaluation is needed to determine the " +
                                    "cause. ",
                                    "###ACRMG#110")
                            ,
                            new ConceptDef()
                                .SetCode("BiopsyClip")
                                .SetDisplay("Biopsy clip")
                                .MammoId("471.263")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("Physical Object | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("Tissue marker placement after image-guided breast " +
                                    "biopsy has become a routine component ",
                                    "of clinical practice. ",
                                    "Marker placement distinguishes multiple biopsied " +
                                    "lesions within the same breast, ",
                                    "prevents re-biopsy of benign lesions, enables multi-modality " +
                                    "correlation, guides ",
                                    "pre-operative localization and helps confirm surgical " +
                                    "target removal. ",
                                    "Numerous breast tissue markers are currently available, " +
                                    "with varied shapes, composition, ",
                                    "and associated bio-absorbable components. ",
                                    "###URL#https://www.ncbi.nlm.nih.gov/pubmed/30059952")
                            ,
                            new ConceptDef()
                                .SetCode("BiopsyClips")
                                .SetDisplay("Biopsy clips")
                                .MammoId("472.264")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("Physical Object | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("Tissue marker placement after image-guided breast " +
                                    "biopsy has become a routine component ",
                                    "of clinical practice. ",
                                    "Marker placement distinguishes multiple biopsied " +
                                    "lesions within the same breast, ",
                                    "prevents re-biopsy of benign lesions, enables multi-modality " +
                                    "correlation, guides ",
                                    "pre-operative localization and helps confirm surgical " +
                                    "target removal. ",
                                    "Numerous breast tissue markers are currently available, " +
                                    "with varied shapes, composition, ",
                                    "and associated bio-absorbable components. ",
                                    "###URL#https://www.ncbi.nlm.nih.gov/pubmed/30059952")
                            ,
                            new ConceptDef()
                                .SetCode("BrachytherapyTube")
                                .SetDisplay("Brachytherapy tube")
                                .MammoId("475")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("Brachytherapy may be temporary or permanent. ",
                                    "Temporary brachytherapy places radioactive material " +
                                    "inside a catheter for a specific ",
                                    "amount of time and then it is removed. ",
                                    "It is given at a low-dose rate (LDR) or high-dose " +
                                    "rate (HDR). ",
                                    "Permanent brachytherapy is also called seed implantation. ",
                                    "It puts radioactive seeds (about the size of a grain " +
                                    "of rice) in or near the tumor ",
                                    "permanently. ",
                                    "After several months, the seeds lose their radioactivity. ",
                                    "###URL#https://www.radiologyinfo.org/en/info.cfm?pg=brachy")
                            ,
                            new ConceptDef()
                                .SetCode("ChestWallInvasion")
                                .SetDisplay("Chest wall invasion")
                                .MammoId("255")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("NO FIND")
                                .SetUMLS("A tumor of the lung that has invaded the chest wall.")
                            ,
                            new ConceptDef()
                                .SetCode("CooperDistorted")
                                .SetDisplay("Cooper distorted")
                                .MammoId("261")
                                .ValidModalities(Modalities.US)
                                .SetUMLS("The cooper's ligaments are fibrous bands extending " +
                                    "vertically from surface attached to ",
                                    "chest wall muscles. ",
                                    "These ligaments maintain the shape and structure " +
                                    "of your breasts and help to prevent ",
                                    "sagging. ",
                                    " Cooper's ligaments support the breasts on the chest " +
                                    "wall, maintain their contour, ",
                                    "and keep them in position. ",
                                    "They become distorted if cancerous tumors grow on " +
                                    "the ligaments. ",
                                    "The normal breast contours can be noticeably different " +
                                    "once they are distorted. ",
                                    "This can be because of swelling, bulges, retraction, " +
                                    "etc.")
                            ,
                            new ConceptDef()
                                .SetCode("CooperThickened")
                                .SetDisplay("Cooper thickened")
                                .MammoId("262")
                                .ValidModalities(Modalities.US)
                                .SetUMLS("The cooper's ligaments are fibrous bands extending " +
                                    "vertically from surface attached",
                                    "to chest wall muscles. ",
                                    "These ligaments maintain the shape and structure " +
                                    "of your breasts and help to prevent ",
                                    "sagging. ",
                                    "Cooper's ligaments support the breasts on the chest " +
                                    "wall, maintain their contour, ",
                                    "and keep them in position. ",
                                    "These support breast tissue; they become contracted " +
                                    "in cancer of breast, producing ",
                                    "dimples in overlying skin. ",
                                    "Thickening occurs when there are skin changes usually " +
                                    "associated with the presence ",
                                    "of a mass, benign or malignant, that causes shortening " +
                                    "in the Coopers ligaments due ",
                                    "to fibrosis.")
                            ,
                            new ConceptDef()
                                .SetCode("Edema")
                                .SetDisplay("Edema")
                                .MammoId("258")
                                .ValidModalities(Modalities.US)
                                .SetSnomedCode("290077003")
                                .SetSnomedDescription("Clinical Finding | Edema of breast (Finding)")
                                .SetUMLS("Edema (swelling of the breasts)  may be due to blockage " +
                                    "of subdermal lymphatics by tumor cells or an inflammatory " +
                                    "process within the breast or axilla.")
                            ,
                            new ConceptDef()
                                .SetCode("EdemaAdj")
                                .SetDisplay("Edema adj")
                                .MammoId("259")
                                .ValidModalities(Modalities.US)
                                .SetUMLS("This is swelling of one or both breasts. ",
                                    "A mammographic pattern of skin thickening, increased " +
                                    "parenchymal density, and interstitial marking.")
                            ,
                            new ConceptDef()
                                .SetCode("GoldSeed")
                                .SetDisplay("Gold Seed")
                                .MammoId("238")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("Physical Object | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("Tiny, gold seeds, about the size of a grain of rice, " +
                                    "that are put in and/or around ",
                                    "a tumor to show exactly where it is in the body. ",
                                    "The tumor can then be directly targeted and be given " +
                                    "higher doses of radiation ",
                                    "with less harm to nearby healthy tissue. ",
                                    "Also called gold fiducial marker seeds, gold fiducial " +
                                    "markers, and gold-seed fiducial ",
                                    "markers. ",
                                    "###URL#https://www.cancer.gov/publications/dictionaries/cancer-terms/def/gold-seeds")
                            ,
                            new ConceptDef()
                                .SetCode("Hematoma")
                                .SetDisplay("Hematoma")
                                .MammoId("478")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("302924003")
                                .SetSnomedDescription("Clinical Finding | Breast hematoma (Disorder) | N64.89")
                                .SetUMLS("A hematoma is a localized bleeding outside of blood " +
                                    "vessels, due to either disease ",
                                    "or trauma including injury or surgery and may involve " +
                                    "blood continuing to seep from ",
                                    "broken capillaries. ",
                                    "en.wikipedia.org > wiki > Hematoma")
                            ,
                            new ConceptDef()
                                .SetCode("NippleRetraction")
                                .SetDisplay("Nipple retraction")
                                .MammoId("477")
                                .ValidModalities(Modalities.MG | Modalities.MRI)
                                .SetSnomedCode("31845005")
                                .SetSnomedDescription("ClinicalFinding | Retraction of nipple (Disorder) " +
                                    "| [2/9] | N64.53")
                                .SetUMLS("Retracted nipples lie flat against the areola. ",
                                    "The condition can be the result of inflammation or " +
                                    "scarring of the tissue behind ",
                                    "the nipple, and caused by numerous conditions, not " +
                                    "just cancer. ",
                                    "In the case of breast cancer, nipple retraction occurs " +
                                    "when the tumor attacks the ",
                                    "duct behind the nipple, pulling it in.")
                            ,
                            new ConceptDef()
                                .SetCode("NOChestWallInvasion")
                                .SetDisplay("NO Chest wall invasion")
                                .MammoId("257")
                                .ValidModalities(Modalities.MRI)
                                .SetUMLS("The mass has not attached itself to the chest wall.")
                            ,
                            new ConceptDef()
                                .SetCode("PectoralisMuscleInvasion")
                                .SetDisplay("Pectoralis muscle invasion")
                                .MammoId("254")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("choices with muscle + invasion")
                                .SetUMLS("Pectoralis muscle invasion is when a tumor has become " +
                                    "large enough to invade into ",
                                    "the pectoralis muscle.")
                            ,
                            new ConceptDef()
                                .SetCode("PectoralisMuscleInvolvement")
                                .SetDisplay("Pectoralis muscle involvement")
                                .MammoId("256")
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedDescription("choices with muscle + invasion")
                                .SetUMLS("Pectoralis muscle involvement of the tumor has been " +
                                    "detected on the MRI by muscle ",
                                    "enhancement with obliteration of the fat plane between " +
                                    "the tumor and the muscle. ",
                                    "pubs.rsna.org > doi > pdf")
                            ,
                            new ConceptDef()
                                .SetCode("PectoralisMuscleTenting")
                                .SetDisplay("Pectoralis muscle tenting")
                                .MammoId("253")
                                .ValidModalities(Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("NO FIND")
                                .SetUMLS("The tent sign is a term referring to a characteristic " +
                                    "appearance of the posterior ",
                                    "edge of the breast parenchyma when a mass (usually " +
                                    "an infiltrating lesion) causes ",
                                    "its retraction and forms an inverted \"V\" that resembles " +
                                    "the tip of a circus tent. ",
                                    "###URL#https://radiopaedia.org/articles/tent-sign-breast?lang=us")
                            ,
                            new ConceptDef()
                                .SetCode("PostSurgicalScar")
                                .SetDisplay("Post surgical scar")
                                .MammoId("479")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("442523003")
                                .SetSnomedDescription("ClinicalFinding | Surgical scar finding (Finding) " +
                                    "| [2/7] | L90.5 |")
                                .SetUMLS("Post surgical scarring happens because of the incisions " +
                                    "needed to surgically remove ",
                                    "tumor, cells, etc. ",
                                    "The amount of scarring is connected to the different " +
                                    "stages of wound healing. ",
                                    "Surgical scar care should be continued for a year.")
                            ,
                            new ConceptDef()
                                .SetCode("Seroma")
                                .SetDisplay("Seroma")
                                .MammoId("469")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("297178008")
                                .SetSnomedDescription("ClinicalFinding | Breast seroma (Disorder)")
                                .SetUMLS("A breast seroma is a collection (pocket) of serous " +
                                    "fluid that can develop after trauma ",
                                    "to the breast or following procedures such as breast " +
                                    "surgery or radiation therapy. ",
                                    "Serous fluid is a pale yellow, transparent fluid " +
                                    "that contains protein, but no blood ",
                                    "cells or pus. ",
                                    "###URL#https://www.verywellhealth.com/seroma-medical-definition-430372")
                            ,
                            new ConceptDef()
                                .SetCode("SkinInvolvement")
                                .SetDisplay("Skin involvement")
                                .MammoId("252")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("The mass or lesion has attached itself to the skin " +
                                    "of the breast. ",
                                    "There are several layers of skin that the mass or " +
                                    "lesion can penetrate and that is ",
                                    "what determines the level of skin invasion.")
                            ,
                            new ConceptDef()
                                .SetCode("SkinLesion")
                                .SetDisplay("Skin lesion")
                                .MammoId("473")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("126510002")
                                .SetSnomedDescription("ClinicalFinding | Neoplasm of skin of breast (Disorder)")
                                .SetUMLS("A skin lesion is a part of the skin that has an abnormal " +
                                    "growth or appearance compared ",
                                    "to the skin around it.In order to diagnose a skin " +
                                    "lesion, a full physical exam is necessary.")
                            ,
                            new ConceptDef()
                                .SetCode("SkinRetraction")
                                .SetDisplay("Skin retraction")
                                .MammoId("251")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 129796009 | Mammographic skin retraction " +
                                    "of breast (Finding) | [0/0] | N64.5")
                                .SetUMLS("Skin retraction (or inversion) or Skin retraction. ",
                                    "Breast cancers that are located near the skin or " +
                                    "nipple may cause scarring within ",
                                    "the breast that pulls at the nipple or nearby skin. ",
                                    "Skin and nipple retraction are more obvious when " +
                                    "a woman raises her arms above her ",
                                    "head or leans forward. ",
                                    "###URL#https://www.drholmesmd.com/blog/early-signs-of-breast-cancer")
                            ,
                            new ConceptDef()
                                .SetCode("SkinThickening")
                                .SetDisplay("Skin thickening")
                                .MammoId("250")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 129797000 | Mammographic skin thickening " +
                                    "of breast (Finding) | [0/0] | R92")
                                .SetUMLS("The presence of skin thickening on mammography is " +
                                    "variably defined, usually being ",
                                    "more than 2 mm in thickness. ",
                                    "It can result from a number of both benign and malignant " +
                                    "causes. ",
                                    "###URL#https://radiopaedia.org/articles/skin-thickening-on-mammography-differential?lang=us")
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalClip")
                                .SetDisplay("Surgical clip")
                                .MammoId("485")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("470342004")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                                .SetUMLS("Most surgical clips are currently made of titanium, " +
                                    "and as many as 30 to 40 clips ",
                                    "may be used during a single surgical procedure. ",
                                    "They remain inside the patient's body after the wounds " +
                                    "are healed.")
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalClips")
                                .SetDisplay("Surgical clips")
                                .MammoId("486")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("470342004")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                                .SetUMLS("A series of surgical staples or clips are used during " +
                                    "surgery. ",
                                    "In one push of a button the blood supply is cut off " +
                                    "to the anatomical part being ",
                                    "removed and a staple line is left in the patient " +
                                    "and on the side where the pathology ",
                                    "has been removed.")
                            ,
                            new ConceptDef()
                                .SetCode("TrabecularThickening")
                                .SetDisplay("Trabecular thickening")
                                .MammoId("470")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("129795008")
                                .SetSnomedDescription("ClinicalFinding | Mammographic trabecular thickening " +
                                    "of breast (Finding)")
                                .SetUMLS("Trabecular thickening-thickening of the Cooper's ligaments " +
                                    "and fibrous stroma-is ",
                                    "an imaging finding of breast edema, usually secondary " +
                                    "to dilated lymphatics. ",
                                    "Skin thickening and trabecular thickening often occur " +
                                    "together, and they have similar ",
                                    "differential diagnoses. ",
                                    "###URL#https://oxfordmedicine.com/view/10.1093/med/9780190270261.001.0001/med-9780190270261-chapter-48")
                            #endregion // Codes
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
                    .AddFragRef(Self.ObservationComponentObservedCountFragment.Value())
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
                e.Select("code").Pattern(Self.ObservationCodeObservedFeature.ToCodeableConcept().ToPattern());

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("featureType",
                    Self.ComponentSliceCodeObservedFeatureType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "Observed Feature Type",
                    "defines the observed feature");
            });
    }
}
