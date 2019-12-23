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
        async StringTask USElasticity()
        {
            if (this.usElasticity == null)
                await this.CreateUSElasticity();
            return this.usElasticity;
        }
        String usElasticity = null;

       CSTaskVar BreastRadUSElasticityCS = new CSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateCodeSystem(
                    "BreastRadUSElasticity",
                    "US Echo Pattern",
                    "US Elasticity/CodeSystem",
                    "Ultra-sound Elasticity code system.",
                    Group_USCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("Soft",
                        "Soft",
                        new Definition()
                            .Line("Penrad")
                        ),
                    new ConceptDef("Medium",
                        "Medium",
                        new Definition()
                            .Line("Penrad")
                        ),
                    new ConceptDef("Hard",
                        "Hard",
                        new Definition()
                            .Line("Penrad")
                        )
                    })
                );


        VSTaskVar BreastRadUSElasticityVS = new VSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateValueSetXX(
                    "BreastRadUSElasticity",
                    "US Elasticity",
                    "US Elasticity/ValueSet",
                    "Ultra-sound Elasticity code system.",
                    Group_USCodes,
                    await ResourcesMaker.Self.BreastRadUSElasticityCS.Value())
            );

        async VTask CreateUSElasticity()
        {
            await VTask.Run(async () =>
            {
                ValueSet binding = await this.BreastRadUSElasticityVS.Value();
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc?.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("BreastRadUSElasticity",
                        "US Elasticity",
                        "US Elasticity",
                        ObservationUrl,
                        $"{Group_USResources}/Elasticity",
                        out this.usElasticity)
                    .Description("Breast Radiology Ultra-Sound Elasticity Observation",
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
                    .CodedObservationLeafNode("an ultra-sound vascularity", binding)
                    ;
            });
        }
    }
}
