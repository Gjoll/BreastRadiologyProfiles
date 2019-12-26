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
        String USShape()
        {
            if (this.usShape == null)
                this.CreateUSShape();
            return this.usShape;
        }
        String usShape = null;


        VSTaskVar UltraSoundShapeVS = new VSTaskVar(
            () =>
            {
                ValueSet binding = ResourcesMaker.Self.CreateValueSetXX(
                        "UltraSoundShape",
                        "Shape",
                        "Shape/ValueSet",
                        "Codes defining shape values.",
                        Group_USCodes,
                        ResourcesMaker.Self.CommonShapeCS.Value()
                    );
                binding.Remove("Reniform");
                return binding;
            }
            );


        void CreateUSShape()
        {
            ValueSet binding = this.UltraSoundShapeVS.Value();
            {
                IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                valueSetIntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ValueSet(binding);
                ;
                String outputPath = valueSetIntroDoc.Save();
                this.fc?.Mark(outputPath);
            }

            SDefEditor e = this.CreateEditor("UltraSoundShape",
                    "Shape",
                    "Shape",
                    ObservationUrl,
                    $"{Group_CommonResources}/Shape")
                .Description("Breast Radiology Shape Observation",
                    new Markdown()
                        .MissingObservation("a shape")
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationCodedValueFragment())
                .AddFragRef(this.ObservationLeafFragment())
                ;

            this.usShape = e.SDef.Url;
            e.Select("value[x]")
                .Type("CodeableConcept")
                .Binding(binding.Url, BindingStrength.Required)
                ;
            e.AddValueSetLink(binding);
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .CodedObservationLeafNode("a shape", binding)
                ;
        }
    }
}
