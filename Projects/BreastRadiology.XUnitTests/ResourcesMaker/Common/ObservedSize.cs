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
using PreFhir;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        VSTaskVar DimensionCodeVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "DimensionCodeVS",
                        "DimensionCode ValueSet",
                        "DimensionCode/ValueSet",
                        "DimensionCode value set.",
                        Group_MGCodesVS,
                        Self.DimensionCodeCS.Value()
                    )
            );

        CSTaskVar DimensionCodeCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "DimensionCodeCodeSystemCS",
                        "Consistent With CodeSystem",
                        "DimensionCode/CodeSystem",
                        "DimensionCode code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            new ConceptDef()
                                .SetCode("Transverse")
                                .SetDisplay("Transverse")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Transverse")
                                    .Line("All dimensions should be Transverse, Anterior-Posterior, and Craniocaudal dimension")
                                ),
                            new ConceptDef()
                                .SetCode("Anterior-Posterior")
                                .SetDisplay("Anterior-Posterior")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Anterior-Posterior")
                                    .Line("All dimensions should be Transverse, Anterior-Posterior, and Craniocaudal dimension")
                                ),
                            new ConceptDef()
                                .SetCode("Craniocaudal")
                                .SetDisplay("Craniocaudal")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Craniocaudal")
                                    .Line("All dimensions should be Transverse, Anterior-Posterior, and Craniocaudal dimension")
                                ),

                            new ConceptDef()
                                .SetCode("LargestSize")
                                .SetDisplay("LargestSize")
                                .SetDefinition(new Definition()
                                    .Line("[PR] LargestSize")
                                    .Line("All dimensions should be Largest, Medium, Smallest")
                                ),
                            new ConceptDef()
                                .SetCode("MiddleSize")
                                .SetDisplay("MiddleSize")
                                .SetDefinition(new Definition()
                                    .Line("[PR] Anterior-Posterior")
                                    .Line("All dimensions should be Largest, Medium, Smallest")
                                ),
                            new ConceptDef()
                                .SetCode("SmallestSize")
                                .SetDisplay("SmallestSize")
                                .SetDefinition(new Definition()
                                    .Line("[PR] SmallestSize")
                                    .Line("All dimensions should be Largest, Medium, Smallest")
                                ),
                        })
            );

        SDTaskVar ObservedSize = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateEditor("ObservedSize",
                        "Observed Size",
                        "ObservedSize",
                        ObservationUrl,
                        $"{Group_MGResources}/ObservedSize",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .Description("Observation of a size or size range in 1, 2, or 3 dimensions.",
                        new Markdown()
                            .Paragraph("Size observations can be one, two, or three dimensional.",
                                       "The axes can be oriented to certain landmarks, or ordered by size.",
                                       $"Each dimention can be a quantity (i.e. 5 cm), or a range (1 cm to 5 cm).",
                                       $"If the lower bound of the range is set but not the upper bound, then it means {{lower bound}} cm or more.",
                                       $"If the upper bound of the range is set but not the lower bound, then it means {{upper bound}} cm or less.")
                            )
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                // Set Observation.code to ObservedSize
                e.Select("code")
                    .Pattern(Self.CodeObservedSize.ToCodeableConcept())
                    ;

                // Constrain Observation.component
                ElementDefinition elementComponent = e.Select("component")
                    .Card(1, 3)
                    ;

                e.Select("component.code")
                    .WithBinding(Self.DimensionCodeVS.Value().Url, BindingStrength.Required)
                    ;

                ElementDefinition.SlicingComponent slicingComponent = new ElementDefinition.SlicingComponent
                {
                    Rules = ElementDefinition.SlicingRules.Closed
                };

                slicingComponent.Discriminator.Add(new ElementDefinition.DiscriminatorComponent
                {
                    Type = ElementDefinition.DiscriminatorType.Type,
                    Path = "$this"
                });

                ElementTreeNode componentValueXNode = e.Get("component.value[x]");
                componentValueXNode.ElementDefinition
                    .Types("Quantity", "Range")
                    .ApplySlicing(slicingComponent, false)
                    .Short("Size value")
                    .Definition(new Markdown()
                            .Paragraph("The observed size of an item. This is always in UCUM units, and can",
                            "be a specific size, or a size range.")
                        )
                    .SetComment(componentDefinition)
                ;

                ValueSet units = Self.UnitsOfLengthVS.Value();

                {
                    Hl7.Fhir.Model.Quantity q = new Hl7.Fhir.Model.Quantity
                    {
                        System = units.Url
                    };

                    componentValueXNode.CreateSlice("valueQuantity").ElementDefinition
                        .ZeroToOne()
                        .Pattern(q);
                        ;
                }

                {
                    Hl7.Fhir.Model.Range r = new Hl7.Fhir.Model.Range
                    {
                        Low = new SimpleQuantity
                        {
                            System = units.Url,
                        },
                        High = new SimpleQuantity
                        {
                            System = units.Url,
                        }
                    };

                    componentValueXNode.CreateSlice("valueRange").ElementDefinition
                        .ZeroToOne()
                        .Pattern(r);
                    ;
                }

                e.AddComponentLink("Size Components",
                    new SDefEditor.Cardinality(elementComponent),
                    Global.ElementAnchor(elementComponent),
                    "Quantity | Range",
                    Self.DimensionCodeVS.Value().Url);
            });


        SDTaskVar ObservedSizeFragment = new SDTaskVar(
               (out StructureDefinition s) =>
               {
                   SDefEditor e = Self.CreateFragment("ObservedSizeFragment",
                           "ObservedSize Fragment",
                           "ObservedSize Fragment",
                           ObservationUrl)
                       .Description("Fragment that adds 'Observed Size' hasmember element to profile.",
                           new Markdown()
                       )
                       ;

                   s = e.SDef;
                   ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                   ElementTreeSlice slice = e.SliceTargetReference(sliceElementDef, Self.ObservedSize.Value(), 0, "1");
                   slice.ElementDefinition.MustSupport();
               });
    }
}
