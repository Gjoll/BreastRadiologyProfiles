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
        StringTaskVar FindingMri = new StringTaskVar(
            (out String s) =>
            {
                //$ Fix me. Incorrect method!!!
                SDefEditor e = Self.CreateEditorObservationSection("MRIFinding",
                        "MRI Finding",
                        "MRI Finding",
                        $"{Group_MRIResources}")
                    .Description("Breast Radiology MRI Finding",
                        new Markdown()
                            .Todo(
                                "Device Metrics detailing the observation devices parameters.",
                                "Add information about contrast enhancement/other observation specific parameters."
                            )
                    )
                    .AddFragRef(Self.ObservationSectionFragment.Value())
                ;
                s = e.SDef.Url;

                //$e.IntroDoc
                //    .ObservationSection("MRI Finding")
                //    .ReviewedStatus(ReviewStatus.NotReviewed)
                //    ;

                //ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                //{
                //new ProfileTargetSlice(Self.MRIMass.Value(), 0, "*"),
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
