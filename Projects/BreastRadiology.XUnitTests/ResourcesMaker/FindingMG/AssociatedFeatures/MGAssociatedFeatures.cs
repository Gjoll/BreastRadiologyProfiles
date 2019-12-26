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
        String MGAssociatedFeatures()
        {
            if (this.mgAssociatedFeatures == null)
                this.CreateMGAssociatedFeatures();
            return this.mgAssociatedFeatures;
        }
        String mgAssociatedFeatures = null;

        void CreateMGAssociatedFeatures()
        {
            SDefEditor e = this.CreateEditor("BreastRadMammoAssociatedFeatures",
                    "Mammography Associated Features",
                    "Mg Associated/Features",
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
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationSectionFragment())
                .AddFragRef(this.ObservationNoValueFragment())
                ;
            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(this.MGSkinRetraction(), 0, "1"),
                    new ProfileTargetSlice(this.MGNippleRetraction(), 0, "1"),
                    new ProfileTargetSlice(this.MGSkinThickening(), 0, "*"),
                    new ProfileTargetSlice(this.MGAxillaryAdenopathy(), 0, "1"),
                    new ProfileTargetSlice(this.MGAbnormalityArchitecturalDistortion(), 0, "*"),
                    new ProfileTargetSlice(this.MGAbnormalityCalcification(), 0, "*")
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationSection("Mammography Associated Features")
                ;
        }
    }
}
