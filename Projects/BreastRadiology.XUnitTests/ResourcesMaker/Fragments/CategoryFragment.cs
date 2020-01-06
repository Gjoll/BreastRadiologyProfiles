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
        SDTaskVar CategoryFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("CategoryFragment",
                        "Category Fragment",
                        "Category/Fragment",
                        ObservationUrl)
                    .Description("Fragment definition to define Observation.category",
                        new Markdown()
                            .Paragraph("This fragment slices Observation.category and adds the required observation code value.")
                    );
                s = e.SDef;

                e.IntroDoc
                   .Intro($"Resource fragment used to by observations to fix the Observation.category field to the 'imaging' fixed value.")
                   .ReviewedStatus(ReviewStatus.NotReviewed)
                   ;

                ElementTreeNode eDef = e.Get("category");
                eDef.ElementDefinition.Card(1, eDef.ElementDefinition.Max);
                e.FixedCodeSlice("category", "category",
                    "http://terminology.hl7.org/CodeSystem/observation-category",
                    "imaging");
            });
    }
}
