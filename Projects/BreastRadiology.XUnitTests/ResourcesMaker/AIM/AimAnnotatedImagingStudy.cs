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
                SDefEditor e = Self.CreateEditor("AimAnnotatedImagingStudy",
                    "AIM Annotated Imaging Study",
                    "Annotated/Imaging Study",
                    ImagingStudyUrl,
                    $"{Group_AimResources}/Aim/AimAnnotatedImagingStudy")
                    .Description("AIM Annotated Imaging Study",
                        new Markdown()
                            //.Todo
                    )
                    .AddFragRef(Self.AimHeaderFragment.Value())
                    .AddFragRef(Self.AimAnnotationPolyLineFragment.Value())
                    ;
                s = e.SDef.Url;
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode("AIM Annotated Imaging Study");
            });
    }
}
