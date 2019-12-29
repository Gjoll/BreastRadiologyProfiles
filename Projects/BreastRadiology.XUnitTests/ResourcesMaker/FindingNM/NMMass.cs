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
        StringTaskVar NMMass = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditor("NMMass",
                        "NM Mass",
                        "NM/Mass",
                        ObservationUrl,
                        $"{Group_NMResources}/Mass")
                    .Description("Breast Radiology NM Mass Observation",
                        new Markdown()
                            .MissingObservation("a mass", "and no Shape, Margin, or Density observations should be referenced by this observation")
                            //$.BiradHeader()
                            //$.BlockQuote("\"MASS\" is three dimensional and occupies space. It is seen on two different pro-")
                            //$.BlockQuote("jections. It has completely or partially convex-outward borders and (when radiodense) appears")
                            //$.BlockQuote("denser in the center than at the periphery. If a potential mass is seen only on a single projection, it")
                            //$.BlockQuote("should be called an \"ASYMMETRY\" until its 3-dimensionality is confirmed")
                            //$.BiradFooter()
                            .Todo(
                                "Complete description"
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.BreastBodyLocationRequiredFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ImagingStudyFragment.Value())
                    ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("NM Mass")
                    ;

                if (ResourcesMaker.Self.Component_HasMember)
                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(ResourcesMaker.Self.ObservedSize.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.ObservedCount.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.Orientation.Value(), 0, "1"),
                    new ProfileTargetSlice(ResourcesMaker.Self.NMMargin.Value(), 0, "*"),
                    new ProfileTargetSlice(ResourcesMaker.Self.ObservedChangeInState.Value(), 0, "*"),
                    };
                    e.SliceByUrl("hasMember", targets);
                    e.AddProfileTargets(targets);
                }
                else
                {
                    throw new NotImplementedException();
                }
            });
    }
}
