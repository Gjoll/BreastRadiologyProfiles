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
                SDefEditor e = ResourcesMaker.Self.CreateEditorXX("BreastRadMRIFinding",
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
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                ;
                s = e.SDef.Url;
                e.Select("value[x]").Zero();

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    //new ProfileTargetSlice(ResourcesMaker.Self.MGArchitecturalDistortion(), 0, "1"),
                    //new ProfileTargetSlice(ResourcesMaker.Self.MGAsymmetries(), 0, "*"),
                    //new ProfileTargetSlice(ResourcesMaker.Self.MGBreastDensity(), 1, "1"),
                    //new ProfileTargetSlice(ResourcesMaker.Self.MGCalcification(), 0, "*"),
                    //$new ProfileTargetSlice(ResourcesMaker.Self.CommonAbnormalityForeignObject(), 0, "*"),
                    //new ProfileTargetSlice(ResourcesMaker.Self.MGIntramammaryLymphNode(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MRIMass.Value(), 0, "*"),
                        //new ProfileTargetSlice(ResourcesMaker.Self.MGSkinLesion(), 0, "*"),
                        //new ProfileTargetSlice(ResourcesMaker.Self.MGSolitaryDilatedDuct(), 0, "1"),
                        //new ProfileTargetSlice(ResourcesMaker.Self.MGAssociatedFeatures(), 0, "1")
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("MRI Finding")
                    ;
                //$e.Find("method")
                //$     .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                //$     .Card(1, "*")
                //$     ;
            });
    }
}
