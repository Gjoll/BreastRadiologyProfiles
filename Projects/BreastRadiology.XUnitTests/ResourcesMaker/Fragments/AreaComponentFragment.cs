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

                       e.SliceComponentSize(sliceName,
                           Self.CodeObservedSize.ToCodeableConcept(),
                           out ElementTreeSlice slice);
                       ElementDefinition sliceDef = slice.ElementDefinition
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

                       e.AddComponentLink("Observed Area",
                            new SDefEditor.Cardinality(slice.ElementDefinition),
                           Global.ElementAnchor(sliceDef),
                           "Quantity or Range");
                   });
    }
}
