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
        SDTaskVar ObservationHasMemberConsistentWithFragment = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateFragment("ConsistentWithHasMemberFragment",
                            "ConsistentWith HasMember Fragment",
                            "ConsistentWith HasMember/Fragment",
                            Global.ObservationUrl)
                        .Description("ConsistentWith HasMember fragment",
                            new Markdown()
                                .Paragraph("This fragment adds the references for the ConsistentWith HasMember.")
                        )
                        .AddFragRef(Self.HeaderFragment.Value())
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("Needs review by KWA")
                    .ReviewedStatus("Needs review by Penrad")
                    .ReviewedStatus("Needs review by MRS")
                    .ReviewedStatus("Needs review by MagView")
                    .ReviewedStatus("Needs review by CIMI")
                    ;
                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference(sliceElementDef, Self.ConsistentWith.Value(), 0, "*");
            });
    }
}