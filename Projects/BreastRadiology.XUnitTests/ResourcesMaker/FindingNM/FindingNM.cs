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
                SDefEditor e = ResourcesMaker.Self.CreateEditor("NMFinding",
                        "NM Finding",
                        "NM Finding",
                        ObservationUrl,
                        $"{Group_NMResources}")
                    .Description("Breast Radiology NMgraphy Finding",
                        new Markdown()
                            .Todo(
                                "Device Metrics detailing the observation devices parameters (transducer freq, etc)."
                                )
                        )
                    .AddFragRef(ResourcesMaker.Self.ObservationSectionFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    ;
                s = e.SDef.Url;
                e.Select("value[x]").Zero();
                ////$ todo. Incorrect method!!!
                //e.Find("method")
                // .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                // .Card(1, "*")
                // ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    //new ProfileTargetSlice(ResourcesMaker.Self.NMBreastDensity(), 1, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.NMMass.Value(), 0, "*"),
                    //new ProfileTargetSlice(ResourcesMaker.Self.NMCalcification(), 0, "*"),
                    //new ProfileTargetSlice(ResourcesMaker.Self.NMArchitecturalDistortion(), 0, "1"),
                    //new ProfileTargetSlice(ResourcesMaker.Self.NMAsymmetries(), 0, "*"),
                    //new ProfileTargetSlice(ResourcesMaker.Self.NMIntramammaryLymphNode(), 0, "1"),
                    //new ProfileTargetSlice(ResourcesMaker.Self.NMSkinLesion(), 0, "*"),
                    //new ProfileTargetSlice(ResourcesMaker.Self.NMSolitaryDilatedDuct(), 0, "1"),
                    //new ProfileTargetSlice(ResourcesMaker.Self.NMAssociatedFeatures(), 0, "1")
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("MRI Finding")
                    ;
            });
    }
}
