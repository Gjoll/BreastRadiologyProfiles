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
        async StringTask CommonObservedChanges()
        {
            if (this.commonObservedChanges == null)
                await this.CreateCommonObservedChanges();
            return this.commonObservedChanges;
        }
        String commonObservedChanges = null;

        async VTask CreateCommonObservedChanges()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs = await this.CreateCodeSystem(
                    "CommonObservedChanges",
                    "Observed Changes",
                    "Observed/Change/Values",
                    "Codes defining types of observed changes in an abnormality over time.",
                    Group_CommonCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("New",
                        "New Observation",
                        new Definition()
                            .Line("This is the first time item has been observed")
                        ),
                    new ConceptDef("Stable",
                        "Stable",
                        new Definition()
                            .Line("Observation of item is stable")
                        ),
                    new ConceptDef("NotSigChanged",
                        "Not Significantly Changed",
                        new Definition()
                            .Line("Item observation has not significantly changed")
                        ),
                    new ConceptDef("NoLongerSeen",
                        "No Longer Seen",
                        new Definition()
                            .Line("Item is no longer visible")
                        ),
                    new ConceptDef("IncidentalFind",
                        "Incidental Find",
                        new Definition()
                            .Line("Item observation is an incidental find")
                        ),
                    new ConceptDef("IncreaseInSize",
                        "Increase In Size",
                        new Definition()
                            .Line("Item has increased in size")
                        ),
                    new ConceptDef("DecreaseInSize",
                        "Decrease In Size",
                        new Definition()
                            .Line("Item has decreased in size")
                        ),
                    new ConceptDef("MoreDefined",
                        "More Defined",
                        new Definition()
                            .Line("Item is more defined")
                        ),
                    new ConceptDef("LessDefined",
                        "Less Defined",
                        new Definition()
                            .Line("Item is less defined")
                        ),
                    new ConceptDef("MoreProminent",
                        "More Prominent",
                        new Definition()
                            .Line("Item is more Prominent")
                        ),
                    new ConceptDef("LessProminent",
                        "Less Prominent",
                        new Definition()
                            .Line("Item is less Prominent")
                        ),
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
                ;

                ValueSet binding = await this.CreateValueSet(
                    "CommonObservedChanges",
                    "Observed Changes",
                    "Observed/Change/Values",
                    "Codes defining types of observed changes in an abnormality over time.",
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

                SDefEditor e = this.CreateEditor("CommonObservedChanges",
                        "Observed Changes",
                        "Changes",
                        ObservationUrl,
                        $"{Group_CommonResources}/ObservedChanges",
                        out this.commonObservedChanges)
                    .Description("Breast Radiology Observed Changes Observation",
                        new Markdown()
                            .MissingObservation("an observed change")
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
                    .CodedObservationLeafNode(e, "an abnormality observed change", binding)
                    ;
            });
        }
    }
}
