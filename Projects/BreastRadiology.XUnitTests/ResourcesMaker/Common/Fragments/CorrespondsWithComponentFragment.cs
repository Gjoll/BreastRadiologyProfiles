using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        SDTaskVar CorrespondsWithComponentsFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
        {
            SDefEditor e = Self.CreateFragment("CorrespondsWithComponentFragment",
                    "Corresponds With Component Fragment",
                    "Corresponds With Component Fragment",
                    ObservationUrl)
                .Description("Corresponds WithComponent Fragment",
                    new Markdown()
                        .Paragraph("Corresponds With Component Fragment")
                        .Paragraph("Adds Corresponds With Component")
                )
                .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
                ;
            s = e.SDef;

            e.StartComponentSliceing();

            e.ComponentSliceCodeableConcept("CorrespondsWith",
                Self.CodeCorrespondsWith.ToCodeableConcept(),
                Self.CorrespondsWithVS.Value(),
                BindingStrength.Required,
                0,
                "*",
                "CorrespondsWith",
                    new Markdown()
                        .Paragraph($"This slice contains zero or more components that define correspondences with this abnormality.",
                                    $"The value of this component is a codeable concept chosen from the {Self.CorrespondsWithVS.Value().Name} valueset.")
                );
        });
    }
}
