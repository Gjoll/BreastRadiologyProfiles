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
        SDTaskVar ObservationNoDeviceFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
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
                    .AddFragRef(Self.ObservationFragment.Value().Url)
                ;
                s = e.SDef;

                e.IntroDoc
                    .Intro($"Fragment for all observations that have no device.")
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("device").Zero();
            });
    }
}
