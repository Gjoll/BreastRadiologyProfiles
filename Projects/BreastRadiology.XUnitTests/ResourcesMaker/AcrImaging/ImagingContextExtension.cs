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
        public SDTaskVar ImagingContextExtension = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e;
                ElementTreeNode extensionNode;

                e = Self.CreateEditor("ImagingContextExtension",
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
                        .Context()
                    ;
                s = e.SDef;

                e.AddFragRef(Self.HeaderFragment);

                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]").Zero();

                extensionNode = e.ConfigureSliceByUrlDiscriminator("extension", true);

                {
                    StructureDefinition extensionStructDef = Self.ImageStudyExtension.Value();
                    ElementDefinition extensionDef = e.ApplyExtension(extensionNode,
                        "studyUid",
                        extensionStructDef.Url)
                        .ElementDefinition
                        .ZeroToOne();

                    e.AddExtensionLink(extensionStructDef.Url,
                        new SDefEditor.Cardinality(extensionDef),
                        "Study Uid",
                        Global.ElementAnchor(extensionDef),
                        false);
                }

                //e.IntroDoc
                //    ;
            });
    }
}