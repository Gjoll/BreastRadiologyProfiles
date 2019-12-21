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
        async StringTask MGCalcificationDistribution()
        {
            if (this.mgCalcificationDistribution == null)
                await this.CreateMGCalcificationDistribution();
            return this.mgCalcificationDistribution;
        }
        String mgCalcificationDistribution = null;

        async VTask CreateMGCalcificationDistribution()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs  = await this.CreateCodeSystem(
                    "MammoCalcificationDistribution",
                    "Mammo Calcification Distribution",
                    "Mammo/Calc./Distribution/Values",
                    "Mammography calcification distribution codes.",
                    Group_MGCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("Diffuse",
                        "Diffuse Calcification Distribution",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"scattered\")")
                            .Line("These are calcifications that are distributed randomly throughout the breast. Punctate and")
                            .Line("amorphous calcifications in this distribution are almost always benign, especially if bilateral.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Regional ",
                        "Regional  Calcification Distribution",
                        new Definition()
                        .CiteStart()
                            .Line("This descriptor is used for numerous calcifications that occupy a large portion of breast tissue")
                            .Line("(more than 2 cm in greatest dimension), not conforming to a duct distribution. Since this")
                            .Line("distribution may involve most of a quadrant or even more than a single quadrant, malignancy")
                            .Line("is less likely. However, overall evaluation of regional calcifications must include particle shape")
                            .Line("(morphology) as well as distribution.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Grouped ",
                        "Grouped  Calcification Distribution",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"clustered\")")
                            .Line("This term should be used when relatively few calcifications occupy a small portion of breast")
                            .Line("tissue. The lower limit for use of this descriptor is usually when 5 calcifications are grouped")
                            .Line("within 1 cm of each other or when a definable pattern is identified. The upper limit for use")
                            .Line("of this descriptor is when larger numbers of calcifications are grouped within 2 cm of each other.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Linear ",
                        "Linear  Calcification Distribution",
                        new Definition()
                        .CiteStart()
                            .Line("These are calcifications arrayed in a line. This distribution may elevate suspicion for malignancy,")
                            .Line("as it suggests deposits in a duct. Note that both vascular and large rod-like calcifications")
                            .Line("also are usually linear in distribution, but that these typically benign calcifications have")
                            .Line("a characteristically benign morphology.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Segmental",
                        "Segmental Calcification Distribution",
                        new Definition()
                        .CiteStart()
                            .Line("Calcifications in a segmental distribution are of concern because they suggest deposits in a")
                            .Line("duct or ducts and their branches, raising the possibility of extensive or multifocal breast cancer")
                            .Line("in a lobe or segment of the breast. Although benign causes of segmental calcifications exist")
                            .Line("(e.g. large rod-like), the smooth, rod-like morphology and large size of benign calcifications")
                            .Line("distinguish them from finer, more pleomorphic or heterogeneous malignant calcifications.")
                            .Line("A segmental distribution may elevate the degree of suspicion for calcifications such as punctate or amorphous forms.")
                        .CiteEnd(BiRadCitation)
                    )
                    }
                );

                    ValueSet binding = await this.CreateValueSet(
                        "MammoCalcificationDistribution",
                        "Mammo Calcification Distribution",
                        "Mammo/Calc./Distribution/Values",
                        "Mammography calcification distribution codes.",
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

                SDefEditor e = this.CreateEditor("BreastRadMammoCalcificationDistribution",
                        "Mammo Calcification Distribution",
                        "Mammo/Calc./Distribution",
                        ObservationUrl,
                        $"{Group_MGResources}/Calcification/Distribution",
                        out this.mgCalcificationDistribution)
                    .Description("Breast Radiology Mammography Calcification Distribution Observation",
                        new Markdown()
                            .Paragraph("This resource describes the calcification distribution observed.")
                            .BiradHeader()
                            .BlockQuote("These descriptors are used to indicate the arrangement of calcifications in the breast. Multiple")
                            .BlockQuote("similar groups may be described in the report when there is more than one group of calcifications")
                            .BlockQuote("that are similar in morphology and distribution. In evaluating the likelihood of malignancy for calcifications, ")
                            .BlockQuote("distribution is at least as important as morphology.")
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
                    .CodedObservationLeafNode(e, "a mammography calcification distribution", binding)
                    ;
            });
        }
    }
}
