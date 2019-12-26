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
       CSTaskVar CommonFibroadenomaCS = new CSTaskVar(
            () =>
                ResourcesMaker.Self.CreateCodeSystem(
                        "Fibroadenoma",
                        "Fibroadenoma",
                        "Fibroadenoma/CodeSystem",
                        "Codes defining Fibroadenoma values.",
                        Group_CommonCodes,
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
    }
}
