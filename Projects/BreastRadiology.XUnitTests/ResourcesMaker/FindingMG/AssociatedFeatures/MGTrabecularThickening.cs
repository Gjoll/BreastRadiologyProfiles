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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        StringTaskVar MGTrabecularThickening = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditorXX("BreastRadMammoTrabecularThickening",
                    "Mammography Trabecular Thickening",
                    "MG Trabecular/Thickening",
                    ObservationUrl,
                    $"{Group_MGResources}/AssociatedFeature/TrabecularThickening")
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
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.BreastBodyLocationRequiredFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    ;
                s = e.SDef.Url;
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode("Trabecular Thickening")
                    ;
            });
    }
}
