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
        String FindingNM()
        {
            if (this.findingNM == null)
                this.CreateFindingNM();
            return this.findingNM;
        }
        String findingNM = null;

        void CreateFindingNM()
        {
                SDefEditor e = this.CreateEditor("BreastRadNMFinding",
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
                    .AddFragRef(this.ObservationSectionFragment())
                    .AddFragRef(this.ObservationNoValueFragment())
                    ;
            this.findingNM = e.SDef.Url;
            e.Select("value[x]").Zero();
                ////$ todo. Incorrect method!!!
                //e.Find("method")
                // .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                // .Card(1, "*")
                // ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    //new ProfileTargetSlice(this.NMBreastDensity(), 1, "1"),
                    new ProfileTargetSlice(this.NMMass(), 0, "*"),
                    //new ProfileTargetSlice(this.NMCalcification(), 0, "*"),
                    //new ProfileTargetSlice(this.NMArchitecturalDistortion(), 0, "1"),
                    //new ProfileTargetSlice(this.NMAsymmetries(), 0, "*"),
                    //new ProfileTargetSlice(this.NMIntramammaryLymphNode(), 0, "1"),
                    //new ProfileTargetSlice(this.NMSkinLesion(), 0, "*"),
                    //new ProfileTargetSlice(this.NMSolitaryDilatedDuct(), 0, "1"),
                    //new ProfileTargetSlice(this.NMAssociatedFeatures(), 0, "1")
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