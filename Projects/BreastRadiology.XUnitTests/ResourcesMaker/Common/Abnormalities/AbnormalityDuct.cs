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
        CSTaskVar AbnormalityDuctCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        "AbnormalityDuctTypeCS",
                        "Duct Type CodeSystem",
                         "Duct Type/CodeSystem",
                        "Duct abnormality types code system.",
                         Group_CommonCodesCS,
                        new ConceptDef[]
                         {
                            //+ DuctTypeCS
                            //+ DuctDilatedATLASSolitaryDilatedDuct
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DuctDilatedATLASSolitaryDilatedDuct")
                                .SetDisplay("Duct dilated ATLAS solitary dilated duct")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Duct dilated ATLAS solitary dilated duct")
                                    .MammoId("694.602")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            ,
                            //- DuctDilatedATLASSolitaryDilatedDuct
                            //+ DuctEctasia
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("DuctEctasia")
                                .SetDisplay("Duct ectasia")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Duct ectasia")
                                    .MammoId("693.614")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            
                            //- DuctEctasia
                            //- DuctTypeCS
                         }
                     )
                 );


        VSTaskVar AbnormalityDuctVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                   "AbnormalityDuctTypeVS",
                   "Duct ValueSet",
                    "Duct/ValueSet",
                   "Duct node abnormality types value set.",
                    Group_CommonCodesVS,
                    Self.AbnormalityDuctCS.Value()
                    )
            );


        SDTaskVar AbnormalityDuct = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.AbnormalityDuctVS.Value();
                SDefEditor e = Self.CreateEditor("AbnormalityDuct",
                        "Duct",
                        "Duct",
                        Global.ObservationUrl,
                        $"{Group_CommonResources}/AbnormalityDuct",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ShapeComponentsFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
                    .Description("Duct Observation",
                        new Markdown()
                    )
                    ;

                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeAbnormalityDuct.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference(sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("ductType",
                    Self.ComponentSliceCodeAbnormalityDuctType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "Duct Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the duct type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
            });
    }
}
