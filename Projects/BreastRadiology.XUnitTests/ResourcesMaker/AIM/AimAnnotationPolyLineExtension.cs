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
        SDTaskVar AimAnnotationPolyLineExtension = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("AimAnnotationPolyLineExtension",
                    "AIM Annotation PolyLine Extension",
                    "Annotation/PolyLine/Location",
                    ExtensionUrl,
                    $"{Group_AimResources}/AimAnnotationPolyLineExtension",
                    "Extension")
                    .Description("AIM Annotation PolyLine Extension",
                        new Markdown()
                            .Paragraph("this extension defines the fields that are used to describe a" +
                                       "polygon line annotation of an image")
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;

                s = e.SDef;
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Intro("#Add Content")
                    ;

                e.AddFragRef(Self.AimHeaderFragment.Value());

                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]")
                    .Zero()
                    ;

                ElementTreeNode extensionNode = e.ConfigureSliceByUrlDiscriminator("extension", true);

                void Extend(String name, String type)
                {
                    ElementTreeSlice slice = extensionNode.CreateSlice(name);
                    ElementDefinition valueDef = e.Clone("value[x]")
                        .Path($"{extensionNode.ElementDefinition.Path}.value[x]")
                        .ElementId($"{extensionNode.ElementDefinition.Path}:{name}.value[x]")
                        .Type(type)
                        .Single()
                        ;
                    slice.CreateNode(valueDef);
                }

                Extend("opacity", "string");
                Extend("style", "string");
                Extend("thickness", "string");
                Extend("color", "string");
                Extend("coordinates", "string");
            });
    }
}
