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
        CSTaskVar ObservedChangeInNumberCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "ObservedChangeInNumberCS",
                     "Observed Changes In Number CodeSystem",
                     "Observed/Change/CodeSystem",
                     "bserved changes in number of an abnormality over time code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                    new ConceptDef("IncrInNumber",
                        "Increased In Number",
                        new Definition()
                            .Line("Item(s) have increased in number")
                        ),
                    new ConceptDef("DecrInNumber",
                        "Decreased In Number",
                        new Definition()
                            .Line("Item(s) have decreased in number")
                        ),
                     })
                 );

        VSTaskVar ObservedChangeInNumberVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ObservedChangeInNumberVS",
                    "Observed Number Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "Observed changes in number of an abnormality over time value set.",
                    Group_CommonCodesVS,
                    Self.ObservedChangeInNumberCS.Value()
                    )
            );
    }
}
