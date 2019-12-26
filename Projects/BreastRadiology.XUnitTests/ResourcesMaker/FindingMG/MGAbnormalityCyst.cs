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
        String MGAbnormalityCyst()
        {
            if (this.mgAbnormalityCyst == null)
                this.CreateMGAbnormalityCyst();
            return this.mgAbnormalityCyst;
        }
        String mgAbnormalityCyst = null;

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
                ResourcesMaker.Self.CreateValueSetXX(
                   "BreastRadMammoAbnormalityCyst",
                   "Mammography CystAbnormalities",
                    "Mg Cyst/ValueSet",
                   "Codes defining types of mammography cyst abnormalities.",
                    Group_MGCodes,
                    ResourcesMaker.Self.BreastRadMammoAbnormalityCystRefinementCS.Value()
                    )
            );


        void CreateMGAbnormalityCyst()
        {
            ValueSet binding = this.BreastRadMammoAbnormalityCystVS.Value();

            {
                IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                valueSetIntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                ;
                String outputPath = valueSetIntroDoc.Save();
                this.fc?.Mark(outputPath);
            }

            SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityCyst",
                    "Mammography Cyst Abnormality",
                    "Mg Cyst Abnormality",
                    ObservationUrl,
                    $"{Group_MGResources}/AbnormalityCyst",
                    out this.mgAbnormalityCyst)
                .Description("Breast Radiology Mammography Cyst Abnormality Observation",
                    new Markdown()
                        .Paragraph("[PR]")
                        .MissingObservation("a cyst")
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationSectionFragment())
                .AddFragRef(this.ObservationNoValueFragment())
                .AddFragRef(this.ImagingStudyFragment())
                .AddFragRef(this.MGCommonTargetsFragment())
                .AddFragRef(this.MGShapeTargetsFragment())
                ;

            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(this.CommonObservedCount(), 0, "1"),
                    //new ProfileTargetSlice(this.MGAssociatedFeatures(), 0, "1", false),
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
        }
    }
}
