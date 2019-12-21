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
        async StringTask MGAsymmetries()
        {
            if (this.mgAsymmetries == null)
                await this.CreateMGAsymmetries();
            return this.mgAsymmetries;
        }
        String mgAsymmetries = null;

        async VTask CreateMGAsymmetries()
        {
            CodeSystem cs = await this.CreateCodeSystem(
                   "BreastRadMemmoAsymmetries",
                   "Mammo Asymmetries",
                    "Mammo/Asymmetry/Values",
                   "Codes defining types of mammography asymmetries.",
                    Group_MGCodes,
                   new ConceptDef[]
                    {
                        new ConceptDef("Asymmetry",
                            "Asymmetry",
                            new Definition()
                            .CiteStart()
                                .Line("This is an area of fibroglandular-density tissue that is visible on only one mammographic projection.")
                                .Line("Most such findings represent summation artifact, a superimposition of normal breast structures,")
                                .Line("whereas those confirmed to be real lesions (by subsequent demonstration on at least one")
                                .Line("more projection) may represent one of the other types of asymmetry or a mass.")
                            .CiteEnd(BiRadCitation)
                            ),
                        new ConceptDef("GlobalAsymmetry",
                            "Global Asymmetry",
                            new Definition()
                            .CiteStart()
                                .Line("Global asymmetry is judged relative to the corresponding area in the contralateral breast and")
                                .Line("represents a large amount of fibroglandular-density tissue over a substantial portion of the")
                                .Line("breast (at least one quadrant). There is no mass, distorted architecture or associated suspicious")
                                .Line("calcifications. Global asymmetry usually represents a normal variant.")
                            .CiteEnd(BiRadCitation)
                            ),
                        new ConceptDef("FocalAsymmetry",
                            "Focal Asymmetry",
                            new Definition()
                            .CiteStart()
                                .Line("A focal asymmetry is judged relative to the corresponding location in the contralateral breast,")
                                .Line("and represents a relatively small amount of fibroglandular-density tissue over a confined portion")
                                .Line("of the breast (less than one quadrant). It is visible on and has similar shape on different mammographic")
                                .Line("projections (hence a real finding rather than superimposition of normal breast structures),")
                                .Line("but it lacks the convex-outward borders and the conspicuity of a mass. Rather, the borders")
                                .Line("of a focal asymmetry are concave-outward, and it usually is seen to be interspersed with fat.")
                                .Line("Note that occasionally what is properly described as a focal asymmetry at screening (a finding visible ")
                                .Line("on standard MLO and CC views) is determined at diagnostic mammography to be 2 different")
                                .Line("findings, each visible on only 1 standard view (hence, 2 asymmetries), each of which ultimately")
                                .Line("is judged to represent superimposition of normal breast structures. Also, not infrequently, what")
                                .Line("is properly described as a focal asymmetry at screening is determined at diagnostic evaluation")
                                .Line("(mammography and/or ultrasound) to represent a mass.")
                            .CiteEnd(BiRadCitation)
                            ),
                        new ConceptDef("DevelopingAsymmetry",
                            "Developing Asymmetry",
                            new Definition()
                            .CiteStart()
                                .Line("This is a focal asymmetry that is new, larger, or more conspicuous than on a previous examination.")
                                .Line("Approximately 15% of cases of developing asymmetry are found to be malignant (either")
                                .Line("invasive carcinoma, DCIS, or both), so these cases warrant further imaging evaluation and biopsy")
                                .Line("unless found to be characteristically benign (e.g., simple cyst at directed ultrasound). Absence")
                                .Line("of a sonographic correlate, especially for a small (< 1 cm) developing asymmetry, should not avert biopsy.")
                            .CiteEnd(BiRadCitation)
                            )
                    }
                );

            ValueSet binding = await this.CreateValueSet(
               "BreastRadMemmoAsymmetries",
               "Mammo Asymmetries",
                "Mammo/Asymmetry/Values",
               "Codes defining types of mammography asymmetries.",
                Group_MGCodes,
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

            SDefEditor e = this.CreateEditor("BreastRadMammoAsymmetries",
                    "Mammo Asymmetries",
                    "Mammo/Asymmetries",
                    ObservationUrl,
                    $"{Group_MGResources}/Asymmetry",
                    out this.mgAsymmetries)
                .Description("Breast Radiology Mammography Asymmetries Observation",
                    new Markdown()
                        .MissingObservation("an asymmetry")
                        .BiradHeader()
                        .BlockQuote("The several types of asymmetry involve a spectrum of mammographic findings that represent")
                        .BlockQuote("unilateral deposits of fibroglandular tissue not conforming to the definition of a radiodense mass.")
                        .BlockQuote("The asymmetry, unlike a mass, is visible on only 1 mammographic projection. The other 3 types of")
                        .BlockQuote("asymmetry, although visible on more than 1 projection, have concave-outward borders and usu-")
                        .BlockQuote("ally are seen to be interspersed with fat, whereas a radiodense mass displays completely or partially")
                        .BlockQuote("convex-outward borders and appears to be denser in the center than at the periphery.")
                        .BiradFooter()
                        .Todo(
                        )
                )
                .AddFragRef(await this.ObservationNoDeviceFragment())
                .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                .AddFragRef(await this.ObservationCodedValueFragment())
                .AddFragRef(await this.ObservationSectionFragment())
            ;

            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(await this.BiRadsAssessmentCategory(), 0, "1"),

                    new ProfileTargetSlice(await this.CommonObservedCount(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonObservedChanges(), 0, "*"),
                    new ProfileTargetSlice(await this.CommonObservedSize(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonOrientation(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonObservedState(), 0, "*"),

                    new ProfileTargetSlice(await this.MGAssociatedFeatures(), 0, "1", false)
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }

            e.Select("value[x]")
                .Type("CodeableConcept")
                .Binding(binding.Url, BindingStrength.Required)
                ;
            e.AddValueSetLink(binding);
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .CodedObservationLeafNode(e, "a mammography asymmetry", binding)
                ;
        }
    }
}
