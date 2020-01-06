using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using PreFhir;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        //#SDTaskVar BooleanValueObservationFragment = new SDTaskVar(
        //    (out StructureDefinition  s) =>
        //    {
        //        SDefEditor e = Self.CreateFragment("BooleanValueObservationFragment",
        //                "BooleanValue Observation Fragment",
        //                "Observation/BooleanValue/Fragment",
        //                ObservationUrl)
        //            .Description("Fragment to define a boolean observation",
        //            new Markdown()
        //                .Paragraph("Fragment that constrains an observation to contains only a boolean value.")
        //                )
        //            .AddFragRef(Self.ObservationNoComponentFragment.Value())
        //            ;
        //        s = e.SDef.Url;

        //        e.IntroDoc
        //            .Fragment($"Resource fragment used to by all observations whose value are a Boolean.")
        //            .ReviewedStatus(ReviewStatus.NotReviewed)
        //            ;

        //        e.Select("value[x]")
        //            .Type("boolean")
        //            ;

        //        e.AddIncompatibleFragment(Self.ObservationNoValueFragment.Value());
        //    });

    }
}
