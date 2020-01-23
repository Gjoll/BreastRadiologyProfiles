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
        //$ Fix: complex extension is wrong - subslices are not identified.
        public SDTaskVar BodyDistanceFromExtension = new SDTaskVar(
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

                    {
                        ElementDefinition sealExtension = new ElementDefinition
                        {
                            ElementId = $"{extensionNode.ElementDefinition.Path}:{sliceName}.extension",
                            Path = $"{extensionNode.ElementDefinition.Path}.extension"
                        };

                        sealExtension.Zero();
                        extensionSlice.CreateNode(sealExtension);
                    }
                    {
                        ElementDefinition elementUrl = new ElementDefinition()
                        .Path($"{extensionNode.ElementDefinition.Path}.url")
                        .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}.url")
                        .Value(new FhirUrl(sliceName))
                        .Type("uri")
                        .Definition(new Markdown()
                            .Paragraph($"Url for {sliceName} complex extension item")
                            )
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

                e = Self.CreateEditor("BodyDistanceFromExtension",
                    "Body Distance From Extension",
                    "Body Dist. From",
                    ExtensionUrl,
                    $"{Group_ExtensionResources}/BreastBodyLocation",
                    "Extension")
                    .Description("Body Distance From extension",
                        new Markdown()
                            .Paragraph("This complex extension adds fields that form a distance measurement from a specified body landmark.",
                                "The body landmark is defined by a codeable concept",
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

                // Slice land mark.
                {
                    Slice("landMark",
                            "Body landmark. Origin of distance measurement.",
                            new Markdown()
                                .Paragraph("Body landmark which defines the origin of the measurement")
                                .Paragraph("Currently the value set this is bound to does not contain the requiored breast landmarks like nipple."),
                            out ElementTreeSlice extensionSlice,
                            out ElementTreeNode valueXNode
                     );

                    String binding = "http://hl7.org/fhir/ValueSet/body-site";
                    valueXNode.ElementDefinition
                        .Binding(binding, BindingStrength.Extensible)
                        .Type("CodeableConcept")
                        .Single()
                        ;
                    e.AddComponentLink("Land Mark",
                        new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                        Global.ElementAnchor(extensionSlice.ElementDefinition),
                        "CodeableConcept",
                        binding);
                }

                {
                    String sliceName = "distanceFromLandMark";

                    Slice(sliceName,
                        "Distance from landmark",
                        new Markdown("Distance from body landmark to body location"),
                            out ElementTreeSlice extensionSlice,
                            out ElementTreeNode valueXNode);

                    String binding = Self.UnitsOfLengthVS.Value().Url;
                    valueXNode.ElementDefinition
                        .Type("Quantity")
                        .Binding(binding, BindingStrength.Required)
                        .Single()
                        ;

                    e.AddComponentLink("Distance From LandMark",
                        new SDefEditor.Cardinality(extensionSlice.ElementDefinition),
                        Global.ElementAnchor(extensionSlice.ElementDefinition),
                        "Quantity",
                        binding);
                }

                e.IntroDoc
                    .ReviewedStatus("NOONE", "1.1.2020")
                    ;
            });
    }
}
