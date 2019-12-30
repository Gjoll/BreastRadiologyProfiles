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
        VSTaskVar MGMarginVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                    "MGMarginVS",
                    "Mammography Margin ValueSet",
                    "MG MarginValueSet",
                    "Mammography margin ValueSet.",
                    Group_MGCodes,
                    Self.MarginCS.Value()
                    )
            );


        StringTaskVar MGMargin = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.MGMarginVS.Value();
                binding
                    .Remove("IntraductalExtension")
                    .Remove("Lobulated")
                    .Remove("NonCircumscribed")
                    .Remove("Smooth")
                    ;
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("MGMargin",
                    "Mammography Margin",
                    "MG Margin",
                    ObservationUrl,
                    $"{Group_MGResources}/Margin")
                    .Description("Breast Radiology Mammography Margin Observation",
                        new Markdown()
                            .MissingObservation("a margin")
                            .BiradHeader()
                            .BlockQuote("The margin is the edge or border of the lesion. The descriptors of margin, like the descriptors of shape, are important predictors of whether a mass is benign or malignant. ")
                            .BiradFooter()
                            //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode("a mammography margin", binding)
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
            });
    }
}
