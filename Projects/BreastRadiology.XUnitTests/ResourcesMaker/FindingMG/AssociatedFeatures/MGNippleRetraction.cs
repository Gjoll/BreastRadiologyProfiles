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
        String MGNippleRetraction()
        {
            if (this.mgNippleRetraction == null)
                this.CreateMGNippleRetraction();
            return this.mgNippleRetraction;
        }
        String mgNippleRetraction = null;

        void CreateMGNippleRetraction()
        {
            SDefEditor e = this.CreateEditor("BreastRadMammoNippleRetraction",
                "Mammography Nipple Retraction",
                "Mg Nipple Retraction",
                ObservationUrl,
                $"{Group_MGResources}/AssociatedFeature/NippleRetraction",
                out this.mgNippleRetraction)
                .Description("Breast Radiology Mammography Nipple Retraction Observation",
                    new Markdown()
                        .MissingObservation("a nipple retraction")
                        .BiradHeader()
                        .BlockQuote("The nipple is pulled in. This should not be confused with nipple inversion, which is often bilateral ")
                        .BlockQuote("and which in the absence of any suspicious findings and when stable for a long period of time, ")
                        .BlockQuote("is not a sign of malignancy. However, if nipple retraction is new, suspicion for underlying malignancy is increased.")
                        .BiradFooter()
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationNoValueFragment())
                .AddFragRef(this.BreastBodyLocationRequiredFragment())
                ;

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationLeafNode("Nipple Retraction")
                ;
        }
    }
}
