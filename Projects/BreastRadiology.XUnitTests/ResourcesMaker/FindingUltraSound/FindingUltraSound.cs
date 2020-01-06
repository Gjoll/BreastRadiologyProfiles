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
                SDefEditor e = Self.CreateEditorObservationSection("USFinding",
                        "Ultra-Sound Finding",
                        "US Finding",
                        $"{Group_USResources}")
                    .Description("Breast Radiology Ultra Sound Finding",
                        new Markdown()
                    )
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("value[x]").Zero();
                //$e.Find("method")
                // .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
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
