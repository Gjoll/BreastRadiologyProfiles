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
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        async StringTask CommonHilum()
        {
            if (this.commonHilum == null)
                await this.CreateCommonHilum();
            return this.commonHilum;
        }
        String commonHilum = null;

        CSTaskVar CommonHilumCS = new CSTaskVar(
             async () =>
                 await ResourcesMaker.Self.CreateCodeSystem(
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
            async () =>
                await ResourcesMaker.Self.CreateValueSetXX(
                        "CommonHilum",
                        "Hilum ValueSet",
                        "Hilum/ValueSet",
                        "Codes defining hilum values.",
                        Group_CommonCodes,
                        await ResourcesMaker.Self.CommonHilumCS.Value())
            );

        async VTask CreateCommonHilum()
        {
            await VTask.Run(async () =>
            {
                ValueSet binding = await CommonHilumVS.Value();

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
                        $"{Group_CommonResources}/Hilum",
                        out this.commonHilum)
                    .Description("Breast Radiology Hilum Observation",
                        new Markdown()
                            .MissingObservation("a hilum")
                            .Todo(
                                "Definition(s) needed"
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationCodedValueFragment())
                    .AddFragRef(await this.ObservationLeafFragment())
                    ;

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .CodedObservationLeafNode("a hilum", binding)
                    ;
            });
        }
    }
}
