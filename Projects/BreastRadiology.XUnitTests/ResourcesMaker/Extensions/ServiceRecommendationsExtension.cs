using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using PreFhir;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        SDTaskVar ServiceRecommendationExtension = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("ServiceRecommendationExtension",
                    "Service Recommendation Extension",
                    "Service Recommendation/Extension",
                    ExtensionUrl,
                     $"{Group_ExtensionResources}/ServiceRecommendation",
                     "Extension")
                    .Description("Diagnostic Report Service Recommendation extension",
                    new Markdown()
                        .Paragraph("This extension adds references to FHIR clinical recommendation resources resulting from this exam.")
                        .Paragraph("Each recommendation is stored as a seperate Fhir resource instance, with a reference to that instance in this extension.")
                        .Paragraph("This extension can accept references to the following fhir resources:")
                        .List(
                            "Medication Request (FHIR base resource)",
                            "Service Request (FHIR base resource)",
                            "Service Recommendation (Profile of Service Request tailored to typical Breast Radiology Service Requests)"
                        )
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                e.AddFragRef(Self.HeaderFragment.Value());

                e.Select("extension").Zero();
                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url))
                    ;
                ElementDefinition valueXDef = e.Select("value[x]")
                    .TypeReference(MedicationRequestUrl, 
                        ServiceRequestUrl, 
                        Self.ServiceRecommendation.Value().Url)
                    .Single()
                    ;
                e.AddTargetLink(MedicationRequestUrl, new SDefEditor.Cardinality(valueXDef), false);
                e.AddTargetLink(ServiceRequestUrl, new SDefEditor.Cardinality(valueXDef), false);
                e.AddTargetLink(Self.ServiceRecommendation.Value().Url, new SDefEditor.Cardinality(valueXDef), false);
            });
    }
}
