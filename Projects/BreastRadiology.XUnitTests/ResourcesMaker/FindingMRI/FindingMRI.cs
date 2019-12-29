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
                SDefEditor e = ResourcesMaker.Self.CreateEditor("MRIFinding",
                        "MRI Finding",
                        "MRI Finding",
                        ObservationUrl,
                        $"{Group_MRIResources}")
                    .Description("Breast Radiology MRI Finding",
                        new Markdown()
                            .Todo(
                                "Device Metrics detailing the observation devices parameters.",
                                "Add information about contrast enhancement/other observation specific parameters."
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationSectionFragment.Value())
                ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("MRI Finding")
                    ;

                if (ResourcesMaker.Self.Component_HasMember)
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ResourcesMaker.Self.MRIMass.Value(), 0, "*"),
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);
                }
                else
                {
                    throw new NotImplementedException();
                }

                //$e.Find("method")
                //$     .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                //$     .Card(1, "*")
                //$     ;
            });
    }
}
