using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        SDTaskVar ShapeComponentsFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
        {
            SDefEditor e = Self.CreateFragment("ShapeComponentsFragment",
                    "Shape Components Fragment",
                    "Shape Components Fragment",
                    ObservationUrl)
                .Description("Shape Components Fragment",
                    new Markdown()
                        .Paragraph("Shape Common Components Fragment")
                        .Paragraph("Adds Orientation, Shape, Margin, and Density Components")
                )
                .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
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
                "Density",
                Modalities.MG);
        });
    }
}
