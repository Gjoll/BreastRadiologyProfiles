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
        SDTaskVar ObservedSizeComponentFragment = new SDTaskVar(
               (out StructureDefinition s) =>
                   {
                       SDefEditor e = Self.CreateFragment("ObservedSizeFragment",
                               "ObservedSize Fragment",
                               "ObservedSize Fragment",
                               ObservationUrl)
                           .Description("Fragment that adds 'Observed Size' element to profile.",
                               new Markdown()
                           )
                           ;
                       s = e.SDef;

                       e.StartComponentSliceing();

                       const String sliceName = "observedSize";

                       ElementTreeSlice slice = e.AppendSlice("component", sliceName, 0, "1");
                       slice.ElementDefinition
                           .SetShort($"Observed Size component")
                           .SetDefinition(new Markdown()
                                               .Paragraph($"This component slice contains the observed size of an item in cemtimeters.",
                                                          $"This can be a quantity (i.e. 5 cm), or a range (1 cm to 5 cm).",
                                                          $"If the lower bound of the range is set but not the upper bound, then it means {{lower bound}} cm or more.",
                                                          $"If the lower bound of the range is not set but not the upper bound is, then it means {{upper bound}} cm or less."
                                           ))
                           .SetComment(new Markdown($"This is one component of a group of components that comprise the observation."))
                           ;

                       // Fix component code
                       Self.FixComponentCode(slice, sliceName, Self.CodeObservedSize.ToCodeableConcept());
                       ElementTreeNode valueXNode = Self.FixComponentValueX(slice, sliceName, new string[] { "Quantity", "Range" });

                       {
                           Hl7.Fhir.Model.Quantity q = new Hl7.Fhir.Model.Quantity
                           {
                               System = "http://unitsofmeasure.org",
                               Code = "cm"
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
                                   Code = "cm"
                               },
                               High = new SimpleQuantity
                               {
                                   System = "http://unitsofmeasure.org",
                                   Code = "cm"
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

                       String componentRef = Global.ComponentAnchor(sliceName);
                       e.AddComponentLink($"Observed Size",
                           new SDefEditor.Cardinality(slice.ElementDefinition),
                           componentRef, 
                           "Quantity or Range");
                   });
    }
}
