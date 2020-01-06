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

        CSTaskVar ObservedChangeInDefinitionCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "ObservedChangeInDefinitionCS",
                     "Observed Changes  CodeSystem",
                     "Observed/Change/CodeSystem",
                     "Observed changes in definition of an abnormality over time code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                    new ConceptDef("MoreDefined",
                        "More Defined",
                        new Definition()
                            .Line("Item is more defined")
                        ),
                    new ConceptDef("LessDefined",
                        "Less Defined",
                        new Definition()
                            .Line("Item is less defined")
                        )
                     })
                 );

        VSTaskVar ObservedChangeInDefinitionVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ObservedChangeInDefinitionVS",
                    "Observed Definition Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "Observed changes in definition of an abnormality over time value set.",
                    Group_CommonCodesVS,
                    Self.ObservedChangeInDefinitionCS.Value())
            );
    }
}
