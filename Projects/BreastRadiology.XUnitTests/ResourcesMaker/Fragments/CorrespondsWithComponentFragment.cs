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
        SDTaskVar CorrespondsWithComponentFragment = new SDTaskVar(
               (out StructureDefinition s) =>
                   {
                       SDefEditor e = Self.CreateFragment("CorrespondsWithFragment",
                               "CorrespondsWith Fragment",
                               "CorrespondsWith Fragment",
                               ObservationUrl)
                           .Description("Observation 'Consistent With' Component Fragment",
                               new Markdown()
                           )
                           ;
                       s = e.SDef;

                       e.StartComponentSliceing();
                       e.ComponentSliceCodeableConcept("correspondsWith",
                           Self.CodeCorrespondsWith.ToCodeableConcept(),
                           Self.CorrespondsWithVS.Value(),
                           BindingStrength.Extensible,
                           0,
                           "*",
                           "Corresponds With",
                            new Markdown()
                                .Paragraph($"This slice contains zero or more components that defines what this observation correspomnds with.",
                                            $"The value of this component is a codeable concept chosen from the {Self.CorrespondsWithVS.Value().Name} valueset.")
                           );
                       e.IntroDoc
                           .ReviewedStatus("NOONE", "")
                           ;
                   });
    }
}
