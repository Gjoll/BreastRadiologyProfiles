using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
        const String imageInstanceSliceName = "imageInstance";

        void ICStudyUid(SDefEditor e,
            ElementTreeNode extensionNode)
        {
            const String sliceName = "studyUid";

            Self.SliceSimpleExtension(e,
                extensionNode,
                sliceName,
                "Study Uid",
                new Markdown()
                  .Paragraph("Specifies DICOM Study"),
                out ElementTreeSlice extensionSlice,
                out ElementTreeNode valueXNode
            );

            extensionSlice.ElementDefinition
                .Single()
                ;

            valueXNode.ElementDefinition
                .Type("oid")
                .Single()
                ;

            e.AddComponentLink(sliceName.ToMachineName(),
                new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                null,
                Global.ElementAnchor(extensionSlice.ElementDefinition),
                "Oid");
        }

        void ICDerivedFrom(SDefEditor e,
                ElementTreeNode extensionNode)
        // derivedFrom
        {
            Self.SliceSimpleExtension(e,
                extensionNode,
                "derivedFrom",
                "Image Study Derived From",
                new Markdown()
                    .Paragraph("Specifies DICOM Study that this is derived from")
                ,
                out ElementTreeSlice extensionSlice,
                out ElementTreeNode valueXNode
            );
            extensionSlice.ElementDefinition
                .ZeroToOne()
                ;

            String[] targets = new string[] { Global.ImagingStudyUrl };
            valueXNode.ElementDefinition
                .Type("Reference", null, targets)
                .Single();
            ;
            e.AddComponentLink("DerivedFrom",
                new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                null,
                Global.ElementAnchor(extensionSlice.ElementDefinition),
                "Reference");
        }

        void ICSeriesUid(SDefEditor e,
                ElementTreeNode extensionNode)
        {
            const String sliceName = "seriesUid";

            Self.SliceSimpleExtension(e,
                extensionNode,
                sliceName,
                "Series Uid",
                new Markdown()
                    .Paragraph("Specifies DICOM Series"),
                out ElementTreeSlice extensionSlice,
                out ElementTreeNode valueXNode
            );

            extensionSlice.ElementDefinition
                .Single()
                ;

            valueXNode.ElementDefinition
                .Type("oid")
                .Single()
                ;

            e.AddComponentLink(sliceName.ToMachineName(),
                new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                null,
                Global.ElementAnchor(extensionSlice.ElementDefinition),
                "Oid");
        }

        void ICInstance(SDefEditor e,
            ElementTreeNode parentExtensionNode)
        {

            ElementTreeNode extensionNode;
            {
                Self.SliceComplexExtension(e,
                    parentExtensionNode,
                    imageInstanceSliceName,
                    "Image Instance",
                    new Markdown()
                        .Paragraph("Specifies DICOM Instance"),
                    out ElementTreeSlice extensionSlice
                );
                extensionSlice.ElementDefinition
                    .ZeroToMany()
                    ;
                e.AddComponentLink(imageInstanceSliceName.ToMachineName(),
                    new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                    null,
                    Global.ElementAnchor(extensionSlice.ElementDefinition),
                    "Image Instance");
                extensionNode = extensionSlice.Nodes.GetItem("extension");
            }

            // Slice sopClass .
            {
                const String sliceName = "sopClass";

                Self.SliceSimpleExtension(e,
                    extensionNode,
                    sliceName,
                    "Image SOPClass",
                    new Markdown()
                        .Paragraph("Specifies DICOM Image SOPClass"),
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );

                extensionSlice.ElementDefinition
                    .ZeroToOne()
                    ;

                valueXNode.ElementDefinition
                    .Type("oid")
                    .Single()
                    ;

                e.AddComponentChildLink(sliceName.ToMachineName(),
                    imageInstanceSliceName,
                    new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                    null,
                    Global.ElementAnchor(extensionSlice.ElementDefinition),
                    "Oid");
            }

            // Slice UID .
            {
                const String sliceName = "imageUid";

                Self.SliceSimpleExtension(e,
                    extensionNode,
                    sliceName,
                    "Image Instance Uid",
                    new Markdown()
                        .Paragraph("Specifies DICOM Image Instance Uid"),
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );

                extensionSlice.ElementDefinition
                    .ZeroToOne()
                    ;

                valueXNode.ElementDefinition
                    .Type("oid")
                    .Single()
                    ;

                e.AddComponentChildLink(sliceName.ToMachineName(),
                    imageInstanceSliceName,
                    new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                    null,
                    Global.ElementAnchor(extensionSlice.ElementDefinition),
                    "Oid");
            }

            // frameNumber
            {
                String sliceName = "frameNumber";
                Self.SliceSimpleExtension(e,
                    parentExtensionNode,
                    sliceName,
                    "Image frame number",
                    new Markdown()
                        .Paragraph("Image frame number"),
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );
                extensionSlice.ElementDefinition
                    .ZeroToMany()
                    ;
                valueXNode.ElementDefinition
                    .Type("integer")
                    .Single()
                    ;

                e.AddComponentChildLink(sliceName.ToMachineName(),
                    imageInstanceSliceName,
                    new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                    null,
                    Global.ElementAnchor(extensionSlice.ElementDefinition),
                    "Oid");
            }

            // Slice Observation UID .
            {
                const String sliceName = "observationUid";

                Self.SliceSimpleExtension(e,
                    extensionNode,
                    sliceName,
                    "Image Instance Observation UID",
                    new Markdown()
                        .Paragraph("Image Instance Observation UID"),
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );

                extensionSlice.ElementDefinition
                    .ZeroToOne()
                    ;

                valueXNode.ElementDefinition
                    .Type("oid")
                    .Single()
                    ;

                e.AddComponentChildLink(sliceName.ToMachineName(),
                    imageInstanceSliceName,
                    new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                    null,
                    Global.ElementAnchor(extensionSlice.ElementDefinition),
                    "Oid");
            }

            // Slice Tracking UID .
            {
                const String sliceName = "trackingUid";

                Self.SliceSimpleExtension(e,
                    extensionNode,
                    sliceName,
                    "Image Instance Tracking UID",
                    new Markdown()
                        .Paragraph("Image Instance Tracking UID"),
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );

                extensionSlice.ElementDefinition
                    .ZeroToOne()
                    ;

                valueXNode.ElementDefinition
                    .Type("oid")
                    .Single()
                    ;

                e.AddComponentChildLink(sliceName.ToMachineName(),
                    imageInstanceSliceName,
                    new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                    null,
                    Global.ElementAnchor(extensionSlice.ElementDefinition),
                    "Oid");
            }

            //ICRegion(e, extensionNode);
        }

        void ICRegion(SDefEditor e,
            ElementTreeNode parentExtensionNode)
        {
            String imageRegionSliceName = "imageRegion";

            ElementTreeNode extensionNode;
            {
                Self.SliceSimpleExtension(e,
                    parentExtensionNode,
                    imageRegionSliceName,
                    "Image Region",
                    new Markdown()
                        .Paragraph("Specifies region in a DICOM image or frame")
                    ,
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );
                extensionSlice.ElementDefinition
                    .ZeroToOne()
                    ;
                valueXNode.ElementDefinition
                    .Type("code")
                    .Zero()
                    ;

                e.AddComponentChildLink(imageRegionSliceName.ToMachineName(),
                    imageInstanceSliceName,
                    new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                    null,
                    Global.ElementAnchor(extensionSlice.ElementDefinition),
                    "Image Region");
                extensionNode = extensionSlice.Nodes.GetItem("extension");
            }

            // Slice imageRegion .
            {
                const String sliceName = "regionType";

                ValueSet regionType = Self.GraphicTypeVS.Value();
                Self.SliceSimpleExtension(e,
                    extensionNode,
                    sliceName,
                    "Image Region Type",
                    new Markdown()
                        .Paragraph("Image Region Type."),
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );
                extensionSlice.ElementDefinition
                    .Single()
                    ;
                valueXNode.ElementDefinition
                    .Binding(regionType, BindingStrength.Extensible)
                    .Type("CodeableConcept")
                    .Single()
                    ;
                e.AddComponentChildLink(sliceName,
                    imageRegionSliceName,
                    new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                    null,
                    Global.ElementAnchor(extensionSlice.ElementDefinition),
                    "CodeableConcept",
                    regionType.Url);

            }

            // Slice coordinates.
            {
                Self.SliceSimpleExtension(e,
                    extensionNode,
                    "coordinates",
                    "Image Coordinates",
                    new Markdown()
                        .Paragraph("Image Coordinates.")
                        .Paragraph("String is a series of space separated points.")
                        .Paragraph("Each point is a comma separated sequence of decimal values",
                            "one for each dimension of the point.")
                        .Paragraph("Point may have two or three dimensions.")
                        .Paragraph("Each and every point in this string will have the same number of dimensions.")
                    ,
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );
                extensionSlice.ElementDefinition
                    .Single()
                    ;
                valueXNode.ElementDefinition
                    .Type("string")
                    .Single()
                    ;
                e.AddComponentChildLink("Coordinates",
                    imageRegionSliceName,
                    new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                    null,
                    Global.ElementAnchor(extensionSlice.ElementDefinition),
                    "string");
            }
        }

        public SDTaskVar ImagingContextExtension = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ElementDefinition CreateElement(ElementTreeSlice slice, String name)
                {
                    ElementDefinition e = new ElementDefinition
                    {
                        Path = $"{slice.ElementDefinition.Path}.{name}",
                        ElementId = $"{slice.ElementDefinition.ElementId}.{name}"
                    };

                    slice.CreateNode(e);
                    return e;
                }

                ElementTreeNode extensionNode;

                SDefEditor e = Self.CreateEditor("ImagingContextExtension",
                            "Image Region Extension",
                            "Imaging Context Extension",
                            Global.ExtensionUrl,
                            $"{ResourcesMaker.Group_AimResources}",
                            "Extension")
                        .Description("Imaging Context Extension",
                            new Markdown()
                                .Paragraph(
                                    "Imaging Reference context as an extension of DocumentReference"
                                )
                        )
                        .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                        .Context(StructureDefinition.ExtensionContextType.Element,
                            "DocumentReference")
                    ;
                s = e.SDef;

                e.AddFragRef(Self.HeaderFragment);

                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]")
                    .Zero()
                    .Type("code")
                    ;

                extensionNode = e.ConfigureSliceByUrlDiscriminator("extension", true);

                Self.ICStudyUid(e, extensionNode);
                Self.ICDerivedFrom(e, extensionNode);
                Self.ICSeriesUid(e, extensionNode);
                Self.ICInstance(e, extensionNode);

                e.SDef.Snapshot = null;
                //e.IntroDoc
                //    ;
                Self.ImagingContextExample();
            });
    }
}