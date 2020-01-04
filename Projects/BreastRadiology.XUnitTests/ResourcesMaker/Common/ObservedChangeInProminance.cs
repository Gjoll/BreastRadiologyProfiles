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

        CSTaskVar ObservedChangeInProminanceCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "ObservedChangeInProminanceCS",
                     "Observed Changes CodeSystem",
                     "Observed/Change/CodeSystem",
                     "Observed changes in Prominance of an abnormality over time code system.",
                     Group_CommonCodesCS,
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

        VSTaskVar ObservedChangeInProminanceVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ObservedChangeInProminanceVS",
                    "Observed Prominance Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "Observed changes in Prominance of an abnormality over time value set.",
                    Group_CommonCodesVS,
                    Self.ObservedChangeInProminanceCS.Value()
                    )
            );

        //#SDTaskVar ObservedChangeInProminance = new SDTaskVar(
        //    (out StructureDefinition  s) =>
        //    {

        //        ValueSet binding = Self.ObservedChangeInProminanceVS.Value();

        //        {
        //            IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
        //            valueSetIntroDoc
        //                .ValueSet(binding);
        //                .ReviewedStatus(ReviewStatus.NotReviewed)
        //            ;
        //            String outputPath = valueSetIntroDoc.Save();
        //            Self.fc?.Mark(outputPath);
        //        }

        //        SDefEditor e = Self.CreateEditor("ObservedChangeInProminance",
        //                "Observed Change in Prominance",
        //                "Prominance Change",
        //                ObservationUrl,
        //                $"{Group_CommonResources}/ObservedChangeInProminance")
        //            .Description("Breast Radiology Changes in Prominance Observation",
        //                new Markdown()
        //                    .MissingObservation("an observed change in Prominance")
        //                    //.Todo
        //            )
        //            .AddFragRef(Self.ObservationNoDeviceFragment.Value())
        //            .AddFragRef(Self.ObservationCodedValueFragment.Value())
        //            .AddFragRef(Self.ObservationLeafFragment.Value())
        //            ;

        //        s = e.SDef.Url;

        //        e.IntroDoc
        //            .CodedObservationLeafNode("an abnormality observed change in Prominance", binding)
        //            .ReviewedStatus(ReviewStatus.NotReviewed)
        //            ;

        //        e.Select("value[x]")
        //            .Type("CodeableConcept")
        //            .Binding(binding.Url, BindingStrength.Required)
        //            ;
        //        e.AddValueSetLink(binding);
        //    });
    }
}
