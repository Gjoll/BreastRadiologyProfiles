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
        CSTaskVar CSMassType = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                         "MassTypeCS",
                         "Mass Type CodeSystem",
                         "Mass/Type/CodeSystem",
                         "Codes defining mass refinements.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                            //+ Type
                            //+ Mass
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("Mass")
                                .SetDisplay("Mass")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mass")
                                    .MammoId("58")
                                )
                                .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.US)
                            //- AutoGen
                            ,
                            //- Mass
                            //+ MassIntraductal
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MassIntraductal")
                                .SetDisplay("Mass intraductal")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mass intraductal")
                                    .MammoId("621")
                                )
                                .ValidModalities(Modalities.US)
                            //- AutoGen
                            ,
                            //- MassIntraductal
                            //+ MassPartiallySolid
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MassPartiallySolid")
                                .SetDisplay("Mass partially solid")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mass partially solid")
                                    .MammoId("697")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            ,
                            //- MassPartiallySolid
                            //+ MassSkinATLASIsSkinLesion
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MassSkinATLASIsSkinLesion")
                                .SetDisplay("Mass skin ATLAS is skin lesion")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mass skin ATLAS is skin lesion")
                                    .MammoId("613")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            ,
                            //- MassSkinATLASIsSkinLesion
                            //+ MassSolid
                            //+ AutoGen
                            new ConceptDef()
                                .SetCode("MassSolid")
                                .SetDisplay("Mass solid")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Mass solid")
                                    .MammoId("608")
                                )
                                .ValidModalities(Modalities.MG | Modalities.US)
                            //- AutoGen
                            
                            //- MassSolid
                            //- Type
                         })
             );


        VSTaskVar MassTypeValueSetVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "MassTypeValueSetVS",
                        "Mass Type ValueSet",
                        "Mass Type/ValueSet",
                        "Mass type value set.",
                        Group_CommonCodesVS,
                        Self.CSMassType.Value()
                    )
            );

        SDTaskVar AbnormalityMass = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.MassTypeValueSetVS.Value();

                SDefEditor e = Self.CreateEditor("AbnormalityMass",
                        "Mass",
                        "Mass",
                        Global.ObservationUrl,
                        $"{Group_CommonResources}/MassAbnormality",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.TumorSatelliteFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ShapeComponentsFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
                    .Description("Mass Observation",
                        new Markdown()
                    )
                    ;

                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeAbnormalityMass.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    .ACRDescription(
                            "\"MASS\" is three dimensional and occupies space. It is seen on two different mammographic ", 
                            "projections. It has completely or partially convex-outward borders and (when radiodense) appears",
                            "denser in the center than at the periphery. If a potential mass is seen only on a single projection, it",
                            "should be called an \"ASYMMETRY\" until its 3-dimensionality is confirmed"
                    )
                    ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference( sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");
                e.SliceTargetReference( sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("massType",
                    Self.ComponentSliceCodeAbnormalityMassType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "Mass Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the mass type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
            });
    }
}
