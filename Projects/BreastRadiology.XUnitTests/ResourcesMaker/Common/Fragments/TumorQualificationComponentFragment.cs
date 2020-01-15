using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        SDTaskVar TumorQualifierComponentsFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
        {
            SDefEditor e = Self.CreateFragment("TumorQualifierComponentFragment",
                    "Tumor Qualifier Component Fragment",
                    "Tumor Qualifier Component Fragment",
                    ObservationUrl)
                .Description("Tumor Qualifier Component Fragment",
                    new Markdown()
                        .Paragraph("Tumor Qualifier Component Fragment")
                        .Paragraph("Adds Tumor Qualifier Component")
                )
                .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
                ;
            s = e.SDef;

            e.StartComponentSliceing();

            e.ComponentSliceCodeableConcept("tumorQualifier",
                Self.CodeTumorQualifier.ToCodeableConcept(),
                Self.TumorQualifierVS.Value(),
                BindingStrength.Required,
                0,
                "1",
                "TumorQualifier",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that defines if a tumour is the index (primary) tumour or a satellite tumour.",
                                    $"The value of this component is a codeable concept chosen from the {Self.TumorQualifierVS.Value().Name} valueset.")
                );
        });
    }
}
