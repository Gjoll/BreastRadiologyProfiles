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
        async StringTask USMargin()
        {
            if (this.usMargin == null)
                await this.CreateUSMargin();
            return this.usMargin;
        }
        String usMargin = null;

        async VTask CreateUSMargin()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs = await this.CommonCSMargin();
                ValueSet binding = await this.CreateValueSet(
                    "BreastRadUSMargin",
                    "US Margin",
                    "US/Margin Values",
                    "Ultra-sound mass margin codes.",
                    Group_USCodes,
                    cs);
                binding
                    .Remove("Macrolobulated")
                    .Remove("Obscured")
                    ;
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("BreastRadUSMargin",
                        "US Margin",
                        "US/Margin",
                        ObservationUrl,
                        $"{Group_USResources}/Margin",
                        out this.usMargin)
                    .Description("Breast Radiology Ultra-Sound Margin Observation",
                        new Markdown()
                            .MissingObservation("a mass margin")
                            .BiradHeader()
                            .BlockQuote("The margin is the edge or border of the lesion. The descriptors of margin, like the descriptors of shape, are important predictors of whether a mass is benign or malignant. ")
                            .BiradFooter()
                            .Todo(
                                "Is Irregular incorrect? Note from ACR B.3.A. 'Irregular' is not used to group these marginal attributes because irregular describes the shape of a mass.",
                                "Is non-circumscribed a stand along value, or implied by selection fo on or more non-circumscribed values? "
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
                    .CodedObservationLeafNode(e, "a mammography mass margin", binding)
                    ;
            });
        }
    }
}
