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

        CSTaskVar ObservedChangeInProminanceCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "ObservedChangeInProminanceCS",
                     "Observed Changes In Prominance CodeSystem",
                     "Observed/Change/CodeSystem",
                     "Observed changes in Prominance of an abnormality over time code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                    new ConceptDef("MoreProminent",
                        "More Prominent",
                        new Definition()
                            .Line("Item is more Prominent")
                        ),
                    new ConceptDef("LessProminent",
                        "Less Prominent",
                        new Definition()
                            .Line("Item is less Prominent")
                        )
                     })
                 );

        VSTaskVar ObservedChangeInProminanceVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ObservedChangeInProminanceVS",
                    "Observed Prominance Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "Observed changes in Prominance of an abnormality over time value set.",
                    Group_CommonCodesVS,
                    Self.ObservedChangeInProminanceCS.Value()
                    )
            );
    }
}
