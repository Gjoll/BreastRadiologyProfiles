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

        CSTaskVar CommonObservedChangeInProminanceCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                     "CommonObservedChangeInProminanceCS",
                     "Observed Changes CodeSystem",
                     "Observed/Change/CodeSystem",
                     "Observed changes in Prominance of an abnormality over time code system.",
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
                    "CommonObservedChangeInProminanceVS",
                    "Observed Prominance Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "ValueSet defining types of observed changes in Prominance of an abnormality over time.",
                    Group_CommonCodes,
                    ResourcesMaker.Self.CommonObservedChangeInProminanceCS.Value()
                    )
            );

        StringTaskVar CommonObservedChangeInProminance = new StringTaskVar(
            (out String s) =>
            {

                ValueSet binding = ResourcesMaker.Self.CommonObservedChangeInProminanceVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    ResourcesMaker.Self.fc?.Mark(outputPath);
                }

                SDefEditor e = ResourcesMaker.Self.CreateEditor("CommonObservedChangeInProminance",
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
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationLeafFragment.Value())
                    ;

                s = e.SDef.Url;
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
