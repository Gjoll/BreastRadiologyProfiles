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
        SDTaskVar ServiceRecommendationFragment = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateFragment("ServiceRecommendationFragment",
                        "Service Recommendation Fragment",
                        "Service Recommendation/Fragment",
                        ObservationUrl)
                    .Description("Service Recommendation Fragment fragment",
                        new Markdown()
                        .Paragraph("This fragment adds the references for the service recommendation extension.")
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
                ElementDefinition extensionDef = e
                    .ApplyExtension("serviceRecommendation", Self.ServiceRecommendationExtension.Value(), true)
                    .Single()
                    ;
                e.AddExtensionLink(extensionDef);
            });
    }
}
