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
        CSTaskVar NMMassMarginCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                     "BreastRadNMMassMargin",
                     "NM Mass Margin",
                     "NM/Mass/Margin/CodeSystem",
                     "NM mass margin code system.",
                     Group_NMCodes,
                     new ConceptDef[]
                     {
                    new ConceptDef("Circumscribed ",
                        "Circumscribed Margin",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"well defined\" or \"sharply defined\")")
                            .Line("The margin is sharply demarcated with an abrupt transition between the lesion and the surrounding tissue.")
                        .CiteEnd(BiRadCitation)
                        )
                     })
                 );


        VSTaskVar NMMassMarginVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                        "BreastRadNMMassMargin",
                        "NM Mass Margin",
                        "NM/Mass/Margin/ValueSet",
                        "NM mass margin value set.",
                        Group_NMCodes,
                        ResourcesMaker.Self.NMMassMarginCS.Value()
                    )
            );


        StringTaskVar NMMassMargin = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.NMMassMarginVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    ResourcesMaker.Self.fc?.Mark(outputPath);
                }

                SDefEditor e = ResourcesMaker.Self.CreateEditorXX("BreastRadNMMassMargin",
                    "NM Mass Margin",
                    "NM/Mass/Margin",
                    ObservationUrl,
                    $"{Group_NMResources}/Mass/Margin")
                    .Description("Breast Radiology NM Mass Margin Observation",
                        new Markdown()
                            .MissingObservation("a mass margin")
                            .BiradHeader()
                            .BlockQuote("The margin is the edge or border of the lesion. The descriptors of margin, like the descriptors of shape, are important predictors of whether a mass is benign or malignant. ")
                            .BiradFooter()
                            .Todo(
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
                    .CodedObservationLeafNode("a NM mass margin", binding)
                    ;
            });
    }
}
