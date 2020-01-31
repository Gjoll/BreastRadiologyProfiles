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
                            //+ BBPellet
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BBPellet")
                                .SetDisplay("BB pellet")
                                .SetDefinition(new Definition()
                                    .Line("[PR] BB pellet")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetOneToMany("many")
                                .SetSnomedDescription("ClinicalFinding | 283574001 | Pellet wound of breast (Disorder) | [0/0] | S21.039?")
                            //- AutoGen
                            //- BBPellet
                            ,
                            //+ BiopsyClip
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BiopsyClip")
                                .SetDisplay("Biopsy clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Biopsy clip")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                                .SetICD10("470272007")
                            //- AutoGen
                            //- BiopsyClip
                            ,
                            //+ BreastMarker
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BreastMarker")
                                .SetDisplay("Breast marker")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Breast marker")
                                )
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                                .SetICD10("470272007")
                            //- AutoGen
                            //- BreastMarker
                            ,
                            //+ Calcification
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Calcification")
                                .SetDisplay("Calcification")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Calcification")
                                )
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            //- Calcification
                            ,
                            //+ CatheterSleeves
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("CatheterSleeves")
                                .SetDisplay("Catheter sleeves")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Catheter sleeves")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- CatheterSleeves
                            ,
                            //+ ChemotherapyPort
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("ChemotherapyPort")
                                .SetDisplay("Chemotherapy port")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Chemotherapy port")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- ChemotherapyPort
                            ,
                            //+ Clip
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Clip")
                                .SetDisplay("Clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Clip")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470342004")
                                .SetOneToMany("many")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                                .SetICD10("470342004")
                            //- AutoGen
                            //- Clip
                            ,
                            //+ Coil
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Coil")
                                .SetDisplay("Coil")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Coil")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470342004")
                                .SetOneToMany("one")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                                .SetICD10("470342004")
                            //- AutoGen
                            //- Coil
                            ,
                            //+ Glass
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Glass")
                                .SetDisplay("Glass")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Glass")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("283258005")
                                .SetSnomedDescription("ClinicalFinding | Glass in breast (Disorder)")
                                .SetICD10("283258005")
                            //- AutoGen
                            //- Glass
                            ,
                            //+ GoldSeed
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("GoldSeed")
                                .SetDisplay("Gold seed")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Gold seed")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- GoldSeed
                            ,
                            //+ GunshotWound
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("GunshotWound")
                                .SetDisplay("Gunshot wound")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Gunshot wound")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 425055008 | Gunshot entry wound (Disorder) | [0/0] | T14.8")
                            //- AutoGen
                            //- GunshotWound
                            ,
                            //+ MarkerClip
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MarkerClip")
                                .SetDisplay("Marker clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Marker clip")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                                .SetICD10("470272007")
                            //- AutoGen
                            //- MarkerClip
                            ,
                            //+ Metal
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Metal")
                                .SetDisplay("Metal")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Metal")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("283169003")
                                .SetSnomedDescription("ClinicalFinding | Metal foreign body in breast (Disorder)")
                                .SetICD10("283169003")
                            //- AutoGen
                            //- Metal
                            ,
                            //+ MetallicMarker
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MetallicMarker")
                                .SetDisplay("Metallic marker")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Metallic marker")
                                )
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                                .SetICD10("470272007")
                            //- AutoGen
                            //- MetallicMarker
                            ,
                            //+ Needle
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Needle")
                                .SetDisplay("Needle")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Needle")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- Needle
                            ,
                            //+ NippleJewelry
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("NippleJewelry")
                                .SetDisplay("Nipple jewelry")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Nipple jewelry")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedCode("80919006")
                                .SetSnomedDescription("PhysicalObject | Jewelry (Object)")
                                .SetICD10("80919006")
                                .SetComment("NEEDED ADD NIPPLE LOCATION")
                            //- AutoGen
                            //- NippleJewelry
                            ,
                            //+ Non-metallicBody
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Non-metallicBody")
                                .SetDisplay("Non-metallic body")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Non-metallic body")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- Non-metallicBody
                            ,
                            //+ Pacemaker
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Pacemaker")
                                .SetDisplay("Pacemaker")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Pacemaker")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- Pacemaker
                            ,
                            //+ SiliconeGranuloma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SiliconeGranuloma")
                                .SetDisplay("Silicone granuloma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Silicone granuloma")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- SiliconeGranuloma
                            ,
                            //+ Sponge
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Sponge")
                                .SetDisplay("Sponge")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Sponge")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("PhysicalObject | 706640008 | Sponge (Object)")
                            //- AutoGen
                            //- Sponge
                            ,
                            //+ SurgicalClip
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalClip")
                                .SetDisplay("Surgical clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical clip")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470342004")
                                .SetOneToMany("one")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                                .SetICD10("470342004")
                            //- AutoGen
                            //- SurgicalClip
                            ,
                            //+ Swab
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Swab")
                                .SetDisplay("Swab")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Swab")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("PhysicalObject | 408098004 | Swab (Object")
                            //- AutoGen
                            //- Swab
                            ,
                            //+ TitaniumClip
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("TitaniumClip")
                                .SetDisplay("Titanium clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Titanium clip")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetOneToMany("one")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                                .SetICD10("470272007")
                            //- AutoGen
                            //- TitaniumClip
                            ,
                            //+ TitaniumMarkerClip
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("TitaniumMarkerClip")
                                .SetDisplay("Titanium marker clip")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Titanium marker clip")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            //- TitaniumMarkerClip
                            ,
                            //+ Wire
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Wire")
                                .SetDisplay("Wire")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Wire")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- Wire
                            ,
                            //+ WireFragment
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("WireFragment")
                                .SetDisplay("Wire fragment")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Wire fragment")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            //- WireFragment
                            ,
                            //+ BBPellets
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BBPellets")
                                .SetDisplay("BB pellets")
                                .SetDefinition(new Definition()
                                    .Line("[PR] BB pellets")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedDescription("ClinicalFinding | 283574001 | Pellet wound of breast (Disorder) | [0/0] | S21.039?")
                            //- AutoGen
                            ,
                            //- BBPellets
                            //+ BiopsyClips
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BiopsyClips")
                                .SetDisplay("Biopsy clips")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Biopsy clips")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                                .SetICD10("470272007")
                            //- AutoGen
                            ,
                            //- BiopsyClips
                            //+ BreastMarkers
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("BreastMarkers")
                                .SetDisplay("Breast markers")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Breast markers")
                                )
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("470272007")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                                .SetICD10("470272007")
                            //- AutoGen
                            ,
                            //- BreastMarkers
                            //+ Calcifications
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Calcifications")
                                .SetDisplay("Calcifications")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Calcifications")
                                )
                                .ValidModalities(Modalities.MRI)
                            //- AutoGen
                            ,
                            //- Calcifications
                            //+ Clips
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Clips")
                                .SetDisplay("Clips")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Clips")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470342004")
                                .SetOneToMany("many")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                                .SetICD10("470342004")
                            //- AutoGen
                            ,
                            //- Clips
                            //+ MetallicMarkers
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MetallicMarkers")
                                .SetDisplay("Metallic markers")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Metallic markers")
                                )
                                .ValidModalities(Modalities.MRI)
                                .SetSnomedCode("470272007")
                                .SetOneToMany("many")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                                .SetICD10("470272007")
                            //- AutoGen
                            ,
                            //- MetallicMarkers
                            //+ MetallicObjects
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MetallicObjects")
                                .SetDisplay("Metallic objects")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Metallic objects")
                                )
                                .ValidModalities(Modalities.MG)
                                .SetSnomedDescription("ClinicalFinding | 283169003 | Metal foreign body in breast (Disorder) | [0/0] | S21.009?")
                            //- AutoGen
                            ,
                            //- MetallicObjects
                            //+ SurgicalClips
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("SurgicalClips")
                                .SetDisplay("Surgical clips")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Surgical clips")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470342004")
                                .SetOneToMany("one")
                                .SetSnomedDescription("PhysicalObject | Implantable tissue clip (Object)")
                                .SetICD10("470342004")
                            //- AutoGen
                            ,
                            //- SurgicalClips
                            //+ TitaniumClips
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("TitaniumClips")
                                .SetDisplay("Titanium clips")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Titanium clips")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                .SetSnomedCode("470272007")
                                .SetOneToMany("many")
                                .SetSnomedDescription("PhysicalObject | Implantable lesion localization marker (Object)")
                                .SetICD10("470272007")
                            //- AutoGen
                            ,
                            //- TitaniumClips
                             //- ForeignObjectCS
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
                        ObservationUrl,
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
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
                    .AddFragRef(Self.BiRadComponentFragment.Value())
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference( sliceElementDef, Self.ConsistentWith.Value(), 0, "*");
                e.SliceTargetReference( sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("abnormalityForeignObjectType",
                    Self.CodeAbnormalityForeignObjectType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "Foreign Object Type",
                    new Markdown()
                        .Paragraph($"This slice contains the required component that refines the foreign object type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
            });
    }
}
