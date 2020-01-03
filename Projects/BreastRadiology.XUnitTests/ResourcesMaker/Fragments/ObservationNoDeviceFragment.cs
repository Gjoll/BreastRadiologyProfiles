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
        StringTaskVar ObservationNoDeviceFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateFragment("BreastRadObservationNoDeviceFragment",
                    "BreastRad Observation NoDevice Fragment",
                        "NoDevice/Observation/Fragment",
                    ObservationUrl)
                    .Description("Fragment that constrains Observations to have not device data.",
                        new Markdown()
                            .Paragraph("Fragment for all observations that have no device.")
                            //.Todo
                    )
                    .AddFragRef(Self.ObservationFragment.Value())
                ;
                s = e.SDef.Url;

                //$e.IntroDoc
                //    .IntroFragment($"Fragment for all observations that have no device.")
                //    .ReviewedStatus(ReviewStatus.NotReviewed)
                //    ;

                e.Select("device").Zero();
            });
    }
}
