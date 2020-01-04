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
       CSTaskVar CSMassType = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "MassTypeCS",
                        "Mass Type CodeSystem",
                        "Mass/Type/CodeSystem",
                        "Codes defining mass refinements.",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                        new ConceptDef("Solid",
                            "Solid Mass",
                            new Definition()
                               .Line("[PR]")
                               .Line("Solid Mass")
                            ),
                        new ConceptDef("PartiallySolid",
                            "Partially Solid Mass",
                            new Definition()
                               .Line("[PR]")
                               .Line("Partially Solid Mass")
                            ),
                        new ConceptDef("Skin",
                            "Skin Mass",
                            new Definition()
                               .Line("[PR]")
                               .Line("Skin Mass")
                            )
                        })
            );
    }
}
