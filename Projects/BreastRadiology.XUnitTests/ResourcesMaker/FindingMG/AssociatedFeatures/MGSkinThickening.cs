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
        StringTaskVar MGSkinThickening = new StringTaskVar(
            (out String s) =>
            {
                SDefEditor e = ResourcesMaker.Self.CreateEditor("MGSkinThickening",
                    "Mammography Skin Thickening",
                    "MG Skin Thickening",
                    ObservationUrl,
                    $"{Group_MGResources}/AssociatedFeature/SkinThickening")
                    .Description("Mammography Skin Thickening Observation",
                        new Markdown()
                            .BiradHeader()
                            .BlockQuote("Skin thickening may be focal or diffuse, and is defined as being greater than 2 mm in thickness. This ")
                            .BlockQuote("finding is of particular concern if it represents a change from previous mammography examinations. ").BlockQuote("However, unilateral skin thickening is an expected finding after radiation therapy.")
                            .BiradFooter()
                            .Todo(
                                "Add choice for focal or diffuse (see definition)?",
                                "Add body location?",
                                "Add size measurement?",
                                "cardinality 0..1 or 0..*?"
                            )
                    )
                    .AddFragRef(ResourcesMaker.Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.ObservationNoValueFragment.Value())
                    .AddFragRef(ResourcesMaker.Self.BreastBodyLocationRequiredFragment.Value())
                    ;
                s = e.SDef.Url;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ObservationLeafNode("Skin Thickening")
                    ;
            });
    }
}
