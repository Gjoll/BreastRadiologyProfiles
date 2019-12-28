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
        StringTaskVar CategoryFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateFragment("CategoryFragment",
                        "Category Fragment",
                        "Category/Fragment",
                        ObservationUrl)
                    .Description("Fragment definition to define Observation.category",
                        new Markdown()
                            .Paragraph("This fragment slices Observation.category and adds the required observation code value.")
                            //.Todo
                    )
                    ;
                s = e.SDef.Url;
                ElementDefGroup eDef = e.GetOrCreate("category");
                eDef.ElementDefinition.Card(1, eDef.BaseElementDefinition.Max);
                e.FixedCodeSlice("category", "category",
                    "http://terminology.hl7.org/CodeSystem/observation-category",
                    "imaging");

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Fragment($"Resource fragment used to by observations to fix the Observation.category field to the 'imaging' fixed value.")
                    ;
            });
    }
}
