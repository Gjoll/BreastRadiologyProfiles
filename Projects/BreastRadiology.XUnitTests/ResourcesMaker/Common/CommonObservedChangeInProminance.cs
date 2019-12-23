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
        async StringTask CommonObservedChangeInProminance()
        {
            if (this.commonObservedChangeInProminance == null)
                await this.CreateCommonObservedChangeInProminance();
            return this.commonObservedChangeInProminance;
        }
        String commonObservedChangeInProminance = null;

       CSTaskVar CommonObservedChangeInProminanceCS = new CSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateCodeSystem(
                    "CommonObservedChangeInProminance",
                    "Observed Changes",
                    "Observed/Change/CodeSystem",
                    "Codes defining types of observed changes in Prominance of an abnormality over time.",
                    Group_CommonCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("MoreProminent",
                        "More Prominent",
                        new Definition()
                            .Line("Item is more Prominent")
                        ),
                    new ConceptDef("LessProminent",
                        "Less Prominent",
                        new Definition()
                            .Line("Item is less Prominent")
                        )
                    })
                );

        VSTaskVar CommonObservedChangeInProminanceVS = new VSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateValueSetXX(
                    "CommonObservedChangeInProminance",
                    "Observed Prominance Changes",
                    "Observed/Change/ValueSet",
                    "Codes defining types of observed changes in Prominance of an abnormality over time.",
                    Group_CommonCodes,
                    await ResourcesMaker.Self.CommonObservedChangeInProminanceCS.Value()
                    )
            );

        async VTask CreateCommonObservedChangeInProminance()
        {
            await VTask.Run(async () =>
            {
                ValueSet binding = await this.CommonObservedChangeInProminanceVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc?.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("CommonObservedChangeInProminance",
                        "Observed Change in Prominance",
                        "Prominance Change",
                        ObservationUrl,
                        $"{Group_CommonResources}/ObservedChangeInProminance",
                        out this.commonObservedChangeInProminance)
                    .Description("Breast Radiology Changes in Prominance Observation",
                        new Markdown()
                            .MissingObservation("an observed change in Prominance")
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
                    .CodedObservationLeafNode("an abnormality observed change in Prominance", binding)
                    ;
            });
        }
    }
}
