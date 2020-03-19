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
        SDTaskVar ObservationLeafFragment = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateFragment("ObservationLeafFragment",
                            "Observation Leaf Fragment",
                            "Observation/Leaf/Fragment",
                            Global.ObservationUrl)
                        .Description("Observation Leaf Node Fragment",
                            new Markdown()
                                .Paragraph(
                                    "Fragment that constrains observations leaf nodes (no hasMembers references).")
                        )
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("Needs review by KWA")
                    .ReviewedStatus("Needs review by Penrad")
                    .ReviewedStatus("Needs review by MRS")
                    .ReviewedStatus("Needs review by MagView")
                    .ReviewedStatus("Needs review by CIMI")
                    ;

                e.Select("hasMember").Zero();
            });
    }
}