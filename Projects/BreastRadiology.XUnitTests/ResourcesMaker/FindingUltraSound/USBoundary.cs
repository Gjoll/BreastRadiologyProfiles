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
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        async StringTask USBoundary()
        {
            if (this.usBoundary == null)
                await this.CreateUSBoundary();
            return this.usBoundary;
        }
        String usBoundary = null;

        async VTask CreateUSBoundary()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs = await this.CreateCodeSystem(
                    "USBoundary",
                    "UltraSound Boundary",
                    "US/Boundary/Values",
                    "Ultra Sound Boundary codes.",
                    Group_USCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("WellDefined",
                        "Well defined boundary",
                        new Definition()
                            .Line("Penrad")
                    ),
                    new ConceptDef("Abrupt",
                        "Abrupt boundary",
                        new Definition()
                            .Line("Penrad")
                    ),
                    new ConceptDef("Echogenic",
                        "Echogenic boundary",
                        new Definition()
                            .Line("Penrad")
                    ),
                    new ConceptDef("Hyperechoic",
                        "Hyperechoic boundary",
                        new Definition()
                            .Line("Penrad")
                    )
                    }
                );

                ValueSet binding = await this.CreateValueSet(
                    "USBoundary",
                    "UltraSound Boundary",
                    "US/Boundary/Values",
                    "UltraSound Boundary Codes.",
                    Group_USCodes,
                    cs);

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("BreastRadUSBoundary",
                    "Ultra Sound Boundary",
                    "US/Boundary",
                    ObservationUrl,
                    $"{Group_USResources}/Boundary",
                    out this.usBoundary)
                    .Description("Breast Radiology Ultra-Sound Boundary Observation",
                        new Markdown()
                            .Paragraph("This resource describes an Ultra-Sound boundary observation.")
                            .Paragraph("Penrad")
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
                    .CodedObservationLeafNode(e, "an UltraSound boundary", binding)
                    ;
            });
        }
    }
}
