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

        CSTaskVar ObservedChangeInStateCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "ObservedChangeInStateCS",
                     "Observed Change In State CodeSystem",
                     "Observed/Change/CodeSystem",
                     "Observed changes in state of an abnormality over time code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                    new ConceptDef("New",
                        "New Observation",
                        new Definition()
                            .Line("This is the first time item has been observed")
                        ),
                    new ConceptDef("Stable",
                        "Stable",
                        new Definition()
                            .Line("Observation of item is stable")
                        ),
                    new ConceptDef("NotSigChanged",
                        "Not Significantly Changed",
                        new Definition()
                            .Line("Item observation has not significantly changed")
                        ),
                    new ConceptDef("NoLongerSeen",
                        "No Longer Seen",
                        new Definition()
                            .Line("Item is no longer visible")
                        ),
                    new ConceptDef("IncidentalFind",
                        "Incidental Find",
                        new Definition()
                            .Line("Item observation is an incidental find")
                        ),
                    new ConceptDef("RepresentsChange",
                        "Represents Change",
                        new Definition()
                            .Line("Unspecified change has occured in item")
                        ),
                     })
                 );


        VSTaskVar ObservedChangeInStateVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ObservedChangeInStateVS",
                    "Observed Change In State ValueSet",
                    "Observed/Change/ValueSet",
                    "Observed changes in state of an abnormality over time value set.",
                    Group_CommonCodesVS,
                    Self.ObservedChangeInStateCS.Value()
                    )
            );
    }
}
