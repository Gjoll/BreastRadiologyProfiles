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
        //#SDTaskVar BreastBodyLocationOptionalFragment = new SDTaskVar(
        //    (out StructureDefinition  s) =>
        //    {
        //        SDefEditor e = Self.CreateFragment("BreastBodyLocationOptionalFragment",
        //                            "Breast Body Location (Optional) Fragment",
        //                            "Breast/Body/Location/Fragment/(Optional)",
        //                            ObservationUrl)
        //            .Description("Fragment definition for a Optional Breast Body Location",
        //                new Markdown()
        //                .Paragraph("This fragment adds the references for the breast body location extension.")
        //                .Paragraph("The references are optional, meaning that the breast body location may exist.")
        //                //.Todo
        //             )
        //            .AddFragRef(Self.HeaderFragment.Value())
        //            ;
        //        s = e.SDef.Url;

        //        e.IntroDoc
        //            .Fragment($"Resource fragment used by various observations to include an optional breast body location.")
        //            .ReviewedStatus(ReviewStatus.NotReviewed)
        //            ;

        //        e
        //            .Select("bodySite")
        //            .ZeroToOne()
        //            ;
        //        e
        //            .ApplyExtension("breastBodyLocation", Self.BreastBodyLocationExtension.Value(), true, false)
        //            .ZeroToOne()
        //            ;
        //    });
    }
}
