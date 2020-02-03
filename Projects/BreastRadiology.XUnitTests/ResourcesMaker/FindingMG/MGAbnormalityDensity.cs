using FhirKhit.Tools;
using FhirKhit.Tools.R4;
using Hl7.Fhir.Model;
using System;
using System.Linq;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {

        CSTaskVar MGAbnormalityDensityTypeCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        "MGAbnormalityDensityTypeCS",
                        "Mammography Density Type CodeSystem",
                         "MG Density Type/CodeSystem",
                        "Mammography density abnormality refinement types code system.",
                         Group_MGCodesCS,
                        new ConceptDef[]
                         {
                        new ConceptDef()
                            .SetCode("FocalAsymmetrical", "Focal Asymmetrical")
                            .SetDefinition("[PR]")
                            ,
                        new ConceptDef()
                            .SetCode("Nodular", "Nodular")
                            .SetDefinition("[PR]")
                            ,
                        new ConceptDef()
                            .SetCode("Tubular", "Tubular")
                            .SetDefinition("[PR]")
                         }
                     )
                 );


        VSTaskVar MGAbnormalityDensityTypeVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                   "MGAbnormalityDensityTypeVS",
                   "Mammography Density Type ValueSet",
                    "MG Density Type/ValueSet",
                   "Mammography density abnormality refinement value set.",
                    Group_MGCodesVS,
                    Self.MGAbnormalityDensityTypeCS.Value()
                    )
            );


        SDTaskVar MGAbnormalityDensity = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                ValueSet binding = Self.MGAbnormalityDensityTypeVS.Value();

                SDefEditor e = Self.CreateEditor("MGAbnormalityDensity",
                        "Mammography Density",
                        "MG Density",
                        Global.ObservationUrl,
                        $"{Group_MGResources}/AbnormalityDensity",
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
                    .Description("Mammography Density Observation",
                        new Markdown()
                    )
                    ;

                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeMGAbnormalityDensity.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    .MammoDescription("686")
                    ;

                e.Select("value[x]").Zero();

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference( sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");
                e.SliceTargetReference( sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("densityType",
                    Self.MGComponentSliceCodeAbnormalityDensityType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "Density Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the density type.",
                                    $"The value of this component is a codeable concept chosen from the {Self.MGCalcificationTypeVS.Value().Name} valueset.")
                    );
            });
    }
}
