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
    partial class ResourcesMaker
    {
        CSTaskVar HilumCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                         "HilumCodeSystemCS",
                         "Hilum CodeSystem",
                         "Hilum/CodeSystem",
                         "Hilum values code system.",
                         Group_CommonCodes,
                         new ConceptDef[]
                         {
                        new ConceptDef("HilumFatty",
                            "Hilum Fatty",
                            new Definition()
                                .Line("Definition needed")
                            ),
                        new ConceptDef("Hilum Not Fatty",
                            "Hilum Not Fatty",
                            new Definition()
                                .Line("Definition needed")
                            )
                         })
                     );

        VSTaskVar HilumVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                        "HilumVS",
                        "Hilum ValueSet",
                        "Hilum/ValueSet",
                        "Hilum values value set.",
                        Group_CommonCodes,
                        ResourcesMaker.Self.HilumCS.Value())
            );

        StringTaskVar Hilum = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.HilumVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    ResourcesMaker.Self.fc?.Mark(outputPath);
                }

                SDefEditor e = ResourcesMaker.Self.CreateEditor("Hilum",
                        "Hilum Shape",
                        "Hilum/Shape",
                        ObservationUrl,
                        $"{Group_CommonResources}/Hilum")
                    .Description("Breast Radiology Hilum Observation",
                        new Markdown()
                            .MissingObservation("a hilum")
                            .Todo(
                                "Definition(s) needed"
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationLeafFragment.Value())
                    ;

                s = e.SDef.Url;
                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode("a hilum", binding)
                    ;
            });
    }
}
