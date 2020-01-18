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
                            //+ BBPellet
                            new ConceptDef()
                                .SetCode("BBPellet")
                                .SetDisplay("BB pellet")
                                .SetDefinition(new Definition()
                                    .Line("[PR] BB pellet")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- BBPellet
                            // SNOMED Code: 470272007
                            // SNOMED Description: PhysicalObject | Implantable lesion localization marker (Object)
                            // ICD10: 470272007
                            //+ BiopsyClip
                            new ConceptDef()
                                .SetCode("BiopsyClip")
                                .SetDisplay("Biopsy clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Biopsy clip")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- BiopsyClip
                            // SNOMED Code: 470272007
                            // SNOMED Description: PhysicalObject | Implantable lesion localization marker (Object)
                            // ICD10: 470272007
                            //+ BreastMarker
                            new ConceptDef()
                                .SetCode("BreastMarker")
                                .SetDisplay("Breast marker")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Breast marker")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- BreastMarker
                            //+ Calcification
                            new ConceptDef()
                                .SetCode("Calcification")
                                .SetDisplay("Calcification")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Calcification")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- Calcification
                            //+ CatheterSleeves
                            new ConceptDef()
                                .SetCode("CatheterSleeves")
                                .SetDisplay("Catheter sleeves")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Catheter sleeves")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- CatheterSleeves
                            //+ ChemotherapyPort
                            new ConceptDef()
                                .SetCode("ChemotherapyPort")
                                .SetDisplay("Chemotherapy port")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Chemotherapy port")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- ChemotherapyPort
                            // SNOMED Code: 470342004
                            // oneToMany: many
                            // SNOMED Description: PhysicalObject | Implantable tissue clip (Object)
                            // ICD10: 470342004
                            //+ Clip
                            new ConceptDef()
                                .SetCode("Clip")
                                .SetDisplay("Clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Clip")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Clip
                            // SNOMED Code: 470342004
                            // oneToMany: one
                            // SNOMED Description: PhysicalObject | Implantable tissue clip (Object)
                            // ICD10: 470342004
                            //+ Coil
                            new ConceptDef()
                                .SetCode("Coil")
                                .SetDisplay("Coil")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Coil")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Coil
                            // SNOMED Code: 283258005
                            // SNOMED Description: ClinicalFinding | Glass in breast (Disorder)
                            // ICD10: 283258005
                            //+ Glass
                            new ConceptDef()
                                .SetCode("Glass")
                                .SetDisplay("Glass")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Glass")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Glass
                            //+ GoldSeed
                            new ConceptDef()
                                .SetCode("GoldSeed")
                                .SetDisplay("Gold seed")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Gold seed")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- GoldSeed
                            // SNOMED Description: ClinicalFinding | 425055008 | Gunshot entry wound (Disorder) | [0/0] | T14.8
                            //+ GunshotWound
                            new ConceptDef()
                                .SetCode("GunshotWound")
                                .SetDisplay("Gunshot wound")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Gunshot wound")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- GunshotWound
                            // SNOMED Code: 470272007
                            // SNOMED Description: PhysicalObject | Implantable lesion localization marker (Object)
                            // ICD10: 470272007
                            //+ MarkerClip
                            new ConceptDef()
                                .SetCode("MarkerClip")
                                .SetDisplay("Marker clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Marker clip")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- MarkerClip
                            // SNOMED Code: 283169003
                            // SNOMED Description: ClinicalFinding | Metal foreign body in breast (Disorder)
                            // ICD10: 283169003
                            //+ Metal
                            new ConceptDef()
                                .SetCode("Metal")
                                .SetDisplay("Metal")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Metal")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Metal
                            // SNOMED Code: 470272007
                            // SNOMED Description: PhysicalObject | Implantable lesion localization marker (Object)
                            // ICD10: 470272007
                            //+ MetallicMarker
                            new ConceptDef()
                                .SetCode("MetallicMarker")
                                .SetDisplay("Metallic marker")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Metallic marker")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            //- MetallicMarker
                            //+ Needle
                            new ConceptDef()
                                .SetCode("Needle")
                                .SetDisplay("Needle")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Needle")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- Needle
                            // SNOMED Code: 80919006
                            // SNOMED Description: PhysicalObject | Jewelry (Object)
                            // ICD10: 80919006
                            // Comment: NEEDED ADD NIPPLE LOCATION
                            //+ NippleJewelry
                            new ConceptDef()
                                .SetCode("NippleJewelry")
                                .SetDisplay("Nipple jewelry")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Nipple jewelry")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- NippleJewelry
                            //+ Non-metallicBody
                            new ConceptDef()
                                .SetCode("Non-metallicBody")
                                .SetDisplay("Non-metallic body")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Non-metallic body")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- Non-metallicBody
                            //+ Pacemaker
                            new ConceptDef()
                                .SetCode("Pacemaker")
                                .SetDisplay("Pacemaker")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Pacemaker")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Pacemaker
                            //+ SiliconeGranuloma
                            new ConceptDef()
                                .SetCode("SiliconeGranuloma")
                                .SetDisplay("Silicone granuloma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Silicone granuloma")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- SiliconeGranuloma
                            // SNOMED Description: PhysicalObject | 706640008 | Sponge (Object)
                            //+ Sponge
                            new ConceptDef()
                                .SetCode("Sponge")
                                .SetDisplay("Sponge")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Sponge")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Sponge
                            // SNOMED Code: 470342004
                            // oneToMany: one
                            // SNOMED Description: PhysicalObject | Implantable tissue clip (Object)
                            // ICD10: 470342004
                            //+ SurgicalClip
                            new ConceptDef()
                                .SetCode("SurgicalClip")
                                .SetDisplay("Surgical clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical clip")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- SurgicalClip
                            // SNOMED Description: PhysicalObject | 408098004 | Swab (Object
                            //+ Swab
                            new ConceptDef()
                                .SetCode("Swab")
                                .SetDisplay("Swab")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Swab")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Swab
                            // SNOMED Code: 470272007
                            // oneToMany: one
                            // SNOMED Description: PhysicalObject | Implantable lesion localization marker (Object)
                            // ICD10: 470272007
                            //+ TitaniumClip
                            new ConceptDef()
                                .SetCode("TitaniumClip")
                                .SetDisplay("Titanium clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Titanium clip")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- TitaniumClip
                            //+ TitaniumMarkerClip
                            new ConceptDef()
                                .SetCode("TitaniumMarkerClip")
                                .SetDisplay("Titanium marker clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Titanium marker clip")
                                    .ValidModalities(Modalities.MG)
                                ),
                            //- TitaniumMarkerClip
                            //+ Wire
                            new ConceptDef()
                                .SetCode("Wire")
                                .SetDisplay("Wire")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Wire")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            //- Wire
                            //+ WireFragment
                            new ConceptDef()
                                .SetCode("WireFragment")
                                .SetDisplay("Wire fragment")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Wire fragment")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                )
                            //- WireFragment
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
                        ObservationUrl,
                        $"{Group_CommonResources}/AbnormalityForeign",
                        "ObservationSection")
                    .Description("Foreign Object Observation",
                        new Markdown()
                            .Paragraph("These are foreign objects found during a breast radiology exam:")
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.CorrespondsWithFragment.Value())
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

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
                    "ForeignObject Type",
                    new Markdown()
                        .Paragraph($"This slice contains the required component that refines the foreign object type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
                Self.ComponentSliceBiRads(e);
            });
    }
}
