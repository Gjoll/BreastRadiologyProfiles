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
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("ObservationLeafFragment",
                    "Observation Leaf Fragment",
                        "Observation/Leaf/Fragment",
                    ObservationUrl)
                    .Description("Observation Leaf Node Fragment",
                        new Markdown()
                            .Paragraph("Fragment that constrains observations leaf nodes (no hasMembers references).")
                    )
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                e.Select("hasMember").Zero();
            });

    }
}
