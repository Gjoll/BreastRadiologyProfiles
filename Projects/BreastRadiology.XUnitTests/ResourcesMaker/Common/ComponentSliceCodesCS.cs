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

        Coding CodeBiRads => new Coding(ComponentSliceCodesUrl, "targetBiRads");
        Coding CodeObservedChanges => new Coding(ComponentSliceCodesUrl, "observedChanges");
        Coding CodeObservedSize => new Coding(ComponentSliceCodesUrl, "observedSize");
        Coding CodeObservedCount => new Coding(ComponentSliceCodesUrl, "observedCount");
        Coding CodeOrientation => new Coding(ComponentSliceCodesUrl, "orientation");
        Coding CodeShape => new Coding(ComponentSliceCodesUrl, "shape");
        Coding CodeMargin => new Coding(ComponentSliceCodesUrl, "margin");
        Coding CodeMGDensity => new Coding(ComponentSliceCodesUrl, "mgDensity");

        Coding ConsistentWithCodeValue => new Coding(ComponentSliceCodesUrl, "consistentWithValue");
        Coding ConsistentWithCodeQualifier => new Coding(ComponentSliceCodesUrl, "consistentWithQualifier");

        Coding MGCodeAbnormalityAsymmetryType => new Coding(ComponentSliceCodesUrl, "mgAbnormalityAsymmetryType");
        Coding MGCodeAbnormalityCystType => new Coding(ComponentSliceCodesUrl, "mgAbnormalityCystType");
        Coding MGCodeAbnormalityDensityType => new Coding(ComponentSliceCodesUrl, "mgAbnormalityDensityType");
        Coding MGCodeAbnormalityDuctType => new Coding(ComponentSliceCodesUrl, "mgAbnormalityDuctType");
        Coding MGCodeAbnormalityFibroAdenomaType => new Coding(ComponentSliceCodesUrl, "mgAbnormalityFibroAdenomaType");
        Coding MGCodeAbnormalityForeignObjectType => new Coding(ComponentSliceCodesUrl, "mgAbnormalityForeignObjectType");
        Coding MGCodeAbnormalityLymphNodeType => new Coding(ComponentSliceCodesUrl, "mgAbnormalityLymphNodeType");
        Coding MGCodeAbnormalityMassType => new Coding(ComponentSliceCodesUrl, "mgAbnormalityMassType");

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
                            new ConceptDef(Self.CodeBiRads, "Slicing Component Code - BiRads"),
                            new ConceptDef(Self.CodeObservedChanges, "Slicing Component Code - Observed Changes"),
                            new ConceptDef(Self.CodeObservedSize, "Slicing Component Code - ObservedSize"),
                            new ConceptDef(Self.CodeObservedCount, "Slicing Component Code - ObservedCount"),

                            new ConceptDef(Self.CodeOrientation, "Slicing Component Code - Orientation"),
                            new ConceptDef(Self.CodeShape, "Slicing Component Code - Shape"),
                            new ConceptDef(Self.CodeMargin, "Slicing Component Code - Margin"),
                            new ConceptDef(Self.CodeMGDensity, "Slicing Component Code - MGDensity"),

                            new ConceptDef(Self.ConsistentWithCodeValue, "Slicing Component Code - CodeValue"),
                            new ConceptDef(Self.ConsistentWithCodeQualifier, "Slicing Component Code - CodeQualifier"),

                            new ConceptDef(Self.MGCodeAbnormalityAsymmetryType, "Slicing Component Code - MGCodeAbnormalityAsymmetryType"),
                            new ConceptDef(Self.MGCodeAbnormalityCystType, "Slicing Component Code - XXYYZ"),
                            new ConceptDef(Self.MGCodeAbnormalityDensityType, "Slicing Component Code - MGCodeAbnormalityDensityType"),
                            new ConceptDef(Self.MGCodeAbnormalityDuctType, "Slicing Component Code - MGCodeAbnormalityDuctType"),
                            new ConceptDef(Self.MGCodeAbnormalityFibroAdenomaType, "Slicing Component Code - MGCodeAbnormalityFibroAdenomaType"),
                            new ConceptDef(Self.MGCodeAbnormalityForeignObjectType, "Slicing Component Code - MGCodeAbnormalityForeignObjectType"),
                            new ConceptDef(Self.MGCodeAbnormalityLymphNodeType, "Slicing Component Code - MGCodeAbnormalityLymphNodeType"),
                            new ConceptDef(Self.MGCodeAbnormalityMassType, "Slicing Component Code - MGCodeAbnormalityMassType"),

                            new ConceptDef(Self.MGCodeCalcificationType, "Slicing Component Code - MGCalcificationType"),
                            new ConceptDef(Self.MGCodeCalcificationDistribution, "Slicing Component Code - MGCalcificationDistribution")
                        })
             );

        //#VSTaskVar ComponentSliceCodesVS = new VSTaskVar(
        //    (out ValueSet vs) =>
        //        vs = Self.CreateValueSet(
        //                "ConsistentWithSliceVS",
        //                "ConsistentWithSlice ValueSet",
        //                "ConsistentWithSlice/ValueSet",
        //                "ConsistentWithSlice value set.",
        //                Group_CommonCodesVS,
        //                Self.ComponentSliceCodesCS.Value()
        //            )
        //    );
    }
}
