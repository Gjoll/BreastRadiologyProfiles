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

        CSTaskVar MGAbnormalityAsymmetryTypeCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                    "MGAbnormalityAsymmetryTypeCS",
                    "Mammography Asymmetry Type CodeSystem",
                     "MG Asymmetry Type/CodeSystem",
                    "Mammography asymmetry abnormality type code system.",
                     Group_MGCodesCS,
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
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                   "MGAbnormalityAsymmetriesVS",
                   "Mammography AsymmetryAbnormalities ValueSet",
                    "MG Asymmetry/ValueSet",
                   "Mammography asymmetry abnormality types value set.",
                    Group_MGCodesVS,
                    Self.MGAbnormalityAsymmetryTypeCS.Value()
                    )
            );


        SDTaskVar MGAbnormalityAsymmetry = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                ValueSet binding = Self.MGAbnormalityAsymmetriesVS.Value();
                {
                    IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("MGAbnormalityAsymmetry",
                        "Mammography Asymmetry",
                        "MG Asymmetry",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityAsymmetry",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .Description("Asymmetry Observation",
                        new Markdown()
                            .BiradHeader()
                            .BlockQuote("The several types of asymmetry involve a spectrum of mammographic findings that represent")
                            .BlockQuote("unilateral deposits of fibroglandular tissue not conforming to the definition of a radiodense mass.")
                            .BlockQuote("The asymmetry, unlike a mass, is visible on only 1 mammographic projection. The other 3 types of")
                            .BlockQuote("asymmetry, although visible on more than 1 projection, have concave-outward borders and usu-")
                            .BlockQuote("ally are seen to be interspersed with fat, whereas a radiodense mass displays completely or partially")
                            .BlockQuote("convex-outward borders and appears to be denser in the center than at the periphery.")
                            .BiradFooter()
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ShapeComponentsFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
                ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                PreFhir.ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");
                Self.SliceTargetReference(e, sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("asymmetryType",
                    Self.MGCodeAbnormalityAsymmetryType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "Asymmetry Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the asymmetry type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
            });
    }
}
