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
                         //+ Codes
                         new ConceptDef()
                             .SetCode("AlmostEntirelyFat")
                             .SetDisplay("Almost entirely fat")
                             .SetDefinition("[PR] Almost entirely fat")
                             .MammoId("Row618")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("A term used to describe breast tissue that is made " +
                                 "up of almost all fatty tissue. Fatty breast tissue " +
                                 "does not look dense on a mammogram, which may make " +
                                 "it easier to find tumors or other changes in the " +
                                 "breast. Fatty breast tissue is more common in older " +
                                 "women than in younger women. Fatty breast tissue " +
                                 "is one of four categories used to describe a level " +
                                 "of breast density seen on a mammogram. https://www.cancer.gov/publications/dictionaries/cancer-terms/search?contains=false&q=fatty")
                             .SetACR("Unless an area containing cancer is not included " +
                                 "in the image field of the mammogram,mammography is " +
                                 "highly sensitive in this setting.")
                         ,
                         new ConceptDef()
                             .SetCode("ScatteredAreasOfFibroglandularDensity")
                             .SetDisplay("Scattered areas of fibroglandular density")
                             .SetDefinition("[PR] Scattered areas of fibroglandular density")
                             .MammoId("Row619")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("A term used to describe breast tissue that is made " +
                                 "up of mostly fatty tissue and also has some dense " +
                                 "fibrous tissue and glandular tissue. On a mammogram, " +
                                 "the dense areas of the breast make it harder to find " +
                                 "tumors or other changes. Scattered fibroglandular " +
                                 "breast tissue is one of four categories used to describe " +
                                 "a level of breast density seen on a mammogram. About " +
                                 "40% of women have this type of breast tissue. https://www.cancer.gov/publications/dictionaries/cancer-terms/def/scattered-fibroglandular-breast-tissue")
                             .SetACR("(historically, there are scattered fibroglandular " +
                                 "densities).It may be helpful to distinguish breasts " +
                                 "in which there are a few scattered areas offibroglandular-density " +
                                 "tissue from those in which there are moderate scattered " +
                                 "areas offibroglandular-density tissue. Note that " +
                                 "there has been a subtle change in the wordingof this " +
                                 "category, to conform to BI-RADS® lexicon use of the " +
                                 "term \"density\" to describethe degree of x-ray attenuation " +
                                 "of breast tissue but not to represent discretemammographic " +
                                 "findings.")
                         ,
                         new ConceptDef()
                             .SetCode("HetrogeneouslyDense")
                             .SetDisplay("Hetrogeneously dense")
                             .SetDefinition("[PR] Hetrogeneously dense")
                             .MammoId("Row620")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("A term used to describe breast tissue that has large " +
                                 "areas of dense fibrous tissue and glandular tissue " +
                                 "and also has some fatty tissue. The dense areas of " +
                                 "the breast make it harder to find tumors or other " +
                                 "changes on a mammogram. Heterogeneously dense breast " +
                                 "tissue is one of four categories used to describe " +
                                 "a level of breast density seen on a mammogram. About " +
                                 "40% of women have this type of breast tissue. https://www.cancer.gov/publications/dictionaries/cancer-terms/def/heterogeneously-dense-breast-tissue")
                             .SetACR("It is not uncommon for some areas in such breasts " +
                                 "to be relatively dense while otherareas are primarily " +
                                 "fatty. When this occurs, it may be helpful to describe " +
                                 "the location(s)of the denser tissue in a second sentence, " +
                                 "so that the referring clinician is aware thatthese " +
                                 "are the areas in which small noncalcified lesions " +
                                 "may be obscured. Suggestedwordings for the second " +
                                 "sentence include:\"The dense tissue is located anteriorly " +
                                 "in both breasts, and the posterior portionsare mostly " +
                                 "fatty.\"\"Primarily dense tissue is located in the upper " +
                                 "outer quadrants of both breasts;scattered areas of " +
                                 "fibroglandular tissue are present in the remainder " +
                                 "of the breasts.\"")
                         ,
                         new ConceptDef()
                             .SetCode("ExtremelyDense")
                             .SetDisplay("Extremely dense")
                             .SetDefinition("[PR] Extremely dense")
                             .MammoId("Row621")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("Also called extremely dense breast tissue. A term " +
                                 "used to describe breast tissue that is made up of " +
                                 "almost all dense fibrous tissue and glandular tissue. " +
                                 "On a mammogram, the dense areas of the breast make " +
                                 "it harder to find tumors or other changes. Women " +
                                 "who have extremely dense breast tissue have a higher " +
                                 "risk of breast cancer than those who have little " +
                                 "or no dense breast tissue. Extremely dense breast " +
                                 "tissue is one of four categories used to describe " +
                                 "a level of breast density seen on a mammogram. About " +
                                 "10% of women have this type of breast tissue. https://www.cancer.gov/publications/dictionaries/cancer-terms/def/extremely-dense-breast-tissue")
                             .SetACR("The sensitivity of mammography is lowest in this " +
                                 "density category.The Fourth Edition of BI-RADS®, " +
                                 "unlike previous editions, indicated quartile rangesof " +
                                 "percentage dense tissue (increments of 25% density) " +
                                 "for each of the four densitycategories, with the " +
                                 "expectation that the assignment of breast density " +
                                 "would bedistributed more evenly across categories " +
                                 "than the historical distribution of 10% fatty,40% " +
                                 "scattered, 40% heterogeneously and 10% extremely " +
                                 "dense. However, it has sincebeen demonstrated in " +
                                 "clinical practice that there has been essentially " +
                                 "no changein this historical distribution across density " +
                                 "categories.")
                         //- Codes
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
