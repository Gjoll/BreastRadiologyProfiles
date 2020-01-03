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
        StringTaskVar ObservationCodedValueFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateFragment("CodedValueObservationFragment",
                        "CodedValue Observation Fragment",
                        "Observation/CodedValue/Fragment",
                        ObservationUrl)
                    .Description("Fragment that defines values for coded observations",
                        new Markdown()
                            .Paragraph("This fragment constrains an observation to only contain coded values.")
                            //.Todo
                    )
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    ;
                s = e.SDef.Url;

                //$e.IntroDoc
                //    .IntroFragment($"Resource fragment used to by all observations whose value are a CodeableConcept.")
                //    .ReviewedStatus(ReviewStatus.NotReviewed)
                //    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    ;

                e.AddIncompatibleFragment(Self.ObservationNoValueFragment.Value());
            });
    }
}
