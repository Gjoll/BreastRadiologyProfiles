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
        async StringTask FindingUltraSound()
        {
            if (this.findingUltraSound == null)
                await this.CreateFindingUltraSound();
            return this.findingUltraSound;
        }
        String findingUltraSound = null;

        async VTask CreateFindingUltraSound()
        {
            await VTask.Run(async () =>
            {
                //$ Fix me. Incorrect method!!!
                SDefEditor e = this.CreateEditor("BreastRadUltraSoundFinding",
                        "UltraSound Finding",
                        "UltraSound/Finding",
                        ObservationUrl,
                        $"{Group_USResources}",
                        out this.findingUltraSound)
                    .Description("Breast Radiology Ultra Sound Finding",
                        new Markdown()
                            .Todo(
                                "Device Metrics detailing the observation devices parameters (transducer freq, etc).",
                                "BiRads US calcifications are only listed as " +
                                "- calc in a mass " +
                                "- calc outside a mass " +
                                "- intraductal calcification. " +
                                "Can we use the Mammo calcification structure instead?",
                                "US Special cases (page 155 E.). How to handle?",
                                "Associated features: " +
                                $"{Group_MGResources}/Ultra-Sound/MRI associated fetures are similar. Can we merge?" +
                                "us has" +
                                "- Edema" +
                                "- Vascularity" +
                                "- Elasticity Assessment" +
                                "Mammo has" +
                                "- Trabecular thickening" +
                                "- Axillary adenopathy" +
                                "mri has" +
                                "- Skin INvasion" +
                                "- Nipple Invasion",
                                $"{Group_MGResources}/Ultra-Sound/MRI Mass Margin are different." +
                                "Not Circumscribed differently." +
                                "Can they be aligned?",
                                $"{Group_MGResources}/Ultra-Sound/MRI Breast Density similar but not same." +
                                "Can they be aligned?"
                            )
                    )
                    .AddFragRef(await this.ObservationSectionFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    ;
                //$e.Find("method")
                //$ .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                //$ .Card(1, "*")
                //$ ;
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                        new ProfileTargetSlice(await this.CommonForeignObject(), 0, "*"),
                        new ProfileTargetSlice(await this.USMass(), 0, "*"),
                        new ProfileTargetSlice(await this.USTissueComposition(), 1, "1"),
                        //new ProfileTargetSlice(await this.MammoCalcification, 0, "*"),
                        //new ProfileTargetSlice(await this.MammoArchitecturalDistortion, 0, "1"),
                        //new ProfileTargetSlice(await this.MammoAsymmetries, 0, "*"),
                        //new ProfileTargetSlice(await this.MammoIntramammaryLymphNode, 0, "1"),
                        //new ProfileTargetSlice(await this.MammoSkinLesion, 0, "*"),
                        //new ProfileTargetSlice(await this.MammoSolitaryDilatedDuct, 0, "1"),
                        //new ProfileTargetSlice(await this.MammoAssociatedFeatures, 0, "1")
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Ultra-Sound Abnormality")
                    ;
            });
        }
    }
}
