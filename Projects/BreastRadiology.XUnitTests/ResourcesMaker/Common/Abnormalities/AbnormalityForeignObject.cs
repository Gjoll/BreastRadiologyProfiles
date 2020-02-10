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
        CSTaskVar AbnormalityForeignObjectCS = new CSTaskVar(
             (out CodeSystem vs) =>
                 vs = Self.CreateCodeSystem(
                         "ForeignObjectCS",
                         "Foreign Object CodeSystem",
                         "Foreign/Object/ CodeSystem",
                         "Foreign objects observed during a Breast Radiology exam code system.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                            //+ Type
                            #region Codes
                            new ConceptDef()
                                .SetCode("BBPellet")
                                .SetDisplay("BB pellet")
                                .MammoId("532")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 283574001 | Pellet wound of breast " +
                                    "(Disorder) | [0/0] | S21.039?")
                                .SetUMLS("A BB pellet is present in the body and is visible " +
                                    "by the Mammogram, MRI and/or Ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("BBPellets")
                                .SetDisplay("BB pellets")
                                .MammoId("531")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 283574001 | Pellet wound of breast " +
                                    "(Disorder) | [0/0] | S21.039?")
                                .SetUMLS("BB pellets are present in the body and is visible " +
                                    "by the Mammogram, MRI and/or Ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("BiopsyClip")
                                .SetDisplay("Biopsy clip")
                                .MammoId("591")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("Tissue marker placement after image-guided breast " +
                                    "biopsy has become a routine component of clinical " +
                                    "practice. ",
                                    "Marker placement distinguishes multiple biopsied " +
                                    "lesions within the same breast, prevents re-biopsy " +
                                    "of benign lesions, enables multi-modality correlation, " +
                                    "guides pre-operative localization and helps confirm " +
                                    "surgical target removal. ",
                                    "Numerous breast tissue markers are currently available, " +
                                    "with varied shapes, composition, and associated bio-absorbable " +
                                    "components. ",
                                    "This review serves to familiarize the breast interventionalist " +
                                    "with the tissue markers most widely available in " +
                                    "the United States today and to provide guidance regarding " +
                                    "selection of appropriate markers for various clinical " +
                                    "settings. ",
                                    "###URL#https://www.ncbi.nlm.nih.gov/pubmed/30059952")
                            ,
                            new ConceptDef()
                                .SetCode("BiopsyClips")
                                .SetDisplay("Biopsy clips")
                                .MammoId("910")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("Tissue marker placement after image-guided breast " +
                                    "biopsy has become a routine component of clinical " +
                                    "practice. ",
                                    "Marker placement distinguishes multiple biopsied " +
                                    "lesions within the same breast, prevents re-biopsy " +
                                    "of benign lesions, enables multi-modality correlation, " +
                                    "guides pre-operative localization and helps confirm " +
                                    "surgical target removal. ",
                                    "Numerous breast tissue markers are currently available, " +
                                    "with varied shapes, composition, and associated bio-absorbable " +
                                    "components. ",
                                    "This review serves to familiarize the breast interventionalist " +
                                    "with the tissue markers most widely available in " +
                                    "the United States today and to provide guidance regarding " +
                                    "selection of appropriate markers for various clinical " +
                                    "settings. ",
                                    "###URL#https://www.ncbi.nlm.nih.gov/pubmed/30059952")
                            ,
                            new ConceptDef()
                                .SetCode("BreastMarker")
                                .SetDisplay("Breast marker")
                                .MammoId("905")
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("A breast marker is present in the  breast and is " +
                                    "viewable on the MRI. ",
                                    "Tissue marker placement after image-guided breast " +
                                    "biopsy has become a routine component of clinical " +
                                    "practice. ",
                                    "Marker placement distinguishes multiple biopsied " +
                                    "lesions within the same breast, prevents re-biopsy " +
                                    "of benign lesions, enables multi-modality correlation, " +
                                    "guides pre-operative localization and helps confirm " +
                                    "surgical target removal. ",
                                    "Numerous breast tissue markers are currently available, " +
                                    "with varied shapes, composition, and associated bio-absorbable " +
                                    "components. ",
                                    "www.ncbi.nlm.nih.gov > pubmed")
                            ,
                            new ConceptDef()
                                .SetCode("BreastMarkers")
                                .SetDisplay("Breast markers")
                                .MammoId("906")
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("Tissue marker placement after image-guided breast " +
                                    "biopsy has become a routine component of clinical " +
                                    "practice. ",
                                    "Marker placement distinguishes multiple biopsied " +
                                    "lesions within the same breast, prevents re-biopsy " +
                                    "of benign lesions, enables multi-modality correlation, " +
                                    "guides pre-operative localization and helps confirm " +
                                    "surgical target removal. ",
                                    "Numerous breast tissue markers are currently available, " +
                                    "with varied shapes, composition, and associated bio-absorbable " +
                                    "components. ",
                                    "This review serves to familiarize the breast interventionalist " +
                                    "with the tissue markers most widely available in " +
                                    "the United States today and to provide guidance regarding " +
                                    "selection of appropriate markers for various clinical " +
                                    "settings. ",
                                    "www.ncbi.nlm.nih.gov > pubmed")
                            ,
                            new ConceptDef()
                                .SetCode("CatheterSleeves")
                                .SetDisplay("Catheter sleeves")
                                .MammoId("519")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            ,
                            new ConceptDef()
                                .SetCode("ChemotherapyPort")
                                .SetDisplay("Chemotherapy port")
                                .MammoId("592")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("A soft thin tube called a catheter connects the port " +
                                    "to a large vein for administering chemotherapy is " +
                                    "present in the MRI/Ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("Clip")
                                .SetDisplay("Clip")
                                .MammoId("908")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470342004")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                            ,
                            new ConceptDef()
                                .SetCode("Clips")
                                .SetDisplay("Clips")
                                .MammoId("516")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470342004")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                            ,
                            new ConceptDef()
                                .SetCode("Coil")
                                .SetDisplay("Coil")
                                .MammoId("517")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470342004")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                                .SetUMLS("The coil acts as an antenna to receive the radio " +
                                    "frequency signal. ",
                                    "This is present on the Mammogram, MRI and/or Ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("Glass")
                                .SetDisplay("Glass")
                                .MammoId("522")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("283258005")
                                .SetSnomedDescription("ClinicalFinding | Glass in breast (Disorder)")
                                .SetUMLS("Glass is present in the body and shows up on the " +
                                    "MRI, Mammogram, and/or Ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("GoldSeed")
                                .SetDisplay("Gold seed")
                                .MammoId("913")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("Tiny, gold seeds that are put in and/or around a " +
                                    "tumor to show exactly where the tumor is are present " +
                                    "in the ultrasound/MRI.")
                            ,
                            new ConceptDef()
                                .SetCode("GunshotWound")
                                .SetDisplay("Gunshot wound")
                                .MammoId("533")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 425055008 | Gunshot entry wound " +
                                    "(Disorder) | [0/0] | T14.8")
                            ,
                            new ConceptDef()
                                .SetCode("MarkerClip")
                                .SetDisplay("Marker clip")
                                .MammoId("575")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                            ,
                            new ConceptDef()
                                .SetCode("Metal")
                                .SetDisplay("Metal")
                                .MammoId("521")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("283169003")
                                .SetSnomedDescription("ClinicalFinding | Metal foreign body in breast (Disorder)")
                                .SetUMLS("A piece of metal is present in the body and is viewable " +
                                    "on the MRI and/or Ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("MetallicMarker")
                                .SetDisplay("Metallic marker")
                                .MammoId("903")
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("A metallic tissue marker is present in the ultrasound/MRI.")
                            ,
                            new ConceptDef()
                                .SetCode("MetallicMarkers")
                                .SetDisplay("Metallic markers")
                                .MammoId("904")
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                                .SetUMLS("Metallic tissue markers are present in the MRI/Ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("MetallicObjects")
                                .SetDisplay("Metallic objects")
                                .MammoId("593")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("ClinicalFinding | 283169003 | Metal foreign body " +
                                    "in breast (Disorder) | [0/0] | S21.009?")
                                .SetUMLS("The Mammogram suggests a foreign body in the breast " +
                                    "that appears to be a metallic object.")
                            ,
                            new ConceptDef()
                                .SetCode("Needle")
                                .SetDisplay("Needle")
                                .MammoId("597")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("The Mammogram suggests a foreign body in the breast " +
                                    "that appears to be a needle.")
                            ,
                            new ConceptDef()
                                .SetCode("NippleJewelry")
                                .SetDisplay("Nipple jewelry")
                                .MammoId("598")
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("80919006")
                                .SetSnomedDescription("PhysicalObject | Jewelry (Object)")
                                .SetUMLS("The Mammogram suggests a foreign body in the breast " +
                                    "that appears to be a piece of nipple jewelry.")
                            ,
                            new ConceptDef()
                                .SetCode("Non-metallicBody")
                                .SetDisplay("Non-metallic body")
                                .MammoId("594")
                                .ValidModalities(Modalities.MG)
                            ,
                            new ConceptDef()
                                .SetCode("Pacemaker")
                                .SetDisplay("Pacemaker")
                                .MammoId("529")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("A pacemaker is present showing up on the MRI and/or " +
                                    "Ultrasound.")
                            ,
                            new ConceptDef()
                                .SetCode("SiliconeGranuloma")
                                .SetDisplay("Silicone granuloma")
                                .MammoId("520")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("Silicone granuloma shows up on the MRI and/or Ultrasound. ",
                                    "Snowball like hyperechogenic axillary lymph nodes " +
                                    "in a woman with silicone implants removed due to " +
                                    "complications. ",
                                    "Specialty. ",
                                    "Dermatology. ",
                                    "Silicone granulomas are a skin condition that occur " +
                                    "as a reaction to liquid silicones, and are characterized " +
                                    "by the formation of nodules.")
                            ,
                            new ConceptDef()
                                .SetCode("Sponge")
                                .SetDisplay("Sponge")
                                .MammoId("535")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("PhysicalObject | 706640008 | Sponge (Object)")
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalClip")
                                .SetDisplay("Surgical clip")
                                .MammoId("911")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470342004")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                            ,
                            new ConceptDef()
                                .SetCode("SurgicalClips")
                                .SetDisplay("Surgical clips")
                                .MammoId("596")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470342004")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                            ,
                            new ConceptDef()
                                .SetCode("Swab")
                                .SetDisplay("Swab")
                                .MammoId("534")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("PhysicalObject | 408098004 | Swab (Object")
                                .SetUMLS("A Retained surgical swab appears to have been idenified " +
                                    "in the breast during the mammogram, ultrasound and/or " +
                                    "MRI.")
                            ,
                            new ConceptDef()
                                .SetCode("TitaniumClip")
                                .SetDisplay("Titanium clip")
                                .MammoId("528")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                            ,
                            new ConceptDef()
                                .SetCode("TitaniumClips")
                                .SetDisplay("Titanium clips")
                                .MammoId("530")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization " +
                                    "marker (Object)")
                            ,
                            new ConceptDef()
                                .SetCode("Wire")
                                .SetDisplay("Wire")
                                .MammoId("518")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("Guidewire is present in the body. ",
                                    " It is viewable in the MRI and/or Ultrasound. ",
                                    "Guidewire is used during medical procedures such " +
                                    "as biopsy or placement of medical devices such as " +
                                    "a catheter or pacemaker.")
                            ,
                            new ConceptDef()
                                .SetCode("WireFragment")
                                .SetDisplay("Wire fragment")
                                .MammoId("527")
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetUMLS("A fragment of a guidewire is present in the body. ",
                                    "It is viewable in the MRI and/or Ultrasound. ",
                                    " Guidewire is used during medical procedures such " +
                                    "as a biopsy or  placement of medical devices such " +
                                    "as a catheter or pacemaker.")
                            #endregion // Codes
                             //- Type
                         })
             );


        VSTaskVar AbnormalityForeignObjectVS = new VSTaskVar(
            (out ValueSet vs) =>
            {
                vs = Self.CreateValueSet(
                        "ForeignObjectVS",
                        "Foreign Object ValueSet",
                        "Foreign/Object/ValueSet",
                        "Foreign objects observed during a Breast Radiology exam value set",
                        Group_CommonCodesVS,
                        Self.AbnormalityForeignObjectCS.Value());

                        IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(vs);
                        valueSetIntroDoc
                            .ReviewedStatus("NOONE", "")
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        Self.fc?.Mark(outputPath);
            }
            );

        SDTaskVar AbnormalityForeignObject = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.AbnormalityForeignObjectVS.Value();

                SDefEditor e = Self.CreateEditor("AbnormalityForeignObject",
                        "Foreign Object",
                        "Foreign Object",
                        Global.ObservationUrl,
                        $"{Group_CommonResources}/AbnormalityForeign",
                        "ObservationSection")
                    .Description("Foreign Object Observation",
                        new Markdown()
                            .Paragraph("These are foreign objects found during a breast radiology exam:")
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ObservationComponentNotPreviouslySeenFragment.Value())
                    .AddFragRef(Self.ObservationComponentCorrespondsWithFragment.Value())
                    .AddFragRef(Self.ObservationComponentBiRadFragment.Value())
                    .AddFragRef(Self.ObservationComponentPreviouslyDemonstratedByFragment.Value())

                    .AddFragRef(Self.ObservationHasMemberAssociatedFeaturesFragment.Value())
                    .AddFragRef(Self.ObservationHasMemberConsistentWithFragment.Value())
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeAbnormalityForeignObject.ToCodeableConcept().ToPattern());

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("abnormalityForeignObjectType",
                    Self.ComponentSliceCodeAbnormalityForeignObjectType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "Foreign Object Type",
                    "refines the foreign object type");
            });
    }
}
