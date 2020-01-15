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
                            new ConceptDef("Normal",
                                "Normal",
                                new Definition()
                                    .Line("[PR]")
                                ),
                            new ConceptDef("Degenerated",
                                "Degenerated",
                                new Definition()
                                    .Line("[PR]")
                                )
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

                SDefEditor e = Self.CreateEditorObservationLeaf("AbnormalityFibroadenoma",
                        "Fibroadenoma",
                        "Fibroadenoma",
                        $"{Group_CommonResources}/AbnormalityFibroadenoma")
                    .Description("Fibroadenoma Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                            .MissingObservation("a fibroadenoma abnormality")
                            .ValidModalities(Modalities.MG | Modalities.US)
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ImagingStudyFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ShapeComponentsFragment.Value())
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("value[x]").Zero();
                PreFhir.ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("fibroAdenomaType",
                    Self.CodeAbnormalityFibroAdenomaType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "AbnormalityFibroAdenoma Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the fibroadenema type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
                Self.ComponentSliceObservedCountRange(e);
            });
    }
}
