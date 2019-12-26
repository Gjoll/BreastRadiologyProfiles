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
        String CommonObservedChangeInSize()
        {
            if (this.commonObservedChangeInSize == null)
                this.CreateCommonObservedChangeInSize();
            return this.commonObservedChangeInSize;
        }
        String commonObservedChangeInSize = null;

        CSTaskVar CommonObservedChangeInSizeCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                     "CommonObservedChangeInSize",
                     "Observed Changes",
                     "Observed/Change/CodeSystem",
                     "Codes defining types of observed changes in the size of an abnormality over time.",
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


        VSTaskVar CommonObservedChangeInSizeVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                    "CommonObservedChangeInSize",
                    "Observed Changes",
                    "Observed/Change/ValueSet",
                    "Codes defining types of observed changes in the size of an abnormality over time.",
                    Group_CommonCodes,
                    ResourcesMaker.Self.CommonObservedChangeInSizeCS.Value()
                    )
            );

        void CreateCommonObservedChangeInSize()
        {
            ValueSet binding = this.CommonObservedChangeInSizeVS.Value();

            {
                IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                valueSetIntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ValueSet(binding);
                ;
                String outputPath = valueSetIntroDoc.Save();
                this.fc?.Mark(outputPath);
            }

            SDefEditor e = this.CreateEditor("CommonObservedChangeInSize",
                    "Observed Changes",
                    "Size Change",
                    ObservationUrl,
                    $"{Group_CommonResources}/ObservedChangeInSize")
                .Description("Breast Radiology Changes in Size Observation",
                    new Markdown()
                        .MissingObservation("an observed change in size")
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment.Value())
                .AddFragRef(this.ObservationCodedValueFragment.Value())
                .AddFragRef(this.ObservationLeafFragment.Value())
                ;

            this.commonObservedChangeInSize = e.SDef.Url;
            e.Select("value[x]")
                .Type("CodeableConcept")
                .Binding(binding.Url, BindingStrength.Required)
                ;
            e.AddValueSetLink(binding);
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .CodedObservationLeafNode("an abnormality observed change in size", binding)
                ;
        }
    }
}
