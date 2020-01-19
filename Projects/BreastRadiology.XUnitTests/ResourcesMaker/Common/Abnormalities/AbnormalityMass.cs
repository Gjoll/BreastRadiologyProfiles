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

                SDefEditor e = Self.CreateEditor("Mass",
                        "Mass",
                        "Mass",
                        ObservationUrl,
                        $"{Group_CommonResources}/MassAbnormality",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .Description("Mass Observation",
                        new Markdown()
                            .BiradHeader()
                            .BlockQuote("\"MASS\" is three dimensional and occupies space. It is seen on two different mammographic pro-")
                            .BlockQuote("jections. It has completely or partially convex-outward borders and (when radiodense) appears")
                            .BlockQuote("denser in the center than at the periphery. If a potential mass is seen only on a single projection, it")
                            .BlockQuote("should be called an \"ASYMMETRY\" until its 3-dimensionality is confirmed")
                            .BiradFooter()
                    )
                    .AddFragRef(Self.TumorSatelliteFragment.Value())

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
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                PreFhir.ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");
                Self.SliceTargetReference(e, sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("massType",
                    Self.CodeAbnormalityMassType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    0,
                    "1",
                    "Mass Type",
                    new Markdown()
                        .Paragraph($"This slice contains the optional component that refines the mass type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
            });
    }
}
