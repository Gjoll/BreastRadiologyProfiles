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
        String ComponentSliceCodesUrl => CodeSystemUrl("ComponentSliceCodes");

        Coding CodeAbnormalityCystType => new Coding(ComponentSliceCodesUrl, "abnormalityCystType");
        Coding CodeAbnormalityDuctType => new Coding(ComponentSliceCodesUrl, "abnormalityDuctType");
        Coding CodeAbnormalityFibroAdenomaType => new Coding(ComponentSliceCodesUrl, "mgAbnormalityFibroAdenomaType");
        Coding CodeAbnormalityForeignObjectType => new Coding(ComponentSliceCodesUrl, "abnormalityForeignObjectType");
        Coding CodeAbnormalityLymphNodeType => new Coding(ComponentSliceCodesUrl, "abnormalityLymphNodeType");
        Coding CodeAbnormalityMassType => new Coding(ComponentSliceCodesUrl, "abnormalityMassType");

        Coding CodeBiRads => new Coding(ComponentSliceCodesUrl, "targetBiRads");
        Coding CodeConsistentWithValue => new Coding(ComponentSliceCodesUrl, "consistentWithValue");
        Coding CodeConsistentWithQualifier => new Coding(ComponentSliceCodesUrl, "consistentWithQualifier");
        Coding CodeCorrespondsWith => new Coding(ComponentSliceCodesUrl, "correspondsWith");
        Coding CodeObservedChanges => new Coding(ComponentSliceCodesUrl, "observedChanges");
        Coding CodeMargin => new Coding(ComponentSliceCodesUrl, "margin");
        Coding CodeMGDensity => new Coding(ComponentSliceCodesUrl, "mgDensity");
        Coding CodeNotPreviouslySeen => new Coding(ComponentSliceCodesUrl, "notPreviouslySeen");
        Coding CodeObservedItemGroup => new Coding(ComponentSliceCodesUrl, "observedItemGroup");
        Coding CodeObservedGrouping => new Coding(ComponentSliceCodesUrl, "observedGrouping");
        Coding CodeObservedRegion => new Coding(ComponentSliceCodesUrl, "observedRegion");
        Coding CodeObservedCount => new Coding(ComponentSliceCodesUrl, "observedCount");
        Coding CodeObservedFeatureType => new Coding(ComponentSliceCodesUrl, "featureType");
        Coding CodeOrientation => new Coding(ComponentSliceCodesUrl, "orientation");
        Coding CodeShape => new Coding(ComponentSliceCodesUrl, "shape");
        Coding CodeTumorQualifier => new Coding(ComponentSliceCodesUrl, "tumorQualifier");

        Coding MGCodeAbnormalityAsymmetryType => new Coding(ComponentSliceCodesUrl, "mgAbnormalityAsymmetryType");
        Coding MGCodeAbnormalityDensityType => new Coding(ComponentSliceCodesUrl, "mgAbnormalityDensityType");

        Coding MGCodeCalcificationType => new Coding(ComponentSliceCodesUrl, "mgCalcificationType");
        Coding MGCodeCalcificationDistribution => new Coding(ComponentSliceCodesUrl, "mgCalcificationDistribution");

        CSTaskVar ComponentSliceCodesCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        "ComponentSliceCodes",
                        "Component Slice Codes CodeSystem",
                        "ComponentSliceCodes/ValueSet",
                        "Component Slice Codes code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            new ConceptDef(Self.CodeAbnormalityCystType,
                                new Definition()
                                    .Line("Slicing Component Code - AbnormalityCystType")
                                ),
                            new ConceptDef(Self.CodeAbnormalityDuctType,
                                new Definition()
                                    .Line("Slicing Component Code - CodeAbnormalityDuctType")
                                ),
                            new ConceptDef(Self.CodeAbnormalityFibroAdenomaType,
                                new Definition()
                                    .Line("Slicing Component Code - CodeAbnormalityFibroAdenomaType")
                                ),
                            new ConceptDef(Self.CodeAbnormalityForeignObjectType,
                                new Definition()
                                    .Line("Slicing Component Code - CodeAbnormalityForeignObjectType")
                                ),
                            new ConceptDef(Self.CodeAbnormalityLymphNodeType,
                                new Definition()
                                    .Line("Slicing Component Code - CodeAbnormalityLymphNodeType")
                                ),
                            new ConceptDef(Self.CodeAbnormalityMassType,
                                new Definition()
                                    .Line("Slicing Component Code - CodeAbnormalityMassType")
                                ),

                            new ConceptDef(Self.CodeBiRads,
                                new Definition()
                                    .Line("Slicing Component Code - BiRads")
                                ),
                            new ConceptDef(Self.CodeConsistentWithValue,
                                new Definition()
                                    .Line("Slicing Component Code - ConsistentWithValue")
                                ),
                            new ConceptDef(Self.CodeConsistentWithQualifier,
                                new Definition()
                                    .Line("Slicing Component Code - ConsistentWithQualifier")
                                ),
                            new ConceptDef(Self.CodeCorrespondsWith,
                                new Definition()
                                    .Line("Slicing Component Code - CorrespondsWith")
                                ),

                            new ConceptDef(Self.CodeMargin,
                                new Definition()
                                    .Line("Slicing Component Code - Margin")
                                ),
                            new ConceptDef(Self.CodeMGDensity,
                                new Definition()
                                    .Line("Slicing Component Code - MGDensity")
                                ),
                            new ConceptDef(Self.CodeNotPreviouslySeen,
                                new Definition()
                                    .Line("Slicing Component Code - Not Previously Seen")
                                ),
                            new ConceptDef(Self.CodeObservedChanges,
                                new Definition()
                                    .Line("Slicing Component Code - Observed Changes")
                                ),
                            new ConceptDef(Self.CodeObservedItemGroup,
                                new Definition()
                                    .Line("Slicing Component Code - ObservedItemGroup")
                                ),
                            new ConceptDef(Self.CodeObservedGrouping,
                                new Definition()
                                    .Line("Slicing Component Code - ObservedGrouping")
                                ),
                            new ConceptDef(Self.CodeObservedRegion,
                                new Definition()
                                    .Line("Slicing Component Code - ObservedArea")
                                ),
                            new ConceptDef(Self.CodeObservedCount,
                                new Definition()
                                    .Line("Slicing Component Code - ObservedCount")
                                ),
                            new ConceptDef(Self.CodeObservedFeatureType,
                                new Definition()
                                    .Line("Slicing Component Code - ObservedFeatureType")
                                ),

                            new ConceptDef(Self.CodeOrientation,
                                new Definition()
                                    .Line("Slicing Component Code - Orientation")
                                ),
                            new ConceptDef(Self.CodeShape,
                                new Definition()
                                    .Line("Slicing Component Code - Shape")
                                ),

                            new ConceptDef(Self.CodeTumorQualifier,
                                new Definition()
                                    .Line("Slicing Component Code - TumorQualifier")
                                ),


                            new ConceptDef(Self.MGCodeAbnormalityAsymmetryType,
                                new Definition()
                                    .Line("Slicing Component Code - MGCodeAbnormalityAsymmetryType")
                                ),
                            new ConceptDef(Self.MGCodeAbnormalityDensityType,
                                new Definition()
                                    .Line("Slicing Component Code - MGCodeAbnormalityDensityType")
                                ),

                            new ConceptDef(Self.MGCodeCalcificationType,
                                new Definition()
                                    .Line("Slicing Component Code - MGCalcificationType")
                                ),
                            new ConceptDef(Self.MGCodeCalcificationDistribution,
                                new Definition()
                                    .Line("Slicing Component Code - MGCalcificationDistribution")
                                ),
                       })
             );
    }
}
