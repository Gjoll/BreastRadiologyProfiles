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
        void SliceOid(SDefEditor e,
            ElementTreeNode extensionNode,
            String sliceName,
            String shortText,
            Markdown definition,
            out ElementTreeSlice extensionSlice,
            out ElementTreeNode valueXNode
        )
        {
            Self.Slice(e,
                extensionNode,
                sliceName,
                shortText,
                definition,
                out extensionSlice,
                out valueXNode
            );
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

        void ICStudyOid(SDefEditor e,
            ElementTreeNode extensionNode)
        {
            SliceOid(e,
                extensionNode,
                "studyUid",
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
        }

        void ICDerivedFrom(SDefEditor e,
                ElementTreeNode extensionNode)
        // derivedFrom
        {
            Self.Slice(e,
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

        void ICSeriesOid(SDefEditor e,
                ElementTreeNode extensionNode)
        {
            SliceOid(e,
                extensionNode,
                "seriesUid",
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
        }

        void ICInstance(SDefEditor e,
            ElementTreeNode parentExtensionNode)
        {
            ElementTreeNode extensionNode;
            {
                Self.Slice(e,
                    parentExtensionNode,
                    "imageInstance",
                    "Image Instance",
                    new Markdown()
                        .Paragraph("Specifies DICOM Instance")
                    ,
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );
                extensionSlice.ElementDefinition
                    .OneToMany()
                    ;
                valueXNode.ElementDefinition
                    .Type("code")
                    .Zero()
                    ;
                e.AddComponentLink("imageInstance",
                    new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                    null,
                    Global.ElementAnchor(extensionSlice.ElementDefinition),
                    "XXYYZ");
                extensionNode = extensionSlice.Nodes.GetItem("extension");
            }

            // Slice sopClass .
            {
                SliceOid(e,
                    parentExtensionNode,
                    "sopClass",
                    "Image Instance SopClass",
                    new Markdown()
                        .Paragraph("Image Instance SopClass"),
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );
                extensionSlice.ElementDefinition
                    .ZeroToOne()
                    ;
            }

            // Slice UID .
            {
                SliceOid(e,
                    parentExtensionNode,
                    "uid",
                    "Image Instance UID",
                    new Markdown()
                        .Paragraph("Image Instance UID"),
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );
                extensionSlice.ElementDefinition
                    .Single()
                    ;
            }

            // frameNumber
            {
                String sliceName = "frameNumber";
                Self.Slice(e,
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

                e.AddComponentLink(sliceName.ToMachineName(),
                    new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                    null,
                    Global.ElementAnchor(extensionSlice.ElementDefinition),
                    "Oid");
                extensionSlice.ElementDefinition
                    .Single()
                    ;
            }

            // Slice Observation UID .
            {
                SliceOid(e,
                    parentExtensionNode,
                    "observationUid",
                    "Image Instance Observation UID",
                    new Markdown()
                        .Paragraph("Image Instance Observation UID"),
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );
                extensionSlice.ElementDefinition
                    .ZeroToMany()
                    ;
            }

            // Slice Tracking UID .
            {
                SliceOid(e,
                    parentExtensionNode,
                    "trackingUid",
                    "Image Instance Tracking UID",
                    new Markdown()
                        .Paragraph("Image Instance Tracking UID"),
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode
                );
                extensionSlice.ElementDefinition
                    .ZeroToMany()
                    ;
            }

            // imageRegion
            //{
            //    StructureDefinition extensionStructDef = Self.ImageRegionExtension.Value();
            //    ElementDefinition extensionDef = e.ApplyExtension(extensionNode,
            //            "imageRegion",
            //            extensionStructDef.Url)
            //        .ElementDefinition
            //        .ZeroToOne();

            //    e.AddExtensionLink(extensionStructDef.Url,
            //        new SDefEditor.Cardinality(extensionDef),
            //        "Image Region",
            //        Global.ElementAnchor(extensionDef),
            //        false);
            //}
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

                Self.ICStudyOid(e, extensionNode);
                Self.ICDerivedFrom(e, extensionNode);
                Self.ICSeriesOid(e, extensionNode);

                // instance
                {
                    StructureDefinition extensionStructDef = Self.ImageInstanceExtension.Value();
                    ElementDefinition extensionDef = e.ApplyExtension(extensionNode,
                            "instance",
                            extensionStructDef.Url)
                        .ElementDefinition
                        .ZeroToMany();

                    e.AddExtensionLink(extensionStructDef.Url,
                        new SDefEditor.Cardinality(extensionDef),
                        "Instance",
                        Global.ElementAnchor(extensionDef),
                        false);
                }
                e.SDef.Snapshot = null;
                //e.IntroDoc
                //    ;
                Self.ImagingContextExample();
            });
    }
}