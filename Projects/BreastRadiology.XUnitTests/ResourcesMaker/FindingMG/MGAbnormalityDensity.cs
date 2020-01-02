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
             () =>
                 Self.CreateCodeSystem(
                        "MGAbnormalityDensityTypeCS",
                        "Mammography Density Type CodeSystem",
                         "MG Density Type/CodeSystem",
                        "Mammography density abnormality refinement types code system.",
                         Group_MGCodesCS,
                        new ConceptDef[]
                         {
                        new ConceptDef("FocalAsymmetrical",
                            "Focal Asymmetrical",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Nodular",
                            "Nodular",
                            new Definition()
                                .Line("[PR]")
                            ),
                        new ConceptDef("Tubular",
                            "Tubular",
                            new Definition()
                                .Line("[PR]")
                            )
                         }
                     )
                 );


        VSTaskVar MGAbnormalityDensityTypeVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                   "MGAbnormalityDensityTypeVS",
                   "Mammography Density Type ValueSet",
                    "MG Density Type/ValueSet",
                   "Mammography density abnormality refinement value set.",
                    Group_MGCodesVS,
                    Self.MGAbnormalityDensityTypeCS.Value()
                    )
            );


        StringTaskVar MGAbnormalityDensity = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.MGAbnormalityDensityTypeVS.Value();

                SDefEditor e = Self.CreateEditor("MGAbnormalityDensity",
                        "Mammography Density",
                        "MG Density",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityDensity")
                    .Description("Breat Radiology Mammography Density Observation",
                        new Markdown()
                            .MissingObservation("a Density abnormality")
                            .Todo(
                                "default value? for refinement"
                            )
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(Self.MGShapeTargetsFragment.Value())
                    ;

                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Density")
                    .Refinement(binding, "Density")
                    ;

                e.Select("value[x]").Zero();

                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(Self.ConsistentWith.Value(), 0, "*")
                };
                e.SliceByUrl("hasMember", targets);
                e.AddProfileTargets(targets);

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("mgAbnormalityDensityType",
                    Self.MGCodeAbnormalityDensityType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "MG AbnormalityDensity Type");
                Self.ComponentSliceObservedCount(e);
            });
    }
}
