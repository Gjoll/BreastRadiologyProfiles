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
                SDefEditor e = Self.CreateEditorObservationLeaf("MGAbnormalityFatNecrosis",
                        "Mammography Fat Necrosis",
                        "MG Fat Necrosis",
                        $"{Group_MGResources}/AbnormalityFatNecrosis")
                    .Description("Breast Radiology Mammography Fat Necrosis Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                            .MissingObservation("a fat necrosis abnormality")
                    //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ImagingStudyFragment.Value())
                    .AddFragRef(Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(Self.MGShapeTargetsFragment.Value())
                    ;

                s = e.SDef.Url;

                //$e.IntroDoc
                //    .ObservationSection("Fat Necrosis")
                //    .ReviewedStatus(ReviewStatus.NotReviewed)
                //    ;

                e.Select("value[x]").Zero();
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(Self.ConsistentWith.Value(), 0, "*"),
                };
                e.SliceByUrl("hasMember", targets);
                e.AddProfileTargets(targets);

                e.StartComponentSliceing();
                Self.ComponentSliceObservedCount(e);
            });
    }
}
