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
        String CommonObservedChangeInProminance()
        {
            if (this.commonObservedChangeInProminance == null)
                this.CreateCommonObservedChangeInProminance();
            return this.commonObservedChangeInProminance;
        }
        String commonObservedChangeInProminance = null;

        CSTaskVar CommonObservedChangeInProminanceCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
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
            () =>
                ResourcesMaker.Self.CreateValueSet(
                    "CommonObservedChangeInProminance",
                    "Observed Prominance Changes",
                    "Observed/Change/ValueSet",
                    "Codes defining types of observed changes in Prominance of an abnormality over time.",
                    Group_CommonCodes,
                    ResourcesMaker.Self.CommonObservedChangeInProminanceCS.Value()
                    )
            );

        void CreateCommonObservedChangeInProminance()
        {
            ValueSet binding = this.CommonObservedChangeInProminanceVS.Value();

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
                    $"{Group_CommonResources}/ObservedChangeInProminance")
                .Description("Breast Radiology Changes in Prominance Observation",
                    new Markdown()
                        .MissingObservation("an observed change in Prominance")
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment.Value())
                .AddFragRef(this.ObservationCodedValueFragment.Value())
                .AddFragRef(this.ObservationLeafFragment.Value())
                ;

            this.commonObservedChangeInProminance = e.SDef.Url;
            e.Select("value[x]")
                .Type("CodeableConcept")
                .Binding(binding.Url, BindingStrength.Required)
                ;
            e.AddValueSetLink(binding);
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .CodedObservationLeafNode("an abnormality observed change in Prominance", binding)
                ;
        }
    }
}
