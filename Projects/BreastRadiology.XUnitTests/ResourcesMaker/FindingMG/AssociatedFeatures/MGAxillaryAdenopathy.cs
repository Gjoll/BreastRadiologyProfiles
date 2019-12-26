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
        String MGAxillaryAdenopathy()
        {
            if (this.mgAxillaryAdenopathy == null)
                this.CreateMGAxillaryAdenopathy();
            return this.mgAxillaryAdenopathy;
        }
        String mgAxillaryAdenopathy = null;

        void CreateMGAxillaryAdenopathy()
        {
            SDefEditor e = this.CreateEditor("BreastRadMammoAxillaryAdenopathy",
                "Mammography Axillary Adenopathy",
                "Mg Axillary/Adenopathy",
                ObservationUrl,
                $"{Group_MGResources}/AssociatedFeature/AxillaryAdenopathy")
                .Description("Breast Radiology Mammography Axillary Adenopathy Observation",
                    new Markdown()
                        .MissingObservation("an axillary adenopathy")
                        .BiradHeader()
                        .BlockQuote("Enlarged axillary lymph nodes may warrant comment, clinical correlation, and additional ")
                        .BlockQuote("evaluation, especially if new or considerably larger or rounder when compared to previous examination.")
                        .BlockQuote("A review of the patient’s medical history may elucidate the cause for axillary adenopathy, averting")
                        .BlockQuote("recommendation for additional evaluation. When one or more large axillary nodes are ")
                        .BlockQuote("substantially composed of fat, this is a normal variant.")
                        .BiradFooter()
                        .Todo(
                            "Cardinalioty?",
                            "Body Location?",
                            "Size?"
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment.Value())
                .AddFragRef(this.ObservationNoValueFragment.Value())
                .AddFragRef(this.BreastBodyLocationRequiredFragment.Value())
                ;
            this.mgAxillaryAdenopathy = e.SDef.Url;
            e.IntroDoc
            .ReviewedStatus(ReviewStatus.NotReviewed)
            .ObservationLeafNode("Mammography Axillary Adenopathy")
            ;
        }
    }
}
