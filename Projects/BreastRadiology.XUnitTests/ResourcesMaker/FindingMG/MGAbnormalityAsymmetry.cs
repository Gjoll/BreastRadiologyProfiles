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

        CSTaskVar MGAbnormalityAsymmetryRefinementCS = new CSTaskVar(
             () =>
                 Self.CreateCodeSystem(
                    "MGAbnormalityAsymmetryRefinementCS",
                    "Mammography Asymmetry Refinement CodeSystem",
                     "MG Asymmetry Refinement/CodeSystem",
                    "Mammography asymmetry abnormality type code system.",
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
                 )
             );


        VSTaskVar MGAbnormalityAsymmetriesVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                   "MGAbnormalityAsymmetriesVS",
                   "Mammography AsymmetryAbnormalities ValueSet",
                    "MG Asymmetry/ValueSet",
                   "Mammography asymmetry abnormality types value set.",
                    Group_MGCodes,
                    Self.MGAbnormalityAsymmetryRefinementCS.Value()
                    )
            );


        StringTaskVar MGAbnormalityAsymmetry = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.MGAbnormalityAsymmetriesVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                        .Refinement(binding, "Asymmetry")
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("MGAbnormalityAsymmetry",
                        "Mammography Asymmetry",
                        "MG Asymmetry",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityAsymmetry")
                    .Description("Breast Radiology Mammography Asymmetry Observation",
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
                            //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationCodedValueFragment.Value())
                    .AddFragRef(Self.MGCommonTargetsFragment.Value())
                ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("a mammography asymmetry abnormality")
                    .Refinement(binding, "Asymmetry")
                    ;

                if (Self.Component_HasMember)
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(Self.ObservedCount.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.MGAssociatedFeatures.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.ConsistentWith.Value(), 0, "*"),
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);
                }
                else
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(Self.MGAssociatedFeatures.Value(), 0, "1"),
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);

                    Self.ComponentSliceObservedCount(e);
                    Self.ComponentSliceConsistentWith(e);
                }

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);
            });
    }
}
