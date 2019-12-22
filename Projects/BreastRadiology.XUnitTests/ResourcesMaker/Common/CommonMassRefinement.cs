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
using VTask = System.Threading.Tasks.Task;

namespace BreastRadiology.XUnitTests
{
    using CSTask = System.Threading.Tasks.Task<Hl7.Fhir.Model.CodeSystem>;

    partial class ResourcesMaker
    {
        async CSTask CommonCSMassRefinement()
        {
            if (this.commonMassRefinement == null)
                await this.CreateCommonMassRefinement();
            return this.commonMassRefinement;
        }
        CodeSystem commonMassRefinement = null;

        async VTask CreateCommonMassRefinement()
        {
            await VTask.Run(async () =>
            {
                this.commonMassRefinement = await this.CreateCodeSystem(
                        "CommonMassRefinement",
                        "Mass Refinement",
                        "Mass/Refinement/CodeSystem",
                        "Codes defining mass refinements.",
                        Group_CommonCodes,
                        new ConceptDef[]
                        {
                        new ConceptDef("Solid",
                            "Solid Mass",
                            new Definition()
                               .Line("Penrad.")
                               .Line("Solid Mass")
                            ),
                        new ConceptDef("PartiallySolid",
                            "Partially Solid Mass",
                            new Definition()
                               .Line("Penrad.")
                               .Line("Partially Solid Mass")
                            ),
                        new ConceptDef("Skin",
                            "Skin Mass",
                            new Definition()
                               .Line("Penrad.")
                               .Line("Skin Mass")
                            )
                        })
                    ;
            });
        }
    }
}
