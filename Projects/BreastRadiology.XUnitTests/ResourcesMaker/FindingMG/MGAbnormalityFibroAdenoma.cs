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
        VSTaskVar MGFibroadenomaVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSet(
                        "MammoFibroadenomaVS",
                        "Fibroadenoma ValueSet",
                        "FibroadenomaValueSet",
                        "Fibroadenoma values value set.",
                        Group_CommonCodes,
                        ResourcesMaker.Self.FibroadenomaCS.Value()
                    )
            );


        StringTaskVar MGAbnormalityFibroadenoma = new StringTaskVar(
            (out String s) =>
            {
                ValueSet binding = ResourcesMaker.Self.MGFibroadenomaVS.Value();

                SDefEditor e = ResourcesMaker.Self.CreateEditor("MGAbnormalityFibroadenoma",
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
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ImagingStudyFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.MGCommonTargetsFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.MGShapeTargetsFragment.Value())
                    ;

                s = e.SDef.Url;
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ResourcesMaker.Self.ObservedCount.Value(), 0, "1"),
                    };

                    e.SliceByUrl("hasMember", targets);
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
