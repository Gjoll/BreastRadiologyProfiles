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
        SDTaskVar FindingMri = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                //$ Fix me. Incorrect method!!!
                SDefEditor e = Self.CreateEditorObservationSection("MRIFinding",
                        "MRI Finding",
                        "MRI Finding",
                        $"{Group_MRIResources}")
                    .Description("Breast Radiology MRI Finding",
                        new Markdown()
                    )
                ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                //ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                //{
                //new ProfileTargetSelf.Slice(e, sliceElementDef, Self.MRIMass.Value(), 0, "*"),
                //};
                //e.SliceByUrl("hasMember", targets);
                //e.AddProfileTargets(targets);

                //$e.Find("method")
                //     .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                //     .Card(1, "*")
                //     ;
            });
    }
}
