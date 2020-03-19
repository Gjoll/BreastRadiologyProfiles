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
        SDTaskVar TumorSatelliteFragment = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateFragment("TumorSatelliteFragment",
                            "Tumor Satellite Fragment",
                            "Tumor Satellite/Fragment",
                            Global.ObservationUrl)
                        .Description("Tumor Satellite fragment",
                            new Markdown()
                                .Paragraph("This fragment adds the references for the Tumor Satellite extension.")
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
                e.SliceTargetReference(sliceElementDef, Self.TumorSatellite.Value(), 0, "*");
            });
    }
}