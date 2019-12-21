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
        async StringTask NMMassMargin()
        {
            if (this.nmMassMargin == null)
                await this.CreateNMMassMargin();
            return this.nmMassMargin;
        }
        String nmMassMargin = null;

        async VTask CreateNMMassMargin()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs  = await this.CreateCodeSystem(
                    "BreastRadNMMassMargin",
                    "NM Mass Margin",
                    "NM/Mass/Margin/Values",
                    "NM mass margin codes.",
                    Group_NMCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("Circumscribed ",
                        "Circumscribed Margin",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"well defined\" or \"sharply defined\")")
                            .Line("The margin is sharply demarcated with an abrupt transition between the lesion and the surrounding tissue.")
                        .CiteEnd(BiRadCitation)
                        )
                    });

                    ValueSet binding = await this.CreateValueSet(
                        "BreastRadNMMassMargin",
                        "NM Mass Margin",
                        "NM/Mass/Margin/Values",
                        "NM mass margin codes.",
                        Group_NMCodes,
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

                SDefEditor e = this.CreateEditor("BreastRadNMMassMargin",
                    "NM Mass Margin",
                    "NM/Mass/Margin",
                    ObservationUrl,
                    $"{Group_NMResources}/Mass/Margin",
                    out this.nmMassMargin)
                    .Description("Breast Radiology NM Mass Margin Observation",
                        new Markdown()
                            .MissingObservation("a mass margin")
                            .BiradHeader()
                            .BlockQuote("The margin is the edge or border of the lesion. The descriptors of margin, like the descriptors of shape, are important predictors of whether a mass is benign or malignant. ")
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
                    .CodedObservationLeafNode(e, "a NM mass margin", binding)
                    ;
            });
        }
    }
}
