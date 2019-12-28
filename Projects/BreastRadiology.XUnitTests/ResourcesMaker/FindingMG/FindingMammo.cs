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
        StringTaskVar FindingMammo = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditor("MGFinding",
                        "Mammographi Finding",
                        "MG Finding",
                        ObservationUrl,
                        $"{Group_MGResources}")
                    .Description("Breast Radiology Mammography Finding",
                        new Markdown()
                            .Todo(
                                "Device Metrics detailing the observation devices parameters (transducer freq, etc)."
                                )
                        )
                    .AddFragRef(ResourcesMaker.Self.ObservationSectionFragment.Value())
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
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityForeignObject.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityArchitecturalDistortion.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityAsymmetry.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityCalcification.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityCyst.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityDensity.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityDuct.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityFatNecrosis.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityFibroadenoma.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityLymphNode.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAbnormalityMass.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGSkinLesion.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGAssociatedFeatures.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.MGBreastDensity.Value(), 1, "1")
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("MG Finding")
                    ;
            });
    }
}