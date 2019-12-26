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
        String MRIMass()
        {
            if (this.mriMass == null)
                this.CreateMRIMass();
            return this.mriMass;
        }
        String mriMass = null;

        void CreateMRIMass()
        {
            SDefEditor e = this.CreateEditor("BreastRadMRIMass",
                    "MRI Mass",
                    "MRI Mass",
                    ObservationUrl,
                    $"{Group_MRIResources}/Mass")
                .Description("Breast Radiology MRIgraphy Mass Observation",
                    new Markdown()
                        .MissingObservation("a mass", "and no Shape, Margin, or Density observations should be referenced by this observation")
                        .BiradHeader()
                        .BlockQuote("\"MASS\" is three dimensional and occupies space. It is seen on two different pro-")
                        .BlockQuote("jections. It has completely or partially convex-outward borders and (when radiodense) appears")
                        .BlockQuote("denser in the center than at the periphery. If a potential mass is seen only on a single projection, it")
                        .BlockQuote("should be called an \"ASYMMETRY\" until its 3-dimensionality is confirmed")
                        .BiradFooter()
                        .Todo(
                            "Complete description",
                            "add mass size measurements (3 dimensional) like US?",
                            "same for asymmetry, lesion, calcification?"
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.BreastBodyLocationRequiredFragment())
                .AddFragRef(this.ObservationSectionFragment())
                .AddFragRef(this.ObservationNoValueFragment())
                .AddFragRef(this.ImagingStudyFragment())
                ;
            this.mriMass = e.SDef.Url;

            {
                ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                {
                    new ProfileTargetSlice(this.CommonObservedSize(), 0, "1"),
                    new ProfileTargetSlice(this.CommonObservedCount(), 0, "1"),
                    //$new ProfileTargetSlice(this.CommonMassShape(), 0, "1"),
                    new ProfileTargetSlice(this.CommonOrientation(), 0, "1"),
                    new ProfileTargetSlice(this.MRIMassMargin(), 0, "*"),
                    //$new ProfileTargetSlice(this.MRIMassDensity(), 0, "1"),
                    new ProfileTargetSlice(this.CommonObservedChangeInState(), 0, "*"),
                    //$new ProfileTargetSlice(this.MRIAssociatedFeatures(), 0, "1", false),
                };
                e.Find("hasMember").SliceByUrl(targets);
                e.AddProfileTargets(targets);
            }

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationSection("MRI Mass")
                ;
        }
    }
}
