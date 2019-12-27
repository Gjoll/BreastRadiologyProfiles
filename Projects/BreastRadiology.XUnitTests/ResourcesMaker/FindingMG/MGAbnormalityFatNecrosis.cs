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
        StringTaskVar MGAbnormalityFatNecrosis = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditorXX("BreastRadMammoAbnormalityFatNecrosis",
                        "Mammography Fat Necrosis",
                        "MG Fat Necrosis",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityFatNecrosis")
                    .Description("Breast Radiology Mammography Fat Necrosis Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                            .MissingObservation("a fat necrosis abnormality")
                            .Todo(
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationSectionFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ImagingStudyFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.MGShapeTargetsFragment.Value())
                    ;

                s = e.SDef.Url;
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedCount.Value(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Mammography Fat Necrosis")
                    ;
            });
    }
}
