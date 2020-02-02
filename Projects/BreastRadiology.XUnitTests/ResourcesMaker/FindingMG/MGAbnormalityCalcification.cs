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
                    new ConceptDef("Diffuse",
                        "Diffuse Calcification Distribution",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("(historically, \"scattered\")")
                            .Text("These are calcifications that are distributed randomly throughout the breast. Punctate and")
                            .Text("amorphous calcifications in this distribution are almost always benign, especially if bilateral.")
                        .CiteEnd()
                    ),
                    new ConceptDef("Regional ",
                        "Regional  Calcification Distribution",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("This descriptor is used for numerous calcifications that occupy a large portion of breast tissue")
                            .Text("(more than 2 cm in greatest dimension), not conforming to a duct distribution. Since this")
                            .Text("distribution may involve most of a quadrant or even more than a single quadrant, malignancy")
                            .Text("is less likely. However, overall evaluation of regional calcifications must include particle shape")
                            .Text("(morphology) as well as distribution.")
                        .CiteEnd()
                    ),
                    new ConceptDef("Grouped ",
                        "Grouped  Calcification Distribution",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("(historically, \"clustered\")")
                            .Text("This term should be used when relatively few calcifications occupy a small portion of breast")
                            .Text("tissue. The lower limit for use of this descriptor is usually when 5 calcifications are grouped")
                            .Text("within 1 cm of each other or when a definable pattern is identified. The upper limit for use")
                            .Text("of this descriptor is when larger numbers of calcifications are grouped within 2 cm of each other.")
                        .CiteEnd()
                    ),
                    new ConceptDef("Linear ",
                        "Linear  Calcification Distribution",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("These are calcifications arrayed in a line. This distribution may elevate suspicion for malignancy,")
                            .Text("as it suggests deposits in a duct. Note that both vascular and large rod-like calcifications")
                            .Text("also are usually linear in distribution, but that these typically benign calcifications have")
                            .Text("a characteristically benign morphology.")
                        .CiteEnd()
                    ),
                    new ConceptDef("Segmental",
                        "Segmental Calcification Distribution",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("Calcifications in a segmental distribution are of concern because they suggest deposits in a")
                            .Text("duct or ducts and their branches, raising the possibility of extensive or multifocal breast cancer")
                            .Text("in a lobe or segment of the breast. Although benign causes of segmental calcifications exist")
                            .Text("(e.g. large rod-like), the smooth, rod-like morphology and large size of benign calcifications")
                            .Text("distinguish them from finer, more pleomorphic or heterogeneous malignant calcifications.")
                            .Text("A segmental distribution may elevate the degree of suspicion for calcifications such as punctate or amorphous forms.")
                        .CiteEnd()
                    )
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
                    new ConceptDef("Skin",
                        "Skin Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("These are usually lucent-centered and pathognomonic in their appearance. Skin calcifications")
                            .Text("are most commonly seen along the inframammary fold, parasternally, overlying the axilla ")
                            .Text("and around the areola. The individual calcific particles usually are tightly grouped, with individual ")
                            .Text("groups smaller than 5 mm in greatest dimension. Atypical forms may be confirmed")
                            .Text("as skin deposits by performing additional mammographic views tangential to the overlying")
                            .Text("skin. Also note that if suspicious-appearing calcifications are adjacent to a skin surface on")
                            .Text("a given mammographic view, they actually may be dermal (hence benign) in nature, so that")
                            .Text("tangential-view mammography with or without magnification should be done prior to any")
                            .Text("intervention.")
                        .CiteEnd()
                    ),
                    new ConceptDef("Vascular",
                        "Vascular Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("Parallel tracks, or linear tubular calcifications that are clearly associated with blood vessels.")
                            .Text("While most vascular calcification is not difficult to identify, if only a few discontinuous calcific")
                            .Text("particles are visible in a single location and if association with a tubular structure is")
                            .Text("questionable, then additional spot-compression magnification views may be needed to further characterize")
                            .Text("their nature.")
                        .CiteEnd()
                    ),
                    new ConceptDef("Coarse",
                        "Coarse or \"Popcorn-like\" Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("These are the classic large (> 2 to 3 mm in greatest diameter) calcifications produced by an involuting fibroadenoma.")
                        .CiteEnd()
                        ),
                    new ConceptDef("LargeRodLike",
                        "Large Rod-Like Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("These benign calcifications associated with ductal ectasia may form solid or discontinuous")
                            .Text("smooth linear rods, most of which are 0.5 mm or larger in diameter. A small percentage of")
                            .Text("these calcifications may have lucent centers if the calcium is in the wall of the duct (periductal),")
                            .Text("but most are intraductal, when calcification forms within the lumen of the duct. All large")
                            .Text("rod-like calcifications follow a ductal distribution, radiating toward the nipple, occasionally")
                            .Text("branching. The calcifications usually are bilateral, although they may be seen in only one")
                            .Text("breast, especially when few calcific particles are visible. These calcifications usually are seen")
                            .Text("in women older than 60 years.)")
                        .CiteEnd()
                        ),
                    new ConceptDef("Round",
                        "Round (Typically Benign)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("When multiple, they may vary in size and therefore also in opacity. They may be considered")
                            .Text("benign when diffuse and small (< 1 mm), and are frequently formed in the acini of lobules. When")
                            .Text("smaller than 0.5 mm, the term \"punctate\" should be used.")
                            .Text("")
                            .Text("An isolated group of punctate calcifications may warrant probably benign assessment and")
                            .Text("mammographic surveillance if no prior examinations are available for comparison, or")
                            .Text("image-guided biopsy if the group is new, increasing, linear or segmental in distribution, or if")
                            .Text("adjacent to a known cancer.")
                        .CiteEnd()
                        ),
                    new ConceptDef("Rim ",
                        "Rim  Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("(historically, \"eggshell\", \"lucent-centered\")")
                            .Text("These are thin benign calcifications that appear as calcium deposited on the surface of a")
                            .Text("sphere. The calcific deposits are usually less than 1 mm in thickness when viewed on edge.")
                            .Text("These are benign nongrouped calcifications that range from smaller than 1 mm to larger")
                            .Text("than a centimeter or more. The calcifications are round or oval, with smooth surfaces and")
                            .Text("lucent centers. Fat necrosis and calcifications in the walls of cysts are the most common \"rim\"")
                            .Text("calcifications, although more extensive (and occasionally thicker-rimmed) calcification in the")
                            .Text("walls of oil cysts or simple cysts may be seen.")
                        .CiteEnd()
                        ),
                    new ConceptDef("Dystrophic",
                        "Dystrophic Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("These typically form in the irradiated breast or in the breast following trauma or surgery. The")
                            .Text("calcifications are irregular in shape, and they are usually larger than 1 mm in size. They often")
                            .Text("have lucent centers.")
                        .CiteEnd()
                        ),
                    new ConceptDef("MilkOfCalcium",
                        "Milk of Calcium Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("This is a manifestation of sedimented calcifications in macro- or microcysts, usually but not")
                            .Text("always grouped. On the craniocaudal image they are often less evident and appear as round,")
                            .Text("smudgy deposits, while occasionally on MLO and especially on 90° lateral (LM/ML) views,")
                            .Text("they are more clearly defined and often semilunar, crescent shaped, curvilinear (concave up),")
                            .Text("or linear, defining the dependent portion of cysts. The most important feature of these calcifications")
                            .Text("is the apparent change in shape of the calcific particles on different mammographic")
                            .Text("projections (craniocaudal versus occasionally the MLO view and especially LM/ML views). At")
                            .Text("times milk of calcium calcifications are seen adjacent to other types of calcifications that may")
                            .Text("be associated with malignancy, so it is important to search for more suspicious forms, especially ")
                            .Text("those that do not change shape from the 90º lateral projection to the CC projection.")
                        .CiteEnd()
                        ),
                    new ConceptDef("Suture",
                        "Suture Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("These represent calcium deposited on suture material. They are typically linear or tubular in")
                            .Text("appearance and when present, knots are frequently visible.")
                        .CiteEnd()
                        ),
                    new ConceptDef("Amorphous",
                        "Amorphous Calcification (Suspicious Morphology)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("(historically, \"indistinct\")")
                            .Text("These are sufficiently small and/or hazy in appearance that a more specific particle shape")
                            .Text("cannot be determined. Amorphous calcifications in a grouped, linear, or segmental distribution")
                            .Text("are suspicious and generally warrant biopsy. Bilateral, diffuse amorphous calcifications")
                            .Text("usually may be dismissed as benign, although baseline magnification views may be helpful.")
                            .Text("The positive predictive value (PPV) of amorphous calcifications is reported to be")
                            .Text("approximately 20%. Therefore, calcifications of this morphology appropriately")
                            .Text("should be placed into BI-RADS® assessment category 4B (PPV range > 10% to ? 50%).")
                        .CiteEnd()
                        ),
                    new ConceptDef("CoarseHeterogeneous",
                        "Coarse Heterogeneous Calcification (Suspicious Morphology)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("These are irregular, conspicuous calcifications that are generally between 0.5 mm and 1 mm")
                            .Text("and tend to coalesce, but are smaller than dystrophic calcifications. They may be associated")
                            .Text("with malignancy but more frequently are present in a fibroadenoma or in areas of fibrosis or")
                            .Text("trauma representing evolving dystrophic calcifications. Numerous bilateral groups of coarse")
                            .Text("heterogeneous calcifications usually may be dismissed as benign, although baseline magnification")
                            .Text("views may be helpful. However, a single group of coarse heterogeneous calcifications has a positive")
                            .Text("predictive value of slightly less than 15%, and therefore this finding should be")
                            .Text("placed in BI-RADS® assessment category 4B (PPV range > 10% to ? 50%).")
                        .CiteEnd()
                        ),
                    new ConceptDef("Fine Pleomorphic",
                        "Fine Pleomorphic Calcification (Suspicious Morphology)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("These calcifications are usually more conspicuous than amorphous forms and are seen to have")
                            .Text("discrete shapes. These irregular calcifications are distinguished from fine linear and fine-linear")
                            .Text("branching forms by the absence of fine-linear particles. Fine pleomorphic calcifications vary in")
                            .Text("size and shape and are usually smaller than 0.5 mm in diameter. They have a somewhat higher")
                            .Text("PPV for malignancy (29%) than amorphous or coarse heterogeneous calcifications,")
                            .Text("but also should be placed in BI-RADS® assessment category 4B (PPV range > 10% to ? 50%).")
                        .CiteEnd()
                    ),
                    new ConceptDef("FineLinear",
                        "Fine Linear or Fine-Linear Branching Calcification (Suspicious Morphology)",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("These are thin, linear, irregular calcifications, which may be discontinuous and which are")
                            .Text("smaller than 0.5 mm in caliber. Occasionally, branching forms may be seen. Their")
                            .Text("appearance suggests filling of the lumen of a duct or ducts involved irregularly by")
                            .Text("breast cancer. Among the suspicious calcifications, fine linear and fine-linear")
                            .Text("branching calcifications have the highest PPV (70%). Therefore, these calcifications")
                            .Text("should be placed in BI-RADS® assessment category 4C (PPV range > 50% to < 95%).")
                        .CiteEnd()
                        )
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
