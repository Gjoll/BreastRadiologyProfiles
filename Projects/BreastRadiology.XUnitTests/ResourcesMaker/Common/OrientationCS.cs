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
        CSTaskVar OrientationCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "OrientationCS",
                     "Orientation CodeSystem",
                     "Orientation CodeSystem",
                     "Orientation CodeSystem",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                         //+ Codes
                         //+ ParallelToSkin
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("ParallelToSkin")
                             .SetDisplay("Parallel to skin")
                             .SetDefinition("[PR] Parallel to skin")
                             .MammoId("1508")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                         //- AutoGen
                             .BiRadsDef("(historically, “wider-than-tall” or “horizontal”)",
                                 "The long axis of the mass parallels the skin line. Masses that are only slightly obiquely oriented",
                                 "might be considered parallel."),
                         //- ParallelToSkin
                         //+ PerpendicularToSkin(notParallel)
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("PerpendicularToSkin(notParallel)")
                             .SetDisplay("Perpendicular to skin (not parallel)")
                             .SetDefinition("[PR] Perpendicular to skin (not parallel)")
                             .MammoId("1509")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                         //- AutoGen
                             .BiRadsDef("(historically, \"isodense\")",
                                 "The long axis of the mass does not lie parallel to the skin line. The anterior–posterior or vertical",
                                 "dimension is greater than the transverse or horizontal dimension. These masses can also be",
                                 "obliquely oriented to the skin line. Round masses are NOT PARALLEL in their orientation.")
                         ,
                         //- PerpendicularToSkin(notParallel)
                         //+ TallerThanWide
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("TallerThanWide")
                             .SetDisplay("Taller than wide")
                             .SetDefinition("[PR] Taller than wide")
                             .MammoId("1518")
                             .ValidModalities(Modalities.MRI | Modalities.US)
                         //- AutoGen
                         ,
                         //- TallerThanWide
                         //+ WiderThanTall
                         //+ AutoGen
                         new ConceptDef()
                             .SetCode("WiderThanTall")
                             .SetDisplay("Wider than tall")
                             .SetDefinition("[PR] Wider than tall")
                             .MammoId("1517")
                             .ValidModalities(Modalities.MRI | Modalities.US)
                         //- AutoGen
                         
                         //- WiderThanTall
                         //- Codes
                     })
             );


        VSTaskVar OrientationVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "OrientationVS",
                        "Orientation ValueSet",
                        "Orientation ValueSet",
                        "Orientation ValueSet",
                        Group_CommonCodesVS,
                        Self.OrientationCS.Value()
                    )
            );
    }
}
