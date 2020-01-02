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
        StringTaskVar ImagingStudyFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateFragment("ImagingStudyFragment",
                        "Imaging Study Fragment",
                        "ImagingStudy",
                        ObservationUrl)
                    .Description("Adds references to imaging studies.",
                        new Markdown()
                            .Paragraph("Fragment that adds derivedFrom references to imaging studies, including AIM annotated imaaging study.")
                     //.Todo
                     )
                    ;
                s = e.SDef.Url;

                e.IntroDoc
                    .IntroFragment($"Imaging Study Fragment")
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(ImagingStudyUrl, 0, "*"),
                    new ProfileTargetSlice(Self.AimAnnotatedImagingStudy.Value(), 0, "1"),
                };
                e.SliceByUrl("derivedFrom", targets);
                e.AddProfileTargets(targets);
            });
    }
}
