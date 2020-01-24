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
                        new ConceptDef("Normal",
                            "Normal",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Ectasia",
                            "Ectasia",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Dilated",
                            "Dilated",
                            new Definition()
                                .CiteStart()
                                .Line("This is a unilateral tubular or branching structure that likely represents a dilated or otherwise en-")
                                .Line("larged duct. It is a rare finding. Even if unassociated with other suspicious clinical or mammographic")
                                .Line("findings, it has been reported to be associated with noncalcified DCIS.")
                                .CiteEnd(BiRadCitation)
                            )
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
            (out StructureDefinition  s) =>
            {
                ValueSet binding = Self.AbnormalityDuctVS.Value();
                SDefEditor e = Self.CreateEditor("AbnormalityDuct",
                        "Duct",
                        "Duct",
                        ObservationUrl,
                        $"{Group_CommonResources}/AbnormalityDuct",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .Description("Duct Observation",
                        new Markdown()
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ShapeComponentsFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference( sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("ductType",
                    Self.CodeAbnormalityDuctType.ToCodeableConcept(),
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
