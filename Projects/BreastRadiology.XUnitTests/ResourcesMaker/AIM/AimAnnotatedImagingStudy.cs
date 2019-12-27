using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        StringTaskVar AimAnnotatedImagingStudy = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditor("AimAnnotatedImagingStudy",
                    "AIM Annotated Imaging Study",
                    "Annotated/Imaging Study",
                    ImagingStudyUrl,
                    $"{Group_AimResources}/Aim/AimAnnotatedImagingStudy")
                    .Description("AIM Annotated Imaging Study",
                        new Markdown()
                            .Todo(
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.AimHeaderFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.AimAnnotationPolyLineFragment.Value())
                    ;
                s = e.SDef.Url;
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode("AIM Annotated Imaging Study");
            });
    }
}
