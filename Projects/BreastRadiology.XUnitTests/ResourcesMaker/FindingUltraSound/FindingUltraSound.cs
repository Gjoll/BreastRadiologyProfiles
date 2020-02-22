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
        SDTaskVar FindingUltraSound = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                //$ Fix me. Incorrect method!!!
                SDefEditor e = Self.CreateEditor("USFinding",
                        "Ultra-Sound Finding",
                        "US Finding",
                        Global.ObservationUrl,
                        $"{Group_USResources}",
                        "ObservationSection")
                        .Description("Ultra Sound Finding",
                            new Markdown()
                        )
                     .AddFragRef(Self.ObservationSectionFragment.Value())
                   ;
                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code")
                    .Pattern(Self.ObservationCodeUSFinding.ToCodeableConcept().ToPattern())
                    .DefaultValueExtension(Self.ObservationCodeUSFinding.ToCodeableConcept().ToPattern())
                    ;

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                //$e.Find("method")
                // .FixedCodeSlice("method", Snomed, "115341008")
                // .Card(1, "*")
                // ;

                //ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                //{
                //    new ProfileTargetSelf.Slice(e, sliceElementDef, Self.USMass.Value(), 0, "*"),
                //    new ProfileTargetSelf.Slice(e, sliceElementDef, Self.USTissueComposition.Value(), 1, "1"),
                //};
                //e.SliceByUrl("hasMember", targets);
                //e.AddProfileTargets(targets);
            });
    }
}
