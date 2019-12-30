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
        Coding CommonTargetCodeBiRads => new Coding(Self.ComponentSliceCodesCS.Value().Url, "targetBiRads");
        Coding CommonTargetCodeObservedChangeInDefinition => new Coding(Self.ComponentSliceCodesCS.Value().Url, "observedChangeInDefinition");
        Coding CommonTargetCodeObservedChangeInNumber => new Coding(Self.ComponentSliceCodesCS.Value().Url, "observedChangeInNumber");
        Coding CommonTargetCodeObservedChangeInProminance => new Coding(Self.ComponentSliceCodesCS.Value().Url, "observedChangeInProminance");
        Coding CommonTargetCodeObservedChangeInSize => new Coding(Self.ComponentSliceCodesCS.Value().Url, "observedChangeInSize");
        Coding CommonTargetCodeObservedChangeInState => new Coding(Self.ComponentSliceCodesCS.Value().Url, "observedChangeInState");
        Coding CommonTargetCodeObservedSize => new Coding(Self.ComponentSliceCodesCS.Value().Url, "observedSize");
        Coding CommonTargetCodeOrientation => new Coding(Self.ComponentSliceCodesCS.Value().Url, "orientation");

        Coding ConsistentWithCodeValue => new Coding(Self.ComponentSliceCodesCS.Value().Url, "consistentWithValue");
        Coding ConsistentWithCodeQualifier => new Coding(Self.ComponentSliceCodesCS.Value().Url, "consistentWithQualifier");



        CSTaskVar ComponentSliceCodesCS = new CSTaskVar(
             () =>
                 Self.CreateCodeSystem(
                        "ComponentSlice",
                        "Component Slice Codes CodeSystem",
                        "ComponentSliceCodes/ValueSet",
                        "Component Slice Codes code system",
                        Group_CommonCodes,
                        new ConceptDef[]
                        {
                            new ConceptDef(Self.ConsistentWithCodeValue, "Slicing Component Code"),
                            new ConceptDef(Self.ConsistentWithCodeQualifier, "Slicing Component Code"),
                            new ConceptDef(Self.CommonTargetCodeBiRads, "Slicing Component Code"),
                            new ConceptDef(Self.CommonTargetCodeObservedChangeInDefinition, "Slicing Component Code"),
                            new ConceptDef(Self.CommonTargetCodeObservedChangeInNumber, "Slicing Component Code"),
                            new ConceptDef(Self.CommonTargetCodeObservedChangeInProminance, "Slicing Component Code"),
                            new ConceptDef(Self.CommonTargetCodeObservedChangeInSize, "Slicing Component Code"),
                            new ConceptDef(Self.CommonTargetCodeObservedChangeInState, "Slicing Component Code"),
                            new ConceptDef(Self.CommonTargetCodeObservedSize, "Slicing Component Code"),
                            new ConceptDef(Self.CommonTargetCodeOrientation, "Slicing Component Code")
                        })
             );

        VSTaskVar ComponentSliceCodesVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                        "ConsistentWithSliceVS",
                        "ConsistentWithSlice ValueSet",
                        "ConsistentWithSlice/ValueSet",
                        "ConsistentWithSlice value set.",
                        Group_CommonCodes,
                        Self.ComponentSliceCodesCS.Value()
                    )
            );
    }
}
