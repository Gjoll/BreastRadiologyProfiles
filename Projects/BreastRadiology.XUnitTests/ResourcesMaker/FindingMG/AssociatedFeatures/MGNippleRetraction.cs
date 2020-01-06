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
        SDTaskVar MGNippleRetraction = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditorObservationLeaf("MGNippleRetraction",
                    "Mammography Nipple Retraction",
                    "MG Nipple Retraction",
                    $"{Group_MGResources}/AssociatedFeature/NippleRetraction")
                    .Description("Breast Radiology Mammography Nipple Retraction Observation",
                        new Markdown()
                            .MissingObservation("a nipple retraction")
                            .BiradHeader()
                            .BlockQuote("The nipple is pulled in. This should not be confused with nipple inversion, which is often bilateral ")
                            .BlockQuote("and which in the absence of any suspicious findings and when stable for a long period of time, ")
                            .BlockQuote("is not a sign of malignancy. However, if nipple retraction is new, suspicion for underlying malignancy is increased.")
                            .BiradFooter()
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value().Url)
                    .AddFragRef(Self.ObservationNoValueFragment.Value().Url)
                    .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value().Url)
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;
            });
    }
}
