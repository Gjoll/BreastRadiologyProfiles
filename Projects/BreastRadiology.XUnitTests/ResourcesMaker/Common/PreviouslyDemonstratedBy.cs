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
        VSTaskVar PreviouslyDemonstratedByVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "PreviouslyDemonstratedByVS",
                        "PreviouslyDemonstratedBy ValueSet",
                        "PreviouslyDemonstratedBy/ValueSet",
                        "PreviouslyDemonstratedBy value set.",
                        Group_CommonCodesVS,
                        Self.PreviouslyDemonstratedByCS.Value()
                    )
            );

        CSTaskVar PreviouslyDemonstratedByCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "PreviouslyDemonstratedByCodeSystemCS",
                        "Not Previously Seen CodeSystem",
                        "PreviouslyDemonstratedBy/CodeSystem",
                        "PreviouslyDemonstratedBy code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            //+ Codes
                            //- Codes
                        })
            );
    }
}
