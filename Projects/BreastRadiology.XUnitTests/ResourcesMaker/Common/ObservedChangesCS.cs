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
    partial class ResourcesMaker : ConverterBase
    {
        CSTaskVar ObservedChangesCS = new CSTaskVar(
              (out CodeSystem cs) =>
                  cs = Self.CreateCodeSystem(
                      "ObservedChangesCS",
                      "Observed Changes CodeSystem",
                      "Observed/Change/CodeSystem",
                      "Observed changes in an abnormality code system.",
                      Group_CommonCodesCS,
                      new ConceptDef[]
                      {
                         //+ Codes
                         //- Codes
                      }));

        VSTaskVar ObservedChangesVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "ObservedChangesVS",
                    "Observed Changes ValueSet",
                    "Observed/Change/ValueSet",
                    "Observed changes in an abnormality value set.",
                    Group_CommonCodesVS,
                    Self.ObservedChangesCS.Value()
                    )
            );
    }
}
