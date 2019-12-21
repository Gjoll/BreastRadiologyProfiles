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
        public async StringTask ObservationCodedValueFragment()
        {
            if (this.observationCodedValueFragment == null)
                await this.CreateObservationCodedValueFragment();
            return this.observationCodedValueFragment;
        }
        String observationCodedValueFragment = null;

        /// <summary>
        /// Create ObservationCodedValueFragment.
        /// </summary>
        /// <returns></returns>
        async VTask CreateObservationCodedValueFragment()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateFragment("CodedValueObservationFragment",
                        "CodedValue Observation Fragment",
                        "Observation/CodedValue/Fragment",
                        ObservationUrl,
                        out this.observationCodedValueFragment)
                    .Description("Fragment that defines values for coded observations",
                        new Markdown()
                            .Paragraph("This fragment constrains an observation to only contain coded values.")
                            .Todo(
                            )
                    )
                    .AddFragRef(await this.HeaderFragment())
                    .AddFragRef(await this.ObservationFragment())
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    ;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used to by all observations whose value are a CodeableConcept.")
                    ;
            });
        }
    }
}
