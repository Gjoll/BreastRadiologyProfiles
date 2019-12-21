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
        async StringTask CommonMassShape()
        {
            if (this.commonMassShape == null)
                await this.CreateCommonMassShape();
            return this.commonMassShape;
        }
        String commonMassShape = null;

        async VTask CreateCommonMassShape()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs  = await this.CreateCodeSystem(
                        "CommonMassShape",
                        "Mass Shape",
                        "Mass/Shape/Values",
                        "Codes defining mass shape values.",
                        Group_CommonCodes,
                        new ConceptDef[]
                        {
                        new ConceptDef("Oval",
                            "Elliptical/Egg-shaped Mass",
                            new Definition()
                            .CiteStart()
                                .Line("A mass that is elliptical or egg-shaped (may include 2 or 3 undulations, , i.e., \"gently lobulated\" or \"macrolobulated\").")
                            .CiteEnd(BiRadCitation)
                            ),
                        new ConceptDef("Round",
                            "Round Mass",
                            new Definition()
                            .CiteStart()
                                .Line("A mass that is spherical, ball-shaped, circular, or globular in shape.")
                                .Line("A round mass has an anteroposterior diameter equal to its transverse diameter")
                                .Line("and to qualify as a ROUND mass, it must be circular in perpendicular projections.")
                                .Line("Breast masses with a ROUND shape are not commonly seen with breast ultrasound.")
                            .CiteEnd(BiRadCitation)
                            ),
                        new ConceptDef("Irregular",
                            "Irregular Mass",
                            new Definition()
                            .CiteStart()
                                .Line("The shape of the mass is neither round nor oval.")
                                .Line("For mammography, use of this descriptor usually implies a suspicious finding.")
                            .CiteEnd(BiRadCitation)
                            )
                        })
                    ;

                    ValueSet binding = await this.CreateValueSet(
                        "CommonMassShape",
                        "Mass Shape",
                        "Mass/Shape/Values",
                        "Codes defining mass shape values.",
                        Group_CommonCodes,
                        cs);

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .ValueSet(binding);
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    this.fc.Mark(outputPath);
                }

                SDefEditor e = this.CreateEditor("CommonMassShape",
                        "Mass Shape",
                        "Mass/Shape",
                        ObservationUrl,
                        $"{Group_CommonResources}/MassShape",
                        out this.commonMassShape)
                    .Description("Breast Radiology Mass Shape Observation",
                        new Markdown()
                            .MissingObservation("a mass shape")
                            .Todo(
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
                    .CodedObservationLeafNode(e, "a mass shape", binding)
                    ;
            });
        }
    }
}
