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
        async CSTask CommonCSShape()
        {
            if (this.commonCSShape == null)
                this.commonCSShape = await this.CreateCommonCSShape();
            return this.commonCSShape;
        }
        CodeSystem commonCSShape = null;

        async CSTask CreateCommonCSShape()
        {
            return await this.CreateCodeSystem(
                    "Shape",
                    "Shape",
                    "Shape/Values",
                    "Codes defining shape values.",
                    Group_CommonCodes,
                    new ConceptDef[]
                    {
                        new ConceptDef("Irregular",
                            "Irregular Shape",
                            new Definition()
                            .CiteStart()
                                .Line("The shape is neither round nor oval.")
                                .Line("For mammography, use of this descriptor usually implies a suspicious finding.")
                            .CiteEnd(BiRadCitation)
                            ),
                        new ConceptDef("Lobulated",
                            "Lobulated Shape",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("Oval",
                            "Elliptical/Egg-shaped",
                            new Definition()
                            .CiteStart()
                                .Line("Shape is elliptical or egg-shaped (may include 2 or 3 undulations, , i.e., \"gently lobulated\" or \"macrolobulated\").")
                            .CiteEnd(BiRadCitation)
                            ),
                        new ConceptDef("Reniform",
                            "Reniform Shape",
                            new Definition()
                                .Line("Penrad")
                            ),
                        new ConceptDef("Round",
                            "Round Shape",
                            new Definition()
                            .CiteStart()
                                .Line("A mass that is spherical, ball-shaped, circular, or globular in shape.")
                                .Line("A round mass has an anteroposterior diameter equal to its transverse diameter")
                                .Line("and to qualify as a ROUND mass, it must be circular in perpendicular projections.")
                                .Line("Breast masses with a ROUND shape are not commonly seen with breast ultrasound.")
                            .CiteEnd(BiRadCitation)
                            )
                    })
                ;
        }
    }
}
