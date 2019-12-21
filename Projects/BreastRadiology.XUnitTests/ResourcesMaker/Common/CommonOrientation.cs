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
    partial class ResourcesMaker : ConverterBase
    {
        async StringTask CommonOrientation()
        {
            if (this.orientation == null)
                await this.CreateOrientation();
            return this.orientation;
        }
        String orientation = null;

        async VTask CreateOrientation()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs  = await this.CreateCodeSystem(
                    "CommonOrientation",
                    "Orientation",
                    "Orientation Values",
                    "Orientation codes",
                    Group_CommonCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("Parallel ",
                        "Parallel",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, “wider-than-tall” or “horizontal”)")
                            .Line("The long axis of the mass parallels the skin line. Masses that are only slightly obiquely oriented")
                            .Line("might be considered parallel.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("NotParallel",
                        "Not Parallel",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"isodense\")")
                            .Line("The long axis of the mass does not lie parallel to the skin line. The anterior–posterior or vertical")
                            .Line("dimension is greater than the transverse or horizontal dimension. These masses can also be")
                            .Line("obliquely oriented to the skin line. Round masses are NOT PARALLEL in their orientation.")
                        .CiteEnd(BiRadCitation)
                        )
                    });

                    ValueSet binding = await this.CreateValueSet(
                        "CommonOrientation",
                        "Orientation",
                        "Orientation Values",
                        "Orientation codes",
                        Group_CommonCodes,
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

                SDefEditor e = this.CreateEditor("CommonOrientation",
                        "Orientation",
                        "Orientation",
                        ObservationUrl,
                        $"{Group_CommonResources}/Orientation",
                        out this.orientation)
                    .Description("Breast Radiology Orientation Observation",
                        new Markdown()
                            .MissingObservation("a orientation")
                            .BiradHeader()
                            .BlockQuote("Orientation is defined with reference to the skin")
                            .BlockQuote("line. Obliquely situated masses may follow a radial pattern, and their long axes will help determine")
                            .BlockQuote("classification as parallel or not parallel. Parallel or \"wider-than-tall\" orientation is a property of most")
                            .BlockQuote("benign masses, notably fibroadenomas; however, many carcinomas have this orientation as well.")
                            .BlockQuote("Orientation alone should not be used as an isolated feature in assessing a mass for its likelihood of")
                            .BlockQuote("malignancy.")
                            .BiradFooter()
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
                    .CodedObservationLeafNode(e, "an orientation", binding)
                    ;
            });
        }
    }
}
