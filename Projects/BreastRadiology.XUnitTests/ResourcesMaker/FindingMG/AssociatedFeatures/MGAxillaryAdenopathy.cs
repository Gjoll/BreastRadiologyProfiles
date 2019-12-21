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
        async StringTask MGAxillaryAdenopathy()
        {
            if (this.mgAxillaryAdenopathy == null)
                await this.CreateMGAxillaryAdenopathy();
            return this.mgAxillaryAdenopathy;
        }
        String mgAxillaryAdenopathy = null;

        async VTask CreateMGAxillaryAdenopathy()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoAxillaryAdenopathy",
                    "Mammo Axillary Adenopathy",
                    "Mammo/Axillary/Adenopathy",
                    ObservationUrl,
                    $"{Group_MGResources}/AssociatedFeature/AxillaryAdenopathy",
                    out this.mgAxillaryAdenopathy)
                    .Description("Breast Radiology Mammography Axillary Adenopathy Observation",
                        new Markdown()
                            .MissingObservation("an axillary adenopathy")
                            .BiradHeader()
                            .BlockQuote("Enlarged axillary lymph nodes may warrant comment, clinical correlation, and additional ")
                            .BlockQuote("evaluation, especially if new or considerably larger or rounder when compared to previous examination.")
                            .BlockQuote("A review of the patient’s medical history may elucidate the cause for axillary adenopathy, averting")
                            .BlockQuote("recommendation for additional evaluation. When one or more large axillary nodes are ")
                            .BlockQuote("substantially composed of fat, this is a normal variant.")
                            .BiradFooter()
                            .Todo(
                                "Cardinalioty?",
                                "Body Location?",
                                "Size?"
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    ;
                e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationLeafNode("Mammography Axillary Adenopathy")
                ;
            });
        }
    }
}
