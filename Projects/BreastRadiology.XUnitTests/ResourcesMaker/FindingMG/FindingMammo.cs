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
                SDefEditor e = Self.CreateEditor("MGFinding",
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
                    .AddFragRef(Self.ObservationSectionFragment.Value())
                    ;
                s = e.SDef.Url;
                e.Select("value[x]").Zero();
                ////$ todo. Incorrect method!!!
                //e.Find("method")
                // .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                // .Card(1, "*")
                // ;

                if (Self.Component_HasMember)
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(Self.MGAbnormalityForeignObject.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAbnormalityArchitecturalDistortion.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAbnormalityAsymmetry.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAbnormalityCalcification.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAbnormalityCyst.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAbnormalityDensity.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAbnormalityDuct.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAbnormalityFatNecrosis.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAbnormalityFibroadenoma.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAbnormalityLymphNode.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAbnormalityMass.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGSkinLesion.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGAssociatedFeatures.Value(), 0, "*"),
                    new ProfileTargetSlice(Self.MGBreastDensity.Value(), 1, "1")
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);
                }
                else
                {
                    throw new NotImplementedException();
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("MG Finding")
                    ;
            });
    }
}