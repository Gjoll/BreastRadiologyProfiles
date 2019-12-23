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
        async StringTask CommonObservedChangeInNumber()
        {
            if (this.commonObservedChangeInNumber == null)
                await this.CreateCommonObservedChangeInNumber();
            return this.commonObservedChangeInNumber;
        }
        String commonObservedChangeInNumber = null;

       CSTaskVar CommonObservedChangeInNumberCS = new CSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateCodeSystem(
                    "CommonObservedChangeInNumber",
                    "Observed Changes",
                    "Observed/Change/CodeSystem",
                    "Codes defining types of observed changes in number of an abnormality over time.",
                    Group_CommonCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("IncrInNumber",
                        "Increased In Number",
                        new Definition()
                            .Line("Item(s) have increased in number")
                        ),
                    new ConceptDef("DecrInNumber",
                        "Decreased In Number",
                        new Definition()
                            .Line("Item(s) have decreased in number")
                        ),
                    })
                );

        VSTaskVar CommonObservedChangeInNumberVS = new VSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateValueSetXX(
                    "CommonObservedChangeInNumber",
                    "Observed Number Changes",
                    "Observed/Change/ValueSet",
                    "Codes defining types of observed changes in number of an abnormality over time.",
                    Group_CommonCodes,
                    await ResourcesMaker.Self.CommonObservedChangeInNumberCS.Value()
                    )
            );

        async VTask CreateCommonObservedChangeInNumber()
        {
            await VTask.Run(async () =>
            {
                ValueSet binding = await this.CommonObservedChangeInNumberVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc?.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("CommonObservedChangeInNumber",
                        "Observed Change in Number",
                        "Changes",
                        ObservationUrl,
                        $"{Group_CommonResources}/ObservedChangeInNumber",
                        out this.commonObservedChangeInNumber)
                    .Description("Breast Radiology Changes in Number Observation",
                        new Markdown()
                            .MissingObservation("an observed change in number")
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
                    .CodedObservationLeafNode("an abnormality observed change in number", binding)
                    ;
            });
        }
    }
}
