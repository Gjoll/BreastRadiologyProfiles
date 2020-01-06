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
        CSTaskVar ObservedChangeInSizeCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "ObservedChangeInSizeCS",
                     "Observed Changes In Size CodeSystem",
                     "Observed/Change/CodeSystem",
                     "Observed changes in the size of an abnormality over time code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                    new ConceptDef("IncreaseInSize",
                        "Increase In Size",
                        new Definition()
                            .Line("Item has increased in size")
                        ),
                    new ConceptDef("DecreaseInSize",
                        "Decrease In Size",
                        new Definition()
                            .Line("Item has decreased in size")
                        )
                     })
                 );


        VSTaskVar ObservedChangeInSizeVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ObservedChangeInSizeVS",
                    "Observed Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "Observed changes in the size of an abnormality over time value set.",
                    Group_CommonCodesVS,
                    Self.ObservedChangeInSizeCS.Value()
                    )
            );
    }
}
