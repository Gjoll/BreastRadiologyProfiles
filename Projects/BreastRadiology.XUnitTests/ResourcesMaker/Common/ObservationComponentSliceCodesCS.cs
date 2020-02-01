using Hl7.Fhir.Model;
using System;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        String ObservationComponentSliceCodesUrl => CodeSystemUrl("ObservationComponentSliceCodesUrl");

        Coding ComponentSliceCodeAbnormalityCystType => new Coding(ObservationComponentSliceCodesUrl, "abnormalityCystType");
        Coding ComponentSliceCodeAbnormalityDuctType => new Coding(ObservationComponentSliceCodesUrl, "abnormalityDuctType");
        Coding ComponentSliceCodeAbnormalityFibroAdenomaType => new Coding(ObservationComponentSliceCodesUrl, "mgAbnormalityFibroAdenomaType");
        Coding ComponentSliceCodeAbnormalityForeignObjectType => new Coding(ObservationComponentSliceCodesUrl, "abnormalityForeignObjectType");
        Coding ComponentSliceCodeAbnormalityLymphNodeType => new Coding(ObservationComponentSliceCodesUrl, "abnormalityLymphNodeType");
        Coding ComponentSliceCodeAbnormalityMassType => new Coding(ObservationComponentSliceCodesUrl, "abnormalityMassType");

        Coding ComponentSliceCodeBiRads => new Coding(ObservationComponentSliceCodesUrl, "targetBiRads");
        Coding ComponentSliceCodeConsistentWithValue => new Coding(ObservationComponentSliceCodesUrl, "consistentWithValue");
        Coding ComponentSliceCodeConsistentWithQualifier => new Coding(ObservationComponentSliceCodesUrl, "consistentWithQualifier");
        Coding ComponentSliceCodeCorrespondsWith => new Coding(ObservationComponentSliceCodesUrl, "correspondsWith");
        Coding ComponentSliceCodeObservedChanges => new Coding(ObservationComponentSliceCodesUrl, "observedChanges");
        Coding ComponentSliceCodeMargin => new Coding(ObservationComponentSliceCodesUrl, "margin");
        Coding ComponentSliceCodeMGDensity => new Coding(ObservationComponentSliceCodesUrl, "mgDensity");
        Coding ComponentSliceCodeNotPreviouslySeen => new Coding(ObservationComponentSliceCodesUrl, "notPreviouslySeen");
        Coding ComponentSliceCodeObservedCount => new Coding(ObservationComponentSliceCodesUrl, "observedCount");
        Coding ComponentSliceCodeObservedFeatureType => new Coding(ObservationComponentSliceCodesUrl, "featureType");
        Coding ComponentSliceCodeOrientation => new Coding(ObservationComponentSliceCodesUrl, "orientation");
        Coding ComponentSliceCodeShape => new Coding(ObservationComponentSliceCodesUrl, "shape");
        Coding MGComponentSliceCodeAbnormalityAsymmetryType => new Coding(ObservationComponentSliceCodesUrl, "mgAbnormalityAsymmetryType");
        Coding MGComponentSliceCodeAbnormalityDensityType => new Coding(ObservationComponentSliceCodesUrl, "mgAbnormalityDensityType");

        Coding MGComponentSliceCodeCalcificationType => new Coding(ObservationComponentSliceCodesUrl, "mgCalcificationType");
        Coding MGCodeCalcificationDistribution => new Coding(ObservationComponentSliceCodesUrl, "mgCalcificationDistribution");

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
                            new ConceptDef(Self.ComponentSliceCodeAbnormalityCystType,
                                new Definition()
                                    .Line("Slicing Component Code - AbnormalityCystType")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeAbnormalityDuctType,
                                new Definition()
                                    .Line("Slicing Component Code - CodeAbnormalityDuctType")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeAbnormalityFibroAdenomaType,
                                new Definition()
                                    .Line("Slicing Component Code - CodeAbnormalityFibroAdenomaType")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeAbnormalityForeignObjectType,
                                new Definition()
                                    .Line("Slicing Component Code - CodeAbnormalityForeignObjectType")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeAbnormalityLymphNodeType,
                                new Definition()
                                    .Line("Slicing Component Code - CodeAbnormalityLymphNodeType")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeAbnormalityMassType,
                                new Definition()
                                    .Line("Slicing Component Code - CodeAbnormalityMassType")
                                ),

                            new ConceptDef(Self.ComponentSliceCodeBiRads,
                                new Definition()
                                    .Line("Slicing Component Code - BiRads")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeConsistentWithValue,
                                new Definition()
                                    .Line("Slicing Component Code - ConsistentWithValue")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeConsistentWithQualifier,
                                new Definition()
                                    .Line("Slicing Component Code - ConsistentWithQualifier")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeCorrespondsWith,
                                new Definition()
                                    .Line("Slicing Component Code - CorrespondsWith")
                                ),

                            new ConceptDef(Self.ComponentSliceCodeMargin,
                                new Definition()
                                    .Line("Slicing Component Code - Margin")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeMGDensity,
                                new Definition()
                                    .Line("Slicing Component Code - MGDensity")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeNotPreviouslySeen,
                                new Definition()
                                    .Line("Slicing Component Code - Not Previously Seen")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeObservedChanges,
                                new Definition()
                                    .Line("Slicing Component Code - Observed Changes")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeObservedCount,
                                new Definition()
                                    .Line("Slicing Component Code - ObservedCount")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeObservedFeatureType,
                                new Definition()
                                    .Line("Slicing Component Code - ObservedFeatureType")
                                ),

                            new ConceptDef(Self.ComponentSliceCodeOrientation,
                                new Definition()
                                    .Line("Slicing Component Code - Orientation")
                                ),
                            new ConceptDef(Self.ComponentSliceCodeShape,
                                new Definition()
                                    .Line("Slicing Component Code - Shape")
                                ),

                            new ConceptDef(Self.MGComponentSliceCodeAbnormalityAsymmetryType,
                                new Definition()
                                    .Line("Slicing Component Code - MGCodeAbnormalityAsymmetryType")
                                ),
                            new ConceptDef(Self.MGComponentSliceCodeAbnormalityDensityType,
                                new Definition()
                                    .Line("Slicing Component Code - MGCodeAbnormalityDensityType")
                                ),

                            new ConceptDef(Self.MGComponentSliceCodeCalcificationType,
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
