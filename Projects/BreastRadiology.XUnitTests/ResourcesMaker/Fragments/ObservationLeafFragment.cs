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
        public String ObservationLeafFragment()
        {
            if (this.observationLeafFragment == null)
                this.CreateObservationLeafFragment();
            return this.observationLeafFragment;
        }
        String observationLeafFragment = null;

        void CreateObservationLeafFragment()
        {
            SDefEditor e = this.CreateFragment("ObservationLeafFragment",
                "Observation Leaf Fragment",
                    "Observation/Leaf/Fragment",
                ObservationUrl,
                out this.observationLeafFragment)
                .Description("Fragment that contstrains all observations that are leaf nodes.",
                    new Markdown()
                        .Paragraph("Fragment that constrains observations leaf nodes (no hasMembers references).")
                        .Todo(
                        )
                )
                .AddFragRef(this.HeaderFragment())
                .AddFragRef(this.CategoryFragment())
                .AddFragRef(this.ObservationFragment())
            ;
            e.Select("hasMember").Zero();

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Fragment($"Resource fragment used by resources that are leaf node observations.")
                ;
        }
    }
}
