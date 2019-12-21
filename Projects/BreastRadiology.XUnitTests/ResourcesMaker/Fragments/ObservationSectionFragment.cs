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
        public async StringTask ObservationSectionFragment()
        {
            if (this.observationSectionFragment == null)
                await this.CreateObservationSectionFragment();
            return this.observationSectionFragment;
        }
        String observationSectionFragment = null;


        async VTask CreateObservationSectionFragment()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateFragment("ObservationSectionFragment",
                        "Observation Section Fragment",
                        "Section/Fragment",
                        ObservationUrl,
                        out this.observationSectionFragment)
                    .Description("Fragment that constrains Observations to be sections.",
                        new Markdown()
                            .Paragraph("this fragment constrains a generic observation to be a observation section.")
                            .Todo(
                            )
                     )
                    .AddFragRef(await this.ObservationFragment())
                    ;

                e.Select("value[x]").Zero();
                e.Select("interpretation").Zero();
                e.Select("note").Zero();
                e.Select("method").Zero();

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used by observations that are used as report sections.")
                    ;
            });
        }
    }
}
