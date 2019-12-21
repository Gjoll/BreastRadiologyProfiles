using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using PreFhir;
using System;
using System.Collections.Generic;
using System.Text;
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;
namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        public async StringTask ObservationBooleanValueFragment()
        {
            if (this.observationBooleanValueFragment == null)
                await this.CreateObservationBooleanValueFragment();
            return this.observationBooleanValueFragment;
        }
        String observationBooleanValueFragment = null;

        /// <summary>
        /// Create ObservationBooleanValueFragment.
        /// </summary>
        /// <returns></returns>
        async VTask CreateObservationBooleanValueFragment()
        {
            await VTask.Run(async () =>
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
                    .AddFragRef(await this.HeaderFragment())
                    .AddFragRef(await this.ObservationFragment())
                    ;

                e.Select("value[x]")
                    .Type("boolean")
                    ;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used to by all observations whose value are a Boolean.")
                    ;
            });
        }
    }
}
