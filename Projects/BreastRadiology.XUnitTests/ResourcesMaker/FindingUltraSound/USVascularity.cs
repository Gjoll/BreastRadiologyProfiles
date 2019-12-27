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
using PreFhir;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {

        CSTaskVar USVascularityCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                     "USVascularityCS",
                     "US Echo Pattern CodeSystem",
                     "US Vascularity/CodeSystem",
                     "Ultra-sound Vascularity code system.",
                     Group_USCodes,
                     new ConceptDef[]
                     {
                    new ConceptDef("Adjacent",
                        "Adjacent",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("IncreaseSurround",
                        "Increase Surround",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("Increased",
                        "Increased",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("NoIncrease",
                        "No increase",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("NotPresent",
                        "Not present",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("Present",
                        "Present",
                        new Definition()
                            .Line("[PR]")
                        )
                     })
                 );



        VSTaskVar USVascularityVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                    "USVascularityVS",
                    "US Vascularity ValueSet",
                    "US Vascularity/ValueSet",
                    "Ultra-sound Vascularity codes value set.",
                    Group_USCodes,
                    ResourcesMaker.Self.USVascularityCS.Value()
                    )
            );



        StringTaskVar USVascularity = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.USVascularityVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    ResourcesMaker.Self.fc?.Mark(outputPath);
                }

                SDefEditor e = ResourcesMaker.Self.CreateEditor("USVascularity",
                        "US Vascularity",
                        "US Vascularity",
                        ObservationUrl,
                        $"{Group_USResources}/Vascularity")
                    .Description("Breast Radiology Ultra-Sound Vascularity Observation",
                        new Markdown()
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
                    .CodedObservationLeafNode("an ultra-sound vascularity", binding)
                    ;
            });
    }
}
