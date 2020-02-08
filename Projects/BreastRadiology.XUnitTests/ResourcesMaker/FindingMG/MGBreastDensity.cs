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
        //# toto: get from gg
        CSTaskVar MGBreastDensityCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                     "MGBreastDensityCS",
                     "Mammography Breast Density CodeSystem",
                     "MG Breast Density/CodeSystem",
                     "Mammography breast density values code system.",
                     Group_MGCodesCS,
                     new ConceptDef[]
                     {
                         //+ Codes
                         //- Codes
                     }
                 )
             );

        VSTaskVar MGBreastDensityVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                    "MGBreastDensityVS",
                    "Mammography Breast Density ValueSet",
                    "MG Breast DensityValueSet",
                    "Mammography breast density value set.",
                    Group_MGCodesVS,
                    Self.MGBreastDensityCS.Value()
                    )
            );


        SDTaskVar MGBreastDensity = new SDTaskVar(
            (out StructureDefinition  s) =>
            {
                ValueSet binding = Self.MGBreastDensityVS.Value();

                {
                    IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(binding);
                    valueSetIntroDoc
                        .ReviewedStatus("NOONE", "")
                    ;
                    String outputPath = valueSetIntroDoc.Save();
                    Self.fc?.Mark(outputPath);
                }

                SDefEditor e = Self.CreateEditor("MGBreastDensity",
                        "Mammography Breast Density",
                        "MG Breast Density",
                        Global.ObservationUrl,
                        $"{Group_MGResources}/BreastDensity",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .Description("Breast Density Observation",
                        new Markdown()
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    ;

                s = e.SDef;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeMGBreastDensity.ToCodeableConcept());

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    .ACRDescription(
                        "The following four categories of breast composition are defined by the visually estimated content of fibroglandular-density tissue within the breasts. Please note that the ",
                        "categories are listed as a, b, c, and d so as not to be confused with the numbered BI-RADS® assessment categories. If the breasts are not of apparently equal density, the ",
                        "denser breast should be used to categorize breast density. The sensitivity of mammography for noncalcified lesions decreases as the BI-RADS® breast density category ",
                        "increases. The denser the breast, the larger the lesion(s) that may be obscured. There is considerable intra- and inter-observer variation in visually estimating breast density ",
                        "between any two adjacent density categories. Furthermore, there is only a minimal and insignificant difference in the sensitivity of mammography between the densest breast ",
                        "in a lower-density category and the least dense breast in the next-higher-density category. These factors limit the clinical relevance of breast density categorization for the ",
                        "individual woman. "
                    )
                    ;
                ElementDefinition valueXDef = e.Select("value[x]")
                    .Type("CodeableConcept")
                    .Binding(binding.Url, BindingStrength.Required)
                    ;
                e.AddComponentLink("Breast Density Value",
                    new SDefEditor.Cardinality(e.Select("value[x]")),
                    Global.ElementAnchor(valueXDef), 
                    "CodeableConcept", 
                    binding.Url);
            });
    }
}
