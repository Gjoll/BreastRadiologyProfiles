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
        CSTaskVar BreastLocationRegionCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                         "BreastLocationRegionCS",
                         "Breast Location Region CodeSystem",
                         "Breast/Location/Region/CodeSystem",
                         "Breast body location region code system.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                        new ConceptDef("Central",
                            "Central Region",
                            new Definition()
                                .Line("Central region of the breast (behind nipple)")
                            ),

                        new ConceptDef("RetroaReolar",
                            "RetroaReolar Region",
                            new Definition()
                                .Line("Central location in the anterior third of the breast close to the nipple")
                            ),
                        new ConceptDef("AxillaryTail",
                            "AxillaryTail Region",
                            new Definition()
                                .Line("Upper outer region location adjacent to the axilla but within the breast mound")
                            ),
                        new ConceptDef("Axilla",
                            "Axilla Region",
                            new Definition()
                                .Line("Upper outer region location in the axilla")
                            ),
                        new ConceptDef("InframammaryFold",
                            "Inframammary Fold Region",
                            new Definition()
                                .Line("Inframammary Fold")
                            ),
                        new ConceptDef("InSkin",
                            "In Skin",
                            new Definition()
                                .Line("In Skin")
                            )
                         })
                     );

        CSTaskVar BreastLocationQuadrantCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                         "BreastLocationQuadrantCS",
                         "Breast Location Quadrant CodeSystem",
                         "Breast/Location/Quadrant/CodeSystem",
                         "Breast body location quadrant code system.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                        new ConceptDef("UpperOuter",
                            "Upper Outer Quadrant",
                            new Definition()
                                .Line("Upper outer quadrant of the breast")
                            ),

                        new ConceptDef("UpperInner",
                            "Upper Inner Quadrant",
                            new Definition()
                                .Line("Upper inner quadrant of the breast")
                            ),

                        new ConceptDef("LowerOuter",
                            "Lower Outer Quadrant",
                            new Definition()
                                .Line("Lower outer quadrant of the breast")
                            ),

                        new ConceptDef("LowerInner",
                            "Lower Inner Quadrant",
                            new Definition()
                                .Line("Lower inner quadrant of the breast")
                            )

                         })
             );
        CSTaskVar BreastLocationClockCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                         "BreastLocationClockCS",
                         "Breast Location Clock CodeSystem",
                         "Breast/Location/Clock/CodeSystem",
                         "Breast body location angles (expressed in clock-face units) code system.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                        new ConceptDef("12:00-OClock",
                            "12:00-OClock",
                            new Definition()
                                .Line("12-OClock")
                            ),
                        new ConceptDef("1:00-OClock",
                            "1:00-OClock",
                            new Definition()
                                .Line("1:00-OClock")
                            ),
                        new ConceptDef("2:00-OClock",
                            "2:00-OClock",
                            new Definition()
                                .Line("2:00-OClock")
                            ),
                        new ConceptDef("3:00-OClock",
                            "3:00-OClock",
                            new Definition()
                                .Line("3:00-OClock")
                            ),
                        new ConceptDef("4:00-OClock",
                            "4:00-OClock",
                            new Definition()
                                .Line("4:00-OClock")
                            ),
                        new ConceptDef("5:00-OClock",
                            "5:00-OClock",
                            new Definition()
                                .Line("5:00-OClock")
                            ),
                        new ConceptDef("6:00-OClock",
                            "6:00-OClock",
                            new Definition()
                                .Line("6:00-OClock")
                            ),
                        new ConceptDef("7:00-OClock",
                            "7:00-OClock",
                            new Definition()
                                .Line("7:00-OClock")
                            ),
                        new ConceptDef("8:00-OClock",
                            "8:00-OClock",
                            new Definition()
                                .Line("8:00-OClock")
                            ),
                        new ConceptDef("9:00-OClock",
                            "9:00-OClock",
                            new Definition()
                                .Line("9:00-OClock")
                            ),
                        new ConceptDef("10:00-OClock",
                            "10:00-OClock",
                            new Definition()
                                .Line("10:00-OClock")
                            ),
                        new ConceptDef("11:00-OClock",
                            "11:00-OClock",
                            new Definition()
                                .Line("11:00-OClock")
                            ),
                         })
                     );

        CSTaskVar BreastLocationDepthCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                         "BreastLocationDepthCS",
                         "Breast Location Depth CodeSystem",
                         "Breast/Location/Depth/CodeSystem",
                         "Breast body location depth code system.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                        new ConceptDef("Anterior",
                            "Anterior depth",
                            new Definition()
                                .Line("Anterior depth")
                            ),
                        new ConceptDef("Middle",
                            "Middle depth",
                            new Definition()
                                .Line("Middle depth")
                            ),
                        new ConceptDef("Posterior",
                            "Posterior depth",
                            new Definition()
                                .Line("Posterior depth")
                            )
                         })
             );

        VSTaskVar BreastLocationRegionVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "BreastLocationRegionVS",
                        "Breast Location Region ValueSet",
                        "Breast/Location/RegionValueSet",
                        "Breast body location region value set.",
                        Group_CommonCodesVS,
                        Self.BreastLocationRegionCS.Value()
                )
            );

        VSTaskVar BreastLocationClockVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "BreastLocationClockVS",
                        "Breast Location Clock ValueSet",
                        "Breast/Location/ClockValueSet",
                        "Breast body location angles (expressed in clock-face units) value set.",
                        Group_CommonCodesVS,
                        Self.BreastLocationClockCS.Value()
                )
            );

        VSTaskVar BreastLocationDepthVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "BreastLocationDepthVS",
                        "Breast Location Depth ValueSet",
                        "Breast/Location/DepthValueSet",
                        "Breast body location depth value set.",
                        Group_CommonCodesVS,
                        Self.BreastLocationDepthCS.Value()
                )
            );

        VSTaskVar BreastLocationQuadrantVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "BreastLocationQuadrantVS",
                        "Breast Location Quadrant ValueSet",
                        "Breast/Location/QuadrantValueSet",
                        "Breast body location quadrant code system value set.",
                        Group_CommonCodesVS,
                        Self.BreastLocationQuadrantCS.Value()
                )
            );

        //$ Fix: complex extension is wrong - subslices are not identified.
        public SDTaskVar BreastBodyLocationExtension = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e;
                ElementTreeNode extensionNode;

                //void AddMapLink(ValueSet binding)
                //{
                //    breastBodyLocationMapLinks.Add(new ResourceMap.Link("valueSet", binding.Url, false));
                //}

                ElementTreeNode Slice(String sliceName,
                    String shortText,
                    Markdown definition)
                {
                    ElementTreeSlice extensionElement = extensionNode.CreateSlice(sliceName);
                    extensionElement.ElementDefinition
                        .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}")
                        .SliceName(sliceName)
                        .Short(shortText)
                        .Definition(definition)
                        .SetCardinality(0, "1")
                        ;
                    extensionElement.ElementDefinition.Type = null;
                    extensionElement.ElementDefinition.Type = null;

                    ElementDefinition sealExtension = new ElementDefinition
                    {
                        ElementId = $"{extensionNode.ElementDefinition.Path}:{sliceName}.extension",
                        Path = $"{extensionNode.ElementDefinition.Path}.extension"
                    };

                    sealExtension.Zero();
                    extensionElement.CreateNode(sealExtension);

                    ElementDefinition elementUrl = new ElementDefinition()
                        .Path($"{extensionNode.ElementDefinition.Path}.url")
                        .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}.url")
                        .Value(new FhirUrl(sliceName))
                        ;
                    extensionElement.CreateNode(elementUrl);

                    ElementDefinition elementValue = new ElementDefinition()
                        .Path($"{extensionNode.ElementDefinition.Path}.value[x]")
                        .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}.value[x]")
                        ;
                    return extensionElement.CreateNode(elementValue);
                }

                void SliceAndBindUrl(String sliceName,
                    String bindName,
                    String shortText,
                    Markdown definition)
                {
                    ElementDefinition elementValue = Slice(sliceName, shortText, definition).ElementDefinition;
                    elementValue
                        .Type("CodeableConcept")
                        .Binding(bindName, BindingStrength.Required)
                        .Single()
                        ;
                }

                void SliceAndBindVS(String sliceName,
                    ValueSet binding,
                    String shortText,
                    Markdown definition)
                {
                    SliceAndBindUrl(sliceName, binding.Url, shortText, definition);
                    e.AddValueSetLink(binding);
                }


                e = Self.CreateEditor("BreastBodyLocationExtension",
                    "Breast Body Location Extension",
                    "Breast Body Loc.",
                    ExtensionUrl,
                    $"{Group_ExtensionResources}/BreastBodyLocation",
                    "Extension")
                    .Description("Breast Body Location extension",
                        new Markdown()
                            .Paragraph("this extension defines the fields that are used to describe the" +
                                       "location of an observed item in a breast radiology report")
                            .Paragraph("Breast radiology exams have specific ways of defining a location that are unique to this field.")
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;
                s = e.SDef;

                e.AddFragRef(Self.HeaderFragment.Value());

                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]").Zero();

                extensionNode = e.ConfigureSliceByUrlDiscriminator("extension", true);

                SliceAndBindUrl("laterality",
                    "http://hl7.org/fhir/ValueSet/bodysite-laterality",
                    "Laterality of the body location",
                    new Markdown().Paragraph("The laterality of the body location"));

                {
                    ValueSet binding = Self.BreastLocationQuadrantVS.Value();

                    {
                        IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                        valueSetIntroDoc
                            .ReviewedStatus(ReviewStatus.NotReviewed)
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        Self.fc?.Mark(outputPath);
                    }

                    SliceAndBindVS("quadrant",
                        binding,
                        "Quadrant of the body location",
                        new Markdown().Paragraph("The quadrant  of the body location"));
                }

                {
                    ValueSet binding = Self.BreastLocationRegionVS.Value();

                    {
                        IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                        valueSetIntroDoc
                            .ReviewedStatus(ReviewStatus.NotReviewed)
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        Self.fc?.Mark(outputPath);
                    }

                    SliceAndBindVS("region",
                        binding,
                        "Region of the body location",
                        new Markdown().Paragraph("The region  of the body location"));
                }

                {
                    ValueSet binding = Self.BreastLocationClockVS.Value();

                    {
                        IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                        valueSetIntroDoc
                            .ReviewedStatus(ReviewStatus.NotReviewed)
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        Self.fc?.Mark(outputPath);
                    }

                    SliceAndBindVS("clockDirection",
                        binding,
                        "Clock direction of the body location",
                        new Markdown().Paragraph("The clock direction of the body location."));
                }

                {
                    ValueSet binding = Self.BreastLocationDepthVS.Value();
                    {
                        IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                        valueSetIntroDoc
                            .ReviewedStatus(ReviewStatus.NotReviewed)
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        Self.fc?.Mark(outputPath);
                    }

                    SliceAndBindVS("depth",
                        binding,
                        "Depth of the body location",
                        new Markdown().Paragraph("The depth of the body location."));
                }
                {
                    ElementDefinition extensionDef = e
                        .ApplyExtension("distanceFromLandmark", Self.BodyDistanceFromExtension.Value(), true)
                        .Single()
                        ;
                    e.AddExtensionLink(extensionDef);
                }
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
            });
    }
}
