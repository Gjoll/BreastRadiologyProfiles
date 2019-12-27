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
        StringTaskVar MGSkinRetraction = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditor("MGSkinRetraction",
                    "Mammography Skin Retraction",
                    "MG Skin Retraction",
                    ObservationUrl,
                    $"{Group_MGResources}/AssociatedFeature/SkinRetraction")
                    .Description("Mammography Skin Retraction Observation",
                        new Markdown()
                            .Paragraph()
                            .BiradHeader()
                            .BlockQuote("The skin is pulled in abnormally")
                            .BiradFooter()
                            .MissingObservation("a skin retraction")
                            .Todo(
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.BreastBodyLocationRequiredFragment.Value())
                    ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode("Skin Retraction")
                    ;
            });
    }
}
