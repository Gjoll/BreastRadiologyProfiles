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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        String CommonObservedChangeInState()
        {
            if (this.commonObservedChangeInState == null)
                this.CreateCommonObservedChangeInState();
            return this.commonObservedChangeInState;
        }
        String commonObservedChangeInState = null;

        CSTaskVar CommonObservedChangeInStateCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                     "CommonObservedChangeInState",
                     "Observed Change In State",
                     "Observed/Change/CodeSystem",
                     "Codes defining types of observed changes in state of an abnormality over time.",
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
                    new ConceptDef("RepresentsChange",
                        "Represents Change",
                        new Definition()
                            .Line("Unspecified change has occured in item")
                        ),
                     })
                 );


        VSTaskVar CommonObservedChangeInStateVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSetXX(
                    "CommonObservedChangeInState",
                    "Observed Change In State",
                    "Observed/Change/ValueSet",
                    "Codes defining types of observed changes in state of an abnormality over time.",
                    Group_CommonCodes,
                    ResourcesMaker.Self.CommonObservedChangeInStateCS.Value()
                    )
            );

        void CreateCommonObservedChangeInState()
        {
            ValueSet binding = this.CommonObservedChangeInStateVS.Value();

            {
                IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                valueSetIntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ValueSet(binding);
                ;
                String outputPath = valueSetIntroDoc.Save();
                this.fc?.Mark(outputPath);
            }

            SDefEditor e = this.CreateEditor("CommonObservedChangeInState",
                    "Observed Change In State",
                    "State Change",
                    ObservationUrl,
                    $"{Group_CommonResources}/ObservedChangeInState")
                .Description("Breast Radiology Observed Change In State Observation",
                    new Markdown()
                        .MissingObservation("an observed change")
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationCodedValueFragment())
                .AddFragRef(this.ObservationLeafFragment())
                ;

            this.commonObservedChangeInState = e.SDef.Url;
            e.Select("value[x]")
                .Type("CodeableConcept")
                .Binding(binding.Url, BindingStrength.Required)
                ;
            e.AddValueSetLink(binding);
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .CodedObservationLeafNode("an abnormality observed change", binding)
                ;
        }
    }
}
