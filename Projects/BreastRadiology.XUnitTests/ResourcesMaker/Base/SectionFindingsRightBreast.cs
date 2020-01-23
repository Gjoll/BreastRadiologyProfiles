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
        SDTaskVar SectionFindingsRightBreast = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("SectionFindingsRightBreast",
                        "Findings Right Breast",
                        "Findings/Right Breast",
                        ObservationUrl,
                        $"{Group_BaseResources}/Findings/RightBreast",
                        "ObservationSection")
                    .Description("Findings Right Breast Section",
                        new Markdown()
                        .Paragraph("This resource is the head of the tree of observations made of the right breast during a breast radiology exam.")
                        .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                    )
                   .AddFragRef(Self.FindingBreastFragment.Value())
                    ;
                s = e.SDef;

                e.Select("bodySite")
                    .Pattern(new Coding(Snomed, "73056007", " Right breast structure (body structure) "));

                e.Select("value[x]")
                    .Definition(new Markdown()
                         .Paragraph("Composite BiRad value for Right Breast.")
                         .Paragraph("Typically this is the most severe of all the BiRad codes set in any of the child observations.")
                    )
                    ;
                e.IntroDoc
                     .ReviewedStatus("KWA-PEN", "1.1.2020")
                     .ReviewedStatus("CIC", "22.1.2020")
                     ;
            });
    }
}
