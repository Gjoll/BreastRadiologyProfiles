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
        SDTaskVar CommonComponentsFragment = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateFragment("CommonComponentsFragment",
                        "Common Components Fragment",
                        "Common Components Fragment",
                        ObservationUrl)
                    .Description("Common Components Fragment",
                        new Markdown()
                            .Paragraph("Common Components Fragment. Adds ")
                            .List("Changes", "Size", "Orientation")
                    )
                    .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
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

                Self.ComponentSliceObservedSize(e);

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
