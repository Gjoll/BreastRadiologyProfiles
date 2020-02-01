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
        String ObservationComponentSliceCodesUrl => CodeSystemUrl("ObservationComponentSliceCodesUrl");

        Coding CodeAbnormalityCystType => new Coding(ObservationComponentSliceCodesUrl, "abnormalityCystType");
        Coding CodeAbnormalityDuctType => new Coding(ObservationComponentSliceCodesUrl, "abnormalityDuctType");
        Coding CodeAbnormalityFibroAdenomaType => new Coding(ObservationComponentSliceCodesUrl, "mgAbnormalityFibroAdenomaType");
        Coding CodeAbnormalityForeignObjectType => new Coding(ObservationComponentSliceCodesUrl, "abnormalityForeignObjectType");
        Coding CodeAbnormalityLymphNodeType => new Coding(ObservationComponentSliceCodesUrl, "abnormalityLymphNodeType");
        Coding CodeAbnormalityMassType => new Coding(ObservationComponentSliceCodesUrl, "abnormalityMassType");

        Coding CodeBiRads => new Coding(ObservationComponentSliceCodesUrl, "targetBiRads");
        Coding CodeConsistentWithValue => new Coding(ObservationComponentSliceCodesUrl, "consistentWithValue");
        Coding CodeConsistentWithQualifier => new Coding(ObservationComponentSliceCodesUrl, "consistentWithQualifier");
        Coding CodeCorrespondsWith => new Coding(ObservationComponentSliceCodesUrl, "correspondsWith");
        Coding CodeObservedChanges => new Coding(ObservationComponentSliceCodesUrl, "observedChanges");
        Coding CodeMargin => new Coding(ObservationComponentSliceCodesUrl, "margin");
        Coding CodeMGDensity => new Coding(ObservationComponentSliceCodesUrl, "mgDensity");
        Coding CodeNotPreviouslySeen => new Coding(ObservationComponentSliceCodesUrl, "notPreviouslySeen");
        Coding CodeObservedItemGroup => new Coding(ObservationComponentSliceCodesUrl, "observedItemGroup");
        Coding CodeObservedItemRegion => new Coding(ObservationComponentSliceCodesUrl, "observedItemRegion");
        Coding CodeObservedCount => new Coding(ObservationComponentSliceCodesUrl, "observedCount");
        Coding CodeObservedFeatureType => new Coding(ObservationComponentSliceCodesUrl, "featureType");
        Coding CodeOrientation => new Coding(ObservationComponentSliceCodesUrl, "orientation");
        Coding CodeShape => new Coding(ObservationComponentSliceCodesUrl, "shape");
        Coding MGCodeAbnormalityAsymmetryType => new Coding(ObservationComponentSliceCodesUrl, "mgAbnormalityAsymmetryType");
        Coding MGCodeAbnormalityDensityType => new Coding(ObservationComponentSliceCodesUrl, "mgAbnormalityDensityType");

        Coding MGCodeCalcificationType => new Coding(ObservationComponentSliceCodesUrl, "mgCalcificationType");
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
                            new ConceptDef(Self.CodeObservedItemRegion,
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
