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
        StringTaskVar SectionFindings = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateEditorObservationSection("SectionFindings",
                        "Findings",
                        "Findings",
                        $"{Group_BaseResources}/Findings")
                    .Description("Findings Section",
                        new Markdown()
                        .Paragraph("This resource is the head of the tree of observations made during a breast radiology exam.")
                        .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                    //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationSectionFragment.Value())
                    ;

                s = e.SDef.Url;
                //$e.IntroDoc
                // .ObservationSection($"Finding")
                // .ReviewedStatus(ReviewStatus.NotReviewed)
                // ;

                e.Select("value[x]").Zero();
                e.Select("bodySite").Zero();

                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(Self.SectionFindingsLeftBreast.Value(), 1, "1"),
                    new ProfileTargetSlice(Self.SectionFindingsRightBreast.Value(), 1, "1")
                };
                e.SliceByUrl("hasMember", targets);
                e.AddProfileTargets(targets);

                e.StartComponentSliceing();
                Self.ComponentSliceBiRads(e);
            });
    }
}
