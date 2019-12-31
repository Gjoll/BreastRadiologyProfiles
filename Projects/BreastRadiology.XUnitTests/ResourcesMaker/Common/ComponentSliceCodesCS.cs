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
        Coding CodeObservedChangeInDefinition => new Coding(ComponentSliceCodesUrl, "observedChangeInDefinition");
        Coding CodeObservedChangeInNumber => new Coding(ComponentSliceCodesUrl, "observedChangeInNumber");
        Coding CodeObservedChangeInProminance => new Coding(ComponentSliceCodesUrl, "observedChangeInProminance");
        Coding CodeObservedChangeInSize => new Coding(ComponentSliceCodesUrl, "observedChangeInSize");
        Coding CodeObservedChangeInState => new Coding(ComponentSliceCodesUrl, "observedChangeInState");
        Coding CodeObservedSize => new Coding(ComponentSliceCodesUrl, "observedSize");
        Coding CodeOrientation => new Coding(ComponentSliceCodesUrl, "orientation");
        Coding CodeShape => new Coding(ComponentSliceCodesUrl, "shape");
        Coding CodeMargin => new Coding(ComponentSliceCodesUrl, "margin");
        Coding CodeMGDensity=> new Coding(ComponentSliceCodesUrl, "mgDensity");

        Coding ConsistentWithCodeValue => new Coding(ComponentSliceCodesUrl, "consistentWithValue");
        Coding ConsistentWithCodeQualifier => new Coding(ComponentSliceCodesUrl, "consistentWithQualifier");

        Coding MGCodeCalcificationType => new Coding(ComponentSliceCodesUrl, "mgCalcificationType");
        Coding MGCodeCalcificationDistribution => new Coding(ComponentSliceCodesUrl, "mgCalcificationDistribution");


        CSTaskVar ComponentSliceCodesCS = new CSTaskVar(
             () =>
                 Self.CreateCodeSystem(
                        "ComponentSliceCodes",
                        "Component Slice Codes CodeSystem",
                        "ComponentSliceCodes/ValueSet",
                        "Component Slice Codes code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            new ConceptDef(Self.ConsistentWithCodeValue, "Slicing Component Code - CodeValue"),
                            new ConceptDef(Self.ConsistentWithCodeQualifier, "Slicing Component Code - CodeQualifier"),
                            new ConceptDef(Self.CodeBiRads, "Slicing Component Code - BiRads"),
                            new ConceptDef(Self.CodeObservedChangeInDefinition, "Slicing Component Code - ChangeInDefinition"),
                            new ConceptDef(Self.CodeObservedChangeInNumber, "Slicing Component Code - ChangeInNumber"),
                            new ConceptDef(Self.CodeObservedChangeInProminance, "Slicing Component Code - ChangeInProminance"),
                            new ConceptDef(Self.CodeObservedChangeInSize, "Slicing Component Code - ChangeInSize"),
                            new ConceptDef(Self.CodeObservedChangeInState, "Slicing Component Code - ChangeInState"),
                            new ConceptDef(Self.CodeObservedSize, "Slicing Component Code - ObservedSize"),

                            new ConceptDef(Self.CodeOrientation, "Slicing Component Code - Orientation"),
                            new ConceptDef(Self.CodeShape, "Slicing Component Code - Shape"),
                            new ConceptDef(Self.CodeMargin, "Slicing Component Code - Margin"),
                            new ConceptDef(Self.CodeMGDensity, "Slicing Component Code - MGDensity"),
                        })
             );

        VSTaskVar ComponentSliceCodesVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                        "ConsistentWithSliceVS",
                        "ConsistentWithSlice ValueSet",
                        "ConsistentWithSlice/ValueSet",
                        "ConsistentWithSlice value set.",
                        Group_CommonCodesVS,
                        Self.ComponentSliceCodesCS.Value()
                    )
            );
    }
}
