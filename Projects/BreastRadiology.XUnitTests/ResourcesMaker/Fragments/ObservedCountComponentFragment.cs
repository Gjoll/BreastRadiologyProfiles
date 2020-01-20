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
        SDTaskVar ObservedCountComponentFragment = new SDTaskVar(
               (out StructureDefinition s) =>
                   {
                       const String sliceName = "observedCount";
                       SDefEditor e = Self.CreateFragment("ObservedCountFragment",
                               "ObservedCount Fragment",
                               "ObservedCount Fragment",
                               ObservationUrl)
                           .Description("Fragment that adds 'Observed Count' element to profile.",
                               new Markdown()
                           )
                           ;
                       s = e.SDef;

                       e.StartComponentSliceing();

                       ElementTreeSlice slice = e.AppendSlice("component", sliceName, 0, "1");
                       slice.ElementDefinition
                           .SetShort($"Observed Count component")
                           .SetDefinition(new Markdown()
                                .Paragraph($"This component slice contains the number of items observed.",
                                            $"This can be a quantity (i.e. 5), or a range (1 to 5).",
                                            $"If the lower bound of the range is set but not the upper bound, then it means {{lower bound}} or more.",
                                            $"If the lower bound of the range is not set but not the upper bound is, then it means {{upper bound}} or less."
                                            )
                                )
                           .SetComment(new Markdown($"This is one component of a group of components that comprise the observation."))
                           ;

                       // Fix component code
                       Self.FixComponentCode(slice, sliceName, Self.CodeObservedCount.ToCodeableConcept());
                       ElementTreeNode valueXNode = Self.FixComponentValueX(slice, sliceName, new string[] { "Quantity", "Range" });

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

                       e.AddComponentLink($"Observed Count",
                           new SDefEditor.Cardinality(slice.ElementDefinition),
                           Global.ComponentAnchor(sliceName), 
                           "Quantity or Range");
                   });
    }
}
