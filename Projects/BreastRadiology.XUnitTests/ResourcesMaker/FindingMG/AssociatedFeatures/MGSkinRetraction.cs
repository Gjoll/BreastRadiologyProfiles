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
        String MGSkinRetraction()
        {
            if (this.mgSkinRetraction == null)
                this.CreateMGSkinRetraction();
            return this.mgSkinRetraction;
        }
        String mgSkinRetraction = null;

        void CreateMGSkinRetraction()
        {
            SDefEditor e = this.CreateEditor("BreastRadMammoSkinRetraction",
                "Mammography Skin Retraction",
                "Mg Skin Retraction",
                ObservationUrl,
                $"{Group_MGResources}/AssociatedFeature/SkinRetraction",
                out this.mgSkinRetraction)
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
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationNoValueFragment())
                .AddFragRef(this.BreastBodyLocationRequiredFragment())
                ;

            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationLeafNode("Skin Retraction")
                ;
        }
    }
}
