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
        String MGMassMargin()
        {
            if (this.mgMassMargin == null)
                this.CreateMGMassMargin();
            return this.mgMassMargin;
        }
        String mgMassMargin = null;


        VSTaskVar BreastRadMammoMassMarginVS = new VSTaskVar(
            () =>
                ResourcesMaker.Self.CreateValueSetXX(
                    "BreastRadMammoMassMargin",
                    "Mammography Mass Margin",
                    "Mg Mass MarginValueSet",
                    "Mammography mass margin ValueSet.",
                    Group_MGCodes,
                    ResourcesMaker.Self.CommonMarginCS.Value()
                    )
            );


        void CreateMGMassMargin()
        {
            ValueSet binding = this.BreastRadMammoMassMarginVS.Value();
            binding
                .Remove("IntraductalExtension")
                .Remove("Lobulated")
                .Remove("NonCircumscribed")
                .Remove("Smooth")
                ;
            {
                IntroDoc valueSetIntroDoc = new IntroDoc(Path.Combine(this.pageDir, $"ValueSet-{binding.Name}-intro.xml"));
                valueSetIntroDoc
                    .ReviewedStatus(ReviewStatus.NotReviewed)
                    .ValueSet(binding);
                ;
                String outputPath = valueSetIntroDoc.Save();
                this.fc?.Mark(outputPath);
            }

            SDefEditor e = this.CreateEditor("BreastRadMammoMassMargin",
                "Mammography Mass Margin",
                "Mg Mass Margin",
                ObservationUrl,
                $"{Group_MGResources}/Mass/Margin",
                out this.mgMassMargin)
                .Description("Breast Radiology Mammography Mass Margin Observation",
                    new Markdown()
                        .MissingObservation("a mass margin")
                        .BiradHeader()
                        .BlockQuote("The margin is the edge or border of the lesion. The descriptors of margin, like the descriptors of shape, are important predictors of whether a mass is benign or malignant. ")
                        .BiradFooter()
                        .Todo(
                        )
                )
                .AddFragRef(this.ObservationNoDeviceFragment())
                .AddFragRef(this.ObservationCodedValueFragment())
                .AddFragRef(this.ObservationLeafFragment())
                ;

            e.Select("value[x]")
                .Type("CodeableConcept")
                .Binding(binding.Url, BindingStrength.Required)
                ;
            e.AddValueSetLink(binding);
            e.IntroDoc
                .ReviewedStatus(ReviewStatus.NotReviewed)
                .CodedObservationLeafNode("a mammography mass margin", binding)
                ;
        }
    }
}
