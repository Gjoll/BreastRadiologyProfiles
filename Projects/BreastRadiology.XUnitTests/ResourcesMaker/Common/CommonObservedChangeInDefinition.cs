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

        CSTaskVar CommonObservedChangeInDefinitionCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                     "CommonObservedChangeInDefinitionCS",
                     "Observed Changes  CodeSystem",
                     "Observed/Change/CodeSystem",
                     "Observed changes in definition of an abnormality over time code system.",
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
            () =>
                ResourcesMaker.Self.CreateValueSet(
                    "CommonObservedChangeInDefinitionVS",
                    "Observed Definition Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "ValueSet defining types of observed changes in definition of an abnormality over time.",
                    Group_CommonCodes,
                    ResourcesMaker.Self.CommonObservedChangeInDefinitionCS.Value())
            );


        StringTaskVar CommonObservedChangeInDefinition = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.CommonObservedChangeInDefinitionVS.Value();
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    ResourcesMaker.Self.fc?.Mark(outputPath);
                }

                SDefEditor e = ResourcesMaker.Self.CreateEditor("CommonObservedChangeInDefinition",
                        "Observed Change in Definition",
                        "Definition Change",
                        ObservationUrl,
                        $"{Group_CommonResources}/ObservedChangeInDefinition")
                    .Description("Breast Radiology Changes in Definition Observation",
                        new Markdown()
                            .MissingObservation("an observed change in definition")
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
                    .CodedObservationLeafNode("an abnormality observed change in definition", binding)
                    ;
            });
    }
}
