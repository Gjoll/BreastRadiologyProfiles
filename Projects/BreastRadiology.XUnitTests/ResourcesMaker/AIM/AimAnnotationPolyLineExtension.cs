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
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;


namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        async StringTask AimAnnotationPolyLineExtension()
        {
            if (this.aimAnnotationPolyLineExtension == null)
                await this.CreateAimAnnotationPolyLineExtension();
            return this.aimAnnotationPolyLineExtension;
        }
        String aimAnnotationPolyLineExtension = null;


        async VTask CreateAimAnnotationPolyLineExtension()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e;
                ElementDefGroup eGroup;
                ElementDefinition topExtension;

                e = this.CreateEditor("AimAnnotationPolyLineExtension",
                    "AIM Annotation PolyLine Extension",
                    "Annotation/PolyLine/Location",
                    ExtensionUrl,
                    $"{Group_AimResources}/AimAnnotationPolyLineExtension",
                    out this.aimAnnotationPolyLineExtension)
                    .Description("AIM Annotation PolyLine Extension",
                        new Markdown()
                            .Paragraph("this extension defines the fields that are used to describe a" +
                                       "polygon line annotation of an image")
                            .Todo(
                            )
                    )
                    .Kind(StructureDefinition.StructureDefinitionKind.ComplexType)
                    .Context()
                    ;

                e.AddFragRef(await this.AimHeaderFragment());

                e.Select("url")
                    .Type("uri")
                    .Fixed(new FhirUri(e.SDef.Url));

                e.Select("value[x]")
                    .Zero()
                    ;
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .Paragraph("AIM Annotation PolyGon extension resource")
                    .Paragraph("This extension defines a polygon line annotation to an image")
                    .Paragraph("It contains the following fields")
                    .List(
                        "opacity - this is the optical opacity of the line. What are its units and range???",
                        "color- this is the color of the line. What are its units and range???",
                        "style - this is the style of the line. What are its units and range???",
                        "thickness- this is the thicknedd of the line. What are its units and range???",
                        "coordinates- A series of points, each of which is an x,y point of the polygonal line. Each point is a string of the " +
                        "format \"{d},{d}\" where d is a fhir decimal string, and each point is seperated from the next by a space."
                    )
                    ;

                eGroup = e.Find("extension");
                topExtension = eGroup.ElementDefinition;
                topExtension.ConfigureSliceByUrlDiscriminator();

                void Extend(String name, String type)
                {
                    ElementDefinition points = e.Clone("extension");
                    points
                        .ElementId($"{topExtension.Path}:{name}")
                        .SliceName(name)
                        ;
                    ElementDefGroup pointsGroup = e.InsertAfter(eGroup, points);
                    ElementDefinition pointsValue = e.Clone("value[x]")
                        .Path($"{topExtension.Path}.value[x]")
                        .ElementId($"{topExtension.Path}:points.value[x]")
                        .Type(type)
                        .Single()
                        ;
                    pointsGroup.RelatedElements.Add(pointsValue);
                }

                Extend("opacity", "string");
                Extend("style", "string");
                Extend("thickness", "string");
                Extend("color", "string");
                Extend("coordinates", "string");
            });
        }
    }
}
