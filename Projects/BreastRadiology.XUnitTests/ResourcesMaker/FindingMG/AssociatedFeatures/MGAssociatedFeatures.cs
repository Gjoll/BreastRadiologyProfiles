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
                SDefEditor e = Self.CreateEditorObservationSection("MGAssociatedFeatures",
                        "Mammography Associated Features",
                        "MG Associated/Features",
                        $"{Group_MGResources}/AssociatedFeature")
                    .Description("Mammography Associated Features Observation",
                        new Markdown()
                            .Paragraph("Used with masses, asymmetries, or calcifications, or may stand alone as " +
                                        "Features when no other abnormality is present.")
                            .Todo(
                                "check Cardinality of the following Observation.hasMember targets?"
                            )
                     )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    ;
                s = e.SDef.Url;

                //$e.IntroDoc
                //    .ObservationSection("Mammography Associated Features")
                //    .ReviewedStatus(ReviewStatus.NotReviewed)
                //    ;

                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(Self.MGSkinRetraction.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.MGNippleRetraction.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.MGSkinThickening.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAxillaryAdenopathy.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.MGAbnormalityArchitecturalDistortion.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAbnormalityCalcification.Value(), 0, "*")
                };
                e.SliceByUrl("hasMember", targets);
                e.AddProfileTargets(targets);
            });
    }
}
