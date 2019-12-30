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
        StringTaskVar ObservationFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateFragment("BreastRadObservationFragment",
                    "BreastRad Observation Fragment",
                        "Observation/Fragment",
                    ObservationUrl)
                    .Description("Base fragment for all BreastRad observations.",
                        new Markdown()
                            .Paragraph("Base fragment that performs common constrains used in all breast radiology observations.")
                            //.Todo
                    )
                    .AddFragRef(Self.HeaderFragment.Value())
                    .AddFragRef(Self.CategoryFragment.Value())
                ;
                s = e.SDef.Url;
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used by all BreatRad observations.")
                    ;

                e.Select("subject").Single();

                e.Select("interpretation").Zero();
                e.Select("referenceRange").Zero();
                e.Select("basedOn").Zero();
                //e.Select("derivedFrom").Zero();
                e.Select("partOf").Zero();
                e.Select("focus").Zero();
                e.Select("specimen").Zero();
                e.Select("contained").Zero();

            });

    }
}
