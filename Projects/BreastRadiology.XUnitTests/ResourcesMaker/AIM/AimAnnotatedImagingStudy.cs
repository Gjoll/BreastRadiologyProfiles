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
        String AimAnnotatedImagingStudy()
        {
            if (this.aimAnnotatedImagingStudy == null)
                this.CreateAimAnnotatedImagingStudy();
            return this.aimAnnotatedImagingStudy;
        }
        String aimAnnotatedImagingStudy = null;

        void CreateAimAnnotatedImagingStudy()
        {
                SDefEditor e = this.CreateEditor("AimAnnotatedImagingStudy",
                    "AIM Annotated Imaging Study",
                    "Annotated/Imaging Study",
                    ImagingStudyUrl,
                    $"{Group_AimResources}/Aim/AimAnnotatedImagingStudy")
                    .Description("AIM Annotated Imaging Study",
                        new Markdown()
                            .Todo(
                            )
                    )
                    .AddFragRef(this.AimHeaderFragment())
                    .AddFragRef(this.AimAnnotationPolyLineFragment())
                    ;
            this.aimAnnotatedImagingStudy = e.SDef.Url;
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode("AIM Annotated Imaging Study");
        }
    }
}
