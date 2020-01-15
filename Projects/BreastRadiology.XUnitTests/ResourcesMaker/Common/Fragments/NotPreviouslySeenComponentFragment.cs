using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        SDTaskVar NotPreviouslySeenComponentsFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
        {
            SDefEditor e = Self.CreateFragment("NotPreviouslySeenComponentFragment",
                    "Not Previously Seen Component Fragment",
                    "Not Previously Seen Component Fragment",
                    ObservationUrl)
                .Description("Not Previously SeenComponent Fragment",
                    new Markdown()
                        .Paragraph("Not Previously Seen Component Fragment")
                        .Paragraph("Adds NotPreviously Seen Component")
                )
                .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
                ;
            s = e.SDef;

            e.StartComponentSliceing();

            e.ComponentSliceCodeableConcept("notPreviouslySeen",
                Self.CodeNotPreviouslySeen.ToCodeableConcept(),
                Self.NotPreviouslySeenVS.Value(),
                BindingStrength.Required,
                0,
                "*",
                "NotPreviouslySeen",
                    new Markdown()
                        .Paragraph($"This slice contains zero or more components that define prevous encounters in which this abnormality was not seen.",
                                    $"The value of this component is a codeable concept chosen from the {Self.NotPreviouslySeenVS.Value().Name} valueset.")
                );
        });
    }
}
