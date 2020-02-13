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
                         #region Codes
                         new ConceptDef()
                             .SetCode("Amorphous")
                             .SetDisplay("Amorphous")
                             .MammoId("702")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-0176C")
                             .SetSnomedCode("129760005")
                             .SetSnomedDescription("ClinicalFinding | 129760005 | Radiographic finding " +
                                 "of amorphous calcification (Finding)")
                             .SetUMLS("Amorphous calcifications, previously known as indistinct " +
                                 "calcifications, are a morphological descriptor for " +
                                 "breast calcifications that are small and/or hazy " +
                                 "such that no clearly defined shape/form can be ascribed. ",
                                 "Many benign and malignant conditions may be seen " +
                                 "in association with these calcifications 1.Magnification " +
                                 "views (specific types of views of the breast where " +
                                 "certain areas are magnified) as part of a diagnostic " +
                                 "mammographic evaluation are required to fully assess " +
                                 "these calcifications.Amorphous calcifications are " +
                                 "small (80-200 micrometer in diameter) and/or hazy/faint, " +
                                 "such that a more specific morphologic descriptor " +
                                 "cannot be assigned. ",
                                 " ###URL#https://radiopaedia.org > articles > amorphous-calcifications-breast")
                             .SetACR("(historically, \"indistinct\")These are sufficiently " +
                                 "small and/or hazy in appearance that a more specific " +
                                 "particle shapecannot be determined. ",
                                 "Amorphous calcifications in a grouped, linear, or " +
                                 "segmental distributionare suspicious and generally " +
                                 "warrant biopsy. ",
                                 "Bilateral, diffuse amorphous calcificationsusually " +
                                 "may be dismissed as benign, although baseline magnification " +
                                 "views may be helpful.The positive predictive value " +
                                 "(PPV) of amorphous calcifications is reported to " +
                                 "beapproximately 20%. ",
                                 "Therefore, calcifications of this morphology appropriatelyshould " +
                                 "be placed into BI-RADS assessment category 4B (PPV " +
                                 "range > 10% to ? 50%).")
                         ,
                         new ConceptDef()
                             .SetCode("Coarse")
                             .SetDisplay("Coarse")
                             .MammoId("704")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01761")
                             .SetSnomedCode("129749001")
                             .SetSnomedDescription("ClinicalFinding | 129749001 | Coarse (popcorn-like) " +
                                 "radiographic calcification (Finding)")
                             .SetUMLS("The classic large 'popcorn-like' calcifications are " +
                                 "produced by involuting fibroadenomas.These calcifications " +
                                 "usually do not cause a diagnostic problem.When the " +
                                 "calcifications in an fibroadenoma are small and numerous, " +
                                 "they may resemble malignant-type calcifications and " +
                                 "need a biopsy. ",
                                 "###URL#https://radiologyassistant.nl/breast/breast-calcifications-differential-diagnosis")
                             .SetACR("These are the classic large (> 2 to 3 mm in greatest " +
                                 "diameter) calcifications produced by an involuting " +
                                 "fibroadenoma.")
                         ,
                         new ConceptDef()
                             .SetCode("Dystrophic")
                             .SetDisplay("Dystrophic")
                             .MammoId("705")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01762")
                             .SetSnomedCode("129750001")
                             .SetSnomedDescription("ClinicalFinding | 129750001 | Dystrophic radiographic " +
                                 "calcification (Finding) | [0/0] | R93.8")
                             .SetUMLS("Dystrophic soft tissue calcification is a broad term " +
                                 "that encompasses a wide range of pathologies that " +
                                 "cause soft-tissue calcification and is caused by " +
                                 "calcification of damaged tissues. ",
                                 " The amorphous calcification that results may be " +
                                 "small or large. ",
                                 " In some cases, ossification may occur - this is " +
                                 "characterized by cortical formation and a central " +
                                 "medullary cavity. ",
                                 "###URL#https://radiopaedia.org/articles/dystrophic-soft-tissue-calcification-1?lang=us")
                             .SetACR("These typically form in the irradiated breast or " +
                                 "in the breast following trauma or surgery. ",
                                 "Thecalcifications are irregular in shape, and they " +
                                 "are usually larger than 1 mm in size. ",
                                 "They oftenhave lucent centers.")
                         ,
                         new ConceptDef()
                             .SetCode("Eggshell")
                             .SetDisplay("Eggshell")
                             .MammoId("706")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01763")
                             .SetSnomedCode("129751002")
                             .SetSnomedDescription("ClinicalFinding | 129751002 | Eggshell radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("Eggshell calcifications in the breast are benign " +
                                 "peripheral rim like calcificationsThey are typically " +
                                 "secondary to fat necrosis or calcification of oil " +
                                 "cysts.thin rim-like calcification (<1 mm in thickness)lucent " +
                                 "centerssmall to several centimeters in diameter (oil " +
                                 "cyst)may disappear (fat necrosis) ###URL#https://radiopaedia.org/articles/eggshell-calcification-breast-1?lang=us")
                         ,
                         new ConceptDef()
                             .SetCode("Fine")
                             .SetDisplay("Fine")
                             .MammoId("707")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("ClinicalFinding | 129761009 | Fine, linear, (casting) " +
                                 "radiographic calcification (Finding)")
                             .SetUMLS("These are thin, linear or curvilinear irregular calcifications. ",
                                 "They may be discontinuous.")
                         ,
                         new ConceptDef()
                             .SetCode("GenericCalcification")
                             .SetDisplay("Generic calcification")
                             .MammoId("701")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("ClinicalFinding | 129748009 | Radiographic calcification " +
                                 "finding")
                             .SetUMLS("Calcification happens when calcium builds up in body " +
                                 "tissue, blood vessels, or organs. ",
                                 "This buildup can harden and disrupt your body's normal " +
                                 "processes. ",
                                 "Calcium is transported through the bloodstream. ",
                                 "It's also found in every cell. ",
                                 "As a result, calcification can occur in almost any " +
                                 "part of the body.")
                         ,
                         new ConceptDef()
                             .SetCode("CourseHeterogeneous")
                             .SetDisplay("Course Heterogeneous")
                             .MammoId("708")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-0176F")
                             .SetSnomedCode("129763007")
                             .SetSnomedDescription("ClinicalFinding | 129763007 | Heterogeneous radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("Grouped coarse heterogeneous calcifications are a " +
                                 "group of irregular and conspicuous microcalcifications, " +
                                 "smaller than dystrophic calcifications. ",
                                 "They may be associated with malignancy, but they " +
                                 "are also present in benign conditions, as fibroadenoma, " +
                                 "in areas of fibrosis or trauma. ",
                                 "###URL#https://radiopaedia.org/cases/suspicious-breast-calcifications-grouped-coarse-heterogeneous-1?lang=us")
                             .SetACR("These are irregular, conspicuous calcifications that " +
                                 "are generally between 0.5 mm and 1 mmand tend to " +
                                 "coalesce, but are smaller than dystrophic calcifications. ",
                                 "They may be associatedwith malignancy but more frequently " +
                                 "are present in a fibroadenoma or in areas of fibrosis " +
                                 "ortrauma representing evolving dystrophic calcifications. ",
                                 "Numerous bilateral groups of coarseheterogeneous " +
                                 "calcifications usually may be dismissed as benign, " +
                                 "although baseline magnificationviews may be helpful. ",
                                 "However, a single group of coarse heterogeneous calcifications " +
                                 "has a positivepredictive value of slightly less than " +
                                 "15%, and therefore this finding should beplaced in " +
                                 "BI-RADS assessment category 4B (PPV range > 10% to " +
                                 "? 50%).")
                         ,
                         new ConceptDef()
                             .SetCode("Indistinct")
                             .SetDisplay("Indistinct")
                             .MammoId("709")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("Amorphous calcifications, previously known as indistinct " +
                                 "calcifications, are a morphological descriptor for " +
                                 "breast calcifications that are small and/or hazy " +
                                 "such that no clearly defined shape/form can be ascribed. ",
                                 "###URL#https://radiopaedia.org > articles > amorphous-calcifications-breast")
                         ,
                         new ConceptDef()
                             .SetCode("LargeRodlike")
                             .SetDisplay("Large rodlike")
                             .MammoId("710")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01764")
                             .SetSnomedCode("129752009")
                             .SetSnomedDescription("ClinicalFinding | 129752009 | Large rod-like radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("These are formed within ectatic ducts.These benign " +
                                 "calcifications form continuous rods that may occasionally " +
                                 "be branching.They are different from malignant-type " +
                                 "fine branching calcifications, because they are usually " +
                                 "> 1 mm in diameter.They may have lucent centers if " +
                                 "the calcium is in the wall of the duct.These calcifications " +
                                 "follow a ductal distribution, radiating toward the " +
                                 "nipple and are usually bilateral (in both breasts).These " +
                                 "secretory calcifications are most often seen in women " +
                                 "older than 60 years.Sometimes it is difficult to " +
                                 "differentiate these from linear calcifications as " +
                                 "seen in DCIS. ",
                                 " ###URL#https://radiologyassistant.nl/breast/breast-calcifications-differential-diagnosis")
                             .SetACR("These benign calcifications associated with ductal " +
                                 "ectasia may form solid or discontinuoussmooth linear " +
                                 "rods, most of which are 0.5 mm or larger in diameter. ",
                                 "A small percentage ofthese calcifications may have " +
                                 "lucent centers if the calcium is in the wall of the " +
                                 "duct (periductal),but most are intraductal, when " +
                                 "calcification forms within the lumen of the duct. ",
                                 "All largerod-like calcifications follow a ductal " +
                                 "distribution, radiating toward the nipple, occasionallybranching. ",
                                 "The calcifications usually are bilateral, although " +
                                 "they may be seen in only onebreast, especially when " +
                                 "few calcific particles are visible. ",
                                 "These calcifications usually are seenin women older " +
                                 "than 60 years.)")
                         ,
                         new ConceptDef()
                             .SetCode("Layering")
                             .SetDisplay("Layering")
                             .MammoId("711")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("Layering of calcium within the calcification. ",
                                 "###URL#https://radiologyassistant.nl/breast/breast-calcifications-differential-diagnosis")
                         ,
                         new ConceptDef()
                             .SetCode("FineLinear")
                             .SetDisplay("Fine Linear")
                             .MammoId("712")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("ClinicalFinding | 129761009 | Fine, linear, (casting) " +
                                 "radiographic calcification (Finding)")
                             .SetUMLS("Also called fine linear branching. ",
                                 "These are thin, linear, irregular calcifications, " +
                                 "which may be discontinuous and which aresmaller than " +
                                 "0.5 mm in caliber. ",
                                 "Occasionally, branching forms may be seen. ",
                                 "Their appearancesuggests filling of the lumen of " +
                                 "a duct or ducts involved irregularly by breast cancer. ",
                                 "###ACRMG#66")
                         ,
                         new ConceptDef()
                             .SetCode("Lucent-centered")
                             .SetDisplay("Lucent-centered")
                             .MammoId("713")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01766")
                             .SetSnomedCode("129754005")
                             .SetSnomedDescription("ClinicalFinding | 129754005 | Lucent-centered radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("These are round or oval calcifications that range " +
                                 "from under 1 mm to over a centimeter.They are the " +
                                 "result of fat necrosis, calcified debris in ducts, " +
                                 "and occasional fibroadenomas.###URL#https://radiologyassistant.nl/breast/breast-calcifications-differential-diagnosis")
                         ,
                         new ConceptDef()
                             .SetCode("MilkOfCalcium")
                             .SetDisplay("Milk of calcium")
                             .MammoId("714")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01765")
                             .SetSnomedCode("129753004")
                             .SetSnomedDescription("ClinicalFinding | 129753004 | Milk of calcium radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("These are benign sedimented calcifications in macro- " +
                                 "or microcysts.On craniocaudad views (a specific type " +
                                 "of view of the breast in radiology) they appear as " +
                                 "fuzzy, round or amorphous.On a 90 degree lateral " +
                                 "view  (another specific type of view of the breast " +
                                 "in radiology) they may appear as semilunar, crescent " +
                                 "shaped tea cups. ",
                                 "###URL#https://radiologyassistant.nl/breast/breast-calcifications-differential-diagnosis")
                             .SetACR("This is a manifestation of sedimented calcifications " +
                                 "in macro- or microcysts, usually but notalways grouped. ",
                                 "On the craniocaudal image they are often less evident " +
                                 "and appear as round,smudgy deposits, while occasionally " +
                                 "on MLO and especially on 90 lateral (LM/ML) views,they " +
                                 "are more clearly defined and often semilunar, crescent " +
                                 "shaped, curvilinear (concave up),or linear, defining " +
                                 "the dependent portion of cysts. ",
                                 "The most important feature of these calcificationsis " +
                                 "the apparent change in shape of the calcific particles " +
                                 "on different mammographicprojections (craniocaudal " +
                                 "versus occasionally the MLO view and especially LM/ML " +
                                 "views). ",
                                 "Attimes milk of calcium calcifications are seen adjacent " +
                                 "to other types of calcifications that maybe associated " +
                                 "with malignancy, so it is important to search for " +
                                 "more suspicious forms, especially those that do not " +
                                 "change shape from the 90 lateral projection to the " +
                                 "CC projection.")
                         ,
                         new ConceptDef()
                             .SetCode("FinePleomorphic")
                             .SetDisplay("Fine Pleomorphic")
                             .MammoId("715")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("111344")
                             .SetSnomedDescription("not found")
                             .SetUMLS("These calcifications are usually more conspicuous " +
                                 "than amorphous forms and are seen to havediscrete " +
                                 "shapes. ",
                                 "These irregular calcifications are distinguished " +
                                 "from fine linear and fine-linearbranching forms by " +
                                 "the absence of fine-linear particles. ",
                                 "Fine pleomorphic calcifications vary insize and shape " +
                                 "and are usually smaller than 0.5 mm in diameter. ",
                                 "###ACRMG#64")
                         ,
                         new ConceptDef()
                             .SetCode("Punctate")
                             .SetDisplay("Punctate")
                             .MammoId("716")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01767")
                             .SetSnomedCode("129755006")
                             .SetSnomedDescription("ClinicalFinding | 129755006 | Punctate radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("Calcification is punctate/round. ",
                                 "It's different than a \"round\" calcification though " +
                                 "as it also means the calcifications are less than " +
                                 ".5 mm in size. ",
                                 "May warrant a probably benign (non-cancer) assessment " +
                                 "unless there is also a linear pattern or in a segmental " +
                                 "distibution. ",
                                 "This may require and imaging guided biopy or mammographic " +
                                 "surveillance. ",
                                 " ###ACRMG#")
                         ,
                         new ConceptDef()
                             .SetCode("Rim")
                             .SetDisplay("Rim")
                             .MammoId("717")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("not found")
                             .SetUMLS("Eggshell or Rim CalcificationsThese are very thin " +
                                 "benign calcifications that appear as calcium is deposited " +
                                 "on the surface of a sphere. ",
                                 "Fat necrosis and calcifications in the walls of cysts " +
                                 "are the most common \"rim\"calcifications, although more " +
                                 "extensive (and occasionally thicker-rimmed) calcification " +
                                 "in thewalls of oil cysts or simple cysts may be seen. ",
                                 "###ACRMG#49")
                         ,
                         new ConceptDef()
                             .SetCode("Round")
                             .SetDisplay("Round")
                             .MammoId("718")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-01768")
                             .SetSnomedCode("129756007")
                             .SetSnomedDescription("ClinicalFinding | 129756007 | Round shaped radiographic " +
                                 "calcification (Finding)")
                             .SetUMLS("Round calcifications are 0.5-1 mm in size and frequently " +
                                 "form in the acini of the terminal duct lobular unit.When " +
                                 "smaller than 0.5 mm, the term 'punctate' is used.Round " +
                                 "and punctate calcifications can be seen in fibrocystic " +
                                 "changes or adenosis, skin calcifications, skin talc " +
                                 "and rarely in DCIS.###URL#https://radiologyassistant.nl/breast/breast-calcifications-differential-diagnosis")
                             .SetACR("When multiple, they may vary in size and therefore " +
                                 "also in opacity. ",
                                 "They may be consideredbenign when diffuse and small " +
                                 "(< 1 mm), and are frequently formed in the acini " +
                                 "of lobules. ",
                                 "Whensmaller than 0.5 mm, the term \"punctate\" should " +
                                 "be used.An isolated group of punctate calcifications " +
                                 "may warrant probably benign assessment andmammographic " +
                                 "surveillance if no prior examinations are available " +
                                 "for comparison, orimage-guided biopsy if the group " +
                                 "is new, increasing, linear or segmental in distribution, " +
                                 "or ifadjacent to a known cancer.")
                         ,
                         new ConceptDef()
                             .SetCode("Skin")
                             .SetDisplay("Skin")
                             .MammoId("719")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("ClinicalFinding | 129757003 | Radiographic finding " +
                                 "of calcified skin of breast (Finding) | [0/0] | R92")
                             .SetUMLS("These are usually lucent-centered and pathognomonic " +
                                 "in their appearance. ",
                                 "Skin calcifications are most commonly seen along " +
                                 "the inframammary fold, parasternally, overlying the " +
                                 "axilla and around the areola. ",
                                 "The individual calcific particles usually are tightly " +
                                 "grouped, with individualgroups smaller than 5 mm " +
                                 "in greatest dimension. ",
                                 "Skin calcifications may develop from a degenerative " +
                                 "metaplastic process. ",
                                 "###ACRMG#36")
                         ,
                         new ConceptDef()
                             .SetCode("Spherical")
                             .SetDisplay("Spherical")
                             .MammoId("720")
                             .ValidModalities(Modalities.MG)
                             .SetSnomedDescription("QualifierValue | 34258004 | Spherical shape (Qualifier) " +
                                 "+")
                             .SetUMLS("Calcifications that have formed a  spherical shape " +
                                 "are usually associated with benign lesions. ",
                                 "###ACRMG#")
                         ,
                         new ConceptDef()
                             .SetCode("Suture")
                             .SetDisplay("Suture")
                             .MammoId("721")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-0176A")
                             .SetSnomedCode("129758008")
                             .SetSnomedDescription("ClinicalFinding | 129758008 | Radiographic finding " +
                                 "of calcified suture material (Finding)")
                             .SetUMLS("These are typically linear or tubular in appearance, " +
                                 "and when present in Mammogram, may show up in a knot " +
                                 "pattern.")
                             .SetACR("These represent calcium deposited on suture material. ",
                                 "They are typically linear or tubular inappearance " +
                                 "and when present, knots are frequently visible.")
                         ,
                         new ConceptDef()
                             .SetCode("Vascular")
                             .SetDisplay("Vascular")
                             .MammoId("722")
                             .ValidModalities(Modalities.MG)
                             .SetDicom("F-0176B")
                             .SetSnomedDescription("ClinicalFinding | 396779001 | Breast arterial calcification " +
                                 "(Finding) | [0/0] | R92.1")
                             .SetUMLS("These are linear or form parallel tracks, that are " +
                                 "usually clearly associated with blood vessels.Vascular " +
                                 "calcifications noted in womenOn the left typical " +
                                 "vascular calcifications.If only one side of a vessel " +
                                 "is calcified, the calcification may simulate intraductal " +
                                 "(across a group of milk ducts) calcification.###URL#https://radiologyassistant.nl/breast/breast-calcifications-differential-diagnosis")
                             .SetACR("Parallel tracks, or linear tubular calcifications " +
                                 "that are clearly associated with blood vessels.While " +
                                 "most vascular calcification is not difficult to identify, " +
                                 "if only a few discontinuous calcificparticles are " +
                                 "visible in a single location and if association with " +
                                 "a tubular structure isquestionable, then additional " +
                                 "spot-compression magnification views may be needed " +
                                 "to further characterizetheir nature.")
                         #endregion // Codes
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
                    .AddFragRef(Self.ObservationComponentNotPreviouslySeenFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedCountFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedSizeFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedDistributionFragment.Value())
                    .AddFragRef(Self.ObservationComponentCorrespondsWithFragment.Value())
                    .AddFragRef(Self.ObservationComponentPreviouslyDemonstratedByFragment.Value())

                    .AddFragRef(Self.ObservationHasMemberAssociatedFeaturesFragment.Value())
                    .AddFragRef(Self.ObservationHasMemberConsistentWithFragment.Value())
                    .Description("Calcification Observation",
                        new Markdown()
                    )
                    ;

                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeMGAbnormalityCalcification.ToCodeableConcept().ToPattern());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    //+ IntroDocDescription
                        .Description("Calcifications usually can't be felt, but they appear " +
                            "on a mammogram. ",
                            "Depending on how they're clustered and their shape, " +
                            "size, and number, further tests may be recommended. ",
                            "Larger \"macrocalcifications\" are usually not associated " +
                            "with cancer.")
                    //- IntroDocDescription
                    ;

                e.StartComponentSliceing();

                e.ComponentSliceCodeableConcept("calcificationType",
                    Self.MGComponentSliceCodeCalcificationType.ToCodeableConcept(),
                    Self.MGCalcificationTypeVS.Value(),
                    BindingStrength.Required,
                    0,
                    "1",
                    "Calcification Type",
                    "refines the calcification type");

                e.ComponentSliceCodeableConcept("calcificationDistribution",
                    Self.MGCodeCalcificationDistribution.ToCodeableConcept(),
                    Self.CalcificationDistributionVS.Value(),
                    BindingStrength.Required,
                    0,
                    "1",
                    "Calcification Distribution",
                    "defines the calcification distribution");
            });
    }
}
