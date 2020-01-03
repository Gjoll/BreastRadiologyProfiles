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
                SDefEditor e = Self.CreateFragment("ObservationLeafFragment",
                    "Observation Leaf Fragment",
                        "Observation/Leaf/Fragment",
                    ObservationUrl)
                    .Description("Fragment that constrains all observations that are leaf nodes.",
                        new Markdown()
                            .Paragraph("Fragment that constrains observations leaf nodes (no hasMembers references).")
                            //.Todo
                    )
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                ;
                s = e.SDef.Url;

                //$e.IntroDoc
                //    .IntroFragment($"Resource fragment used by resources that are leaf node observations.")
                //    .ReviewedStatus(ReviewStatus.NotReviewed)
                //    ;

                e.Select("hasMember").Zero();
            });

    }
}
