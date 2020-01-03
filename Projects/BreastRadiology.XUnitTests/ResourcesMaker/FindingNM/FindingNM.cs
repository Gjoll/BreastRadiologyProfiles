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
        StringTaskVar FindingNM = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateEditorObservationSection("NMFinding",
                        "NM Finding",
                        "NM Finding",
                        $"{Group_NMResources}")
                    .Description("Breast Radiology NMgraphy Finding",
                        new Markdown()
                            .Todo(
                                "Device Metrics detailing the observation devices parameters (transducer freq, etc)."
                                )
                        )
                    .AddFragRef(Self.ObservationSectionFragment.Value())
                    ;
                s = e.SDef.Url;

                //$e.IntroDoc
                //    .ObservationSection("MRI Finding")
                //    .ReviewedStatus(ReviewStatus.NotReviewed)
                //    ;

                e.Select("value[x]").Zero();
                ////$ todo. Incorrect method!!!
                //e.Find("method")
                // .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                // .Card(1, "*")
                // ;

                //ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                //{
                //new ProfileTargetSlice(Self.NMMass.Value(), 0, "*"),
                //};
                //e.SliceByUrl("hasMember", targets);
                //e.AddProfileTargets(targets);
            });
    }
}
