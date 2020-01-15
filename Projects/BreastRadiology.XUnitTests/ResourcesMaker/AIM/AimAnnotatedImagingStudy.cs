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
        SDTaskVar AimAnnotatedImagingStudy = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("AimAnnotatedImagingStudy",
                    "AIM Annotated Imaging Study",
                    "Annotated/Imaging Study",
                    ImagingStudyUrl,
                    $"{Group_AimResources}/Aim/AimAnnotatedImagingStudy",
                    "Extension")
                    .Description("AIM Annotated Imaging Study",
                        new Markdown()
                    )
                    .AddFragRef(Self.AimHeaderFragment.Value())
                    .AddFragRef(Self.AimAnnotationPolyLineFragment.Value())
                    ;
                s = e.SDef;
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Intro("#Add Content")
                    ;
            });
    }
}
