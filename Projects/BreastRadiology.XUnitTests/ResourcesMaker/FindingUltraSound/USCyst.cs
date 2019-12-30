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
        StringTaskVar USCyst = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateEditor("USCyst",
                        "UltraSound Cyst",
                        "US Cyst",
                        ObservationUrl,
                        $"{Group_USResources}/Cyst")
                    .Description("Breast Radiology UltraSound Cyst Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                            .MissingObservation("a cyst")
                            //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ImagingStudyFragment.Value())
                    ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("UltraSound Cyst")
                    ;

                if (Self.Component_HasMember)
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(Self.BiRadsAssessmentCategory.Value(), 0, "1"),

                    new ProfileTargetSlice(Self.ObservedCount.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.ObservedChangeInState.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.ObservedSize.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.Orientation.Value(), 0, "1"),
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);
                }
                else
                {
                    //$ XXYYZ-Slice
                    Self.ComponentSliceObservedCount(e);
                }
            });
    }
}
