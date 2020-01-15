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
                            new ConceptDef("AxillaryAdenopathy",
                                "Axillary adenopathy",
                                new Definition()
                                    .Line("[PR] Axillary adenopathy")
                                    .CiteStart()
                                    .Line("Enlarged axillary lymph nodes may warrant comment, clinical correlation, and additional ")
                                    .Line("evaluation, especially if new or considerably larger or rounder when compared to previous examination.")
                                    .Line("A review of the patient’s medical history may elucidate the cause for axillary adenopathy, averting")
                                    .Line("recommendation for additional evaluation. When one or more large axillary nodes are ")
                                    .Line("substantially composed of fat, this is a normal variant.")
                                    .CiteEnd(BiRadCitation)
                                    .ValidModalities(Modalities.MG | Modalities.MRI)
                                ),
                            new ConceptDef("BiopsyClip",
                                "Biopsy clip",
                                new Definition()
                                    .Line("[PR] Biopsy clip")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("BrachytherapyTube",
                                "Brachytherapy tube",
                                new Definition()
                                    .Line("[PR] Brachytherapy tube")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("ChestWallInvasion",
                                "Chest wall invasion",
                                new Definition()
                                    .Line("[PR] Chest wall invasion")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("CooperDistorted",
                                "Cooper distorted",
                                new Definition()
                                    .Line("[PR] Cooper distorted")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("CooperThickened",
                                "Cooper thickened",
                                new Definition()
                                    .Line("[PR] Cooper thickened")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("Edema",
                                "Edema",
                                new Definition()
                                    .Line("[PR] Edema")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("EdemaAdj",
                                "Edema adj",
                                new Definition()
                                    .Line("[PR] Edema adj")
                                    .ValidModalities(Modalities.US)
                                ),
                            new ConceptDef("GoldSeed",
                                "Gold Seed",
                                new Definition()
                                    .Line("[PR] Gold Seed")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Hematoma",
                                "Hematoma",
                                new Definition()
                                    .Line("[PR] Hematoma")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("NippleRetraction",
                                "Nipple retraction",
                                new Definition()
                                    .CiteStart()
                                    .Line("The nipple is pulled in. This should not be confused with nipple inversion, which is often bilateral ")
                                    .Line("and which in the absence of any suspicious findings and when stable for a long period of time, ")
                                    .Line("is not a sign of malignancy. However, if nipple retraction is new, suspicion for underlying malignancy is increased.")
                                    .CiteEnd(BiRadCitation)
                                   .ValidModalities(Modalities.MG | Modalities.MRI)
                                ),
                            new ConceptDef("NOChestWallInvasion",
                                "NO Chest wall invasion",
                                new Definition()
                                    .Line("[PR] NO Chest wall invasion")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            new ConceptDef("PectoralisMuscleInvasion",
                                "Pectoralis muscle invasion",
                                new Definition()
                                    .Line("[PR] Pectoralis muscle invasion")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("PectoralisMuscleInvolvement",
                                "Pectoralis muscle involvement",
                                new Definition()
                                    .Line("[PR] Pectoralis muscle involvement")
                                    .ValidModalities(Modalities.MRI)
                                ),
                            new ConceptDef("PectoralisMuscleTenting",
                                "Pectoralis muscle tenting",
                                new Definition()
                                    .Line("[PR] Pectoralis muscle tenting")
                                    .ValidModalities(Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("PostSurgicalScar",
                                "Post surgical scar",
                                new Definition()
                                    .Line("[PR] Post surgical scar")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("Seroma",
                                "Seroma",
                                new Definition()
                                    .Line("[PR] Seroma")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("SkinInvolvement",
                                "Skin involvement",
                                new Definition()
                                    .Line("[PR] Skin involvement")
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("SkinLesion",
                                "Skin lesion",
                                new Definition()
                                    .CiteStart()
                                    .Line("This finding may be described in the mammography report or annotated on the mammographic")
                                    .Line("image when it projects over the breast (especially on 2 different projections), and may be mistaken")
                                    .Line("for an intramammary lesion. A raised skin lesion sufficiently large to be seen at mammography")
                                    .Line("should be marked by the technologist with a radiopaque device designated for use as a marker for")
                                    .Line("a skin lesion.")
                                    .CiteEnd(BiRadCitation)
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("SkinRetraction",
                                "Skin retraction",
                                new Definition()
                                    .CiteStart()
                                    .Line("The skin is pulled in abnormally")
                                    .CiteEnd(BiRadCitation)
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("SkinThickening",
                                "Skin thickening",
                                new Definition()
                                    .CiteStart()
                                    .Line("Skin thickening may be focal or diffuse, and is defined as being greater than 2 mm in thickness. This ")
                                    .Line("finding is of particular concern if it represents a change from previous mammography examinations. ")
                                    .Line("However, unilateral skin thickening is an expected finding after radiation therapy.")
                                    .CiteEnd(BiRadCitation)
                                    .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                                ),
                            new ConceptDef("SurgicalClip",
                                "Surgical clip",
                                new Definition()
                                    .Line("[PR] Surgical clip")
                                    .ValidModalities(Modalities.MG)
                                ),
                            new ConceptDef("TrabecularThickening",
                                "Trabecular thickening",
                                new Definition()
                                    .CiteStart()
                                    .Line("This is a thickening of the fibrous septa of the breast.")
                                    .CiteEnd(BiRadCitation)
                                    .ValidModalities(Modalities.MG)
                                )
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
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Intro(vs.Description)
                ;
                String outputPath = valueSetIntroDoc.Save();
                Self.fc?.Mark(outputPath);
            }
            );

        SDTaskVar ObservedFeature = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.ObservedFeatureVS.Value();

                SDefEditor e = Self.CreateEditorObservationLeaf("ObservedFeature",
                    "Observed Feature",
                    "Observed Feature",
                    $"{Group_CommonResources}/AssociatedFeature/ObservedFeature")
                    .Description("Observed Feature Observation",
                        new Markdown()
                            .Paragraph("The feature observed is defined by the codeable concept in the value[x] field.")
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
                    ;
                s = e.SDef;
                e.Select("value[x]").Zero();
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("featureType",
                    Self.CodeObservedFeatureType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "Observed Feature Type");
                Self.ComponentSliceObservedCountRange(e);
            });
    }
}
