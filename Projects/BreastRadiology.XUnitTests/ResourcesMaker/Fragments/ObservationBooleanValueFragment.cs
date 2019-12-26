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
        StringTaskVar BooleanValueObservationFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateFragment("BooleanValueObservationFragment",
                        "BooleanValue Observation Fragment",
                        "Observation/BooleanValue/Fragment",
                        ObservationUrl)
                    .Description("Fragment to define a boolean observation",
                    new Markdown()
                        .Paragraph("Fragment that constrains an observation to contains only a boolean value.")
                        .Todo(
                        )
                        )
                    .AddFragRef(ResourcesMaker.Self.HeaderFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationFragment.Value())
                    ;
                s = e.SDef.Url;
                e.Select("value[x]")
                    .Type("boolean")
                    ;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used to by all observations whose value are a Boolean.")
                    ;
            });

    }
}
