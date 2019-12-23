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
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        async StringTask USShape()
        {
            if (this.usShape == null)
                await this.CreateUSShape();
            return this.usShape;
        }
        String usShape = null;


        VSTaskVar UltraSoundShapeVS = new VSTaskVar(
            async () =>
            {
                ValueSet binding = await ResourcesMaker.Self.CreateValueSetXX(
                        "UltraSoundShape",
                        "Shape",
                        "Shape/ValueSet",
                        "Codes defining shape values.",
                        Group_USCodes,
                        await ResourcesMaker.Self.CommonShapeCS.Value()
                    );
                binding.Remove("Reniform");
                return binding;
            }
            );


        async VTask CreateUSShape()
        {
            await VTask.Run(async () =>
            {
                ValueSet binding = await this.UltraSoundShapeVS.Value();
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
                        $"{Group_CommonResources}/Shape",
                        out this.usShape)
                    .Description("Breast Radiology Shape Observation",
                        new Markdown()
                            .MissingObservation("a shape")
                            .Todo(
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationCodedValueFragment())
                    .AddFragRef(await this.ObservationLeafFragment())
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode("a shape", binding)
                    ;
            });
        }
    }
}
