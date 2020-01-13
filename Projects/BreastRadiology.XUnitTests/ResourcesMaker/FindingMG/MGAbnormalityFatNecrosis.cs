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
                SDefEditor e = Self.CreateEditorObservationLeaf("MGAbnormalityFatNecrosis",
                        "Mammography Fat Necrosis",
                        "MG Fat Necrosis",
                        $"{Group_MGResources}/AbnormalityFatNecrosis")
                    .Description("Fat Necrosis Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                            .MissingObservation("a fat necrosis abnormality")
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value().Url)
                    .AddFragRef(Self.ObservationNoValueFragment.Value().Url)
                    .AddFragRef(Self.ImagingStudyFragment.Value().Url)
                    .AddFragRef(Self.CommonComponentsFragment.Value().Url)
                    .AddFragRef(Self.ShapeComponentsFragment.Value().Url)
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value().Url)
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

                e.Select("value[x]").Zero();
                PreFhir.ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                Self.SliceTargetReference(e, sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");
                Self.SliceTargetReference(e, sliceElementDef, Self.ConsistentWith.Value(), 0, "*");

                e.StartComponentSliceing();
                Self.ComponentSliceObservedCount(e);
            });
    }
}
