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
        #region ItemRegionComponentCodes
        VSTaskVar ItemRegionComponentCodesVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "ItemRegionComponentCodesVS",
                        "Item Region Component Codes ValueSet",
                        "Component Code/ValueSet",
                        "Item Region Component Codes value set.",
                        Group_MGCodesVS,
                        Self.ItemRegionComponentCodesCS.Value()
                    )
            );

        CSTaskVar ItemRegionComponentCodesCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "ItemRegionComponentCodesCS",
                        "Item Region Codes CodeSystem",
                        "ItemRegionComponentCodes/CodeSystem",
                        "ItemRegionComponentCodes code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            new ConceptDef()
                                .SetCode("RegionComponent")
                                .SetDisplay("Region Component code")
                                .SetDefinition("Region Component",
                                                "Identifies the component containing the grouping code")
                                ,
                            new ConceptDef()
                                .SetCode("SizeComponent")
                                .SetDisplay("Size Component code")
                                .SetDefinition("Size Component",
                                                "Identifies the component(s) containing the size values")
                                ,
                        })
            );
        #endregion
        #region ItemRegion
        CSTaskVar ItemRegionCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "ItemRegion",
                     "Item Region CodeSystem",
                     "Item/Region/CodeSystem",
                     "Item grouping code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                         new ConceptDef()
                             .SetCode("SingleItem")
                             .SetDisplay("Single Region")
                             .SetDefinition("[PR] Single Region"),
                         new ConceptDef()
                             .SetCode("MultipleItems")
                             .SetDisplay("Multiple Regions")
                             .SetDefinition("[PR] Multiple Regions"),
                         new ConceptDef()
                             .SetCode("ClusterOfItems")
                             .SetDisplay("Cluster of Regions")
                             .SetDefinition("[PR] Cluster of Regions")
                     }));

        VSTaskVar ItemRegionVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ItemRegionVS",
                    "Item Region ValueSet",
                    "Item/Region/ValueSet",
                    "Item Region of abnormalities value set.",
                    Group_CommonCodesVS,
                    Self.ItemRegionCS.Value()
                    )
            );
        #endregion

        SDTaskVar ObservedItemRegion = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateEditor("ObservedItemRegion",
                        "Observed ItemRegion",
                        "ObservedItemRegion",
                        Global.ObservationUrl,
                        $"{Group_MGResources}/ObservedItemRegion",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .Description("Observation Region",
                        new Markdown()
                            .Paragraph("Observation of a region containing abnormalities.")
                            .Paragraph("The size of the region can be one, two, or three dimensional.",
                                       "The axes can be oriented to certain landmarks, or ordered by size.",
                                       $"Each dimention can be a quantity (i.e. 5 cm), or a range (1 cm to 5 cm).",
                                       $"If the lower bound of the range is set but not the upper bound, then it means {{lower bound}} cm or more.",
                                       $"If the upper bound of the range is set but not the lower bound, then it means {{upper bound}} cm or less.")
                            .Paragraph("The region can be a single region, or multiple regions, or a cluster of regions.")
                            .Paragraph($"If the referencing Observation references an {Self.ObservedItemGroup.Value().Name} item, then",
                                       $"the meaning of the region changes slightly. The region now becomes a region of",
                                       $"the {Self.ObservedItemGroup.Value().Name} items.")
                            .Paragraph($"i.e. if {Self.ObservedItemGroup.Value().Name} is 'a Cluster of 1x1x1cm items'",
                                       $"and the region is 'cluster or 2x2x2cm areas",
                                       $"then the two togother would be cluster or 2x2x2cm areas each containing a Cluster of 1x1x1cm items'")
                            )
                    ;
                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeObservedItemRegion.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                // Set Observation.code to ObservedItemRegion
                e.Select("code")
                    .Pattern(Self.ObservationCodeObservedItemRegion.ToCodeableConcept())
                    ;

                e.StartComponentSliceing();

                // First component slice is the item grouping type
                {
                    ValueSet binding = Self.ItemRegionVS.Value();
                    ElementTreeSlice slice = e.ComponentSliceCodeableConcept("groupingType",
                        Self.ItemRegionComponentCodesVS.Value().Find("RegionComponent").ToCodeableConcept(),
                        binding,
                        BindingStrength.Required,
                        1,
                        "1",
                        "Region Type",
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

                        e.AddComponentLink("Item Region Components",
                            new SDefEditor.Cardinality(slice.ElementDefinition),
                            Global.ElementAnchor(slice.ElementDefinition),
                            "Quantity | Range",
                            Self.DimensionCodeVS.Value().Url);
                    }
                }
            });


        SDTaskVar ObservedItemRegionFragment = new SDTaskVar(
               (out StructureDefinition s) =>
               {
                   SDefEditor e = Self.CreateFragment("ObservedItemRegionFragment",
                           "ObservedItemRegion Fragment",
                           "ObservedItemRegion Fragment",
                           Global.ObservationUrl)
                       .Description("Fragment that adds 'Observed Item Region' hasmember element to profile.",
                           new Markdown()
                       )
                       ;

                   s = e.SDef;
                   ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                   ElementTreeSlice slice = e.SliceTargetReference(sliceElementDef, Self.ObservedItemRegion.Value(), 0, "1");
                   slice.ElementDefinition.MustSupport();
               });
    }
}
