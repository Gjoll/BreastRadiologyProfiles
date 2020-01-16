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
                    .Description("Observations No Device Data fragment.",
                        new Markdown()
                            .Paragraph("Fragment for all observations that have no device.")
                    )
                    .AddFragRef(Self.ObservationFragment.Value())
                ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("device").Zero();
            });
    }
}
