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
                    "Observation NoValue Fragment",
                        "Observation/NoValue/Fragment",
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
                    .ReviewedStatus("NOONE", "1.1.2020")
                    ;

                e.Select("dataAbsentReason").Zero();
                e.Select("value[x]").Zero();
                e.Select("interpretation").Zero();
                e.Select("referenceRange").Zero();
            });
    }
}
