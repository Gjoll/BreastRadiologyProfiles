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
        async StringTask CommonObservedState()
        {
            if (this.commonObservedState == null)
                await this.CreateCommonObservedState();
            return this.commonObservedState;
        }
        String commonObservedState = null;

        async VTask CreateCommonObservedState()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs  = await this.CreateCodeSystem(
                    "CommonObservedState",
                    "Observed State",
                    "Observed/State/Values",
                    "Codes for observed state of an abnormality.",
                    Group_CommonCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("Benign",
                        "Benign",
                        new Definition()
                            .Line("Item is considered benign")
                        ),
                    new ConceptDef("BenignAppearing",
                        "Benign Appearing",
                        new Definition()
                            .Line("Item appears to be benign")
                        ),
                    new ConceptDef("ProbablyBenign",
                        "Probably Benign",
                        new Definition()
                            .Line("Item is considered to be probably benign")
                        ),
                    new ConceptDef("NotSeen",
                        "Not Seen",
                        new Definition()
                            .Line("Item was not observed.")
                        ),
                    new ConceptDef("Biopsed",
                        "Biopsed",
                        new Definition()
                            .Line("Item was Biopsed")
                        )
                    })
                ;

                    ValueSet binding = await this.CreateValueSet(
                        "CommonObservedState",
                        "Observed State",
                        "Observed/State/Values",
                        "Codes for observed state of an abnormality.",
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

                SDefEditor e = this.CreateEditor("CommonObservedState",
                        "Observed State",
                        "State",
                        ObservationUrl,
                        $"{Group_CommonResources}/ObservedState",
                        out this.commonObservedState)
                    .Description("Breast Radiology Observed State Observation",
                        new Markdown()
                            .Paragraph("This observations describes an observed change in a previously observed item.")
                            .MissingObservation("an observed change")
                            .Todo(
                                "Do we want benign appearing & probably benign? Define difference."
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
                    .CodedObservationLeafNode(e, "an abnormality observed state", binding)
                    ;
            });
        }
    }
}
