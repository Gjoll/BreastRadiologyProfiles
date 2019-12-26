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
                        "Mg Common Targets Fragment",
                        "Mg Common Targets Fragment",
                        ObservationUrl)
                    .Description("Mammography Common Targets Fragment",
                        new Markdown()
                            .Paragraph("Mammography Common Targets Fragment")
                            .Todo(
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.BreastBodyLocationRequiredFragment.Value())
                    ;
                s = e.SDef.Url;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ResourcesMaker.Self.BiRadsAssessmentCategory.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedChangeInDefinition(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedChangeInNumber(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedChangeInProminance(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedChangeInSize(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedChangeInState(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedSize(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonOrientation(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }
            });

    }
}
