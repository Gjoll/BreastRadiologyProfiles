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
        StringTaskVar FindingUltraSound = new StringTaskVar(
            (out String s) =>
            {
                //$ Fix me. Incorrect method!!!
                SDefEditor e = ResourcesMaker.Self.CreateEditor("USFinding",
                        "UltraSound Finding",
                        "US Finding",
                        ObservationUrl,
                        $"{Group_USResources}")
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
                    .AddFragRef(ResourcesMaker.Self.ObservationSectionFragment.Value())
                    ;
                s = e.SDef.Url;
                e.Select("value[x]").Zero();
                //$e.Find("method")
                //$ .FixedCodeSlice("method", "http://snomed.info/sct", "115341008")
                //$ .Card(1, "*")
                //$ ;
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                        //$new ProfileTargetSlice(ResourcesMaker.Self.CommonAbnormalityForeignObject(), 0, "*"),
                        new ProfileTargetSlice(ResourcesMaker.Self.USMass.Value(), 0, "*"),
                        new ProfileTargetSlice(ResourcesMaker.Self.USTissueComposition.Value(), 1, "1"),
                        //new ProfileTargetSlice(ResourcesMaker.Self.MammoCalcification, 0, "*"),
                        //new ProfileTargetSlice(ResourcesMaker.Self.MammoArchitecturalDistortion, 0, "1"),
                        //new ProfileTargetSlice(ResourcesMaker.Self.MammoAsymmetries, 0, "*"),
                        //new ProfileTargetSlice(ResourcesMaker.Self.MammoIntramammaryLymphNode, 0, "1"),
                        //new ProfileTargetSlice(ResourcesMaker.Self.MammoSkinLesion, 0, "*"),
                        //new ProfileTargetSlice(ResourcesMaker.Self.MammoSolitaryDilatedDuct, 0, "1"),
                        //new ProfileTargetSlice(ResourcesMaker.Self.MammoAssociatedFeatures, 0, "1")
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Ultra-Sound Finding")
                    ;
            });
    }
}
