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
        async StringTask USVascularity()
        {
            if (this.usVascularity == null)
                await this.CreateUSVascularity();
            return this.usVascularity;
        }
        String usVascularity = null;

        async VTask CreateUSVascularity()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs = await this.CreateCodeSystem(
                    "BreastRadUSVascularity",
                    "US Echo Pattern",
                    "US/Vascularity/Values",
                    "Ultra-sound Vascularity codes.",
                    Group_USCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("Adjacent",
                        "Adjacent",
                        new Definition()
                            .Line("Penrad")
                        ),
                    new ConceptDef("IncreaseSurround",
                        "Increase Surround",
                        new Definition()
                            .Line("Penrad")
                        ),
                    new ConceptDef("Increased",
                        "Increased",
                        new Definition()
                            .Line("Penrad")
                        ),
                    new ConceptDef("NoIncrease",
                        "No increase",
                        new Definition()
                            .Line("Penrad")
                        ),
                    new ConceptDef("NotPresent",
                        "Not present",
                        new Definition()
                            .Line("Penrad")
                        ),
                    new ConceptDef("Present",
                        "Present",
                        new Definition()
                            .Line("Penrad")
                        )
                    });

                ValueSet binding = await this.CreateValueSet(
                    "BreastRadUSVascularity",
                    "US Vascularity",
                    "US/Vascularity/Values",
                    "Ultra-sound Vascularity codes.",
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

                SDefEditor e = this.CreateEditor("BreastRadUSVascularity",
                        "US Vascularity",
                        "US/Vascularity",
                        ObservationUrl,
                        $"{Group_USResources}/Vascularity",
                        out this.usVascularity)
                    .Description("Breast Radiology Ultra-Sound Vascularity Observation",
                        new Markdown()
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
                    .CodedObservationLeafNode(e, "an ultra-sound vascularity", binding)
                    ;
            });
        }
    }
}
