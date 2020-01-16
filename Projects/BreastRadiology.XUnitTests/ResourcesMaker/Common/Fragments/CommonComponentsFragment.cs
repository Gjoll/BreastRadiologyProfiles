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
                    .Description("Common Components fragment",
                        new Markdown()
                            .Paragraph("Adds commonly used component slice values, including:")
                            .List("Changes", "Size")
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
                    "Observed Change In Abnormality",
                    new Markdown()
                        .Paragraph($"This slice contains zero or more components that define observed changes in this abnormality.",
                                    $"The value of this component is a codeable concept chosen from the {Self.ObservedChangesVS.Value().Name} valueset.")
                    );

                Self.ComponentSliceObservedSize(e);
            });
    }
}
