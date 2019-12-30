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
        CSTaskVar ObservedChangeInSizeCS = new CSTaskVar(
             () =>
                 Self.CreateCodeSystem(
                     "ObservedChangeInSizeCS",
                     "Observed Changes CodeSystem",
                     "Observed/Change/CodeSystem",
                     "Observed changes in the size of an abnormality over time code system.",
                     Group_CommonCodes,
                     new ConceptDef[]
                     {
                    new ConceptDef("IncreaseInSize",
                        "Increase In Size",
                        new Definition()
                            .Line("Item has increased in size")
                        ),
                    new ConceptDef("DecreaseInSize",
                        "Decrease In Size",
                        new Definition()
                            .Line("Item has decreased in size")
                        )
                     })
                 );


        VSTaskVar ObservedChangeInSizeVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                    "ObservedChangeInSizeVS",
                    "Observed Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "Observed changes in the size of an abnormality over time value set.",
                    Group_CommonCodes,
                    Self.ObservedChangeInSizeCS.Value()
                    )
            );

        StringTaskVar ObservedChangeInSize = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.ObservedChangeInSizeVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("ObservedChangeInSize",
                        "Observed Changes",
                        "Size Change",
                        ObservationUrl,
                        $"{Group_CommonResources}/ObservedChangeInSize")
                    .Description("Breast Radiology Changes in Size Observation",
                        new Markdown()
                            .MissingObservation("an observed change in size")
                            //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    ;

                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode("an abnormality observed change in size", binding)
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
            });
    }
}
