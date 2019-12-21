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
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        async StringTask MGMassDensity()
        {
            if (this.mgMassDensity == null)
                await this.CreateMGMassDensity();
            return this.mgMassDensity;
        }
        String mgMassDensity = null;

        async VTask CreateMGMassDensity()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs = await this.CreateCodeSystem(
                    "BreastRadMammoMassDensity",
                    "Mammo Mass Density",
                    "Mammo/Mass/Density/Values",
                    "Mammography mass density codes.",
                    Group_MGCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("HighDensity ",
                        "High Density",
                        new Definition()
                        .CiteStart()
                            .Line("X-ray attenuation of the mass is greater than the expected attenuation of an equal volume of")
                            .Line("fibroglandular breast tissue.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("EqualDensity",
                        "Equal Density",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"isodense\")")
                            .Line("X-ray attenuation of the mass is the same as the expected attenuation of an equal volume of")
                            .Line("fibroglandular breast tissue.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("LowDensity",
                        "Low Density",
                        new Definition()
                        .CiteStart()
                            .Line("X-ray attenuation of the mass is less than the expected attenuation of an equal volume of")
                            .Line("fibroglandular breast tissue. A low density mass may be a group of microcysts. If such a finding")
                            .Line("is identified at mammography, it may very well not be malignant but appropriately may")
                            .Line("be worked up.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("FatContaining",
                        "Fat Containing",
                        new Definition()
                        .CiteStart()
                            .Line("This includes all masses containing fat, such as oil cyst, lipoma or galactocele, as well as mixed")
                            .Line("density masses such as hamartoma. A fat-containing mass will almost always represent a")
                            .Line("benign mass.")
                        .CiteEnd(BiRadCitation)
                        )
                    });

                ValueSet binding = await this.CreateValueSet(
                    "BreastRadMammoMassDensity",
                    "Mammo Mass Density",
                    "Mammo/Mass/Density/Values",
                    "Mammography mass density codes.",
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

                SDefEditor e = this.CreateEditor("BreastRadMammoMassDensity",
                        "Mammo Mass Density",
                        "Mammo/Mass/Density",
                        ObservationUrl,
                        $"{Group_MGResources}/Mass/Density",
                        out this.mgMassDensity)
                    .Description("Breast Radiology Mammography Mass Density Observation",
                        new Markdown()
                            .MissingObservation("a mass density")
                            .BiradHeader()
                            .BlockQuote("Radiographic density is considered an important feature in the evaluation of noncalcified breast masses, yet")
                            .BlockQuote("no studies assessing its value have been published. The radiographic densities of 91 biopsy-proved, nonfatty,")
                            .BlockQuote("noncalcified breast masses were evaluated by three mammographers. The density determinations made by")
                            .BlockQuote("each observer were compared with the histologic outcome for the 51 benign and 40 malignant lesions. With")
                            .BlockQuote("the kappa statistic, interobserver agreement was relatively poor (0.22 to 0.49), and intraobserver agreement for")
                            .BlockQuote("one expert mammographer was 0.50. When the majority opinion of the mammographers was used, sensitivity")
                            .BlockQuote("was 48%, specificity was 80%, and both positive and negative predictive values were 66%. As a solitary feature")
                            .BlockQuote("in lesion analysis, mammographic density is difficult to assess and is of limited value for the prediction of the")
                            .BlockQuote("benign or malignant nature of noncalcified breast masses.")
                            .BiradFooter()
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
                    .CodedObservationLeafNode(e, "a mammography mass density", binding)
                    ;
            });
        }
    }
}
