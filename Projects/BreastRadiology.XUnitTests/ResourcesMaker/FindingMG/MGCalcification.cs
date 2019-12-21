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
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        async StringTask MGCalcification()
        {
            if (this.mgCalcification == null)
                await this.CreateMGCalcification();
            return this.mgCalcification;
        }
        String mgCalcification = null;

        async VTask CreateMGCalcification()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoCalcification",
                        "Mammo Calcification",
                        "Mammo/Calc.",
                        ObservationUrl,
                        $"{Group_MGResources}/Calcification",
                        out this.mgCalcification)
                    .Description("Breast Radiology Mammography Calcification Observation",
                        new Markdown()
                            .MissingObservation("a calcification",
                                " and no Type or Distribution observations should be referenced by this observation")
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
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    .AddFragRef(await this.ObservationSectionFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.BiRadsAssessmentCategory(), 0, "1"),

                    new ProfileTargetSlice(await this.CommonObservedCount(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonObservedChanges(), 0, "*"),
                    new ProfileTargetSlice(await this.CommonObservedSize(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonObservedState(), 0, "*"),

                    new ProfileTargetSlice(await this.MGCalcificationType(), 0, "1"),
                    new ProfileTargetSlice(await this.MGCalcificationDistribution(), 0, "1"),
                    new ProfileTargetSlice(await this.MGAssociatedFeatures(), 0, "1", false),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Mammography Calcification")
                    ;
            });
        }
    }
}
