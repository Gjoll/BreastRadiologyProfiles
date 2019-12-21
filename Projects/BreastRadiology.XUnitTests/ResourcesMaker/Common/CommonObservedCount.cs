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
        async StringTask CommonObservedCount()
        {
            if (this.commonObservedCount == null)
                await this.CreateCommonObservedCount();
            return this.commonObservedCount;
        }
        String commonObservedCount = null;

        async VTask CreateCommonObservedCount()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("CommonCount",
                        "Count",
                        "Count",
                        ObservationUrl,
                        $"{Group_CommonResources}/ObservedCount",
                        out this.commonObservedCount)
                    .Description("Breast Radiology Count Observation",
                        new Markdown()
                            .Paragraph("This observations describes the number of discrete items in an observed item.")
                            .MissingObservation("an objects Count")
                            .Todo(
                                "Should value[x] be SimpleQuantity.",
                                "is 'tot' correct ucum units for count?"
                            )
                        )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationLeafFragment())
                    ;
                e.Select("value[x]")
                    .Types("integer", "Range")
                    .SetCardinality(1, "1")
                    .SetDefinition(new Markdown()
                        .Paragraph("Count of an object.")
                        .Paragraph("This is either an integer count, or a Range (min..max) count.")
                        .Paragraph($"A range value with no maximum specified implies count is min or more.")
                        .Paragraph($"A range value with no minimum specified implies count is max or less.")
                     )
                    ;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode($"Count")
                    ;
            });
        }
    }
}
