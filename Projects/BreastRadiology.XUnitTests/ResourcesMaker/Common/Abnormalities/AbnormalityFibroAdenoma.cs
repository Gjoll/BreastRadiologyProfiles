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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        CSTaskVar FibroadenomaCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                         "FibroadenomaCodeSystemCS",
                         "Fibroadenoma CodeSystem",
                         "Fibroadenoma/CodeSystem",
                         "Fibroadenoma values code system.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                            //+ Type
                            #region Codes
                            new ConceptDef()
                                .SetCode("Fibroadenoma")
                                .SetDisplay("Fibroadenoma")
                                .MammoId("70")
                                .ValidModalities(Modalities.MG | Modalities.US)
                                .SetUMLS("A fibroadenoma is a benign, or noncancerous, breast " +
                                    "tumor. ",
                                    "Unlike a breast cancer, which grows larger over time " +
                                    "and can spread to other organs, ",
                                    "a fibroadenoma remains in the breast tissue. ",
                                    "They're pretty small, too. ",
                                    "Most are only 1 or 2 centimeters in size. ",
                                    "www.webmd.com > breast-cancer > what-are-fibroadenomas")
                            ,
                            new ConceptDef()
                                .SetCode("FibroadenomaDegeneration")
                                .SetDisplay("Fibroadenoma degeneration")
                                .MammoId("695")
                                .ValidModalities(Modalities.MG)
                                .SetUMLS("These are non-cancerous breast lumps. ",
                                    "Fibroadenomas usually go away with age. ",
                                    "By the time a woman is menopausal, they will likely " +
                                    "experience a degeneration of ",
                                    "the Fibroadenomas.")
                            #endregion // Codes
                            //- Type
                         })
                     );

        VSTaskVar FibroadenomaVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "FibroadenomaVS",
                        "Fibroadenoma ValueSet",
                        "FibroadenomaValueSet",
                        "Fibroadenoma value set.",
                        Group_CommonCodesVS,
                        Self.FibroadenomaCS.Value()
                    )
            );

        SDTaskVar AbnormalityFibroadenoma = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.FibroadenomaVS.Value();

                SDefEditor e = Self.CreateEditor("AbnormalityFibroadenoma",
                        "Fibroadenoma",
                        "Fibroadenoma",
                        Global.ObservationUrl,
                        $"{Group_CommonResources}/AbnormalityFibroadenoma",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ObservationComponentShapeFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedCountFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedDistributionFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedSizeFragment.Value())
                    .AddFragRef(Self.ObservationComponentPreviouslyDemonstratedByFragment.Value())

                    .AddFragRef(Self.ObservationHasMemberAssociatedFeaturesFragment.Value())

                    .Description("Fibroadenoma Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                            .ValidModalities(Modalities.MG | Modalities.US)
                    )
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                // Set Observation.code to unique value for this profile.
                e.Select("code")
                    .Pattern(Self.ObservationCodeAbnormalityFibroadenoma.ToCodeableConcept().ToPattern())
                    .DefaultValueExtension(Self.ObservationCodeAbnormalityFibroadenoma.ToCodeableConcept())
                    ;

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("fibroAdenomaType",
                    Self.ComponentSliceCodeAbnormalityFibroAdenomaType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "FibroAdenoma Type",
                    "refines the fibroadenema type");
            });
    }
}
