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
        String MGShape()
        {
            if (this.mgShape == null)
                this.CreateMammoShape();
            return this.mgShape;
        }
        String mgShape = null;


        VSTaskVar MammoShapeVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSetXX(
                        "MammoShape",
                        "Shape",
                        "Shape/ValueSet",
                        "Codes defining shape values.",
                        Group_MGCodes,
                        ResourcesMaker.Self.CommonShapeCS.Value()
                    )
            );


        void CreateMammoShape()
        {
            ValueSet binding = this.MammoShapeVS.Value();
            {
                IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                valueSetIntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ValueSet(binding);
                ;
                String outputPath = valueSetIntroDoc.Save();
                this.fc?.Mark(outputPath);
            }

            SDefEditor e = this.CreateEditor("MammoShape",
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
            this.mgShape = e.SDef.Url;

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
