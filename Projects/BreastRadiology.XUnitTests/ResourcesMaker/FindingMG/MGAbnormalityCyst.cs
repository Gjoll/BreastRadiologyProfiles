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
             () =>
                 Self.CreateCodeSystem(
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
            () =>
                Self.CreateValueSet(
                   "MGAbnormalityCystVS",
                   "Mammography CystAbnormalities ValueSet",
                    "MG Cyst/ValueSet",
                   "Mammography cyst abnormality types value set.",
                    Group_MGCodesVS,
                    Self.MGAbnormalityCystTypeCS.Value()
                    )
            );


        StringTaskVar MGAbnormalityCyst = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.MGAbnormalityCystVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("MGAbnormalityCyst",
                        "Mammography Cyst",
                        "MG Cyst",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityCyst")
                    .Description("Breast Radiology Mammography Cyst Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                            .MissingObservation("a cyst")
                    //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ImagingStudyFragment.Value())
                    .AddFragRef(Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(Self.MGShapeTargetsFragment.Value())
                    ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("a mammography asymmetry abnormality")
                    .Refinement(binding, "Cyst")
                    ;

                e.Select("value[x]").Zero();
                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("mgAbnormalityCystType",
                    Self.MGCodeAbnormalityCystType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "MG AbnormalityCyst Type");
                Self.ComponentSliceObservedCount(e);
                Self.ComponentSliceConsistentWith(e);

                e.AddValueSetLink(binding);
            });
    }
}
