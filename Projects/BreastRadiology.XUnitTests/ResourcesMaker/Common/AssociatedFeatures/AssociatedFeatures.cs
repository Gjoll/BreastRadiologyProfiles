using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using PreFhir;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        SDTaskVar AssociatedFeatures = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("AssociatedFeatures",
                        "Associated Features",
                        "Associated/Features",
                        ObservationUrl,
                        $"{Group_CommonResources}/AssociatedFeature",
                        "ObservationSection")
                    .Description("Associated Features Observation",
                        new Markdown()
                            .Paragraph("Used with masses, asymmetries, or calcifications, or may stand alone as " +
                                        "Features when no other abnormality is present.")
                     )
                    .AddFragRef(Self.ObservationSectionFragment.Value())
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);

                e.SliceTargetReference( sliceElementDef, Self.MGAbnormalityArchitecturalDistortion.Value(), Modalities.MG, 0, "*");
                e.SliceTargetReference( sliceElementDef, Self.MGAbnormalityCalcification.Value(), Modalities.MG, 0, "*");
                e.SliceTargetReference( sliceElementDef, Self.ObservedFeature.Value(), Modalities.All, 0, "*");
            });
    }
}
