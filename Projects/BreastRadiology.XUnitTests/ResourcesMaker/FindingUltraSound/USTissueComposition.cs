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
        async StringTask USTissueComposition()
        {
            if (this.usTissueComposition == null)
                await this.CreateUSTissueComposition();
            return this.usTissueComposition;
        }
        String usTissueComposition = null;

        async VTask CreateUSTissueComposition()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs = await this.CreateCodeSystem(
                    "BreastRadUSTissueComposition",
                    "US Tissue Composition",
                    "US/Tissue/Composition/Values",
                    "Ultra-sound breast tissue composition codes.",
                    Group_USCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("Fat",
                        "Homogenous Background Echotexture - Fat",
                        new Definition()
                        .CiteStart()
                            .Line("Fat lobules and uniformly echogenic bands of supporting structures")
                            .Line("(Cooper’s ligaments [arrows]) comprise the bulk of breast tissue.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Fibroglandular",
                        "Homogenous Background Echotexture - Fibroglandular",
                        new Definition()
                        .CiteStart()
                            .Line("A thick zone of homogeneously echogenic fibroglandular parenchyma is present beneath the")
                            .Line("thin hypoechoic layer of fat lobules. Many lesions, cancers and fibroadenomas, for example, are")
                            .Line("found within the fibroglandular zone or at its junction with the layer of fat.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Heterogeneous",
                        "Heterogeneous Background Echo Texture",
                        new Definition()
                        .CiteStart()
                            .Line("Heterogeneity can be either focal or diffuse. The breast echotexture is characterized by multiple")
                            .Line("small areas of increased and decreased echogenicity. Shadowing may occur at the interfaces of fat")
                            .Line("lobules and parenchyma. This pattern occurs in younger breasts and those with heterogeneously")
                            .Line("dense parenchyma depicted mammographically. Whether and how this pattern affects the sensitivity")
                            .Line("of sonography merits study, but technical maneuvers may help resolve interpretive dilemmas")
                            .Line("that occasionally result in unnecessary biopsy.")
                        .CiteEnd(BiRadCitation)
                    )
                    }
                );

                ValueSet binding = await this.CreateValueSet(
                    "BreastRadUSTissueComposition",
                    "US Tissue Composition",
                    "US/Tissue/Composition/Values",
                    "Ultra-sound breast tissue composition codes.",
                    Group_USCodes,
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

                SDefEditor e = this.CreateEditor("BreastRadUSTissueComposition",
                        "US Tissue Composition",
                        "US/Tissue/Composition",
                        ObservationUrl,
                        $"{Group_USResources}/Mass/TissueComposition",
                        out this.usTissueComposition)
                    .Description("Breast Radiology Ultra-Sound Tissue Composition Observation",
                        new Markdown()
                            .BiradHeader()
                            .BlockQuote("The wide normal variability in tissue composition seen on mammograms can also be observed")
                            .BlockQuote("on US images. Just as increasing breast density diminishes the sensitivity of mammography in the")
                            .BlockQuote("detection of small masses, heterogeneous background echotexture of the breast may affect the")
                            .BlockQuote("sensitivity of breast sonograms for lesion detection.")
                            .BiradFooter()
                            .Todo(
                                "can this and mammo breast density be the same?"
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
                    .CodedObservationLeafNode(e, "an ultra-sound tissue composition", binding)
                    ;
            });
        }
    }
}
