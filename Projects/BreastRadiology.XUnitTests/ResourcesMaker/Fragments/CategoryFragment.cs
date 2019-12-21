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
        public async StringTask CategoryFragment()
        {
            if (this.findingCategoryFragment == null)
                await this.CreateCategoryFragment();
            return this.findingCategoryFragment;
        }
        String findingCategoryFragment = null;

        /// <summary>
        /// Create Category fragment.
        /// This fragment creates a slice that is bound to the 'imaging' category.
        /// </summary>
        /// <returns></returns>
        async VTask CreateCategoryFragment()
        {
            await VTask.Run(() =>
            {
                SDefEditor e = this.CreateFragment("CategoryFragment",
                        "Category Fragment",
                        "Category/Fragment",
                        ObservationUrl,
                        out this.findingCategoryFragment)
                    .Description("Fragment definition to define Observation.category",
                        new Markdown()
                            .Paragraph("This fragment slices Observation.category and adds the required observation code value.")
                            .Todo(
                            )
                    )
                    ;
                ElementDefGroup eDef = e.Find("category");
                eDef.ElementDefinition.Card(1, eDef.BaseElementDefinition.Max);
                eDef.FixedCodeSlice("category",
                    "http://terminology.hl7.org/CodeSystem/observation-category",
                    "imaging");

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used to by observations to fix the Observation.category field to the 'imaging' fixed value.")
                    ;
            });
        }
    }
}
