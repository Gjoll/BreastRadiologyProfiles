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
                    new ConceptDef("ParallelToSkin",
                        "Parallel to skin",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, “wider-than-tall” or “horizontal”)")
                            .Line("The long axis of the mass parallels the skin line. Masses that are only slightly obiquely oriented")
                            .Line("might be considered parallel.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("PerpendicularToSkin",
                        "Perpendicular To Skin",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"isodense\")")
                            .Line("The long axis of the mass does not lie parallel to the skin line. The anterior–posterior or vertical")
                            .Line("dimension is greater than the transverse or horizontal dimension. These masses can also be")
                            .Line("obliquely oriented to the skin line. Round masses are NOT PARALLEL in their orientation.")
                        .CiteEnd(BiRadCitation)
                        )
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
