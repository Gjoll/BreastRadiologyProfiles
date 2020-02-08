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
                         new ConceptDef()
                             .SetCode("ParallelToSkin")
                             .SetDisplay("Parallel to skin")
                             .MammoId("1508")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                             .SetACR("(historically, \"wider-than-tall\" or \"horizontal\")The " +
                                 "long axis of the mass parallels the skin line. ",
                                 "Masses that are only slightly obiquely orientedmight " +
                                 "be considered parallel.")
                         ,
                         new ConceptDef()
                             .SetCode("PerpendicularToSkin(notParallel)")
                             .SetDisplay("Perpendicular to skin (not parallel)")
                             .MammoId("1509")
                             .ValidModalities(Modalities.MG | Modalities.MRI | Modalities.NM | Modalities.US)
                             .SetACR("(historically, \"isodense\")The long axis of the mass " +
                                 "does not lie parallel to the skin line. ",
                                 "The anterior–posterior or verticaldimension is greater " +
                                 "than the transverse or horizontal dimension. ",
                                 "These masses can also beobliquely oriented to the " +
                                 "skin line. ",
                                 "Round masses are NOT PARALLEL in their orientation.")
                         ,
                         new ConceptDef()
                             .SetCode("TallerThanWide")
                             .SetDisplay("Taller than wide")
                             .MammoId("1518")
                             .ValidModalities(Modalities.MRI | Modalities.US)
                         ,
                         new ConceptDef()
                             .SetCode("WiderThanTall")
                             .SetDisplay("Wider than tall")
                             .MammoId("1517")
                             .ValidModalities(Modalities.MRI | Modalities.US)
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
