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
        CSTaskVar BreastRadMammoAbnormalityCystRefinementCS = new CSTaskVar(
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                        "BreastRadMammoAbnormalityCystRefinement",
                        "Mammography Cyst Abnormality Refinement",
                         "Mg Cyst Refinement/CodeSystem",
                        "Codes defining types of mammography cyst abnormalities.",
                         Group_MGCodes,
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


        VSTaskVar BreastRadMammoAbnormalityCystVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                   "BreastRadMammoAbnormalityCyst",
                   "Mammography CystAbnormalities",
                    "Mg Cyst/ValueSet",
                   "Codes defining types of mammography cyst abnormalities.",
                    Group_MGCodes,
                    ResourcesMaker.Self.BreastRadMammoAbnormalityCystRefinementCS.Value()
                    )
            );


        StringTaskVar MGAbnormalityCyst = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.BreastRadMammoAbnormalityCystVS.Value();

                {
                    IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                    valueSetIntroDoc
                        .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    ResourcesMaker.Self.fc?.Mark(outputPath);
                }

                SDefEditor e = ResourcesMaker.Self.CreateEditorXX("BreastRadMammoAbnormalityCyst",
                        "Mammography Cyst Abnormality",
                        "Mg Cyst Abnormality",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityCyst")
                    .Description("Breast Radiology Mammography Cyst Abnormality Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                            .MissingObservation("a cyst")
                            .Todo(
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationSectionFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ImagingStudyFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.MGShapeTargetsFragment.Value())
                    ;
                s = e.SDef.Url;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedCount.Value(), 0, "1"),
                        //new ProfileTargetSlice(ResourcesMaker.Self.MGAssociatedFeatures.Value(), 0, "1", false),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddValueSetLink(binding);

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("a mammography asymmetry abnormality")
                    .Refinement(binding, "Cyst")
                    ;
            });
    }
}
