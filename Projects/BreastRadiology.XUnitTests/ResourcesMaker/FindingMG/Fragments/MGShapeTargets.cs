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
        StringTaskVar MGShapeTargetsFragment = new StringTaskVar(
            (out String s) =>
        {
            SDefEditor e = ResourcesMaker.Self.CreateFragment("MgShapeTargetsFragment",
                    "MG Shape Targets Fragment",
                    "MG Shape Targets Fragment",
                    ObservationUrl)
                .Description("Mammography Shape Targets Fragment",
                    new Markdown()
                        .Paragraph("Shape Common Targets Fragment")
                        .Paragraph("Adds Orientation, Shape, Margin, Density and Thickening targets")
                        .Todo(
                        )
                )
                .AddFragRef(ResourcesMaker.Self.BreastBodyLocationRequiredFragment.Value())
                ;
            s = e.SDef.Url;

            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(ResourcesMaker.Self.Orientation.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGShape.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGMargin.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGDensity.Value(), 0, "1"),
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }
        });
    }
}
