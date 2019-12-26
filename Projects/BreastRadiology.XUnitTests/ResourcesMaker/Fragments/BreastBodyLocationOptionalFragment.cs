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
        StringTaskVar BreastBodyLocationOptionalFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateFragment("BreastBodyLocationOptionalFragment",
                                    "Breast Body Location (Optional) Fragment",
                                    "Breast/Body/Location/Fragment/(Optional)",
                                    ObservationUrl)
                    .Description("Fragment definition for a Optional Breast Body Location",
                        new Markdown()
                        .Paragraph("This fragment adds the references for the breast body location extension.")
                        .Paragraph("The references are optional, meaning that the breast body location may exist.")
                        .Todo(
                        )
                     )
                    .AddFragRef(ResourcesMaker.Self.HeaderFragment.Value())
                    .AddExtensionLink(ResourcesMaker.Self.BreastBodyLocationExtension.Value())
                    ;
                s = e.SDef.Url;
                e
                    .Select("bodySite")
                    .ZeroToOne()
                    ;
                e
                    .ApplyExtension("breastBodyLocation", ResourcesMaker.Self.BreastBodyLocationExtension.Value(), true, false)
                    .ZeroToOne()
                    ;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used by various observations to include an optional breast body location.")
                    ;
            });

    }
}
