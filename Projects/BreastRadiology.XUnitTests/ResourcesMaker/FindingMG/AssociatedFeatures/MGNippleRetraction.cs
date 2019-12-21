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
        async StringTask MGNippleRetraction()
        {
            if (this.mgNippleRetraction == null)
                await this.CreateMGNippleRetraction();
            return this.mgNippleRetraction;
        }
        String mgNippleRetraction = null;

        async VTask CreateMGNippleRetraction()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoNippleRetraction",
                    "Mammo Nipple Retraction",
                    "Mammo/Nipple/Retraction",
                    ObservationUrl,
                    $"{Group_MGResources}/AssociatedFeature/NippleRetraction",
                    out this.mgNippleRetraction)
                    .Description("Breast Radiology Mammography Nipple Retraction Observation",
                        new Markdown()
                            .MissingObservation("a nipple retraction")
                            .BiradHeader()
                            .BlockQuote("The nipple is pulled in. This should not be confused with nipple inversion, which is often bilateral ")
                            .BlockQuote("and which in the absence of any suspicious findings and when stable for a long period of time, ")
                            .BlockQuote("is not a sign of malignancy. However, if nipple retraction is new, suspicion for underlying malignancy is increased.")
                            .BiradFooter()
                            .Todo(
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    ;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode("Nipple Retraction")
                    ;
            });
        }
    }
}
