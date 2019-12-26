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
        StringTaskVar SectionFindingsLeftBreast = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditorXX("BreastRadSectionFindingsLeftBreast",
                       "Findings Left Breast",
                       "Left Breast",
                       ObservationUrl,
                       $"{Group_BaseResources}/Findings/LeftBreast")
                   .Description("Findings Left Breast Section",
                       new Markdown()
                       .Paragraph("This resource is the head of the tree of observations made of the left breast during a breast radiology exam.")
                       .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                       .Todo(
                       )
                   )
                   .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                   .AddFragRef(ResourcesMaker.Self.ObservationSectionFragment.Value())
                   .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                   ;
                s = e.SDef.Url;
                e.Select("value[x]").Zero();
                e.Select("bodySite").Zero();
                e.Find("hasMember").SliceByUrl(ResourcesMaker.Self.FindingBreastTargets());
                e.AddProfileTargets(ResourcesMaker.Self.FindingBreastTargets());

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Abnormality Left Breast Finding")
                    ;
            });
    }
}
