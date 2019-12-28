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
        StringTaskVar SectionFindingsRightBreast = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditor("SectionFindingsRightBreast",
                        "Findings Right Breast",
                        "Right Breast",
                        ObservationUrl,
                        $"{Group_BaseResources}/Findings/RightBreast")
                    .Description("Findings Right Breast Section",
                        new Markdown()
                        .Paragraph("This resource is the head of the tree of observations made of the right breast during a breast radiology exam.")
                        .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                        //.Todo
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationSectionFragment.Value())
                    ;
                s = e.SDef.Url;
                e.Select("value[x]").Zero();
                e.Select("bodySite").Zero();
                e.SliceByUrl("hasMember", ResourcesMaker.Self.FindingBreastTargets());
                e.AddProfileTargets(ResourcesMaker.Self.FindingBreastTargets());

                e.IntroDoc
                     .ReviewedStatus(ReviewStatus.NotReviewed)
                     .ObservationSection($"Right Breast Finding")
                     ;
            });
    }
}
