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
        async StringTask MGBreastDensity()
        {
            if (this.mgBreastDensity == null)
                await this.CreateMGBreastDensity();
            return this.mgBreastDensity;
        }
        String mgBreastDensity = null;

        async VTask CreateMGBreastDensity()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs  = await this.CreateCodeSystem(
                    "BreastRadMammoBreastDensity",
                    "Mammo Breast Density",
                    "Mammo/Breast/Density/Values",
                    "Codes for mammography breast density values.",
                    Group_MGCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("Fatty",
                        "The breasts are almost entirely fatty",
                        new Definition()
                        .CiteStart()
                            .Line("Unless an area containing cancer is not included in the image field of the mammogram,")
                            .Line("mammography is highly sensitive in this setting.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Fibroglandular",
                        "Scattered areas of fibroglandular density",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, there are scattered fibroglandular densities).")
                            .Line("")
                            .Line("It may be helpful to distinguish breasts in which there are a few scattered areas of")
                            .Line("fibroglandular-density tissue from those in which there are moderate scattered areas of")
                            .Line("fibroglandular-density tissue. Note that there has been a subtle change in the wording")
                            .Line("of this category, to conform to BI-RADS® lexicon use of the term \"density\" to describe")
                            .Line("the degree of x-ray attenuation of breast tissue but not to represent discrete")
                            .Line("mammographic findings.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("HeterogeneouslyDense",
                        "The breasts are heterogeneously dense, which may obscure detection of small masses",
                        new Definition()
                        .CiteStart()
                            .Line("It is not uncommon for some areas in such breasts to be relatively dense while other")
                            .Line("areas are primarily fatty. When this occurs, it may be helpful to describe the location(s)")
                            .Line("of the denser tissue in a second sentence, so that the referring clinician is aware that")
                            .Line("these are the areas in which small noncalcified lesions may be obscured. Suggested")
                            .Line("wordings for the second sentence include:")
                            .Line("")
                            .Line("\"The dense tissue is located anteriorly in both breasts, and the posterior portions")
                            .Line("are mostly fatty.\"")
                            .Line("")
                            .Line("\"Primarily dense tissue is located in the upper outer quadrants of both breasts;")
                            .Line("scattered areas of fibroglandular tissue are present in the remainder of the breasts.\"")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("ExtremelyDense",
                        "The breasts are extremely dense, which lowers the sensitivity of mammography.",
                        new Definition()
                        .CiteStart()
                            .Line("The sensitivity of mammography is lowest in this density category.")
                            .Line("The Fourth Edition of BI-RADS®, unlike previous editions, indicated quartile ranges")
                            .Line("of percentage dense tissue (increments of 25% density) for each of the four density")
                            .Line("categories, with the expectation that the assignment of breast density would be")
                            .Line("distributed more evenly across categories than the historical distribution of 10% fatty,")
                            .Line("40% scattered, 40% heterogeneously and 10% extremely dense. However, it has since")
                            .Line("been demonstrated in clinical practice that there has been essentially no change")
                            .Line("in this historical distribution across density categories.")
                        .CiteEnd(BiRadCitation)
                    ),
                    }
                );

                    ValueSet binding = await this.CreateValueSet(
                        "BreastRadMammoBreastDensity",
                        "Mammo Breast Density",
                        "Mammo/Breast/Density/Values",
                        "Codes for mammography breast density values.",
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

                SDefEditor e = this.CreateEditor("BreastRadMammoBreastDensity",
                        "Mammo Breast Density",
                        "Mammo/Breast/Density",
                        ObservationUrl,
                        $"{Group_MGResources}/BreastDensity",
                        out this.mgBreastDensity)
                    .Description("Breast Radiology Mammography Breast Density Observation",
                        new Markdown()
                            .BiradHeader()
                            .BlockQuote("The following four categories of breast composition are defined by the visually estimated content of fibroglandular-density tissue within the breasts. Please note that the ")
                            .BlockQuote("categories are listed as a, b, c, and d so as not to be confused with the numbered BI-RADS® assessment categories. If the breasts are not of apparently equal density, the ")
                            .BlockQuote("denser breast should be used to categorize breast density. The sensitivity of mammography for noncalcified lesions decreases as the BI-RADS® breast density category ")
                            .BlockQuote("increases. The denser the breast, the larger the lesion(s) that may be obscured. There is considerable intra- and inter-observer variation in visually estimating breast density ")
                            .BlockQuote("between any two adjacent density categories. Furthermore, there is only a minimal and insignificant difference in the sensitivity of mammography between the densest breast ")
                            .BlockQuote("in a lower-density category and the least dense breast in the next-higher-density category. These factors limit the clinical relevance of breast density categorization for the ")
                            .BlockQuote("individual woman. ")
                            .BiradFooter()
                            .Todo(
                            "Do we need statement that breast density is required now?",
                            "can this and US tissue composition be the same?"
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
                    .CodedObservationLeafNode(e, "a mammography breast density", binding)
                    ;
            });
        }
    }
}
