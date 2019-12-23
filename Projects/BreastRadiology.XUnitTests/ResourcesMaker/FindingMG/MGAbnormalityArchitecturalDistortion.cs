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
        async StringTask MGAbnormalityArchitecturalDistortion()
        {
            if (this.mgAbnormalityArchitecturalDistortion == null)
                await this.CreateMGAbnormalityArchitecturalDistortion();
            return this.mgAbnormalityArchitecturalDistortion;
        }
        String mgAbnormalityArchitecturalDistortion = null;

        async VTask CreateMGAbnormalityArchitecturalDistortion()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoAbnormalityArchitecturalDistortion",
                        "Mammography Architectural Distortion Abnormality",
                        "Mg Arch. Distortion Abnormality",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityArchitecturalDistortion",
                        out this.mgAbnormalityArchitecturalDistortion)
                    .Description("Breast Radiology Mammography Architectural Distortion Abnormality Observation",
                        new Markdown()
                            .MissingObservation("an architectural distortion abnormality")
                            .BiradHeader()
                            .BlockQuote("The parenchyma is distorted with no definite mass visible. For mammography, this includes thin")
                            .BlockQuote("straight lines or spiculations radiating from a point, and focal retraction, distortion or straightening")
                            .BlockQuote("at the anterior or posterior edge of the parenchyma. Architectural distortion may also be associ-")
                            .BlockQuote("ated with a mass, asymmetry, or calcifications. In the absence of appropriate history of trauma or")
                            .BlockQuote("surgery, architectural distortion is suspicious for malignancy or radial scar, and tissue diagnosis is")
                            .BlockQuote("appropriate.")
                            .BlockQuote("As an ASSOCIATED FEATURE, architectural distortion may be used in conjunction with another")
                            .BlockQuote("finding to indicate that the parenchyma is distorted or retracted adjacent to the FINDING")
                            .BiradFooter()
                            .Todo(
                            )
                    )
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    .AddFragRef(await this.ObservationLeafFragment())
                    .AddFragRef(await this.MGCommonTargetsFragment())
                    .AddFragRef(await this.MGShapeTargetsFragment())
                    ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode($"Architectural Distortion Abnormality")
                    ;
            });
        }
    }
}
