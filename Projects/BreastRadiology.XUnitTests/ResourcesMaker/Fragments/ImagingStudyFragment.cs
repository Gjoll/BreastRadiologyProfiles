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
        SDTaskVar ImagingStudyFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("ImagingStudyFragment",
                        "Imaging Study Fragment",
                        "ImagingStudy",
                        ObservationUrl)
                    .Description("Adds references to imaging studies.",
                        new Markdown()
                            .Paragraph("Fragment that adds derivedFrom references to imaging studies, including AIM annotated imaaging study.")
                     )
                    ;
                s = e.SDef;

                e.IntroDoc
                    .Intro($"Imaging Study Fragment")
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                PreFhir.ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, ImagingStudyUrl, "ImagingStudy", 0, "*");
                Self.SliceTargetReference(e, sliceElementDef, Self.AimAnnotatedImagingStudy.Value(), 0, "1");
            });
    }
}
