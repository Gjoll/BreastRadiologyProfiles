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
        //#StringTaskVar USMass = new StringTaskVar(
        //    (out String s) =>
        //    {
        //        SDefEditor e = Self.CreateEditor("USMass",
        //                "US Mass",
        //                "US Mass",
        //                ObservationUrl,
        //                $"{Group_USResources}/Finding/Mass")
        //            .Description("Breast Radiology Mammography Ultra-Sound Mass Observation",
        //                new Markdown()
        //                    .MissingObservation("a mass", "and no Shape, Orientation, Margin, Echo Pattern, or Posterior Acoustic Feature observations should be referenced by this observation")
        //                    .BiradHeader()
        //                    .BlockQuote("A mass is three dimensional and occupies space. With 2-D ultrasound, it should be seen in two")
        //                    .BlockQuote("different planes, and in three planes with volumetric acquisitions. Masses can be distinguished")
        //                    .BlockQuote("from normal anatomic structures, such as ribs or fat lobules, using two or more projections and")
        //                    .BlockQuote("real-time scanning.")
        //                    .BiradFooter()
        //            //.Todo
        //            )
        //            .AddFragRef(Self.ObservationNoDeviceFragment.Value())
        //            .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
        //            .AddFragRef(Self.ObservationNoValueFragment.Value())
        //            .AddFragRef(Self.ImagingStudyFragment.Value())
        //            ;
        //        s = e.SDef.Url;

        //        e.IntroDoc
        //            .ObservationSection($"Ultra-Sound Mass")
        //            .ReviewedStatus(ReviewStatus.NotReviewed)
        //            ;

        //        //ProfileTargetSlice[] targets = new ProfileTargetSlice[]
        //        //{
        //        //new ProfileTargetSlice(Self.BiRadsAssessmentCategory.Value(), 0, "1"),

        //        //new ProfileTargetSlice(Self.ObservedCount.Value(), 0, "1"),
        //        //new ProfileTargetSlice(Self.ObservedChangeInState.Value(), 0, "*"),
        //        //new ProfileTargetSlice(Self.ObservedSize.Value(), 0, "1"),
        //        //new ProfileTargetSlice(Self.Orientation.Value(), 0, "1"),
        //        //new ProfileTargetSlice(Self.Hilum.Value(), 0, "1"),

        //        //new ProfileTargetSlice(Self.USBoundary.Value(), 0, "1"),
        //        //new ProfileTargetSlice(Self.USEchoPattern.Value(), 0, "1"),
        //        //new ProfileTargetSlice(Self.USElasticity.Value(), 0, "1"),
        //        //new ProfileTargetSlice(Self.USMargin.Value(), 0, "*"),
        //        //new ProfileTargetSlice(Self.USPosteriorAcousticFeatures.Value(), 0, "1"),
        //        //new ProfileTargetSlice(Self.USShape.Value(), 0, "1"),
        //        //new ProfileTargetSlice(Self.USVascularity.Value(), 0, "1"),
        //        //};
        //        //e.SliceByUrl("hasMember", targets);
        //        //e.AddProfileTargets(targets);

        //        e.StartComponentSliceing();
        //        Self.ComponentSliceObservedCount(e);
        //    });
    }
}
