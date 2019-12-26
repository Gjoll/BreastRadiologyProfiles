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
        public String CategoryFragment()
        {
            if (this.findingCategoryFragment == null)
                this.CreateCategoryFragment();
            return this.findingCategoryFragment;
        }
        String findingCategoryFragment = null;

        /// <summary>
        /// Create Category fragment.
        /// This fragment creates a slice that is bound to the 'imaging' category.
        /// </summary>
        /// <returns></returns>
        void CreateCategoryFragment()
        {
            SDefEditor e = this.CreateFragment("CategoryFragment",
                    "Category Fragment",
                    "Category/Fragment",
                    ObservationUrl)
                .Description("Fragment definition to define Observation.category",
                    new Markdown()
                        .Paragraph("This fragment slices Observation.category and adds the required observation code value.")
                        .Todo(
                        )
                )
                ;
            this.findingCategoryFragment = e.SDef.Url;
            ElementDefGroup eDef = e.Find("category");
            eDef.ElementDefinition.Card(1, eDef.BaseElementDefinition.Max);
            eDef.FixedCodeSlice("category",
                "http://terminology.hl7.org/CodeSystem/observation-category",
                "imaging");

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .Fragment($"Resource fragment used to by observations to fix the Observation.category field to the 'imaging' fixed value.")
                ;
        }
    }
}
