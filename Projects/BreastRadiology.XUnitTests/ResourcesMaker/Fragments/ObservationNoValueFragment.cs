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
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateFragment("BreastRadObservationNoValueFragment",
                            "Observation NoValue Fragment",
                            "Observation/NoValue/Fragment",
                            Global.ObservationUrl)
                        .Description("Observation No Value fragment",
                            new Markdown()
                                .Paragraph("Base fragment for all BreastRad observations that have no explicit value.")
                        )
                        .AddFragRef(Self.ObservationFragment.Value())
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("Needs review by KWA")
                    .ReviewedStatus("Needs review by Penrad")
                    .ReviewedStatus("Needs review by MRS")
                    .ReviewedStatus("Needs review by MagView")
                    .ReviewedStatus("Needs review by CIMI")
                    ;

                e.Select("dataAbsentReason").Zero();
                e.Select("value[x]").Zero();
                e.Select("interpretation").Zero();
                e.Select("referenceRange").Zero();
            });
    }
}