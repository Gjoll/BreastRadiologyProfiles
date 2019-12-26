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
        String FindingMri()
        {
            if (this.findingMri == null)
                this.CreateFindingMri();
            return this.findingMri;
        }
        String findingMri = null;

        void CreateFindingMri()
        {
            //$ Fix me. Incorrect method!!!
            SDefEditor e = this.CreateEditor("BreastRadMRIFinding",
                    "MRI Finding",
                    "MRI Finding",
                    ObservationUrl,
                    $"{Group_MRIResources}",
                    out this.findingMri)
                .Description("Breast Radiology MRI Finding",
                    new Markdown()
                        .Todo(
                            "Device Metrics detailing the observation devices parameters.",
                            "Add information about contrast enhancement/other observation specific parameters."
                        )
                )
                .AddFragRef(this.ObservationSectionFragment())
                .AddFragRef(this.ObservationNoValueFragment())
            ;
            e.Select("value[x]").Zero();

            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    //new ProfileTargetSlice(this.MGArchitecturalDistortion(), 0, "1"),
                    //new ProfileTargetSlice(this.MGAsymmetries(), 0, "*"),
                    //new ProfileTargetSlice(this.MGBreastDensity(), 1, "1"),
                    //new ProfileTargetSlice(this.MGCalcification(), 0, "*"),
                    //$new ProfileTargetSlice(this.CommonAbnormalityForeignObject(), 0, "*"),
                    //new ProfileTargetSlice(this.MGIntramammaryLymphNode(), 0, "1"),
                    new ProfileTargetSlice(this.MRIMass(), 0, "*"),
                    //new ProfileTargetSlice(this.MGSkinLesion(), 0, "*"),
                    //new ProfileTargetSlice(this.MGSolitaryDilatedDuct(), 0, "1"),
                    //new ProfileTargetSlice(this.MGAssociatedFeatures(), 0, "1")
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationSection("MRI Abnormality")
                ;
            //$e.Find("method")
            //$     .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
            //$     .Card(1, "*")
            //$     ;
        }
    }
}
