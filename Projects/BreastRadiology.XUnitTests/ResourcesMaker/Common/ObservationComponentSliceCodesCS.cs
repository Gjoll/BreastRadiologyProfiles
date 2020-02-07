using Hl7.Fhir.Model;
using System;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker
    {
        const String ObservationComponentSliceCodesName = "ObservationComponentSliceCodes";

        String ObservationComponentSliceCodesUrl => this.CodeSystemUrl(ObservationComponentSliceCodesName);

        Coding ComponentSliceCodeAbnormalityCystType => new Coding(this.ObservationComponentSliceCodesUrl, "abnormalityCystType");
        Coding ComponentSliceCodeAbnormalityDuctType => new Coding(this.ObservationComponentSliceCodesUrl, "abnormalityDuctType");
        Coding ComponentSliceCodeAbnormalityFibroAdenomaType => new Coding(this.ObservationComponentSliceCodesUrl, "mgAbnormalityFibroAdenomaType");
        Coding ComponentSliceCodeAbnormalityForeignObjectType => new Coding(this.ObservationComponentSliceCodesUrl, "abnormalityForeignObjectType");
        Coding ComponentSliceCodeAbnormalityLymphNodeType => new Coding(this.ObservationComponentSliceCodesUrl, "abnormalityLymphNodeType");
        Coding ComponentSliceCodeAbnormalityMassType => new Coding(this.ObservationComponentSliceCodesUrl, "abnormalityMassType");

        Coding ComponentSliceCodeBiRads => new Coding(this.ObservationComponentSliceCodesUrl, "targetBiRads");
        Coding ComponentSliceCodeConsistentWithValue => new Coding(this.ObservationComponentSliceCodesUrl, "consistentWithValue");
        Coding ComponentSliceCodeConsistentWithQualifier => new Coding(this.ObservationComponentSliceCodesUrl, "consistentWithQualifier");
        Coding ComponentSliceCodeCorrespondsWith => new Coding(this.ObservationComponentSliceCodesUrl, "correspondsWith");
        Coding ComponentSliceCodeObservedChanges => new Coding(this.ObservationComponentSliceCodesUrl, "obsChanges");
        Coding ComponentSliceCodeMargin => new Coding(this.ObservationComponentSliceCodesUrl, "margin");
        Coding ComponentSliceCodeMGDensity => new Coding(this.ObservationComponentSliceCodesUrl, "mgDensity");
        Coding ComponentSliceCodeNotPreviouslySeen => new Coding(this.ObservationComponentSliceCodesUrl, "notPreviouslySeen");
        Coding ComponentSliceCodeObservedSize => new Coding(this.ObservationComponentSliceCodesUrl, "obsSize");
        Coding ComponentSliceCodeObservedDistribution => new Coding(this.ObservationComponentSliceCodesUrl, "obsDistribution");
        Coding ComponentSliceCodeObservedCount => new Coding(this.ObservationComponentSliceCodesUrl, "obsCount");
        Coding ComponentSliceCodeObservedFeatureType => new Coding(this.ObservationComponentSliceCodesUrl, "featureType");
        Coding ComponentSliceCodeOrientation => new Coding(this.ObservationComponentSliceCodesUrl, "orientation");
        Coding ComponentSliceCodeShape => new Coding(this.ObservationComponentSliceCodesUrl, "shape");
        Coding MGComponentSliceCodeAbnormalityAsymmetryType => new Coding(this.ObservationComponentSliceCodesUrl, "mgAbnormalityAsymmetryType");
        Coding MGComponentSliceCodeAbnormalityDensityType => new Coding(this.ObservationComponentSliceCodesUrl, "mgAbnormalityDensityType");

        Coding MGComponentSliceCodeCalcificationType => new Coding(this.ObservationComponentSliceCodesUrl, "mgCalcificationType");
        Coding MGCodeCalcificationDistribution => new Coding(this.ObservationComponentSliceCodesUrl, "mgCalcificationDistribution");

        CSTaskVar ComponentSliceCodesCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        ObservationComponentSliceCodesName,
                        "Component Slice Codes CodeSystem",
                        "ComponentSliceCodes/ValueSet",
                        "Component Slice Codes code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeAbnormalityCystType)
                                .SetDefinition("Slicing Component Code - AbnormalityCystType")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeAbnormalityDuctType)
                                .SetDefinition("Slicing Component Code - CodeAbnormalityDuctType")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeAbnormalityFibroAdenomaType)
                                .SetDefinition("Slicing Component Code - CodeAbnormalityFibroAdenomaType")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeAbnormalityForeignObjectType)
                                .SetDefinition("Slicing Component Code - CodeAbnormalityForeignObjectType")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeAbnormalityLymphNodeType)
                                .SetDefinition("Slicing Component Code - CodeAbnormalityLymphNodeType")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeAbnormalityMassType)
                                .SetDefinition("Slicing Component Code - CodeAbnormalityMassType")
                                ,

                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeBiRads)
                                .SetDefinition("Slicing Component Code - BiRads")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeConsistentWithValue)
                                .SetDefinition("Slicing Component Code - ConsistentWithValue")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeConsistentWithQualifier)
                                .SetDefinition("Slicing Component Code - ConsistentWithQualifier")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeCorrespondsWith)
                                .SetDefinition("Slicing Component Code - CorrespondsWith")
                                ,

                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeMargin)
                                .SetDefinition("Slicing Component Code - Margin")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeMGDensity)
                                .SetDefinition("Slicing Component Code - MGDensity")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeNotPreviouslySeen)
                                .SetDefinition("Slicing Component Code - Not Previously Seen")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeObservedChanges)
                                .SetDefinition("Slicing Component Code - Observed Changes")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeObservedCount)
                                .SetDefinition("Slicing Component Code - ObservedCount")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeObservedDistribution)
                                .SetDefinition("Slicing Component Code - ObservedDistribution")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeObservedSize)
                                .SetDefinition("Slicing Component Code - ObservedSize")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeObservedFeatureType)
                                .SetDefinition("Slicing Component Code - ObservedFeatureType")
                                ,

                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeOrientation)
                                .SetDefinition("Slicing Component Code - Orientation")
                                ,
                            new ConceptDef()
                                .SetCode(Self.ComponentSliceCodeShape)
                                .SetDefinition("Slicing Component Code - Shape")
                                ,

                            new ConceptDef()
                                .SetCode(Self.MGComponentSliceCodeAbnormalityAsymmetryType)
                                .SetDefinition("Slicing Component Code - MGCodeAbnormalityAsymmetryType")
                                ,
                            new ConceptDef()
                                .SetCode(Self.MGComponentSliceCodeAbnormalityDensityType)
                                .SetDefinition("Slicing Component Code - MGCodeAbnormalityDensityType")
                                ,

                            new ConceptDef()
                                .SetCode(Self.MGComponentSliceCodeCalcificationType)
                                .SetDefinition("Slicing Component Code - MGCalcificationType")
                                ,
                            new ConceptDef()
                                .SetCode(Self.MGCodeCalcificationDistribution)
                                .SetDefinition("Slicing Component Code - MGCalcificationDistribution")
                                ,
                       })
             );
    }
}
