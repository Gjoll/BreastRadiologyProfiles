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
                             .SetCode("MultipleRegions")
                             .SetDisplay("Multiple Observed Regions in Grouping")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Multiple Observed Regions in Grouping")
                             ),
                         new ConceptDef()
                             .SetCode("ClusterOfRegions")
                             .SetDisplay("Cluster of Observed Regions in Grouping")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Cluster of Observed Regions in Grouping")
                             ),
                         new ConceptDef()
                             .SetCode("MultipleItems")
                             .SetDisplay("Multiple Items in Grouping")
                             .SetDefinition(new Definition()
                                 .Line("[PR] Multiple Items in Grouping")
                             ),
                         new ConceptDef()
                             .SetCode("ClusterOfItems")
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
                       "*",
                       "Observed Grouping of Abnormalities regions or items",
                       new Markdown()
                                .Paragraph("This component slice contains the grouping of an item observed.",
                                            "The grouping component can describe a grouping of items and/or a grouping of regions.")
                       );
               });
    }
}
