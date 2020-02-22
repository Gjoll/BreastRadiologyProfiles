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
        SDTaskVar FindingsLeftBreast = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateEditor("SectionFindingsLeftBreast",
                       "Findings Left Breast",
                       "Findings/Left Breast",
                        Global.ObservationUrl,
                       $"{Group_BaseResources}/Findings/LeftBreast",
                        "ObservationSection")
                   .Description("Findings Left Breast Section",
                       new Markdown()
                       .Paragraph("This resource is the head of the tree of observations made of the left breast during a breast radiology exam.")
                       .Paragraph("Child observations are referenced by the 'Observation.hasMember' field.")
                   )
                   .AddFragRef(Self.FindingBreastFragment.Value())
                   ;
                s = e.SDef;
                {
                    CodeableConcept coding = new Coding(Global.Snomed, "80248007", "Left breast structure (body structure)").ToCodeableConcept();
                    e.Select("bodySite")
                        .Pattern(coding.ToPattern())
                        .DefaultValueExtension(coding);
                }
                e.Select("value[x]")
                    .Definition(new Markdown()
                         .Paragraph("Composite BiRad value for Left Breast.")
                         .Paragraph("Typically this is the most severe of all the BiRad codes set in any of the child observations.")
                    )
                    ;

                // Set Observation.code to unique value for this profile.
                e.Select("code")
                    .Pattern(Self.ObservationCodeFindingsLeftBreast.ToCodeableConcept().ToPattern())
                    .DefaultValueExtension(Self.ObservationCodeFindingsLeftBreast.ToCodeableConcept())
                    ;

                e.IntroDoc
                     .ReviewedStatus("KWA-PEN", "1.1.2020")
                     .ReviewedStatus("CIC", "22.1.2020")
                    ;
            });
    }
}
