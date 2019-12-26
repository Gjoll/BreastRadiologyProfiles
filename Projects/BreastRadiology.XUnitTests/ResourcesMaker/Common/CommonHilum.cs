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
    partial class ResourcesMaker
    {
        String CommonHilum()
        {
            if (this.commonHilum == null)
                this.CreateCommonHilum();
            return this.commonHilum;
        }
        String commonHilum = null;

        CSTaskVar CommonHilumCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                         "CommonHilum",
                         "Hilum CodeSystem",
                         "Hilum/CodeSystem",
                         "Codes defining hilum values.",
                         Group_CommonCodes,
                         new ConceptDef[]
                         {
                        new ConceptDef("HilumFatty",
                            "Hilum Fatty",
                            new Definition()
                                .Line("Definition needed")
                            ),
                        new ConceptDef("Hilum Not Fatty",
                            "Hilum Not Fatty",
                            new Definition()
                                .Line("Definition needed")
                            )
                         })
                     );

        VSTaskVar CommonHilumVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSetXX(
                        "CommonHilum",
                        "Hilum ValueSet",
                        "Hilum/ValueSet",
                        "Codes defining hilum values.",
                        Group_CommonCodes,
                        ResourcesMaker.Self.CommonHilumCS.Value())
            );

        void CreateCommonHilum()
        {
            ValueSet binding = CommonHilumVS.Value();

            {
                IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                valueSetIntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ValueSet(binding);
                ;
                String outputPath = valueSetIntroDoc.Save();
                this.fc?.Mark(outputPath);
            }

            SDefEditor e = this.CreateEditor("CommonHilum",
                    "Hilum Shape",
                    "Hilum/Shape",
                    ObservationUrl,
                    $"{Group_CommonResources}/Hilum")
                .Description("Breast Radiology Hilum Observation",
                    new Markdown()
                        .MissingObservation("a hilum")
                        .Todo(
                            "Definition(s) needed"
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationCodedValueFragment())
                .AddFragRef(this.ObservationLeafFragment())
                ;

            this.commonHilum = e.SDef.Url;
            e.Select("value[x]")
                .Type("CodeableConcept")
                .Binding(binding.Url, BindingStrength.Required)
                ;
            e.AddValueSetLink(binding);
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .CodedObservationLeafNode("a hilum", binding)
                ;
        }
    }
}
