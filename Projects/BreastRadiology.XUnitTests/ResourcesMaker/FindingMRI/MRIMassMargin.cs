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
    partial class ResourcesMaker : ConverterBase
    {
        async StringTask MRIMassMargin()
        {
            if (this.mriMassMargin == null)
                await this.CreateMRIMassMargin();
            return this.mriMassMargin;
        }
        String mriMassMargin = null;

        async VTask CreateMRIMassMargin()
        {
            await VTask.Run(async () =>
            {
                CodeSystem cs = await this.CreateCodeSystem(
                    "BreastRadMRIMassMargin",
                    "MRI Mass Margin",
                    "MRI/Mass/Margin/Values",
                    "MRI mass margin codes.",
                    Group_MRICodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("Irregular",
                        "Irregular Margin",
                        new Definition()
                            .Line("Penrad specific.")
                        ),
                    new ConceptDef("Macrolobulated",
                        "Microlobulated Margin",
                        new Definition()
                            .Line("Penrad specific.")
                        ),
                    new ConceptDef("Obscured",
                        "Obscured Margin",
                        new Definition()
                        .CiteStart()
                            .Line("A margin that is hidden by superimposed or adjacent fibroglandular tissue. This is used")
                            .Line("primarily when some of the margin of the mass is circumscribed, but the rest (more than 25%) is hidden.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Smooth",
                        "Smooth Margin",
                        new Definition()
                            .Line("Penrad specific.")
                        ),
                    new ConceptDef("Spiculated",
                        "Spiculated Margin",
                        new Definition()
                        .CiteStart()
                            .Line("The margin is characterized by lines radiating from the mass. Use of this descriptor usually")
                            .Line("implies a suspicious finding.")
                        .CiteEnd(BiRadCitation)
                        )
                    });
                ValueSet binding = await this.CreateValueSet(
                    "BreastRadMRIMassMargin",
                    "MRI Mass Margin",
                    "MRI/Mass/Margin/Values",
                    "MRI mass margin codes.",
                    Group_MRICodes,
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

                SDefEditor e = this.CreateEditor("BreastRadMRIMassMargin",
                    "MRI Mass Margin",
                    "MRI/Mass/Margin",
                    ObservationUrl,
                    $"{Group_MRIResources}/Mass/Margin",
                    out this.mriMassMargin)
                    .Description("Breast Radiology MRI Mass Margin Observation",
                        new Markdown()
                            .MissingObservation("a mass margin")
                            .BiradHeader()
                            .BlockQuote("The margin is the edge or border of the lesion. The descriptors of margin, like the descriptors of shape, are important predictors of whether a mass is benign or malignant. ")
                            .BiradFooter()
                            .Todo(
                                "Is Irregular incorrect? Note from ACR B.3.A. 'Irregular' is not used to group these marginal attributes because irregular describes the shape of a mass.",
                                "Is non-circumscribed a stand along value, or implied by selection fo on or more non-circumscribed values? "
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
                    .CodedObservationLeafNode(e, "a MRI mass margin", binding)
                    ;
            });
        }
    }
}
