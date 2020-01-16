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
        SDTaskVar ObservationCodedValueFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("CodedValueObservationFragment",
                        "CodedValue Observation Fragment",
                        "Observation/CodedValue/Fragment",
                        ObservationUrl)
                    .Description("Coded Value Observation Fragment",
                        new Markdown()
                            .Paragraph("Resource fragment used to by all observations whose value are a CodeableConcept.")
                    )
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    ;

                e.AddIncompatibleFragment(Self.ObservationNoValueFragment.Value().Url);
            });
    }
}
