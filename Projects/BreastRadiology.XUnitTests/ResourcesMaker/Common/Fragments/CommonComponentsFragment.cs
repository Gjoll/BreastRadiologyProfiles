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
                    .AddFragRef(Self.ObservedChangesComponentFragment.Value())
                    .AddFragRef(Self.ObservedSizeComponentFragment.Value())
                    .AddFragRef(Self.ObservedAreaComponentFragment.Value())
                    .AddFragRef(Self.BiRadComponentFragment.Value())
                    ;
                s = e.SDef;

                e.StartComponentSliceing();
            });
    }
}
