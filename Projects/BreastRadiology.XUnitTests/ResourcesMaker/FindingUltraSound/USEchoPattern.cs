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
        String USEchoPattern()
        {
            if (this.usEchoPattern == null)
                this.CreateUSEchoPattern();
            return this.usEchoPattern;
        }
        String usEchoPattern = null;

        CSTaskVar BreastRadUSEchoPatternCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                     "BreastRadUSEchoPattern",
                     "US Echo Pattern",
                     "US Echo Pattern/CodeSystem",
                     "Ultra-sound mass echo pattern code system.",
                     Group_USCodes,
                     new ConceptDef[]
                     {
                    new ConceptDef("Anechoic",
                        "Anechoic",
                        new Definition()
                        .CiteStart()
                            .Line("Without internal echoes.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("ComplexCysticAndSolid",
                        "Complex Cystic and Solid",
                        new Definition()
                        .CiteStart()
                            .Line("A complex mass contains both anechoic (cystic or fluid) and echogenic (solid) components.")
                            .Line("Not [PR]")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("FibrocysticTissue",
                        "Fibrocystic Tissue",
                        new Definition()
                            .Line("[PR]")
                        ),
                     new ConceptDef("Heterogeneous",
                        "Heterogeneous",
                        new Definition()
                        .CiteStart()
                            .Line("A mixture of echogenic patterns within a solid mass. Heterogeneity has little prognostic")
                            .Line("value in differentiating benign from malignant masses, but it is not uncommon to observe")
                            .Line("heterogeneity in fibroadenomas as well as cancers. Clumped areas of different echogenicity")
                            .Line("may elevate the suspicion for malignancy, particularly in a mass whose margins are not")
                            .Line("circumscribed and whose shape is irregular.")
                        .CiteEnd(BiRadCitation)
                        ),
                     new ConceptDef("Homogeneous",
                        "Homogeneous",
                        new Definition()
                            .Line("[PR]")
                        ),
                   new ConceptDef("Hyperechoic",
                        "Hyperechoic",
                        new Definition()
                        .CiteStart()
                            .Line("Hyperechogenicity is defined as having increased echogenicity relative to fat or equal to fibroglandular tissue.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Hypoechoic",
                        "Hypoechoic",
                        new Definition()
                        .CiteStart()
                            .Line("The term “hypoechoic” is defined relative to subcutaneous fat; hypoechoic masses, less")
                            .Line("echogenic than fat, are characterized by low-level echoes throughout (for example,")
                            .Line("complicated cysts and fibroadenomas)")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Isoechoic",
                        "Isoechoic",
                        new Definition()
                        .CiteStart()
                            .Line("Isoechogenicity is defined as having the same echogenicity as subcutaneous fat. Isoechoic")
                            .Line("masses may be relatively inconspicuous, particularly when they are situated within an area of")
                            .Line("fat lobules. This may limit the sensitivity of US, especially at screening, in which the presence")
                            .Line("and location of such a mass is not known at the time of examination.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("MixedEchogenic",
                        "Mixed Echogenic",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("Septated",
                        "Mixed Echogenic",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("Sonolucent",
                        "Sonolucent",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("WithInternalEchos",
                        "With Internal Echos",
                        new Definition()
                            .Line("[PR]")
                        )
                     })
                 );


        VSTaskVar BreastRadUSEchoPatternVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                    "BreastRadUSEchoPattern",
                    "US Echo Pattern",
                    "US Echo Pattern/ValueSet",
                    "Ultra-sound mass echo pattern code system.",
                    Group_USCodes,
                    ResourcesMaker.Self.BreastRadUSEchoPatternCS.Value())
            );


        void CreateUSEchoPattern()
        {
            ValueSet binding = this.BreastRadUSEchoPatternVS.Value();

            {
                IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                valueSetIntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ValueSet(binding);
                ;
                String outputPath = valueSetIntroDoc.Save();
                this.fc?.Mark(outputPath);
            }

            SDefEditor e = this.CreateEditor("BreastRadUSEchoPattern",
                    "US Echo Pattern",
                    "US Echo Pattern",
                    ObservationUrl,
                    $"{Group_USResources}/EchoPattern")
                .Description("Breast Radiology Ultra-Sound Echo Pattern Observation",
                    new Markdown()
                        .BiradHeader()
                        .BlockQuote("The echogenicity of most benign and malignant masses is hypoechoic compared with ")
                        .BlockQuote("mammary fat. While many completely echogenic masses are benign, prospective assessment as")
                        .BlockQuote("benign has greater dependency on marginal circumscription. Although the echo pattern")
                        .BlockQuote("contributes with other feature categories to the assessment of a breast lesion, echogenicity")
                        .BlockQuote("alone has little specificity.")
                        .BiradFooter()
                        .Todo(
                        )
                    )
                .AddFragRef(this.ObservationNoDeviceFragment.Value())
                .AddFragRef(this.ObservationCodedValueFragment.Value())
                .AddFragRef(this.ObservationLeafFragment.Value())
                ;
            this.usEchoPattern = e.SDef.Url;

            e.Select("value[x]")
                .Type("CodeableConcept")
                .Binding(binding.Url, BindingStrength.Required)
                ;
            e.AddValueSetLink(binding);
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .CodedObservationLeafNode("an ultra-sound mass echo pattern", binding)
                ;
        }
    }
}
