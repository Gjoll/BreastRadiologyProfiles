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
        StringTaskVar MGCommonTargetsFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateFragment("MgCommonTargetsFragment",
                        "MG Common Targets Fragment",
                        "MG Common Targets Fragment",
                        ObservationUrl)
                    .Description("Mammography Common Targets Fragment",
                        new Markdown()
                            .Paragraph("Mammography Common Targets Fragment")
                            //.Todo
                    )
                    .AddFragRef(ResourcesMaker.Self.BreastBodyLocationRequiredFragment.Value())
                    ;
                s = e.SDef.Url;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ResourcesMaker.Self.BiRadsAssessmentCategory.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.ObservedChangeInDefinition.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.ObservedChangeInNumber.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.ObservedChangeInProminance.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.ObservedChangeInSize.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.ObservedChangeInState.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.ObservedSize.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.Orientation.Value(), 0, "1"),
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);
                }
            });

    }
}
