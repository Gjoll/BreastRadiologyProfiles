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
        StringTaskVar MGAbnormalityArchitecturalDistortion = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditor("MGAbnormalityArchitecturalDistortion",
                        "Mammography Architectural Distortion",
                        "MG Arch. Distortion",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityArchitecturalDistortion")
                    .Description("Breast Radiology Mammography Architectural Distortion Observation",
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
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.MGCommonTargetsFragment.Value())
                    ;
                s = e.SDef.Url;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ResourcesMaker.Self.ConsistentWith.Value(), 0, "*"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }
                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Architectural Distortion")
                    ;
            });
    }
}
