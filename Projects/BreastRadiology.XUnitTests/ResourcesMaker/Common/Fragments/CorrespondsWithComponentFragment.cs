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
                .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value().Url)
                ;
            s = e.SDef;

            e.StartComponentSliceing();

            e.ComponentSliceCodeableConcept("CorrespondsWith",
                Self.CodeCorrespondsWith.ToCodeableConcept(),
                Self.CorrespondsWithVS.Value(),
                BindingStrength.Required,
                0,
                "*",
                "CorrespondsWith");
        });
    }
}
