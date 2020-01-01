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

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        StringTaskVar MGCommonTargetsFragment = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateFragment("MgCommonTargetsFragment",
                        "MG Common Targets Fragment",
                        "MG Common Targets Fragment",
                        ObservationUrl)
                    .Description("Mammography Common Targets Fragment",
                        new Markdown()
                            .Paragraph("Mammography Common Targets Fragment")
                            //.Todo
                    )
                    .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
                    ;
                s = e.SDef.Url;

                if (Self.Component_HasMember)
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(Self.BiRadsAssessmentCategory.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.ObservedChangeInDefinition.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.ObservedChangeInNumber.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.ObservedChangeInProminance.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.ObservedChangeInSize.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.ObservedChangeInState.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.ObservedSize.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.Orientation.Value(), 0, "1"),
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);
                }
                else
                {
                    Self.ComponentSliceBiRads(e);

                    e.ComponentSliceCodeableConcept("observedChangeInDefinition",
                        Self.CodeObservedChangeInDefinition.ToCodeableConcept(),
                        Self.ObservedChangeInDefinitionVS.Value(),
                        BindingStrength.Required,
                        0,
                        "1",
                        "Change In Definition");

                    e.ComponentSliceCodeableConcept("observedChangeInNumber",
                        Self.CodeObservedChangeInNumber.ToCodeableConcept(),
                        Self.ObservedChangeInNumberVS.Value(),
                        BindingStrength.Required,
                        0,
                        "1",
                        "Change In Number");
                    e.ComponentSliceCodeableConcept("observedChangeInProminance",
                        Self.CodeObservedChangeInProminance.ToCodeableConcept(),
                        Self.ObservedChangeInProminanceVS.Value(),
                        BindingStrength.Required,
                        0,
                        "1",
                        "Change In Prominance");
                    e.ComponentSliceCodeableConcept("observedChangeInSize",
                        Self.CodeObservedChangeInSize.ToCodeableConcept(),
                        Self.ObservedChangeInSizeVS.Value(),
                        BindingStrength.Required,
                        0,
                        "1",
                        "Change In Size");
                    e.ComponentSliceCodeableConcept("observedChangeInState",
                        Self.CodeObservedChangeInState.ToCodeableConcept(),
                        Self.ObservedChangeInStateVS.Value(),
                        BindingStrength.Required,
                        0,
                        "1",
                        "Change In State");
                    e.ComponentSliceQuantity("observedSize",
                        Self.CodeObservedSize.ToCodeableConcept(),
                        0,
                        "1",
                        "Size");
                    e.ComponentSliceCodeableConcept("orientation",
                        Self.CodeOrientation.ToCodeableConcept(),
                        Self.OrientationVS.Value(),
                        BindingStrength.Required,
                        0,
                        "1",
                        "Orientation");
                }
            });
    }
}
