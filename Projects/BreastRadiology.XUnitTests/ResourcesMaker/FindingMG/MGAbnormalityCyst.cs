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
        CSTaskVar MGAbnormalityCystTypeCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        "MGAbnormalityCystTypeCS",
                        "Mammography Cyst Type CodeSystem",
                         "MG Cyst Type/CodeSystem",
                        "Mammography cyst abnormality type CodeSystem.",
                         Group_MGCodesCS,
                        new ConceptDef[]
                         {
                        new ConceptDef("Complex",
                            "Complex cyst",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Oil",
                            "Oil cyst",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Simple",
                            "Simple cyst",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Complicated",
                            "Complicated cyst",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("WithDebris",
                            "Cyst With Debris",
                            new Definition()
                                .Line("[PR]")
                            )
                         }
                     )
             );


        VSTaskVar MGAbnormalityCystVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                   "MGAbnormalityCystVS",
                   "Mammography CystAbnormalities ValueSet",
                    "MG Cyst/ValueSet",
                   "Mammography cyst abnormality types value set.",
                    Group_MGCodesVS,
                    Self.MGAbnormalityCystTypeCS.Value()
                    )
            );


        SDTaskVar MGAbnormalityCyst = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                ValueSet binding = Self.MGAbnormalityCystVS.Value();

                {
                    IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditorObservationLeaf("MGAbnormalityCyst",
                        "Mammography Cyst",
                        "MG Cyst",
                        $"{Group_MGResources}/AbnormalityCyst")
                    .Description("Breast Radiology Mammography Cyst Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                            .MissingObservation("a cyst")
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value().Url)
                    .AddFragRef(Self.ObservationNoValueFragment.Value().Url)
                    .AddFragRef(Self.ImagingStudyFragment.Value().Url)
                    .AddFragRef(Self.MGCommonTargetsFragment.Value().Url)
                    .AddFragRef(Self.MGShapeTargetsFragment.Value().Url)
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("value[x]").Zero();

                PreFhir.ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.MGAssociatedFeatures.Value(), 0, "1");
                Self.SliceTargetReference(e, sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("mgAbnormalityCystType",
                    Self.MGCodeAbnormalityCystType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "MG AbnormalityCyst Type");
                Self.ComponentSliceObservedCount(e);
            });
    }
}
