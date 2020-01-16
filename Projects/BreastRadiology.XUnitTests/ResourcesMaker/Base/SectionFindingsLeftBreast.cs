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
        SDTaskVar SectionFindingsLeftBreast = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditorObservationSection("SectionFindingsLeftBreast",
                       "Findings Left Breast",
                       "Findings/Left Breast",
                       $"{Group_BaseResources}/Findings/LeftBreast")
                   .Description("Findings Left Breast Section",
                       new Markdown()
                       .Paragraph("This resource is the head of the tree of observations made of the left breast during a breast radiology exam.")
                       .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                   )
                   .AddFragRef(Self.FindingBreastFragment.Value())
                   ;
                s = e.SDef;

                e.Select("bodySite")
                    .Pattern(new Coding(Snomed, "80248007", "Left breast structure (body structure)"));

                e.IntroDoc
                     .ReviewedStatus(ReviewStatus.Alpha)
                    ;
            });
    }
}
