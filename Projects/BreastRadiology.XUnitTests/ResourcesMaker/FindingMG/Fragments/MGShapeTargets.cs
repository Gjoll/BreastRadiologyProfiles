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
        SDTaskVar MGShapeTargetsFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
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
                .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value().Url)
                ;
            s = e.SDef;

            e.StartComponentSliceing();

            e.ComponentSliceCodeableConcept("orientation",
                Self.CodeOrientation.ToCodeableConcept(),
                Self.OrientationVS.Value(),
                BindingStrength.Required,
                0,
                "1",
                "Orientation");

            e.ComponentSliceCodeableConcept("shape",
                Self.CodeShape.ToCodeableConcept(),
                Self.ShapeVS.Value(),
                BindingStrength.Required,
                0,
                "1",
                "Shape");

            e.ComponentSliceCodeableConcept("margin",
                Self.CodeMargin.ToCodeableConcept(),
                Self.MarginVS.Value(),
                BindingStrength.Required,
                0,
                "1",
                "Margin");

            e.ComponentSliceCodeableConcept("mgDensity",
                Self.CodeMGDensity.ToCodeableConcept(),
                Self.MGDensityVS.Value(),
                BindingStrength.Required,
                0,
                "1",
                "Density");
        });
    }
}
