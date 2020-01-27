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
        String CompositionSectionSliceCodesUrl => CodeSystemUrl("CompositionSectionSliceCodes");

        Coding SectionCodeReport => new Coding(CompositionSectionSliceCodesUrl, "report");

        CSTaskVar CompositionSectionSliceCodesCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        "CompositionSectionSliceCodes",
                        "Composition Section Slice Codes CodeSystem",
                        "Composition Section/Slice Codes/ValueSet",
                        "Composition Section Slice Codes code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            new ConceptDef(Self.SectionCodeReport,
                                new Definition()
                                    .Line("Slicing CompositionSection Code - SectionCodeReport")
                                ),
                       })
             );
    }
}
