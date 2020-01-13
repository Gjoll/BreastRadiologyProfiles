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
                        "AbnormalityDuctCS",
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
                   "AbnormalityDuctVS",
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
                SDefEditor e = Self.CreateEditorObservationLeaf("AbnormalityDuct",
                        "Duct",
                        "Duct",
                        $"{Group_CommonResources}/AbnormalityDuct")
                    .Description("Breat Radiology Duct Observation",
                        new Markdown()
                            .MissingObservation("a duct abnormality")
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value().Url)
                    .AddFragRef(Self.CommonComponentsFragment.Value().Url)
                    .AddFragRef(Self.ShapeComponentsFragment.Value().Url)
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value().Url)
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("value[x]").Zero();

                e.Select("value[x]").Zero();
                PreFhir.ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("ductType",
                    Self.CodeAbnormalityDuctType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "AbnormalityDuct Type");
                Self.ComponentSliceObservedCount(e);
            });
    }
}
