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
    using VTask = System.Threading.Tasks.Task;

    partial class ResourcesMaker
    {
        CSTaskVar CommonAbnormalityForeignObjectCS = new CSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateCodeSystem(
                        "CommonAbnormalities",
                        "Foreign Object",
                        "Foreign/Object/ValueSet",
                        "Foreign object codes defining types of foreign objects observed during a Breast Radiology exam",
                        Group_CommonCodes,
                        new ConceptDef[]
                        {
                        new ConceptDef("BB",
                            "BB",
                            new Definition()
                                .Line("A foreign object is identified as a BB")
                            ),
                        new ConceptDef("BiopsyClip",
                            "Biopsy Clip",
                            new Definition()
                                .Line("A foreign object is identified as a Biopsy Clip")
                            ),
                        new ConceptDef("BiopsyClipTitanium",
                            "Biopsy Clip Titanium",
                            new Definition()
                                .Line("A foreign object is identified as a Titanium Biopsy Clip")
                            ),
                        new ConceptDef("CatheterSleeve",
                            "Catheter Sleeve",
                            new Definition()
                                .Line("A foreign object is identified as a Catheter Sleeve")
                            ),
                        new ConceptDef("ChemotherapyPort",
                            "Chemotherapy Port",
                            new Definition()
                                .Line("A foreign object is identified as a Chemotherapy Port")
                            ),
                        new ConceptDef("Coil",
                            "Coil",
                            new Definition()
                                .Line("A foreign object is identified as a Coil")
                            ),
                        new ConceptDef("GunShotWound",
                            "Gun Shot Wound",
                            new Definition()
                                .Line("A foreign object is identified as a Gun Shot Wound")
                            ),
                        new ConceptDef("Metal",
                            "Metal",
                            new Definition()
                                .Line("A foreign object is identified as a Metal")
                            ),
                        new ConceptDef("MetallicObjects",
                            "Metallic Objects",
                            new Definition()
                                .Line("A foreign object is identified as a Metallic Objects")
                            ),
                        new ConceptDef("Needle",
                            "Needle",
                            new Definition()
                                .Line("A foreign object is identified as a Needle")
                            ),
                        new ConceptDef("NippleJewelery",
                            "Nipple Jewelery",
                            new Definition()
                                .Line("A foreign object is identified as a Nipple Jewelery")
                            ),
                        new ConceptDef("NonMetallicBody",
                            "Non Metallic Body",
                            new Definition()
                                .Line("A foreign object is identified as a Non Metallic Body")
                            ),
                        new ConceptDef("PaceMaker",
                            "Pace Maker",
                            new Definition()
                                .Line("A foreign object is identified as a Pace Maker")
                            ),
                        new ConceptDef("RadioactivePellet",
                            "Radioactive Pellet",
                            new Definition()
                                .Line("A foreign object is identified as a Radioactive Pellet")
                            ),
                        new ConceptDef("Sponge",
                            "Sponge",
                            new Definition()
                                .Line("A foreign object is identified as a Sponge")
                            ),
                        new ConceptDef("SurgicalClip",
                            "Surgical Clip",
                            new Definition()
                                .Line("A foreign object is identified as a Surgical Clip")
                            ),
                        new ConceptDef("Swab",
                            "Swab",
                            new Definition()
                                .Line("A foreign object is identified as a Swab")
                            ),
                        new ConceptDef("Wire",
                            "Wire",
                            new Definition()
                                .Line("A foreign object is identified as a Wire")
                            ),
                        new ConceptDef("WireFragment",
                            "Wire Fragment",
                            new Definition()
                                .Line("A foreign object is identified as a Wire Fragment")
                            )
                        })
            );
    }
}
