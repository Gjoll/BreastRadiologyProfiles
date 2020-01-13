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
        Coding CodeObservedChanges => new Coding(ComponentSliceCodesUrl, "observedChanges");
        Coding CodeMargin => new Coding(ComponentSliceCodesUrl, "margin");
        Coding CodeMGDensity => new Coding(ComponentSliceCodesUrl, "mgDensity");
        Coding CodeNotPreviouslySeen => new Coding(ComponentSliceCodesUrl, "notPreviouslySeen");
        Coding CodeObservedSize => new Coding(ComponentSliceCodesUrl, "observedSize");
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
                            new ConceptDef(Self.CodeAbnormalityCystType, "Slicing Component Code - AbnormalityCystType"),
                            new ConceptDef(Self.CodeAbnormalityDuctType, "Slicing Component Code - CodeAbnormalityDuctType"),
                            new ConceptDef(Self.CodeAbnormalityFibroAdenomaType, "Slicing Component Code - CodeAbnormalityFibroAdenomaType"),
                            new ConceptDef(Self.CodeAbnormalityForeignObjectType, "Slicing Component Code - CodeAbnormalityForeignObjectType"),
                            new ConceptDef(Self.CodeAbnormalityLymphNodeType, "Slicing Component Code - CodeAbnormalityLymphNodeType"),
                            new ConceptDef(Self.CodeAbnormalityMassType, "Slicing Component Code - CodeAbnormalityMassType"),

                            new ConceptDef(Self.CodeBiRads, "Slicing Component Code - BiRads"),
                            new ConceptDef(Self.CodeConsistentWithValue, "Slicing Component Code - ConsistentWithValue"),
                            new ConceptDef(Self.CodeConsistentWithQualifier, "Slicing Component Code - ConsistentWithQualifier"),

                            new ConceptDef(Self.CodeMargin, "Slicing Component Code - Margin"),
                            new ConceptDef(Self.CodeMGDensity, "Slicing Component Code - MGDensity"),
                            new ConceptDef(Self.CodeNotPreviouslySeen, "Slicing Component Code - Not Previously Seen"),
                            new ConceptDef(Self.CodeObservedChanges, "Slicing Component Code - Observed Changes"),
                            new ConceptDef(Self.CodeObservedSize, "Slicing Component Code - ObservedSize"),
                            new ConceptDef(Self.CodeObservedCount, "Slicing Component Code - ObservedCount"),
                            new ConceptDef(Self.CodeObservedFeatureType, "Slicing Component Code - ObservedFeatureType"),

                            new ConceptDef(Self.CodeOrientation, "Slicing Component Code - Orientation"),
                            new ConceptDef(Self.CodeShape, "Slicing Component Code - Shape"),

                            new ConceptDef(Self.CodeTumorQualifier, "Slicing Component Code - TumorQualifier"),


                            new ConceptDef(Self.MGCodeAbnormalityAsymmetryType, "Slicing Component Code - MGCodeAbnormalityAsymmetryType"),
                            new ConceptDef(Self.MGCodeAbnormalityDensityType, "Slicing Component Code - MGCodeAbnormalityDensityType"),

                            new ConceptDef(Self.MGCodeCalcificationType, "Slicing Component Code - MGCalcificationType"),
                            new ConceptDef(Self.MGCodeCalcificationDistribution, "Slicing Component Code - MGCalcificationDistribution"),
                       })
             );
    }
}
