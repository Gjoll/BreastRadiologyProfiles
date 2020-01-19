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
                .Description("Shape component slice fragment",
                    new Markdown()
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
                "Orientation",
                new Markdown()
                    .Paragraph($"This slice contains the optional component that define the orientation of the abnormality.",
                                $"The value of this component is a codeable concept chosen from the {Self.OrientationVS.Value().Name} valueset.")
                );

            e.ComponentSliceCodeableConcept("shape",
                Self.CodeShape.ToCodeableConcept(),
                Self.ShapeVS.Value(),
                BindingStrength.Required,
                0,
                "1",
                "Shape",
                new Markdown()
                    .Paragraph($"This slice contains the optional component that defines the shape of the abnormality.",
                                $"The value of this component is a codeable concept chosen from the {Self.ShapeVS.Value().Name} valueset.")
                );

            e.ComponentSliceCodeableConcept("margin",
                Self.CodeMargin.ToCodeableConcept(),
                Self.MarginVS.Value(),
                BindingStrength.Required,
                0,
                "1",
                "Margin",
                new Markdown()
                    .Paragraph($"This slice contains the optional component that defines the observed margin of the abnormality.",
                                $"The value of this component is a codeable concept chosen from the {Self.MarginVS.Value().Name} valueset.")
                );

            e.ComponentSliceCodeableConcept("mgDensity",
                Self.CodeMGDensity.ToCodeableConcept(),
                Self.MGDensityVS.Value(),
                BindingStrength.Required,
                0,
                "1",
                "Density",
                new Markdown()
                    .Paragraph($"This slice contains the optional component that defines the observed density of the breast tissue.",
                                $"The value of this component is a codeable concept chosen from the {Self.MGDensityVS.Value().Name} valueset."),
                Modalities.MG
                );
        });
    }
}
