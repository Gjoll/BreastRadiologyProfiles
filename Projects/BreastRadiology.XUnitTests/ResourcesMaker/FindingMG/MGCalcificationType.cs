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
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        async StringTask MGCalcificationType()
        {
            if (this.mgCalcificationType == null)
                await this.CreateMGCalcificationType();
            return this.mgCalcificationType;
        }
        String mgCalcificationType = null;

        async VTask CreateMGCalcificationType()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs = await this.CreateCodeSystem(
                    "MammoCalcificationType",
                    "Mammo Calcification Type",
                    "Mammo/Calc./Type/Values",
                    "Mammography calcification type codes.",
                    Group_MGCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("Skin",
                        "Skin Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart()
                            .Line("These are usually lucent-centered and pathognomonic in their appearance. Skin calcifications")
                            .Line("are most commonly seen along the inframammary fold, parasternally, overlying the axilla ")
                            .Line("and around the areola. The individual calcific particles usually are tightly grouped, with individual ")
                            .Line("groups smaller than 5 mm in greatest dimension. Atypical forms may be confirmed")
                            .Line("as skin deposits by performing additional mammographic views tangential to the overlying")
                            .Line("skin. Also note that if suspicious-appearing calcifications are adjacent to a skin surface on")
                            .Line("a given mammographic view, they actually may be dermal (hence benign) in nature, so that")
                            .Line("tangential-view mammography with or without magnification should be done prior to any")
                            .Line("intervention.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Vascular",
                        "Vascular Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart()
                            .Line("Parallel tracks, or linear tubular calcifications that are clearly associated with blood vessels.")
                            .Line("While most vascular calcification is not difficult to identify, if only a few discontinuous calcific")
                            .Line("particles are visible in a single location and if association with a tubular structure is")
                            .Line("questionable, then additional spot-compression magnification views may be needed to further characterize")
                            .Line("their nature.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Coarse",
                        "Coarse or \"Popcorn-like\" Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart()
                            .Line("These are the classic large (> 2 to 3 mm in greatest diameter) calcifications produced by an involuting fibroadenoma.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("LargeRodLike",
                        "Large Rod-Like Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart()
                            .Line("These benign calcifications associated with ductal ectasia may form solid or discontinuous")
                            .Line("smooth linear rods, most of which are 0.5 mm or larger in diameter. A small percentage of")
                            .Line("these calcifications may have lucent centers if the calcium is in the wall of the duct (periductal),")
                            .Line("but most are intraductal, when calcification forms within the lumen of the duct. All large")
                            .Line("rod-like calcifications follow a ductal distribution, radiating toward the nipple, occasionally")
                            .Line("branching. The calcifications usually are bilateral, although they may be seen in only one")
                            .Line("breast, especially when few calcific particles are visible. These calcifications usually are seen")
                            .Line("in women older than 60 years.)")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Round",
                        "Round (Typically Benign)",
                        new Definition()
                        .CiteStart()
                            .Line("When multiple, they may vary in size and therefore also in opacity. They may be considered")
                            .Line("benign when diffuse and small (< 1 mm), and are frequently formed in the acini of lobules. When")
                            .Line("smaller than 0.5 mm, the term \"punctate\" should be used.")
                            .Line("")
                            .Line("An isolated group of punctate calcifications may warrant probably benign assessment and")
                            .Line("mammographic surveillance if no prior examinations are available for comparison, or")
                            .Line("image-guided biopsy if the group is new, increasing, linear or segmental in distribution, or if")
                            .Line("adjacent to a known cancer.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Rim ",
                        "Rim  Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"eggshell\", \"lucent-centered\")")
                            .Line("These are thin benign calcifications that appear as calcium deposited on the surface of a")
                            .Line("sphere. The calcific deposits are usually less than 1 mm in thickness when viewed on edge.")
                            .Line("These are benign nongrouped calcifications that range from smaller than 1 mm to larger")
                            .Line("than a centimeter or more. The calcifications are round or oval, with smooth surfaces and")
                            .Line("lucent centers. Fat necrosis and calcifications in the walls of cysts are the most common \"rim\"")
                            .Line("calcifications, although more extensive (and occasionally thicker-rimmed) calcification in the")
                            .Line("walls of oil cysts or simple cysts may be seen.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Dystrophic",
                        "Dystrophic Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart()
                            .Line("These typically form in the irradiated breast or in the breast following trauma or surgery. The")
                            .Line("calcifications are irregular in shape, and they are usually larger than 1 mm in size. They often")
                            .Line("have lucent centers.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("MilkOfCalcium",
                        "Milk of Calcium Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart()
                            .Line("This is a manifestation of sedimented calcifications in macro- or microcysts, usually but not")
                            .Line("always grouped. On the craniocaudal image they are often less evident and appear as round,")
                            .Line("smudgy deposits, while occasionally on MLO and especially on 90° lateral (LM/ML) views,")
                            .Line("they are more clearly defined and often semilunar, crescent shaped, curvilinear (concave up),")
                            .Line("or linear, defining the dependent portion of cysts. The most important feature of these calcifications")
                            .Line("is the apparent change in shape of the calcific particles on different mammographic")
                            .Line("projections (craniocaudal versus occasionally the MLO view and especially LM/ML views). At")
                            .Line("times milk of calcium calcifications are seen adjacent to other types of calcifications that may")
                            .Line("be associated with malignancy, so it is important to search for more suspicious forms, especially ")
                            .Line("those that do not change shape from the 90º lateral projection to the CC projection.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Suture",
                        "Suture Calcification (Typically Benign)",
                        new Definition()
                        .CiteStart()
                            .Line("These represent calcium deposited on suture material. They are typically linear or tubular in")
                            .Line("appearance and when present, knots are frequently visible.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Amorphous",
                        "Amorphous Calcification (Suspicious Morphology)",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"indistinct\")")
                            .Line("These are sufficiently small and/or hazy in appearance that a more specific particle shape")
                            .Line("cannot be determined. Amorphous calcifications in a grouped, linear, or segmental distribution")
                            .Line("are suspicious and generally warrant biopsy. Bilateral, diffuse amorphous calcifications")
                            .Line("usually may be dismissed as benign, although baseline magnification views may be helpful.")
                            .Line("The positive predictive value (PPV) of amorphous calcifications is reported to be")
                            .Line("approximately 20%. Therefore, calcifications of this morphology appropriately")
                            .Line("should be placed into BI-RADS® assessment category 4B (PPV range > 10% to ? 50%).")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("CoarseHeterogeneous",
                        "Coarse Heterogeneous Calcification (Suspicious Morphology)",
                        new Definition()
                        .CiteStart()
                            .Line("These are irregular, conspicuous calcifications that are generally between 0.5 mm and 1 mm")
                            .Line("and tend to coalesce, but are smaller than dystrophic calcifications. They may be associated")
                            .Line("with malignancy but more frequently are present in a fibroadenoma or in areas of fibrosis or")
                            .Line("trauma representing evolving dystrophic calcifications. Numerous bilateral groups of coarse")
                            .Line("heterogeneous calcifications usually may be dismissed as benign, although baseline magnification")
                            .Line("views may be helpful. However, a single group of coarse heterogeneous calcifications has a positive")
                            .Line("predictive value of slightly less than 15%, and therefore this finding should be")
                            .Line("placed in BI-RADS® assessment category 4B (PPV range > 10% to ? 50%).")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Fine Pleomorphic",
                        "Fine Pleomorphic Calcification (Suspicious Morphology)",
                        new Definition()
                        .CiteStart()
                            .Line("These calcifications are usually more conspicuous than amorphous forms and are seen to have")
                            .Line("discrete shapes. These irregular calcifications are distinguished from fine linear and fine-linear")
                            .Line("branching forms by the absence of fine-linear particles. Fine pleomorphic calcifications vary in")
                            .Line("size and shape and are usually smaller than 0.5 mm in diameter. They have a somewhat higher")
                            .Line("PPV for malignancy (29%) than amorphous or coarse heterogeneous calcifications,")
                            .Line("but also should be placed in BI-RADS® assessment category 4B (PPV range > 10% to ? 50%).")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("FineLinear",
                        "Fine Linear or Fine-Linear Branching Calcification (Suspicious Morphology)",
                        new Definition()
                        .CiteStart()
                            .Line("These are thin, linear, irregular calcifications, which may be discontinuous and which are")
                            .Line("smaller than 0.5 mm in caliber. Occasionally, branching forms may be seen. Their")
                            .Line("appearance suggests filling of the lumen of a duct or ducts involved irregularly by")
                            .Line("breast cancer. Among the suspicious calcifications, fine linear and fine-linear")
                            .Line("branching calcifications have the highest PPV (70%). Therefore, these calcifications")
                            .Line("should be placed in BI-RADS® assessment category 4C (PPV range > 50% to < 95%).")
                        .CiteEnd(BiRadCitation)
                        )
                    }
                );

                ValueSet binding = await this.CreateValueSet(
                    "MammoCalcificationType",
                    "Mammo Calcification Type",
                    "Mammo/Calc./Type/Values",
                    "Mammography calcification type codes.",
                    Group_MGCodes,
                    cs);

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("BreastRadMammoCalcificationType",
                    "Mammo Calcification Type",
                    "Mammo/Calc./Type",
                    ObservationUrl,
                    $"{Group_MGResources}/Calcification/Type",
                    out this.mgCalcificationType)
                    .Description("Breast Radiology Mammography Calcification Type Observation",
                        new Markdown()
                            .Paragraph("This resource describes the type of calcification observed.")
                            .Todo(
                            )
                     )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationCodedValueFragment())
                    .AddFragRef(await this.ObservationLeafFragment())
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode(e, "a mammography calcification type", binding)
                    ;
            });
        }
    }
}
