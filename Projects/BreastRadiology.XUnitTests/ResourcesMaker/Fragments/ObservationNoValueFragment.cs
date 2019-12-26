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
        public String ObservationNoValueFragment()
        {
            if (this.observationNoValueFragment == null)
                this.CreateObservationNoValueFragment();
            return this.observationNoValueFragment;
        }
        String observationNoValueFragment = null;

        void CreateObservationNoValueFragment()
        {
            SDefEditor e = this.CreateFragment("BreastRadObservationNoValueFragment",
                "BreastRad Observation NoValue Fragment",
                    "NoValue/Observation/Fragment",
                ObservationUrl,
                out this.observationNoValueFragment)
                .Description("Fragment that constrains Observations to have no explicit value.",
                    new Markdown()
                        .Paragraph("Base fragment for all BreastRad observations that have no explicit value.")
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationFragment())
            ;
            e.Select("value[x]").Zero();
            e.Select("interpretation").Zero();

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Fragment($"Resource fragment used by observations that constrain the value[x] element to cardinality 0..0.")
                ;
        }
    }
}
