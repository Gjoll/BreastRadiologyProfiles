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
        SDTaskVar ObservationNoComponentFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("BreastRadObservationNoComponentFragment",
                    "BreastRad Observation No Component Fragment",
                    "Observation/No Component/Fragment",
                    ObservationUrl)
                    .Description("Zero's Component.",
                        new Markdown()
                            .Paragraph("Zero's Observation.component.")
                    )
                    .AddFragRef(Self.ObservationFragment.Value())
                ;
                s = e.SDef;

                e.Select("component").Zero();

                e.IntroDoc
                    .Intro($"Resource fragment used by all BreastRad observations that do not have components.")
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
            });

    }
}
