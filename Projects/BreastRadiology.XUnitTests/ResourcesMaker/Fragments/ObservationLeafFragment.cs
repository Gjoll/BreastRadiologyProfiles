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
        SDTaskVar ObservationLeafFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
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
                    .AddFragRef(Self.ObservationNoComponentFragment.Value().Url)
                ;
                s = e.SDef;

                e.IntroDoc
                    .Intro($"Resource fragment used by resources that are leaf node observations.")
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("hasMember").Zero();
            });

    }
}
