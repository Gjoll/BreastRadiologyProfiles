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
        //#SDTaskVar MGTrabecularThickening = new SDTaskVar(
        //    (out StructureDefinition  s) =>
        //    {
        //        SDefEditor e = Self.CreateEditor("MGTrabecularThickening",
        //            "Mammography Trabecular Thickening",
        //            "MG Trabecular/Thickening",
        //            ObservationUrl,
        //            $"{Group_MGResources}/AssociatedFeature/TrabecularThickening")
        //            .Description("Trabecular Thickening Observation",
        //                new Markdown()
        //                    .BiradHeader()
        //                    .BlockQuote("This is a thickening of the fibrous septa of the breast.")
        //                    .BiradFooter()
        //                    .MissingObservation("a trabecular thickening")
        //                    //.Todo
        //            )
        //            .AddFragRef(Self.ObservationNoDeviceFragment.Value())
        //            .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
        //            .AddFragRef(Self.ObservationNoValueFragment.Value())
        //            ;
        //        s = e.SDef.Url;
        //        e.IntroDoc
        //            .ObservationLeafNode("Trabecular Thickening")
        //            .ReviewedStatus(ReviewStatus.NotReviewed)
        //            ;
        //    });
    }
}
