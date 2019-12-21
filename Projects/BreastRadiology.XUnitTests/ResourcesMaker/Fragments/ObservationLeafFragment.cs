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
        public async StringTask ObservationLeafFragment()
        {
            if (this.observationLeafFragment == null)
                await this.CreateObservationLeafFragment();
            return this.observationLeafFragment;
        }
        String observationLeafFragment = null;

        async VTask CreateObservationLeafFragment()
        {
            await VTask.Run(async () =>
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
                    .AddFragRef(await this.HeaderFragment())
                    .AddFragRef(await this.CategoryFragment())
                    .AddFragRef(await this.ObservationFragment())
                ;
                e.Select("hasMember").Zero();

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used by resources that are leaf node observations.")
                    ;
            });
        }
    }
}
