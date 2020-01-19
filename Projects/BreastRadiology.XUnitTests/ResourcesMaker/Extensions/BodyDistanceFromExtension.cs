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
            (out StructureDefinition  s) =>
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

                    ElementDefinition valueBase = e.Get("value[x]").ElementDefinition;
                    ElementDefinition elementValue = new ElementDefinition()
                        .Path($"{extensionNode.ElementDefinition.Path}.value[x]")
                        .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}.value[x]")
                        ;

                    ElementDefinition elementUrl = new ElementDefinition()
                        .Path($"{extensionNode.ElementDefinition.Path}.url")
                        .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}.url")
                        .Value(new FhirUrl(sliceName))
                        ;
                    return extensionElement.CreateNode(elementValue);
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
                    ElementDefinition elementValue = Slice("landMark",
                            "Body landmark. Origin of distance measurement.",
                            new Markdown()
                            .Paragraph("Body landmark which defines the origin of the measurement")
                            .Paragraph("Currently the value set this is bound to does not contain the requiored breast landmarks like nipple.")
                            )
                        .ElementDefinition
                        .Binding("http://hl7.org/fhir/ValueSet/body-site", BindingStrength.Extensible)
                        ;

                    elementValue
                        .Type("CodeableConcept")
                        .Single()
                        ;
                }

                {
                    String sliceName = "distanceFromLandMark";

                    ElementTreeNode sliceNode = Slice(sliceName,
                        "Distance from landmark",
                        new Markdown("Distance from body landmark to body location"));

                    sliceNode.ElementDefinition
                        .Type("Quantity")
                        .Single()
                        .Pattern(
                            new Quantity
                            {
                                System = "http://unitsofmeasure.org",
                                Code = "cm"
                            })
                        ;
                    ElementDefinition quantityCode = new ElementDefinition()
                        .Path($"{extensionNode.ElementDefinition.Path}.value[x].code")
                        .ElementId($"{extensionNode.ElementDefinition.Path}:{sliceName}.value[x].code")
                        .Type("uri")
                        .Single()
                        .Binding("http://hl7.org/fhir/us/breast-radiology/ValueSet/UnitsOfLengthVS",
                                BindingStrength.Required)
                        ;
                    sliceNode.DefaultSlice.CreateNode(quantityCode);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
            });
    }
}
