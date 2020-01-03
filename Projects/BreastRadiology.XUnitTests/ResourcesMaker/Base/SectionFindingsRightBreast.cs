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
                SDefEditor e = Self.CreateEditorObservationSection("SectionFindingsRightBreast",
                        "Findings Right Breast",
                        "Right Breast",
                        $"{Group_BaseResources}/Findings/RightBreast")
                    .Description("Findings Right Breast Section",
                        new Markdown()
                        .Paragraph("This resource is the head of the tree of observations made of the right breast during a breast radiology exam.")
                        .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                        //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationSectionFragment.Value())
                    ;
                s = e.SDef.Url;

                //$e.IntroDoc
                //     .ObservationSection($"Right Breast Finding")
                //     .ReviewedStatus(ReviewStatus.NotReviewed)
                //     ;

                e.Select("value[x]").Zero();
                e.Select("bodySite").Zero();

                Self.AddFindingBreastTargets(e);
            });
    }
}
