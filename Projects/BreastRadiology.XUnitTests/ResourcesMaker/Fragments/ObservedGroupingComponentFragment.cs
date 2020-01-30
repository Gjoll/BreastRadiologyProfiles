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
        CSTaskVar ObservedGroupingCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "ObservedGroupingCS",
                     "Observed Grouping CodeSystem",
                     "Observed/Grouping/CodeSystem",
                     "Observed grouping of abnormalities code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                         new ConceptDef()
                             .SetCode("Multiple")
                             .SetDisplay("Multiple Items in Grouping")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Multiple Items in Grouping")
                             ),
                         new ConceptDef()
                             .SetCode("ClusterOf")
                             .SetDisplay("Cluster of Items in Grouping")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Cluster of Items in Grouping")
                             ),
                     }));

        VSTaskVar ObservedGroupingVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ObservedGroupingVS",
                    "Observed Grouping ValueSet",
                    "Observed/Grouping/ValueSet",
                    "Observed Grouping of abnormalities value set.",
                    Group_CommonCodesVS,
                    Self.ObservedGroupingCS.Value()
                    )
            );

        SDTaskVar ObservedGroupingComponentFragment = new SDTaskVar(
               (out StructureDefinition s) =>
               {
                   SDefEditor e = Self.CreateFragment("ObservedGroupingFragment",
                           "ObservedGrouping Fragment",
                           "ObservedGrouping Fragment",
                           ObservationUrl)
                       .Description("Fragment that adds 'Observed Grouping' element to profile.",
                           new Markdown()
                       )
                       ;
                   s = e.SDef;

                   e.StartComponentSliceing();

                   e.ComponentSliceCodeableConcept("observedGrouping",
                       Self.CodeObservedGrouping.ToCodeableConcept(),
                       Self.ObservedGroupingVS.Value(),
                       BindingStrength.Required,
                       0,
                       "1",
                       "Observed Grouping of Abnormalities",
                       new Markdown()
                                .Paragraph("This component slice contains the grouping of an item observed.",
                                            "If a grouping component is included in an observation, then what is being observed is a grouping of items")
                                .Paragraph("If an ObservedRegion component is included, then the grouping of a grouping of these areas.",
                                            "Otherwise the grouping is a grouping of the items observed.")
                       );
               });
    }
}
