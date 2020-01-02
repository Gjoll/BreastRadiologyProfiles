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
        VSTaskVar MarginVS = new VSTaskVar(
            () =>
                Self.CreateValueSet(
                    "MarginVS",
                    "Margin ValueSet",
                    "MarginValueSet",
                    "Margin ValueSet.",
                    Group_CommonCodesVS,
                    Self.MarginCS.Value()
                    )
            );


        //#StringTaskVar Margin = new StringTaskVar(
        //    (out String s) =>
        //    {
        //        ValueSet binding = Self.MarginVS.Value();
        //        binding
        //            .Remove("IntraductalExtension")
        //            .Remove("Lobulated")
        //            .Remove("NonCircumscribed")
        //            .Remove("Smooth")
        //            ;
        //        {
        //            IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(Self.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
        //            valueSetIntroDoc
        //                .ValueSet(binding);
        //                .ReviewedStatus(ReviewStatus.NotReviewed)
        //            ;
        //            String outputPath = valueSetIntroDoc.Save();
        //            Self.fc?.Mark(outputPath);
        //        }

        //        SDefEditor e = Self.CreateEditor("Margin",
        //            "Margin",
        //            "Margin",
        //            ObservationUrl,
        //            $"{Group_CommonResources}/Margin")
        //            .Description("Breast Radiology Mammography Margin Observation",
        //                new Markdown()
        //                    .MissingObservation("a margin")
        //                    .BiradHeader()
        //                    .BlockQuote("The margin is the edge or border of the lesion. The descriptors of margin, like the descriptors of shape, are important predictors of whether a mass is benign or malignant. ")
        //                    .BiradFooter()
        //                    //.Todo
        //            )
        //            .AddFragRef(Self.ObservationNoDeviceFragment.Value())
        //            .AddFragRef(Self.ObservationCodedValueFragment.Value())
        //            .AddFragRef(Self.ObservationLeafFragment.Value())
        //            ;
        //        s = e.SDef.Url;

        //        e.IntroDoc
        //            .CodedObservationLeafNode("a mammography margin", binding)
        //            .ReviewedStatus(ReviewStatus.NotReviewed)
        //            ;

        //        e.Select("value[x]")
        //            .Type("CodeableConcept")
        //            .Binding(binding.Url, BindingStrength.Required)
        //            ;
        //        e.AddValueSetLink(binding);
        //    });

        CSTaskVar MarginCS = new CSTaskVar(
             () =>
                 Self.CreateCodeSystem(
                     "MarginCS",
                     "MarginCodeSystem",
                     "Margin CodeSystem",
                     "Margin code system.",
                     Group_CommonCodesCS,
                     new ConceptDef[]
                     {
                    new ConceptDef("Angular",
                        "Not Circumscribed - Angular",
                        new Definition()
                        .CiteStart()
                            .Line("Some or all of the margin has sharp corners, often forming acute angles, but the significant")
                            .Line("feature is that the margin of the mass is NOT CIRCUMSCRIBED.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Circumscribed ",
                        "Circumscribed Margin",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, “well-defined” or “sharply-defined”)")
                            .Line("A circumscribed margin is one that is well defined, with an abrupt transition between the")
                            .Line("lesion and the surrounding tissue. For US, to describe a mass as circumscribed, its entire margin")
                            .Line("must be sharply defined. Most circumscribed lesions have round or oval shapes.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Indistinct",
                        "Indistinct Margin",
                        new Definition()
                        .CiteStart()
                            .Line("There is no clear demarcation of the entire margin or any portion of the margin from the")
                            .Line("surrounding tissue. The boundary is poorly defined, and the significant feature is that the")
                            .Line("mass is NOT CIRCUMSCRIBED. This is meant to include “echogenic rim” (historically, echogenic")
                            .Line("halo) because one may not be able to distinguish between an indistinct margin and")
                            .Line("one that displays an echogenic rim.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("IntraductalExtension",
                        "Intraductal Extension",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("Irregular",
                        "Irregular Margin",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("Lobulated",
                        "Lobulated Margin",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("Macrolobulated",
                        "Microlobulated Margin",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("Microlobulated",
                        "Not Circumscribed - Microlobulated",
                        new Definition()
                        .CiteStart()
                            .Line("The margin is characterized by short-cycle undulations, but the significant feature is that")
                            .Line("the margin of the mass is NOT CIRCUMSCRIBED.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("NonCircumscribed",
                        "Non Circumscribed Margin",
                        new Definition()
                        .CiteStart()
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Obscured",
                        "Obscured Margin",
                        new Definition()
                        .CiteStart()
                            .Line("A margin that is hidden by superimposed or adjacent fibroglandular tissue. This is used")
                            .Line("primarily when some of the margin of the mass is circumscribed, but the rest (more than 25%) is hidden.")
                        .CiteEnd(BiRadCitation)
                        ),
                    new ConceptDef("Smooth",
                        "Smooth Margin",
                        new Definition()
                            .Line("[PR]")
                        ),
                    new ConceptDef("Spiculated",
                        "Not Circumscribed - Spiculated",
                        new Definition()
                        .CiteStart()
                            .Line("The margin is characterized by sharp lines radiating from the mass, often a sign of malignancy,")
                            .Line("but the significant feature is that the margin of the mass is NOT CIRCUMSCRIBED.")
                        .CiteEnd(BiRadCitation)
                        )
                     })
                 );
    }
}
