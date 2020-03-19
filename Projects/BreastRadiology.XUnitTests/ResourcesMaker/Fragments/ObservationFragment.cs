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
        SDTaskVar ObservationFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("BreastRadObservationFragment",
                    "Observation Fragment",
                        "Observation/Fragment",
                    Global.ObservationUrl)
                    .Description("Observation base fragment",
                        new Markdown()
                            .Paragraph("Base fragment that performs common constrains used in all breast radiology observations.")
                    )
                    .AddFragRef(Self.HeaderFragment.Value())
                    .AddFragRef(Self.CategoryFragment.Value())
                ;
                s = e.SDef;
                e.IntroDoc
                     .ReviewedStatus("Needs review by KWA")
                     .ReviewedStatus("Needs review by Penrad")
                     .ReviewedStatus("Needs review by MRS")
                     .ReviewedStatus("Needs review by MagView")
                     .ReviewedStatus("Needs review by CIMI")
                    ;

                e.Select("interpretation").Zero();
                e.Select("referenceRange").Zero();
                e.Select("basedOn").Zero();
                e.Select("partOf").Zero();
                e.Select("focus").Zero();
                e.Select("specimen").Zero();
                e.Select("contained").Zero();

            });

    }
}
