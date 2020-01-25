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
                    .ReviewedStatus("NOONE", "")
                    ;

                {
                    StructureDefinition extensionStructDef = Self.ServiceRecommendationExtension.Value();
                    ElementDefinition extensionDef = e.ApplyExtension("serviceRecommendation", extensionStructDef, true).ElementDefinition
                        .ZeroToMany()
                        .SetDefinition(new Markdown()
                            .Paragraph("References to recommended action to be taken in response to this observation.")
                            .Paragraph("All Service Recommendations for a Breast Radiology Report will be referenced in the Breast Radiology Report, ",
                                       "so that all recommendations can be found in one place.",
                                       "In addition pecific Service Recommendations may also be referenced in an abnormality observations, indicating that the action",
                                       "taken is inresponse to that abnormality observation,",
                                       "or in a finding observation, indicating that the action ",
                                       "taken is in response to one or more of the abnormality observations that are a part of the finding.")
                            .Paragraph("All Service Recommendations referenced in an abnormality observation or finding observation ",
                                       "will always be also referenced in the Breast Radiology Report")
                            )
                        ;
                    e.AddExtensionLink(extensionStructDef.Url,
                        new SDefEditor.Cardinality(extensionDef),
                        "Service Recommendation",
                        Global.ElementAnchor(extensionDef));
                }
            });
    }
}
