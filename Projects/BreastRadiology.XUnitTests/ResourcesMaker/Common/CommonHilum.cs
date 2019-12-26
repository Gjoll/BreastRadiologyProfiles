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
        CSTaskVar CommonHilumCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                         "CommonHilum",
                         "Hilum CodeSystem",
                         "Hilum/CodeSystem",
                         "Codes defining hilum values.",
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

        VSTaskVar CommonHilumVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                        "CommonHilum",
                        "Hilum ValueSet",
                        "Hilum/ValueSet",
                        "Codes defining hilum values.",
                        Group_CommonCodes,
                        ResourcesMaker.Self.CommonHilumCS.Value())
            );

        StringTaskVar CommonHilum = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.CommonHilumVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    ResourcesMaker.Self.fc?.Mark(outputPath);
                }

                SDefEditor e = ResourcesMaker.Self.CreateEditorXX("CommonHilum",
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
