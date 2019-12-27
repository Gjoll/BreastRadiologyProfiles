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
        StringTaskVar USMass = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditor("BreastRadUSMass",
                        "US Mass",
                        "US Mass",
                        ObservationUrl,
                        $"{Group_USResources}/Finding/Mass")
                    .Description("Breast Radiology Mammography Ultra-Sound Mass Observation",
                        new Markdown()
                            .MissingObservation("a mass", "and no Shape, Orientation, Margin, Echo Pattern, or Posterior Acoustic Feature observations should be referenced by this observation")
                            .BiradHeader()
                            .BlockQuote("A mass is three dimensional and occupies space. With 2-D ultrasound, it should be seen in two")
                            .BlockQuote("different planes, and in three planes with volumetric acquisitions. Masses can be distinguished")
                            .BlockQuote("from normal anatomic structures, such as ribs or fat lobules, using two or more projections and")
                            .BlockQuote("real-time scanning.")
                            .BiradFooter()
                            .Todo(
                                "add mass size measurements (3 dimensional) like US?",
                                "same for asymmetry, lesion, calcification?"
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.BreastBodyLocationRequiredFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationSectionFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ImagingStudyFragment.Value())
                    ;
                s = e.SDef.Url;
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ResourcesMaker.Self.BiRadsAssessmentCategory.Value(), 0, "1"),

                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedCount.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedChangeInState.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.CommonObservedSize.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.Orientation.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.Hilum.Value(), 0, "1"),

                    new ProfileTargetSlice(ResourcesMaker.Self.USBoundary.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.USEchoPattern.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.USElasticity.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.USMargin.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.USPosteriorAcousticFeatures.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.USShape.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.USVascularity.Value(), 0, "1"),
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection($"Ultra-Sound Mass")
                    ;
            });
    }
}
