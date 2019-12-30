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
                SDefEditor e = Self.CreateEditor("SectionFindingsLeftBreast",
                       "Findings Left Breast",
                       "Left Breast",
                       ObservationUrl,
                       $"{Group_BaseResources}/Findings/LeftBreast")
                   .Description("Findings Left Breast Section",
                       new Markdown()
                       .Paragraph("This resource is the head of the tree of observations made of the left breast during a breast radiology exam.")
                       .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                       //.Todo
                   )
                   .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                   .AddFragRef(Self.ObservationSectionFragment.Value())
                   ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Left Breast Finding")
                    ;

                e.Select("value[x]").Zero();
                e.Select("bodySite").Zero();
                Self.AddFindingBreastTargets(e);
            });
    }
}
