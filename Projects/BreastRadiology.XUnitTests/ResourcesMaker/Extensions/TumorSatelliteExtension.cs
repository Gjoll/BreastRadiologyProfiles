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
                    {
                        ElementDefinition elementUrl = new ElementDefinition()
                            .Path($"{extensionNode.ElementDefinition.Path}.url")
                            .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}.url")
                            .Value(new FhirUrl(sliceName))
                            .Type("uri")
                            ;
                        extensionElement.CreateNode(elementUrl);
                    }
                    {
                        ElementDefinition valueBase = e.Get("value[x]").ElementDefinition;
                        ElementDefinition elementValue = new ElementDefinition()
                            .Path($"{extensionNode.ElementDefinition.Path}.value[x]")
                            .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}.value[x]")
                            ;
                        return extensionElement.CreateNode(elementValue);
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
                    ElementDefinition elementValue = Slice("indexReference",
                            "Reference of index tumor",
                            new Markdown()
                            .Paragraph("Optional reference to index tumor (tumor that this is a satellite of).")
                            )
                        .ElementDefinition
                        ;

                    elementValue
                        .Type("Reference")
                        .Single()
                        ;
                }

                {
                    String sliceName = "distanceFromIndex";

                    ElementTreeNode sliceNode = Slice(sliceName,
                        "Distance from index tumor",
                        new Markdown("Distance from satellite tumor to index tumor"));

                    sliceNode.ElementDefinition
                        .Type("Quantity")
                        .Single()
                        .Pattern(
                            new Quantity
                            {
                                System = "http://hl7.org/fhir/us/breast-radiology/ValueSet/UnitsOfLengthVS"
                            })
                        ;
                }

                e.IntroDoc
                    .ReviewedStatus("NOONE", "1.1.2020")
                    ;
            });
    }
}
