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
                        new ConceptDef("Solid",
                            "Solid Mass",
                            new Definition()
                               .Line("[PR]")
                               .Line("Solid Mass")
                            ),
                        new ConceptDef("Intraductal",
                            "Intraductal Mass",
                            new Definition()
                               .Line("[PR]")
                               .Line("Intraductal Mass")
                            ),
                        new ConceptDef("PartiallySolid",
                            "Partially Solid Mass",
                            new Definition()
                               .Line("[PR]")
                               .Line("Partially Solid Mass")
                            ),
                        new ConceptDef("Skin",
                            "Skin Mass",
                            new Definition()
                               .Line("[PR]")
                               .Line("Skin Mass")
                            )
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

                SDefEditor e = Self.CreateEditorObservationLeaf("Mass",
                        "Mass",
                        "Mass",
                        $"{Group_CommonResources}/MassAbnormality")
                    .Description("Mass Observation",
                        new Markdown()
                            .MissingObservation("a mass abnormality")
                            .BiradHeader()
                            .BlockQuote("\"MASS\" is three dimensional and occupies space. It is seen on two different mammographic pro-")
                            .BlockQuote("jections. It has completely or partially convex-outward borders and (when radiodense) appears")
                            .BlockQuote("denser in the center than at the periphery. If a potential mass is seen only on a single projection, it")
                            .BlockQuote("should be called an \"ASYMMETRY\" until its 3-dimensionality is confirmed")
                            .BiradFooter()
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value().Url)
                    .AddFragRef(Self.ObservationCodedValueFragment.Value().Url)
                    .AddFragRef(Self.ImagingStudyFragment.Value().Url)

                    .AddFragRef(Self.TumorQualifierComponentsFragment.Value().Url)
                    .AddFragRef(Self.CommonComponentsFragment.Value().Url)
                    .AddFragRef(Self.ShapeComponentsFragment.Value().Url)
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value().Url)
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("value[x]").Zero();

                PreFhir.ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");
                Self.SliceTargetReference(e, sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("massType",
                    Self.CodeAbnormalityMassType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "AbnormalityMass Type");
                Self.ComponentSliceObservedCountRange(e);
            });
    }
}
