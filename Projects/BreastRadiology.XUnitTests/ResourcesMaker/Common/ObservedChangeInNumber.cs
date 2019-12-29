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
        CSTaskVar ObservedChangeInNumberCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                     "ObservedChangeInNumberCS",
                     "Observed Changes CodeSystem",
                     "Observed/Change/CodeSystem",
                     "bserved changes in number of an abnormality over time code system.",
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

        VSTaskVar ObservedChangeInNumberVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                    "ObservedChangeInNumberVS",
                    "Observed Number Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "Observed changes in number of an abnormality over time value set.",
                    Group_CommonCodes,
                    ResourcesMaker.Self.ObservedChangeInNumberCS.Value()
                    )
            );

        StringTaskVar ObservedChangeInNumber = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.ObservedChangeInNumberVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    ResourcesMaker.Self.fc?.Mark(outputPath);
                }

                SDefEditor e = ResourcesMaker.Self.CreateEditor("ObservedChangeInNumber",
                        "Observed Change in Number",
                        "Number Change",
                        ObservationUrl,
                        $"{Group_CommonResources}/ObservedChangeInNumber")
                    .Description("Breast Radiology Changes in Number Observation",
                        new Markdown()
                            .MissingObservation("an observed change in number")
                            .Todo(
                            "Is this change in count, or number of calcifications?"
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationLeafFragment.Value())
                    ;

                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode("an abnormality observed change in number", binding)
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
            });
    }
}
