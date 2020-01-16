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
        SDTaskVar ObservationNoValueFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("BreastRadObservationNoValueFragment",
                    "BreastRad Observation NoValue Fragment",
                        "NoValue/Observation/Fragment",
                    ObservationUrl)
                    .Description("Observation No Value fragment",
                        new Markdown()
                            .Paragraph("Base fragment for all BreastRad observations that have no explicit value.")
                    )
                    .AddFragRef(Self.ObservationFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("value[x]").Zero();
                e.Select("interpretation").Zero();
                e.Select("referenceRange").Zero();
            });
    }
}
