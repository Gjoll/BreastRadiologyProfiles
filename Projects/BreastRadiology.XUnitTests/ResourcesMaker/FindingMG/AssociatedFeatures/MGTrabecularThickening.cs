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
        String MGTrabecularThickening()
        {
            if (this.mgTrabecularThickening == null)
                this.CreateMGTrabecularThickening();
            return this.mgTrabecularThickening;
        }
        String mgTrabecularThickening = null;

        void CreateMGTrabecularThickening()
        {
            SDefEditor e = this.CreateEditor("BreastRadMammoTrabecularThickening",
                "Mammography Trabecular Thickening",
                "Mg Trabecular/Thickening",
                ObservationUrl,
                $"{Group_MGResources}/AssociatedFeature/TrabecularThickening")
                .Description("Trabecular Thickening Observation",
                    new Markdown()
                        .BiradHeader()
                        .BlockQuote("This is a thickening of the fibrous septa of the breast.")
                        .BiradFooter()
                        .MissingObservation("a trabecular thickening")
                        .Todo(
                            "Add body location?",
                            "Add size measurement?",
                            "cardinality 0..1 or 0..*?"
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment.Value())
                .AddFragRef(this.BreastBodyLocationRequiredFragment.Value())
                .AddFragRef(this.ObservationNoValueFragment.Value())
                ;
            this.mgTrabecularThickening = e.SDef.Url;
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .ObservationLeafNode("Trabecular Thickening")
                ;
        }
    }
}
