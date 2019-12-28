using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using PreFhir;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        StringTaskVar ObservationNoComponentFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateFragment("BreastRadObservationNoComponentFragment",
                    "BreastRad Observation No Component Fragment",
                        "Observation/No Component/Fragment",
                    ObservationUrl)
                    .Description("Zero's Component.",
                        new Markdown()
                            .Paragraph("Zero's Observation.component.")
                            //.Todo
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationFragment.Value())
                ;
                s = e.SDef.Url;

                e.Select("component").Zero();

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used by all BreastRad observations that do not have components.")
                    ;
            });

    }
}
