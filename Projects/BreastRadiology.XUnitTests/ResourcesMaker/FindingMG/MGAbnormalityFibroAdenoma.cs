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
        String MGAbnormalityFibroadenoma()
        {
            if (this.mgAbnormalityFibroadenoma == null)
                this.CreateMGAbnormalityFibroadenoma();
            return this.mgAbnormalityFibroadenoma;
        }
        String mgAbnormalityFibroadenoma = null;


        VSTaskVar MammoFibroadenomaVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSetXX(
                        "MammoFibroadenoma",
                        "Fibroadenoma",
                        "FibroadenomaValueSet",
                        "Codes defining Fibroadenoma values.",
                        Group_CommonCodes,
                        ResourcesMaker.Self.CommonFibroadenomaCS.Value()
                    )
            );


        void CreateMGAbnormalityFibroadenoma()
        {
            ValueSet binding = this.MammoFibroadenomaVS.Value();

            SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityFibroadenoma",
                    "Mammography Fibroadenoma Abnormality",
                    "Mg Fibroadenoma Abnormality",
                    ObservationUrl,
                    $"{Group_MGResources}/AbnormalityFibroadenoma")
                .Description("Breast Radiology Mammography Fibroadenoma Abnormality Observation",
                    new Markdown()
                        .Paragraph("[PR]")
                        .MissingObservation("a fibroadenoma abnormality")
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationSectionFragment())
                .AddFragRef(this.ObservationNoValueFragment())
                .AddFragRef(this.ImagingStudyFragment())
                .AddFragRef(this.MGCommonTargetsFragment())
                .AddFragRef(this.MGShapeTargetsFragment())
                ;

            this.mgAbnormalityFibroadenoma = e.SDef.Url;
            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(this.CommonObservedCount(), 0, "1"),
                };

                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }

            e.Select("value[x]")
                .ZeroToOne()
                .Type("CodeableConcept")
                .Binding(binding.Url, BindingStrength.Required)
                ;
            e.AddValueSetLink(binding);

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationSection("Mammography Fibroadenoma")
                .Refinement(binding, "Fibroadenoma")
                ;
        }
    }
}
