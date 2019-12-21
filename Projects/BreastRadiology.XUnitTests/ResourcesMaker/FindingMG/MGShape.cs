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
        async StringTask MGShape()
        {
            if (this.mgShape == null)
                await this.CreateMammoShape();
            return this.mgShape;
        }
        String mgShape = null;

        async VTask CreateMammoShape()
        {
            await VTask.Run(async () =>
            {
                ValueSet binding = await this.CreateValueSet(
                        "MammoShape",
                        "Shape",
                        "Shape/Values",
                        "Codes defining shape values.",
                        Group_MGCodes,
                        await this.CommonCSShape());
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("MammoShape",
                        "Shape",
                        "Shape",
                        ObservationUrl,
                        $"{Group_CommonResources}/Shape",
                        out this.mgShape)
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
                    .CodedObservationLeafNode(e, "a shape", binding)
                    ;
            });
        }
    }
}
