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
        async StringTask MGAssociatedFeatures()
        {
            if (this.mgAssociatedFeatures == null)
                await this.CreateMGAssociatedFeatures();
            return this.mgAssociatedFeatures;
        }
        String mgAssociatedFeatures = null;

        async VTask CreateMGAssociatedFeatures()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoAssociatedFeatures",
                        "Mammo Associated Features",
                        "Mammo/Associated/Features",
                        ObservationUrl,
                        $"{Group_MGResources}/AssociatedFeature",
                        out this.mgAssociatedFeatures)
                    .Description("Mammography Associated Features Observation",
                        new Markdown()
                            .Paragraph("Used with masses, asymmetries, or calcifications, or may stand alone as " +
                                        "Features when no other abnormality is present.")
                            .Todo(
                                "check Cardinality of the following Observation.hasMember targets?"
                            )
                     )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationSectionFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    ;
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.MGSkinRetraction(), 0, "1"),
                    new ProfileTargetSlice(await this.MGNippleRetraction(), 0, "1"),
                    new ProfileTargetSlice(await this.MGSkinThickening(), 0, "*"),
                    new ProfileTargetSlice(await this.MGAxillaryAdenopathy(), 0, "1"),
                    new ProfileTargetSlice(await this.MGArchitecturalDistortion(), 0, "*"),
                    new ProfileTargetSlice(await this.MGCalcification(), 0, "*")
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Mammography Associated Features")
                    ;
            });
        }
    }
}
