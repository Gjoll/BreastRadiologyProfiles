using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using PreFhir;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        SDTaskVar BreastBodyLocationRequiredFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("BreastBodyLocationRequiredFragment",
                        "Breast Body Location (Required) Fragment",
                        "Breast Body Location/Fragment (Required)",
                        ObservationUrl)
                    .Description("Required Breast Body Location fragment",
                        new Markdown()
                        .Paragraph("This fragment adds the references for the breast body location extension.")
                        .Paragraph("The references are required, meaning that the breast body location must exist.")
                     )
                    .AddFragRef(Self.HeaderFragment.Value())
                ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e
                    .Select("bodySite")
                    .Single()
                    ;
                e
                    .ApplyExtension("breastBodyLocation", Self.BreastBodyLocationExtension.Value(), true)
                    .Single()
                    ;
            });
    }
}
