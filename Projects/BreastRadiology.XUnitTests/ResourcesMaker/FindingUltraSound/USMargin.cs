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
        VSTaskVar USMarginVS = new VSTaskVar(
            () =>
            {
                ValueSet binding = ResourcesMaker.Self.CreateValueSet(
                    "USMarginVS",
                    "US Margin ValueSet",
                    "US Margin ValueSet",
                    "Ultra-sound mass margin codes value set.",
                    Group_USCodes,
                    ResourcesMaker.Self.MarginCS.Value());
                binding
                    .Remove("Macrolobulated")
                    .Remove("Obscured")
                    ;
                return binding;
            }
            );


        StringTaskVar USMargin = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.USMarginVS.Value();
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    ResourcesMaker.Self.fc?.Mark(outputPath);
                }

                SDefEditor e = ResourcesMaker.Self.CreateEditor("USMargin",
                        "US Margin",
                        "US Margin",
                        ObservationUrl,
                        $"{Group_USResources}/Margin")
                    .Description("Breast Radiology Ultra-Sound Margin Observation",
                        new Markdown()
                            .MissingObservation("a mass margin")
                            .BiradHeader()
                            .BlockQuote("The margin is the edge or border of the lesion. The descriptors of margin, like the descriptors of shape, are important predictors of whether a mass is benign or malignant. ")
                            .BiradFooter()
                            .Todo(
                                "Is Irregular incorrect? Note from ACR B.3.A. 'Irregular' is not used to group these marginal attributes because irregular describes the shape of a mass.",
                                "Is non-circumscribed a stand along value, or implied by selection fo on or more non-circumscribed values? "
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
                    .CodedObservationLeafNode("a mammography mass margin", binding)
                    ;
            });
    }
}
