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
        async StringTask CommonObservedChangeInSize()
        {
            if (this.commonObservedChangeInSize == null)
                await this.CreateCommonObservedChangeInSize();
            return this.commonObservedChangeInSize;
        }
        String commonObservedChangeInSize = null;

       CSTaskVar CommonObservedChangeInSizeCS = new CSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateCodeSystem(
                    "CommonObservedChangeInSize",
                    "Observed Changes",
                    "Observed/Change/CodeSystem",
                    "Codes defining types of observed changes in the size of an abnormality over time.",
                    Group_CommonCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("IncreaseInSize",
                        "Increase In Size",
                        new Definition()
                            .Line("Item has increased in size")
                        ),
                    new ConceptDef("DecreaseInSize",
                        "Decrease In Size",
                        new Definition()
                            .Line("Item has decreased in size")
                        )
                    })
                );


        VSTaskVar CommonObservedChangeInSizeVS = new VSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateValueSetXX(
                    "CommonObservedChangeInSize",
                    "Observed Changes",
                    "Observed/Change/ValueSet",
                    "Codes defining types of observed changes in the size of an abnormality over time.",
                    Group_CommonCodes,
                    await ResourcesMaker.Self.CommonObservedChangeInSizeCS.Value()
                    )
            );

        async VTask CreateCommonObservedChangeInSize()
        {
            await VTask.Run(async () =>
            {

                ValueSet binding = await this.CommonObservedChangeInSizeVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc?.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("CommonObservedChangeInSize",
                        "Observed Changes",
                        "Changes",
                        ObservationUrl,
                        $"{Group_CommonResources}/ObservedChangeInSize",
                        out this.commonObservedChangeInSize)
                    .Description("Breast Radiology Changes in Size Observation",
                        new Markdown()
                            .MissingObservation("an observed change in size")
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
                    .CodedObservationLeafNode("an abnormality observed change in size", binding)
                    ;
            });
        }
    }
}
