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
        SDTaskVar MGCommonTargetsFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("MgCommonTargetsFragment",
                        "MG Common Targets Fragment",
                        "MG Common Targets Fragment",
                        ObservationUrl)
                    .Description("Mammography Common Targets Fragment",
                        new Markdown()
                            .Paragraph("Mammography Common Targets Fragment")
                    )
                    .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value().Url)
                    ;
                s = e.SDef;

                e.StartComponentSliceing();

                Self.ComponentSliceBiRads(e);

                e.ComponentSliceCodeableConcept("observedChanges",
                    Self.CodeObservedChanges.ToCodeableConcept(),
                    Self.ObservedChangesVS.Value(),
                    BindingStrength.Required,
                    0,
                    "*",
                    "Observed Change In Abnormality");

                e.ComponentSliceQuantity("observedSize",
                    Self.CodeObservedSize.ToCodeableConcept(),
                    0,
                    "1",
                    "Size of an abnormality");

                e.ComponentSliceCodeableConcept("orientation",
                    Self.CodeOrientation.ToCodeableConcept(),
                    Self.OrientationVS.Value(),
                    BindingStrength.Required,
                    0,
                    "1",
                    "Orientation of an abnormality");
            });
    }
}
