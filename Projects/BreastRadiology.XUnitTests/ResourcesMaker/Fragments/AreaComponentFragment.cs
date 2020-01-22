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
    partial class ResourcesMaker
    {
        SDTaskVar ObservedAreaComponentFragment = new SDTaskVar(
               (out StructureDefinition s) =>
                   {
                       const String sliceName = "observedArea";
                       SDefEditor e = Self.CreateFragment("ObservedAreaFragment",
                               "ObservedArea Fragment",
                               "ObservedArea Fragment",
                               ObservationUrl)
                           .Description("Fragment that adds 'Observed Area' element to profile.",
                               new Markdown()
                           )
                           ;
                       s = e.SDef;

                       e.StartComponentSliceing();

                       ElementTreeSlice slice = e.AppendSlice("component", sliceName, 0, "1");
                       slice.ElementDefinition
                           .SetShort($"Observed Area component")
                           .SetDefinition(new Markdown()
                                .Paragraph("This component slice contains the spherical area of an item observed.",
                                            "If an area component is included in an observation, then what is being observed is not a single item,",
                                            "but some number of items contained in the area of the observation")
                                .Paragraph("The size is the diameter of the area. The units are always cm.",
                                            "This can be a quantity (i.e. 5 cm area ), or a range (1 to 5 cm area).",
                                            "If the lower bound of the range is set but not the upper bound, then it means {lower bound} or more.",
                                            "If the lower bound of the range is not set but not the upper bound is, then it means {upper bound} or less."
                                            )
                                )
                           .SetComment(new Markdown($"This is one component of a group of components that comprise the observation."))
                           ;

                       // Fix component code
                       e.FixComponentCode(slice, sliceName, Self.CodeObservedArea.ToCodeableConcept());
                       ElementTreeNode valueXNode = e.FixComponentValueX(slice, sliceName, new string[] { "Quantity", "Range" });

                       {
                           Hl7.Fhir.Model.Quantity q = new Hl7.Fhir.Model.Quantity
                           {
                               System = "http://unitsofmeasure.org",
                               Code = "tot"
                           };

                           ElementDefinition valueX = new ElementDefinition
                           {
                               Path = $"{slice.ElementDefinition.Path}.value[x]",
                               ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:{sliceName}/quantity",
                               SliceName = $"{sliceName}/quantity",
                               Min = 0,
                               Max = "1"
                           }
                           .Pattern(q)
                           .Type("Quantity")
                           ;
                           valueXNode.CreateSlice($"{sliceName}/quantity", valueX);
                       }

                       {
                           Hl7.Fhir.Model.Range r = new Hl7.Fhir.Model.Range
                           {
                               Low = new SimpleQuantity
                               {
                                   System = "http://unitsofmeasure.org",
                                   Code = "tot"
                               },
                               High = new SimpleQuantity
                               {
                                   System = "http://unitsofmeasure.org",
                                   Code = "tot"
                               }
                           };
                           ElementDefinition valueX = new ElementDefinition
                           {
                               Path = $"{slice.ElementDefinition.Path}.value[x]",
                               ElementId = $"{slice.ElementDefinition.Path}:{sliceName}.value[x]:{sliceName}/range",
                               SliceName = $"{sliceName}/range",
                               Min = 0,
                               Max = "1"
                           }
                           .Pattern(r)
                           .Type("Range")
                           ;
                           valueXNode.CreateSlice($"{sliceName}/range", valueX);
                       }

                       e.AddComponentLink("Observed Area",
                            new SDefEditor.Cardinality(slice.ElementDefinition),
                           Global.ComponentAnchor(sliceName), 
                           "Quantity or Range");
                   });
    }
}
