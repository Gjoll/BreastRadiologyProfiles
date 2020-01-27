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
        public SDTaskVar TumorSatelliteExtension = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e;
                ElementTreeNode extensionNode;

                void Slice(String sliceName,
                    String shortText,
                    Markdown definition,
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode)
                {
                    extensionSlice = extensionNode.CreateSlice(sliceName);
                    extensionSlice.ElementDefinition
                        .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}")
                        .SliceName(sliceName)
                        .Short(shortText)
                        .Definition(definition)
                        .SetCardinality(0, "1")
                        ;
                    extensionSlice.ElementDefinition.Type = null;
                    extensionSlice.ElementDefinition.Type = null;

                    ElementDefinition sealExtension = new ElementDefinition
                    {
                        ElementId = $"{extensionNode.ElementDefinition.Path}:{sliceName}.extension",
                        Path = $"{extensionNode.ElementDefinition.Path}.extension"
                    };

                    sealExtension.Zero();
                    extensionSlice.CreateNode(sealExtension);
                    {
                        ElementDefinition elementUrl = new ElementDefinition()
                            .Path($"{extensionNode.ElementDefinition.Path}.url")
                            .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}.url")
                            .Value(new FhirUrl(sliceName))
                            .Type("uri")
                            ;
                        extensionSlice.CreateNode(elementUrl);
                    }
                    {
                        ElementDefinition valueBase = e.Get("value[x]").ElementDefinition;
                        ElementDefinition elementValue = new ElementDefinition()
                            .Path($"{extensionNode.ElementDefinition.Path}.value[x]")
                            .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}.value[x]")
                            ;
                        valueXNode = extensionSlice.CreateNode(elementValue);
                    }
                }

                e = Self.CreateEditor("TumorSatelliteExtension",
                    "Tumor Satellite Extension",
                    "Tumor Satellite/Extension",
                    ExtensionUrl,
                    $"{Group_ExtensionResources}/TumorSatelliteExtension",
                    "Extension")
                    .Description("Tumor Satellite Extension",
                        new Markdown()
                            .Paragraph("This extension identifies a tumour as a satellite of another tumour.",
                                "Optionally a reference to that tumor and the distance to that tumor may be defined.",
                                "The distance is defined by a quantity of metric distance units (cm, mm, etc)."
                                )
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

                // Slice index tumour reference.
                {
                    Slice("indexReference",
                        "Reference of index tumor",
                        new Markdown()
                            .Paragraph("Optional reference to index tumor (tumor that this is a satellite of).")
                            .Paragraph("Generally this should be a reference to a Breast Radiology Abnormality Observation resource"),
                        out ElementTreeSlice extensionSlice,
                        out ElementTreeNode valueXNode);

                    valueXNode.ElementDefinition
                        .Type("Reference", 
                        null,
                        new string[] { "Observation" })
                        .Single()
                        ;

                    e.AddComponentLinkVS("Index Reference",
                        new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                        Global.ElementAnchor(extensionSlice.ElementDefinition),
                        "Reference");
                }

                {
                    String sliceName = "distanceFromIndex";

                    Slice(sliceName,
                        "Distance from index tumor",
                        new Markdown("Distance from satellite tumor to index tumor"),
                    out ElementTreeSlice extensionSlice,
                    out ElementTreeNode valueXNode);

                    String binding = Self.UnitsOfLengthVS.Value().Url;
                    valueXNode.ElementDefinition
                        .Type("Quantity")
                        .Single()
                        .Binding(binding, BindingStrength.Required)
                        ;

                    e.AddComponentLinkVS("Distance From Index",
                        new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                        Global.ElementAnchor(extensionSlice.ElementDefinition),
                        "Quantity",
                        binding);
                }

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;
            });
    }
}
