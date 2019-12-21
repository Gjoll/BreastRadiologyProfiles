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
    using CSTask = System.Threading.Tasks.Task<Hl7.Fhir.Model.CodeSystem>;
    partial class ResourcesMaker
    {
        async CSTask CommonCSFibroadenoma()
        {
            if (this.commonCSFibroadenoma == null)
                await this.CreateCommonCSFibroadenoma();
            return this.commonCSFibroadenoma;
        }
        CodeSystem commonCSFibroadenoma = null;

        async CSTask CreateCommonCSFibroadenoma()
        {
            return await this.CreateCodeSystem(
                    "Fibroadenoma",
                    "Fibroadenoma",
                    "Fibroadenoma/Values",
                    "Codes defining Fibroadenoma values.",
                    Group_CommonCodes,
                    new ConceptDef[]
                    {
                        new ConceptDef("Normal",
                            "Normal",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("Degenerated",
                            "Degenerated",
                            new Definition()
                                .Line("Penrad")
                            )
                    })
                ;
        }
    }
}
