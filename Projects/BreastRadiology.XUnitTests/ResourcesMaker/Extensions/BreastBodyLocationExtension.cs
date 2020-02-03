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
                         "Breast Location/Region CodeSystem",
                         "Breast body location region code system.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                        new ConceptDef()
                            .SetCode("Central", "Central Region")
                            .SetDefinition("Central region of the breast (behind nipple)"),
                        new ConceptDef()
                            .SetCode("RetroaReolar", "RetroaReolar Region")
                            .SetDefinition("Central location in the anterior third of the breast close to the nipple"),
                        new ConceptDef()
                            .SetCode("AxillaryTail", "AxillaryTail Region")
                            .SetDefinition("Upper outer region location adjacent to the axilla but within the breast mound"),
                        new ConceptDef()
                            .SetCode("Axilla", "Axilla Region")
                            .SetDefinition("Upper outer region location in the axilla"),
                        new ConceptDef()
                            .SetCode("AxillaI", "Axilla Region I")
                            .SetDefinition("Axilla Region I"),
                        new ConceptDef()
                            .SetCode("AxillaII", "Axilla Region II")
                            .SetDefinition("Axilla Region II"),
                        new ConceptDef()
                            .SetCode("AxillaIII", "Axilla Region III")
                            .SetDefinition("Axilla Region III"),
                        new ConceptDef()
                            .SetCode("InframammaryFold", "Inframammary Fold Region")
                            .SetDefinition("Inframammary Fold"),
                        new ConceptDef()
                            .SetCode("InSkin", "In Skin")
                            .SetDefinition("In Skin")
                         })
                     );

        CSTaskVar BreastLocationQuadrantCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                         "BreastLocationQuadrantCS",
                         "Breast Location Quadrant CodeSystem",
                         "Breast Location/Quadrant CodeSystem",
                         "Breast body location quadrant code system.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                        new ConceptDef()
                            .SetCode("UpperOuter", "Upper Outer Quadrant")
                            .SetDefinition("Upper outer quadrant of the breast"),
                        new ConceptDef()
                            .SetCode("UpperInner", "Upper Inner Quadrant")
                            .SetDefinition("Upper inner quadrant of the breast"),
                        new ConceptDef()
                            .SetCode("LowerOuter", "Lower Outer Quadrant")
                            .SetDefinition("Lower outer quadrant of the breast"),
                        new ConceptDef()
                            .SetCode("LowerInner", "Lower Inner Quadrant")
                            .SetDefinition("Lower inner quadrant of the breast")
                         })
             );
        CSTaskVar BreastLocationClockCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                         "BreastLocationClockCS",
                         "Breast Location Clock CodeSystem",
                         "Breast Location/Clock CodeSystem",
                         "Breast body location angles (expressed in clock-face units) code system.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                        new ConceptDef()
                             .SetCode("12:00-OClock", "12:00-OClock")
                             .SetDefinition("12-OClock"),
                        new ConceptDef()
                            .SetCode("1:00-OClock", "1:00-OClock")
                            .SetDefinition("1:00-OClock"),
                        new ConceptDef()
                            .SetCode("2:00-OClock", "2:00-OClock")
                            .SetDefinition("2:00-OClock"),
                        new ConceptDef()
                            .SetCode("3:00-OClock", "3:00-OClock")
                            .SetDefinition("3:00-OClock"),
                        new ConceptDef()
                            .SetCode("4:00-OClock", "4:00-OClock")
                            .SetDefinition("4:00-OClock"),
                        new ConceptDef()
                            .SetCode("5:00-OClock", "5:00-OClock")
                            .SetDefinition("5:00-OClock"),
                        new ConceptDef()
                            .SetCode("6:00-OClock", "6:00-OClock")
                            .SetDefinition("6:00-OClock"),
                        new ConceptDef()
                            .SetCode("7:00-OClock", "7:00-OClock")
                            .SetDefinition("7:00-OClock"),
                        new ConceptDef()
                            .SetCode("8:00-OClock", "8:00-OClock")
                            .SetDefinition("8:00-OClock"),
                        new ConceptDef()
                            .SetCode("9:00-OClock", "9:00-OClock")
                            .SetDefinition("9:00-OClock"),
                        new ConceptDef()
                            .SetCode("10:00-OClock", "10:00-OClock")
                            .SetDefinition("10:00-OClock"),
                        new ConceptDef()
                            .SetCode("11:00-OClock", "11:00-OClock")
                            .SetDefinition("11:00-OClock"),
                         })
                     );

        CSTaskVar BreastLocationDepthCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                         "BreastLocationDepthCS",
                         "Breast Location Depth CodeSystem",
                         "Breast Location/Depth CodeSystem",
                         "Breast body location depth code system.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                        new ConceptDef()
                            .SetCode("Anterior", "Anterior depth")
                            .SetDefinition("Anterior depth"),
                        new ConceptDef()
                            .SetCode("Middle", "Middle depth")
                            .SetDefinition("Middle depth"),
                        new ConceptDef()
                            .SetCode("Posterior", "Posterior depth")
                            .SetDefinition("Posterior depth")
                         })
             );

        VSTaskVar BreastLocationRegionVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "BreastLocationRegionVS",
                        "Breast Location Region ValueSet",
                        "Breast Location/Region ValueSet",
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
                        "Breast Location/Clock ValueSet",
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
                        "Breast Location/Depth ValueSet",
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
                        "Breast Location/Quadrant ValueSet",
                        "Breast body location quadrant code system value set.",
                        Group_CommonCodesVS,
                        Self.BreastLocationQuadrantCS.Value()
                )
            );

        //$ Fix: complex extension is wrong - subslices are not identified.
        public SDTaskVar BreastBodyLocationExtension = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e;
                ElementTreeNode extensionNode;

                e = Self.CreateEditor("BreastBodyLocationExtension",
                    "Breast Body Location Extension",
                    "Breast Body Loc.",
                    Global.ExtensionUrl,
                    $"{Group_ExtensionResources}/BreastBodyLocation",
                    "Extension")
                    .Description("Breast Body Location extension",
                        new Markdown()
                            .Paragraph("this extension defines the fields that are used to describe the",
                                       "location of an observed item in a breast radiology report.")
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

                //Self.SliceAndBindUrl(e,
                //    extensionNode,
                //    "laterality",
                //    "http://hl7.org/fhir/ValueSet/bodysite-laterality",
                //    "Laterality of the body location",
                //    new Markdown().Paragraph("The laterality of the body location."),
                //    out ElementTreeSlice extensionSlice,
                //    out ElementTreeNode valueXNode
                //    );
                //extensionSlice.ElementDefinition.Single();
                {
                    ElementDefinition extensionDef = e.ApplyExtension(extensionNode,
                        "laterality",
                        "http://hl7.org/fhir/us/skinwoundassessment/StructureDefinition/BodySideExt")
                        .ElementDefinition
                            .Single()
                            .SetDefinition(new Markdown().Paragraph("The laterality of the body location."))
                        ;

                    //$ This is the build site url. Fix this when bodysite gets published.
                    e.AddExtensionLink("https://build.fhir.org/ig/HL7/fhir-skin-wound-ig/branches/master/StructureDefinition-BodySideExt.html",
                        new SDefEditor.Cardinality(extensionDef),
                        "Laterality", 
                        Global.ElementAnchor(extensionDef), false);
                }
                {
                    ValueSet binding = Self.BreastLocationQuadrantVS.Value();

                    {
                        IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                        valueSetIntroDoc
                            .ReviewedStatus("NOONE", "")
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        Self.fc?.Mark(outputPath);
                    }

                    ElementDefinition sliceDef = Self.SliceAndBindVS(e,
                        extensionNode,
                        "quadrant",
                        binding,
                        "Quadrant of the body location",
                        new Markdown().Paragraph("The quadrant  of the body location."))
                        .Single()
                       ;

                    e.AddComponentLink("Quadrant",
                        new SDefEditor.Cardinality(sliceDef),
                        Global.ElementAnchor(sliceDef),
                        "CodeableConcept",
                        binding.Url);
                }

                {
                    ValueSet binding = Self.BreastLocationRegionVS.Value();

                    {
                        IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                        valueSetIntroDoc
                            .ReviewedStatus("NOONE", "")
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        Self.fc?.Mark(outputPath);
                    }

                    ElementDefinition sliceDef = Self.SliceAndBindVS(e,
                        extensionNode,
                        "region",
                        binding,
                        "Region of the body location",
                        new Markdown().Paragraph("The region  of the body location."))
                        .ZeroToMany()
                    ;

                    e.AddComponentLink("Region",
                        new SDefEditor.Cardinality(sliceDef),
                        Global.ElementAnchor(extensionNode.ElementDefinition),
                        "CodeableConcept",
                        binding.Url);
                }

                {
                    ValueSet binding = Self.BreastLocationClockVS.Value();

                    {
                        IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                        valueSetIntroDoc
                            .ReviewedStatus("NOONE", "")
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        Self.fc?.Mark(outputPath);
                    }

                    ElementDefinition sliceDef = Self.SliceAndBindVS(e,
                        extensionNode,
                        "clockDirection",
                        binding,
                        "Clock direction of the body location",
                        new Markdown().Paragraph("The clock direction of the body location."))
                        .Single()
                        ;

                    e.AddComponentLink("ClockDirection",
                        new SDefEditor.Cardinality(sliceDef),
                        Global.ElementAnchor(extensionNode.ElementDefinition),
                        "CodeableConcept",
                        binding.Url);
                }

                {
                    ValueSet binding = Self.BreastLocationDepthVS.Value();
                    {
                        IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                        valueSetIntroDoc
                            .ReviewedStatus("NOONE", "")
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        Self.fc?.Mark(outputPath);
                    }

                    ElementDefinition sliceDef = Self.SliceAndBindVS(e,
                        extensionNode,
                        "depth",
                        binding,
                        "Depth of the body location",
                        new Markdown().Paragraph("The depth of the body location."))
                        .Single()
                        ;

                    e.AddComponentLink("Depth",
                        new SDefEditor.Cardinality(sliceDef),
                        Global.ElementAnchor(extensionNode.ElementDefinition),
                        "CodeableConcept",
                        binding.Url);
                }
                {
                    StructureDefinition extensionStructDef = Self.BodyDistanceFromExtension.Value();
                    ElementTreeSlice extensionSlice = e.ApplyExtension("distanceFromNipple", extensionStructDef, true);
                    extensionSlice.ElementDefinition.ZeroToOne();
                    e.AddExtensionLink(extensionStructDef.Url,
                        new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                        "Distance From Nipple",
                        Global.ElementAnchor(extensionSlice.ElementDefinition),
                        false);
                }
                {
                    StructureDefinition extensionStructDef = Self.BodyDistanceFromExtension.Value();
                    ElementTreeSlice extensionSlice = e.ApplyExtension("distanceFromChestWall", extensionStructDef, true);
                    extensionSlice.ElementDefinition.ZeroToOne();
                    e.AddExtensionLink(extensionStructDef.Url,
                        new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                        "Distance From Chest Wall", 
                        Global.ElementAnchor(extensionSlice.ElementDefinition), false);
                }
                {
                    StructureDefinition extensionStructDef = Self.BodyDistanceFromExtension.Value();
                    ElementTreeSlice extensionSlice = e.ApplyExtension("distanceFromSkin", extensionStructDef, true);
                    extensionSlice.ElementDefinition.ZeroToOne();
                    e.AddExtensionLink(extensionStructDef.Url,
                        new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                        "Distance From Skin", 
                        Global.ElementAnchor(extensionSlice.ElementDefinition),
                        false);
                }
                e.IntroDoc.ReviewedStatus("NOONE", "");
            });
    }
}
