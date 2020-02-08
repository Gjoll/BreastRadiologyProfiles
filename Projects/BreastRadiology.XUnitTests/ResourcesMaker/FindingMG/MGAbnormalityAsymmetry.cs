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
                         //+ Type
                         new ConceptDef()
                             .SetCode("Asymmetry")
                             .SetDisplay("Asymmetry")
                             .MammoId("691")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("Breast asymmetry refers to when one breast is a different " +
                                 "size or shape than the other. ",
                                 "Uneven or different sized breasts or nipples are " +
                                 "not usually a cause for concern.")
                         ,
                         new ConceptDef()
                             .SetCode("AsymmetryFocal")
                             .SetDisplay("Asymmetry focal")
                             .MammoId("643")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("Focal asymmetry is visible as a confined asymmetry " +
                                 "with a similar shape on two views but does not fit " +
                                 "the criteria of a mass: that is, it lacks convex " +
                                 "outer borders and conspicuity (,Fig 4,,). ",
                                 "In contrast to global asymmetry, it occupies a volume " +
                                 "of less than one quadrant of the breast and is of " +
                                 "more concern. ",
                                 "The frequency of finding focal asymmetry at screening " +
                                 "mammography is less than 1%. ",
                                 "###URL#https://pubs.rsna.org/doi/10.1148/rg.e33")
                         ,
                         new ConceptDef()
                             .SetCode("AsymmetryGlobal")
                             .SetDisplay("Asymmetry global")
                             .MammoId("644")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("Global asymmetry in breast tissue is a form of breast " +
                                 "asymmetry where at least one quadrant of a breast " +
                                 "has a larger amount of fibroglandular density than " +
                                 "the corresponding area in the contralateral breast. ",
                                 "There is no mass, suspicious calcification, or architectural " +
                                 "distortion. ",
                                 "###URL#https://radiopaedia.org/articles/global-asymmetry-in-breast-tissue?lang=us")
                         ,
                         new ConceptDef()
                             .SetCode("DevelopingAsymmetry")
                             .SetDisplay("Developing Asymmetry")
                             .MammoId("Row542")
                             .ValidModalities(Modalities.MG)
                             .SetUMLS("A developing asymmetry is a focal asymmetry that " +
                                 "is new or increased in conspicuity compared with " +
                                 "the previous mammogram. ",
                                 "It is challenging to evaluate, as it often looks " +
                                 "similar to fibroglandular tissue at mammography. ",
                                 "A developing asymmetry should be viewed with suspicion " +
                                 "because it is an uncommon manifestation of breast " +
                                 "cancer. ",
                                 "###URL#https://pubs.rsna.org/doi/full/10.1148/rg.2016150123")
                         //- Type
                         }
                 )
             );


        VSTaskVar MGAbnormalityAsymmetriesVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                   "MGAbnormalityAsymmetriesTypeVS",
                   "Mammography AsymmetryAbnormalities ValueSet",
                    "MG Asymmetry/ValueSet",
                   "Mammography asymmetry abnormality types value set.",
                    Group_MGCodesVS,
                    Self.MGAbnormalityAsymmetryTypeCS.Value()
                    )
            );


        SDTaskVar MGAbnormalityAsymmetry = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.MGAbnormalityAsymmetriesVS.Value();
                {
                    IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                    valueSetIntroDoc
                        .ReviewedStatus("NOONE", "")
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("MGAbnormalityAsymmetry",
                        "Mammography Asymmetry",
                        "MG Asymmetry",
                        Global.ObservationUrl,
                        $"{Group_MGResources}/AbnormalityAsymmetry",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ShapeComponentsFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
                    .Description("Asymmetry Observation",
                        new Markdown()
                    )
                ;
                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeMGAbnormalityAsymmetry.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    .ACRDescription(
                            "The several types of asymmetry involve a spectrum of mammographic findings that represent",
                            "unilateral deposits of fibroglandular tissue not conforming to the definition of a radiodense mass.",
                            "The asymmetry, unlike a mass, is visible on only 1 mammographic projection. The other 3 types of ",
                            "asymmetry, although visible on more than 1 projection, have concave-outward borders and ",
                            "usually are seen to be interspersed with fat, whereas a radiodense mass displays completely or partially",
                            "convex-outward borders and appears to be denser in the center than at the periphery."
                    )
                    ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference(sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");
                e.SliceTargetReference(sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("asymmetryType",
                    Self.MGComponentSliceCodeAbnormalityAsymmetryType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "Asymmetry Type",
                    "refines the asymmetry type");
            });
    }
}
