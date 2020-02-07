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
        const string CompositionSectionSliceCodesName = "CompositionSectionSliceCodes";
        String CompositionSectionSliceCodesUrl => this.CodeSystemUrl(CompositionSectionSliceCodesName);

        Coding SectionCodeReport => new Coding(this.CompositionSectionSliceCodesUrl, "sectionReport");
        Coding SectionCodeImpressions => new Coding(this.CompositionSectionSliceCodesUrl, "sectionImpressions");
        Coding SectionCodeRelatedResources => new Coding(this.CompositionSectionSliceCodesUrl, "sectionRelatedResources");
        Coding SectionCodeRecommendations => new Coding(this.CompositionSectionSliceCodesUrl, "sectionCodeRecommendations");
        Coding SectionCodeFindings => new Coding(this.CompositionSectionSliceCodesUrl, "sectionCodeFindings");

        CSTaskVar CompositionSectionSliceCodesCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        CompositionSectionSliceCodesName,
                        "Composition Section Slice Codes CodeSystem",
                        "Composition Section/Slice Codes/ValueSet",
                        "Composition Section Slice Codes code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            new ConceptDef()
                                .SetCode(Self.SectionCodeReport)
                                .SetDefinition("Slicing CompositionSection Code - Report")
                                ,
                            new ConceptDef()
                                .SetCode(Self.SectionCodeImpressions)
                                .SetDefinition("Slicing CompositionSection Code - Impressions")
                                ,
                            new ConceptDef()
                                .SetCode(Self.SectionCodeRelatedResources)
                                .SetDefinition("Slicing CompositionSection Code - Related Resources")
                                ,
                            new ConceptDef()
                                .SetCode(Self.SectionCodeRecommendations)
                                .SetDefinition("Slicing CompositionSection Code - Recommendations")
                                ,
                            new ConceptDef()
                                .SetCode(Self.SectionCodeFindings)
                                .SetDefinition("Slicing CompositionSection Code - Findings")
                                ,
                       })
             );
    }
}
