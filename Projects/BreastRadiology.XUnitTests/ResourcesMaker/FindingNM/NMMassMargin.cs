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
        CSTaskVar NMMarginCS = new CSTaskVar(
             () =>
                 Self.CreateCodeSystem(
                     "NMMarginCS",
                     "NM Margin CodeSystem",
                     "NM/Margin/CodeSystem",
                     "NM margin code system.",
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


        VSTaskVar NMMarginVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                        "NMMarginVS",
                        "NM Margin ValueSet",
                        "NM/Margin/ValueSet",
                        "NM margin value set.",
                        Group_NMCodes,
                        Self.NMMarginCS.Value()
                    )
            );


        StringTaskVar NMMargin = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.NMMarginVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("NMMargin",
                    "NM Margin",
                    "NM/Margin",
                    ObservationUrl,
                    $"{Group_NMResources}/Margin")
                    .Description("Breast Radiology NM Margin Observation",
                        new Markdown()
                            .MissingObservation("a margin")
                            .BiradHeader()
                            .BlockQuote("The margin is the edge or border of the lesion. The descriptors of margin, like the descriptors of shape, are important predictors of whether a mass is benign or malignant. ")
                            .BiradFooter()
                            .Todo(
                            )
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode("a NM margin", binding)
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
            });
    }
}
