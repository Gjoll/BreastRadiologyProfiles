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
            SDefEditor e = Self.CreateFragment("MgShapeTargetsFragment",
                    "MG Shape Targets Fragment",
                    "MG Shape Targets Fragment",
                    ObservationUrl)
                .Description("Mammography Shape Targets Fragment",
                    new Markdown()
                        .Paragraph("Shape Common Targets Fragment")
                        .Paragraph("Adds Orientation, Shape, Margin, and Density targets")
                        //.Todo
                )
                .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
                ;
            s = e.SDef.Url;

            if (Self.Component_HasMember)
            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(Self.Orientation.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.Shape.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.Margin.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.MGDensity.Value(), 0, "1"),
                };
                e.SliceByUrl("hasMember", targets);
                e.AddProfileTargets(targets);
            }
            else
            {
                e.StartComponentSliceing();

                e.ComponentSliceCodeableConcept("orientation",
                    Self.CodeOrientation.ToCodeableConcept(),
                    Self.OrientationCS.Value().Url,
                    BindingStrength.Required,
                    0,
                    "1");

                e.ComponentSliceCodeableConcept("shape",
                    Self.CodeShape.ToCodeableConcept(),
                    Self.ShapeCS.Value().Url,
                    BindingStrength.Required,
                    0,
                    "1");

                e.ComponentSliceCodeableConcept("margin",
                    Self.CodeMargin.ToCodeableConcept(),
                    Self.MarginCS.Value().Url,
                    BindingStrength.Required,
                    0,
                    "1");

                e.ComponentSliceCodeableConcept("mgDensity",
                    Self.CodeMGDensity.ToCodeableConcept(),
                    Self.MGDensityCS.Value().Url,
                    BindingStrength.Required,
                    0,
                    "1");
            }
        });
    }
}
