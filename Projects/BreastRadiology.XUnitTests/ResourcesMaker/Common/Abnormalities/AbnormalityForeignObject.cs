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
        CSTaskVar AbnormalityForeignObjectCS = new CSTaskVar(
             (out CodeSystem vs) =>
                 vs = Self.CreateCodeSystem(
                         "ForeignObjectCS",
                         "Foreign Object CodeSystem",
                         "Foreign/Object/ CodeSystem",
                         "Foreign objects observed during a Breast Radiology exam code system.",
                         Group_CommonCodesCS,
                         new ConceptDef[]
                         {
                            //+ Type
                             //- Type
                         })
             );


        VSTaskVar AbnormalityForeignObjectVS = new VSTaskVar(
            (out ValueSet vs) =>
            {
                vs = Self.CreateValueSet(
                        "ForeignObjectVS",
                        "Foreign Object ValueSet",
                        "Foreign/Object/ValueSet",
                        "Foreign objects observed during a Breast Radiology exam value set",
                        Group_CommonCodesVS,
                        Self.AbnormalityForeignObjectCS.Value());

                        IntroDoc valueSetIntroDoc = Self.CreateIntroDocVS(vs);
                        valueSetIntroDoc
                            .ReviewedStatus("NOONE", "")
                        ;
                        String outputPath = valueSetIntroDoc.Save();
                        Self.fc?.Mark(outputPath);
            }
            );

        SDTaskVar AbnormalityForeignObject = new SDTaskVar(
            (out StructureDefinition s) =>
            {
                ValueSet binding = Self.AbnormalityForeignObjectVS.Value();

                SDefEditor e = Self.CreateEditor("AbnormalityForeignObject",
                        "Foreign Object",
                        "Foreign Object",
                        Global.ObservationUrl,
                        $"{Group_CommonResources}/AbnormalityForeign",
                        "ObservationSection")
                    .Description("Foreign Object Observation",
                        new Markdown()
                            .Paragraph("These are foreign objects found during a breast radiology exam:")
                    )
                    .AddFragRef(Self.ObservationNoDeviceFragment.Value())
                    .AddFragRef(Self.ObservationNoValueFragment.Value())
                    .AddFragRef(Self.ObservationNoComponentFragment.Value())
                    .AddFragRef(Self.CommonComponentsFragment.Value())
                    .AddFragRef(Self.NotPreviouslySeenComponentsFragment.Value())
                    .AddFragRef(Self.CorrespondsWithComponentFragment.Value())
                    .AddFragRef(Self.BiRadComponentFragment.Value())
                    ;

                s = e.SDef;

                e.IntroDoc
                    .ReviewedStatus("NOONE", "")
                    ;

                // Set Observation.code to unique value for this profile.
                e.Select("code").Pattern(Self.ObservationCodeAbnormalityForeignObject.ToCodeableConcept());

                ElementTreeNode sliceElementDef = e.ConfigureSliceByUrlDiscriminator("hasMember", false);
                e.SliceTargetReference( sliceElementDef, Self.ConsistentWith.Value(), 0, "*");
                e.SliceTargetReference( sliceElementDef, Self.AssociatedFeatures.Value(), 0, "1");

                e.StartComponentSliceing();
                e.ComponentSliceCodeableConcept("abnormalityForeignObjectType",
                    Self.ComponentSliceCodeAbnormalityForeignObjectType.ToCodeableConcept(),
                    binding,
                    BindingStrength.Required,
                    1,
                    "1",
                    "Foreign Object Type",
                    new Markdown()
                        .Paragraph($"This slice contains the required component that refines the foreign object type.",
                                    $"The value of this component is a codeable concept chosen from the {binding.Name} valueset.")
                    );
            });
    }
}
