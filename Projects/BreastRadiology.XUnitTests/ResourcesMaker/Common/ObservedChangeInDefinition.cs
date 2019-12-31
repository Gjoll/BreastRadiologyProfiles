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

        CSTaskVar ObservedChangeInDefinitionCS = new CSTaskVar(
             () =>
                 Self.CreateCodeSystem(
                     "ObservedChangeInDefinitionCS",
                     "Observed Changes  CodeSystem",
                     "Observed/Change/CodeSystem",
                     "Observed changes in definition of an abnormality over time code system.",
                     Group_CommonCodesCS,
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

        VSTaskVar ObservedChangeInDefinitionVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                    "ObservedChangeInDefinitionVS",
                    "Observed Definition Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "Observed changes in definition of an abnormality over time value set.",
                    Group_CommonCodesVS,
                    Self.ObservedChangeInDefinitionCS.Value())
            );


        StringTaskVar ObservedChangeInDefinition = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.ObservedChangeInDefinitionVS.Value();
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("ObservedChangeInDefinition",
                        "Observed Change in Definition",
                        "Definition Change",
                        ObservationUrl,
                        $"{Group_CommonResources}/ObservedChangeInDefinition")
                    .Description("Breast Radiology Changes in Definition Observation",
                        new Markdown()
                            .MissingObservation("an observed change in definition")
                            //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    ;

                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode("an abnormality observed change in definition", binding)
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
            });
    }
}
