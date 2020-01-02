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
        StringTaskVar MGAbnormalityCalcification = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = Self.CreateEditor("MGAbnormalityCalcification",
                        "Mammography Calcification",
                        "MG Calc.",
                        ObservationUrl,
                        $"{Group_MGResources}/CalcificationAbnormality")
                    .Description("Breast Radiology Mammography Calcification Observation",
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
                    //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(Self.MGShapeTargetsFragment.Value())
                    ;

                s = e.SDef.Url;

                e.IntroDoc
                    .ObservationSection("Mammography Calcification")
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("value[x]").Zero();
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(Self.MGAssociatedFeatures.Value(), 0, "1"),
                    new ProfileTargetSlice(Self.ConsistentWith.Value(), 0, "*"),
                };
                e.SliceByUrl("hasMember", targets);
                e.AddProfileTargets(targets);

                e.StartComponentSliceing();
                Self.ComponentMGCalcificationType(e);
                Self.ComponentMGCalcificationDistribution(e);
                Self.ComponentSliceObservedCount(e);
            });
    }
}
