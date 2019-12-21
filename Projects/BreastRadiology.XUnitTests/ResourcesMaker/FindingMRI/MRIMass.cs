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
using VTask = System.Threading.Tasks.Task;
using StringTask = System.Threading.Tasks.Task<string>;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        async StringTask MRIMass()
        {
            if (this.mriMass == null)
                await this.CreateMRIMass();
            return this.mriMass;
        }
        String mriMass = null;

        async VTask CreateMRIMass()
        {
            await VTask.Run(async () =>
            {
                SDefEditor e = this.CreateEditor("BreastRadMRIMass",
                        "MRI Mass",
                        "MRI/Mass",
                        ObservationUrl,
                        $"{Group_MRIResources}/Mass",
                        out this.mriMass)
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
                    .AddFragRef(await this.ObservationNoDeviceFragment())
                    .AddFragRef(await this.BreastBodyLocationRequiredFragment())
                    .AddFragRef(await this.ObservationSectionFragment())
                    .AddFragRef(await this.ObservationNoValueFragment())
                    .AddFragRef(await this.ImagingStudyFragment())
;

                {
                    ProfileTargetSlice[] targets = new ProfileTargetSlice[]
                    {
                    new ProfileTargetSlice(await this.CommonObservedSize(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonObservedCount(), 0, "1"),
                    //$new ProfileTargetSlice(await this.CommonMassShape(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonOrientation(), 0, "1"),
                    new ProfileTargetSlice(await this.MRIMassMargin(), 0, "*"),
                    //$new ProfileTargetSlice(await this.MRIMassDensity(), 0, "1"),
                    new ProfileTargetSlice(await this.CommonObservedChanges(), 0, "*"),
                    //$new ProfileTargetSlice(await this.MRIAssociatedFeatures(), 0, "1", false),
                    new ProfileTargetSlice(await this.CommonObservedState(), 0, "*")
                    };
                    e.Find("hasMember").SliceByUrl(targets);
                    e.AddProfileTargets(targets);
                }

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationSection("MRI Mass")
                    ;
            });
        }
    }
}
