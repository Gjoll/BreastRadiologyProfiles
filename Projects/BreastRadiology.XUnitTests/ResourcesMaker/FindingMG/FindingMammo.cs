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
        String FindingMammo()
        {
            if (this.findingMammo == null)
                this.CreateFindingMammo();
            return this.findingMammo;
        }
        String findingMammo = null;

        void CreateFindingMammo()
        {
            SDefEditor e = this.CreateEditor("BreastRadMammoFinding",
                    "Mammographi Finding",
                    "Mg Finding",
                    ObservationUrl,
                    $"{Group_MGResources}")
                .Description("Breast Radiology Mammography Finding",
                    new Markdown()
                        .Todo(
                            "Device Metrics detailing the observation devices parameters (transducer freq, etc)."
                            )
                    )
                .AddFragRef(this.ObservationSectionFragment())
                .AddFragRef(this.ObservationNoValueFragment())
                ;
            this.findingMammo = e.SDef.Url;
            e.Select("value[x]").Zero();
            ////$ todo. Incorrect method!!!
            //e.Find("method")
            // .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
            // .Card(1, "*")
            // ;

            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(this.MGAbnormalityForeignObject(), 0, "*"),
                    new ProfileTargetSlice(this.MGAbnormalityArchitecturalDistortion(), 0, "*"),
                    new ProfileTargetSlice(this.MGAbnormalityAsymmetry(), 0, "*"),
                    new ProfileTargetSlice(this.MGAbnormalityCalcification(), 0, "*"),
                    new ProfileTargetSlice(this.MGAbnormalityCyst(), 0, "*"),
                    new ProfileTargetSlice(this.MGAbnormalityDensity(), 0, "*"),
                    new ProfileTargetSlice(this.MGAbnormalityDuct(), 0, "*"),
                    new ProfileTargetSlice(this.MGAbnormalityFatNecrosis(), 0, "*"),
                    new ProfileTargetSlice(this.MGAbnormalityFibroadenoma(), 0, "*"),
                    new ProfileTargetSlice(this.MGAbnormalityLymphNode(), 0, "*"),
                    new ProfileTargetSlice(this.MGAbnormalityMass(), 0, "*"),
                    new ProfileTargetSlice(this.MGSkinLesion(), 0, "*"),
                    new ProfileTargetSlice(this.MGAssociatedFeatures(), 0, "*"),
                    new ProfileTargetSlice(this.MGBreastDensity(), 1, "1")
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationSection("MRI Abnormality")
                ;
        }
    }
}