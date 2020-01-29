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
        SDTaskVar ObservedRegionComponentFragment = new SDTaskVar(
               (out StructureDefinition s) =>
                   {
                       const String sliceName = "observedRegion";
                       SDefEditor e = Self.CreateFragment("ObservedRegionFragment",
                               "ObservedRegion Fragment",
                               "ObservedRegion Fragment",
                               ObservationUrl)
                           .Description("Fragment that adds 'Observed Region' element to profile.",
                               new Markdown()
                           )
                           ;
                       s = e.SDef;

                       e.SliceComponentSize(sliceName,
                           Self.CodeObservedSize.ToCodeableConcept(),
                           Self.UnitsOfLengthVS.Value(),
                           out ElementTreeSlice slice);
                       ElementDefinition sliceDef = slice.ElementDefinition
                           .SetShort($"Observed Region component")
                           .SetDefinition(new Markdown()
                                .Paragraph("This component slice contains the spherical region of an item observed.",
                                            "If a region component is included in an observation, then what is being observed is not a single item,",
                                            "but some number of items contained in the region of the observation")
                                .Paragraph("The size is the diameter of the region.",
                                            "This can be a quantity (i.e. 5 cm region ), or a range (1 to 5 cm region).",
                                            "If the lower bound of the range is set but not the upper bound, then it means {lower bound} or more.",
                                            "If the lower bound of the range is not set but not the upper bound is, then it means {upper bound} or less."
                                            )
                                )
                           .SetComment(new Markdown()
                                    .Paragraph($"This is one component of a group of components that comprise the observation."))
                           ;

                       e.AddComponentLinkVS("Observed Region",
                            new SDefEditor.Cardinality(slice.ElementDefinition),
                           Global.ElementAnchor(sliceDef),
                           "Quantity or Range");
                   });
    }
}
