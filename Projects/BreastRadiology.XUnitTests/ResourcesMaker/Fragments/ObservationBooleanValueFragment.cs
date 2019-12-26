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
        public String ObservationBooleanValueFragment()
        {
            if (this.observationBooleanValueFragment == null)
                this.CreateObservationBooleanValueFragment();
            return this.observationBooleanValueFragment;
        }
        String observationBooleanValueFragment = null;

        /// <summary>
        /// Create ObservationBooleanValueFragment.
        /// </summary>
        /// <returns></returns>
        void CreateObservationBooleanValueFragment()
        {
            SDefEditor e = this.CreateFragment("BooleanValueObservationFragment",
                    "BooleanValue Observation Fragment",
                    "Observation/BooleanValue/Fragment",
                    ObservationUrl,
                    out this.observationBooleanValueFragment)
                .Description("Fragment to define a boolean observation",
                new Markdown()
                    .Paragraph("Fragment that constrains an observation to contains only a boolean value.")
                    .Todo(
                    )
                    )
                .AddFragRef(this.HeaderFragment())
                .AddFragRef(this.ObservationFragment())
                ;

            e.Select("value[x]")
                .Type("boolean")
                ;

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Fragment($"Resource fragment used to by all observations whose value are a Boolean.")
                ;
        }
    }
}
