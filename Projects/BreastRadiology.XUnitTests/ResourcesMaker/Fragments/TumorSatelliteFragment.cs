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
                        ObservationUrl)
                    .Description("Tumor Satellite fragment",
                        new Markdown()
                        .Paragraph("This fragment adds the references for the Tumor Satellite extension.")
                     )
                    .AddFragRef(Self.HeaderFragment.Value())
                ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                ElementDefinition extensionDef = e
                    .ApplyExtension("tumorSatellite", Self.TumorSatelliteExtension.Value(), true)
                    .ZeroToOne()
                    ;
                e.AddExtensionLink(extensionDef);
            });
    }
}
