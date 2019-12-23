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
        async StringTask CommonObservedChangeInDefinition()
        {
            if (this.commonObservedChangeInDefinition == null)
                await this.CreateCommonObservedChangeInDefinition();
            return this.commonObservedChangeInDefinition;
        }
        String commonObservedChangeInDefinition = null;

       CSTaskVar CommonObservedChangeInDefinitionCS = new CSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateCodeSystem(
                    "CommonObservedChangeInDefinition",
                    "Observed Changes",
                    "Observed/Change/CodeSystem",
                    "Codes defining types of observed changes in definition of an abnormality over time.",
                    Group_CommonCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("MoreDefined",
                        "More Defined",
                        new Definition()
                            .Line("Item is more defined")
                        ),
                    new ConceptDef("LessDefined",
                        "Less Defined",
                        new Definition()
                            .Line("Item is less defined")
                        )
                    })
                );

        VSTaskVar CommonObservedChangeInDefinitionVS = new VSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateValueSetXX(
                    "CommonObservedChangeInDefinition",
                    "Observed Definition Changes",
                    "Observed/Change/ValueSet",
                    "Codes defining types of observed changes in definition of an abnormality over time.",
                    Group_CommonCodes,
                    await ResourcesMaker.Self.CommonObservedChangeInDefinitionCS.Value())
            );


        async VTask CreateCommonObservedChangeInDefinition()
        {
            await VTask.Run(async () =>
            {
                ValueSet binding = await CommonObservedChangeInDefinitionVS.Value();
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc?.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("CommonObservedChangeInDefinition",
                        "Observed Change in Definition",
                        "Changes",
                        ObservationUrl,
                        $"{Group_CommonResources}/ObservedChangeInDefinition",
                        out this.commonObservedChangeInDefinition)
                    .Description("Breast Radiology Changes in Definition Observation",
                        new Markdown()
                            .MissingObservation("an observed change in definition")
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
                    .CodedObservationLeafNode("an abnormality observed change in definition", binding)
                    ;
            });
        }
    }
}
