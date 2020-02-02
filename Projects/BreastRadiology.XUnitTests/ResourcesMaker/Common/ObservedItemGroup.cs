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
        #region ItemGroupComponentCodes
        VSTaskVar ItemGroupComponentCodesVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "ItemGroupComponentCodesVS",
                        "Item Group Component Codes ValueSet",
                        "Component Code/ValueSet",
                        "Item Group Component Codes value set.",
                        Group_MGCodesVS,
                        Self.ItemGroupComponentCodesCS.Value()
                    )
            );

        CSTaskVar ItemGroupComponentCodesCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "ItemGroupComponentCodesCS",
                        "Item Group Codes CodeSystem",
                        "ItemGroupComponentCodes/CodeSystem",
                        "ItemGroupComponentCodes code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            new ConceptDef()
                                .SetCode("GroupingComponent")
                                .SetDisplay("Grouping Component code")
                                .SetDefinition("Grouping Component code",
                                                "Identifies the component containing the grouping code"),
                            new ConceptDef()
                                .SetCode("SizeComponent")
                                .SetDisplay("Size Component code")
                                .SetDefinition("Size Component code",
                                                "Identifies the component(s) containing the size values")
                        })
            );
        #endregion
        #region DimensionCodes
        VSTaskVar DimensionCodeVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "DimensionCodeVS",
                        "Dimension Code ValueSet",
                        "Dimension Code/ValueSet",
                        "Dimension Code value set.",
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
                                .SetDefinition("[PR] Transverse",
                                                "All dimensions should be Transverse, Anterior-Posterior, and Craniocaudal dimension")
                                ,
                            new ConceptDef()
                                .SetCode("Anterior-Posterior")
                                .SetDisplay("Anterior-Posterior")
                                .SetDefinition("[PR] Anterior-Posterior",
                                                "All dimensions should be Transverse, Anterior-Posterior, and Craniocaudal dimension")
                                ,
                            new ConceptDef()
                                .SetCode("Craniocaudal")
                                .SetDisplay("Craniocaudal")
                                .SetDefinition("[PR] Craniocaudal",
                                                "All dimensions should be Transverse, Anterior-Posterior, and Craniocaudal dimension")
                                ,

                            new ConceptDef()
                                .SetCode("LargestSize")
                                .SetDisplay("LargestSize")
                                .SetDefinition("[PR] LargestSize",
                                                "All dimensions should be Largest, Medium, Smallest")
                                ,
                            new ConceptDef()
                                .SetCode("MiddleSize")
                                .SetDisplay("MiddleSize")
                                .SetDefinition("[PR] Anterior-Posterior",
                                        "All dimensions should be Largest, Medium, Smallest")
                                ,
                            new ConceptDef()
                                .SetCode("SmallestSize")
                                .SetDisplay("SmallestSize")
                                .SetDefinition("[PR] SmallestSize",
                                        "All dimensions should be Largest, Medium, Smallest")
                                ,
                        })
            );
        #endregion
        #region ItemGrouping
        CSTaskVar ItemGroupingCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "ItemGrouping",
                     "Item Grouping CodeSystem",
                     "Item/Grouping/CodeSystem",
                     "Item grouping code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                         new ConceptDef()
                             .SetCode("SingleItem")
                             .SetDisplay("Single Items in Grouping")
                             .SetDefinition("[PR] Single Items in Grouping")
                             ,
                         new ConceptDef()
                             .SetCode("MultipleItems")
                             .SetDisplay("Multiple Items in Grouping")
                             .SetDefinition("[PR] Multiple Items in Grouping")
                             ,
                         new ConceptDef()
                             .SetCode("ClusterOfItems")
                             .SetDisplay("Cluster of Items in Grouping")
                             .SetDefinition("[PR] Cluster of Items in Grouping")
                             ,
                     }));

        VSTaskVar ItemGroupingVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ItemGroupingVS",
                    "Item Grouping ValueSet",
                    "Item/Grouping/ValueSet",
                    "Item Grouping of abnormalities value set.",
                    Group_CommonCodesVS,
                    Self.ItemGroupingCS.Value()
                    )
            );
        #endregion

        SDTaskVar ObservedItemGroup = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateEditor("ObservedItemGroup",
                        "Observed ItemGroup",
                        "ObservedItemGroup",
                        Global.ObservationUrl,
                        $"{Group_MGResources}/ObservedItemGroup",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .Description("Observation of a size or size range in 1, 2, or 3 dimensions.",
                        new Markdown()
                            .Paragraph("Observation of a one or more items and the size and grouping of the item(s)")
                            .Paragraph("The size can be one, two, or three dimensional.",
                                       "The axes can be oriented to certain landmarks, or ordered by size.",
                                       $"Each dimention can be a quantity (i.e. 5 cm), or a range (1 cm to 5 cm).",
                                       $"If the lower bound of the range is set but not the upper bound, then it means {{lower bound}} cm or more.",
                                       $"If the upper bound of the range is set but not the lower bound, then it means {{upper bound}} cm or less.")
                            )
                    ;
                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeObservedItemGroup.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                e.StartComponentSliceing();

                // First component slice is the item grouping type
                {
                    ValueSet binding = Self.ItemGroupingVS.Value();
                    ElementTreeSlice slice = e.ComponentSliceCodeableConcept("groupingType",
                        Self.ItemGroupComponentCodesVS.Value().Find("GroupingComponent").ToCodeableConcept(),
                        binding,
                        BindingStrength.Required,
                        1,
                        "1",
                        "Grouping Type",
                        new Markdown()
                            .Paragraph($"This slice contains the required component that defines the ",
                                        $"type of item grouping.")
                    );
                }

                // Second component slice is the item size value(s)
                {
                    String sliceName = "sizeDimension";
                    ElementTreeSlice slice = e.AppendSlice("component", sliceName, 1, "3");

                    // Bind code to DimensionCodeVS.
                    {
                        ElementDefinition componentCode = new ElementDefinition
                        {
                            Path = $"{slice.ElementDefinition.Path}.code",
                            ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.code",
                            Min = 1,
                            Max = "1",
                            Short = $"Item dimension code",
                            Definition = new Markdown()
                                .Paragraph($"This code identifies the item size dimension.")
                        };
                        componentCode
                            .Binding(Self.DimensionCodeVS.Value(), BindingStrength.Required)
                            ;
                        slice.CreateNode(componentCode);
                    }

                    // Constrain component.valueX.
                    {
                        ElementDefinition componentValueX = new ElementDefinition
                        {
                            Path = $"{slice.ElementDefinition.Path}.valueX",
                            ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.valueX",
                        }
                        .Short($"Item size value")
                        .Definition(new Markdown()
                                .Paragraph("The observed size of an item. This is always in UCUM units, and can",
                                "be a specific size, or a size range."))
                        .ZeroToOne()
                        .Types("Quantity", "Range")
                        .SetComment(componentDefinition)
                        ;

                        ElementTreeNode componentValueXNode = slice.CreateNode(componentValueX);

                        ValueSet units = Self.UnitsOfLengthVS.Value();
                        {
                            Hl7.Fhir.Model.Quantity q = new Hl7.Fhir.Model.Quantity
                            {
                                System = units.Url
                            };

                            componentValueXNode.CreateSlice("valueQuantity").ElementDefinition
                                .ZeroToOne()
                                .Pattern(q)
                                ;
                        }

                        {
                            Hl7.Fhir.Model.Range r = new Hl7.Fhir.Model.Range
                            {
                                Low = new SimpleQuantity { System = units.Url },
                                High = new SimpleQuantity { System = units.Url }
                            };

                            componentValueXNode.CreateSlice("valueRange").ElementDefinition
                                .ZeroToOne()
                                .Pattern(r);
                            ;
                        }

                        e.AddComponentLink("Item Group Components",
                            new SDefEditor.Cardinality(slice.ElementDefinition),
                            Global.ElementAnchor(slice.ElementDefinition),
                            "Quantity | Range",
                            Self.DimensionCodeVS.Value().Url);
                    }
                }
            });


        SDTaskVar ObservedItemGroupFragment = new SDTaskVar(
               (out StructureDefinition s) =>
               {
                   SDefEditor e = Self.CreateFragment("ObservedItemGroupFragment",
                           "ObservedItemGroup Fragment",
                           "ObservedItemGroup Fragment",
                           Global.ObservationUrl)
                       .Description("Fragment that adds 'Observed Item Group' hasmember element to profile.",
                           new Markdown()
                       )
                       ;

                   s = e.SDef;
                   ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                   ElementTreeSlice slice = e.SliceTargetReference(sliceElementDef, Self.ObservedItemGroup.Value(), 0, "1");
                   slice.ElementDefinition.MustSupport();
               });
    }
}
