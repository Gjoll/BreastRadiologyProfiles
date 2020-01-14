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
                            //+ ForeignObjectCS
                            // oneToMany: many
                            // SNOMED Description: ClinicalFinding | 283574001 | Pellet wound of breast (Disorder) | [0/0] | S21.039? 
                            new ConceptDef("BBPellet",
                                "BB pellet",
                                new Definition()
                                    .Line("[PR] BB pellet")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 470272007
                            // SNOMED Description: PhysicalObject | Implantable lesion localization marker (Object)
                            // ICD10: 470272007
                            new ConceptDef("BiopsyClip",
                                "Biopsy clip",
                                new Definition()
                                    .Line("[PR] Biopsy clip")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 470272007
                            // SNOMED Description: PhysicalObject | Implantable lesion localization marker (Object)
                            // ICD10: 470272007
                            new ConceptDef("BreastMarker",
                                "Breast marker",
                                new Definition()
                                    .Line("[PR] Breast marker")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            new ConceptDef("Calcification",
                                "Calcification",
                                new Definition()
                                    .Line("[PR] Calcification")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            new ConceptDef("CatheterSleeves",
                                "Catheter sleeves",
                                new Definition()
                                    .Line("[PR] Catheter sleeves")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("ChemotherapyPort",
                                "Chemotherapy port",
                                new Definition()
                                    .Line("[PR] Chemotherapy port")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Code: 470342004
                            // oneToMany: many
                            // SNOMED Description: PhysicalObject | Implantable tissue clip (Object)
                            // ICD10: 470342004
                            new ConceptDef("Clip",
                                "Clip",
                                new Definition()
                                    .Line("[PR] Clip")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 470342004
                            // oneToMany: one
                            // SNOMED Description: PhysicalObject | Implantable tissue clip (Object)
                            // ICD10: 470342004
                            new ConceptDef("Coil",
                                "Coil",
                                new Definition()
                                    .Line("[PR] Coil")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 283258005
                            // SNOMED Description: ClinicalFinding | Glass in breast (Disorder)
                            // ICD10: 283258005
                            new ConceptDef("Glass",
                                "Glass",
                                new Definition()
                                    .Line("[PR] Glass")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("GoldSeed",
                                "Gold seed",
                                new Definition()
                                    .Line("[PR] Gold seed")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: ClinicalFinding | 425055008 | Gunshot entry wound (Disorder) | [0/0] | T14.8
                            new ConceptDef("GunshotWound",
                                "Gunshot wound",
                                new Definition()
                                    .Line("[PR] Gunshot wound")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 470272007
                            // SNOMED Description: PhysicalObject | Implantable lesion localization marker (Object)
                            // ICD10: 470272007
                            new ConceptDef("MarkerClip",
                                "Marker clip",
                                new Definition()
                                    .Line("[PR] Marker clip")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Code: 283169003
                            // SNOMED Description: ClinicalFinding | Metal foreign body in breast (Disorder)
                            // ICD10: 283169003
                            new ConceptDef("Metal",
                                "Metal",
                                new Definition()
                                    .Line("[PR] Metal")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 470272007
                            // SNOMED Description: PhysicalObject | Implantable lesion localization marker (Object)
                            // ICD10: 470272007
                            new ConceptDef("MetallicMarker",
                                "Metallic marker",
                                new Definition()
                                    .Line("[PR] Metallic marker")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            new ConceptDef("Needle",
                                "Needle",
                                new Definition()
                                    .Line("[PR] Needle")
                                    .ValidModalities(Modalities.MG)
                                ),
                            // SNOMED Code: 80919006
                            // SNOMED Description: PhysicalObject | Jewelry (Object)
                            // ICD10: 80919006
                            // Comment: NEEDED ADD NIPPLE LOCATION
                            new ConceptDef("NippleJewelry",
                                "Nipple jewelry",
                                new Definition()
                                    .Line("[PR] Nipple jewelry")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Non-metallicBody",
                                "Non-metallic body",
                                new Definition()
                                    .Line("[PR] Non-metallic body")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Pacemaker",
                                "Pacemaker",
                                new Definition()
                                    .Line("[PR] Pacemaker")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("SiliconeGranuloma",
                                "Silicone granuloma",
                                new Definition()
                                    .Line("[PR] Silicone granuloma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: PhysicalObject | 706640008 | Sponge (Object)
                            new ConceptDef("Sponge",
                                "Sponge",
                                new Definition()
                                    .Line("[PR] Sponge")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 470342004
                            // oneToMany: one
                            // SNOMED Description: PhysicalObject | Implantable tissue clip (Object)
                            // ICD10: 470342004
                            new ConceptDef("SurgicalClip",
                                "Surgical clip",
                                new Definition()
                                    .Line("[PR] Surgical clip")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Description: PhysicalObject | 408098004 | Swab (Object
                            new ConceptDef("Swab",
                                "Swab",
                                new Definition()
                                    .Line("[PR] Swab")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            // SNOMED Code: 470272007
                            // oneToMany: one
                            // SNOMED Description: PhysicalObject | Implantable lesion localization marker (Object)
                            // ICD10: 470272007
                            new ConceptDef("TitaniumClip",
                                "Titanium clip",
                                new Definition()
                                    .Line("[PR] Titanium clip")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("TitaniumMarkerClip",
                                "Titanium marker clip",
                                new Definition()
                                    .Line("[PR] Titanium marker clip")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Wire",
                                "Wire",
                                new Definition()
                                    .Line("[PR] Wire")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("WireFragment",
                                "Wire fragment",
                                new Definition()
                                    .Line("[PR] Wire fragment")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                             //- ForeignObjectCS
                         })
             );


        VSTaskVar AbnormalityForeignObjectVS = new VSTaskVar(
            (out ValueSet vs) =>
            {
                vs = Self.CreateValueSet(
                        "AbnormalitiesVS",
                        "Foreign Object ValueSet",
                        "Foreign/Object/ValueSet",
                        "Foreign objects observed during a Breast Radiology exam value set",
                        Group_CommonCodesVS,
                        Self.AbnormalityForeignObjectCS.Value());

                        IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(vs);
                        valueSetIntroDoc
                            .ReviewedStatus(ReviewStatus.NotReviewed)
                            .Intro(vs.Description)
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        Self.fc?.Mark(outputPath);
            }
            );

        SDTaskVar AbnormalityForeignObject = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.AbnormalityForeignObjectVS.Value();

                SDefEditor e = Self.CreateEditorObservationSection("AbnormalityForeignObject",
                        "Foreign Object",
                        "Foreign Object",
                        $"{Group_CommonResources}/AbnormalityForeign")
                    .Description("Foreign Object Observation",
                        new Markdown()
                            .Paragraph("These are foreign objects found during a breast radiology exam:")
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value().Url)
                    .AddFragRef(Self.ObservationCodedValueFragment.Value().Url)
                    .AddFragRef(Self.CommonComponentsFragment.Value().Url)
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value().Url)
                    .AddFragRef(Self.CorrespondsWith.Value().Url)
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("value[x]").Zero();

                PreFhir.ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.ConsistentWith.Value(), 0, "*");
                Self.SliceTargetReference(e, sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("abnormalityForeignObjectType",
                    Self.CodeAbnormalityForeignObjectType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "AbnormalityForeignObject Type");
                Self.ComponentSliceBiRads(e);
            });
    }
}
