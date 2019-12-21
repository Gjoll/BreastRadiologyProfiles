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
        async StringTask MGTrabecularThickening()
        {
            if (this.mgTrabecularThickening == null)
                await this.CreateMGTrabecularThickening();
            return this.mgTrabecularThickening;
        }
        String mgTrabecularThickening = null;

        async VTask CreateMGTrabecularThickening()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoTrabecularThickening",
                    "Mammo Trabecular Thickening",
                    "Mammo/Trabecular/Thickening",
                    ObservationUrl,
                    $"{Group_MGResources}/AssociatedFeature/TrabecularThickening",
                    out this.mgTrabecularThickening)
                    .Description("Trabecular Thickening Observation",
                        new Markdown()
                            .BiradHeader()
                            .BlockQuote("This is a thickening of the fibrous septa of the breast.")
                            .BiradFooter()
                            .MissingObservation("a trabecular thickening")
                            .Todo(
                                "Add body location?",
                                "Add size measurement?",
                                "cardinality 0..1 or 0..*?"
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    ;
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode("Trabecular Thickening")
                    ;
            });
        }
    }
}
