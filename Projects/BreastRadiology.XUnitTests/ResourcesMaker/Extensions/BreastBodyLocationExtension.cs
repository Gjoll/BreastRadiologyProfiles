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
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                         "BreastLocationRegionCS",
                         "Breast Location Region CodeSystem",
                         "Breast/Location/Region/CodeSystem",
                         "Breast body location region code system.",
                         Group_CommonCodes,
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
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                         "BreastLocationQuadrantCS",
                         "Breast Location Quadrant CodeSystem",
                         "Breast/Location/Quadrant/CodeSystem",
                         "Breast body location quadrant code system.",
                         Group_CommonCodes,
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
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                         "BreastLocationClockCS",
                         "Breast Location Clock CodeSystem",
                         "Breast/Location/Clock/CodeSystem",
                         "Breast body location angles (expressed in clock-face units) code system.",
                         Group_CommonCodes,
                         new ConceptDef[]
                         {
                        new ConceptDef("12-OClock",
                            "12-OClock",
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
             () =>
                 ResourcesMaker.Self.CreateCodeSystem(
                         "BreastLocationDepthCS",
                         "Breast Location Depth CodeSystem",
                         "Breast/Location/Depth/CodeSystem",
                         "Breast body location depth code system.",
                         Group_CommonCodes,
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
            () =>
                ResourcesMaker.Self.CreateValueSet(
                        "BreastLocationRegionVS",
                        "Breast Location Region ValueSet",
                        "Breast/Location/RegionValueSet",
                        "Breast body location region value set.",
                        Group_CommonCodes,
                        ResourcesMaker.Self.BreastLocationRegionCS.Value()
                )
            );

        VSTaskVar BreastLocationClockVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                        "BreastLocationClockVS",
                        "Breast Location Clock ValueSet",
                        "Breast/Location/ClockValueSet",
                        "Breast body location angles (expressed in clock-face units) value set.",
                        Group_CommonCodes,
                        ResourcesMaker.Self.BreastLocationClockCS.Value()
                )
            );

        VSTaskVar BreastLocationDepthVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                        "BreastLocationDepthVS",
                        "Breast Location Depth ValueSet",
                        "Breast/Location/DepthValueSet",
                        "Breast body location depth value set.",
                        Group_CommonCodes,
                        ResourcesMaker.Self.BreastLocationDepthCS.Value()
                )
            );

        VSTaskVar BreastLocationQuadrantVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                        "BreastLocationQuadrantVS",
                        "Breast Location Quadrant ValueSet",
                        "Breast/Location/QuadrantValueSet",
                        "Breast body location quadrant code system value set.",
                        Group_CommonCodes,
                        ResourcesMaker.Self.BreastLocationQuadrantCS.Value()
                )
            );

        StringTaskVar BreastBodyLocationExtension = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e;
                ElementDefGroup eGroup;
                ElementDefinition topExtension;

                void AddMapLink(ValueSet binding)
                {
                    //breastBodyLocationMapLinks.Add(new ResourceMap.Link("valueSet", binding.Url, false));
                }

                void SliceAndBind(String sliceName,
                    String bindName,
                    String shortText,
                    Markdown definition)
                {
                    ElementDefinition extensionElement = e.Clone("extension");
                    extensionElement
                        .ElementId($"{topExtension.Path}:{sliceName}")
                        .SliceName(sliceName)
                        .ZeroToOne()
                        ;
                    ElementDefGroup extensionGroup = e.InsertAfter(eGroup, extensionElement);

                    ElementDefinition sealExtension = e.Clone("extension");
                    sealExtension
                        .ElementId($"{topExtension.Path}:{sliceName}.extension")
                        .Path($"{topExtension.Path}.extension")
                        .Zero()
                        ;
                    e.InsertAfter(extensionGroup, sealExtension);

                    ElementDefinition elementValue = e.Clone("value[x]")
                        .Path($"{topExtension.Path}.value[x]")
                        .ElementId($"{topExtension.Path}:{sliceName}.value[x]")
                        .Type("CodeableConcept")
                        .Binding(bindName, BindingStrength.Required)
                        .Single()
                        .Short(shortText)
                        .Definition(definition)
                        ;
                    e.InsertAfter(extensionGroup, elementValue);
                }

                //breastBodyLocationMapLinks = new List<ResourceMap.Link>();

                e = ResourcesMaker.Self.CreateEditor("BreastBodyLocationExtension",
                    "Breast Body Location Extension",
                    "Breast Body Loc.",
                    ExtensionUrl,
                    $"{Group_ExtensionResources}/BreastBodyLocation")
                    .Description("Breast Body Location extension",
                        new Markdown()
                            .Paragraph("this extension defines the fields that are used to describe the" +
                                       "location of an observed item in a breat radiology report")
                            .Paragraph("Breast radiology exams have specific ways of defining a location that are unique to this field.")
                            //.Todo
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;
                s = e.SDef.Url;

                //breastBodyLocationMapLinks.Add(new ResourceMap.Link("extension", breastBodyLocationExtension, false));

                e.AddFragRef(ResourcesMaker.Self.HeaderFragment.Value());

                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]")
                    .Zero()
                    ;

                eGroup = e.GetOrCreate("extension");
                topExtension = eGroup.ElementDefinition;
                topExtension.ConfigureSliceByUrlDiscriminator();

                SliceAndBind("laterality",
                    "http://hl7.org/fhir/ValueSet/bodysite-laterality",
                    "Laterality of the body location",
                    new Markdown().Paragraph("The laterality of the body location"));

                {
                    ValueSet binding = ResourcesMaker.Self.BreastLocationQuadrantVS.Value();

                    {
                        IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                        valueSetIntroDoc
                            .ReviewedStatus(ReviewStatus.NotReviewed)
                            .ValueSet(binding);
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        ResourcesMaker.Self.fc?.Mark(outputPath);
                    }

                    SliceAndBind("quadrant",
                        binding.Url,
                        "Quadrant of the body location",
                        new Markdown().Paragraph("The quadrant  of the body location"));
                    AddMapLink(binding);
                }

                {
                    ValueSet binding = ResourcesMaker.Self.BreastLocationRegionVS.Value();

                    {
                        IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                        valueSetIntroDoc
                            .ReviewedStatus(ReviewStatus.NotReviewed)
                            .ValueSet(binding);
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        ResourcesMaker.Self.fc?.Mark(outputPath);
                    }

                    SliceAndBind("region",
                        binding.Url,
                        "Region of the body location",
                        new Markdown().Paragraph("The region  of the body location"));
                    AddMapLink(binding);
                }
                {

                    ValueSet binding = ResourcesMaker.Self.BreastLocationClockVS.Value();

                    {
                        IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                        valueSetIntroDoc
                            .ReviewedStatus(ReviewStatus.NotReviewed)
                            .ValueSet(binding);
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        ResourcesMaker.Self.fc?.Mark(outputPath);
                    }

                    SliceAndBind("clockDirection",
                        binding.Url,
                        "Clock direction of the body location",
                        new Markdown().Paragraph("The clock direction of the body location."));
                    AddMapLink(binding);
                }

                {

                    ValueSet binding = ResourcesMaker.Self.BreastLocationDepthVS.Value();
                    {
                        IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(ResourcesMaker.Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                        valueSetIntroDoc
                            .ReviewedStatus(ReviewStatus.NotReviewed)
                            .ValueSet(binding);
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        ResourcesMaker.Self.fc?.Mark(outputPath);
                    }

                    SliceAndBind("depth",
                        binding.Url,
                        "Depth of the body location",
                        new Markdown().Paragraph("The depth of the body location."));
                    AddMapLink(binding);
                }

                {
                    ElementDefinition distanceFromNipple = e.Clone("extension");
                    distanceFromNipple
                        .ElementId($"{topExtension.Path}:distanceFromNipple")
                        .SliceName("distanceFromNipple")
                        ;
                    ElementDefGroup distanceFromNippleGroup = e.InsertAfter(eGroup, distanceFromNipple);
                    ElementDefinition distanceFromNippleValue = e.Clone("value[x]")
                        .Path($"{topExtension.Path}.value[x]")
                        .ElementId($"{topExtension.Path}:distanceFromNipple.value[x]")
                        .Type("Quantity")
                        .Single()
                        .Short("Distance from nipple")
                        .Definition("Distance from nipple to body location")
                        ;
                    e.InsertAfter(distanceFromNippleGroup, distanceFromNippleValue);

                    ElementDefinition quantitySystem = new ElementDefinition()
                        .Path($"{topExtension.Path}.value[x].system")
                        .ElementId($"{topExtension.Path}:distanceFromNipple.value[x].system")
                        .Type("uri")
                        .Single()
                        .Fixed(new FhirUri("http://unitsofmeasure.org"))
                        ;
                    e.InsertAfter(distanceFromNippleGroup, quantitySystem);

                    ElementDefinition quantityCode = new ElementDefinition()
                        .Path($"{topExtension.Path}.value[x].code")
                        .ElementId($"{topExtension.Path}:distanceFromNipple.value[x].code")
                        .Type("uri")
                        .Single()
                        .Binding("http://hl7.org/fhir/us/breast-radiology/ValueSet/UnitsOfLengthVS",
                                BindingStrength.Required)
                        ;
                    e.InsertAfter(distanceFromNippleGroup, quantityCode);
                }

                {
                    ElementDefinition distanceFromSkin = e.Clone("extension");
                    distanceFromSkin
                        .ElementId($"{topExtension.Path}:distanceFromSkin")
                        .SliceName("distanceFromSkin")
                        ;
                    ElementDefGroup distanceFromSkinGroup = e.InsertAfter(eGroup, distanceFromSkin);
                    ElementDefinition distanceFromSkinValue = e.Clone("value[x]")
                        .Path($"{topExtension.Path}.value[x]")
                        .ElementId($"{topExtension.Path}:distanceFromSkin.value[x]")
                        .Type("Quantity")
                        .Short("Distance from skin")
                        .Definition("Distance from skin to body location")
                        .Single()
                        ;
                    e.InsertAfter(distanceFromSkinGroup, distanceFromSkinValue);

                    ElementDefinition quantitySystem = new ElementDefinition()
                        .Path($"{topExtension.Path}.value[x].system")
                        .ElementId($"{topExtension.Path}:distanceFromSkin.value[x].system")
                        .Type("uri")
                        .Single()
                        .Fixed(new FhirUri("http://unitsofmeasure.org"))
                        ;
                    e.InsertAfter(distanceFromSkinGroup, quantitySystem);

                    ElementDefinition quantityCode = new ElementDefinition()
                        .Path($"{topExtension.Path}.value[x].code")
                        .ElementId($"{topExtension.Path}:distanceFromSkin.value[x].code")
                        .Type("uri")
                        .Single()
                        .Binding("http://hl7.org/fhir/us/breast-radiology/ValueSet/UnitsOfLengthVS",
                                BindingStrength.Required)
                        ;
                    e.InsertAfter(distanceFromSkinGroup, quantityCode);
                }

                {
                    ElementDefinition distanceFromChestWall = e.Clone("extension");
                    distanceFromChestWall
                        .ElementId($"{topExtension.Path}:distanceFromChestWall")
                        .SliceName("distanceFromChestWall")
                        ;
                    ElementDefGroup distanceFromChestWallGroup = e.InsertAfter(eGroup, distanceFromChestWall);
                    ElementDefinition distanceFromChestWallValue = e.Clone("value[x]")
                        .Path($"{topExtension.Path}.value[x]")
                        .ElementId($"{topExtension.Path}:distanceFromChestWall.value[x]")
                        .Type("Quantity")
                        .Short("Distance from chest wall")
                        .Definition("Distance from chest wall to body location")
                        .Single()
                        ;
                    e.InsertAfter(distanceFromChestWallGroup, distanceFromChestWallValue);

                    ElementDefinition quantitySystem = new ElementDefinition()
                        .Path($"{topExtension.Path}.value[x].system")
                        .ElementId($"{topExtension.Path}:distanceFromChestWall.value[x].system")
                        .Type("uri")
                        .Single()
                        .Fixed(new FhirUri("http://unitsofmeasure.org"))
                        ;
                    e.InsertAfter(distanceFromChestWallGroup, quantitySystem);

                    ElementDefinition quantityCode = new ElementDefinition()
                        .Path($"{topExtension.Path}.value[x].code")
                        .ElementId($"{topExtension.Path}:distanceFromChestWall.value[x].code")
                        .Type("uri")
                        .Single()
                        .Binding("http://hl7.org/fhir/us/breast-radiology/ValueSet/UnitsOfLengthVS",
                                BindingStrength.Required)
                        ;
                    e.InsertAfter(distanceFromChestWallGroup, quantityCode);

                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Extension("Breast Body Location", "define a location in the breast")
                    ;
            });
    }
}
