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
                       const String sliceName = "observedSize";
                       e.SliceComponentSize(sliceName,
                           Self.CodeObservedSize.ToCodeableConcept(),
                           Self.UnitsOfLengthVS.Value(),
                           out ElementTreeSlice slice);

                       ElementDefinition sliceDef = slice.ElementDefinition
                           .SetShort($"Observed Size component")
                           .SetDefinition(new Markdown()
                                               .Paragraph($"This component slice contains the observed size of an item in cemtimeters.",
                                                          $"This can be a quantity (i.e. 5 cm), or a range (1 cm to 5 cm).",
                                                          $"If the lower bound of the range is set but not the upper bound, then it means {{lower bound}} cm or more.",
                                                          $"If the lower bound of the range is not set but not the upper bound is, then it means {{upper bound}} cm or less."
                                           ))
                           .SetComment(new Markdown($"This is one component of a group of components that comprise the observation."))
                           ;

                       e.AddComponentLink($"Observed Size",
                           new SDefEditor.Cardinality(slice.ElementDefinition),
                           Global.ElementAnchor(sliceDef),
                           "Quantity or Range");
                   });
    }
}
