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
        CSTaskVar ObservedFeatureCS = new CSTaskVar(
             (out CodeSystem vs) =>
                 vs = Self.CreateCodeSystem(
                         "ObservedFeatureCS",
                         "Observed Feature CodeSystem",
                         "ObservedFeature/CodeSystem",
                         "Observed Feature seen during a breast examination.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                            //+ ObservedFeatureCS
                            //- ObservedFeatureCS
                         })
             );


        VSTaskVar ObservedFeatureVS = new VSTaskVar(
            (out ValueSet vs) =>
            {
                vs = Self.CreateValueSet(
                        "ObservedFeatureVS",
                        "Observed Feature ValueSet",
                        "Observed Feature/ValueSet",
                        "Observed feature observed during a Breast Radiology exam value set",
                        Group_CommonCodesVS,
                        Self.ObservedFeatureCS.Value());

                IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(vs);
                valueSetIntroDoc
                    .ReviewedStatus("NOONE", "")
                ;
                String outputPath = valueSetIntroDoc.Save();
                Self.fc?.Mark(outputPath);
            }
            );

        SDTaskVar ObservedFeature = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.ObservedFeatureVS.Value();

                SDefEditor e = Self.CreateEditor("ObservedFeature",
                    "Observed Feature",
                    "Observed Feature",
                    Global.ObservationUrl,
                    $"{Group_CommonResources}/AssociatedFeature/ObservedFeature",
                        "ObservationLeaf")
                    .AddFragRef(Self.ObservationLeafFragment.Value())
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.BreastBodyLocationRequiredFragment.Value())
                    .AddFragRef(Self.ObservedCountComponentFragment.Value())
                    .Description("Observed Feature Observation",
                        new Markdown()
                            .Paragraph("The feature observed is defined by the codeable concept in the value[x] field.")
                    )
                    ;
                s = e.SDef;
                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeObservedFeature.ToCodeableConcept());

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("featureType",
                    Self.ComponentSliceCodeObservedFeatureType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "Observed Feature Type",
                    new Markdown()
                        .Paragraph($"This slice contains the required component that defines the observed feature.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
            });
    }
}
