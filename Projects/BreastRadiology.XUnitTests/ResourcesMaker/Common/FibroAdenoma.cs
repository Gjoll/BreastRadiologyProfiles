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
       CSTaskVar FibroadenomaCS = new CSTaskVar(
            () =>
                Self.CreateCodeSystem(
                        "FibroadenomaCodeSystemCS",
                        "Fibroadenoma CodeSystem",
                        "Fibroadenoma/CodeSystem",
                        "Fibroadenoma values code system.",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            new ConceptDef("Normal",
                                "Normal",
                                new Definition()
                                    .Line("[PR]")
                                ),
                            new ConceptDef("Degenerated",
                                "Degenerated",
                                new Definition()
                                    .Line("[PR]")
                                )
                        })
                    );

        VSTaskVar FibroadenomaVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                        "FibroadenomaVS",
                        "Fibroadenoma ValueSet",
                        "FibroadenomaValueSet",
                        "Fibroadenoma values value set.",
                        Group_CommonCodesVS,
                        Self.FibroadenomaCS.Value()
                    )
            );
    }
}
