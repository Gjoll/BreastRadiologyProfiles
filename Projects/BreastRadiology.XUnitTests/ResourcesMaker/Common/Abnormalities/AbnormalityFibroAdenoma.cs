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
                            //+ FibroTypeCS
                            //+ Fibroadenoma
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Fibroadenoma")
                                .SetDisplay("Fibroadenoma")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroadenoma")
                                    .MammoId("70")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            ,
                            //- Fibroadenoma
                            //+ FibroadenomaDegeneration
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("FibroadenomaDegeneration")
                                .SetDisplay("Fibroadenoma degeneration")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Fibroadenoma degeneration")
                                    .MammoId("695")
                                )
                                .ValidModalities(Modalities.MG)
                            //- AutoGen
                            
                            //- FibroadenomaDegeneration
                            //- FibroTypeCS
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
                    .AddFragRef(Self.ShapeComponentsFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
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
                e.Select("code").Pattern(Self.ObservationCodeAbnormalityFibroadenoma.ToCodeableConcept());

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference( sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("fibroAdenomaType",
                    Self.ComponentSliceCodeAbnormalityFibroAdenomaType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "FibroAdenoma Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the fibroadenema type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
            });
    }
}
