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
        StringTaskVar ObservationSectionFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateFragment("ObservationSectionFragment",
                        "Observation Section Fragment",
                        "Section/Fragment",
                        ObservationUrl)
                    .Description("Fragment that constrains Observations to be sections.",
                        new Markdown()
                            .Paragraph("this fragment constrains a generic observation to be a observation section.")
                            //.Todo
                     )
                    .AddFragRef(ResourcesMaker.Self.ObservationFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    ;
                s = e.SDef.Url;
                e.Select("interpretation").Zero();
                e.Select("method").Zero();
                e.AddIncompatibleFragment(ResourcesMaker.Self.ObservationLeafFragment.Value());
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used by observations that are used as report sections.")
                    ;
            });

    }
}
