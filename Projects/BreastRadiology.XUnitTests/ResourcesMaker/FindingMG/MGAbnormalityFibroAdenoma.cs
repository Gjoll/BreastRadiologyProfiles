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
        StringTaskVar MGAbnormalityFibroadenoma = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = Self.FibroadenomaVS.Value();

                SDefEditor e = Self.CreateEditor("MGAbnormalityFibroadenoma",
                        "Mammography Fibroadenoma",
                        "MG Fibroadenoma",
                        ObservationUrl,
                        $"{Group_MGResources}/AbnormalityFibroadenoma")
                    .Description("Breast Radiology Mammography Fibroadenoma Observation",
                        new Markdown()
                            .Paragraph("[PR]")
                            .MissingObservation("a fibroadenoma abnormality")
                            //.Todo
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ImagingStudyFragment.Value())
                    .AddFragRef(Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(Self.MGShapeTargetsFragment.Value())
                    ;

                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("Mammography Fibroadenoma")
                    .Refinement(binding, "Fibroadenoma")
                    ;

                if (Self.Component_HasMember)
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(Self.ObservedCount.Value(), 0, "1"),
                    };

                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);

                    e.Select("value[x]")
                        .ZeroToOne()
                        .Type("CodeableConcept")
                        .Binding(binding.Url, BindingStrength.Required)
                        ;
                    e.AddValueSetLink(binding);
                }
                else
                {
                    e.Select("value[x]").Zero();

                    e.StartComponentSliceing();
                    e.ComponentSliceCodeableConcept("mgAbnormalityFibroAdenomaType",
                        Self.MGCodeAbnormalityFibroAdenomaType.ToCodeableConcept(),
                        binding,
                        BindingStrength.Required,
                        1,
                        "1",
                        "MG AbnormalityFibroAdenoma Type");
                    Self.ComponentSliceObservedCount(e);
                }
            });
    }
}
