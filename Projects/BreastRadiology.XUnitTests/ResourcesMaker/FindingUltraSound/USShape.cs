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
        VSTaskVar UltraSoundShapeVS = new VSTaskVar(
            () =>
            {
                ValueSet binding = Self.CreateValueSet(
                        "UltraSoundShapeVS",
                        "ShapeValueSet",
                        "Shape/ValueSet",
                        "Shape values value set.",
                        Group_USCodesVS,
                        Self.ShapeCS.Value()
                    );
                binding.Remove("Reniform");
                return binding;
            }
            );


        StringTaskVar USShape = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.UltraSoundShapeVS.Value();
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("UltraSoundShape",
                        "Shape",
                        "Shape",
                        ObservationUrl,
                        $"{Group_CommonResources}/Shape")
                    .Description("Breast Radiology Shape Observation",
                        new Markdown()
                            .MissingObservation("a shape")
                            //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    ;

                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode("a shape", binding)
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
            });
    }
}
