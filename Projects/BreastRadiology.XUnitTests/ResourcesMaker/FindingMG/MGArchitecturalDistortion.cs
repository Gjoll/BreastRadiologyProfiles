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
        async StringTask MGArchitecturalDistortion()
        {
            if (this.mgArchitecturalDistortion == null)
                await this.CreateMGArchitecturalDistortion();
            return this.mgArchitecturalDistortion;
        }
        String mgArchitecturalDistortion = null;

        async VTask CreateMGArchitecturalDistortion()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMammoArchitecturalDistortion",
                            "Mammo Architectural Distortion",
                        "Mammo/Arch./Distortion",
                        ObservationUrl,
                        $"{Group_MGResources}/ArchitecturalDistortion",
                        out this.mgArchitecturalDistortion)
                    .Description("Breast Radiology Mammography Architectural Distortion Observation",
                        new Markdown()
                            .MissingObservation("an architectural distortion")
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
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    ;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.BiRadsAssessmentCategory(), 0, "1"),

                    new ProfileTargetSlice(await this.CommonObservedChanges(), 0, "*"),
                    new ProfileTargetSlice(await this.CommonObservedSize(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonOrientation(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonObservedState(), 0, "*")
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode($"Architectural Distortion")
                    ;
            });
        }
    }
}
