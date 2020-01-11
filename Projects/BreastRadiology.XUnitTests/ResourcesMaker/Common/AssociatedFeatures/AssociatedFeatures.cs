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
                SDefEditor e = Self.CreateEditorObservationSection("AssociatedFeatures",
                        "Associated Features",
                        "Associated/Features",
                        $"{Group_CommonResources}/AssociatedFeature")
                    .Description("Associated Features Observation",
                        new Markdown()
                            .Paragraph("Used with masses, asymmetries, or calcifications, or may stand alone as " +
                                        "Features when no other abnormality is present.")
                     )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value().Url)
                    .AddFragRef(Self.ObservationNoValueFragment.Value().Url)
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);

                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityArchitecturalDistortion.Value(), Modalities.MG, 0, "*");
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAbnormalityCalcification.Value(), Modalities.MG, 0, "*");
                Self.SliceTargetReference(e, sliceElementDef, Self.ObservedFeature.Value(), Modalities.All, 0, "*");
            });
    }
}
