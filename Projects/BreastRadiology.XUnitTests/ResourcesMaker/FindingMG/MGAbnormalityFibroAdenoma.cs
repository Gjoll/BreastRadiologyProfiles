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
        async StringTask MGAbnormalityFibroadenoma()
        {
            if (this.mgAbnormalityFibroadenoma == null)
                await this.CreateMGAbnormalityFibroadenoma();
            return this.mgAbnormalityFibroadenoma;
        }
        String mgAbnormalityFibroadenoma = null;


        VSTaskVar MammoFibroadenomaVS = new VSTaskVar(
            async () =>
                await ResourcesMaker.Self.CreateValueSetXX(
                        "MammoFibroadenoma",
                        "Fibroadenoma",
                        "FibroadenomaValueSet",
                        "Codes defining Fibroadenoma values.",
                        Group_CommonCodes,
                        await ResourcesMaker.Self.CommonFibroadenomaCS.Value()
                    )
            );


        async VTask CreateMGAbnormalityFibroadenoma()
        {
            await VTask.Run(async () =>
            {
                ValueSet binding = await this.MammoFibroadenomaVS.Value();

                SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityFibroadenoma",
                        "Mammography Fibroadenoma Abnormality",
                        "Mg Fibroadenoma Abnormality",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityFibroadenoma",
                        out this.mgAbnormalityFibroadenoma)
                    .Description("Breast Radiology Mammography Fibroadenoma Abnormality Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                            .MissingObservation("a fibroadenoma abnormality")
                            .Todo(
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationSectionFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    .AddFragRef(await this.ImagingStudyFragment())
                    .AddFragRef(await this.MGCommonTargetsFragment())
                    .AddFragRef(await this.MGShapeTargetsFragment())
                    ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.CommonObservedCount(), 0, "1"),
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
            });
        }
    }
}
