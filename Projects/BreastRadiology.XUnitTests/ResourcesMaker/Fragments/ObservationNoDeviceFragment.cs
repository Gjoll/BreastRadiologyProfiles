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
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateFragment("BreastRadObservationNoDeviceFragment",
                            "Observation NoDevice Fragment",
                            "Observation/NoDevice/Fragment",
                            Global.ObservationUrl)
                        .Description("Observations No Device Data fragment.",
                            new Markdown()
                                .Paragraph("Fragment for all observations that have no device.")
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

                e.Select("device").Zero();
            });
    }
}