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
        SDTaskVar MGSkinLesion = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                SDefEditor e = Self.CreateEditorObservationLeaf("MGSkinLesion",
                    "Mammography Skin Lesion",
                    "MG Skin Lesion",
                    $"{Group_MGResources}/SkinLesion")
                    .Description("Breast Radiology Mammography Skin Lesion Observation",
                        new Markdown()
                            .MissingObservation("a skin lesion")
                            .BiradHeader()
                            .BlockQuote("This finding may be described in the mammography report or annotated on the mammographic")
                            .BlockQuote("image when it projects over the breast (especially on 2 different projections), and may be mistaken")
                            .BlockQuote("for an intramammary lesion. A raised skin lesion sufficiently large to be seen at mammography")
                            .BlockQuote("should be marked by the technologist with a radiopaque device designated for use as a marker for")
                            .BlockQuote("a skin lesion.")
                            .BiradFooter()
                            //.Todo
                    )
                    .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value().Url)
                    .AddFragRef(Self.ObservationNoValueFragment.Value().Url)
                    .AddFragRef(Self.MGCommonTargetsFragment.Value().Url)
                    ;
                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    ;

            });
    }
}
