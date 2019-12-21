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
        async CSTask CommonCSMargin()
        {
            if (this.commonCSMargin == null)
                this.commonCSMargin = await this.CreateCommonCSMargin();
            return this.commonCSMargin;
        }
        CodeSystem commonCSMargin = null;

        async CSTask CreateCommonCSMargin()
        {
            return await this.CreateCodeSystem(
                    "BreastRadMargin",
                    "Margin",
                    "Margin Values",
                    "Margin codes.",
                    Group_CommonCodes,
                    new ConceptDef[]
                    {
                    new ConceptDef("Angular",
                        "Not Circumscribed - Angular",
                        new Definition()
                        .CiteStart()
                            .Line("Some or all of the margin has sharp corners, often forming acute angles, but the significant")
                            .Line("feature is that the margin of the mass is NOT CIRCUMSCRIBED.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Circumscribed ",
                        "Circumscribed Margin",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, “well-defined” or “sharply-defined”)")
                            .Line("A circumscribed margin is one that is well defined, with an abrupt transition between the")
                            .Line("lesion and the surrounding tissue. For US, to describe a mass as circumscribed, its entire margin")
                            .Line("must be sharply defined. Most circumscribed lesions have round or oval shapes.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Indistinct",
                        "Indistinct Margin",
                        new Definition()
                        .CiteStart()
                            .Line("There is no clear demarcation of the entire margin or any portion of the margin from the")
                            .Line("surrounding tissue. The boundary is poorly defined, and the significant feature is that the")
                            .Line("mass is NOT CIRCUMSCRIBED. This is meant to include “echogenic rim” (historically, echogenic")
                            .Line("halo) because one may not be able to distinguish between an indistinct margin and")
                            .Line("one that displays an echogenic rim.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("IntraductalExtension",
                        "Intraductal Extension",
                        new Definition()
                            .Line("Penrad specific.")
                        ),
                    new ConceptDef("Irregular",
                        "Irregular Margin",
                        new Definition()
                            .Line("Penrad specific.")
                        ),
                    new ConceptDef("Lobulated",
                        "Lobulated Margin",
                        new Definition()
                            .Line("Penrad specific.")
                        ),
                    new ConceptDef("Macrolobulated",
                        "Microlobulated Margin",
                        new Definition()
                            .Line("Penrad specific.")
                        ),
                    new ConceptDef("Microlobulated",
                        "Not Circumscribed - Microlobulated",
                        new Definition()
                        .CiteStart()
                            .Line("The margin is characterized by short-cycle undulations, but the significant feature is that")
                            .Line("the margin of the mass is NOT CIRCUMSCRIBED.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("NonCircumscribed",
                        "Non Circumscribed Margin",
                        new Definition()
                        .CiteStart()
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Obscured",
                        "Obscured Margin",
                        new Definition()
                        .CiteStart()
                            .Line("A margin that is hidden by superimposed or adjacent fibroglandular tissue. This is used")
                            .Line("primarily when some of the margin of the mass is circumscribed, but the rest (more than 25%) is hidden.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Smooth",
                        "Smooth Margin",
                        new Definition()
                            .Line("Penrad specific.")
                        ),
                    new ConceptDef("Spiculated",
                        "Not Circumscribed - Spiculated",
                        new Definition()
                        .CiteStart()
                            .Line("The margin is characterized by sharp lines radiating from the mass, often a sign of malignancy,")
                            .Line("but the significant feature is that the margin of the mass is NOT CIRCUMSCRIBED.")
                        .CiteEnd(BiRadCitation)
                        )
                    });
                ;
        }
    }
}
