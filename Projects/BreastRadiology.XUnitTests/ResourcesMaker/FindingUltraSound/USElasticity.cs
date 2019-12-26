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
        CSTaskVar USElasticityCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                     "BreastRadUSElasticity",
                     "US Echo Pattern",
                     "US Elasticity/CodeSystem",
                     "Ultra-sound Elasticity code system.",
                     Group_USCodes,
                     new ConceptDef[]
                     {
                    new ConceptDef("Soft",
                        "Soft",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("Medium",
                        "Medium",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("Hard",
                        "Hard",
                        new Definition()
                            .Line("[PR]")
                        )
                     })
                 );


        VSTaskVar USElasticityVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                    "BreastRadUSElasticity",
                    "US Elasticity",
                    "US Elasticity/ValueSet",
                    "Ultra-sound Elasticity code system.",
                    Group_USCodes,
                    ResourcesMaker.Self.USElasticityCS.Value())
            );

        StringTaskVar USElasticity = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.USElasticityVS.Value();
                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    ResourcesMaker.Self.fc?.Mark(outputPath);
                }

                SDefEditor e = ResourcesMaker.Self.CreateEditorXX("BreastRadUSElasticity",
                        "US Elasticity",
                        "US Elasticity",
                        ObservationUrl,
                        $"{Group_USResources}/Elasticity")
                    .Description("Breast Radiology Ultra-Sound Elasticity Observation",
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
