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
    partial class ResourcesMaker
    {
        SDTaskVar ConsistentWith = new SDTaskVar(
               (out StructureDefinition  s) =>
                   {
                       SDefEditor e = Self.CreateEditor("ConsistentWith",
                        "Consistent With",
                        "Consistent/With",
                        Global.ObservationUrl,
                        $"{Group_CommonResources}/ConsistentWith",
                        "ObservationLeaf")
                           .AddFragRef(Self.ObservationLeafFragment.Value())
                           .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                           .AddFragRef(Self.ObservationNoValueFragment.Value())
                           .AddFragRef(Self.ObservationNoComponentFragment.Value())
                           .Description("'Consistent With' Observation",
                               new Markdown()
                           )
                           ;
                       s = e.SDef;

                       // Set Observation.code to unique value for this profile.
                       e.Select("code").Pattern(Self.ObservationCodeConsistentWith.ToCodeableConcept());


                       e.StartComponentSliceing();
                       e.ComponentSliceCodeableConcept("value",
                           Self.ComponentSliceCodeConsistentWithValue.ToCodeableConcept(),
                           Self.ConsistentWithVS.Value(),
                           BindingStrength.Extensible,
                           1,
                           "1",
                           "Consistent With Value",
                            new Markdown()
                                .Paragraph($"This slice contains the required component that defines what this observation is consistent with.",
                                            $"The value of this component is a codeable concept chosen from the {Self.ConsistentWithVS.Value().Name} valueset.")
                       );
                       e.ComponentSliceCodeableConcept("qualifier",
                           Self.ComponentSliceCodeConsistentWithQualifier.ToCodeableConcept(),
                           Self.ConsistentWithQualifierVS.Value(),
                           BindingStrength.Required,
                           0,
                           "*",
                           "Consistent With Qualifier",
                            new Markdown()
                                .Paragraph($"This slice contains zero or more components that qualify the consistent with slice component value.",
                                            $"The value of this component is a codeable concept chosen from the {Self.ConsistentWithVS.Value().Name} valueset.")
                           );

                       e.IntroDoc
                           .ReviewedStatus("NOONE", "")
                           ;
                   });

        VSTaskVar ConsistentWithVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "ConsistentWithVS",
                        "ConsistentWith ValueSet",
                        "ConsistentWith/ValueSet",
                        "ConsistentWith value set.",
                        Group_CommonCodesVS,
                        Self.ConsistentWithCS.Value()
                    )
            );

        VSTaskVar ConsistentWithQualifierVS = new VSTaskVar(
            (out ValueSet vs) =>
                vs = Self.CreateValueSet(
                        "ConsistentWithQualifierVS",
                        "ConsistentWithQualifier ValueSet",
                        "ConsistentWithQualifier/ValueSet",
                        "ConsistentWithQualifier value set.",
                        Group_CommonCodesVS,
                        Self.ConsistentWithQualifierCS.Value()
                    )
            );

        CSTaskVar ConsistentWithCS = new CSTaskVar(
            (out CodeSystem cs) =>
                cs = Self.CreateCodeSystem(
                        "ConsistentWithCodeSystemCS",
                        "Consistent With CodeSystem",
                        "ConsistentWith/CodeSystem",
                        "ConsistentWith code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            //+ Codes
                            //- Codes
                        })
            );


        CSTaskVar ConsistentWithQualifierCS = new CSTaskVar(
             (out CodeSystem cs) =>
                 cs = Self.CreateCodeSystem(
                        "ConsistentWithQualifierCS",
                        "ConsistentWith Qualifier CodeSystem",
                        "ConsistentWithQualifier/ValueSet",
                        "ConsistentWithQualifier  code system",
                        Group_CommonCodesCS,
                        new ConceptDef[]
                        {
                            //+ Qualifiers
                            //- Qualifiers
                        })
             );
    }
}
