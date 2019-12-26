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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        String CommonObservedCount()
        {
            if (this.commonObservedCount == null)
                this.CreateCommonObservedCount();
            return this.commonObservedCount;
        }
        String commonObservedCount = null;

        void CreateCommonObservedCount()
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
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationLeafFragment())
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
        }
    }
}
