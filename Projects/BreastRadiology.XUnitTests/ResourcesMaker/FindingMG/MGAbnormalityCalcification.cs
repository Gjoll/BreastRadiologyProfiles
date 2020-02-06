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
        //# TODO: get from gg
        CSTaskVar MGCalcificationDistributionCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "MammoCalcificationDistributionCS",
                     "Mammography Calcification Distribution CodeSystem",
                     "MG Calc./Distribution/CodeSystem",
                     "Mammography calcification distribution code system.",
                     Group_MGCodesCS,
                     new ConceptDef[]
                     {
                    new ConceptDef()
                        .SetCode("Diffuse", "Diffuse Calcification Distribution")
                        .BiRadsDef("(historically, \"scattered\")",
                                       "These are calcifications that are distributed randomly throughout the breast. Punctate and",
                                        "amorphous calcifications in this distribution are almost always benign, especially if bilateral."),
                    new ConceptDef()
                        .SetCode("Regional ", "Regional  Calcification Distribution")
                        .BiRadsDef("This descriptor is used for numerous calcifications that occupy a large portion of breast tissue",
                                   "(more than 2 cm in greatest dimension), not conforming to a duct distribution. Since this",
                                   "distribution may involve most of a quadrant or even more than a single quadrant, malignancy",
                                   "is less likely. However, overall evaluation of regional calcifications must include particle shape",
                                   "(morphology) as well as distribution."),
                    new ConceptDef()
                        .SetCode("Grouped ", "Grouped  Calcification Distribution")
                        .BiRadsDef("(historically, \"clustered\")",
                                   "This term should be used when relatively few calcifications occupy a small portion of breast",
                                   "tissue. The lower limit for use of this descriptor is usually when 5 calcifications are grouped",
                                   "within 1 cm of each other or when a definable pattern is identified. The upper limit for use",
                                   "of this descriptor is when larger numbers of calcifications are grouped within 2 cm of each other."),
                    new ConceptDef()
                        .SetCode("Linear ", "Linear  Calcification Distribution")
                        .BiRadsDef("These are calcifications arrayed in a line. This distribution may elevate suspicion for malignancy,",
                                   "as it suggests deposits in a duct. Note that both vascular and large rod-like calcifications",
                                   "also are usually linear in distribution, but that these typically benign calcifications have",
                                   "a characteristically benign morphology."),
                    new ConceptDef()
                        .SetCode("Segmental", "Segmental Calcification Distribution")
                        .BiRadsDef("Calcifications in a segmental distribution are of concern because they suggest deposits in a",
                                   "duct or ducts and their branches, raising the possibility of extensive or multifocal breast cancer",
                                   "in a lobe or segment of the breast. Although benign causes of segmental calcifications exist",
                                   "(e.g. large rod-like), the smooth, rod-like morphology and large size of benign calcifications",
                                   "distinguish them from finer, more pleomorphic or heterogeneous malignant calcifications.",
                                   "A segmental distribution may elevate the degree of suspicion for calcifications such as punctate or amorphous forms.")
                     }
                 ));


        VSTaskVar MGCalcificationDistributionVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "MammoCalcificationDistributionVS",
                        "Mammography Calcification Distribution ValueSet",
                        "MG Calc./DistributionValueSet",
                        "Mammography calcification distribution value set.",
                        Group_MGCodesVS,
                        Self.MGCalcificationDistributionCS.Value()
                    )
            );

        CSTaskVar MGCalcificationTypeCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "MammoCalcificationTypeCS",
                     "Mammography Calcification Type CodeSystem",
                     "MG Calc. Type/CodeSystem",
                     "Mammography calcification type code system.",
                     Group_MGCodesCS,
                     new ConceptDef[]
                     {
                         //+ Type
                         //+ Amorphous
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Amorphous")
                             .SetDisplay("Amorphous")
                             .SetDefinition("[PR] Amorphous")
                             .MammoId("702")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-0176C")
                             .SetSnomedCode("129760005")
                             .SetSnomedDescription("ClinicalFinding | 129760005 | Radiographic finding " +
                                 "of amorphous calcification (Finding)")
                             .SetUMLS("C1268685")
                         //- AutoGen
                             .BiRadsDef("(historically, \"indistinct\")",
                                 "These are sufficiently small and/or hazy in appearance that a more specific particle shape",
                                 "cannot be determined. Amorphous calcifications in a grouped, linear, or segmental distribution",
                                 "are suspicious and generally warrant biopsy. Bilateral, diffuse amorphous calcifications",
                                 "usually may be dismissed as benign, although baseline magnification views may be helpful.",
                                 "The positive predictive value (PPV) of amorphous calcifications is reported to be",
                                 "approximately 20%. Therefore, calcifications of this morphology appropriately",
                                 "should be placed into BI-RADS� assessment category 4B (PPV range > 10% to ? 50%).")
                         ,
                         //- Amorphous
                         //+ Coarse
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Coarse")
                             .SetDisplay("Coarse")
                             .SetDefinition("[PR] Coarse")
                             .MammoId("704")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01761")
                             .SetSnomedCode("129749001")
                             .SetSnomedDescription("ClinicalFinding | 129749001 | Coarse (popcorn-like) " +
                                 "radiographic calcification (Finding)")
                             .SetUMLS("C1268677")
                         //- AutoGen
                             .BiRadsDef("These are the classic large (> 2 to 3 mm in greatest diameter) calcifications produced by an involuting fibroadenoma.")
                         ,
                         //- Coarse
                         //+ Dystrophic
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Dystrophic")
                             .SetDisplay("Dystrophic")
                             .SetDefinition("[PR] Dystrophic")
                             .MammoId("705")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01762")
                             .SetSnomedCode("129750001")
                             .SetSnomedDescription("ClinicalFinding | 129750001 | Dystrophic radiographic " +
                                 "calcification (Finding) | [0/0] | R93.8")
                             .SetUMLS("C0333582")
                         //- AutoGen
                             .BiRadsDef("These typically form in the irradiated breast or in the breast following trauma or surgery. The",
                                 "calcifications are irregular in shape, and they are usually larger than 1 mm in size. They often",
                                 "have lucent centers.")
                         ,
                         //- Dystrophic
                         //+ Eggshell
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Eggshell")
                             .SetDisplay("Eggshell")
                             .SetDefinition("[PR] Eggshell")
                             .MammoId("706")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01763")
                             .SetSnomedCode("129751002")
                             .SetSnomedDescription("ClinicalFinding | 129751002 | Eggshell radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("C1313950")
                         //- AutoGen
                         ,
                         //- Eggshell
                         //+ FineADDPrefix
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("FineADDPrefix")
                             .SetDisplay("Fine ADD prefix ")
                             .SetDefinition("[PR] Fine ADD prefix ")
                             .MammoId("707")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("ClinicalFinding | 129761009 | Fine, linear, (casting) " +
                                 "radiographic calcification (Finding)")
                         //- AutoGen
                         ,
                         //- FineADDPrefix
                         //+ GenericCalcification
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("GenericCalcification")
                             .SetDisplay("Generic calcification")
                             .SetDefinition("[PR] Generic calcification")
                             .MammoId("701")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("ClinicalFinding | 129748009 | Radiographic calcification " +
                                 "finding")
                             .SetUMLS("Calcification happens when calcium builds up in body " +
                                 "tissue, blood vessels, or organs. This buildup can " +
                                 "harden and disrupt your body’s normal processes. " +
                                 "Calcium is transported through the bloodstream. It’s " +
                                 "also found in every cell. As a result, calcification " +
                                 "can occur in almost any part of the body.")
                         //- AutoGen
                         ,
                         //- GenericCalcification
                         //+ HeterogeneousADDPrefixCourse
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("HeterogeneousADDPrefixCourse")
                             .SetDisplay("Heterogeneous ADD prefix course")
                             .SetDefinition("[PR] Heterogeneous ADD prefix course")
                             .MammoId("708")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-0176F")
                             .SetSnomedCode("129763007")
                             .SetSnomedDescription("ClinicalFinding | 129763007 | Heterogeneous radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("C1268688")
                         //- AutoGen
                             .BiRadsDef("These are irregular, conspicuous calcifications that are generally between 0.5 mm and 1 mm",
                                 "and tend to coalesce, but are smaller than dystrophic calcifications. They may be associated",
                                 "with malignancy but more frequently are present in a fibroadenoma or in areas of fibrosis or",
                                 "trauma representing evolving dystrophic calcifications. Numerous bilateral groups of coarse",
                                 "heterogeneous calcifications usually may be dismissed as benign, although baseline magnification",
                                 "views may be helpful. However, a single group of coarse heterogeneous calcifications has a positive",
                                 "predictive value of slightly less than 15%, and therefore this finding should be",
                                 "placed in BI-RADS� assessment category 4B (PPV range > 10% to ? 50%).")
                         ,
                         //- HeterogeneousADDPrefixCourse
                         //+ Indistinct
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Indistinct")
                             .SetDisplay("Indistinct")
                             .SetDefinition("[PR] Indistinct")
                             .MammoId("709")
                             .ValidModalities(Modalities.MG)
                         //- AutoGen
                         ,
                         //- Indistinct
                         //+ LargeRodlike
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("LargeRodlike")
                             .SetDisplay("Large rodlike")
                             .SetDefinition("[PR] Large rodlike")
                             .MammoId("710")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01764")
                             .SetSnomedCode("129752009")
                             .SetSnomedDescription("ClinicalFinding | 129752009 | Large rod-like radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("C1268678")
                         //- AutoGen
                             .BiRadsDef("These benign calcifications associated with ductal ectasia may form solid or discontinuous",
                                 "smooth linear rods, most of which are 0.5 mm or larger in diameter. A small percentage of",
                                 "these calcifications may have lucent centers if the calcium is in the wall of the duct (periductal),",
                                 "but most are intraductal, when calcification forms within the lumen of the duct. All large",
                                 "rod-like calcifications follow a ductal distribution, radiating toward the nipple, occasionally",
                                 "branching. The calcifications usually are bilateral, although they may be seen in only one",
                                 "breast, especially when few calcific particles are visible. These calcifications usually are seen",
                                 "in women older than 60 years.)")
                         ,
                         //- LargeRodlike
                         //+ Layering
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Layering")
                             .SetDisplay("Layering")
                             .SetDefinition("[PR] Layering")
                             .MammoId("711")
                             .ValidModalities(Modalities.MG)
                         //- AutoGen
                         ,
                         //- Layering
                         //+ LinearADDPrefixFine
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("LinearADDPrefixFine")
                             .SetDisplay("Linear ADD prefix fine")
                             .SetDefinition("[PR] Linear ADD prefix fine")
                             .MammoId("712")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("ClinicalFinding | 129761009 | Fine, linear, (casting) " +
                                 "radiographic calcification (Finding)")
                         //- AutoGen
                             .BiRadsDef("These are thin, linear, irregular calcifications, which may be discontinuous and which are",
                                 "smaller than 0.5 mm in caliber. Occasionally, branching forms may be seen. Their",
                                 "appearance suggests filling of the lumen of a duct or ducts involved irregularly by",
                                 "breast cancer. Among the suspicious calcifications, fine linear and fine-linear",
                                 "branching calcifications have the highest PPV (70%). Therefore, these calcifications",
                                 "should be placed in BI-RADS� assessment category 4C (PPV range > 50% to < 95%).")
                         ,
                         //- LinearADDPrefixFine
                         //+ Lucent-centered
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Lucent-centered")
                             .SetDisplay("Lucent-centered")
                             .SetDefinition("[PR] Lucent-centered")
                             .MammoId("713")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01766")
                             .SetSnomedCode("129754005")
                             .SetSnomedDescription("ClinicalFinding | 129754005 | Lucent-centered radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("C1268680")
                         //- AutoGen
                         ,
                         //- Lucent-centered
                         //+ MilkOfCalcium
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("MilkOfCalcium")
                             .SetDisplay("Milk of calcium")
                             .SetDefinition("[PR] Milk of calcium")
                             .MammoId("714")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01765")
                             .SetSnomedCode("129753004")
                             .SetSnomedDescription("ClinicalFinding | 129753004 | Milk of calcium radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("C1268679")
                         //- AutoGen
                             .BiRadsDef("This is a manifestation of sedimented calcifications in macro- or microcysts, usually but not",
                                 "always grouped. On the craniocaudal image they are often less evident and appear as round,",
                                 "smudgy deposits, while occasionally on MLO and especially on 90� lateral (LM/ML) views,",
                                 "they are more clearly defined and often semilunar, crescent shaped, curvilinear (concave up),",
                                 "or linear, defining the dependent portion of cysts. The most important feature of these calcifications",
                                 "is the apparent change in shape of the calcific particles on different mammographic",
                                 "projections (craniocaudal versus occasionally the MLO view and especially LM/ML views). At",
                                 "times milk of calcium calcifications are seen adjacent to other types of calcifications that may",
                                 "be associated with malignancy, so it is important to search for more suspicious forms, especially ",
                                 "those that do not change shape from the 90� lateral projection to the CC projection.")
                         ,
                         //- MilkOfCalcium
                         //+ PleomorphicADDPrefixFine
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("PleomorphicADDPrefixFine")
                             .SetDisplay("Pleomorphic ADD prefix fine")
                             .SetDefinition("[PR] Pleomorphic ADD prefix fine")
                             .MammoId("715")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("111344")
                             .SetSnomedDescription("not found")
                             .SetComment("not found")
                         //- AutoGen
                             .BiRadsDef("These calcifications are usually more conspicuous than amorphous forms and are seen to have",
                                 "discrete shapes. These irregular calcifications are distinguished from fine linear and fine-linear",
                                 "branching forms by the absence of fine-linear particles. Fine pleomorphic calcifications vary in",
                                 "size and shape and are usually smaller than 0.5 mm in diameter. They have a somewhat higher",
                                 "PPV for malignancy (29%) than amorphous or coarse heterogeneous calcifications,",
                                 "but also should be placed in BI-RADS� assessment category 4B (PPV range > 10% to ? 50%).")
                         ,
                         //- PleomorphicADDPrefixFine
                         //+ Punctate
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Punctate")
                             .SetDisplay("Punctate")
                             .SetDefinition("[PR] Punctate")
                             .MammoId("716")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01767")
                             .SetSnomedCode("129755006")
                             .SetSnomedDescription("ClinicalFinding | 129755006 | Punctate radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("C1265883")
                         //- AutoGen
                         ,
                         //- Punctate
                         //+ Rim
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Rim")
                             .SetDisplay("Rim")
                             .SetDefinition("[PR] Rim")
                             .MammoId("717")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("not found")
                             .SetComment("not found")
                         //- AutoGen
                             .BiRadsDef("(historically, \"eggshell\", \"lucent-centered\")",
                                 "These are thin benign calcifications that appear as calcium deposited on the surface of a",
                                 "sphere. The calcific deposits are usually less than 1 mm in thickness when viewed on edge.",
                                 "These are benign nongrouped calcifications that range from smaller than 1 mm to larger",
                                 "than a centimeter or more. The calcifications are round or oval, with smooth surfaces and",
                                 "lucent centers. Fat necrosis and calcifications in the walls of cysts are the most common \"rim\"",
                                 "calcifications, although more extensive (and occasionally thicker-rimmed) calcification in the",
                                 "walls of oil cysts or simple cysts may be seen.")
                         ,
                         //- Rim
                         //+ Round
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Round")
                             .SetDisplay("Round")
                             .SetDefinition("[PR] Round")
                             .MammoId("718")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01768")
                             .SetSnomedCode("129756007")
                             .SetSnomedDescription("ClinicalFinding | 129756007 | Round shaped radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("C1268681")
                         //- AutoGen
                             .BiRadsDef("When multiple, they may vary in size and therefore also in opacity. They may be considered",
                                 "benign when diffuse and small (< 1 mm), and are frequently formed in the acini of lobules. When",
                                 "smaller than 0.5 mm, the term \"punctate\" should be used.",
                                 "An isolated group of punctate calcifications may warrant probably benign assessment and",
                                 "mammographic surveillance if no prior examinations are available for comparison, or",
                                 "image-guided biopsy if the group is new, increasing, linear or segmental in distribution, or if",
                                 "adjacent to a known cancer.")
                         ,
                         //- Round
                         //+ Skin
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Skin")
                             .SetDisplay("Skin")
                             .SetDefinition("[PR] Skin")
                             .MammoId("719")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("ClinicalFinding | 129757003 | Radiographic finding " +
                                 "of calcified skin of breast (Finding) | [0/0] | R92")
                         //- AutoGen
                             .BiRadsDef("These are usually lucent-centered and pathognomonic in their appearance. Skin calcifications",
                                 "are most commonly seen along the inframammary fold, parasternally, overlying the axilla ",
                                 "and around the areola. The individual calcific particles usually are tightly grouped, with individual ",
                                 "groups smaller than 5 mm in greatest dimension. Atypical forms may be confirmed",
                                 "as skin deposits by performing additional mammographic views tangential to the overlying",
                                 "skin. Also note that if suspicious-appearing calcifications are adjacent to a skin surface on",
                                 "a given mammographic view, they actually may be dermal (hence benign) in nature, so that",
                                 "tangential-view mammography with or without magnification should be done prior to any",
                                 "intervention.")
                         ,
                         //- Skin
                         //+ Spherical
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Spherical")
                             .SetDisplay("Spherical")
                             .SetDefinition("[PR] Spherical")
                             .MammoId("720")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("QualifierValue | 34258004 | Spherical shape (Qualifier) " +
                                 "+")
                         //- AutoGen
                         ,
                         //- Spherical
                         //+ Suture
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Suture")
                             .SetDisplay("Suture")
                             .SetDefinition("[PR] Suture")
                             .MammoId("721")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-0176A")
                             .SetSnomedCode("129758008")
                             .SetSnomedDescription("ClinicalFinding | 129758008 | Radiographic finding " +
                                 "of calcified suture material (Finding)")
                             .SetUMLS("C1268683")
                         //- AutoGen
                             .BiRadsDef("These represent calcium deposited on suture material. They are typically linear or tubular in",
                                 "appearance and when present, knots are frequently visible.")
                         ,
                         //- Suture
                         //+ Vascular
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("Vascular")
                             .SetDisplay("Vascular")
                             .SetDefinition("[PR] Vascular")
                             .MammoId("722")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-0176B")
                             .SetSnomedDescription("ClinicalFinding | 396779001 | Breast arterial calcification " +
                                 "(Finding) | [0/0] | R92.1")
                             .SetUMLS("C1268684")
                         //- AutoGen
                             .BiRadsDef("Parallel tracks, or linear tubular calcifications that are clearly associated with blood vessels.",
                                 "While most vascular calcification is not difficult to identify, if only a few discontinuous calcific",
                                 "particles are visible in a single location and if association with a tubular structure is",
                                 "questionable, then additional spot-compression magnification views may be needed to further characterize",
                                 "their nature.")
                        
                         //- Vascular
                         //- Type
                     }
                 )
             );


        VSTaskVar MGCalcificationTypeVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "MammoCalcificationTypeVS",
                    "Mammography Calcification Type ValueSet",
                    "MG Calc. TypeValueSet",
                    "Mammography calcification types value set.",
                    Group_MGCodesVS,
                    Self.MGCalcificationTypeCS.Value()
                    )
            );

        SDTaskVar MGAbnormalityCalcification = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("MGAbnormalityCalcification",
                        "Mammography Calcification",
                        "MG Calc.",
                        Global.ObservationUrl,
                        $"{Group_MGResources}/CalcificationAbnormality",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
                    .AddFragRef(Self.ObservedSizeComponentFragment.Value())
                    .AddFragRef(Self.ObservedDistributionComponentFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
                    .Description("Calcification Observation",
                        new Markdown()
                    )
                    ;

                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeMGAbnormalityCalcification.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    .ACRDescription(
                        "Calcifications that are assessed as benign at mammography are typically larger, coarser, round with",
                        "smooth margins, and more easily seen than malignant calcifications. Calcifications associated with",
                        "malignancy (and many benign calcifications as well) are usually very small and often require the use",
                        "of magnification to be seen well. When a specific typically benign etiology cannot be assigned, a",
                        "description of calcifications should include their morphology and distribution. Calcifications that are",
                        "obviously benign need not be reported, especially if the interpreting physician is concerned that",
                        "the referring clinician or patient might infer anything other than absolute confidence in benignity",
                        "were such calcifications described in the report. However, typically benign calcifications should be",
                        "reported if the interpreting physician is concerned that other observers might misinterpret them as",
                        "anything but benign were such calcifications not described in the report.",
                        "As an ASSOCIATED FEATURE, this may be used in conjunction with one or more other FINDING(S)",
                        "to describe calcifications within or immediately adjacent to the finding(s)"
                        )
                    .MammoDescription("545")
                    ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference( sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");
                e.SliceTargetReference( sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();

                e.ComponentSliceCodeableConcept("calcificationType",
                    Self.MGComponentSliceCodeCalcificationType.ToCodeableConcept(),
                    Self.MGCalcificationTypeVS.Value(),
                    BindingStrength.Required,
                    0,
                    "1",
                    "Calcification Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the calcification type.",
                                    $"The value of this component is a codeable concept chosen from the {Self.MGCalcificationTypeVS.Value().Name} valueset.")
                    );

                e.ComponentSliceCodeableConcept("calcificationDistribution",
                    Self.MGCodeCalcificationDistribution.ToCodeableConcept(),
                    Self.MGCalcificationDistributionVS.Value(),
                    BindingStrength.Required,
                    0,
                    "1",
                    "Calcification Distribution",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that defines the calcification distribution.",
                                    $"The value of this component is a codeable concept chosen from the {Self.MGCalcificationDistributionVS.Value().Name} valueset.")
                    );
            });
    }
}
