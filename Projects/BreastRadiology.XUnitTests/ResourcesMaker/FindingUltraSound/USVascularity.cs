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
        String USVascularity()
        {
            if (this.usVascularity == null)
                this.CreateUSVascularity();
            return this.usVascularity;
        }
        String usVascularity = null;

        CSTaskVar BreastRadUSVascularityCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                     "BreastRadUSVascularity",
                     "US Echo Pattern",
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



        VSTaskVar BreastRadUSVascularityVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSetXX(
                    "BreastRadUSVascularity",
                    "US Vascularity",
                    "US Vascularity/ValueSet",
                    "Ultra-sound Vascularity code system.",
                    Group_USCodes,
                    ResourcesMaker.Self.BreastRadUSVascularityCS.Value()
                    )
            );



        void CreateUSVascularity()
        {
            ValueSet binding = this.BreastRadUSVascularityVS.Value();

            {
                IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                valueSetIntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ValueSet(binding);
                ;
                String outputPath = valueSetIntroDoc.Save();
                this.fc?.Mark(outputPath);
            }

            SDefEditor e = this.CreateEditor("BreastRadUSVascularity",
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
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationCodedValueFragment())
                .AddFragRef(this.ObservationLeafFragment())
                ;

            this.usVascularity = e.SDef.Url;
            e.Select("value[x]")
                .Type("CodeableConcept")
                .Binding(binding.Url, BindingStrength.Required)
                ;
            e.AddValueSetLink(binding);
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .CodedObservationLeafNode("an ultra-sound vascularity", binding)
                ;
        }
    }
}
