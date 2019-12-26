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
        CSTaskVar USBoundaryCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                     "USBoundary",
                     "UltraSound Boundary",
                     "US Boundary/CodeSystem",
                     "Ultra Sound Boundary code system.",
                     Group_USCodes,
                     new ConceptDef[]
                     {
                    new ConceptDef("WellDefined",
                        "Well defined boundary",
                        new Definition()
                            .Line("[PR]")
                    ),
                    new ConceptDef("Abrupt",
                        "Abrupt boundary",
                        new Definition()
                            .Line("[PR]")
                    ),
                    new ConceptDef("Echogenic",
                        "Echogenic boundary",
                        new Definition()
                            .Line("[PR]")
                    ),
                    new ConceptDef("Hyperechoic",
                        "Hyperechoic boundary",
                        new Definition()
                            .Line("[PR]")
                    )
                     }
                 )
             );


        VSTaskVar USBoundaryVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                    "USBoundary",
                    "UltraSound Boundary",
                    "US Boundary/ValueSet",
                    "UltraSound Boundary Codes.",
                    Group_USCodes,
                    ResourcesMaker.Self.USBoundaryCS.Value()
                    )
            );


        StringTaskVar USBoundary = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.USBoundaryVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    ResourcesMaker.Self.fc?.Mark(outputPath);
                }

                SDefEditor e = ResourcesMaker.Self.CreateEditorXX("BreastRadUSBoundary",
                    "Ultra Sound Boundary",
                    "US Boundary",
                    ObservationUrl,
                    $"{Group_USResources}/Boundary")
                    .Description("Breast Radiology Ultra-Sound Boundary Observation",
                        new Markdown()
                            .Paragraph("This resource describes an Ultra-Sound boundary observation.")
                            .Paragraph("[PR]")
                            .Todo(
                            )
                     )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationLeafFragment.Value())
                    ;

                s = e.SDef.Url;
                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode("an UltraSound boundary", binding)
                    ;
            });
    }
}
