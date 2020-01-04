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
        CSTaskVar MGCalcificationDistributionCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "MammoCalcificationDistributionCS",
                     "Mammography Calcification Distribution CodeSystem",
                     "MG Calc./Distribution/CodeSystem",
                     "Mammography calcification distribution code system.",
                     Group_MGCodesCS,
                     new ConceptDef[]
                     {
                    new ConceptDef("Diffuse",
                        "Diffuse Calcification Distribution",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"scattered\")")
                            .Line("These are calcifications that are distributed randomly throughout the breast. Punctate and")
                            .Line("amorphous calcifications in this distribution are almost always benign, especially if bilateral.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Regional ",
                        "Regional  Calcification Distribution",
                        new Definition()
                        .CiteStart()
                            .Line("This descriptor is used for numerous calcifications that occupy a large portion of breast tissue")
                            .Line("(more than 2 cm in greatest dimension), not conforming to a duct distribution. Since this")
                            .Line("distribution may involve most of a quadrant or even more than a single quadrant, malignancy")
                            .Line("is less likely. However, overall evaluation of regional calcifications must include particle shape")
                            .Line("(morphology) as well as distribution.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Grouped ",
                        "Grouped  Calcification Distribution",
                        new Definition()
                        .CiteStart()
                            .Line("(historically, \"clustered\")")
                            .Line("This term should be used when relatively few calcifications occupy a small portion of breast")
                            .Line("tissue. The lower limit for use of this descriptor is usually when 5 calcifications are grouped")
                            .Line("within 1 cm of each other or when a definable pattern is identified. The upper limit for use")
                            .Line("of this descriptor is when larger numbers of calcifications are grouped within 2 cm of each other.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Linear ",
                        "Linear  Calcification Distribution",
                        new Definition()
                        .CiteStart()
                            .Line("These are calcifications arrayed in a line. This distribution may elevate suspicion for malignancy,")
                            .Line("as it suggests deposits in a duct. Note that both vascular and large rod-like calcifications")
                            .Line("also are usually linear in distribution, but that these typically benign calcifications have")
                            .Line("a characteristically benign morphology.")
                        .CiteEnd(BiRadCitation)
                    ),
                    new ConceptDef("Segmental",
                        "Segmental Calcification Distribution",
                        new Definition()
                        .CiteStart()
                            .Line("Calcifications in a segmental distribution are of concern because they suggest deposits in a")
                            .Line("duct or ducts and their branches, raising the possibility of extensive or multifocal breast cancer")
                            .Line("in a lobe or segment of the breast. Although benign causes of segmental calcifications exist")
                            .Line("(e.g. large rod-like), the smooth, rod-like morphology and large size of benign calcifications")
                            .Line("distinguish them from finer, more pleomorphic or heterogeneous malignant calcifications.")
                            .Line("A segmental distribution may elevate the degree of suspicion for calcifications such as punctate or amorphous forms.")
                        .CiteEnd(BiRadCitation)
                    )
                     }
                 ));


        VSTaskVar MGCalcificationDistributionVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "MammoCalcificationDistributionVS",
                        "Mammography Calcification Distribution ValueSet",
                        "MG Calc./DistributionValueSet",
                        "Mammography calcification distribution value set.",
                        Group_MGCodesVS,
                        Self.MGCalcificationDistributionCS.Value()
                    )
            );


        //#SDTaskVar MGCalcificationDistribution = new SDTaskVar(
        //    (out StructureDefinition  s) =>
        //    {
        //        ValueSet binding = Self.MGCalcificationDistributionVS.Value();

        //        {
        //            IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
        //            valueSetIntroDoc
        //                .ValueSet(binding);
        //                .ReviewedStatus(ReviewStatus.NotReviewed)
        //            ;
        //            String outputPath = valueSetIntroDoc.Save();
        //            Self.fc?.Mark(outputPath);
        //        }

        //        SDefEditor e = Self.CreateEditor("MGCalcificationDistribution",
        //                "Mammography Calcification Distribution",
        //                "MG Calc./Distribution",
        //                ObservationUrl,
        //                $"{Group_MGResources}/Calcification/Distribution")
        //            .Description("Breast Radiology Mammography Calcification Distribution Observation",
        //                new Markdown()
        //                    .Paragraph("This resource describes the calcification distribution observed.")
        //                    .BiradHeader()
        //                    .BlockQuote("These descriptors are used to indicate the arrangement of calcifications in the breast. Multiple")
        //                    .BlockQuote("similar groups may be described in the report when there is more than one group of calcifications")
        //                    .BlockQuote("that are similar in morphology and distribution. In evaluating the likelihood of malignancy for calcifications, ")
        //                    .BlockQuote("distribution is at least as important as morphology.")
        //                    .BiradFooter()
        //                    //.Todo
        //            )
        //            .AddFragRef(Self.ObservationNoDeviceFragment.Value())
        //            .AddFragRef(Self.ObservationCodedValueFragment.Value())
        //            .AddFragRef(Self.ObservationLeafFragment.Value())
        //            ;
        //        s = e.SDef.Url;

        //        e.IntroDoc
        //            .CodedObservationLeafNode("a mammography calcification distribution", binding)
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
