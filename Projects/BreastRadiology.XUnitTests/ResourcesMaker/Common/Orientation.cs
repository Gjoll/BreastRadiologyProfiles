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
using PreFhir;

namespace BreastRadiology.XUnitTests
{
    partial class ResourcesMaker : ConverterBase
    {
        CSTaskVar OrientationCS = new CSTaskVar(
             () =>
                 Self.CreateCodeSystem(
                     "OrientationCS",
                     "Orientation CodeSystem",
                     "Orientation CodeSystem",
                     "Orientation CodeSystem",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                    new ConceptDef("Parallel ",
                        "Parallel",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, “wider-than-tall” or “horizontal”)")
                            .Line("The long axis of the mass parallels the skin line. Masses that are only slightly obiquely oriented")
                            .Line("might be considered parallel.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("NotParallel",
                        "Not Parallel",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"isodense\")")
                            .Line("The long axis of the mass does not lie parallel to the skin line. The anterior–posterior or vertical")
                            .Line("dimension is greater than the transverse or horizontal dimension. These masses can also be")
                            .Line("obliquely oriented to the skin line. Round masses are NOT PARALLEL in their orientation.")
                        .CiteEnd(BiRadCitation)
                        )
                     })
             );


        VSTaskVar OrientationVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                        "OrientationVS",
                        "Orientation ValueSet",
                        "Orientation ValueSet",
                        "Orientation ValueSet",
                        Group_CommonCodesVS,
                        Self.OrientationCS.Value()
                    )
            );

        //#StringTaskVar Orientation = new StringTaskVar(
        //    (out String s) =>
        //    {
        //        ValueSet binding = Self.OrientationVS.Value();
        //        {
        //            IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
        //            valueSetIntroDoc
        //                .ValueSet(binding);
        //                .ReviewedStatus(ReviewStatus.NotReviewed)
        //            ;
        //            String outputPath = valueSetIntroDoc.Save();
        //            Self.fc?.Mark(outputPath);
        //        }

        //        SDefEditor e = Self.CreateEditor("Orientation",
        //                "Orientation",
        //                "Orientation",
        //                ObservationUrl,
        //                $"{Group_CommonResources}/Orientation")
        //            .Description("Breast Radiology Orientation Observation",
        //                new Markdown()
        //                    .MissingObservation("a orientation")
        //                    .BiradHeader()
        //                    .BlockQuote("Orientation is defined with reference to the skin")
        //                    .BlockQuote("line. Obliquely situated masses may follow a radial pattern, and their long axes will help determine")
        //                    .BlockQuote("classification as parallel or not parallel. Parallel or \"wider-than-tall\" orientation is a property of most")
        //                    .BlockQuote("benign masses, notably fibroadenomas; however, many carcinomas have this orientation as well.")
        //                    .BlockQuote("Orientation alone should not be used as an isolated feature in assessing a mass for its likelihood of")
        //                    .BlockQuote("malignancy.")
        //                    .BiradFooter()
        //                    //.Todo
        //                )
        //            .AddFragRef(Self.ObservationNoDeviceFragment.Value())
        //            .AddFragRef(Self.ObservationCodedValueFragment.Value())
        //            .AddFragRef(Self.ObservationLeafFragment.Value())
        //            ;
        //        s = e.SDef.Url;

        //        e.IntroDoc
        //            .CodedObservationLeafNode("an orientation", binding)
        //            .ReviewedStatus(ReviewStatus.NotReviewed)
        //            ;

        //        e.Select("value[x]")
        //            .Type("CodeableConcept")
        //            .Binding(binding.Url, BindingStrength.Required)
        //            ;
        //        e.AddValueSetLink(binding);
        //    });
    }
}
