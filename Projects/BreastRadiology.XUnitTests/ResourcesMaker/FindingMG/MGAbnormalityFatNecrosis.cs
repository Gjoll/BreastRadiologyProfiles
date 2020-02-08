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
        SDTaskVar MGAbnormalityFatNecrosis = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                SDefEditor e = Self.CreateEditor("MGAbnormalityFatNecrosis",
                        "Mammography Fat Necrosis",
                        "MG Fat Necrosis",
                        Global.ObservationUrl,
                        $"{Group_MGResources}/AbnormalityFatNecrosis",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.ObservationComponentShapeFragment.Value())
                    .AddFragRef(Self.ObservationComponentNotPreviouslySeenFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedCountFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedSizeFragment.Value())
                    .AddFragRef(Self.ObservationComponentObservedDistributionFragment.Value())
                    .AddFragRef(Self.ObservationComponentCorrespondsWithFragment.Value())
                    .AddFragRef(Self.ObservationComponentPreviouslyDemonstratedByFragment.Value())

                    .AddFragRef(Self.ObservationHasMemberAssociatedFeaturesFragment.Value())
                    .AddFragRef(Self.ObservationHasMemberConsistentWithFragment.Value())

                    .Description("Fat Necrosis Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                    )
                    ;

                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeMGAbnormalityFatNecrosis.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    .MammoDescription("688")
                    ;

                e.StartComponentSliceing();
            });
    }
}
