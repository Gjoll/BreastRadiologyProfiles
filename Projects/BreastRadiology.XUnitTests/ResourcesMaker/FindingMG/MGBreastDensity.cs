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
        //# toto: get from gg
        CSTaskVar MGBreastDensityCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "MGBreastDensityCS",
                     "Mammography Breast Density CodeSystem",
                     "MG Breast Density/CodeSystem",
                     "Mammography breast density values code system.",
                     Group_MGCodesCS,
                     new ConceptDef[]
                     {
                    new ConceptDef("Fatty",
                        "The breasts are almost entirely fatty",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("Unless an area containing cancer is not included in the image field of the mammogram,")
                            .Text("mammography is highly sensitive in this setting.")
                        .CiteEnd()
                    ),
                    new ConceptDef("Fibroglandular",
                        "Scattered areas of fibroglandular density",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("(historically, there are scattered fibroglandular densities).")
                            .Text("")
                            .Text("It may be helpful to distinguish breasts in which there are a few scattered areas of")
                            .Text("fibroglandular-density tissue from those in which there are moderate scattered areas of")
                            .Text("fibroglandular-density tissue. Note that there has been a subtle change in the wording")
                            .Text("of this category, to conform to BI-RADS® lexicon use of the term \"density\" to describe")
                            .Text("the degree of x-ray attenuation of breast tissue but not to represent discrete")
                            .Text("mammographic findings.")
                        .CiteEnd()
                    ),
                    new ConceptDef("HeterogeneouslyDense",
                        "The breasts are heterogeneously dense, which may obscure detection of small masses",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("It is not uncommon for some areas in such breasts to be relatively dense while other")
                            .Text("areas are primarily fatty. When this occurs, it may be helpful to describe the location(s)")
                            .Text("of the denser tissue in a second sentence, so that the referring clinician is aware that")
                            .Text("these are the areas in which small noncalcified lesions may be obscured. Suggested")
                            .Text("wordings for the second sentence include:")
                            .Text("")
                            .Text("\"The dense tissue is located anteriorly in both breasts, and the posterior portions")
                            .Text("are mostly fatty.\"")
                            .Text("")
                            .Text("\"Primarily dense tissue is located in the upper outer quadrants of both breasts;")
                            .Text("scattered areas of fibroglandular tissue are present in the remainder of the breasts.\"")
                        .CiteEnd()
                    ),
                    new ConceptDef("ExtremelyDense",
                        "The breasts are extremely dense, which lowers the sensitivity of mammography.",
                        new Definition()
                        .CiteStart(BiRadCitation)
                            .Text("The sensitivity of mammography is lowest in this density category.")
                            .Text("The Fourth Edition of BI-RADS®, unlike previous editions, indicated quartile ranges")
                            .Text("of percentage dense tissue (increments of 25% density) for each of the four density")
                            .Text("categories, with the expectation that the assignment of breast density would be")
                            .Text("distributed more evenly across categories than the historical distribution of 10% fatty,")
                            .Text("40% scattered, 40% heterogeneously and 10% extremely dense. However, it has since")
                            .Text("been demonstrated in clinical practice that there has been essentially no change")
                            .Text("in this historical distribution across density categories.")
                        .CiteEnd()
                    ),
                     }
                 )
             );


        VSTaskVar MGBreastDensityVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "MGBreastDensityVS",
                    "Mammography Breast Density ValueSet",
                    "MG Breast DensityValueSet",
                    "Mammography breast density value set.",
                    Group_MGCodesVS,
                    Self.MGBreastDensityCS.Value()
                    )
            );


        SDTaskVar MGBreastDensity = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                ValueSet binding = Self.MGBreastDensityVS.Value();

                {
                    IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                    valueSetIntroDoc
                        .ReviewedStatus("NOONE", "")
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("MGBreastDensity",
                        "Mammography Breast Density",
                        "MG Breast Density",
                        Global.ObservationUrl,
                        $"{Group_MGResources}/BreastDensity",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .Description("Breast Density Observation",
                        new Markdown()
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    ;

                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeMGBreastDensity.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    .ACRDescription(
                        "The following four categories of breast composition are defined by the visually estimated content of fibroglandular-density tissue within the breasts. Please note that the ",
                        "categories are listed as a, b, c, and d so as not to be confused with the numbered BI-RADS® assessment categories. If the breasts are not of apparently equal density, the ",
                        "denser breast should be used to categorize breast density. The sensitivity of mammography for noncalcified lesions decreases as the BI-RADS® breast density category ",
                        "increases. The denser the breast, the larger the lesion(s) that may be obscured. There is considerable intra- and inter-observer variation in visually estimating breast density ",
                        "between any two adjacent density categories. Furthermore, there is only a minimal and insignificant difference in the sensitivity of mammography between the densest breast ",
                        "in a lower-density category and the least dense breast in the next-higher-density category. These factors limit the clinical relevance of breast density categorization for the ",
                        "individual woman. "
                    )
                    ;
                ElementDefinition valueXDef = e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddComponentLink("Breast Density Value",
                    new SDefEditor.Cardinality(e.Select("value[x]")),
                    Global.ElementAnchor(valueXDef), 
                    "CodeableConcept", 
                    binding.Url);
            });
    }
}
