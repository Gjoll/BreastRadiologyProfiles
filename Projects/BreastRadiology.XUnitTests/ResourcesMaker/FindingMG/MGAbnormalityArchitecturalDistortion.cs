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
using PreFhir;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        SDTaskVar MGAbnormalityArchitecturalDistortion = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditor("MGAbnormalityArchitecturalDistortion",
                        "Mammography Architectural Distortion",
                        "MG Arch. Distortion",
                        Global.ObservationUrl,
                        $"{Group_MGResources}/AbnormalityArchitecturalDistortion",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ShapeComponentsFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
                    .Description("Architectural Distortion Observation",
                        new Markdown()
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
                    )
                    ;
                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeMGAbnormalityArchitecturalDistortion.ToCodeableConcept());


                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;


                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference( sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");
                e.SliceTargetReference( sliceElementDef, Self.ConsistentWith.Value(), 0, "*");
            });
    }
}
