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
        String MGAbnormalityCalcification()
        {
            if (this.mgAbnormalityCalcification == null)
                this.CreateMGAbnormalityCalcification();
            return this.mgAbnormalityCalcification;
        }
        String mgAbnormalityCalcification = null;

        void CreateMGAbnormalityCalcification()
        {
            SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityCalcification",
                    "Mammography Calcification Abnormality",
                    "Mg Calc. Abnormality",
                    ObservationUrl,
                    $"{Group_MGResources}/CalcificationAbnormality",
                    out this.mgAbnormalityCalcification)
                .Description("Breast Radiology Mammography Calcification Abnormality Observation",
                    new Markdown()
                        .MissingObservation("a calcification")
                        .BiradHeader()
                        .BlockQuote("Calcifications that are assessed as benign at mammography are typically larger, coarser, round with")
                        .BlockQuote("smooth margins, and more easily seen than malignant calcifications. Calcifications associated with")
                        .BlockQuote("malignancy (and many benign calcifications as well) are usually very small and often require the use")
                        .BlockQuote("of magnification to be seen well. When a specific typically benign etiology cannot be assigned, a")
                        .BlockQuote("description of calcifications should include their morphology and distribution. Calcifications that are")
                        .BlockQuote("obviously benign need not be reported, especially if the interpreting physician is concerned that")
                        .BlockQuote("the referring clinician or patient might infer anything other than absolute confidence in benignity")
                        .BlockQuote("were such calcifications described in the report. However, typically benign calcifications should be")
                        .BlockQuote("reported if the interpreting physician is concerned that other observers might misinterpret them as")
                        .BlockQuote("anything but benign were such calcifications not described in the report.")
                        .BlockQuote("As an ASSOCIATED FEATURE, this may be used in conjunction with one or more other FINDING(S)")
                        .BlockQuote("to describe calcifications within or immediately adjacent to the finding(s)")
                        .BiradFooter()
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationSectionFragment())
                .AddFragRef(this.ObservationNoValueFragment())
                .AddFragRef(this.MGCommonTargetsFragment())
                .AddFragRef(this.MGShapeTargetsFragment())
                ;

            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(this.CommonObservedCount(), 0, "1"),

                    new ProfileTargetSlice(this.MGCalcificationType(), 0, "1"),
                    new ProfileTargetSlice(this.MGCalcificationDistribution(), 0, "1"),
                    new ProfileTargetSlice(this.MGAssociatedFeatures(), 0, "1"),
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationSection("Mammography Calcification Abnormality")
                ;
        }
    }
}
