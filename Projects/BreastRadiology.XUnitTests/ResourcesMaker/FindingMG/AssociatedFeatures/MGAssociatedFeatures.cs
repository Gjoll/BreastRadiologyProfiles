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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        StringTaskVar MGAssociatedFeatures = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditor("MGAssociatedFeatures",
                        "Mammography Associated Features",
                        "MG Associated/Features",
                        ObservationUrl,
                        $"{Group_MGResources}/AssociatedFeature")
                    .Description("Mammography Associated Features Observation",
                        new Markdown()
                            .Paragraph("Used with masses, asymmetries, or calcifications, or may stand alone as " +
                                        "Features when no other abnormality is present.")
                            .Todo(
                                "check Cardinality of the following Observation.hasMember targets?"
                            )
                     )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    ;
                s = e.SDef.Url;
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ResourcesMaker.Self.MGSkinRetraction.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGNippleRetraction.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGSkinThickening.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAxillaryAdenopathy.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityArchitecturalDistortion.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityCalcification.Value(), 0, "*")
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);
                }
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Mammography Associated Features")
                    ;
            });
    }
}
