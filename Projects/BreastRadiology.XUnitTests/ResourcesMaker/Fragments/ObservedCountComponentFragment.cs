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

                       e.SliceComponentSize(sliceName,
                           Self.CodeObservedSize.ToCodeableConcept(),
                           Self.UnitsOfLengthVS.Value(),
                           out ElementTreeSlice slice);

                       ElementDefinition sliceDef = slice.ElementDefinition
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

                       e.AddComponentLinkVS($"Observed Count",
                           new SDefEditor.Cardinality(slice.ElementDefinition),
                           Global.ElementAnchor(sliceDef), 
                           "Quantity or Range");
                   });
    }
}
