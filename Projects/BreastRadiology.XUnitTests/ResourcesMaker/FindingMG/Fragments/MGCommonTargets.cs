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
                    ElementDefGroup component = e.StartComponentSliceing();

                    e.ComponentSliceCodeableConcept("biRadsAssessmentCategory",
                        Self.CommonTargetCodeBiRads.ToCodeableConcept(),
                        Self.BiRadsAssessmentCategoriesCS.Value().Url,
                        BindingStrength.Required,
                        0,
                        "1");

                    e.ComponentSliceCodeableConcept("observedChangeInDefinition",
                        Self.CommonTargetCodeObservedChangeInDefinition.ToCodeableConcept(),
                        Self.ObservedChangeInDefinitionCS.Value().Url,
                        BindingStrength.Required,
                        0,
                        "1");

                    e.ComponentSliceCodeableConcept("observedChangeInNumber",
                        Self.CommonTargetCodeObservedChangeInNumber.ToCodeableConcept(),
                        Self.ObservedChangeInNumberCS.Value().Url,
                        BindingStrength.Required,
                        0,
                        "1");
                    e.ComponentSliceCodeableConcept("observedChangeInProminance",
                        Self.CommonTargetCodeObservedChangeInProminance.ToCodeableConcept(),
                        Self.ObservedChangeInProminanceCS.Value().Url,
                        BindingStrength.Required,
                        0,
                        "1");
                    e.ComponentSliceCodeableConcept("observedChangeInSize",
                        Self.CommonTargetCodeObservedChangeInSize.ToCodeableConcept(),
                        Self.ObservedChangeInSizeCS.Value().Url,
                        BindingStrength.Required,
                        0,
                        "1");
                    e.ComponentSliceCodeableConcept("observedChangeInState",
                        Self.CommonTargetCodeObservedChangeInState.ToCodeableConcept(),
                        Self.ObservedChangeInStateCS.Value().Url,
                        BindingStrength.Required,
                        0,
                        "1");
                    e.ComponentSliceQuantity("observedSize",
                        Self.CommonTargetCodeObservedSize.ToCodeableConcept(),
                        0,
                        "1");
                    e.ComponentSliceCodeableConcept("orientation",
                        Self.CommonTargetCodeOrientation.ToCodeableConcept(),
                        Self.OrientationCS.Value().Url,
                        BindingStrength.Required,
                        0,
                        "1");
                }
            });
    }
}
