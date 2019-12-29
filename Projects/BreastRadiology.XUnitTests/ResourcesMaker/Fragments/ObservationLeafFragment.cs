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
        StringTaskVar ObservationLeafFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateFragment("ObservationLeafFragment",
                    "Observation Leaf Fragment",
                        "Observation/Leaf/Fragment",
                    ObservationUrl)
                    .Description("Fragment that constrains all observations that are leaf nodes.",
                        new Markdown()
                            .Paragraph("Fragment that constrains observations leaf nodes (no hasMembers references).")
                            //.Todo
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoComponentFragment.Value())
                ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used by resources that are leaf node observations.")
                    ;

                e.Select("hasMember").Zero();
            });

    }
}
