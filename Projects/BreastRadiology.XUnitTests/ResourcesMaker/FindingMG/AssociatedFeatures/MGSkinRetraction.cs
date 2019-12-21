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
        async StringTask MGSkinRetraction()
        {
            if (this.mgSkinRetraction == null)
                await this.CreateMGSkinRetraction();
            return this.mgSkinRetraction;
        }
        String mgSkinRetraction = null;

        async VTask CreateMGSkinRetraction()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoSkinRetraction",
                    "Mammo Skin Retraction",
                    "Mammo/Skin/Retraction",
                    ObservationUrl,
                    $"{Group_MGResources}/AssociatedFeature/SkinRetraction",
                    out this.mgSkinRetraction)
                    .Description("Mammography Skin Retraction Observation",
                        new Markdown()
                            .Paragraph()
                            .BiradHeader()
                            .BlockQuote("The skin is pulled in abnormally")
                            .BiradFooter()
                            .MissingObservation("a skin retraction")
                            .Todo(
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    ;

                e.IntroDoc  
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode("Skin Retraction")
                    ;
            });
        }
    }
}
